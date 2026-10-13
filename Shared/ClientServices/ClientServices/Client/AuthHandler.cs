using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using ClientServices.ClientServices.Tokens;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Microsoft.Extensions.Http;
using ClientServices.ClientServices.Role;
using System.Text;



public class JwtAuthenticationHandler : DelegatingHandler
{
    private readonly ITokens _tokens;
    private readonly IRole _Role;
    protected readonly ILogger<JwtAuthenticationHandler> _logger;
    private readonly string _refreshTokenSubRoute;
    
  
    private readonly SemaphoreSlim _refreshLock = new SemaphoreSlim(1, 1);
    
    

    

    private static readonly HttpRequestOptionsKey<bool> IsLoginRequestKey =
        new HttpRequestOptionsKey<bool>("IsLoginRequest");

    private static readonly HttpRequestOptionsKey<bool> IsLoginRefreshTokenRequest =
        new HttpRequestOptionsKey<bool>("IsLoginRefreshTokenRequest");

    public JwtAuthenticationHandler(
        ITokens tokens,      
        ILogger<JwtAuthenticationHandler> logger,
        
        IRole role = null,
        string refreshTokenSubRoute = "Login/SystemUserRefreshToken")
    {
        _tokens = tokens;
        _logger = logger;
        _refreshTokenSubRoute = refreshTokenSubRoute;
       
        _Role = role;
    }

  
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        bool isLoginRefreshToken = request.Options.TryGetValue(IsLoginRefreshTokenRequest, out bool value) && value;

        if (isLoginRefreshToken)
        {
            return await HandleLoginRefreshTokenRequest(cancellationToken);
        }

        bool isLoginRequest = request.Options.TryGetValue(IsLoginRequestKey, out bool loginValue) && loginValue;

        

        if (!isLoginRequest)
        {
            string? jwt = await _tokens.GetJWTToken();
            if (!string.IsNullOrEmpty(jwt))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                
            }
        }

        var response = await base.SendAsync(request, cancellationToken);

        if (isLoginRequest && response.IsSuccessStatusCode)
        {
            await SaveTokensFromLoginResponse(response);

            await _SaveRoleFromToken();

            var jwt = await _tokens.GetJWTToken();
            if (string.IsNullOrWhiteSpace(jwt))
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);

            return new HttpResponseMessage(statusCode: HttpStatusCode.OK)
            {
                Content = new StringContent(jwt)
            };
        }

        if (response.StatusCode == HttpStatusCode.Unauthorized && !isLoginRequest)
        {
            _logger.LogWarning("Received 401, attempting token refresh...");

            if (await RefreshJwtToken(cancellationToken))
            {
                var retryRequest = await CloneRequest(request);
                var newJwt = await _tokens.GetJWTToken();
                if (!string.IsNullOrEmpty(newJwt))
                {
                    retryRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", newJwt);
                }
                response = await base.SendAsync(retryRequest, cancellationToken);
            }
            else
            {
                await _tokens.Clear();
                _logger.LogWarning("Token refresh failed, session cleared.");

            }
        }

        return response;
    }

    private async Task<string?> _GetRole()
    {
        if (_Role == null) return null;

        var Role = await _Role.GetRole();

        return Role;
    }
    private async Task<HttpResponseMessage> HandleLoginRefreshTokenRequest(CancellationToken cancellationToken)
    {
        var refreshToken = await _tokens.GetRefreshToken();

        if (string.IsNullOrWhiteSpace(refreshToken))
        {
            _logger.LogWarning("Refresh Token Not Found");
            await _tokens.Clear();
            return new HttpResponseMessage(statusCode: HttpStatusCode.Unauthorized);
            
        }

        var jsonContent = JsonSerializer.Serialize(refreshToken);

        var refreshRequest = new HttpRequestMessage(HttpMethod.Post, _refreshTokenSubRoute)
        {
            Content = new StringContent(jsonContent, Encoding.UTF8, "application/json")
        };



        var refreshResponse = await base.SendAsync(refreshRequest, cancellationToken);
        if (refreshResponse.IsSuccessStatusCode)
        {
            var newJwt = await refreshResponse.Content.ReadAsStringAsync(cancellationToken);
            if (!string.IsNullOrWhiteSpace(newJwt))
            {
                await _tokens.SetJWTToken(newJwt);
            }
        }

        else
        {
            await _tokens.Clear();
            return new HttpResponseMessage(HttpStatusCode.Unauthorized);
        }

        return refreshResponse;


    }

    private async Task<bool> RefreshJwtToken(CancellationToken cancellationToken)
    {
        await _refreshLock.WaitAsync();

        try
        {

            if (!await IsJwtTokenExpiringSoon())
            {
                _logger.LogInformation("Token refreshed already");
               
                return true;
            }

            var refreshToken = await _tokens.GetRefreshToken();

            if (string.IsNullOrEmpty(refreshToken))
                return false;

            var jsonContent = JsonSerializer.Serialize(refreshToken);

            var refreshRequest = new HttpRequestMessage(HttpMethod.Post, _refreshTokenSubRoute)
            {
                Content = new StringContent(jsonContent, Encoding.UTF8, "application/json")
            };


            var refreshResponse = await base.SendAsync(refreshRequest, cancellationToken);

            if (!refreshResponse.IsSuccessStatusCode)
                return false;

            var newJwt = await refreshResponse.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(newJwt))
                return false;

            await _tokens.SetJWTToken(newJwt);
            _logger.LogInformation("Token refreshed successfully");
            return true;
        }
        finally
        {
            _refreshLock.Release();
        }
    }

    private async Task SaveTokensFromLoginResponse(HttpResponseMessage loginResponse)
    {
        
      
            var body = await loginResponse.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(body);
            var root = doc.RootElement;

            if (root.TryGetProperty("JWT_Token", out var jwtProp) &&
                root.TryGetProperty("Refresh_Token", out var refreshProp))
            {
                var jwt = jwtProp.GetString();
                var refresh = refreshProp.GetString();

                if (!string.IsNullOrEmpty(jwt) && !string.IsNullOrEmpty(refresh))
                {
                    await _tokens.SetJWTToken(jwt);
                    await _tokens.SetRefreshToken(refresh);
                    _logger.LogInformation("Tokens saved successfully from login response");
                    return;
                }
            }

            _logger.LogError("Login response missing required tokens (JWT_Token or Refresh_Token)");
        
        
    }

    private async Task _SaveRoleFromToken()
    {

        if (_Role == null) return;

        var token = await _tokens.GetJWTToken();

        if (string.IsNullOrWhiteSpace(token)) return;

        await _Role.SetRole(token);

    }
    

    private async Task<HttpRequestMessage> CloneRequest(HttpRequestMessage request)
    {
        var clone = new HttpRequestMessage(request.Method, request.RequestUri);

        foreach (var header in request.Headers)
            clone.Headers.TryAddWithoutValidation(header.Key, header.Value);

        if (request.Content != null)
        {
            var ms = new MemoryStream();
            await request.Content.CopyToAsync(ms);
            ms.Position = 0;
            clone.Content = new StreamContent(ms);
            foreach (var header in request.Content.Headers)
                clone.Content.Headers.TryAddWithoutValidation(header.Key, header.Value);
        }

        return clone;
    }

    private async Task<bool> IsJwtTokenExpiringSoon()
    {
        var jwtToken = await _tokens.GetJWTToken();

        if (string.IsNullOrWhiteSpace(jwtToken))
            return true;

        var handler = new JwtSecurityTokenHandler();

        if (!handler.CanReadToken(jwtToken))
            return true;   

        var token = handler.ReadJwtToken(jwtToken);
        return token.ValidTo <= DateTime.UtcNow.AddMinutes(1);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _refreshLock?.Dispose();
          
        }
        base.Dispose(disposing);
    }
}
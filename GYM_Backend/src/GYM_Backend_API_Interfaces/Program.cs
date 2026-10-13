using System.Text;
using Gym_Backend_BusinessTier.Services.FitnessType;
using Gym_Backend_BusinessTier.Services.Gym;
using Gym_Backend_BusinessTier.Services.Gym.GymSubscription;
using Gym_Backend_BusinessTier.Services.Gym.GymSubscription.GymSubscriptionPayment;
using Gym_Backend_BusinessTier.Services.Login;
using Gym_Backend_BusinessTier.Services.Login.Session;
using Gym_Backend_BusinessTier.Services.Person;
using Gym_Backend_MiddleWares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ProjectsServices.JWTServices;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<scSystemUserLoginService>();

builder.Services.AddScoped<scSessionService>();

builder.Services.AddScoped<scSystemUserLoginByRefreshTokenService>();

builder.Services.AddScoped<scCreateCompletedPersonService>();

builder.Services.AddScoped<scCreateGymService>();

builder.Services.AddScoped<scAddFitnessTypeService>();



builder.Services.AddScoped<scAddGymSubscriptionService>();

builder.Services.AddScoped<scAddGymSubscriptionPaymentService>();

var jwtConfig = builder.Configuration.GetSection("JwtSettings").Get<clsJWTTemplate>();
if (jwtConfig == null || string.IsNullOrEmpty(jwtConfig.Key))
{
    throw new Exception("JwtSettings or SigningKey in appsettings.json is null or empty. Please check your configuration.");
}
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = jwtConfig.Issuer,
        ValidateAudience = true,
        ValidAudience = jwtConfig.Audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key)),
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

var app = builder.Build();

app.UseMiddleware<ExceptionLoggingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
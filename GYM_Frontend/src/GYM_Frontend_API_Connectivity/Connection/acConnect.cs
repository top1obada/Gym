using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Frontend_API_Connectivity.Connection
{
    public abstract class acConnect
    {
        protected HttpClient _Client;
        public acConnect(HttpClient client)
        {

            _Client = client;

        }

    }
}

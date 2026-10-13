using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServices.ClientServices.Role
{
    public interface IRole
    {

        Task SetRole(string Value);

        Task<string?> GetRole();

        Task Remove();

    }
}

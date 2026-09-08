using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Backend_BusinessTier.ServicesInterfaces.Check
{
    public interface ICheckService<TObject>
    {

        Task<bool> Check(TObject obj);

    }
}

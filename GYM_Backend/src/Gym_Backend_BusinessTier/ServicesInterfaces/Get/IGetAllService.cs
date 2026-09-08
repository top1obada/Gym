using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Backend_BusinessTier.ServicesInterfaces.Get
{
    public interface IGetAllService<TResult>
    {

        Task<TResult> Get();

    }
}

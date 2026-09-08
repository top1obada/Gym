using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Backend_BusinessTier.ServicesInterfaces.Find
{
    public interface IFindService<TObject,TResult>
    {

        Task<TResult> Find(TObject obj);

    }
}

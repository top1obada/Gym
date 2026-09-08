using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Backend_BusinessTier.ServicesInterfaces.Save
{
    public interface ISaveService<TObject,TResult>
    {

        Task<TResult> Save(TObject Object);
     

    }

}

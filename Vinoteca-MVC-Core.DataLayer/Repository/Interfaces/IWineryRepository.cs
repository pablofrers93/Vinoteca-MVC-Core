using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinoteca_MVC_Core.Models.Models;

namespace Vinoteca_MVC_Core.DataLayer.Repository.Interfaces
{
    public interface IWineryRepository : IRepository<Winery>
    {
        void Update(Winery winery);
        bool Exists(Winery winery);
        bool CheckNoChanges(Winery winery);
    }
}

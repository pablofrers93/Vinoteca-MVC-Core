using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinoteca_MVC_Core.Models.Models;

namespace Vinoteca_MVC_Core.DataLayer.Repository.Interfaces
{
    public interface IVarietyRepositoryIVarietyRepository : IRepository<Variety>
    {
        void Update(Variety variety);
        bool Exists(Variety variety);
        bool CheckNoChanges(Variety variety);
    }
}

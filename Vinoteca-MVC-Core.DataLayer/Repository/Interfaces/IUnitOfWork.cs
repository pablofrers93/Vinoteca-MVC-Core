using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vinoteca_MVC_Core.DataLayer.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IVarietyRepository Varieties { get; }
        void Save();
    }
}

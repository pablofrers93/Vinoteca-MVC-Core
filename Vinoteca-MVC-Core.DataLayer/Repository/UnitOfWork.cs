using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinoteca_MVC_Core.Data;
using Vinoteca_MVC_Core.DataLayer.Repository.Interfaces;

namespace Vinoteca_MVC_Core.DataLayer.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Varieties = new VarietyRepository(db);
        }

        public IVarietyRepository Varieties { get; private set; }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}

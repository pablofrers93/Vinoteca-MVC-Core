using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinoteca_MVC_Core.Data;
using Vinoteca_MVC_Core.Models.Models;

namespace Vinoteca_MVC_Core.DataLayer.Repository
{
    public class VarietyRepository : Repository<Variety>, IVarietyRepository
    {
        private readonly ApplicationDbContext _db;

        public VarietyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public bool Exists(Variety variety)
        {
            if (variety.Id == 0)
            {
                return _db.Varieties.Any(c => c.VarietyName == variety.VarietyName);
            }
            return _db.Varieties.Any(c => c.VarietyName == variety.VarietyName && c.Id != variety.Id);
        }

        public void Update(Variety variety)
        {
            _db.Varieties.Update(variety);
        }

        public bool CheckNoChanges(Variety variety)
        {
            return (_db.Varieties.Any(c => c.VarietyName == variety.VarietyName && c.Id == variety.Id && variety.DisplayOrder == c.DisplayOrder));
        }
    }
}

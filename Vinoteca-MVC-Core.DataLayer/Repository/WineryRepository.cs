using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinoteca_MVC_Core.Data;
using Vinoteca_MVC_Core.DataLayer.Repository.Interfaces;
using Vinoteca_MVC_Core.Models.Models;

namespace Vinoteca_MVC_Core.DataLayer.Repository
{
    public class WineryRepository : Repository<Winery>, IWineryRepository
    {
        private readonly ApplicationDbContext _db;

        public WineryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public bool Exists(Winery winery)
        {
            if (winery.Id == 0)
            {
                return _db.Wineries.Any(c => c.WineryName == winery.WineryName);
            }
            return _db.Wineries.Any(c => c.WineryName == winery.WineryName && c.Id != winery.Id);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
        public void Update(Winery winery)
        {
            _db.Wineries.Update(winery);
        }

        public bool CheckNoChanges(Winery winery)
        {
            return (_db.Wineries.Any(c => c.WineryName == winery.WineryName && c.Id == winery.Id));
        }
    }
}

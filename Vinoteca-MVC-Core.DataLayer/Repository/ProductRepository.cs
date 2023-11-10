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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public bool Exists(Product product)
        {
            if (product.Id == 0)
            {
                return _db.Products.Any(c => c.Description == product.Description);
            }
            return _db.Products.Any(c => c.Description == product.Description && c.Id != product.Id);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
        public void Update(Product product)
        {
            _db.Products.Update(product);
        }

        public bool CheckNoChanges(Product product)
        {
            return (_db.Products.Any(c => c.Description == product.Description &&
                                     c.Id == product.Id && 
                                     c.Price == product.Price &&
                                     c.Winemaker_Notes == product.Winemaker_Notes &&
                                     c.ImageUrl == product.ImageUrl &&
                                     c.WineryId == product.WineryId &&
                                     c.VarietyId == product.VarietyId && 
                                     c.Stock == product.Stock));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinoteca_MVC_Core.Models.Models;

namespace Vinoteca_MVC_Core.DataLayer.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
        bool Exists(Product product);
        bool CheckNoChanges(Product product);
    }
}

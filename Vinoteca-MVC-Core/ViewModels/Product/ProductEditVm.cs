using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Vinoteca_MVC_Core.ViewModels.Product
{
    public class ProductEditVm
    {
        public Models.Models.Product Product { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> WineriesList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> VarietiesList { get; set; }
    }
}

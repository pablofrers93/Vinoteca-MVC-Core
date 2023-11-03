using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Vinoteca_MVC_Core.Models.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Must be between {2} and {1}", MinimumLength = 3)]
        public string Description { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "Must be between {2} and {1}", MinimumLength = 3)]
        public string Winemaker_Notes { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Price { get; set; }

        [Display(Name = "Image")]
        [ValidateNever]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Winery")]
        public int WineryId { get; set; }
        
        [Required]
        [Display(Name = "Variety")]
        public int VarietyId { get; set; }
        [ValidateNever]
        public int Stock { get; set; }

        [ValidateNever]
        public Variety Variety { get; set; }
        [ValidateNever]
        public Winery Winery { get; set; }
    }
}

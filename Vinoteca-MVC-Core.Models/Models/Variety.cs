using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

namespace Vinoteca_MVC_Core.Models.Models
{	
	[Index(nameof(VarietyName), IsUnique = true)]	
	public class Variety
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[StringLength(100, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 3)]
		[DisplayName("Variety Name")]
		public string VarietyName { get; set; }
		[Required]
		[Range(1, 100, ErrorMessage = "The field {0} must be between {1} and {2}")]
		[DisplayName("Display Order")]
		public int DisplayOrder { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vinoteca_MVC_Core.Models.Models
{
	public class Winery
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[StringLength(100, ErrorMessage="The field {0} must be between {2} and {1} characters",MinimumLength=3)]
		[DisplayName("Winery Name")]
		public string WineryName { get; set; }

		public string Address { get; set; }
	}
}

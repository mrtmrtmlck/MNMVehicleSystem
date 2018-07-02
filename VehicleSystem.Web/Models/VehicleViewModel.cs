using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace VehicleSystem.Web.Models
{
    public class VehicleViewModel
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^(0[1-9]|[1-7][0-9]|8[01])(([A-Z])(\d{4,5})|([A-Z]{2})(\d{3,4})|([A-Z]{3})(\d{2}))$",
            ErrorMessage = "Invalid Plate Format")]
        public string Plate { get; set; }

        [Display(Name = "Nick Name")] public string NickName { get; set; }
        [Required] public string Brand { get; set; }
        [Required] public string Model { get; set; }

        [Required]
        [Range(1800, 2099, ErrorMessage = "Invalid Year")]
        public int Year { get; set; }

        [Required] public string Type { get; set; }
        [Required] public string Color { get; set; }

        [Required]
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}
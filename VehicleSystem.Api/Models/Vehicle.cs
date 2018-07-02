using System.ComponentModel.DataAnnotations;

namespace VehicleSystem.Api.Models
{
    public class Vehicle
    {
        [Required] public int Id { get; set; }
        [Required] public string Plate { get; set; }
        public string NickName { get; set; }
        [Required] public string Brand { get; set; }
        [Required] public string Model { get; set; }
        [Required] public int Year { get; set; }
        [Required] public string Type { get; set; }
        [Required] public string Color { get; set; }
        public bool IsActive { get; set; }
    }
}
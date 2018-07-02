using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehicleSystem.Api.Models;
using VehicleSystem.Api.Services;

namespace VehicleSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        // GET api/vehicle
        [HttpGet]
        public async Task<IEnumerable<Vehicle>> Get()
        {
            return await _vehicleService.GetVehicleList();
        }

        // GET api/vehicle/5
        [HttpGet("{id}")]
        public async Task<Vehicle> Get(int id)
        {
            return await _vehicleService.GetVehicle(id);
        }

        // POST api/vehicle
        [HttpPost]
        public async Task Post([FromBody] Vehicle vehicle)
        {
            await _vehicleService.AddVehicle(vehicle);
        }

        // PUT api/vehicle/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Vehicle vehicle)
        {
            await _vehicleService.UpdateVehicle(id, vehicle);
        }

        // DELETE api/vehicle/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _vehicleService.DeleteVehicle(id);
        }
    }
}
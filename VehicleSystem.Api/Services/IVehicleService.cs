using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleSystem.Api.Models;

namespace VehicleSystem.Api.Services
{
    public interface IVehicleService
    {
        Task<List<Vehicle>> GetVehicleList();
        Task<Vehicle> GetVehicle(int vehicleId);
        Task AddVehicle(Vehicle vehicle);
        Task UpdateVehicle(int vehicleId, Vehicle vehicle);
        Task DeleteVehicle(int vehicleId);
    }
}
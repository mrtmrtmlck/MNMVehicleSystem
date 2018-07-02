using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleSystem.Api.Database;
using VehicleSystem.Api.Models;

namespace VehicleSystem.Api.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly VehicleDbContext _vehicleDbContext;

        public VehicleService(VehicleDbContext vehicleDbContext)
        {
            _vehicleDbContext = vehicleDbContext;
        }

        public async Task<List<Vehicle>> GetVehicleList()
        {
            var vehicleList = await _vehicleDbContext.Vehicles.Select(p => p).ToListAsync();
            return vehicleList;
        }

        public async Task<Vehicle> GetVehicle(int vehicleId)
        {
            var vehicle = await _vehicleDbContext.Vehicles.FirstOrDefaultAsync(p => p.Id == vehicleId);
            return vehicle;
        }

        public async Task AddVehicle(Vehicle vehicle)
        {
            if (vehicle != null)
            {
                await _vehicleDbContext.Vehicles.AddAsync(vehicle);
                await _vehicleDbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateVehicle(int vehicleId, Vehicle vehicle)
        {
            var foundedVehicle = await GetVehicle(vehicleId);
            if (foundedVehicle != null)
            {
                foundedVehicle.Brand = vehicle.Brand;
                foundedVehicle.Model = vehicle.Model;
                foundedVehicle.Year = vehicle.Year;
                foundedVehicle.Type = vehicle.Type;
                foundedVehicle.NickName = vehicle.NickName;
                foundedVehicle.Color = vehicle.Color;
                foundedVehicle.IsActive = vehicle.IsActive;
                foundedVehicle.Plate = vehicle.Plate;

                await _vehicleDbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteVehicle(int vehicleId)
        {
            var foundedVehicle = await GetVehicle(vehicleId);
            if (foundedVehicle != null)
            {
                _vehicleDbContext.Remove(foundedVehicle);
                await _vehicleDbContext.SaveChangesAsync();
            }
        }
    }
}
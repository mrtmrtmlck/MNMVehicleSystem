using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VehicleSystem.Web.Models;

namespace VehicleSystem.Web.Controllers
{
    public class VehicleController : Controller
    {
        private readonly string apiUrl = "http://localhost:5000/api/vehicle";

        public async Task<ActionResult> VehicleList()
        {
            List<VehicleViewModel> vehicleList = new List<VehicleViewModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(apiUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    vehicleList = JsonConvert.DeserializeObject<List<VehicleViewModel>>(result);
                }
            }

            return View(vehicleList);
        }

        public async Task<ActionResult> Addvehicle(VehicleViewModel vehicleViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new StringContent(JsonConvert.SerializeObject(vehicleViewModel), Encoding.UTF8,
                    "application/json");
                var response = await client.PostAsync(apiUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("VehicleList");
                }
            }

            return View();
        }

        public async Task<ActionResult> UpdateVehicle(int id)
        {
            VehicleViewModel vehicle = new VehicleViewModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(apiUrl + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    vehicle = JsonConvert.DeserializeObject<VehicleViewModel>(result);
                }
            }

            return View(vehicle);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateVehicle(int id, VehicleViewModel vehicleViewModel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new StringContent(JsonConvert.SerializeObject(vehicleViewModel), Encoding.UTF8,
                    "application/json");
                var response = await client.PutAsync(apiUrl + "/" + id, content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("VehicleList");
                }
            }

            return View();
        }

        public async Task<ActionResult> DeleteVehicle(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                await client.DeleteAsync(apiUrl + "/" + id);
                return RedirectToAction("VehicleList");
            }
        }
    }
}
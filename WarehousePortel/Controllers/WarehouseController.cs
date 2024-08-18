using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehousePortel.Models;

namespace WarehousePortel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : Controller
    {
        public readonly TrainingDBContext trainingDBContext;
        public WarehouseController(TrainingDBContext _trainingDBContext)
        {
            trainingDBContext = _trainingDBContext;
        }
        [HttpGet("GetWarehouseDetails")]
        public List<Warehouse> GetWarehouseDetails()
        {
            List<Warehouse> lstWarehouse = new List<Warehouse>();
            try
            {
                lstWarehouse = trainingDBContext.Warehouse.ToList();
                return lstWarehouse;
            }
            catch (Exception ex)
            {
                lstWarehouse = new List<Warehouse>();
                return lstWarehouse;
            }
        }
        [HttpPost("AddWarehouse")]
        public string AddWarehouse(Warehouse warehouse)
        {
            string message = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(warehouse.WarehouseName))
                {
                    trainingDBContext.Add(warehouse);
                    trainingDBContext.SaveChanges();
                    message = "Warehouse added successfully";
                }
                else
                    message = "Warehouse Name required.";

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
    }
}

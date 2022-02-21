using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse_V3_Entity;
using Warehouse_V3_Service;

namespace Warehose_V3_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        [HttpGet]
        [Route("get-all-warehouse")]
        public ActionResult<List<WarehouseDTO>> GetWarehouseList()
        {
            WarehouseService warehouseService = new WarehouseService();
            var resp = warehouseService.getAllWarehouse();
            return resp;
        }

        [HttpGet]
        [Route("get-all-car")]
        public ActionResult<List<CarDTO>> GetCarList()
        {
            WarehouseService warehouseService = new WarehouseService();
            var resp = warehouseService.getAllCar();
            return resp;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Warehouse_V3_Entity;
using Warehouse_V3_Orm.Models;
using Warehouse_V3_Orm.Repositories;

namespace Warehouse_V3_Service
{
    public class WarehouseService
    {
        public List<WarehouseDTO> getAllWarehouse()
        {
            WarehouseRepository warehouseRepository = new WarehouseRepository();
            List<WarehouseDTO> resp = warehouseRepository.getAllWarehouse();
            return resp;
        }

        public List<CarDTO> getAllCar()
        {
            WarehouseRepository warehouseRepository = new WarehouseRepository();
            List<CarDTO> resp = warehouseRepository.getAllCar().OrderBy(x => x.DateAdded).ToList();
            return resp;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Warehouse_V3_Orm.Models;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using Warehouse_V3_Entity;
using System.Linq;

namespace Warehouse_V3_Orm.Repositories
{
    public class WarehouseRepository
    {
        public List<Warehouse> warehouseList = JArray.Parse(File.ReadAllText("warehouses.json")).ToObject<List<Warehouse>>();
        private static Dictionary<int, CarDTO> carDictonary;
        public static Dictionary<int, CarDTO> getCarDictionary()
        {
            if (carDictonary == null) {
                carDictonary = new Dictionary<int, CarDTO>();
            }

            if(carDictonary.Count == 0) {
                WarehouseRepository warehouseRepository = new WarehouseRepository();
                List<CarDTO> carList = warehouseRepository.getAllCar();
                foreach(CarDTO carDTO in carList) {
                    if(!carDictonary.Keys.Contains(carDTO.CarID))
                    carDictonary.Add(carDTO.CarID, carDTO);
                }
            }

            return carDictonary;
        }
        public List<WarehouseDTO> getAllWarehouse()
        {
            List<WarehouseDTO> resp = new List<WarehouseDTO>();
            resp.AddRange(warehouseList.ConvertAll(warehouse => new WarehouseDTO
            {
                ID = warehouse.ID,
                Name = warehouse.Name,
                Location = warehouse.Cars.Location,
                CarCount = warehouse.Cars.Vehicles.Count
            }));
            return resp;
        }

        public List<CarDTO> getAllCar()
        {
            List<CarDTO> resp = new List<CarDTO>();
            foreach(Warehouse warehouse in warehouseList)
            {
                resp.AddRange(warehouse.Cars.Vehicles.ConvertAll(x => new CarDTO {
                    CarID = x.CarID,
                    WarehouseID = warehouse.ID,
                    WarehouseName = warehouse.Name,
                    WarehouseLocation = new Warehouse_V3_Entity.Location { Lat = warehouse.Location.Lat, Long = warehouse.Location.Long },
                    Location = warehouse.Cars.Location,
                    Make = x.Make,
                    Model = x.Model,
                    YearModel = x.YearModel,
                    Price = x.Price,
                    DateAdded = x.DateAdded,
                    Licensed = x.Licensed                    
                }));
            }
            return resp;
        }
    }
}

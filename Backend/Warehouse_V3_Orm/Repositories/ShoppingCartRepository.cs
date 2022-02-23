using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Warehouse_V3_Entity;
using Warehouse_V3_Entity.ShoppingCart;
using Warehouse_V3_Orm.Models;
using Warehouse_V3_Orm.Models.SqliteModels;

namespace Warehouse_V3_Orm.Repositories
{
    public class ShoppingCartRepository
    {
        public List<ShoppingCartDTO> getAllShoppingCart()
        {
            List<ShoppingCart> shoppingCarts = new List<ShoppingCart>();
            List<ShoppingCartDTO> resp = new List<ShoppingCartDTO>();
            using (var db = new ShoppingCartDBContext())
            {
                db.Database.EnsureCreated();
                shoppingCarts = db.ShoppingCart.ToList();
            }
            foreach(ShoppingCart item in shoppingCarts)
            {
                CarDTO carDTO = WarehouseRepository.getCarDictionary()[item.CarID];
                ShoppingCartDTO shoppingCartDTO = new ShoppingCartDTO()
                {
                    ID = item.ID,
                    CarID = item.CarID,
                    UserID = item.UserID,
                    Make = carDTO.Make,
                    Model = carDTO.Model,
                    WarehouseLocation = carDTO.WarehouseLocation,
                    Location = carDTO.Location,
                    YearModel = carDTO.YearModel,
                    DateAdded = carDTO.DateAdded,
                    Licensed = carDTO.Licensed,
                    Price = carDTO.Price

                };
                resp.Add(shoppingCartDTO);
            }
            return resp;
        }
        public void addShoppingCart(ShoppingCart newCart)
        {
            using (var db = new ShoppingCartDBContext())
            {
                var a = db.ShoppingCart.Add(newCart);
                db.SaveChanges();
            }
        }

        public void deleteShoppingCart(string id)
        {
            using (var db = new ShoppingCartDBContext())
            {
                ShoppingCart deletedItem = db.ShoppingCart.FirstOrDefault(x => x.ID == id);
                db.ShoppingCart.Remove(deletedItem);
                db.SaveChanges();
            }
        }

        public void completeShoppingCart(int userID)
        {
            using (var db = new ShoppingCartDBContext())
            {
                List<ShoppingCart> deletedItems = db.ShoppingCart.Where(items => items.UserID == userID).ToList();
                db.ShoppingCart.RemoveRange(deletedItems);
                db.SaveChanges();
            }
        }
    }
}

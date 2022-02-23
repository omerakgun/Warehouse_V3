using System;
using System.Collections.Generic;
using System.Text;
using Warehouse_V3_Entity.ShoppingCart;
using Warehouse_V3_Orm.Models.SqliteModels;
using Warehouse_V3_Orm.Repositories;

namespace Warehouse_V3_Service
{
    public class ShoppingCartService
    {
        public List<ShoppingCartDTO> getAllShoppingCart()
        {
            ShoppingCartRepository shoppingCartRepository = new ShoppingCartRepository();
            List<ShoppingCartDTO> resp = new List<ShoppingCartDTO>();
            resp = shoppingCartRepository.getAllShoppingCart();
            return resp;
        }

        public void addShoppingCart(ShoppingCart newItem)
        {
            newItem.ID = Guid.NewGuid().ToString();
            ShoppingCartRepository shoppingCartRepository = new ShoppingCartRepository();
            shoppingCartRepository.addShoppingCart(newItem);
        }

        public void deleteShoppingCart(string id)
        {
            ShoppingCartRepository shoppingCartRepository = new ShoppingCartRepository();
            shoppingCartRepository.deleteShoppingCart(id);
        }

        public void completeShoppingCart(int userID)
        {
            ShoppingCartRepository shoppingCartRepository = new ShoppingCartRepository();
            shoppingCartRepository.completeShoppingCart(userID);
        }
    }
}

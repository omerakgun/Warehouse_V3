using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse_V3_Entity.ShoppingCart;
using Warehouse_V3_Orm.Models.SqliteModels;
using Warehouse_V3_Service;

namespace Warehose_V3_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        [HttpGet]
        [Route("get-all-shopping-cart")]
        public ActionResult<List<ShoppingCartDTO>> GetWarehouseList()
        {
            ShoppingCartService shoppingCartService = new ShoppingCartService();
            var resp = shoppingCartService.getAllShoppingCart();
            return resp;
        }

        [HttpPost]
        [Route("add-car-to-shopping-cart")]
        public ActionResult AddCarToShoppingCart([FromBody] ShoppingCart value)
        {
            ShoppingCartService shoppingCartService = new ShoppingCartService();
            shoppingCartService.addShoppingCart(value);
            return Ok();
        }

        [HttpPost]
        [Route("delete-car-from-shopping-cart")]
        public ActionResult DeleteCarFromShoppingCart([FromBody] string id)
        {
            ShoppingCartService shoppingCartService = new ShoppingCartService();
            shoppingCartService.deleteShoppingCart(id);
            return Ok();
        }

        [HttpPost]
        [Route("complete-shopping-cart")]
        public ActionResult CompleteShoppingCart([FromBody] int userID)
        {
            ShoppingCartService shoppingCartService = new ShoppingCartService();
            shoppingCartService.completeShoppingCart(userID);
            return Ok();
        }
    }
}

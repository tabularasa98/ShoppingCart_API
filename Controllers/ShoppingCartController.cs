using Microsoft.AspNetCore.Mvc;
using DynamicButtons.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shoppingCart.Controllers
{
    [ApiController]
    [Route("cart")]
    public class ShoppingCartController : ControllerBase
    {
        [HttpGet("GetInv")]
        public ActionResult<List<InventoryItem>> GetInv()
        {
            return Ok(DataContext.Inventory);
        }

        [HttpGet("GetCart")]
        public ActionResult<List<Product>> GetCart()
        {
            return Ok(DataContext.Cart);
        }

        [HttpGet("test")]
        public string Test()
        {
            return "Hello, World!";

        }
        [HttpPost("add")]
        public ActionResult<InventoryItem> AddProduct([FromBody]InventoryItem SelectedProduct)
        {
            if (SelectedProduct == null)
            {
                return BadRequest();
            }
            
            if (DataContext.Cart.Any(i => i.Id.Equals(SelectedProduct.Id)))
            {
                if (DataContext.Cart.FirstOrDefault(i => i.Id.Equals(SelectedProduct.Id)).Display.Contains("Unit"))
                {
                    DataContext.Cart.FirstOrDefault(i => i.Id.Equals(SelectedProduct.Id)).Units++;
                }
                else
                {
                    DataContext.Cart.FirstOrDefault(i => i.Id.Equals(SelectedProduct.Id)).Ounces += 0.5;
                }
            }
            else
            {
                if (SelectedProduct.Id == Guid.Empty)
                {
                    SelectedProduct.Id = Guid.NewGuid();
                }
                if (SelectedProduct.Display.Contains("Unit"))
                {
                    DataContext.Cart.Add(new UnitProduct { Name = SelectedProduct.Name, Description = SelectedProduct.Description, UnitPrice = SelectedProduct.Price, Units = 1, Id = SelectedProduct.Id });
                }
                else
                {
                    DataContext.Cart.Add(new OunceProduct { Name = SelectedProduct.Name, Description = SelectedProduct.Description, OuncePrice = SelectedProduct.Price, Ounces = 1, Id = SelectedProduct.Id });
                }

            }

            return Ok(SelectedProduct);
        }
        [HttpPost("delete")]
        public ActionResult<Product> DeleteProduct([FromBody] Product SelectedInCart)
        {
            if (SelectedInCart == null)
            {
                return BadRequest();
            }
            if (DataContext.Cart.Any(i => i.Id.Equals(SelectedInCart.Id)))
            {
                if (DataContext.Cart.FirstOrDefault(i => i.Id.Equals(SelectedInCart.Id)).Display.Contains("Unit"))
                {
                    if (DataContext.Cart.FirstOrDefault(i => i.Id.Equals(SelectedInCart.Id)).Units > 1)
                    {
                        DataContext.Cart.FirstOrDefault(i => i.Id.Equals(SelectedInCart.Id)).Units--;
                    }
                    else
                    {
                        DataContext.Cart.Remove(DataContext.Cart.FirstOrDefault(i => i.Id.Equals(SelectedInCart.Id)));
                    }
                }
                else
                {
                    if (DataContext.Cart.FirstOrDefault(i => i.Id.Equals(SelectedInCart.Id)).Ounces > 0.5)
                    {
                        DataContext.Cart.FirstOrDefault(i => i.Id.Equals(SelectedInCart.Id)).Ounces -= 0.5;
                    }
                    else
                    {
                        DataContext.Cart.Remove(DataContext.Cart.FirstOrDefault(i => i.Id.Equals(SelectedInCart.Id)));
                    }
                }
            }

            return Ok(SelectedInCart);
        }
        [HttpGet("clear")]
        public ActionResult<List<Product>> ClearCart()
        {
            DataContext.Cart.Clear();
            return Ok(DataContext.Cart);
        }

        [HttpGet("checkout")]
        public ActionResult<string> Checkout()
        {
            string Subtotal = $"Subtotal {DataContext.Cart.Sum(i => i.Price):C}\n";
            string Tax = $"Tax {DataContext.Cart.Sum(i => i.Price) * 0.07:C}\n";
            string Total = $"Total {(DataContext.Cart.Sum(i => i.Price) * 0.07) + DataContext.Cart.Sum(i => i.Price):C}\n";
            string output = "";
            foreach (var item in DataContext.Cart)
            {
                output += item.Display;
                output += '\n';
            }
            output += Subtotal;
            output += Tax;
            output += Total;
            return Ok(output);
        }
    }
}

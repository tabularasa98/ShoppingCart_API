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
    [Route("inv")]
    public class InventoryController : ControllerBase
    {
        [HttpPost("search")]
        public ActionResult<List<InventoryItem>> Search([FromBody]  string item)
        {
            Console.WriteLine(item);
            if(item == null)
            {
                return BadRequest();
            }
            foreach (var i in DataContext.Inventory)
            {
                if (i.Name.Contains(item))
                {
                    DataContext.Results.Add(i);
                }
            }
            foreach (var i in DataContext.Inventory)
            {
                if (i.Description.Contains(item) && !DataContext.Results.Contains(i))
                {
                    DataContext.Results.Add(i);

                }
            }
            return Ok(DataContext.Results);
        }
        [HttpGet("searchResults")]
        public ActionResult<List<InventoryItem>> Results_dis()
        {
            return Ok(DataContext.Results);
        }
        [HttpGet("clear")]
        public ActionResult<List<InventoryItem>> ClearResults()
        {
            DataContext.Results.Clear();
            return Ok(DataContext.Results);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        static List<string> products_data = new List<string>();
        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return products_data;
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return products_data[id];
        }

        // POST api/products
        [HttpPost]
        public void Post([FromBody] string value)
        {
            products_data.Add(value);
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
             products_data.Insert(id, value);
             products_data.RemoveAt(id);

        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            products_data.RemoveAt(id);
        }
    }
}
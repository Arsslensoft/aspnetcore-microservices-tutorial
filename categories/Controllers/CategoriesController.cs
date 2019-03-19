using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace categories.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        static List<string> categories_data = new List<string>();
        // GET api/categories
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return categories_data;
        }

        // GET api/categories/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return categories_data[id];
        }

        // POST api/categories
        [HttpPost]
        public void Post([FromBody] string value)
        {
            categories_data.Add(value);
        }

        // PUT api/categories/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {       
             categories_data.RemoveAt(id);
             categories_data.Insert(id, value);
      

        }

        // DELETE api/categories/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            categories_data.RemoveAt(id);
        }
    }
}
using RestaurantAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestaurantAppWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        List<Menu> items = new List<Menu>()
        {
            new Menu{ Id = 1, Name = "Butter Chicken", Price =  15.5 },
             new Menu{ Id = 2, Name = "Rice", Price = 10.0  },
              new Menu{ Id = 3, Name = "Naan/Roti", Price = 3.5 },
               new Menu{ Id = 4, Name = "Paneer Tikka Masala", Price = 15.5  }
        };
        public List<Menu> Get()
        {
            return items;
        }

        // GET api/values/5
        public Menu Get(int id)
        {
            return items.Where(m => m.Id == id).FirstOrDefault();
        }
        // POST api/values
        public void Post([FromBody]Menu menu)
        {
            items.Add(menu);
        }
        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

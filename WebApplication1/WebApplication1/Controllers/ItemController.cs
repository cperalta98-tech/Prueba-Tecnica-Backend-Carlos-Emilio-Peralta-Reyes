using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "http://localhost:5173", headers: "*", methods: "*")]
    public class ItemController : ApiController
    {
        BDRuletaEntities _bDRuletaEntities = new BDRuletaEntities();
        // GET: api/User
        public IEnumerable<tblItem> Get()
        {
            var listadoItems = _bDRuletaEntities.tblItem.ToList();
            return listadoItems;
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public User Post([FromBody] User user)
        {
            return user;
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}

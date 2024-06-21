using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Web.Http.Cors;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "http://localhost:5173", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        BDRuletaEntities _bDRuletaEntities = new BDRuletaEntities();
        // GET: api/User
        public IEnumerable<tblUsuario> Get()
        {
           var listadoItems =  _bDRuletaEntities.tblUsuario.ToList();
            return listadoItems;
        }

        // GET: api/User/5
        public IEnumerable<tblUsuario> GetById(string id)
        {
            var listadoItems = _bDRuletaEntities.tblUsuario.Where(x=>x.IdUsuario == id).ToList();
            return listadoItems;
        }

        // POST: api/User
        public tblUsuario Post([FromBody] tblUsuario user)
        {
            try
            {
                tblUsuario objCreate = new tblUsuario();
                bool existe = _bDRuletaEntities.tblUsuario.Any(x => x.IdUsuario == user.IdUsuario);
                if (!existe)
                {
                    
                    objCreate.IdUsuario = user.IdUsuario;
                    objCreate.Pass = user.Pass;
                    objCreate.Activo = true;
                    objCreate.Monto = user.Monto;
                    _bDRuletaEntities.tblUsuario.Add(objCreate);
                    _bDRuletaEntities.SaveChanges();                   
                }
                return objCreate;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        // PUT: api/User/5
        public tblUsuario Put([FromBody] tblUsuario _user)
        {
            tblUsuario objEditar = _bDRuletaEntities.tblUsuario.Where(x => x.IdUsuario == _user.IdUsuario).FirstOrDefault();
            if (objEditar != null)
            {
                objEditar.Monto = _user.Monto;
                _bDRuletaEntities.SaveChanges();

            }
            return objEditar;
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}

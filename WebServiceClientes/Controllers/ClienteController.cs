using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServiceClientes.Models;

namespace WebServiceClientes.Controllers
{
    public class ClienteController : ApiController
    {
        CAR_CENTEREntitie Bd = new CAR_CENTEREntitie();

        // GET api/Cliente
        public IHttpActionResult GetClientes()
        {
            try
            {
                Bd.Configuration.ProxyCreationEnabled = false;
                var clientes = Bd.Cliente.ToList();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        //GET api/Cliente/{id}
        public IHttpActionResult GetCliente(int id)
        {
            try
            {
                Bd.Configuration.ProxyCreationEnabled = false;
                Cliente cliente = Bd.Cliente.Find(id);
                if (cliente == null)
                {
                    return BadRequest("Record not found");
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // POST api/Cliente
        public IHttpActionResult Addcliente(Cliente model)
        {
            //ModelState ayuda a comprobar el estado del modelo si coincide con los datanotation de nuestra partialclass
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Bd.Cliente.Add(model);
                Bd.SaveChanges();
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        // PUT api/Client/{id}
        public IHttpActionResult Put(int id, Cliente model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Cliente cliente = Bd.Cliente.Find(id);
                if (cliente == null)
                {
                    return BadRequest("Record not found");
                }
                Bd.Entry(cliente).State = EntityState.Detached;
                Bd.Entry(model).State = EntityState.Modified;
                Bd.SaveChanges();
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // DELETE api/Cliente/{id}
        public IHttpActionResult Deletecliente(int id)
        {
            try
            {
                Cliente cliente = Bd.Cliente.Find(id);
                if (cliente == null)
                {
                    return BadRequest("Record not found");
                }
                Bd.Cliente.Remove(cliente);
                Bd.SaveChanges();
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

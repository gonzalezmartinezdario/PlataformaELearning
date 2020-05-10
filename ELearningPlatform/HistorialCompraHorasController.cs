using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ELearningPlatform
{
    public class HistorialCompraHorasController : ApiController
    {
        ELearningEntities context;

        //Constructor
        HistorialCompraHorasController()
        {
            context = new ELearningEntities();
            context.Configuration
                    .ProxyCreationEnabled = false;
        }

        // GET api/<controller>
        public IEnumerable<HistorialCompraHoras> Get()
        {
            return context.HistorialCompraHoras
                   .AsNoTracking().ToList();
        }

        // GET api/<controller>/5
        public HistorialCompraHoras Get(int id)
        {
            return context.HistorialCompraHoras
                   .AsNoTracking().FirstOrDefault(Compra => Compra.idCompra == id);
        }

        // POST api/<controller>
        public void Post([FromBody]HistorialCompraHoras value)
        {
            context.HistorialCompraHoras.Add(value);
            context.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]HistorialCompraHoras value)
        {
            HistorialCompraHoras formerCompra = context.HistorialCompraHoras
                                                .FirstOrDefault(Compra => Compra.idCompra
                                                                       == value.idCompra);
            //Si no se encuentra el elemento
            if (formerCompra == null) return;

            //Igualar los objetos
            formerCompra.FechaCommpra = value.FechaCommpra;
            formerCompra.idAlumno = value.idAlumno;
            formerCompra.Importe = value.Importe;
            formerCompra.NumeroHoras = value.NumeroHoras;
            formerCompra.ZonaHoraria = value.ZonaHoraria;

            context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            HistorialCompraHoras borrarCompra = context.HistorialCompraHoras
                                               .FirstOrDefault(Compra =>
                                                               Compra.idCompra == id);

            if (borrarCompra == null) return;

            context.HistorialCompraHoras.Remove(borrarCompra);
            context.SaveChanges();
        }

        //Destructor
        ~HistorialCompraHorasController()  // finalizer
        {
            context = null;
        }
    }
}
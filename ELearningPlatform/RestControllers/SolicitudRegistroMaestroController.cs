using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ELearningPlatform.RestControllers
{
    public class SolicitudRegistroMaestroController : ApiController
    {
        ELearningEntities context;

        //Constructor
        SolicitudRegistroMaestroController()
        {
            context = new ELearningEntities();
            context.Configuration
                    .ProxyCreationEnabled = false;
        }

        // GET api/<controller>
        public IEnumerable<SolicitudRegistroMaestro> Get()
        {
            return context.SolicitudRegistroMaestro
                   .AsNoTracking().ToList();
        }

        // GET api/<controller>/5
        public SolicitudRegistroMaestro Get(int id)
        {
            return context.SolicitudRegistroMaestro
                   .AsNoTracking().FirstOrDefault( SRM => SRM.idSolicitud == id);
        }

        // POST api/<controller>
        public void Post([FromBody]SolicitudRegistroMaestro value)
        {
            context.SolicitudRegistroMaestro.Add(value);
            context.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]SolicitudRegistroMaestro value)
        {
            SolicitudRegistroMaestro formerSRM = context.SolicitudRegistroMaestro
                                                 .FirstOrDefault(SRM => SRM.idSolicitud
                                                                     == value.idSolicitud);
            //Si no se encuentra el elemento
            if (formerSRM == null) return;
            
            //Igualar los objetos
            formerSRM.Apellido = value.Apellido;
            formerSRM.CV = value.CV;
            formerSRM.Email = value.Email;
            formerSRM.EsNueva = value.EsNueva;
            formerSRM.FechaSolicitud = value.FechaSolicitud;
            formerSRM.Nombre = value.Nombre;
            formerSRM.TelCodigoPais = value.TelCodigoPais;
            formerSRM.Telefono = value.Telefono;

            context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            SolicitudRegistroMaestro borrarSRM = context.SolicitudRegistroMaestro
                                                 .FirstOrDefault(SRM => 
                                                                 SRM.idSolicitud == id);

            if (borrarSRM == null) return;

            context.SolicitudRegistroMaestro.Remove(borrarSRM);
            context.SaveChanges();
        }

        //Destructor
        ~SolicitudRegistroMaestroController()  // finalizer
        {
            context = null;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ELearningPlatform.RestControllers
{
    public class AgendaMaestroController : ApiController
    {
        ELearningEntities context;

        //Constructor
        AgendaMaestroController()
        {
            context = new ELearningEntities();
            context.Configuration
                    .ProxyCreationEnabled = false;
        }

        // GET api/<controller>
        public IEnumerable<AgendaMaestro> Get()
        {
            return context.AgendaMaestro
                   .AsNoTracking().ToList();
        }

        // GET api/<controller>/5
        public AgendaMaestro Get(int id)
        {
            return context.AgendaMaestro
                   .AsNoTracking().FirstOrDefault(Clase => Clase.idClase == id);
        }

        // POST api/<controller>
        public void Post([FromBody]AgendaMaestro value)
        {
            context.AgendaMaestro.Add(value);
            context.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]AgendaMaestro value)
        {
            AgendaMaestro formerClase = context.AgendaMaestro
                                                 .FirstOrDefault(Clase => Clase.idClase
                                                                       == value.idClase);
            //Si no se encuentra el elemento
            if (formerClase == null) return;

            //Igualar los objetos
            formerClase.FechaCita = value.FechaCita;
            formerClase.idAlumno = value.idAlumno;
            formerClase.idMaestro = value.idMaestro;
            formerClase.StatusCita = value.StatusCita;
            formerClase.ZonaHoraria = value.ZonaHoraria;            

            context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            AgendaMaestro borrarClase = context.AgendaMaestro
                                               .FirstOrDefault(CLase =>
                                                               CLase.idClase == id);

            if (borrarClase == null) return;

            context.AgendaMaestro.Remove(borrarClase);
            context.SaveChanges();
        }

        //Destructor
        ~AgendaMaestroController()  // finalizer
        {
            context = null;
        }
    }
}
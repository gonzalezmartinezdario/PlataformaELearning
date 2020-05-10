using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ELearningPlatform.RestControllers
{
    public class MaestroController : ApiController
    {
        ELearningEntities context;

        //Constructor
        MaestroController()
        {
            context = new ELearningEntities();
            context.Configuration
                   .ProxyCreationEnabled = false;
        }

        // GET api/<controller>
        public IEnumerable<Maestro> Get()
        {
            return context.Maestro
                   .AsNoTracking().ToList();
        }

        // GET api/<controller>/5
        public Maestro Get(int id)
        {
            return context.Maestro
                   .AsNoTracking().FirstOrDefault(maestro => maestro.id == id);
        }

        // POST api/<controller>
        public void Post([FromBody]Maestro value)
        {
            context.Maestro.Add(value);
            context.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Maestro value)
        {
            Maestro formerMaestro = context.Maestro
                                           .FirstOrDefault(maestro => maestro.id
                                                                   == value.id);
            //Si no se encuentra el elemento
            if (formerMaestro == null) return;

            //Igualar los objetos
            formerMaestro.Apellidos = value.Apellidos;
            formerMaestro.Ciudad = value.Ciudad;
            formerMaestro.idMaestro = value.idMaestro;
            formerMaestro.Nombre = value.Nombre;
            formerMaestro.Pais = value.Pais;
            formerMaestro.ZonaHoraria = value.ZonaHoraria;

            context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            Maestro borrarMaestro = context.Maestro
                                                  .FirstOrDefault(maestro =>
                                                                  maestro.id
                                                                  == id);

            if (borrarMaestro == null) return;

            context.Maestro.Remove(borrarMaestro);
            context.SaveChanges();
        }

        //Destructor
        ~MaestroController()  // finalizer
        {
            context = null;
        }
    }
}
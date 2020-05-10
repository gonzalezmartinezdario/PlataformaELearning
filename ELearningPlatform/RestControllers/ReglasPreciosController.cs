using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ELearningPlatform.RestControllers
{
    public class ReglasPreciosController : ApiController
    {
        ELearningEntities context;

        //Constructor
        ReglasPreciosController()
        {
            context = new ELearningEntities();
            context.Configuration
                    .ProxyCreationEnabled = false;
        }

        // GET api/<controller>
        public IEnumerable<ReglasPrecios> Get()
        {
            return context.ReglasPrecios
                   .AsNoTracking().ToList();
        }

        // GET api/<controller>/5
        public ReglasPrecios Get(int id)
        {
            return context.ReglasPrecios
                   .AsNoTracking().FirstOrDefault(Regla => Regla.idRegla == id);
        }

        // POST api/<controller>
        public void Post([FromBody]ReglasPrecios value)
        {
            context.ReglasPrecios.Add(value);
            context.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]ReglasPrecios value)
        {
            ReglasPrecios formerRegla = context.ReglasPrecios
                                                .FirstOrDefault(Regla => Regla.idRegla
                                                                      == value.idRegla);
            //Si no se encuentra el elemento
            if (formerRegla == null) return;

            //Igualar los objetos
            formerRegla.CantidadFinalHoras = value.CantidadFinalHoras;
            formerRegla.CantidadInicialHoras = value.CantidadInicialHoras;
            formerRegla.FechaFinal = value.FechaFinal;
            formerRegla.FechaInicio = value.FechaInicio;
            formerRegla.Nombre = value.Nombre;

            context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            ReglasPrecios borrarRegla = context.ReglasPrecios
                                               .FirstOrDefault(Regla =>
                                                               Regla.idRegla
                                                               == id);

            if (borrarRegla == null) return;

            context.ReglasPrecios.Remove(borrarRegla);
            context.SaveChanges();
        }

        //Destructor
        ~ReglasPreciosController()  // finalizer
        {
            context = null;
        }
    }
}
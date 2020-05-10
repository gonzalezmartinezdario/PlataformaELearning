using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ELearningPlatform.RestControllers
{
    public class ReporteHorasController : ApiController
    {
        ELearningEntities context;

        //Constructor
        ReporteHorasController()
        {
            context = new ELearningEntities();
            context.Configuration
                    .ProxyCreationEnabled = false;
        }

        // GET api/<controller>
        public IEnumerable<HistorialReporteHoras> Get()
        {
            return context.HistorialReporteHoras
                   .AsNoTracking().ToList();
        }

        // GET api/<controller>/5
        public HistorialReporteHoras Get(int id)
        {
            return context.HistorialReporteHoras
                   .AsNoTracking().FirstOrDefault(Reporte => Reporte.idRegistro == id);
        }

        // POST api/<controller>
        public void Post([FromBody]HistorialReporteHoras value)
        {
            context.HistorialReporteHoras.Add(value);
            context.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]HistorialReporteHoras value)
        {
            HistorialReporteHoras formerReporte = context.HistorialReporteHoras
                                                  .FirstOrDefault(Reporte => Reporte.idRegistro
                                                                          == value.idRegistro);
            //Si no se encuentra el elemento
            if (formerReporte == null) return;

            //Igualar los objetos
            formerReporte.CantidadHoras = value.CantidadHoras;
            formerReporte.FechaClase = value.FechaClase;
            formerReporte.FechaReporte = value.FechaReporte;
            formerReporte.idAlumno = value.idAlumno;
            formerReporte.idMaestro = value.idMaestro;
            formerReporte.ZonaHoraria = value.ZonaHoraria;        

            context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            HistorialReporteHoras borrarReporte = context.HistorialReporteHoras
                                                  .FirstOrDefault(Reporte =>
                                                                  Reporte.idRegistro
                                                                  == id);

            if (borrarReporte == null) return;

            context.HistorialReporteHoras.Remove(borrarReporte);
            context.SaveChanges();
        }

        //Destructor
        ~ReporteHorasController()  // finalizer
        {
            context = null;
        }
    }
}
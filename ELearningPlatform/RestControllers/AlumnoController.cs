using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ELearningPlatform.Models;
namespace ELearningPlatform.RestControllers
{
    public class AlumnoController : ApiController
    {
        ELearningEntities context;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        AlumnoController()
        {
            context = new ELearningEntities();
            context.Configuration.ProxyCreationEnabled = false;
        }            

        // GET api/<controller>
        public IEnumerable<Alumno> Get()
        {
            //ELearningEntities context = new ELearningEntities();
            //context.Configuration.ProxyCreationEnabled = false;

            return context.Alumno.AsNoTracking().ToList();
        }

        // GET api/<controller>/5
        public Alumno Get(int id)
        {
            //ELearningEntities context = new ELearningEntities();
            //context.Configuration.ProxyCreationEnabled = false;

            return context.Alumno.AsNoTracking().FirstOrDefault(alumno => alumno.id == id);
        }

        // POST api/<controller>
        public void Post([FromBody]Alumno value)
        {
            context.Alumno.Add(value);
            context.SaveChanges();                        
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Alumno value)
        {
            //ELearningEntities context = new ELearningEntities();

            Alumno formerAlumno = context.Alumno
                                        .FirstOrDefault(alumno => alumno.id == id);

            if (formerAlumno == null) return;            

            formerAlumno.Nombre = value.Nombre;
            formerAlumno.Apellidos = value.Apellidos;
            formerAlumno.Ciudad = value.Ciudad;
            formerAlumno.idMaestroAsignado = value.idMaestroAsignado;
            formerAlumno.Pais = value.Pais;
            formerAlumno.ZonaHoraria = value.ZonaHoraria;
            formerAlumno.Fotografia = value.ZonaHoraria;

            context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            //ELearningEntities context = new ELearningEntities();

            Alumno borrarAlumno = context.Alumno
                                        .FirstOrDefault(Alumno => Alumno.id == id);

            if (borrarAlumno == null) return;            

            context.Alumno.Remove(borrarAlumno);
            context.SaveChanges();
        }
    }
}
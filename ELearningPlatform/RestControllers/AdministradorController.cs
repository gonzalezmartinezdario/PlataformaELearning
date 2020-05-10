using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ELearningPlatform.RestControllers
{
    public class AdministradorController : ApiController
    {
        ELearningEntities context;

        //Constructor
        AdministradorController()
        {
            context = new ELearningEntities();
            context.Configuration
                    .ProxyCreationEnabled = false;
        }

        // GET api/<controller>
        public IEnumerable<Administrador> Get()
        {
            return context.Administrador
                   .AsNoTracking().ToList();
        }

        // GET api/<controller>/5
        public Administrador Get(int id)
        {
            return context.Administrador
                   .AsNoTracking().FirstOrDefault( Admin => Admin.idAdmin == id);
        }

        // POST api/<controller>
        public void Post([FromBody]Administrador value)
        {
            context.Administrador.Add(value);
            context.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Administrador value)
        {
            Administrador formerAdmin = context.Administrador
                                                 .FirstOrDefault(Admin => Admin.idAdmin
                                                                     == value.idAdmin);
            //Si no se encuentra el elemento
            if (formerAdmin == null) return;

            //Igualar los objetos
            formerAdmin.Apellido = value.Apellido;
            formerAdmin.Nombre = value.Nombre;            
            formerAdmin.Pais = value.Pais;
            formerAdmin.ZonaHoraria = value.ZonaHoraria;

            context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            Administrador borrarAdmin = context.Administrador
                                                 .FirstOrDefault(Admin =>
                                                                 Admin.idAdmin == id);

            if (borrarAdmin == null) return;

            context.Administrador.Remove(borrarAdmin);
            context.SaveChanges();
        }

        //Destructor
        ~AdministradorController()  // finalizer
        {
            context = null;
        }
    }
}
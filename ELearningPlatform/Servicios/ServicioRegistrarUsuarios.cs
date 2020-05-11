using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearningPlatform.ViewModels;

namespace ELearningPlatform.Servicios
{
    public class ServicioRegistrarUsuarios
    {     

        public void RegistrarUsuarios(UsuarioViewModel model)
        {
            string tipo = model.TipoUsuario.ToUpper();

            switch(tipo)
            {
                case "ADMINISTRADOR":
                        ingresarAdministrador(model);
                    break;
                case "ALUMNO":
                        ingresarAlumno(model);
                    break;
                case "MAESTRO":
                        ingresarMaestro(model);
                    break;
                default:
                    return;
                break;
            }
        }

        private ELearningEntities ConexionFabrica()
        {
            ELearningEntities context = new ELearningEntities();
            return context;
        }

        private void ingresarMaestro(UsuarioViewModel model)
        {
            ELearningEntities context = ConexionFabrica();

            string _idMaestro = obtenerIdUsuario(model);

            //Llena el objeto
            Maestro maestro = new Maestro()
            {
                id = 0,
                Apellidos = model.Apellidos,
                Ciudad = model.Ciudad,
                idMaestro = _idMaestro,
                Nombre = model.Nombre,
                Pais = model.Pais,
                ZonaHoraria = model.ZonaHoraria,
                Fotografia = string.Empty
            };

            //Guarda el maestro y commit
            context.Maestro.Add(maestro);
            context.SaveChanges();
            
            //ingresa ROLE
            //ingresarRole(_idMaestro, " MAESTRO");

        }

        private string obtenerIdUsuario(UsuarioViewModel model)
        {
            ELearningEntities context = ConexionFabrica();

            //Busca el id de los usuarios
            string _idUsuario = context.AspNetUsers
                                .FirstOrDefault(u => u.Email
                                                  == model.Email)
                                                  .Id;
            return _idUsuario;
        }
        
        private void ingresarAlumno(UsuarioViewModel model)
        {
            //Crea conexion
            ELearningEntities context = new ELearningEntities();
            //Obtiene id del usuario
            string _idAlumo = obtenerIdUsuario(model);

            //Llena el alumno
            Alumno alumno = new Alumno()
            {
                Apellidos = model.Apellidos,
                Ciudad = model.Ciudad,
                HorasCompradas = model.HorasCompradas,
                id = 0,
                idAlumno = _idAlumo,
                Nombre = model.Nombre,
                Pais = model.Pais,
                ZonaHoraria = model.ZonaHoraria,
                Fotografia = string.Empty                
            };

            //Ingresa alumno y guarda cambios
            context.Alumno.Add(alumno);
            context.SaveChanges();

            //Ingresa Role
            //ingresarRole(_idAlumo, "ALUMNO");
        }

        private void ingresarAdministrador(UsuarioViewModel model)
        {
            //Crea conexion
            ELearningEntities context = new ELearningEntities();
            //Obtiene id del usuario
            string _idAdministrador = obtenerIdUsuario(model);

            Administrador admin = new Administrador()
            {
                Apellido = model.Apellidos,
                idAdmin = 0,
                idAdministrador = _idAdministrador,
                Nombre = model.Nombre,
                Pais = model.Pais,
                ZonaHoraria = model.ZonaHoraria,
                Fotografia = string.Empty
            };

            //Guarda Administrador y guarda cambios
            context.Administrador.Add(admin);
            context.SaveChanges();            

        }
    }
}
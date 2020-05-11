using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ELearningPlatform.ViewModels
{
    public class UsuarioViewModel
    {[Required]
        [Display(Name = "Name")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Last name")]
        public string Apellidos { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string Pais { get; set; }
        [Required]
        [Display(Name = "City")]
        public string Ciudad { get; set; }
        public string ZonaHoraria { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Contrasena { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Contrasena", ErrorMessage = "Password and Confirm password do not match.")]
        public string ConfirmContrasena { get; set; }
        public int HorasCompradas { get; set; }
        public string TipoUsuario { get; set; }
        [Required]
        [Display(Name = "Country code")]
        public string TelCodigoPais { get; set; }
        [Required]
        [Display(Name = "Phone number")]
        public string TelNumero { get; set; }

    }
}
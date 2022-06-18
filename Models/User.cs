using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace CRMventas.Models
{
    public class User
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "El nombre completo es requerido.")]
        public string Name { get; set; }
        [Range(1, 4, ErrorMessage = "El Tipo de usuario es requerido.")]
        public string Type { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "El User Name es requerido.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password es requerido.")]
        [StringLength(maximumLength: 10, MinimumLength = 5, ErrorMessage = "Password debe tener entre 5 y 10 caracteres.")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password y Confirmacion deben ser iguales.")]
        public string PasswordConfirm { get; set; }
        public bool Active { get; set; }
        public string File { get; set; }
    }

    public class Modelos
    {
        public User User { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}




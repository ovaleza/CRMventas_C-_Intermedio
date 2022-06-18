using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace CRMventas.Models
{
    public class Client
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "El campo nombre de Cliente es requerido")]
        public string Name { get; set; }
        public string Address { get; set; }
        [StringLength(maximumLength: 15, MinimumLength = 10, ErrorMessage = "Telefono debe tener mínimo 10 caracteres, máximo 15")]
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public bool Active { get; set; }
        public string File { get; set; }
    }
    public class ClientList
    {
       public List<Client> Clients;
    }
}

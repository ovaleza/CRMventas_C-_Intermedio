using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace CRMventas.Models
{
    public class Tclient
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido.")]
        public string Name { get; set; }
        public string User { get; set; }
        public string Note { get; set; }
    }
    public class TclientList
    {
        public List<Tclient> Tclients;
    }
}

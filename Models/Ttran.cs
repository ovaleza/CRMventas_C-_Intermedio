using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace CRMventas.Models
{
    public class Ttran
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido.")]
        public string Name { get; set; }
        public string User { get; set; }
        public string Note { get; set; }
    }
    public class TtranList
    {
        public List<Ttran> Ttrans;
    }
}

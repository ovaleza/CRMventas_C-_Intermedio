using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace CRMventas.Models
{
    public class Iteraction
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Es requerido el cliente.")]
        public string ClientId { get; set; }
        [Range(1,4, ErrorMessage = "El Tipo de Trasaccion es requerido.")]
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public string File { get; set; }
        public string Client { get; set; }
        public string User { get; set; }
        public IEnumerable<Iteraction> Iteractions { get; set; }
    }
}

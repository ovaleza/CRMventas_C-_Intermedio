using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace CRMventas.Models
{
    public class Transaction
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Es requerido el cliente.")]
        public string ClientId { get; set; }
        [Range(1,4, ErrorMessage = "El Tipo de Trasaccion es requerido.")]
        public string Type { get; set; }
        [Required(ErrorMessage = "El Monto es requerido.")]
        public string Amount { get; set; }
        public string User { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public string File { get; set; }
    }
    public class TransactionList
    {
        public List<Transaction> Transactions; 

    }
}

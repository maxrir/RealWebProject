using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [Table("Transacoes")]
    public class Transacao
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataHoraTransacao { get; set; }
        public double ValorTotal { get; set; }
        public double ValorPago { get; set; }
        public double Troco { get; set; }
    }
}

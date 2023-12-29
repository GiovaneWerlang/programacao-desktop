using System;
using System.Collections.Generic;

#nullable disable

namespace CORE.MODELS
{
    public partial class Lançamento
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int ContaId { get; set; }
        public int Operacao { get; set; }
        public string Historico { get; set; }
        public decimal Valor { get; set; }

        public virtual Conta Conta { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace CORE.MODELS
{
    public partial class Conta
    {
        public Conta()
        {
            Lançamentos = new HashSet<Lançamento>();
        }

        public int Id { get; set; }
        public int CorrentistaId { get; set; }
        public decimal LimiteCredito { get; set; }
        public decimal Saldo { get; set; }
        public DateTime DataAbertura { get; set; }

        public virtual Correntista Correntista { get; set; }
        public virtual ICollection<Lançamento> Lançamentos { get; set; }
    }
}

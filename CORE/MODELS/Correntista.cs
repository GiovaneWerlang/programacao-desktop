using System;
using System.Collections.Generic;

#nullable disable

namespace CORE.MODELS
{
    public partial class Correntista
    {
        public Correntista()
        {
            Conta = new HashSet<Conta>();
        }

        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Conta> Conta { get; set; }
    }
}

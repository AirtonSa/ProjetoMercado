using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Models
{
    public class EstoqueViewModel
    {
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public string Mensagem { get; set; }
        public int Saldo { get; set; }

        public bool PossueEstoque { get; set; }
    }
}

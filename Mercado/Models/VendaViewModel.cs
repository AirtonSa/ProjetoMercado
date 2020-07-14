using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Models
{
    public class VendaViewModel
    {
        public string idProduto { get; set; }

        public string valor { get; set; }

        public string quantidade { get; set; }

        public decimal ValorTotal { get; set; }
    }

    public class CarrinhoViewModel
    {
        public CarrinhoViewModel(string qtd, bool sucesso)
        {
            quantidadeitens = qtd;
            this.sucesso = sucesso;
        }

        public string quantidadeitens { get; set; }

        public bool sucesso { get; set; }

 
    }
}

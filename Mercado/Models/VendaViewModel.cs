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
}

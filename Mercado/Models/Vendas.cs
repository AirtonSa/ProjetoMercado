using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Models
{
    public class Vendas : BaseModel
    {
        public Usuario Usuario{get; set;}

        public Produto Produto { get; set; }

        public string quantidade { get; set; }

        public decimal ValorTotal { get; set; }

       

    }
}

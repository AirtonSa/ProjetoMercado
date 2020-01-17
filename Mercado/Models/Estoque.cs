using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Models
{
    public class Estoque : BaseModel
    {
        public int Quantidade { get; set; }

        public Produto Produto { get; set; }
        public Usuario Usuario { get; set;  }
    }
}

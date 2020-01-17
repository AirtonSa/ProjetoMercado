using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Models
{
    public class Usuario : BaseModel
    {
        public string Nome { get; set; }

        public string Senha { get; set; }
        
    }
}

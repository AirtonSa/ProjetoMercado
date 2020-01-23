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
        public Usuario Usuario { get; set; }

        public TipoLancamento TipoLancamento { get; set; }

        public Estoque()
        {
          
        }

        public Estoque(int quantidade, Produto produto, Usuario usuario, TipoLancamento tipoLancamento)
        {
            Quantidade = quantidade;
            Produto = produto;
            Usuario = usuario;
            TipoLancamento = tipoLancamento;
        }

    
    }
    

    public class teste
    {
        public string ahuhuahu { get; set; }
        public string ahuhfrruahu { get; set; }
        public outroobj outroobj { get; set; }

    }

    public class outroobj
    {
        public string frf { get; set; }
        public string descricao { get; set; }
        public string ahuhasasuahu { get; set; }
    }

   
}

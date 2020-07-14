using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Models
{
    //public class Vendas : BaseModel
    //{        
    //    public List<Pedido> Itens { get; set; }       
    //    public decimal ValorTotal { get; set; }         
    //}



    public class Pedido : BaseModel
    {
        public List<ItemPedido> Itens { get; set; }
        public Usuario Usuario { get; set; }
        public decimal ValorTotal { get; set; }        
        public StatusPedido Status { get; set; }

    }

    public class ItemPedido : BaseModel
    {
        public Pedido Pedido { get; set; }       
        public Produto Produto { get; set; }
        public string quantidade { get; set; }     

    }

    public class StatusPedido : BaseModel
    {
        public string Descricao { get; set; }
    }
}

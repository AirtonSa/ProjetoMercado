﻿using Mercado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Repositories
{
    public interface IItemPedidoRepository
    {
         void SalvarItem(ItemPedido Item);

      
    }
}
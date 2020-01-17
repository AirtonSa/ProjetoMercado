using Mercado.Banco;
using Mercado.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Repositories
{
    public class BaseRepository<T> where T : BaseModel
    {
        protected readonly AplicationContext context;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(AplicationContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();

        }
    }
}

using Mercado.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Banco
{
    public partial class Startup
    {
        class DataService : IDataService
        {
            private readonly AplicationContext aplicationContext;

            public DataService(AplicationContext aplicationContext)
            {

                this.aplicationContext = aplicationContext;

            }

            public void InicializaDB()
            {
                aplicationContext.Database.Migrate();
            }
        }
    }
}

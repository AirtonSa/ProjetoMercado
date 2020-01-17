using Mercado.Banco;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado
{
    //public class Dtservice
    //{
    //}

    public partial class Startup
    {
        class Dtservice : IDtService
        {
            private readonly AplicationContext aplicationContext;

            public Dtservice(AplicationContext aplicationContext)
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

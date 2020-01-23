using Mercado.Banco;
using Mercado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Repositories
{
    public class TipolancamentoRepository : BaseRepository<TipoLancamento>, ITipolancamentoRepository
    {

        public TipolancamentoRepository(AplicationContext context) : base(context)
        {

        }

        public TipoLancamento BuscarDescricaoporid( int id)
        {
            var buscardescrição = dbSet

                .Where(d => d.Id == id).FirstOrDefault();

            return buscardescrição;



        }
    }
}

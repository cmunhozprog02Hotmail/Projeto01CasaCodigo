using Modelo.Cadastros;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Cadastros
{
    public class FabricanteDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Fabricante>
        ObterCategoriasClassificadasPorNome()
        {
            return context.Fabricantes.OrderBy(b => b.Nome);
        }
    }
}

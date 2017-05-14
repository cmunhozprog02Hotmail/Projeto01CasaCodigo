using Modelo.Cadastros;
using Persistencia.DAL.Cadastros;
using System.Linq;

namespace Servico.Cadastros
{
    public class FabricanteServico
    {
        private FabricanteDAL fabricanteDAL = new  FabricanteDAL();
        public IQueryable<Fabricante>
        ObterCategoriasClassificadasPorNome()
        {
            return fabricanteDAL.
            ObterCategoriasClassificadasPorNome();
        }
    }
}

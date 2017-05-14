using Modelo.Cadastros;
using Persistencia.DAL.Cadastros;
using System.Linq;

namespace Servico.Cadastros
{
    public class CategoriaServico
    {
        private CategoriaDAL categoriaDAL = new CategoriaDAL();
        public IQueryable<Categoria>
        ObterCategoriasClassificadasPorNome()
        {
            return categoriaDAL.
            ObterCategoriasClassificadasPorNome();
        }
    }
}

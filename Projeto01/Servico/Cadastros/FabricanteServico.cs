using Modelo.Cadastros;
using Persistencia.DAL.Cadastros;
using System.Linq;

namespace Servico.Cadastros
{
    public class FabricanteServico
    {
        private FabricanteDAL fabricanteDAL = new  FabricanteDAL();

        public IQueryable<Fabricante>ObterCategoriasClassificadasPorNome()
        {
            return fabricanteDAL.ObterCategoriasClassificadasPorNome();
        }

        public Fabricante ObterFabricantePorId(long id)
        {
            return fabricanteDAL.ObterFabricantePorId(id);
        }

        public void GravarFabricante(Categoria categoria)
        {
            fabricanteDAL.GravarFabricante(fabricante);
        }

        public Fabricante EliminarFabricantePorId(long id)
        {
            return fabricanteDAL.EliminarFabricantePorId(id);
        }
    }
}

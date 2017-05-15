using Modelo.Cadastros;
using Persistencia.Contexts;
using System.Data.Entity;
using System.Linq;

namespace Persistencia.DAL.Cadastros
{
    public class CategoriaDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Categoria> ObterCategoriasClassificadasPorNome()
        {
            return context.Categorias.OrderBy(b => b.Nome);
        }

        // Burcar por ID - Edit, Details, Delete
        public Categoria ObterCategoriaPorId(long id)
        {
            return context.Categorias.Where(c => c.CategoriaId == id).First();
        }

        // Salvar Registros - Edit e Create
        public void GravarCategoria(Categoria categoria)
        {
            if (categoria.CategoriaId == null)
            {
                context.Categorias.Add(categoria);
            }
            else
            {
                context.Entry(categoria).State =
                EntityState.Modified;
            }
            context.SaveChanges();
        }

        // Deletar
        public Categoria EliminarCategoriaPorId(long id)
        {
            Categoria categoria = ObterCategoriaPorId(id);
            context.Categorias.Remove(categoria);
            context.SaveChanges();
            return categoria;
        }
    }
}

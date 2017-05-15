using Modelo.Cadastros;
using Persistencia.Contexts;
using System.Data.Entity;
using System.Linq;

namespace Persistencia.DAL.Cadastros
{
    public class FabricanteDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Fabricante>ObterFabricantesClassificadasPorNome()
        {
            return context.Fabricantes.OrderBy(b => b.Nome);
        }

        // Burcar por ID - Edit, Details, Delete
        public Fabricante ObterFabricantePorId(long id)
        {
            return context.Fabricantes.Where(c => c.FabricanteId == id).First();
        }

        // Salvar Registros - Edit e Create
        public void GravarFabricante(Fabricante fabricante)
        { 
            if (fabricante.FabricanteId == null)
            {
                context.Fabricantes.Add(fabricante);
            }
            else
            {
                context.Entry(fabricante).State = EntityState.Modified;
                
            }
            context.SaveChanges();
            
            
        }

        // Deletar
        public Fabricante EliminarFabricantePorId(long id)
        {
            Fabricante fabricante = ObterFabricantePorId(id);
            context.Fabricantes.Remove(fabricante);
            context.SaveChanges();
            return fabricante;
        }
    }
}

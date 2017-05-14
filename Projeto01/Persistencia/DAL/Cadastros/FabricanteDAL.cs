using Modelo.Cadastros;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (fabricante == null)
            {
                context.Fabricantes.Add(fabricante);
            }
            else
            {
                context.Entry(fabricante).State =
                EntityState.Modified;
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

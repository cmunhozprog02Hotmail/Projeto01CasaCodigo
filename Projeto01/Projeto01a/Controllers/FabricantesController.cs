using System.Web.Mvc;
using System.Net;
using Modelo.Cadastros;
using Servico.Cadastros;

namespace Projeto01a.Controllers
{
    public class FabricantesController : Controller
    {
        private ProdutoServico produtoServico = new ProdutoServico();
        private CategoriaServico categoriaServico = new CategoriaServico();
        private FabricanteServico fabricanteServico = new FabricanteServico();

        // GET: listar nomes por ordem alfabetica 
        public ActionResult Index()
        {
            return View(fabricanteServico.ObterFabricantePorNome());
        }

        private ActionResult ObterFabricantePorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = fabricanteServico.ObterFabricantePorId((long)id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        // GET: Details

        public ActionResult Details(long? id)
        {
            return ObterFabricantePorId(id);
        }

        // GET: Edit
        public ActionResult Edit(long? id)
        {
            return ObterFabricantePorId(id);
        }

        // GET: Delete
        public ActionResult Delete(long? id)
        {
            return ObterFabricantePorId(id);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Create e Edit
        private ActionResult GravarFabricante(Fabricante fabricante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    fabricanteServico.GravarFabricante(fabricante);
                    return RedirectToAction("Index");
                }
                return View(fabricante);

            }
            catch
            {

                return View(fabricante);
            }
        }

        // POST: Create 
        [HttpPost]
        
        public ActionResult Create(Fabricante fabricante)
        {
            return GravarFabricante(fabricante);
        }

        // POST: Edit 
        [HttpPost]
        
        public ActionResult Edit(Fabricante fabricante)
        {
            return GravarFabricante(fabricante);
        }

        // POST: Delete

        public ActionResult Delete(long id)
        {
            try
            {
                Fabricante fabricante = fabricanteServico.EliminarFabricantePorId(id);
                TempData["Message"] = "Fabricante " + fabricante.Nome.ToUpper() + " foi removido!";
                return RedirectToAction("Index");
            }
            catch
            {

                return View();
            }
        }
    }
}
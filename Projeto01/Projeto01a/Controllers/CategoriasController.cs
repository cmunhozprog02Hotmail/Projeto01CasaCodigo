using Modelo.Cadastros;
using Servico.Cadastros;
using System.Net;
using System.Web.Mvc;

namespace Projeto01a.Controllers
{
    public class CategoriasController : Controller
    {
        private CategoriaServico categoriaServico = new CategoriaServico();

        // GET: Categorias lista por ordem alfabetica 
        public ActionResult Index()
        {
            return View(categoriaServico.ObterCategoriasClassificadasPorNome());
        }

        private ActionResult ObterCategoriaPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = categoriaServico.ObterCategoriaPorId((long)id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // GET: Details

        public ActionResult Details(long? id)
        {
            return ObterCategoriaPorId(id);
        }

        // GET: Delete
        public ActionResult Delete(long? id)
        {
            return ObterCategoriaPorId(id);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Create e Edit
        private ActionResult GravarCategoria(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoriaServico.GravarCategoria(categoria);
                    return RedirectToAction("Index");
                }
                return View(categoria);

            }
            catch
            {

                return View(categoria);
            }
        }

        // POST: Create 
        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }

        // POST: Edit 
        [HttpPost]
        public ActionResult Edit(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }

        // POST: Delete

        public ActionResult Delete(long id)
        {
            try
            {
                Categoria categoria = categoriaServico.EliminarCategoriaPorId(id);
                TempData["Message"] = "Categoria " + categoria.Nome.ToUpper() + " foi removida!";
                return RedirectToAction("Index");
            }
            catch
            {

                return View();
            }
        }
    }
}
    
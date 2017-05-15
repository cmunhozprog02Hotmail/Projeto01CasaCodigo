using System.Web.Mvc;
using System.Net;
using Modelo.Cadastros;
using Servico.Cadastros;

namespace Projeto01a.Controllers
{
    public class ProdutosController : Controller
    {
        // Declaração dos Serviços
        private ProdutoServico produtoServico = new ProdutoServico();
        private CategoriaServico categoriaServico = new CategoriaServico();
        private FabricanteServico fabricanteServico = new FabricanteServico();

        // GET: Produtos
        public ActionResult Index()
        {
            return View(produtoServico.ObterProdutosClassificadosPorNome());
        }

        private ActionResult ObterVisaoProdutoPorId(long? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = produtoServico.ObterProdutoPorId((long)id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        //GET: Edit
        public ActionResult Edit(long? id)
        {
            PopularViewBag();
            return ObterVisaoProdutoPorId(id);
        }

        // GET: Details
        
        public ActionResult Details(long? id)
        {
            return ObterVisaoProdutoPorId(id);
        }
        
        /*
        // GET: Delete
        public ActionResult Delete(long? id)
        {
            return ObterVisaoProdutoPorId(id);
        }
        */

        //Popular DropList
        private void PopularViewBag(Produto produto = null)
        {
            if (produto == null)
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico.ObterCategoriasClassificadasPorNome(), "CategoriaId", "Nome");
                ViewBag.FabricanteId = new SelectList(fabricanteServico.ObterFabricantePorNome(), "FabricanteId", "Nome");
            }
            else
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico.ObterCategoriasClassificadasPorNome(), "CategoriaId", "Nome", produto.CategoriaId);
                ViewBag.FabricanteId = new SelectList(fabricanteServico.ObterFabricantePorNome(), "FabricanteId", "Nome", produto.FabricanteId);
            }
        }
        
       
        // GET: Produtos/Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        // GET: Create e Edit
        private ActionResult GravarProduto(Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    produtoServico.GravarProduto(produto);
                    return RedirectToAction("Index");
                }
                return View(produto);

            }
            catch 
            {

                return View(produto);
            }
        }

        // POST: Create 
        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            return GravarProduto(produto);
        }

        // POST: Edit 
        [HttpPost]
        public ActionResult Edit(Produto produto)
        {
            return GravarProduto(produto);
        }

        // POST: Delete

        public ActionResult Delete(long id)
        {
            try
            {
                Produto produto = produtoServico.EliminarProdutoPorId(id);
                TempData["Message"] = "Produto " + produto.Nome.ToUpper() + " foi removido!";
                return RedirectToAction("Index");
            }
            catch 
            {

                return View();
            }
        }
        
    }
}

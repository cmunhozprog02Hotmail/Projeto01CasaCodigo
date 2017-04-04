using Projeto01a.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Projeto01a.Controllers
{
    public class CategoriasController : Controller
    {
        private static IList<Categoria> categorias = new List<Categoria>()
        {
            new Categoria() {
                CategoriaId = 1,
                Nome = "Notebooks"
                },
                new Categoria() {
                CategoriaId = 2,
                Nome = "Monitores"
                },
                new Categoria() {
                CategoriaId = 3,
                Nome = "Impressoras"
                },
                new Categoria() {
                CategoriaId = 4,
                Nome = "Mouses"
                },
                new Categoria() {
                CategoriaId = 5,
                Nome = "Desktops"
                }
         };
    
        // GET: Categorias
        public ActionResult Index()
        {
            return View(categorias);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            categorias.Add(categoria);
            categoria.CategoriaId = categorias.Select(m => m.CategoriaId).Max() + 1;
            return RedirectToAction("Index");
        }

        // GET: Edit
        public ActionResult Edit(long id)
        {
            return View(categorias.Where(m => m.CategoriaId == id).First());
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            categorias[categorias.IndexOf(categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First())] = categoria;
            return RedirectToAction("Index");
        }

        // GET: Details
        public ActionResult Details(long id)
        {
            return View(categorias.Where(m => m.CategoriaId == id).First());
        }
    }
}
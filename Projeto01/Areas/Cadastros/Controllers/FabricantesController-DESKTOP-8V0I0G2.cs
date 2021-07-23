using System.Linq;
using System.Web.Mvc;
using Modelo.Cadastros;
using System.Net;
using System.Data.Entity;
using Servicos.Cadastros;
using System;

namespace Projeto01.Areas.Cadastros.Controllers
{
    [Authorize]
    [Authorize(Roles = "Cadastros")]
    public class FabricantesController : Controller
    {
        //private EFContext context = new EFContext();
        private FabricanteServico fabricanteServico = new FabricanteServico();
        // GET: Fabricantes
        private ActionResult ObterVisaoFabricantePorId (long? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = fabricanteServico.ObterFabricantePorId(Convert.ToInt64(id));
            if(fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }
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
        [Authorize]
        public ActionResult Index()
        {
            return View(fabricanteServico.ObterFabricantesClassificadosPorNome().ToList());
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            return GravarFabricante(fabricante);
        }
        [Authorize]
        public ActionResult Edit(long? id)
        {
            return ObterVisaoFabricantePorId(id);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (Fabricante fabricante)
        {
            return GravarFabricante(fabricante);
        }
        [Authorize]
        public ActionResult Details (long? id)
        {
            return ObterVisaoFabricantePorId(id);
        }
        [Authorize]
        public ActionResult Delete (long? id)
        {
            return ObterVisaoFabricantePorId(id);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete (long id)
        {
            try
            {
                Fabricante fabricante = fabricanteServico.EliminarFabricantePorId(id);
                TempData["Message"] = "Fabricante " + fabricante.Nome.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch 
            {
                return View();
            }
        }
    }
}
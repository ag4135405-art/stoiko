using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto.Controllers
{
    public class Perfil_usuController : Controller
    {
        // GET: Perfil_usu
        public ActionResult Index()
        {
            return View();
        }

        // GET: Perfil_usu/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Perfil_usu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Perfil_usu/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Perfil_usu/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Perfil_usu/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Perfil_usu/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Perfil_usu/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

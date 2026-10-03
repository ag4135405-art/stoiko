using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto.Controllers
{
    public class EjercicioController : Controller
    {
        // GET: Ejercicio
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ejercicio/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ejercicio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ejercicio/Create
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

        // GET: Ejercicio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ejercicio/Edit/5
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

        // GET: Ejercicio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ejercicio/Delete/5
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

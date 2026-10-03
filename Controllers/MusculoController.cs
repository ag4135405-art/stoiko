using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto.Controllers
{
    public class MusculoController : Controller
    {
        // GET: Musculo
        public ActionResult Index()
        {
            return View();
        }

        // GET: Musculo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Musculo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Musculo/Create
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

        // GET: Musculo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Musculo/Edit/5
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

        // GET: Musculo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Musculo/Delete/5
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

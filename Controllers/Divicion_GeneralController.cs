using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto.Controllers
{
    public class Divicion_GeneralController : Controller
    {
        // GET: Divicion_GeneralController
        public ActionResult Index()
        {
            return View();
        }

        // GET: Divicion_GeneralController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Divicion_GeneralController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Divicion_GeneralController/Create
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

        // GET: Divicion_GeneralController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Divicion_GeneralController/Edit/5
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

        // GET: Divicion_GeneralController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Divicion_GeneralController/Delete/5
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

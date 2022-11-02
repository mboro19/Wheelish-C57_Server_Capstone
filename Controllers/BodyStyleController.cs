using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Wheelish.Controllers
{
    public class BodyStyleController : Controller
    {
        // GET: BodyStyleController
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //// GET: BodyStyleController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: BodyStyleController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: BodyStyleController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: BodyStyleController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: BodyStyleController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: BodyStyleController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: BodyStyleController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}

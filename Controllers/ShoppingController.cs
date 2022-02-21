using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Boutique.Models;

namespace Boutique.Controllers
{
    public class ShoppingController : Controller
    {
        // GET: Shopping
        public ActionResult BoutiquesList()
        {
            var compo = new DetailsImple();
            var obj = compo.GetBoutique();
            return View(obj);
        }
        [HttpPost]
        public ActionResult OnEdit(string Id)
        {
            int Bid = Convert.ToInt32(Id);
            var component = new DetailsImple();
            try
            {
                component.Delete(Bid);
                return RedirectToAction("GetBoutique");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult OnEdit(BoutiqueDetails modifed)
        {
            var component = new DetailsImple();
            try
            {
                component.Update(modifed);
                return RedirectToAction("GetBoutique");
            }
            catch (Exception)
            {
                throw;
            }
        }

        
        public ActionResult Add(BoutiqueDetails modifieddata)
        {
            var com = new DetailsImple();
            try
            {
                com.Add(modifieddata);
                return RedirectToAction("GetBoutique");
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                ViewBag.ErrorMessage = message;
                return View(new BoutiqueDetails());
            }
        }
    }
}
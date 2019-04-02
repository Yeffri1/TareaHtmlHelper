using htmlHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace htmlHelper.Controllers
{
    public class HomeController : Controller
    {
        List<SelectListItem> generos = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Masculino",
                    Value = "1"
                },
                new SelectListItem()
                {
                    Text = "Femenino",
                    Value = "2"
                }
            };
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Formulario()
        {
           
            ViewBag.Generos = new SelectList(generos, "Value", "Text");
            return View(new Cliente());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Formulario([Bind]Cliente cliente)
        {
            cliente = cliente ?? new Cliente();
            if (ModelState.IsValid)
            {
                cliente.EstadoCivil_Text = cliente.GetEstadoText(cliente.EstadoCivil);
                cliente.GeneroText = cliente.GetGeneroText(cliente.Genero);
                return View("MostrarInfo", cliente);
            }
            ViewBag.Generos = new SelectList(generos, "Value", "Text");
            return View(cliente);
        }
        [HttpGet]
        public ActionResult CedulaValida(string Cedula)
        {
            return Json(ValidarCedula.EsValid(Cedula),JsonRequestBehavior.AllowGet);
        }
     
    }
}
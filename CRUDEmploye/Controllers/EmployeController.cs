using CRUDEmploye.Models.DAL;
using CRUDEmploye.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDEmploye.Controllers
{
    public class EmployeController : Controller
    {
        private IDAL _service;
        public EmployeController(IDAL service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service.SelectAll());
        }
        public JsonResult GetData()
        {
            List<Employe> empList = _service.SelectAll();
            return Json(empList );
        }

        public ActionResult GetEmployePartial()
        {
            var employe = new Employe();
            return PartialView("AddEditEmployePartial", employe);
        }

        public JsonResult AddEdit(Employe employe)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.Add(employe);
                    
                }
                return Json(new { sucess = true, message = "Bien reçcu" });
            }
            catch (Exception e)
            {

                return Json(new { sucess = false, message = e.Message });
            }
        }
        //[HttpGet]
        //public ActionResult AddEdit(int Id=0)
        //{
        //    return View(new Employe());
        //}
        //[HttpPost]
        //public ActionResult AddEdit()
        //{
        //    return View();
        //}
    }
}

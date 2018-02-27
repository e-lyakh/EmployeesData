using HR.DAL.DbLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.WebUI.Controllers
{
    public class EmpPromotionController : Controller
    {
        HrContext context;
        public EmpPromotionController()
        {
            context = new HrContext();
        }

        public ActionResult Index(int id = 0)
        {
            ViewBag.EmployeeId = new SelectList(
                context.Employees.Select(e => new
                {
                    e.EmployeeId,
                    FullName = e.FirstName + " " + e.LastName
                })
                ,
                "EmployeeId", "FullName", (id == 0) ? context.Employees.FirstOrDefault().EmployeeId : id);
            return View();
        }

        [HttpPost]
        public ActionResult ListProms(int id)
        {
            var model = context.EmpPromotions.Where(p => p.EmployeeId == id);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var obj = context.EmpPromotions.Find(id);
            context.EmpPromotions.Remove(obj);
            context.SaveChanges();
            return Json("OK");            
        }

        public ActionResult Edit(int id, int EmployeeId = 0)
        {
            var model = (id == 0) ? new EmpPromotion() { EmployeeId = EmployeeId, HireDate = DateTime.Now } :
                context.EmpPromotions.Find(id);
            ViewBag.Emp = context.Employees.Find(model.EmployeeId);
            ViewBag.JobTitleId = new SelectList(context.JobTitles, "JobTitleId", "NameJobTitle", model.JobTitleId);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EmpPromotion obj)
        {
            if (ModelState.IsValid)
            {
                context.EmpPromotions.AddOrUpdate(obj);
                context.SaveChanges();
                return RedirectToAction("Index", new { id = obj.EmployeeId });
            }
            return View(obj);
        }
    }
}
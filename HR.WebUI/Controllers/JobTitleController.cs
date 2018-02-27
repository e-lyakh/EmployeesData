using HR.DAL.DbLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Migrations;

namespace HR.WebUI.Controllers
{
    public class JobTitleController : Controller
    {
        HrContext context;

        public JobTitleController()
        {
            context = new HrContext();
        }

        public ActionResult Index()
        {
            var model = context.JobTitles;
            return View(model);
        }

        public ActionResult Edit(int id=0)
        {
            JobTitle model = id == 0 ? new JobTitle() : context.JobTitles.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(JobTitle job)
        {
            if(ModelState.IsValid)
            {                
                context.JobTitles.AddOrUpdate(job);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(job);
        }

        public ActionResult Delete(int id)
        {
            context.JobTitles.Remove(context.JobTitles.Find(id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

    }
}
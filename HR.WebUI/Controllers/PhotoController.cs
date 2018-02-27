using HR.DAL.DbLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.WebUI.Controllers
{
    public class PhotoController : Controller
    {
        HrContext context;               

        public PhotoController()
        {
            context = new HrContext();            
        }

        public ActionResult Index(int? id = 0)
        {
            ViewBag.EmployeeId = new SelectList(
                context.Employees.Select(e => new
                {
                    e.EmployeeId,
                    FullName = e.FirstName + " " + e.LastName
                }),
                "EmployeeId", "FullName", (id==0)? context.Employees.FirstOrDefault().EmployeeId : id);
            return View();
        }             

        [HttpPost]
        public ActionResult ListPhoto(int id)
        {
            var model = context.Photos.Where(p => p.EmployeeId == id);
            EmployeeId.Id = id;         
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var photoToDel = context.Photos.Find(id);

            string photoDest = photoToDel.PhotoPath.Substring(1);
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, photoDest);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
                file.Delete();

            context.Photos.Remove(photoToDel);
            context.SaveChanges();

            return Json("OK");
        }

        public ActionResult UploadPhotos(IEnumerable<HttpPostedFileBase> photos)
        {
            Photo photo;            
            foreach (var p in photos)
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/");
                string filename = Path.GetFileName(p.FileName);
                string ext = Path.GetExtension(filename);
                filename = Guid.NewGuid().ToString() + ext;
                if (p != null) p.SaveAs(Path.Combine(path, filename));

                photo = context.Photos.Create();
                photo.EmployeeId = EmployeeId.Id;
                photo.PhotoPath = "/Images/" + filename;
                context.Photos.Add(photo);
            }
            context.SaveChanges();
            return RedirectToAction("Index", "Photo", new { id = EmployeeId.Id } );
        }
    }
}
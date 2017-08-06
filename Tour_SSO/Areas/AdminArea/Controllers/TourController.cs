using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_SSO.Models;

namespace Tour_SSO.Areas.AdminArea.Controllers
{
    public class TourController : Controller
    {
        // GET: AdminArea/Home
        public ActionResult Index()
        {
            UnitOfWork _unitOfWork = new UnitOfWork(new TourEntities());
            var model = _unitOfWork.TourRepo.GetAll().ToList();
            return View(model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            UnitOfWork _unitOfWork = new UnitOfWork(new TourEntities());
            var country = _unitOfWork.CountryRepo.GetAll().ToList();
            ViewBag.country = new SelectList(country, "CountryId", "Name");
            var tourPlace = _unitOfWork.TourPlaceRepo.GetAll().ToList();
            ViewBag.tourPlace = new SelectList(tourPlace, "TourPlaceId", "Name");
            return View();
        }

        public ActionResult LoadCb2(int countryID)
        {
            UnitOfWork _unitOfWork = new UnitOfWork(new TourEntities());
            var tourPlace = (List<TourPlace>)(from a in _unitOfWork.CountryRepo.GetAll()
                                              join b in _unitOfWork.ForeignAreaRepo.GetAll() on a.CountryId equals b.CountryId
                                              join c in _unitOfWork.TourPlaceRepo.GetAll() on b.ForeignAreaId equals c.ForeignAreaId
                                              where a.CountryId == countryID
                                              select c).ToList();
            return Json(tourPlace, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Detail()
        {
            return PartialView();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UploadImage(HttpPostedFileBase upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            string url; // url to return
            string message; // message to display (optional)

            // here logic to upload image
            // and get file path of the image

            // path of the image
            string path = "Content/Images/my_uploaded_image.jpg";

            // will create http://localhost:1457/Content/Images/my_uploaded_image.jpg
            url = Request.Url.GetLeftPart(UriPartial.Authority) + "/" + path;

            // passing message success/failure
            message = "Image was saved correctly";

            // since it is an ajax request it requires this string
            string output = @"<html><body><script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + url + "\", \"" + message + "\");</script></body></html>";
            return Content(output);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Tour model, List<int> TourPlace)
        {

            UnitOfWork _unitOfWork = new UnitOfWork(new TourEntities());
            var img = Request.Files["Image"];
            if (img.ContentLength > 0 && img != null)
            {
                string path = Server.MapPath("~/Upload/" + img.FileName);
                img.SaveAs(path);

                string a = "../../../../Upload/" + img.FileName;
                model.Image = a;
            }
            model.Status = 1;
            model.Booked = 0;
            model.UnitPrice = "VNĐ";
            TimeSpan? Days = model.EndDate - model.StartDate;
            model.Days = (int)Days.Value.TotalDays;
            model.Note = Request["Note"] == null ? null : Request["Note"];
            model.InOutType = Int32.Parse(Request["Country"]) == 1 ? 1 : 2;
            _unitOfWork.TourRepo.Insert(model);
            int _tourID = model.TourId;
            for (int i = 0; i < TourPlace.Count(); i++)
            {
                TourDetail _tourDetail = new TourDetail();
                _tourDetail.TourId = _tourID;
                _tourDetail.TourPlaceId = TourPlace[i];
                _tourDetail.Status = 1;
                _unitOfWork.TourDetailRepo.Insert(_tourDetail);
            }

            _unitOfWork.Save();

            //return Content("<script language='javascript' type='text/javascript'> alert(" + model.CategoryId + model.Special + model.Name + img.InputStream. + ");</script>");
            return RedirectToAction("Index");

            //return Content("<script language='javascript' type='text/javascript'>alert('Hello world!');</script>");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            UnitOfWork _unitOfWork = new UnitOfWork(new TourEntities());
            var model = _unitOfWork.TourRepo.GetById(id);
            var country = _unitOfWork.CountryRepo.GetAll().ToList();
            ViewBag.country = new SelectList(country, "CountryId", "Name");
            var tourPlace = _unitOfWork.TourPlaceRepo.GetAll().ToList();
            ViewBag.tourPlace = new SelectList(tourPlace, "TourPlaceId", "Name");

            return View(model);
        }

        public ActionResult Delete(int tourid)
        {
            UnitOfWork _unitOfWork = new UnitOfWork(new TourEntities());
            var modelTourPlace = _unitOfWork.TourDetailRepo.GetAll().Where(x => x.TourId == tourid).ToList();
            for (int i = 0; i < modelTourPlace.Count(); i++)
            {
                _unitOfWork.TourDetailRepo.Delete(modelTourPlace[i]);
            }
            var model = _unitOfWork.TourRepo.GetById(tourid);
            _unitOfWork.TourRepo.Delete(model);
            _unitOfWork.Save();
            return Json(model, JsonRequestBehavior.AllowGet);
        }



    }
}
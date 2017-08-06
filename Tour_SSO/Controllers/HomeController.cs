using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_SSO.Models;

namespace Tour_SSO.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int k = 0;
            UnitOfWork _unitOfWork = new UnitOfWork(new TourEntities());
            ViewBag.InTour = _unitOfWork.TourRepo.GetAll().Where(x => x.InOutType == 1).Take(4).ToList();
            ViewBag.OutTour = _unitOfWork.TourRepo.GetAll().Where(x => x.InOutType == 2).Take(4).ToList();
            return View();
        }

        public ActionResult FindCountry(string Type = "1")
        {
            UnitOfWork _unitOfWork = new UnitOfWork(new TourEntities());
            List<string> Arrivel = new List<string>();
            if (Type == "1")
            {
                Arrivel = (from a in _unitOfWork.CountryRepo.GetAll()
                           join b in _unitOfWork.ForeignAreaRepo.GetAll() on a.CountryId equals b.CountryId
                           where a.AreaId == 1
                           select b.Name).ToList();
            }
            else
            {
                Arrivel = _unitOfWork.CountryRepo.GetAll().Where(x => x.AreaId == 2).Select(x => x.Name).ToList();
            }

            return Json(Arrivel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail(int id)
        {
            UnitOfWork _unitOfWork = new UnitOfWork(new TourEntities());
            var model = _unitOfWork.TourRepo.GetById(id);
            return View(model);
        }

        public ActionResult ExpandTour(int id)
        {
            UnitOfWork _unitOfWork = new UnitOfWork(new TourEntities());

            List<Tour> model = null;

            if (id == 1)
            {
                model = _unitOfWork.TourRepo.GetAll().Where(x => x.InOutType == 1).ToList();
            }
            else
            {
                model = _unitOfWork.TourRepo.GetAll().Where(x => x.InOutType == 2).ToList();
            }

            return View(model);
        }

        public ActionResult TourOrder()
        {
            return View();
        }

    }
}
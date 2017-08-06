using Movie.Models;
using Movie.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using PagedList;

namespace Movie.Controllers
{
    public class TimKiemController : Controller
    {
        //
        // GET: /TimKiem/
        public ActionResult Index(string phim, string theloais, string quocgias, int? page)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new movieEntities());
            CommonMovieViewModel model = new CommonMovieViewModel();
            theloais = theloais + string.Empty;
            quocgias = quocgias + string.Empty;
            phim = phim + string.Empty;
             int pageSize = 2;
            int pageNumber = (page ?? 1);

            model.TheLoaiPhims = unitOfWork.Theloaiphim.GetAll().ToList();
            model.QuocGias = unitOfWork.Quocgia.GetAll().ToList();
            model.DienViens = unitOfWork.Dienvien.GetAll().ToList();
            model.SelectedTheLoais = theloais.Split(',').ToList();
            model.SelectedQuocGias = quocgias.Split(',').ToList();

            if (model.SelectedTheLoais.Count == 1)
            {
                model.SelectedTheLoais = unitOfWork.Theloaiphim.GetAll().Select(x => x.id.ToString()).ToList();
            }
            if (model.SelectedQuocGias.Count == 1)
            {
                model.SelectedQuocGias = unitOfWork.Quocgia.GetAll().Select(x => x.id.ToString()).ToList();
            }
           
            

           model.Phims  = unitOfWork.Phim.SearchFor(
                x => (x.tenphim.Contains(phim) || x.phim_dienvien.Any(y => y.dienvien.tendienvien.Contains(phim)))
                && x.phim_theloaiphim.Any(y => model.SelectedTheLoais.Contains(y.theloaiphim.id.ToString()))
                && x.phim_quocgia.Any(y => model.SelectedQuocGias.Contains(y.quocgia.id.ToString()))
                ).OrderBy(x=>x.tenphim).ToPagedList(pageNumber, pageSize);

            model.SelectedTheLoais = theloais.Split(',').ToList();
            model.SelectedQuocGias = quocgias.Split(',').ToList();
            model.SearchString = phim;


            ViewBag.theloais = theloais;
            ViewBag.quocgias = quocgias;
            ViewBag.searching = phim;

            return View(model);
        }
	}
}
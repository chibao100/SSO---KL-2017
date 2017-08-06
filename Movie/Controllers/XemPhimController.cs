using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie.Models;
using Movie.ViewModel;
using System.IO;


namespace Movie.Controllers
{
    public class XemPhimController : Controller
    {
        //
        // GET: /XemPhim/
        public ActionResult IdPhim(int id, int? tap)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new movieEntities());
            phim a = unitOfWork.Phim.SearchFor(x => x.id == id).FirstOrDefault();
            WatchMovieViewModel viewModel = new WatchMovieViewModel();
            string url = string.Empty;

            viewModel.ID = a.id;
            viewModel.TenPhim = a.tenphim;
            viewModel.GioiThieu = a.gioithieuphim;
            viewModel.NgayCongChieu = a.ngaycongchieu;
            viewModel.DaoDien = a.daodien;
            viewModel.NamSanXuat = a.namsanxuat;
            viewModel.TheLoaiPhims = unitOfWork.Theloaiphim.GetAll().ToList();
            viewModel.QuocGias = unitOfWork.Quocgia.GetAll().ToList();
            viewModel.PhimItems = a.phimitems.OrderBy(x=>x.tap).ToList();

            if (tap == null)
            {
                viewModel.PhimItemSelected = 0;
                url = a.tenphim.Replace(' ', '-') + "/Tap-1";
               
            }
            else
            {
                viewModel.PhimItemSelected = viewModel.PhimItems.FindIndex(delegate(phimitem myPhimItem)
                {
                    return myPhimItem.tap.Equals(tap);
                });
                url = a.tenphim.Replace(' ', '-') + "/Tap-" + tap;
              
            }
            

           


            TempData["model"] = viewModel;

            
           

            return Redirect("/XemPhim/" + url);
        }

     

        public ActionResult Index(string name, string tap)
        {
            if (TempData["model"] == null)
            {
                string name2 = name.Replace('-', ' ');
                string[] tap2 = tap.Split('-');
                UnitOfWork unitOfWork = new UnitOfWork(new movieEntities());
                phim a = unitOfWork.Phim.SearchFor(x => x.tenphim == name2).FirstOrDefault();
                if (a == null)
                {
                    return Redirect("/timkiem");
                }
                else
                {
                    return Redirect("/Xemphim/IdPhim?id=" + a.id + "&tap=" + tap2[1]);
                }
            }
            WatchMovieViewModel viewModel = TempData["model"] as WatchMovieViewModel;

            return View(viewModel);
        } 

	}
}
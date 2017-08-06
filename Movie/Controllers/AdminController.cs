using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie.Models;
using Movie.ViewModel;
using System.IO;
using PagedList;
using OfficeOpenXml;
using Movie.Models.ObjectModel;

namespace Movie.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        //sasdasdasdadasdsaSAs
        public ActionResult Index()
        {
            string k = "test";
            return View();
        }

        public ActionResult AddMovie() 
        {
            movieEntities db = new movieEntities();
            UnitOfWork unitOfWork = new UnitOfWork(db);
            AddMovieViewModel viewModel = new AddMovieViewModel();

            viewModel.TheLoaiPhims = unitOfWork.Theloaiphim.GetAll().ToList();
            viewModel.QuocGias = unitOfWork.Quocgia.GetAll().ToList();
            viewModel.DienViens = unitOfWork.Dienvien.GetAll().ToList();
           
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddMovie(AddMovieViewModel movie)
        {
            movieEntities db = new movieEntities();
            UnitOfWork unitOfWork = new UnitOfWork(db);
            HttpPostedFileBase file = movie.UploadFiles[0];
            string fileName = Path.GetFileName(file.FileName);
            string path = Path.Combine(Server.MapPath("~/Uploads"), fileName);

            // insert phim entity
            phim newPhim = new phim
            {
                tenphim = movie.TenPhim,
                gioithieuphim = movie.GioiThieu,
                ngaycongchieu = movie.NgayCongChieu,
                daodien = movie.DaoDien,
                namsanxuat = movie.NamSanXuat,
                luotxem = 0,
                danhgiaphim = 0,
                tongsotap = movie.TongSoTap,
                anhbiaphim = fileName
            };
            unitOfWork.Phim.Insert(newPhim);
            
            // insert theloaiphim
            for (int i = 0; i < movie.SelectedTheLoais.Length; i++)
            {
                unitOfWork.PhimTheloaiphim.Insert(new phim_theloaiphim 
                { 
                    idphim = newPhim.id,
                    idtheloaiphim = movie.SelectedTheLoais[i]
                });
            }

            // insert quocgia
            for (int i = 0; i < movie.SelectedQuocGias.Length; i++)
            {
                unitOfWork.PhimQuocgia.Insert(new phim_quocgia
                {
                    idphim = newPhim.id,
                    idquocgia = movie.SelectedQuocGias[i]
                });
            }

            // insert dienvien
            for (int i = 0; i < movie.SelectedDienViens.Length; i++)
            {
                unitOfWork.PhimDienvien.Insert(new phim_dienvien
                {
                    idphim = newPhim.id,
                    iddienvien = movie.SelectedDienViens[i]
                });
            }

            file.SaveAs(path);
            unitOfWork.Save();

            return RedirectToAction("AddMovie");
        }


        public ActionResult MovieList(string SearchString, int? page)
        {
            movieEntities db = new movieEntities();
            UnitOfWork unitOfWork = new UnitOfWork(db);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            if (SearchString == null)
            {
                SearchString = "";
            }

            var movieList = unitOfWork.Phim.SearchFor(x=>x.tenphim.Contains(SearchString)).OrderBy(x =>x.tenphim);

            ViewBag.SearchString = SearchString;
            return View(movieList.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult EditMovie(int? id)
        {
            movieEntities db = new movieEntities();
            UnitOfWork unitOfWork = new UnitOfWork(db);
            phim a = unitOfWork.Phim.SearchFor(x => x.id == id).FirstOrDefault();
            EditMovieViewModel viewModel = new EditMovieViewModel();

            viewModel.ID = a.id;
            viewModel.TenPhim = a.tenphim;
            viewModel.GioiThieu = a.gioithieuphim;
            viewModel.NgayCongChieu = a.ngaycongchieu;
            viewModel.DaoDien = a.daodien;
            viewModel.NamSanXuat = a.namsanxuat;
            viewModel.TongSoTap = (a.tongsotap ?? 0);
            viewModel.TheLoaiPhims = unitOfWork.Theloaiphim.GetAll().ToList();
            viewModel.QuocGias = unitOfWork.Quocgia.GetAll().ToList();
            viewModel.DienViens = unitOfWork.Dienvien.GetAll().ToList();
            viewModel.UploadFiles = null;
            viewModel.SelectedTheLoais = a.phim_theloaiphim.Select(x => x.idtheloaiphim).ToList().ToArray();
            viewModel.SelectedQuocGias = a.phim_quocgia.Select(x => x.idquocgia).ToList().ToArray();
            viewModel.SelectedDienViens = a.phim_dienvien.Select(x => x.iddienvien).ToList().ToArray();
            viewModel.AnhBia = a.anhbiaphim;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditMovie(EditMovieViewModel movie)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new movieEntities());
            HttpPostedFileBase file = null;
            string fileName = "";
            string path = "";
            if(movie.UploadFiles[0] != null)
            {
                file = movie.UploadFiles[0];
                fileName = Path.GetFileName(file.FileName);
                path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
            }
            phim phim = unitOfWork.Phim.SearchFor(x => x.id == movie.ID).FirstOrDefault();
            List<phim_theloaiphim> theLoaiPhimList = phim.phim_theloaiphim.ToList();
            List<phim_quocgia> quocGiaList = phim.phim_quocgia.ToList();
            List<phim_dienvien> dienVienList = phim.phim_dienvien.ToList();

            if (phim != null)
            {
                // update phim entity
                phim.tenphim = movie.TenPhim;
                phim.gioithieuphim = movie.GioiThieu;
                phim.ngaycongchieu = movie.NgayCongChieu;
                phim.daodien = movie.DaoDien;
                phim.namsanxuat = movie.NamSanXuat;
                phim.tongsotap = movie.TongSoTap;
                if(file != null)
                {
                    phim.anhbiaphim = fileName;
                }

                //update theloaiphim entity
                for (int i = 0; i < theLoaiPhimList.Count; i++)
                {
                    unitOfWork.PhimTheloaiphim.Delete(theLoaiPhimList[i]);
                }
                for (int i = 0; i < movie.SelectedTheLoais.Length; i++)
                {
                    unitOfWork.PhimTheloaiphim.Insert(new phim_theloaiphim
                    {
                        idphim = movie.ID,
                        idtheloaiphim = movie.SelectedTheLoais[i]
                    });
                }

                // update quocgia entity
                for (int i = 0; i < quocGiaList.Count; i++)
                {
                    unitOfWork.PhimQuocgia.Delete(quocGiaList[i]);
                }
                for (int i = 0; i < movie.SelectedQuocGias.Length; i++)
                {
                    unitOfWork.PhimQuocgia.Insert(new phim_quocgia
                    {
                        idphim = movie.ID,
                        idquocgia = movie.SelectedQuocGias[i]
                    });
                }

                // update dienvien entity
                for (int i = 0; i < dienVienList.Count; i++)
                {
                    unitOfWork.PhimDienvien.Delete(dienVienList[i]);
                }
                for (int i = 0; i < movie.SelectedDienViens.Length; i++)
                {
                    unitOfWork.PhimDienvien.Insert(new phim_dienvien
                    {
                        idphim = movie.ID,
                        iddienvien = movie.SelectedDienViens[i]
                    });
                }

                if (file != null)
                {
                    file.SaveAs(path);
                }
                unitOfWork.Save();
            }

            return RedirectToAction("MovieList");
        }

        public ActionResult UploadMovie(int? id)
        {
            movieEntities db = new movieEntities();
            UnitOfWork unitOfWork = new UnitOfWork(db);
            phim a = unitOfWork.Phim.SearchFor(x => x.id == id).FirstOrDefault();
            List<phimitem> phimItemList = unitOfWork.Phimitem.SearchFor(x=>x.idphim==a.id).ToList();
            UploadMovieViewModel viewModel = new UploadMovieViewModel();

            viewModel.IdPhim = a.id;
            viewModel.TenPhim = a.tenphim;
            viewModel.TongSoTap = phimItemList.Count;
            if (phimItemList.Count > 0)
            {
                viewModel.TenTapPhimGanDayNhat = phimItemList[phimItemList.Count - 1].tentapphim;
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult UploadMovie(UploadMovieViewModel movieItem)
        {
            movieEntities db = new movieEntities();
            UnitOfWork unitOfWork = new UnitOfWork(db);
            unitOfWork.Phimitem.Insert(new phimitem
            {
                idphim = movieItem.IdPhim,
                tap = movieItem.TongSoTap + 1,
                tentapphim = movieItem.TenTapPhim,
                link = movieItem.Link
            });

            unitOfWork.Save();


            return RedirectToAction("MovieList");
        }


        [HttpPost]
        public ActionResult ImportPhimItem()
        {
            UnitOfWork unitOfWork = new UnitOfWork(new movieEntities());
            HttpPostedFileBase file = Request.Files["myFile"];
            int id = Int32.Parse(Request.Form["id"].ToString());
            List<ImportPhimItem> list = new List<ImportPhimItem>();
            List<phimitem> phimitemList = unitOfWork.Phimitem.SearchFor(x => x.idphim == id).ToList();

            using (var package = new ExcelPackage(file.InputStream))
            {
                // get the first worksheet in the workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                int col = 1;
                for (int row = 2; worksheet.Cells[row, col].Value != null; row++)
                {
                    // do something with worksheet.Cells[row, col].Value        
                    ImportPhimItem a = new ImportPhimItem();
                    a.STT = Int32.Parse(worksheet.Cells[row, col].Value.ToString());
                    a.Ten = worksheet.Cells[row, col + 1].Value.ToString();
                    a.Link = worksheet.Cells[row, col + 2].Value.ToString();
                    a.LinkDowload = worksheet.Cells[row, col + 3].Value.ToString();
                    list.Add(a);
                }
            } // the using
            
            // sapxep
            list = list.OrderBy(x => x.STT).ToList();

            //delete phimitem
            for (int i = 0; i < phimitemList.Count; i++)
            {
                unitOfWork.Phimitem.Delete(phimitemList[i]);
            }

            //insert new phimitem
            for (int i = 0; i < list.Count; i++)
            {
                unitOfWork.Phimitem.Insert(new phimitem
                {
                    idphim = id,
                    tap = list[i].STT,
                    link = list[i].Link,
                    tentapphim = list[i].Ten,
                    linkdowload = list[i].LinkDowload
                });
            }

            //save
            unitOfWork.Save();

            return Redirect("/Admin/MovieList");
        }


        [HttpGet]
        public ActionResult DeleteMovie(int? id)
        {
            movieEntities db = new movieEntities();
            UnitOfWork unitOfWork = new UnitOfWork(db);
            phim phim = unitOfWork.Phim.SearchFor(x => x.id == id).FirstOrDefault();
            List<phim_theloaiphim> theLoaiPhimList = phim.phim_theloaiphim.ToList();
            List<phim_quocgia> quocGiaList = phim.phim_quocgia.ToList();
            List<phim_dienvien> dienVienList = phim.phim_dienvien.ToList();
            List<phimitem> phimItemList = phim.phimitems.ToList();


            // delete phim entity
            unitOfWork.Phim.Delete(phim);

            // delete theloaiphim entity
            for (int i = 0; i < theLoaiPhimList.Count; i++)
            {
                unitOfWork.PhimTheloaiphim.Delete(theLoaiPhimList[i]);
            }

            // delete quocgia entity
            for (int i = 0; i < quocGiaList.Count; i++)
            {
                unitOfWork.PhimQuocgia.Delete(quocGiaList[i]);
            }

            // delete dienvien entity
            for (int i = 0; i < dienVienList.Count; i++)
            {
                unitOfWork.PhimDienvien.Delete(dienVienList[i]);
            }

            // delete itemphim entity
            for (int i = 0; i < phimItemList.Count; i++)
            {
                unitOfWork.Phimitem.Delete(phimItemList[i]);
            }

            // save
            unitOfWork.Save();

            return RedirectToAction("MovieList");
        }


	}
}
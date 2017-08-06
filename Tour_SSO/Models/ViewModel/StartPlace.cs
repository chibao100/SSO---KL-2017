using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tour_SSO.Models.ViewModel
{
    public static class StartPlace
    {
        public static List<string> Place()
        {
            List<string> StartPlace = new List<string>();

            StartPlace.Add("Hồ Chí Minh");
            StartPlace.Add("Hà Nội");
            StartPlace.Add("Đà Nẵng");
            StartPlace.Add("Cần Thơ");
            StartPlace.Add("Hải Phòng");
            StartPlace.Add("Bình Dương");
            StartPlace.Add("Nha Trang");
            StartPlace.Add("Huế");
            StartPlace.Add("Quy Nhơn");
            StartPlace.Add("Quảng Ngãi");
            StartPlace.Add("Đồng Nai");
            StartPlace.Add("Quảng Ninh");
            StartPlace.Add("Đà Lạt");
            StartPlace.Add("Thanh Hóa");
            StartPlace.Add("Cà Mau");

            return StartPlace;
        }

        public static List<string> FindCountry(string Type = "1") {
            UnitOfWork _unitOfWork = new UnitOfWork(new TourEntities());
            List<string> Arrivel = new List<string>();
            if(Type == "1")
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
            
            return Arrivel;
        }

    }
}
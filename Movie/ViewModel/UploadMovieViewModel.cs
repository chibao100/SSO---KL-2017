using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie.ViewModel
{
    public class UploadMovieViewModel
    {
        private int _idPhim;
        private string _tenPhim;
        private string _tenTapPhim;
        private string _link;
        private int _tongSoTap;
        private string _tenTapPhimGanDayNhat;




        public UploadMovieViewModel()
        {
            IdPhim = 0;
            TenTapPhim = string.Empty;
            Link = string.Empty;
            TongSoTap = 0;
            TenTapPhimGanDayNhat = string.Empty;
        }

        public int IdPhim
        {
            get
            {
                return _idPhim;
            }
            set
            {
                _idPhim = value;
            }
        }

        public string TenPhim
        {
            get
            {
                return _tenPhim;
            }
            set
            {
                if (value == null || value == string.Empty)
                {
                    _tenPhim = "";
                }
                else
                {
                    _tenPhim = value;
                }
            }
        }

        public string TenTapPhim
        {
            get
            {
                return _tenTapPhim;
            }
            set
            {
                if (value == null || value == string.Empty)
                {
                    _tenTapPhim = "";
                }
                else
                {
                    _tenTapPhim = value;
                }
            }
        }

        public string Link
        {
            get
            {
                return _link;
            }
            set
            {
                if (value == null || value == string.Empty)
                {
                    _link = "";
                }
                else
                {
                    _link = value;
                }
            }
        }

        public int TongSoTap
        {
            get
            {
                return _tongSoTap;
            }
            set
            {
                _tongSoTap = value;
            }
        }

       


        public string TenTapPhimGanDayNhat
        {
            get
            {
                return _tenTapPhimGanDayNhat;
            }
            set
            {
                if (value == null || value == string.Empty)
                {
                    _tenTapPhimGanDayNhat = "";
                }
                else
                {
                    _tenTapPhimGanDayNhat = value;
                }
            }
        }

        

        
       
    }
}
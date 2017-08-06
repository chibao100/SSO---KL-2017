using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movie.Models;

namespace Movie.ViewModel
{
    public class WatchMovieViewModel
    {
        private int _id;
        private string _tenPhim;
        private string _gioiThieu;
        private DateTime _ngayCongChieu;
        private string _daoDien;
        private int _namSanXuat;
        private List<phimitem> _phimItems;
        private List<theloaiphim> _theLoaiPhims;
        private List<quocgia> _quocGias;
        private int _phimItemSelected;


        public WatchMovieViewModel()
        {
            ID = -1;
            TenPhim = string.Empty;
            GioiThieu = string.Empty;
            NgayCongChieu = DateTime.Now;
            DaoDien = string.Empty;
            NamSanXuat = 0;
            PhimItems = null;
        }

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
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

        public string GioiThieu
        {
            get
            {
                return _gioiThieu;
            }
            set
            {
                if (value == null || value == string.Empty)
                {
                    _gioiThieu = "";
                }
                else
                {
                    _gioiThieu = value;
                }
            }
        }

        public DateTime NgayCongChieu
        {
            get
            {
                return _ngayCongChieu;
            }
            set
            {
                if (value == null)
                {
                    _ngayCongChieu = DateTime.Now;
                }
                else
                {
                    _ngayCongChieu = value;
                }
            }
        }

        public string DaoDien
        {
            get
            {
                return _daoDien;
            }
            set
            {
                if (value == null || value == string.Empty)
                {
                    _daoDien = "";
                }
                else
                {
                    _daoDien = value;
                }
            }
        }

        public int NamSanXuat
        {
            get
            {
                return _namSanXuat;
            }
            set
            {
                _namSanXuat = value;
            }
        }

        public List<phimitem> PhimItems
        {
            get
            {
                return _phimItems;
            }
            set
            {
                if (value == null)
                {
                    _phimItems = new List<phimitem>();
                }
                else
                {
                    _phimItems = value;
                }
            }
        }


        public List<theloaiphim> TheLoaiPhims
        {
            get
            {
                return _theLoaiPhims;
            }
            set
            {
                if (value == null)
                {
                    _theLoaiPhims = new List<theloaiphim>();
                }
                else
                {
                    _theLoaiPhims = value;
                }
            }
        }


        public List<quocgia> QuocGias
        {
            get
            {
                return _quocGias;
            }
            set
            {
                if (value == null)
                {
                    _quocGias = new List<quocgia>();
                }
                else
                {
                    _quocGias = value;
                }
            }
        }

        public int PhimItemSelected
        {
            get
            {
                return _phimItemSelected;
            }
            set
            {
                _phimItemSelected = value;
            }
        }
    }
}
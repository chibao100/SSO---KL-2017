using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movie.Models;

namespace Movie.ViewModel
{
    public class EditMovieViewModel
    {
        private string _tenPhim;
        private string _gioiThieu;
        private DateTime _ngayCongChieu;
        private string _daoDien;
        private int _namSanXuat;
        private int _tongSoTap;
        private string _anhBia;
        private int _id;
        private List<theloaiphim> _theLoaiPhims;
        private List<quocgia> _quocGias;
        private List<dienvien> _dienViens;
        private List<HttpPostedFileBase> _uploadFiles;
        private int[] _selectedTheLoais;
        private int[] _selectedQuocGias;
        private int[] _selectedDienViens;



        public EditMovieViewModel()
        {
            TenPhim = string.Empty;
            GioiThieu = string.Empty;
            NgayCongChieu = DateTime.Now;
            DaoDien = string.Empty;
            NamSanXuat = 0;
            TheLoaiPhims = null;
            QuocGias = null;
            DienViens = null;
            UploadFiles = null;
            SelectedTheLoais = null;
            SelectedQuocGias = null;
            SelectedDienViens = null;
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
                    _daoDien ="";
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

        public string AnhBia
        {
            get
            {
                return _anhBia;
            }
            set
            {

                if (value == null || value == string.Empty)
                {
                    _anhBia = "";
                }
                else
                {
                    _anhBia = value;
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

        public List<dienvien> DienViens
        {
            get
            {
                return _dienViens;
            }
            set
            {
                if (value == null)
                {
                    _dienViens = new List<dienvien>();
                }
                else
                {
                    _dienViens = value;
                }
            }
        }

        public List<HttpPostedFileBase> UploadFiles
        {
            get
            {
                return _uploadFiles;
            }
            set
            {
                _uploadFiles = value;
            }
        }

        public int[] SelectedTheLoais 
        {
            get 
            {
                if (_selectedTheLoais == null)
                {
                    _selectedTheLoais = new int[0];
                }
                return _selectedTheLoais;
            }
            set
            {
                if (value == null)
                {
                    _selectedTheLoais = new int[0];
                }
                else
                {
                    _selectedTheLoais = value;
                }
            }
        }
        public int[] SelectedQuocGias
        {
            get
            {
                if (_selectedQuocGias == null)
                {
                    _selectedQuocGias = new int[0];
                }
                return _selectedQuocGias;
            }
            set
            {
                if (value == null)
                {
                    _selectedQuocGias = new int[0];
                }
                else
                {
                    _selectedQuocGias = value;
                }
            }
        }
        public int[] SelectedDienViens 
        {
            get
            {
                if (_selectedDienViens == null)
                {
                    _selectedDienViens = new int[0];
                }
                return _selectedDienViens;
            }
            set
            {
                if (value == null)
                {
                    _selectedDienViens = new int[0];
                }
                else
                {
                    _selectedDienViens = value;
                }
            }
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
    }
}
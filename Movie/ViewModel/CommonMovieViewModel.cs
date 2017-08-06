using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movie.Models;
using System.IO;
using PagedList;

namespace Movie.ViewModel
{
    public class CommonMovieViewModel
    {
       
        private List<theloaiphim> _theLoaiPhims;
        private List<quocgia> _quocGias;
        private List<dienvien> _dienViens;
        private IPagedList<phim> _phims;
        private List<string> _selectedTheLoais;
        private List<string> _selectedQuocGias;
        private string _searchString;


        public CommonMovieViewModel()
        {
            TheLoaiPhims = null;
            QuocGias = null;
            DienViens = null;
            SelectedTheLoais = null;
            SelectedQuocGias = null;
            SearchString = null;
        }

        public string SearchString
        {
            get
            {
                return _searchString;
            }
            set
            {
                if (value == null || value == string.Empty)
                {
                    _searchString = "";
                }
                else
                {
                    _searchString = value;
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

        public IPagedList<phim> Phims
        {
            get
            {
                return _phims;
            }
            set
            {
                _phims = value;
            }
        }

        public List<string> SelectedTheLoais 
        {
            get 
            {
                if (_selectedTheLoais == null)
                {
                    _selectedTheLoais = new List<string>();
                }
                return _selectedTheLoais;
            }
            set
            {
                if (value == null)
                {
                    _selectedTheLoais = new List<string>();
                }
                else
                {
                    _selectedTheLoais = value;
                }
            }
        }
        public List<string> SelectedQuocGias
        {
            get
            {
                if (_selectedQuocGias == null)
                {
                    _selectedQuocGias = new List<string>();
                }
                return _selectedQuocGias;
            }
            set
            {
                if (value == null)
                {
                    _selectedQuocGias = new List<string>();
                }
                else
                {
                    _selectedQuocGias = value;
                }
            }
        }

      
    }
}
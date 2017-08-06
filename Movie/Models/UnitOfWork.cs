using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movie.Models;
using Movie.Models.Repositories;

namespace Movie.Models
{
    public class UnitOfWork
    {
        private DienvienRepository _dienvien;
        private NguoidungRepository _nguoidung;
        private PhimRepository _phim;
        private Phim_DienvienRepository _phimdienvien;
        private Phim_QuocgiaRepository _phimquocgia;
        private Phim_TheloaiphimRepository _phimtheloaiphim;
        private PhimitemRepository _phimitem;
        private QuocgiaRepository _quocgia;
        private TheloaiphimRepository _theloaiphim;

        private movieEntities _db;

        public UnitOfWork(movieEntities db)
        {
            _db = db;
        }

        public DienvienRepository Dienvien
        {
            get
            {
                if (_dienvien == null)
                {
                    _dienvien = new DienvienRepository(_db);
                }
                return _dienvien;
            }
        }

        public NguoidungRepository Nguoidung
        {
            get
            {
                if (_nguoidung == null)
                {
                    _nguoidung = new NguoidungRepository(_db);
                }
                return _nguoidung;
            }
        }

        public PhimRepository Phim
        {
            get
            {
                if (_phim == null)
                {
                    _phim = new PhimRepository(_db);
                }
                return _phim;
            }
        }

        public Phim_DienvienRepository PhimDienvien
        {
            get
            {
                if (_phimdienvien == null)
                {
                    _phimdienvien = new Phim_DienvienRepository(_db);
                }
                return _phimdienvien;
            }
        }

        public Phim_QuocgiaRepository PhimQuocgia
        {
            get
            {
                if (_phimquocgia == null)
                {
                    _phimquocgia = new Phim_QuocgiaRepository(_db);
                }
                return _phimquocgia;
            }
        }

        public Phim_TheloaiphimRepository PhimTheloaiphim
        {
            get
            {
                if (_phimtheloaiphim == null)
                {
                    _phimtheloaiphim = new Phim_TheloaiphimRepository(_db);
                }
                return _phimtheloaiphim;
            }
        }

        public PhimitemRepository Phimitem
        {
            get
            {
                if (_phimitem == null)
                {
                    _phimitem = new PhimitemRepository(_db);
                }
                return _phimitem;
            }
        }

        public QuocgiaRepository Quocgia
        {
            get
            {
                if (_quocgia == null)
                {
                    _quocgia = new QuocgiaRepository(_db);
                }
                return _quocgia;
            }
        }

        public TheloaiphimRepository Theloaiphim
        {
            get
            {
                if (_theloaiphim == null)
                {
                    _theloaiphim = new TheloaiphimRepository(_db);
                }
                return _theloaiphim;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
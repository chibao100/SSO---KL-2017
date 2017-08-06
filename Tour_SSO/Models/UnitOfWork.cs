using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tour_SSO.Models.Repositories;
using Tour_SSO.Models;

namespace Tour_SSO.Models
{
    public class UnitOfWork
    {
        private AreaRepository _area;
        private ContactRepository _contact;
        private CountryRepository _country;
        private CustomerRepository _customer;
        private DetailOfTourOrderRepository _detailOfTourOrder;
        private ForeignAreaRepository _foreignArea;
        private GallaryRepository _gallary;
        private MemberRepository _member;
        private TourRepository _tour;
        private TourDetailRepository _tourDetail;
        private TourGallaryRepository _tourGallary;
        private TourOrderRepository _tourOrder;
        private TourPlaceRepository _tourPlace;
        private TourPlaceGallaryRepository _tourPlaceGallary;

        private TourEntities _db;

        public UnitOfWork(TourEntities db)
        {
            _db = db;
        }

        public AreaRepository AreaRepo
        {
            get
            {
                if (_area == null)
                {
                    _area = new AreaRepository(_db);
                }
                return _area;
            }
        }

        public ContactRepository ContactRepo
        {
            get
            {
                if (_contact == null)
                {
                    _contact = new ContactRepository(_db);
                }
                return _contact;
            }
        }

        public CountryRepository CountryRepo
        {
            get
            {
                if (_country == null)
                {
                    _country = new CountryRepository(_db);
                }
                return _country;
            }
        }

        public CustomerRepository CustomerRepo
        {
            get
            {
                if (_customer == null)
                {
                    _customer = new CustomerRepository(_db);
                }
                return _customer;
            }
        }

        public DetailOfTourOrderRepository DetailOfTourOrderRepo
        {
            get
            {
                if (_detailOfTourOrder == null)
                {
                    _detailOfTourOrder = new DetailOfTourOrderRepository(_db);
                }
                return _detailOfTourOrder;
            }
        }

        public ForeignAreaRepository ForeignAreaRepo
        {
            get
            {
                if (_foreignArea == null)
                {
                    _foreignArea = new ForeignAreaRepository(_db);
                }
                return _foreignArea;
            }
        }

        public GallaryRepository GallaryRepo
        {
            get
            {
                if (_gallary == null)
                {
                    _gallary = new GallaryRepository(_db);
                }
                return _gallary;
            }
        }

        public MemberRepository MemberRepo
        {
            get
            {
                if (_member == null)
                {
                    _member = new MemberRepository(_db);
                }
                return _member;
            }
        }

        public TourRepository TourRepo
        {
            get
            {
                if (_tour == null)
                {
                    _tour = new TourRepository(_db);
                }
                return _tour;
            }
        }


        public TourDetailRepository TourDetailRepo
        {
            get
            {
                if (_tourDetail == null)
                {
                    _tourDetail = new TourDetailRepository(_db);
                }
                return _tourDetail;
            }
        }

        public TourGallaryRepository TourGallaryRepo
        {
            get
            {
                if (_tourGallary == null)
                {
                    _tourGallary = new TourGallaryRepository(_db);
                }
                return _tourGallary;
            }
        }

        public TourOrderRepository TourOrderRepo
        {
            get
            {
                if (_tourOrder == null)
                {
                    _tourOrder = new TourOrderRepository(_db);
                }
                return _tourOrder;
            }
        }

        public TourPlaceRepository TourPlaceRepo
        {
            get
            {
                if (_tourPlace == null)
                {
                    _tourPlace = new TourPlaceRepository(_db);
                }
                return _tourPlace;
            }
        }

        public TourPlaceGallaryRepository TourPlaceGallaryRepo
        {
            get
            {
                if (_tourPlaceGallary == null)
                {
                    _tourPlaceGallary = new TourPlaceGallaryRepository(_db);
                }
                return _tourPlaceGallary;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
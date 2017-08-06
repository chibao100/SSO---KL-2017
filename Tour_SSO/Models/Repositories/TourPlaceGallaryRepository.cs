using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tour_SSO.Models.Repositories
{
    public class TourPlaceGallaryRepository : Repository<TourPlaceGallary>
    {
        public TourPlaceGallaryRepository(DbContext dataContext) : base(dataContext) {

        }
    }
}
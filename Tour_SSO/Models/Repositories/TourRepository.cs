using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tour_SSO.Models.Repositories
{
    public class TourRepository : Repository<Tour>
    {
        public TourRepository(DbContext dataContext) : base(dataContext) {

        }

        public void Edit(Tour model)
        {
            //Tour a = DbSet.Where(x => x.TourId == model.TourId).FirstOrDefault();
            
        }
    }
}
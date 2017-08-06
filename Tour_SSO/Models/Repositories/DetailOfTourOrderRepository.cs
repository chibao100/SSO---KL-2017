using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tour_SSO.Models.Repositories
{
    public class DetailOfTourOrderRepository : Repository<DetailOfTourOrder>
    {
        public DetailOfTourOrderRepository(DbContext dataContext) : base(dataContext) {

        }
    }
}
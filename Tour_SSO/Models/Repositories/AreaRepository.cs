using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Tour_SSO.Models;

namespace Tour_SSO.Models.Repositories
{
    public class AreaRepository : Repository<Area>
    {
        public AreaRepository(DbContext dataContext) : base(dataContext) {

        }
    }
}
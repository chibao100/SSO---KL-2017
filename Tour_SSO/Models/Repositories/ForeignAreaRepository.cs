using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tour_SSO.Models.Repositories
{
    public class ForeignAreaRepository : Repository<ForeignArea>
    {
        public ForeignAreaRepository(DbContext dataContext) : base(dataContext) {

        }
    }
}
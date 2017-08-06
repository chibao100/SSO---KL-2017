using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Movie.Models.Repositories
{
    public class NguoidungRepository:Repository<nguoidung>
    {
        public NguoidungRepository(DbContext dataContext): base(dataContext)
        {

        }
    }
}
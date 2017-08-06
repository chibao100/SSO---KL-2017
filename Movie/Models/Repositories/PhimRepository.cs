using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Movie.Models.Repositories
{
    public class PhimRepository:Repository<phim>
    {
        public PhimRepository(DbContext dataContext): base(dataContext)
        {

        }

       

    }
}
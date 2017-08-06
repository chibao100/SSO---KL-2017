using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Movie.Models.Repositories
{
    public class PhimitemRepository:Repository<phimitem>
    {
        public PhimitemRepository(DbContext dataContext): base(dataContext)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Movie.Models.Repositories
{
    public class Phim_DienvienRepository:Repository<phim_dienvien>
    {
        public Phim_DienvienRepository(DbContext dataContext): base(dataContext)
        {

        }
    }
}
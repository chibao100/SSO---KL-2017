using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Movie.Models.Repositories
{
    public class Phim_QuocgiaRepository:Repository<phim_quocgia>
    {
        public Phim_QuocgiaRepository(DbContext dataContext): base(dataContext)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Movie.Models.Repositories
{
    public class QuocgiaRepository:Repository<quocgia>
    {
        public QuocgiaRepository(DbContext dataContext): base(dataContext)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Movie.Models.Repositories
{
    public class Phim_TheloaiphimRepository:Repository<phim_theloaiphim>
    {
        public Phim_TheloaiphimRepository(DbContext dataContext): base(dataContext)
        {

        }

       

        
    }
}
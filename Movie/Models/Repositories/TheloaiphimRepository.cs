using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Movie.Models;

namespace Movie.Models.Repositories
{
    public class TheloaiphimRepository:Repository<theloaiphim>
    {
        
        public TheloaiphimRepository(DbContext dataContext): base(dataContext)
        {

        }

       
    }
}
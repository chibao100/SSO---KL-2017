using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Movie.Models.Repositories
{
    public class DienvienRepository: Repository<dienvien>
    {
        public DienvienRepository(DbContext dataContext): base(dataContext)
        {

        }
    }
}
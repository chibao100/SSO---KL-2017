using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tour_SSO.Models.Repositories
{
    public class CountryRepository : Repository<Country>
    {

        public CountryRepository(DbContext dataContext) : base(dataContext) {

        }

    }
}
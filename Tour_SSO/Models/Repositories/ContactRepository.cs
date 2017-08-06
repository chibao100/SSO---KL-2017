using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Tour_SSO.Models.Repositories
{
    public class ContactRepository : Repository<Contact>
    {
        public ContactRepository(DbContext dataContext) : base(dataContext) {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tour_SSO.Models.Repositories
{
    public class MemberRepository : Repository<Member>
    {

        public MemberRepository(DbContext dataContext) : base(dataContext) {

        }

    }
}
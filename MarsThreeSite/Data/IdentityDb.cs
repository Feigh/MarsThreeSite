using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MarsThreeSite.Data
{
    public class IdentityDb : IdentityDbContext
    {
        public IdentityDb(DbContextOptions<IdentityDb> options)
            : base(options)
        {
        }
    }
}

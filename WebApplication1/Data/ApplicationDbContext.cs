using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Coach> Coach { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<ScheduleMembers> ScheduleMembers { get; set; }

    }
}

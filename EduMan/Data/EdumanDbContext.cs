using System;
using System.Collections.Generic;
using System.Text;
using Eduman.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Eduman.Data
{
    public class EdumanDbContext : IdentityDbContext<EdumanUser>
    {
        public EdumanDbContext(DbContextOptions<EdumanDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Event> Events { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<Absence> Absences { get; set; }

        public DbSet<Reflection> Reflections { get; set; }

        public DbSet<Fee> Fees { get; set; }
    }
}

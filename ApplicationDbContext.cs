using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Jurassic.Park.Data;

namespace Jurassic.Park.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Jurassic.Park.Data.Dinosaurs> Dinosaurs { get; set; }
        public DbSet<Jurassic.Park.Data.Exibits> Exibits { get; set; }
    }
}

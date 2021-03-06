﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using eshopper.Models;

namespace eshopper.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<eshopper.Models.Product> Product { get; set; }
        public DbSet<eshopper.Models.HomeProducts> HomeProducts { get; set; }
    }
}

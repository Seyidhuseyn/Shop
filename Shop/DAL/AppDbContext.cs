﻿using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }

}

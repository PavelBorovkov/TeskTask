﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain;
using TestTask.Application.Interfaces;
using TestTask.Persistance.EntityTypeConfigurations;

namespace TestTask.Persistance
{
    public class TestTaskDbContext : DbContext, ITestTaskDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Coin> Coins { get; set; }
        public TestTaskDbContext(DbContextOptions<TestTaskDbContext> options)
           : base(options){ }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new CoinConfiguration());
            base.OnModelCreating(builder);
        }
    }
}

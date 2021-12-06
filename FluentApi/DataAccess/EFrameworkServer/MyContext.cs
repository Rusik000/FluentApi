using FluentApi.Domain.Entities;
using FluentApi.Domain.Entities.Mapping;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
namespace FluentApi.DataAccess.EFrameworkServer
{
    public class MyContext:DbContext
    {
        public MyContext():base("StoreDb")
        {
            //if your db in other location
            //this.Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new OrderMap());

            modelBuilder.Entity<Order>()
                .HasOptional<Customer>(s => s.Customer)
                .WithMany()
                .WillCascadeOnDelete();
        }
    }
}

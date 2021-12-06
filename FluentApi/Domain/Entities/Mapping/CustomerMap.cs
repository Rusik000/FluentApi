using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi.Domain.Entities.Mapping
{
   public class CustomerMap:EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            this.HasKey(c => c.Id);

            this.Property(c => c.CompanyName)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(true);

            this.Property(c => c.City)
                .HasMaxLength(15);


            this.Property(c => c.ContactName)
                .HasMaxLength(30);

            this.ToTable("Customers");

            this.Property(t => t.Id).HasColumnName("Id");

            this.Property(t => t.Country)
                .HasColumnName("Country");

            this.Property(t => t.ContactName)
                .HasColumnName("ContactName");

            this.Property(t => t.ContactName)
                .HasColumnAnnotation(
                IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("IX_ContactName", 2) { IsUnique = true }));

            this.HasMany(c => c.Orders)
                .WithOptional()
                .HasForeignKey(o => o.CustomerId)
                .WillCascadeOnDelete(true);

        }
    }
}

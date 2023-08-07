using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleAssignment.Domain.Entities;

namespace SampleAssignment.Infrastructure.EntityConfigurations
{
    internal class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.OwnsOne(o => o.Address, a =>
            {
                a.Property(address => address.Country)
                                 .HasColumnName("Country");
                a.Property(address => address.City)
                                 .HasColumnName("City");
                a.Property(address => address.AddressLine1)
                                 .HasColumnName("AddressLine1");
                a.Property(address => address.AddressLine2)
                                 .HasColumnName("AddressLine2");
                a.Property(address => address.State)
                                 .HasColumnName("State");
                a.Property(address => address.PostalCode)
                                 .HasColumnName("PostalCode");
            });
        }
    }
}

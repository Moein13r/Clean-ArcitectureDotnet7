using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Dot7.Architecture.Domain.Entities;

namespace Dot7.Architecture.Infrastructure.Context.Configuration
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasIndex(c => new { c.FirstName, c.LastName, c.DateOfBirth })
                .IsUnique();
            builder
                .HasIndex(c => c.Email)
                .IsUnique();
        }
    }
}

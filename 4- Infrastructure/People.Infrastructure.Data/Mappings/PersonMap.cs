using People.Domain.Models;
using People.Infrastructure.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace People.Infrastructure.Data.Mappings
{
    public class PersonMap : EntityTypeConfiguration<PersonModel>
    {
        public override void Map(EntityTypeBuilder<PersonModel> builder)
        {
            builder.Property(c => c.ID)
                .HasColumnName("ID");

            builder.Property(c => c.FirstName)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(c => c.LastName)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(c => c.Gender)
                .HasMaxLength(10);

            builder.Property(c => c.Age)
                .HasMaxLength(3);
        }
    }
}

﻿using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Pesistence.Constrants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Pesistence.Configuarations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(TableNames.Product);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(250).IsRequired(true);
        }
    }
}

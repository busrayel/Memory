﻿using Memory.Core.Map;
using Memory.Entites.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Core.Mappings
{
    public class CityMap : CoreMap<City>
    {
        public override void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(30);
            builder.HasMany(x => x.Notebooks).WithOne(x => x.City).HasForeignKey(x => x.CityId);
            base.Configure(builder);
        }
    }
}

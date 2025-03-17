using HS_14_MVC.Domain.Core.BaseEntityConfigurations;
using HS_14_MVC.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Infrastructure.Configurations
{
    public class CategoryConfiguration : AudiTableEntityConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(128);
            base.Configure(builder);
        }
    }
}

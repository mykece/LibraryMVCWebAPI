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
    public class BookConfiguration :AudiTableEntityConfiguration<Book>
    {
        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(b => b.Name).IsRequired().HasMaxLength(128);
            builder.Property(b => b.DateOfPublish).IsRequired();
            builder.Property(b => b.IsAvailable).IsRequired();
            base.Configure(builder);
        }
    }
}

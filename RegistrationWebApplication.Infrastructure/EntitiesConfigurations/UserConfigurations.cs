using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegistrationWebApplication.Core.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationWebApplication.Infrastructure.EntitiesMapper
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users","dbo").HasKey(t => t.Id).HasName("Id");
            builder.Property(x => x.Name).HasMaxLength(30).HasColumnName("Name");
            builder.Property(x => x.Age).HasColumnName("Age");
            builder.HasIndex(x => x.Id).IsUnique();
        }
    }
}

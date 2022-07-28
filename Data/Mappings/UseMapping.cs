using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class UseMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Ativo).HasColumnName(nameof(User.Ativo)).IsRequired();
            builder.Property(d => d.Name).HasColumnName(nameof(User.Name)).IsRequired();
            builder.Property(d => d.Login).HasColumnName(nameof(User.Login)).IsRequired();
            builder.Property(d => d.Password).HasColumnName(nameof(User.Password)).IsRequired();
        }
    }
}

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
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Ativo).HasColumnName(nameof(Book.Ativo)).IsRequired();
            builder.Property(d => d.Name).HasColumnName(nameof(Book.Name)).IsRequired();
            builder.Property(d => d.Author).HasColumnName(nameof(Book.Author)).IsRequired();
            builder.Property(d => d.Synopsis).HasColumnName(nameof(Book.Synopsis)).IsRequired();
            builder.Property(d => d.ReleaseData).HasColumnName(nameof(Book.ReleaseData)).IsRequired();
            builder.Property(d => d.Status).HasColumnName(nameof(Book.Status)).IsRequired();

        }
    }
}

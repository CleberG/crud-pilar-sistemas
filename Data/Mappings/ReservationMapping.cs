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
    public class ReservationMapping : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Ativo);
            builder.Property(d => d.WithDrawalDate);
            builder.Property(d => d.Price).HasColumnName(nameof(Reservation.Price)).IsRequired();
            builder.HasOne(d => d.Book).WithMany(d => d.Reservations).HasForeignKey(d => d.BookId).OnDelete(DeleteBehavior.Restrict); 
        }
    }
}

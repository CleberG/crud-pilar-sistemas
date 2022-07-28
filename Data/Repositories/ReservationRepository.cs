using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(MainContext dbContext) : base(dbContext)
        {

        }

        public async Task <List<Reservation>> GetByUserId(Guid id)
        {
            return await _dbContext.Set<Reservation>()
                .AsNoTracking()
                .Where(r => r.UserId == id)
                .Include(d => d.User)
                .Include(x => x.Book)
                .ToListAsync();
        }
    }
}

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
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public readonly MainContext _dbContext;

        public GenericRepository(MainContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var entity = await GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _dbContext.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Update(Guid id, TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Task<bool> CheckExistence(Guid id)
        {
            return _dbContext.Set<TEntity>().AnyAsync(entity => entity.Id == id);
        }

        public async Task InsertRecordList(IList<TEntity> entity)
        {
            _dbContext.Set<TEntity>().AddRange(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRecordList(IList<TEntity> entity)
        {
            _dbContext.Set<TEntity>().UpdateRange(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}

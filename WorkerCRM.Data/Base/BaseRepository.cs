using Microsoft.EntityFrameworkCore;
using WorkerCRM.Data.Contract.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerCRM.Models.Interfaces;

namespace WorkerCRM.Data.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly PlanersDbContext _dbContext;

        public BaseRepository(PlanersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>()
                .AsNoTracking();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetByIds(IEnumerable<int> ids)
        {
            return await _dbContext.Set<TEntity>()
                .AsNoTracking()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();
        }

        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().AddRange(entities);
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }

        public IQueryable<TEntity> Query()
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

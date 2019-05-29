using Core.Database.Stores.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Database.Stores
{
    public abstract class AbstractEntityFrameworkStore<TEntity> : IStore<TEntity> where TEntity : class, new()
    {
        private readonly ApiDbContext dbContext;
        private readonly ILogger logger;

        protected DbSet<TEntity> DbSet => dbContext.Set<TEntity>();

        protected AbstractEntityFrameworkStore(ApiDbContext context, ILoggerFactory loggerFactory)
        {
            dbContext = context;
            logger = loggerFactory.CreateLogger(GetType());
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            DbSet.Add(entity);

            try
            {
                await this.dbContext.SaveChangesAsync();

            }
            catch (DbUpdateException ex)
            {
                logger.LogInformation($"An exception occurred. Error message: {ex.Message} Stacktrace: {ex.StackTrace}");
            }

            return entity;

        }

        public virtual async Task<TEntity> FindEntityAsync(Func<TEntity, bool> predicate)
        {
            var item = DbSet.Where(predicate).FirstOrDefault();

            return await Task.FromResult(item);
        }
    }
}

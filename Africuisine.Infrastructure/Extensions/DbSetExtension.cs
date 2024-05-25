using Africuisine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Africuisine.Infrastructure.Extensions
{
    public static class DbsetExtension
    {
        public static EntityEntry<TEntity> Upsert<TEntity, TContext>(this DbSet<TEntity> set, TEntity entity)
            where TEntity : BaseEntity
            where TContext: DbContext
        {
            EntityEntry<TEntity> entry;
            var context = GetContext<TEntity, TContext>(set);
            var existing = GetEntityById<TEntity>(context, entity.Id);
            if (existing is null)
            {
                entry = set.Add(entity);
                return entry;
            }
            entry = context.Entry(entity);
            entry.CurrentValues.SetValues(entity);
            return entry;
        }

        public static List<TEntity> UpsertRange<TEntity, TContext>(this DbSet<TEntity> set, List<TEntity> entities)
            where TEntity : BaseEntity
            where TContext : DbContext
        {
            List<TEntity> models = new();
            foreach (TEntity entity in entities){
              var entry =  Upsert<TEntity,TContext>(set, entity);
              models.Add(entry.Entity);
            }
            return models;
        }

        private static TEntity GetEntityById<TEntity>(this DbContext context, string id)
            where TEntity : BaseEntity
        {
            return context.Set<TEntity>().Find(id);
        }
        private static TContext GetContext<TEntity, TContext>(this DbSet<TEntity> set)
        where TEntity : BaseEntity
        where TContext : DbContext{
            var context = set.GetService<TContext>();
            return context;
        }
    }
}

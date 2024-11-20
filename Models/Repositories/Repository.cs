using System.Linq.Expressions;
using BlazorDemoPOC.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemoPOC.Models.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
        {
            public readonly ApplicationDbContext _db;
            internal DbSet<T> dbset;

            public Repository(ApplicationDbContext db)
            {
                _db = db;
                this.dbset = _db.Set<T>();
            }
            public async Task<T?> GetOne(Expression<Func<T, bool>> filter, string? includeProperties = null){
                IQueryable<T> query = dbset;
                query = query.Where(filter);
                 if (includeProperties != null)
                {
                    foreach (var includeProp in includeProperties.Split([','], StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }
                return await query.FirstOrDefaultAsync();
            }
            /// <summary>
            /// Return a single entity of Type T. Pass in a query to perform, select certain properties, and include individual navigation properties.
            /// </summary>
            /// <typeparam name="Result"></typeparam>
            /// <param name="filter"></param>
            /// <param name="selector"></param>
            /// <param name="includeProperties"></param>
            /// <returns></returns>
            public async Task<Result> GetOne<Result>(
                Expression<Func<T, bool>> filter, 
                Expression<Func<T, Result>> selector,
                string? includeProperties = null
            ){
                IQueryable<T> query = dbset;
                query = query.Where(filter);
                if (includeProperties != null)
                {
                    foreach (var includeProp in includeProperties.Split([','], StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }
                Result entity = await query.Select(selector).FirstAsync();
                return entity;
            }
            public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
            {
                IQueryable<T> query = dbset;
                if (filter != null) query = query.Where(filter);
                if (includeProperties != null)
                {
                    foreach (var includeProp in includeProperties.Split([','], StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }
                return await query.ToListAsync();
            }

            // ! Needs to be tested.
            /// <summary>
            /// Returns a List of type T. Able to execute multiple queries (where clauses) on a single operation.
            /// </summary>
            /// <param name="filter">List of queries to be performed on the search</param>
            /// <param name="includeProperties">Navigation properties to be included.</param>
            /// <returns>Promise of IEnumerable</returns>
            public async Task<IEnumerable<T>> GetAll(List<Expression<Func<T, bool>>>? filter = null, string? includeProperties = null)
            {
                IQueryable<T> query = dbset;
                if (filter != null){
                    foreach (var q in filter){
                        query = query.Where(q);
                    }
                } 

                if (includeProperties != null)
                {
                    foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }
                return await query.ToListAsync();
            }

            public async Task Save()
            {
               await _db.SaveChangesAsync();
            }
        }
}
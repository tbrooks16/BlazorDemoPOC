using System.Linq.Expressions;

namespace BlazorDemoPOC.Models.Repositories
{
    public interface IRepository<T> where T : class
        {
            public Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
            public Task<Result> GetOne<Result>(
                Expression<Func<T, bool>> filter, 
                Expression<Func<T, Result>> selector,
                string? includeProperties = null);
            public Task<T?> GetOne(Expression<Func<T, bool>> filter, string? includeProperties = null);

            public Task Save();
        }
}

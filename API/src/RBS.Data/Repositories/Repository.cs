using Microsoft.EntityFrameworkCore;
using RBS.Data.Pagination;
using RBS.Persistence.Database;
using System.Linq.Expressions;

namespace RBS.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> Table => _dbSet;

        public IQueryable<T> GetList()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<ICollection<T>> GetListAsync(
            Expression<Func<T, bool>>? predicate = null,
            Expression<Func<T, object>>[]? includeProperties = null,
            Expression<Func<T, object>>? orderBy = null,
            OrderByType orderByType = OrderByType.None)
        {
            IQueryable<T> query = _dbSet;
            if (predicate != null)
                query = query.Where(predicate);

            if (includeProperties != null)
                query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (orderBy != null && orderByType == OrderByType.ASC)
                query = query.OrderBy(orderBy);

            if (orderBy != null && orderByType == OrderByType.DESC)
                query = query.OrderByDescending(orderBy);

            return await query.ToListAsync();
        }

        public async Task<DomainPagedResult<T>> GetAllAsyncByPage(
            int page,
            Expression<Func<T, object>>[] includeProperties,
            List<Expression<Func<T, bool>>>? expression = null,
            int resultsPerPage = 10)
        {
            IQueryable<T> query = _context.Set<T>();

            if (expression != null)
            {
                for (int i = 0; i < expression.Count; i++)
                {
                    query = query.Where(expression[i]);
                }
            }

            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            var result = query.Paginate<T>(new DomainPagedQueryBase(page, resultsPerPage));
            return result;
        }

        public async Task<T> GetAsync(Expression<Func<T, object>>[] includeProperties, Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _dbSet;

            if (includeProperties != null)
                query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> GetForUpdateAsync(object key)
        {
            var obj = new object[1] { key };
            return await _dbSet.FindAsync(obj);
        }

        public async Task<int> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);

            var IdProperty = entity.GetType().GetProperty("Id").GetValue(entity, null);
            return (int)IdProperty;
        }

        public void Update(T entity)
        {
            if (entity == null)
                return;

            _dbSet.Update(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<T> GetAsyncByKey(object key)
        {
            var obj = new object[1] { key };
            return await _dbSet.FindAsync(obj);
        }

        public async Task RemoveAsync(params object[] key)
        {
            var entity = await GetAsyncByKey(key);
            _dbSet.Remove(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public Task<ICollection<T>> GetListAsync(Expression<Func<T, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }
    }
}

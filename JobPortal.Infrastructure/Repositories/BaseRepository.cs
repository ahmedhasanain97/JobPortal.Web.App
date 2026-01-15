using JobPortal.Application.Abstractions;
using JobPortal.Application.Common.Models;
using JobPortal.Application.Exceptions;
using System.Linq.Expressions;

namespace JobPortal.Infrastructure.Repositories
{
    public class BaseRepository<T, TId> : IAsyncRepository<T, TId> where T : class
    {
        private readonly DbSet<T> _dbSet;

        public BaseRepository(AppDbContext context)
        {
            _dbSet = context.Set<T>();
        }

        #region GET
        /// <summary>
        /// Retrieves all elements from a table without including navigation properties, paging, or ordering.
        /// </summary>
        /// <returns>An IQueryable representing all elements in the table.</returns>
        public IQueryable<T> GetAll()
            => _dbSet.AsNoTracking();

        /// <summary>
        /// Retrieves a queryable collection of elements from a table with optional filtering, inclusion of navigation properties, and ordering.
        /// </summary>
        /// <param name="predicate">Optional predicate for filtering the results.</param>
        /// <param name="includeNavigationProperties">Optional delegate to include navigation properties in the query.</param>
        /// <param name="orderBy">Optional expression to specify ordering.</param>
        /// <param name="orderByDirection">Optional enum indicating ordering direction.</param>
        /// <returns>An IQueryable representing the collection of elements with optional filtering, navigation properties, and ordering applied.</returns>
        public IQueryable<T> GetAll(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IQueryable<T>>? includeNavigationProperties = null,
            Expression<Func<T, object>>? orderBy = null,
            OrderBy? orderByDirection = OrderBy.Ascending)
        {
            IQueryable<T> query = _dbSet;

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            if (includeNavigationProperties != null)
                query = includeNavigationProperties(query);

            return query.AsNoTracking();
        }

        /// <summary>
        /// Retrieves a queryable collection of elements from a table with optional navigation property inclusion and ordering.
        /// </summary>
        /// <param name="includeNavigationProperties">Optional delegate to include navigation properties in the query.</param>
        /// <param name="orderBy">Optional expression to specify ordering.</param>
        /// <param name="orderByDirection">Optional string indicating ordering direction ('Ascending' or 'Descending').</param>
        /// <returns>An IQueryable representing the collection of elements with optional navigation properties and ordering applied.</returns>
        public IQueryable<T> GetAll(
            Func<IQueryable<T>, IQueryable<T>>? includeNavigationProperties = null,
            Expression<Func<T, object>>? orderBy = null,
            OrderBy? orderByDirection = OrderBy.Ascending)
        {
            IQueryable<T> query = _dbSet;

            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            if (includeNavigationProperties != null)
                query = includeNavigationProperties(query);

            return query.AsNoTracking();
        }

        /// <summary>
        /// Retrieves a queryable collection of elements from a table with optional navigation property inclusion, paging, and ordering.
        /// </summary>
        /// <param name="pageNumber">Page number for paging.</param>
        /// <param name="pageSize">Number of elements per page for paging.</param>
        /// <param name="includeNavigationProperties">Optional delegate to include navigation properties in the query.</param>
        /// <param name="orderBy">Optional expression to specify ordering.</param>
        /// <param name="orderByDirection">Optional string indicating ordering direction ('Ascending' or 'Descending').</param>
        /// <returns>An IQueryable representing the filtered, paged, and ordered collection of elements.</returns>
        public IQueryable<T> GetAll(
            int pageNumber = 0,
            int pageSize = 0,
            Func<IQueryable<T>, IQueryable<T>>? includeNavigationProperties = null,
            Expression<Func<T, object>>? orderBy = null,
            OrderBy? orderByDirection = OrderBy.Ascending)
        {
            IQueryable<T> query = _dbSet;

            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            if (includeNavigationProperties != null)
                query = includeNavigationProperties(query);

            if (pageNumber > 0 && pageSize > 0)
            {
                query = query.Skip(pageSize * (pageNumber - 1))
                    .Take(pageSize);
            }

            return query.AsNoTracking();
        }
        #endregion

        #region Search
        /// <summary>
        /// Retrieves an entity by its primary key.
        /// </summary>
        /// <param name="id">The primary key value of the entity to retrieve.</param>
        /// <returns>The entity with the specified primary key, or null if not found.</returns>
        public T? FindById(TId id)
            => _dbSet.Find(id);

        /// <summary>
        /// Asynchronously retrieves an entity by its primary key.
        /// </summary>
        /// <param name="id">The primary key value of the entity to retrieve.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains the entity with the specified primary key,
        /// or null if not found.
        /// </returns>
        public async Task<T?> FindByIdAsync(TId id)
            => await _dbSet.FindAsync(id);

        /// <summary>
        /// Retrieves a single entity from a table based on the specified predicate, with optional inclusion of navigation properties.
        /// </summary>
        /// <param name="predicate">The predicate used to filter the entity.</param>
        /// <param name="includeNavigationProperties">Optional delegate to include navigation properties in the query.</param>
        /// <returns>The entity matching the predicate, or null if not found.</returns>
        public T? Find(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>>? includeNavigationProperties = null)
        {
            IQueryable<T> query = _dbSet;

            if (includeNavigationProperties != null)
                query = includeNavigationProperties(query);

            return query.FirstOrDefault(predicate);
        }

        /// <summary>
        /// Asynchronously retrieves a single entity from a table based on the specified predicate, with optional inclusion of navigation properties.
        /// </summary>
        /// <param name="predicate">The predicate used to filter the entity.</param>
        /// <param name="includeNavigationProperties">Optional delegate to include navigation properties in the query.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the entity matching the predicate, or null if not found.</returns>
        public async Task<T?> FindAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>>? includeNavigationProperties = null)
        {

            IQueryable<T> query = _dbSet;

            if (includeNavigationProperties != null)
                query = includeNavigationProperties(query);

            return await query.FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Checks if any entities in the database context satisfy the specified predicate.
        /// </summary>
        /// <param name="predicate">A predicate to match entities against.</param>
        /// <returns>True if any matching entity exists, otherwise false.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the predicate is null.</exception>
        /// <exception cref="DataAccessErrorException">Thrown when an error occurs during database access.</exception>
        public bool AnyMatching(Expression<Func<T, bool>> predicate)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate), "predicate cannot be null!");
            try
            {
                return _dbSet.Any(predicate);
            }
            catch (Exception ex)
            {
                throw new DataFailureException(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        /// <summary>
        /// Asynchronously checks if any entities in the database context satisfy the specified predicate.
        /// </summary>
        /// <param name="predicate">A predicate to match entities against.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result is true if any matching entity exists, otherwise false.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when the predicate is null.</exception>
        /// <exception cref="DataAccessErrorException">Thrown when an error occurs during database access.</exception>
        public async Task<bool> AnyMatchingAsync(Expression<Func<T, bool>> predicate)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate), "predicate cannot be null!");
            try
            {
                return await _dbSet.AnyAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new DataFailureException(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
        #endregion

        #region Filter
        /// <summary>
        /// Filters and customizes a queryable collection of elements from a table based on the specified predicate,
        /// with optional inclusion of navigation properties and ordering.
        /// </summary>
        /// <param name="predicate">The predicate used to filter the collection.</param>
        /// <param name="includeNavigationProperties">Optional delegate to include navigation properties in the query.</param>
        /// <param name="orderBy">Optional expression to specify ordering.</param>
        /// <param name="orderByDirection">Optional enum indicating ordering direction.</param>
        /// <returns>An IQueryable representing the filtered and customized collection of elements.</returns>
        public IQueryable<T> Filter(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IQueryable<T>>? includeNavigationProperties = null,
            Expression<Func<T, object>>? orderBy = null,
            OrderBy? orderByDirection = OrderBy.Ascending)
        {
            IQueryable<T> query = _dbSet;

            query = query.Where(predicate);

            if (includeNavigationProperties != null)
                query = includeNavigationProperties(query);

            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return query.AsNoTracking();
        }
        #endregion

        #region Post
        public async Task<T> PostAsync(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null!");

            try
            {
                await _dbSet.AddAsync(entity);
                return entity;
            }
            catch (Exception ex) when (ex is DbUpdateException
                                    || ex is InvalidOperationException
                                    || ex is Exception)
            {
                throw new DataFailureException(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
        #endregion

        #region Delete
        public void SoftDelete(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                var property = entity.GetType().GetProperty("IsDeleted");
                if (property == null || property.PropertyType != typeof(bool))
                    throw new InvalidOperationException("The entity does not support soft deletion.");

                property.SetValue(entity, true);
                _dbSet.Update(entity);
            }
            catch (DbUpdateException ex)
            {
                throw new DataFailureException(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public void HardDelete(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                _dbSet.Remove(entity);
            }
            catch (DbUpdateException ex)
            {
                throw new DataFailureException(ex.InnerException?.Message ?? ex.Message);
            }
        }
        #endregion

        #region Attach
        public void Attach(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null!");
            try
            {
                _dbSet.Attach(entity);
            }
            catch (Exception ex) when (ex is DbUpdateException
                                    || ex is InvalidOperationException
                                    || ex is Exception)
            {
                throw new DataFailureException(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
        #endregion

        #region Count
        public int Count()
            => _dbSet.Count();

        public async Task<int> CountAsync()
            => await _dbSet.CountAsync();
        #endregion
    }
}
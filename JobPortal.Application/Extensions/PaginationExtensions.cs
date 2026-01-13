using Microsoft.EntityFrameworkCore;

namespace JobPortal.Application.Extensions
{
    public static class PaginationExtensions
    {
        public static async Task<PaginatedResult<T>> ToPaginatedResultAsync<T>(
            this IQueryable<T> query,
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken = default)
        {
            if (pageNumber <= 0)
                pageNumber = 1;

            if (pageSize <= 0)
                pageSize = 10;

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return new PaginatedResult<T>(
                items,
                pageNumber,
                pageSize,
                totalCount);
        }
    }
}

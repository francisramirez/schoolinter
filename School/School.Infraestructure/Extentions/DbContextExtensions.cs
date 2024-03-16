using Microsoft.EntityFrameworkCore;

namespace School.Infraestructure.Extentions
{
    public static class DbContextExtensions
    {
        public static async Task<List<T>> SqlQueryAsync<T>(this DbContext db, string sql, object[] parameters = null, CancellationToken cancellationToken = default) where T : class
        {
            if (parameters is null)
            {
                parameters = new object[] { };
            }

            if (typeof(T).GetProperties().Any())
            {
                return await db.Set<T>().FromSqlRaw(sql, parameters).ToListAsync(cancellationToken);
            }
            else
            {
                await db.Database.ExecuteSqlRawAsync(sql, parameters, cancellationToken);
                return default;
            }
        }

    }
}

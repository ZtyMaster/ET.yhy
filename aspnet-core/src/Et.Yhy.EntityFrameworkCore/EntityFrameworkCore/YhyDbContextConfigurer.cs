using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Et.Yhy.EntityFrameworkCore
{
    public static class YhyDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<YhyDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString,a=>a.UseRowNumberForPaging());
        }

        public static void Configure(DbContextOptionsBuilder<YhyDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}

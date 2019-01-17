using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Et.Yhy.Configuration;
using Et.Yhy.Web;

namespace Et.Yhy.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class YhyDbContextFactory : IDesignTimeDbContextFactory<YhyDbContext>
    {
        public YhyDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<YhyDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            YhyDbContextConfigurer.Configure(builder, configuration.GetConnectionString(YhyConsts.ConnectionStringName));

            return new YhyDbContext(builder.Options);
        }
    }
}

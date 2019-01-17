using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Et.Yhy.Authorization.Roles;
using Et.Yhy.Authorization.Users;
using Et.Yhy.MultiTenancy;
using Et.Yhy.Complay;
using Et.Yhy.EntityMapper.Complayss;
using Et.Yhy.EntityMapper.Bumens;
using Et.Yhy.BuMens;

namespace Et.Yhy.EntityFrameworkCore
{
    public class YhyDbContext : AbpZeroDbContext<Tenant, Role, User, YhyDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public YhyDbContext(DbContextOptions<YhyDbContext> options)
            : base(options)
        {
        }
        public DbSet<Complays> Complayss { get; set; }

        public DbSet<Bumen> Bumens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bumen>().ToTable("Bumen", "Yhy");
            modelBuilder.Entity<Complays>().ToTable("Complays", "Yhy");
            //modelBuilder.ApplyConfiguration(new ComplaysCfg());
            //modelBuilder.ApplyConfiguration(new BumenCfg());
            base.OnModelCreating(modelBuilder);
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.ApplyConfiguration(new ComplaysCfg());
        //}
    }
}

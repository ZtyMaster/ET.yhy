

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Et.Yhy.Complay;

namespace Et.Yhy.EntityMapper.Complayss
{
    public class ComplaysCfg : IEntityTypeConfiguration<Complays>
    {
        public void Configure(EntityTypeBuilder<Complays> builder)
        {

            builder.ToTable("Complayss", YoYoAbpefCoreConsts.SchemaNames.CMS);

            
			builder.Property(a => a.NameTXT).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.OverTime).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.Bumens).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.Users).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.MaxPersons).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);


        }
    }
}



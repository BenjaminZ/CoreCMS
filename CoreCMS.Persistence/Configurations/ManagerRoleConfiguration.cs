using CoreCMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreCMS.Persistence.Configurations
{
    public class ManagerRoleConfiguration : IEntityTypeConfiguration<ManagerRole>
    {
        public void Configure(EntityTypeBuilder<ManagerRole> builder)
        {
            builder.HasKey(mr => mr.ManagerRoleId);
            builder.Property(mr => mr.ManagerRoleName)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(mr => mr.ManagerRoleType)
                .IsRequired()
                .HasDefaultValue(2);

            builder.Property(mr => mr.IsSystemDefault)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(mr => mr.AddedBy)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(mr => mr.AddTime)
                .HasColumnType("datetime")
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(mr => mr.ModifyTime)
                .HasColumnType("datetime")
                .ValueGeneratedOnUpdate();

            builder.Property(mr => mr.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}
using CoreCMS.Domain.Entities;
using CoreCMS.Persistence.Encryption;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreCMS.Persistence.Configurations
{
    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasKey(m => m.ManagerId);
            builder.Property(m => m.ManagerId).HasColumnName("ManagerID");
            builder.Property(m => m.ManagerRoleId)
                .IsRequired()
                .HasColumnName("ManagerRoleID");

            builder.Property(m => m.AccountName)
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(m => m.Password)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(m => m.HeadShot).HasMaxLength(256);
            builder.Property(m => m.NickName).HasMaxLength(32);
            builder.Property(m => m.CellPhone).HasMaxLength(32);
            builder.Property(m => m.Email).HasMaxLength(128);

            builder.Property(m => m.LoginCount)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(m => m.LastLoginIp).HasMaxLength(64);
            builder.Property(m => m.LastLoginTime).HasColumnType("datetime");

            builder.Property(m => m.AddedBy)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(m => m.AddTime)
                .HasColumnType("datetime")
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(m => m.ModifyTime)
                .HasColumnType("datetime")
                .ValueGeneratedOnUpdate();

            builder.Property(m => m.IsLocked)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(m => m.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasOne(m => m.ManagerRole)
                .WithMany(r => r.Managers)
                .HasForeignKey(m => m.ManagerRoleId)
                .HasConstraintName("FK_Managers_ManagerRoles");
        }
    }
}
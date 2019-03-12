using System;
using CoreCMS.Domain.Entities;
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
            // TODO: Role
            builder.Property(m => m.AccountName).HasMaxLength(32);
            builder.Property(m => m.Password).HasMaxLength(128);
            builder.Property(m => m.HeadShot).HasMaxLength(256);
            builder.Property(m => m.NickName).HasMaxLength(32);
            builder.Property(m => m.CellPhone).HasMaxLength(32);
            builder.Property(m => m.Email).HasMaxLength(128);
            builder.Property(m => m.LoginCount).IsRequired().HasDefaultValue(0);
            builder.Property(m => m.LastLoginIp).HasMaxLength(64);
            builder.Property(m => m.LastLoginTime).HasColumnType("datetime");
            builder.Property(m => m.AddTime).HasColumnType("datetime").IsRequired().HasDefaultValue(DateTime.UtcNow);
            builder.Property(m => m.ModifyTime).HasColumnType("datetime");
            builder.Property(m => m.IsLocked).IsRequired().HasDefaultValue(false);
            builder.Property(m => m.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}
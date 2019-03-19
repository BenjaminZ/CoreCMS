using CoreCMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreCMS.Persistence.Configurations
{
    public class RoleAccessConfiguration : IEntityTypeConfiguration<RoleAccess>
    {
        public void Configure(EntityTypeBuilder<RoleAccess> builder)
        {
            builder.HasKey(a => a.RoleAccessId);
            builder.Property(a => a.RoleAccessId).HasColumnName("RoleAccessID");
            builder.Property(a => a.AdminMenuId)
                .HasColumnName("AdminMenuID");
            builder.Property(a => a.ManagerRoleId)
                .IsRequired()
                .HasColumnName("ManagerRoleID");
            builder.Property(a => a.AcessType).HasMaxLength(128);

            builder.HasOne(a => a.AdminMenu)
                .WithMany(m => m.RoleAccesses)
                .HasForeignKey(a => a.AdminMenuId)
                .HasConstraintName("FK_RoleAccesses_AdminMenus");

            builder.HasOne(a => a.ManagerRole)
                .WithMany(mr => mr.RoleAccesses)
                .HasForeignKey(a => a.ManagerRoleId)
                .HasConstraintName("FK_RoleAccesses_ManagerRoles");
        }
    }
}
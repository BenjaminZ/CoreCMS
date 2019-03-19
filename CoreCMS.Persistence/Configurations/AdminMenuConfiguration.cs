using CoreCMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreCMS.Persistence.Configurations
{
    public class AdminMenuConfiguration : IEntityTypeConfiguration<AdminMenu>
    {
        public void Configure(EntityTypeBuilder<AdminMenu> builder)
        {
            builder.HasKey(m => m.AdminMenuId);
            builder.Property(m => m.AdminMenuId).HasColumnName("AdminMenuID");
            builder.Property(m => m.ParentMenuId)
                .IsRequired()
                .HasColumnName("ParentMenuID");
            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(m => m.DisplayName).HasMaxLength(128);
            builder.Property(m => m.IconPath).HasMaxLength(128);
            builder.Property(m => m.Url).HasMaxLength(128);
            builder.Property(m => m.OperationLevel).HasMaxLength(256);
            builder.Property(m => m.IsDisplayed)
                .IsRequired()
                .HasDefaultValue(true);
            builder.Property(m => m.IsDefault)
                .IsRequired()
                .HasDefaultValue(false);
            builder.Property(m => m.AddedBy)
                .IsRequired();
            builder.Property(m => m.AddTime)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(m => m.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasOne(m => m.ParentMenu)
                .WithMany(m => m.ChildMenus)
                .HasForeignKey(m => m.ParentMenuId)
                .HasConstraintName("FK_ParentMenus_ChildMenus");
        }
    }
}
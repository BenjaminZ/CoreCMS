using System.Globalization;
using CoreCMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreCMS.Persistence.Configurations
{
    public class ArticleCategoryConfiguration : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.HasKey(ac => ac.ArticleCategoryId);
            builder.Property(ac => ac.ArticleCategoryId).HasColumnName("ArticleCategoryID");
            builder.Property(ac => ac.CategoryName)
                .IsRequired()
                .HasMaxLength(128);
            builder.Property(ac => ac.ParentCategoryId).HasColumnName("ParentCategoryID");
            builder.Property(ac => ac.OrderNumber).IsRequired();
            builder.Property(ac => ac.IconPath).HasMaxLength(128);
            builder.Property(ac => ac.SeoTitle).HasMaxLength(128);
            builder.Property(ac => ac.SeoKeywords).HasMaxLength(256);
            builder.Property(ac => ac.SeoDescription).HasMaxLength(512);
            builder.Property(ac => ac.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasOne(ac => ac.ParentCategory)
                .WithMany(ac => ac.ChildCategories)
                .HasForeignKey(ac => ac.ParentCategoryId)
                .HasConstraintName("FK_ParentCategories_ChildCategories");
        }
    }
}
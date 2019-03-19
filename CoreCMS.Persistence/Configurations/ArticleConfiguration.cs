using System.Globalization;
using CoreCMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreCMS.Persistence.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.ArticleId);
            builder.Property(a => a.ArticleId).HasColumnName("ArticleID");
            builder.Property(a => a.ArticleCategoryId)
                .HasColumnName("ArticleCategoryID")
                .IsRequired();
            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(128);
            builder.Property(a => a.PicturePath).HasMaxLength(128);
            builder.Property(a => a.Content).HasColumnType("Text");
            builder.Property(a => a.ViewCount)
                .IsRequired()
                .HasDefaultValue(0);
            builder.Property(a => a.OrderNumber).IsRequired();
            builder.Property(a => a.Author).HasMaxLength(64);
            builder.Property(a => a.Origin).HasMaxLength(128);
            builder.Property(a => a.SeoTitle).HasMaxLength(128);
            builder.Property(a => a.SeoKeywords).HasMaxLength(256);
            builder.Property(a => a.SeoDescription).HasMaxLength(512);
            builder.Property(a => a.AddedBy).IsRequired();
            builder.Property(a => a.AddTime)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(a => a.IsPinned)
                .IsRequired()
                .HasDefaultValue(false);
            builder.Property(a => a.IsInCarousel)
                .IsRequired()
                .HasDefaultValue(false);
            builder.Property(a => a.IsHot)
                .IsRequired()
                .HasDefaultValue(false);
            builder.Property(a => a.IsPublished)
                .IsRequired()
                .HasDefaultValue(false);
            builder.Property(a => a.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasOne(a => a.ArticleCategory)
                .WithMany(ac => ac.Articles)
                .HasForeignKey(ac => ac.ArticleCategoryId)
                .HasConstraintName("FK_Articles_ArticleCategories");
        }
    }
}
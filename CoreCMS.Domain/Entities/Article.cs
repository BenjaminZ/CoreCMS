using System;

namespace CoreCMS.Domain.Entities
{
    public class Article
    {
        public int ArticleId { get; set; }
        public int ArticleCategoryId { get; set; }
        public int Title { get; set; }
        public int PicturePath { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; }
        public int OrderNumber { get; set; }
        public string Author { get; set; }
        public string Origin { get; set; }
        public string SeoTitle { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifyTime { get; set; }
        public bool IsPinned { get; set; }
        public bool IsInCarousel { get; set; }
        public bool IsHot { get; set; }
        public bool IsPublished { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ArticleCategory ArticleCategory { get; set; }
    }
}
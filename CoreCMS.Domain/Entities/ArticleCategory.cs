using System.Collections.Generic;

namespace CoreCMS.Domain.Entities
{
    public class ArticleCategory
    {
        public int ArticleCategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }
        public int Depth { get; set; }
        public int OrderNumber { get; set; }
        public string IconPath { get; set; }
        public string SeoTitle { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ArticleCategory ParentCategory { get; set; }
        public virtual ICollection<ArticleCategory> ChildCategories { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
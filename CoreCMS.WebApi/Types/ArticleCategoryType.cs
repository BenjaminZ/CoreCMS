using CoreCMS.Domain.Entities;
using GraphQL.Types;

namespace CoreCMS.WebApi.Types
{
    public class ArticleCategoryType : ObjectGraphType<ArticleCategory>
    {
        public ArticleCategoryType()
        {
            Name = "ArticleCategory";
            Field(ac => ac.ArticleCategoryId);
            Field(ac => ac.CategoryName, true).Name("name");
            Field<ArticleCategoryType, ArticleCategory>()
                .Name("parent")
                .Resolve(ctx => ctx.Source.ParentCategory);
            Field(ac => ac.Depth);
            Field(ac => ac.OrderNumber);
            Field(ac => ac.IconPath);
            Field(ac => ac.SeoTitle);
            Field(ac => ac.SeoKeywords);
            Field(ac => ac.SeoDescription);
            Field(ac => ac.IsDeleted);
        }
    }
}
using CoreCMS.Domain.Entities;
using CoreCMS.Persistence;
using GraphQL.Types;

namespace CoreCMS.WebApi.Types
{
    public class ArticleCategoryType : ObjectGraphType<ArticleCategory>
    {
        public ArticleCategoryType()
        {
            Name = "ArticleCategory";
            Field(ac => ac.ArticleCategoryId).Name("id");
            Field(ac => ac.CategoryName, true).Name("name");
            Field<ArticleCategoryType, ArticleCategory>()
                .Name("parent")
                .Resolve(ctx => ctx.Source.ParentCategory);
        }
    }
}
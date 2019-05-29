using System.Threading.Tasks;
using CoreCMS.Domain.Entities;
using CoreCMS.Persistence;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace CoreCMS.WebApi.Types
{
    public class CMSQuery : ObjectGraphType
    {
        public CMSQuery(CMSDbContext dbContext)
        {
            Task<ArticleCategory> Func(ResolveFieldContext<object> resolveFieldContext)
            {
                var id = resolveFieldContext.GetArgument<int>("articleCategoryId");
                return dbContext.ArticleCategories.FirstOrDefaultAsync(
                    ac => ac.ArticleCategoryId == id && !ac.IsDeleted);
            }

            FieldAsync<ArticleCategoryType, ArticleCategory>(
                "articleCategory",
                arguments: new QueryArguments
                {
                    new QueryArgument(typeof(NonNullGraphType<IntGraphType>))
                    {
                        Name = "articleCategoryId"
                    }
                },
                resolve: Func
            );
        }
    }
}
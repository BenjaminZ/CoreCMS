using System.Threading.Tasks;
using CoreCMS.Domain.Entities;
using CoreCMS.Persistence;
using GraphQL.Types;

namespace CoreCMS.WebApi.Types
{
    public class CMSQuery : ObjectGraphType
    {
        public CMSQuery(CMSDbContext dbContext)
        {
            Task<ArticleCategory> Func(ResolveFieldContext<object> resolveFieldContext)
            {
                return dbContext.ArticleCategories.FindAsync(resolveFieldContext.GetArgument<int>("id"));
            }

            FieldAsync<ArticleCategoryType, ArticleCategory>(
                "articleCategory",
                arguments: new QueryArguments
                {
                    new QueryArgument(typeof(NonNullGraphType<IdGraphType>))
                    {
                        Name = "id"
                    }
                },
                resolve: Func
            );
        }
    }
}
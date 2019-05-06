using CoreCMS.Domain.Entities;
using MediatR;

namespace CoreCMS.Application.Articles.Queries
{
    public class GetArticleQuery : IRequest<Article>
    {
        public int ArticleCategoryId { get; set; }
    }
}
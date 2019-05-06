using System.Threading;
using System.Threading.Tasks;
using CoreCMS.Domain.Entities;
using CoreCMS.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreCMS.Application.Articles.Queries
{
    public class GetArticleQueryHandler : IRequestHandler<GetArticleQuery, Article>
    {
        private readonly CMSDbContext _context;

        public GetArticleQueryHandler(CMSDbContext context)
        {
            _context = context;
        }

        public async Task<Article> Handle(GetArticleQuery request, CancellationToken cancellationToken)
        {
            var article = await _context.Articles
                .SingleOrDefaultAsync(a => a.ArticleId == request.ArticleCategoryId && a.IsDeleted == false,
                    cancellationToken);

            return article;
        }
    }
}
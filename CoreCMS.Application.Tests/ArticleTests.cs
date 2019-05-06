using System.Linq;
using System.Threading;
using CoreCMS.Application.Articles.Queries;
using CoreCMS.Domain.Entities;
using CoreCMS.Persistence;
using FluentAssertions;
using Xunit;

namespace CoreCMS.Application.Tests
{
    public class ArticleTests : TestBase
    {
        public ArticleTests()
        {
            _context = InitAndGetDbContext();
            _queryHandler = new GetArticleQueryHandler(_context);
        }

        private readonly CMSDbContext _context;
        private readonly GetArticleQueryHandler _queryHandler;

        private CMSDbContext InitAndGetDbContext()
        {
            var context = GetDbContext();
            context.ArticleCategories.Add(new ArticleCategory
            {
                CategoryName = "Super power articles",
            });
            context.SaveChanges();
            var ac = context.ArticleCategories.First();
            context.Articles.Add(new Article
            {
                ArticleCategoryId = ac.ArticleCategoryId
            });
            context.SaveChanges();

            return context;
        }

        public override void Dispose()
        {
            _context.Dispose();
        }

        [Fact]
        public async void ArticleTest()
        {
            var query = new GetArticleQuery
            {
                ArticleCategoryId = 1
            };
            var article = await _queryHandler.Handle(query, CancellationToken.None);
            article.ArticleId.Should().Be(1);
            article.ArticleCategory.CategoryName.Should().Be("Super power articles");
        }
    }
}
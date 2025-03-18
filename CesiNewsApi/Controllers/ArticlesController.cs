using CesiNewsDomain.Services;
using CesiNewsInfrastructure.Dto;
using CesiNewsModel.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CesiNewsApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly ArticleService _articleService;

        public ArticlesController(ArticleService articleService)
        {
            _articleService = articleService;
        }

        // GET: api/Articles
        [HttpGet]
        public async Task<IEnumerable<ArticleDto>> GetArticles() =>
            await _articleService.GetArticles();

        // GET: api/Articles/5
        [HttpGet("{id}")]
        public async Task<ArticleDto?> GetArticle(int id) =>
            await _articleService.GetArticle(id);

        // PUT: api/Articles/5
        [HttpPut("{id}")]
        public async Task<ArticleDto?> PutArticle(int id, Article article) =>
            await _articleService.PutArticle(id, article);

        // PUT: api/Articles/5/categories/1
        [HttpPut("{id}/categories/{idCategory}")]
        public async Task<bool> PutArticleAddCategory(int id, int idCategory) =>
            await _articleService.AddCategoryToArticle(id, idCategory);

        // POST: api/Articles
        [HttpPost]
        public async Task<ArticleDto?> PostArticle(Article article) =>
            await _articleService.PostArticle(article);

        // DELETE: api/Articles/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteArticle(int id) =>
            await _articleService.DeleteArticle(id);
        
    }
}

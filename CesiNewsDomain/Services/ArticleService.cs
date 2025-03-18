
using CesiNewsInfrastructure.Dto;
using CesiNewsInfrastructure.Repositories;
using CesiNewsModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace CesiNewsDomain.Services;
public class ArticleService
{
    private readonly ArticleRepository _articleRepository;

    public ArticleService(ArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public async Task<IEnumerable<ArticleDto>> GetArticles()
    {
        return await _articleRepository.GetArticles();
    }

    public async Task<ArticleDto?> GetArticle(int id)
    {
        return await _articleRepository.GetArticle(id);
    }

    public async Task<ArticleDto?> PostArticle(Article article)
    {
        int id = await _articleRepository.Add(article);
        return await _articleRepository.GetArticle(id);
    }

    public async Task<ArticleDto?> PutArticle(int id, Article article)
    {
        if (id != article.Id)
        {
            throw new ArgumentException();
        }

        await _articleRepository.Update(article);
        return await _articleRepository.GetArticle(id);
    }

    public async Task<bool> DeleteArticle(int id)
    {
        return await _articleRepository.Delete(id);
    }

    public async Task<bool> AddCategoryToArticle(int id, int idCategory)
    {
        return await _articleRepository.AddCategoryToArticle(id, idCategory);
    }
}

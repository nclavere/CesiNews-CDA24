using CesiNewsInfrastructure.Dto;
using CesiNewsInfrastructure.Extensions;
using CesiNewsModel.Context;
using CesiNewsModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace CesiNewsInfrastructure.Repositories;
public class ArticleRepository
{
    private readonly NewsDbContext _context;

    public ArticleRepository(NewsDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ArticleDto>> GetArticles()
    {
        return await _context.Articles
            .Select(a => a.ToDto())
            .ToListAsync();
    }

    public async Task<ArticleDto?> GetArticle(int id)
    {
        return await _context.Articles
            .Include("Categories")
            .Include("Support")
            .Where(a => a.Id == id)
            .Select(a => a.ToDto())
            .FirstOrDefaultAsync();
    }

    public async Task<int> Add(Article article)
    {
        _context.Articles.Add(article);
        await _context.SaveChangesAsync();
        return article.Id;
    }

    public async Task Update(Article article)
    {
        _context.Entry(article).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<bool> AddCategoryToArticle(int id, int idCategory)
    {
        var article = await _context.Articles
            .Include("Categories")
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync();
        if (article == null)
        {
            return false;
        }

        var categorie = await _context.Categories.FindAsync(idCategory);
        if (categorie == null)
        {
            return false;
        }

        article.Categories!.Add(categorie);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var article = await _context.Articles.FindAsync(id);
        if (article == null)
        {
            return false;
        }
        _context.Articles.Remove(article);
        await _context.SaveChangesAsync();
        return true;
    }
}

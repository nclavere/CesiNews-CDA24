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

    public async Task<IEnumerable<Article>> GetArticle()
    {
        return await _context.Articles.ToListAsync();
    }

    public async Task<Article?> GetArticle(int id)
    {
        return await _context.Articles.FindAsync(id);
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

    public async Task DeleteCategorie(Article article)
    {
        _context.Articles.Remove(article);
        await _context.SaveChangesAsync();
    }
}

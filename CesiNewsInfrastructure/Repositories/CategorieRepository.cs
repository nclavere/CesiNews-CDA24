using CesiNewsModel.Context;
using CesiNewsModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace CesiNewsInfrastructure.Repositories;
public class CategorieRepository
{
    private readonly NewsDbContext _context;
    public CategorieRepository(NewsDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Categorie>> GetCategories()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Categorie?> GetCategorie(int id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async Task<int> Add(Categorie categorie)
    {
        _context.Categories.Add(categorie);
        await _context.SaveChangesAsync();
        return categorie.Id;
    }

    public async Task Update( Categorie categorie)
    {      
        _context.Entry(categorie).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }       

    public async Task Delete(Categorie categorie)
    {
        _context.Categories.Remove(categorie);
        await _context.SaveChangesAsync();
    }
}

using CesiNewsModel.Context;
using CesiNewsModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace CesiNewsInfrastructure.Repositories;
public class TexteRepository
{
    private readonly NewsDbContext _context;

    public TexteRepository(NewsDbContext context)
    {
        _context = context;
    }

    public async Task Add(Texte support)
    {
        _context.Textes.Add(support);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Texte support)
    {
        _context.Entry(support).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Texte support)
    {
        _context.Textes.Remove(support);
        await _context.SaveChangesAsync();
    }

}

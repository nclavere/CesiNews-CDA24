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

    public async Task<int> Add(Texte support)
    {
        _context.Textes.Add(support);
        await _context.SaveChangesAsync();
        return support.Id;
    }

    public async Task Update(Texte support)
    {
        _context.Entry(support).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

}

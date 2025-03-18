using CesiNewsModel.Context;
using CesiNewsModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace CesiNewsInfrastructure.Repositories;
public class VideoRepository
{
    private readonly NewsDbContext _context;

    public VideoRepository(NewsDbContext context)
    {
        _context = context;
    }

    public async Task<int> Add(Video support)
    {
        _context.Videos.Add(support);
        await _context.SaveChangesAsync();
        return support.Id;
    }

    public async Task Update(Video support)
    {
        _context.Entry(support).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}

using CesiNewsModel.Context;
using CesiNewsModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace CesiNewsInfrastructure.Repositories;
public class SupportRepository
{
    private readonly NewsDbContext _context;

    public SupportRepository(NewsDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Support>> GetSupports() =>   
        await _context.Supports.ToListAsync();
 

    public async Task<Support?> GetSupport(int id)=>
        await _context.Supports.FindAsync(id);


}

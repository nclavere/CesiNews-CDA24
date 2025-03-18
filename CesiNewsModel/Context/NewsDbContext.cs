using CesiNewsModel.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CesiNewsModel.Context;
public class NewsDbContext : IdentityDbContext<User>
{
    public virtual DbSet<Categorie> Categories { get; set; } = null!;
    public virtual DbSet<Article> Articles { get; set; } = null!;
    public virtual DbSet<Support> Supports { get; set; } = null!;
    public virtual DbSet<Texte> Textes { get; set; } = null!;
    public virtual DbSet<Video> Videos { get; set; } = null!;

    public NewsDbContext(DbContextOptions<NewsDbContext> options)
        : base(options)
    {
    }


}

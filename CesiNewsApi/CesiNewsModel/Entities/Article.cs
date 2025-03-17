using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CesiNewsModel.Entities;
public class Article
{
    public int Id { get; set; }
    [StringLength(40)]
    public string Titre { get; set; } = null!;
    [StringLength(400)]
    public string Resume { get; set; } = null!;

    public string? Contenu { get; set; }

    [StringLength(80)]
    public string Auteur { get; set; } = null!;
    public DateTime? DatePubli { get; set; }

    [ForeignKey(nameof(Support))]
    public int SupportId { get; set; }
    public virtual Support? Support { get; set; }

    [InverseProperty(nameof(Categorie.Articles))]
    public virtual List<Categorie>? Categories { get; set; }
}

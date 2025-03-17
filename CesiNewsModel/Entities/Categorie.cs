using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CesiNewsModel.Entities;
public class Categorie
{
    public int Id { get; set; }

    [StringLength(40)]
    public string Libelle { get; set; } = null!;

    [InverseProperty(nameof(Article.Categories))]
    public virtual List<Article>? Articles { get; set; }

}
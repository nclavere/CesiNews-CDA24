using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CesiNewsInfrastructure.Dto;
public class ArticleDto
{
    public int Id { get; set; }
    public string Titre { get; set; } = null!;
    public string Resume { get; set; } = null!;
    public string? Contenu { get; set; }
    public string Auteur { get; set; } = null!;
    public DateTime? DatePubli { get; set; }
    public string? Support { get; set; } 
    public virtual List<string>? Categories { get; set; }
}

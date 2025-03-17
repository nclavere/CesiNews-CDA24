using System.ComponentModel.DataAnnotations;

namespace CesiNewsModel.Entities;
public abstract class Support
{
    public int Id { get; set; }

    [StringLength(40)]
    public string Libelle { get; set; } = null!;
}

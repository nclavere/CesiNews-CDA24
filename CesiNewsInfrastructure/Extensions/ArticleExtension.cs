using CesiNewsInfrastructure.Dto;
using CesiNewsModel.Entities;
using System.Runtime.CompilerServices;

namespace CesiNewsInfrastructure.Extensions;
public static class ArticleExtension
{
    public static ArticleDto ToDto(this Article article)
    {
        return new ArticleDto
        {
            Id = article.Id,
            Titre = article.Titre,
            Resume = article.Resume,
            Contenu = article.Contenu,
            Auteur = article.Auteur,
            DatePubli = article.DatePubli,
            Support = article.Support?.Libelle,
            Categories = article.Categories?.Select(c => c.Libelle).ToList()
        };
    }


}

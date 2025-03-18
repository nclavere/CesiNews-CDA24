
using CesiNewsInfrastructure.Repositories;

namespace CesiNewsDomain.Services;
public class ArticleService
{
    private readonly ArticleRepository _articleRepository;

    public ArticleService(ArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }


}

using CesiNewsInfrastructure.Repositories;
using CesiNewsModel.Entities;

namespace CesiNewsDomain.Services;
public class CategorieService
{
    private readonly CategorieRepository _categorieRepository;

    public CategorieService(CategorieRepository categorieRepository)
    {
        _categorieRepository = categorieRepository;
    }

    public async Task<IEnumerable<Categorie>> GetCategories()
    {
        return await _categorieRepository.GetCategories();
    }

    public async Task<Categorie?> GetCategorie(int id)
    {
        return await _categorieRepository.GetCategorie(id);
    }

    public async Task<Categorie?> PostCategorie(Categorie categorie)
    {
        int id = await _categorieRepository.Add(categorie);
        return await _categorieRepository.GetCategorie(id);
    }

    public async Task<Categorie?> PutCategorie(int id, Categorie categorie)
    {
        if (id != categorie.Id)
        {
            throw new ArgumentException();
        }

        await _categorieRepository.Update(categorie);
        return await _categorieRepository.GetCategorie(id);
    }

    public async Task<bool> DeleteCategorie(int id)
    {
        var categorie = await _categorieRepository.GetCategorie(id);
        if (categorie == null)
        {
            return false;
        }

        await _categorieRepository.Delete(categorie);
        return true;
    }
}

using CesiNewsInfrastructure.Repositories;
using CesiNewsModel.Entities;

namespace CesiNewsDomain.Services;
public class SupportService
{
    private readonly SupportRepository _supportRepository;
    private readonly TexteRepository _texteRepository;
    private readonly VideoRepository _videoRepository;

    public SupportService(
        SupportRepository supportRepository, 
        TexteRepository texteRepository,
        VideoRepository videoRepository)
    {
        _supportRepository = supportRepository;
        _texteRepository = texteRepository;
        _videoRepository = videoRepository;
    }

    public async Task<IEnumerable<Support>> GetSupports()
    {
        return await _supportRepository.GetSupports();
    }

    public async Task<Support?> GetSupport(int id)
    {
        return await _supportRepository.GetSupport(id);
    }


    public async Task<Support?> CreateTexte(Texte support)
    {
        int id = await _texteRepository.Add(support);
        return await _supportRepository.GetSupport(id);
    }

    public async Task<Support?> CreateVideo(Video support)
    {
        int id = await _videoRepository.Add(support);
        return await _supportRepository.GetSupport(id);
    }

    public async Task<bool> DeleteSupport(int id)
    {
        var support = await _supportRepository.GetSupport(id);
        if (support==null)
        {
            return false;
        }

        await _supportRepository.Delete(support);
        return true;
    }


    public async Task<Support?> UpdateTexte(int id, Texte support)
    {
        if(id != support.Id)
        {
            throw new ArgumentException();
        }

        await _texteRepository.Update(support);
        return await _supportRepository.GetSupport(id);
    }

    public async Task<Support?> UpdateVideo(int id, Video support)
    {
        if (id != support.Id)
        {
            throw new ArgumentException();
        }

        await _videoRepository.Update(support);
        return await _supportRepository.GetSupport(id);
    }
}


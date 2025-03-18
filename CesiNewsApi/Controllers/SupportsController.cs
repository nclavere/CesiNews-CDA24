using CesiNewsDomain.Services;
using CesiNewsModel.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CesiNewsApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SupportsController : ControllerBase
    {
        private readonly SupportService _supportService;

        public SupportsController(SupportService supportService)
        {
            _supportService = supportService;
        }

        // GET: api/Supports
        [HttpGet]
        public async Task<IEnumerable<Support>> GetSupports() => 
            await _supportService.GetSupports();

        // GET: api/Supports/5
        [HttpGet("{id}")]
        public async Task<Support?> GetSupport(int id) =>
             await _supportService.GetSupport(id);


        // PUT: api/Supports/Texte/5
        [HttpPut("Texte/{id}")]
        public async Task<Support?> PutSupport(int id, Texte support) =>
               await _supportService.UpdateTexte(id, support);


        // PUT: api/Supports/Video/5
        [HttpPut("Video/{id}")]
        public async Task<Support?> PutSupport(int id, Video support) =>
            await _supportService.UpdateVideo(id, support);

        // POST: api/Supports/Texte
        [HttpPost]
        [Route("texte")]
        public async Task<Support?> PostSupport(Texte support) =>
               await _supportService.CreateTexte(support);

        // POST: api/Supports/Video
        [HttpPost]
        [Route("video")]
        public async Task<Support?> PostSupport(Video support) =>
               await _supportService.CreateVideo(support);

        // DELETE: api/Supports/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteSupport(int id) =>
               await _supportService.DeleteSupport(id);
    }
}

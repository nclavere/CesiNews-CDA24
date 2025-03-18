using CesiNewsDomain.Services;
using CesiNewsModel.Context;
using CesiNewsModel.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CesiNewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategorieService _categorieService;

        public CategoriesController(CategorieService categorieService)
        {
            _categorieService = categorieService;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<IEnumerable<Categorie>> GetCategories() =>
            await _categorieService.GetCategories();

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<Categorie?> GetCategorie(int id) => 
            await _categorieService.GetCategorie(id);

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<Categorie?> PutCategorie(int id, Categorie categorie) =>
            await _categorieService.PutCategorie(id, categorie);

        // POST: api/Categories
        [HttpPost]
        public async Task<Categorie?> PostCategorie(Categorie categorie) =>
            await _categorieService.PostCategorie(categorie);

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteCategorie(int id) =>
            await _categorieService.DeleteCategorie(id);
    }
}

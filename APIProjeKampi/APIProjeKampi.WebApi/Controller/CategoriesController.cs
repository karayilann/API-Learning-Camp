using APIProjeKampi.WebApi.Context;
using APIProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIProjeKampi.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _context;

        public CategoriesController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CategoryResult()
        {
            var values = _context.Categories.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("Kategori Başarıyla Eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value = _context.Categories.Find(id);
            _context.Categories.Remove(value);
            _context.SaveChanges();
            return Ok($"{id} nolu kategori silindi.");
        }

        // WARNING : We cannot use the same attribute in the same controller.
        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var value = _context.Categories.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            var value = _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok("Kategori Başarıyla Güncellendi.");
        }

    }
}

using APIProjeKampi.WebApi.Context;
using APIProjeKampi.WebApi.Dtos.CategoryDtos;
using APIProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIProjeKampi.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public CategoriesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryResult()
        {
            var values = _context.Categories.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddCategory(CreateCategoryDto category)
        {
            var mappedCategory = _mapper.Map<Category>(category);
            _context.Categories.Add(mappedCategory);
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

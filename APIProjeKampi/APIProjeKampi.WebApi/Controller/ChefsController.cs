using APIProjeKampi.WebApi.Context;
using APIProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIProjeKampi.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly ApiContext _context;

        public ChefsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ChefResult()
        {
            var value = _context.Chefs.ToList();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult AddChefs(Chef chef)
        {
            _context.Chefs.Add(chef);
            _context.SaveChanges();
            return Ok("Şef sisteme eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteChef(int id)
        {
            var value = _context.Chefs.Find(id);
            _context.Chefs.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }

        [HttpGet("GetChef")]
        public IActionResult GetChef(int id)
        {
            return Ok(_context.Chefs.Find(id));
        }

        [HttpPut]
        public IActionResult UpdateChef(Chef chef)
        {
            var value = _context.Chefs.Update(chef);
            _context.SaveChanges();
            return Ok($"Güncelleme işlemi başarılı {chef.ChefId}");

        }

    }
}

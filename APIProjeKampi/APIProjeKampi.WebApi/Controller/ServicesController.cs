using APIProjeKampi.WebApi.Context;
using APIProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIProjeKampi.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        // Bu class için DTO yaz
        private readonly ApiContext _context;

        public ServicesController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult ServicesResult()
        {
            var values = _context.Services.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return Ok("Hizmet Başarıyla Eklendi.");
        }

        [HttpDelete]
        public ActionResult DeleteServices(int id)
        {
            var value = _context.Services.Find(id);
            _context.Services.Remove(value);
            _context.SaveChanges();
            return Ok($"{id} nolu servis silindi.");
        }

        [HttpGet("GetServices")]
        public IActionResult GetServices(int id)
        {
            var value = _context.Services.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateServices(Service service)
        {
            var value = _context.Services.Update(service);
            _context.SaveChanges();
            return Ok("Servis Başarıyla Güncellendi.");
        }
    }
}

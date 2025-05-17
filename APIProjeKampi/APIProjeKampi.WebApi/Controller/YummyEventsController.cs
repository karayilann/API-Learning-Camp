using APIProjeKampi.WebApi.Context;
using APIProjeKampi.WebApi.Dtos.YummyEventDto;
using APIProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIProjeKampi.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class YummyEventsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public YummyEventsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult YummyEventResult()
        {
            var values = _context.YummyEvents.ToList();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddYummyEvent(CreateEventDto yummyEvent)
        {
            var map = _mapper.Map<YummyEvent>(yummyEvent);

            _context.YummyEvents.Add(map);
            await _context.SaveChangesAsync();
            return Ok("Etkinlik Başarıyla Eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteYummyEvent(int id)
        {
            var value = _context.YummyEvents.Find(id);
            _context.YummyEvents.Remove(value);
            _context.SaveChanges();
            return Ok($"{id} nolu Etkinlik silindi.");
        }

        [HttpGet("GetYummyEvent")]
        public IActionResult GetYummyEvent(int id)
        {
            var value = _context.YummyEvents.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateYummyEvent(YummyEvent yummyEvent)
        {
            var value = _context.YummyEvents.Update(yummyEvent);
            _context.SaveChanges();
            return Ok("Etkinlik Başarıyla Güncellendi.");
        }

    }
}

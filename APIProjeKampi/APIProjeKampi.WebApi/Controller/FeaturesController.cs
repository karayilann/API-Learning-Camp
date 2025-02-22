using APIProjeKampi.WebApi.Context;
using APIProjeKampi.WebApi.Dtos.FeatureDtos;
using APIProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace APIProjeKampi.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;


        public FeaturesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _context.Features.ToList();
            return Ok(_mapper.Map<List<ResultFeatureDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var value = _mapper.Map<Feature>(createFeatureDto); // Bu işlem value değerini Feature türüne dönüştürür
            _context.Features.Add(value);
            _context.SaveChanges();
            return Ok("Ekleme işlemi tamamlandı");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var value = _context.Features.Find(id);
            _context.Features.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi tamamlandı.");
        }

        [HttpGet("GetFeature")]
        //public IActionResult GetFeature(int id)
        //{
        //    var value = _context.Features.Find(id);
        //    return Ok(_mapper.Map<GetByIdFeatureDto>(value));
        //}
        public async Task<IActionResult> GetFeature(int id)
        {
            var feature = await _context.Features.FindAsync(id);
            return Ok(_mapper.Map<GetByIdFeatureDto>(feature));
        }


        // Videodan farklı olarak daha optimize yazılmaya çalışıldı.
        // [FromBody] ile: İstek gövdesindeki veriler(JSON, XML vb.) beklenen formata göre otomatik deserialize edilir.
        // Fakat ApiController bulunuyorsa bu attributeyi kullanmak sadece kodun okunabilirliğine katkı sunabilir.

        [HttpPut]
        public async Task<IActionResult> UpdateFeature(int id, [FromBody] UpdateResultFeatureDto updateResultFeatureDto)
        {
            if (updateResultFeatureDto == null || id != updateResultFeatureDto.FeatureId)
                return BadRequest("Geçersiz ID");

            var existingFeature = await _context.Features.FindAsync(id);
            if (existingFeature == null)
                return NotFound("Güncellenecek kayıt bulunamadı.");

            _mapper.Map(updateResultFeatureDto, existingFeature); // Burada yeni bir mapleme işlemi uygulanmamakta, var olan güncellenir.
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Video
        //[HttpPut]
        //public IActionResult UpdateFeature(UpdateResultFeatureDto updateResultFeatureDto)
        //{
        //    var value = _mapper.Map<Feature>(updateResultFeatureDto);
        //    _context.Features.Update(value);
        //    return Ok("Güncelleme işlemi tamamlandı.");
        //}

    }

}

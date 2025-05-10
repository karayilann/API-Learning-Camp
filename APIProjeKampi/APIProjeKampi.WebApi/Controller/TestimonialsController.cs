using APIProjeKampi.WebApi.Context;
using APIProjeKampi.WebApi.Dtos.TestimonialDtos;
using APIProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIProjeKampi.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {

        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public TestimonialsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> TestimonialResult()
        {
            var listAsync = await _context.Testimonials.ToListAsync();
            return Ok(listAsync);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonials(CreateTestimonialDto testimonial)
        {
            var map = _mapper.Map<Testimonial>(testimonial);
            await _context.Testimonials.AddAsync(map);
            await _context.SaveChangesAsync();
            return Ok("Referans Başarıyla Eklendi");
        }

        [HttpGet("Get Testimonial By ID")]
        public async Task<IActionResult> GetTestimonial(int testimonialId)
        {
            var findedTestimonial = await _context.Testimonials.FindAsync(testimonialId);
            return Ok(findedTestimonial);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTestimonials(Testimonial testimonial)
        {
            var findedTestimonial = _context.Testimonials.Update(testimonial);
            await _context.SaveChangesAsync();
            return Ok("Referans Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var findedTestimonial = await _context.Testimonials.FindAsync(id);
            _context.Testimonials.Remove(findedTestimonial);
            await _context.SaveChangesAsync();
            return Ok("Testimonial Başarıyla Silindi");
        }

    }
}

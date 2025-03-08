using APIProjeKampi.WebApi.Context;
using APIProjeKampi.WebApi.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIProjeKampi.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IValidator<Product> _validator;
        private readonly ApiContext _context;

        public ProductsController(IValidator<Product> validator, ApiContext context)
        {
            _validator = validator;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ProductListAsync()
        {
            var values = _context.Products;
            await values.ToListAsync();
            return Ok(values);
        }

        [HttpPost("Add Product")]
        public IActionResult AddProduct(Product product)
        {
            var validationResult = _validator.Validate(product);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            _context.Add(product);
            _context.SaveChanges();
            return Ok("Ürün ekleme işlemi başarılı");
        }

        //[HttpPost("Add Product Async")]
        //public async Task<IActionResult> AddProductAsync(Product product)
        //{
        //    var validationResult = await _validator.ValidateAsync(product);
        //    if (!validationResult.IsValid)
        //        return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));

        //    _context.Products.Add(product); // AddAsync büyük veri yüklerinde avantaj sağlar, ama düşük memory için sync kullanmak daha iyidir

        //    await _context.SaveChangesAsync(); //Sadece SaveChanges'i async yapmak yeterli, çünkü asıl IO işlemi burada gerçekleşiyor.

        //    return Ok("Ürün ekleme işlemi başarılı");
        //}

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _context.Products.Find(id);
            _context.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }

        [HttpGet("Get Product")]
        public IActionResult GetProduct(int id)
        {
            var value = _context.Products.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var validationResult = _validator.Validate(product);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            _context.Update(product);
            _context.SaveChanges();
            return Ok("Ürün güncelleme işlemi başarılı");
        }
    
    }
}

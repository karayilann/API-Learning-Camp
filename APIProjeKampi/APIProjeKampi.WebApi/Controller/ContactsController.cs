using APIProjeKampi.WebApi.Context;
using APIProjeKampi.WebApi.Dtos.ContactDtos;
using APIProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIProjeKampi.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _context;
        public ContactsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _context.Contacts.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            Contact contact = new Contact();
            contact.Address = createContactDto.Address;
            contact.Email = createContactDto.Email;
            contact.MapLocation = createContactDto.MapLocation;
            contact.OpeningHours = createContactDto.OpeningHours;
            contact.Phone = createContactDto.Phone;
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            Contact contact = new Contact();
            contact.Address = updateContactDto.Address;
            contact.Email = updateContactDto.Email;
            contact.MapLocation = updateContactDto.Address;
            contact.OpeningHours = updateContactDto.OpeningHours;
            contact.Phone = updateContactDto.Phone;
            contact.ContactId = updateContactDto.ContactId;
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi tamamlandı");

        }


        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var contact = _context.Contacts.Find(id);
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }

        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var contact = _context.Contacts.Find(id);
            return Ok(contact);
        }


    }
}

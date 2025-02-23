using APIProjeKampi.WebApi.Context;
using APIProjeKampi.WebApi.Dtos.MessageDtos;
using APIProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIProjeKampi.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public MessagesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> MessageList()
        {
            var messages = await _context.Messages.ToListAsync();
            return Ok(_mapper.Map<List<ResultMessageDto>>(messages));
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        { 
            var createdMessage = _mapper.Map<Message>(createMessageDto); 
            await _context.Messages.AddAsync(createdMessage); 
            await _context.SaveChangesAsync(); 
            //return CreatedAtAction($"CreateMessage", new { id = createdMessage.MessageId }, "Ekleme işlemi tamamlandı");
            return Ok("Ekleme işlemi tamamlandı");

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var delete = await _context.Messages.FindAsync(id);
            if (delete != null) _context.Messages.Remove(delete);

            await _context.SaveChangesAsync();
            return Ok("Silme işlemi başarıyla tamamlandı");
            //return NoContent();
            //return Ok(null);
        }

        [HttpGet("GetMessage")]
        public async Task<IActionResult> GetMessage(int id)
        {
            var findAsync = await _context.Messages.FindAsync(id);
            var message = _mapper.Map<GetByIdMessageDto>(findAsync);
            return Ok(message);
        }

        //[HttpPut]
        //public async Task<IActionResult> UpdateMessage(UpdateMessageDto updateMessage)
        //{
        //    var message = _mapper.Map<Message>(updateMessage);
        //    var findAsync = await _context.Messages.FindAsync(message);

        //    if (message != null) _mapper.Map(findAsync, updateMessage);
        //    await _context.SaveChangesAsync();
        //    return Ok("Güncelleme işlemi tamamlandı");
        //}

        [HttpPut]
        public async Task<IActionResult> UpdateMessageS(UpdateMessageDto updateMessage)
        {
            var message = _mapper.Map<Message>(updateMessage);
            _context.Messages.Update(message);
            await _context.SaveChangesAsync();
            return Ok("Güncelleme işlemi tamamlandı");
        }
    }
}

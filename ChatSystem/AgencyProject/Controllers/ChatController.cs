using BLL.DTO.Request;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgencyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;
        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _chatService.GetAllAsync();

            if (data == null)
                return BadRequest();
            else
                return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _chatService.GetByIdAsync(id);

            if (data == null) 
                return BadRequest();
            else
                return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ChatRequest request)
        {
            var data = await _chatService.AddAsync(request);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ChatRequest request)
        {
            await _chatService.UpdateAsync(request);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _chatService.DeleteAsync(id);
            return Ok();
        }
    }
}

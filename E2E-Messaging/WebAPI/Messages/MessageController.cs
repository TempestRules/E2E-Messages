using Application.Messages.Handlers.SendMessage;
using Application.Messages.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Messages
{
    [Route("api/message")]
    [ApiController]
    [Authorize]
    public class MessageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("send")]
        public async Task<IActionResult> Send([FromBody] SendMessageModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send(new SendMessageRequest(model));

            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Models;
using Portfolio.Web.Services;

namespace Portfolio.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<ContactController> _logger;

        public ContactController(IEmailService emailService, ILogger<ContactController> logger)
        {
            _emailService = emailService;
            _logger = logger;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] ContactMessage contactMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var success = await _emailService.SendContactEmailAsync(contactMessage);

                if (success)
                {
                    _logger.LogInformation("Kontaktmeddelande skickat från {Email}", contactMessage.Email);
                    return Ok(new { message = "Meddelandet har skickats!" });
                }
                else
                {
                    _logger.LogWarning("Misslyckades att skicka kontaktmeddelande från {Email}", contactMessage.Email);
                    return StatusCode(500, new { message = "Ett fel uppstod när meddelandet skulle skickas. Försök igen senare." });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Oväntat fel vid skickande av kontaktmeddelande från {Email}", contactMessage.Email);
                return StatusCode(500, new { message = "Ett oväntat fel uppstod. Försök igen senare." });
            }
        }
    }
}
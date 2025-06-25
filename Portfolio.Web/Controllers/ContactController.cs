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
            // Server-side validation som backup till client-side
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key.ToLower(), // Gör nycklar lowercase för konsistens
                        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

                _logger.LogWarning("Validation failed for contact message from {Email}. Errors: {Errors}",
                    contactMessage?.Email, string.Join(", ", errors.Values.SelectMany(v => v)));

                return BadRequest(new
                {
                    message = "Validering misslyckades",
                    errors = errors,
                    success = false
                });
            }

            // Sanitize input (extra säkerhet)
            contactMessage.Name = contactMessage.Name.Trim();
            contactMessage.Email = contactMessage.Email.Trim().ToLower();
            contactMessage.Subject = contactMessage.Subject.Trim();
            contactMessage.Message = contactMessage.Message.Trim();

            try
            {
                var success = await _emailService.SendContactEmailAsync(contactMessage);

                if (success)
                {
                    _logger.LogInformation("Kontaktmeddelande skickat från {Email}", contactMessage.Email);
                    return Ok(new
                    {
                        message = "The message has been sent! I will get back to you as soon as possible.",
                        success = true
                    });
                }
                else
                {
                    _logger.LogWarning("Misslyckades att skicka kontaktmeddelande från {Email}", contactMessage.Email);
                    return StatusCode(500, new
                    {
                        message = "An error occurred while sending the message. Please try again later.",
                        success = false
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Oväntat fel vid skickande av kontaktmeddelande från {Email}", contactMessage.Email);
                return StatusCode(500, new
                {
                    message = "An unexpected error occurred. Please try again later.",
                    success = false
                });
            }
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok(new { message = "Contact API is working", timestamp = DateTime.Now });
        }
    }
}
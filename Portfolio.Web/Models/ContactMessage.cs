using System.ComponentModel.DataAnnotations;

namespace Portfolio.Web.Models
{
    public class ContactMessage
    {
        [Required(ErrorMessage = "Namn är obligatoriskt")]
        [StringLength(100, ErrorMessage = "Namnet får inte vara längre än 100 tecken")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "E-postadress är obligatorisk")]
        [EmailAddress(ErrorMessage = "Ogiltig e-postadress")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ämne är obligatoriskt")]
        [StringLength(200, ErrorMessage = "Ämnet får inte vara längre än 200 tecken")]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "Meddelande är obligatoriskt")]
        [StringLength(1000, ErrorMessage = "Meddelandet får inte vara längre än 1000 tecken")]
        public string Message { get; set; } = string.Empty;
    }
}
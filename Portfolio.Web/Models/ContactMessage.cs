using System.ComponentModel.DataAnnotations;

namespace Portfolio.Web.Models
{
    public class ContactMessage
    {
        [Required(ErrorMessage = "Namn är obligatoriskt")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Namnet måste vara mellan 2-100 tecken")]
        [RegularExpression(@"^[a-zA-ZåäöÅÄÖ\s\-'\.]+$", ErrorMessage = "Namnet får endast innehålla bokstäver, mellanslag och bindestreck")]
        [Display(Name = "Namn")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "E-postadress är obligatorisk")]
        [EmailAddress(ErrorMessage = "Ange en giltig e-postadress")]
        [StringLength(320, ErrorMessage = "E-postadressen får inte vara längre än 320 tecken")]
        [Display(Name = "E-post")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ämne är obligatoriskt")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Ämnet måste vara mellan 3-200 tecken")]
        [Display(Name = "Ämne")]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "Meddelande är obligatoriskt")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Meddelandet måste vara mellan 10-1000 tecken")]
        [Display(Name = "Meddelande")]
        public string Message { get; set; } = string.Empty;
    }
}
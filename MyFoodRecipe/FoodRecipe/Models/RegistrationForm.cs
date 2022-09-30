using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FoodRecipe.Models
{
    /// <summary>
    /// EventRegistrationForm - form is used  to Registered the user to the event and stored record
    /// </summary>
    [Table("EventRegistrationForm")]
    public class RegistrationForm
    {
        [Key]                                                               
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Sr.No")] // ParticipantId
        public int ParticipantId { get; set; }


        [Display(Name = "Participant Name")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        [StringLength(60, ErrorMessage = "{0} cannot have more than {1} characters.")]
        [RegularExpression(@"^[A-Za-z]+[\s][A-Za-z]+$", ErrorMessage = "Use only characters!")]
        public string ParticipantName { get; set; }


        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Enter only 10 digits")]
        public string PhoneNumer { get; set; }


        [EmailAddress(ErrorMessage = "{0} is not valid.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "{0} cannot be empty")]
        [StringLength(60, ErrorMessage = "{0} cannot have more than {1} characters.")]
        public string Address { get; set; }

        #region Navigation Properties to the Master Model - FoodEvent

        [Display(Name = "Event Name")]
        [Required(ErrorMessage = "{0} must be required!")]
        [StringLength(60, ErrorMessage = "{0} cannot have more than {1} characters")]
        [ForeignKey(nameof(RegistrationForm.EventName))]
        public string EventName { get; set; }

        #endregion

    }
}

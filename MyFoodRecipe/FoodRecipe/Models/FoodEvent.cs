using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodRecipe.Models
{
    [Table("FoodEvents")]
    public class FoodEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventNo { get; set; }
        [Display(Name="Event Name")]
        [Required (ErrorMessage = "{0} must be required!")]
        [StringLength (60, ErrorMessage = "{0} cannot have more than {1} characters")]
        public string EventName { get; set; }


        [Required, MinLength(5,ErrorMessage ="{0} is must for event details")]
        public string Description { get; set; }


        [Display(Name = "Date & Time")]
        [Required(ErrorMessage="{0} cannot be empty!")]
        public DateTime EventDateTime { get; set; }


    }
}

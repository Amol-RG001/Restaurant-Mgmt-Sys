using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodRecipe.Models
{
    [Table("FoodCategories")]
    public class FoodCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Required(ErrorMessage = "{0} cannot be empty.")]
        public int FoodCategoryId { get; set; }

        [Display(Name ="Food Category")]
        [Required(ErrorMessage ="{0} cannot be empty.")]
        [StringLength (50, ErrorMessage = "{0} cannot have more than {1} characters.")]
        public string FoodCategoryName { get; set; }

        #region Navigation Properties to the Transcation model - FoodSubCategory
        
        public ICollection<FoodSubCategory> FoodSubCategories { get; set; }

        #endregion

       /* #region Navigation Properties to the Transcation model - AddFoodRecipe
        public ICollection<AddFoodRecipe> AddFoodRecipes { get; set; }

        #endregion*/

    }
}

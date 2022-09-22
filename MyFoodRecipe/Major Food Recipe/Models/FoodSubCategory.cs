using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Major_Food_Recipe.Models
{
   [Table("FoodSubCategories")]
     public class FoodSubCategory
     {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int FoodSubCategoryId { get; set; }

            [Display(Name = "Food Sub-Category")]
            [Required(ErrorMessage = "{0} cannot be empty.")]
            [StringLength(50, ErrorMessage = "{0} cannot have more than {1} characters.")]
            public string FoodSubCategoryName { get; set; }


        #region Navigation Properties to the Master Model - FoodCategory
        
        [Required]
        public int FoodCategoryId { get; set; }
        
        [ForeignKey(nameof(FoodSubCategory.FoodCategoryId))]
        public FoodCategory FoodCategory { get; set; }
        
        #endregion

        #region Navigation Properties to the Transcation model - AddFoodRecipe
        public ICollection<AddFoodRecipe> AddFoodRecipes { get; set; }

        #endregion

    }

}

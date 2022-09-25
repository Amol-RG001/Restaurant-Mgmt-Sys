using FoodRecipe.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FoodRecipe.Areas.Recipe.ViewModels
{
    public class ShowFoodSubCategoryViewModel
    {
        [Display(Name = "Select Sub Category:")]
        [Required(ErrorMessage = "Please select a sub category for displaying the Foods")]
        public int FoodSubCategoryId { get; set; }

        public ICollection<FoodSubCategory> FoodSubCategories { get; set; }
    }
}

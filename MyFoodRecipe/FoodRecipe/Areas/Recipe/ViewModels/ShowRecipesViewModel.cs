using FoodRecipe.Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodRecipe.Areas.Recipe.ViewModels
{
    public class ShowRecipesViewModel
    {
        [Display(Name = " Select Recipe want to see:")]
        [Required(ErrorMessage = "Please select recipe that you want")]

        public int FoodRecipeId { get; set; }

        public ICollection<AddFoodRecipe> AddFoodRecipes { get; set; }
    }
}

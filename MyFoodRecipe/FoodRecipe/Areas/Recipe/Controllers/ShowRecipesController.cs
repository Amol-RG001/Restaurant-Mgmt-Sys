using FoodRecipe.Areas.Recipe.ViewModels;
using FoodRecipe.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace FoodRecipe.Areas.Recipe.Controllers
{
    [Area("Recipe")]
    [Authorize]
    public class ShowRecipesController : Controller
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<ShowRecipesController> _logger;

        public ShowRecipesController(ApplicationDbContext dbContext, ILogger<ShowRecipesController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public IActionResult Index()
        {
            PopulateDropDownListToSelectCategory();

            _logger.LogInformation("--- extracted recipes");
            return View();
        }

        private void PopulateDropDownListToSelectCategory()
        {
            List<SelectListItem> recipesList = new List<SelectListItem>();
            recipesList.Add(new SelectListItem
            {
                Text = "----- select a recipe  -----",
                Value = "",
                Selected = true
            });
            recipesList.AddRange(new SelectList(_dbContext.AddFoodRecipe
                , "FoodRecipeId", "FoodRecipeName"));

            ViewData["RecipesListCollection"] = recipesList;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind("FoodRecipeId")] ShowRecipesViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                // Something is wrong with the viewmodel.  So, just return it back to the view with the ModelState errors!
                return View(viewmodel);
            }


            // Now performing server-side validation - checking if any books exist for the selected category
            bool fooditemsExist = _dbContext.AddFoodRecipe.Any(b => b.FoodRecipeId == viewmodel.FoodRecipeId);
            if (!fooditemsExist)
            {
                //--- Error will be shown as part of the Validation Summary
                ModelState.AddModelError("", "No FoodItems were found for the selected category!");

                //--- Error will be attached to the UI Control mapped by the asp-for attribute.
                // ModelState.AddModelError("CategoryId", "No books were found for this category");

                PopulateDropDownListToSelectCategory();

                return View(viewmodel);         // return the viewmodel with the ModelState errors!
            }


            return RedirectToAction(
                actionName: "GetRecipe",
                controllerName: "AddFoodRecipes",
                routeValues: new { area = "Recipe", filterFoodRecipeId = viewmodel.FoodRecipeId });


        }



    }
}

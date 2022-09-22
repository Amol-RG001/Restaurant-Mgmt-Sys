using FoodRecipe.Areas.Recipe.ViewModels;
using FoodRecipe.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace FoodRecipe.Areas.Recipe.Controllers
{
    [Area("Recipe")]
    public class ShowFoodSubCategoriesController : Controller
    {
       
      
            private readonly ApplicationDbContext _dbContext;
            private readonly ILogger<ShowFoodSubCategoriesController> _logger;

            public ShowFoodSubCategoriesController(ApplicationDbContext dbContext, ILogger<ShowFoodSubCategoriesController> logger)
            {
                _dbContext = dbContext;
                _logger = logger;
            }
            public IActionResult Index()
            {
                PopulateDropDownListToSelectCategory();

                _logger.LogInformation("--- extracted Categories");
                return View();
            }

            private void PopulateDropDownListToSelectCategory()
            {
                List<SelectListItem> categories = new List<SelectListItem>();
                categories.Add(new SelectListItem
                {
                    Text = "----- select a category -----",
                    Value = "",
                    Selected = true
                });
                categories.AddRange(new SelectList(_dbContext.FoodSubCategory
                    , "FoodSubCategoryId", "FoodSubCategoryName"));

                ViewData["CategoriesCollection"] = categories;
            }


            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Index([Bind("FoodSubCategoryId")] ShowFoodSubCategoryViewModel viewmodel)
            {
                if (!ModelState.IsValid)
                {
                    // Something is wrong with the viewmodel.  So, just return it back to the view with the ModelState errors!
                    return View(viewmodel);
                }


                // Now performing server-side validation - checking if any books exist for the selected category
                bool fooditemsExist = _dbContext.FoodSubCategory.Any(b => b.FoodSubCategoryId == viewmodel.FoodSubCategoryId);
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
                    actionName: "GetFoodsOfCategory",
                    controllerName: "FoodSubCategories",
                    routeValues: new { area = "Recipe", filterFoodCategoryId = viewmodel.FoodSubCategoryId });


            }
        
    }
}

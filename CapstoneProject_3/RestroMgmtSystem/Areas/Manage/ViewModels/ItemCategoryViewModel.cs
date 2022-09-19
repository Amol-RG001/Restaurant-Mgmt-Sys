using RestroMgmtSystem.Models;
using System.ComponentModel.DataAnnotations;
using System;

namespace RestroMgmtSystem.Areas.Manage.ViewModels
{
    public class ItemCategoryViewModel: ItemCategory
    {
            [Display(Name = "Item Category Name")]
            [Required(ErrorMessage = "{0} cannot be empty!")]
            [MinLength(3, ErrorMessage = "{0} should have at least {1} characters.")]
            [MaxLength(100, ErrorMessage = "{0} can have maximum of {1} characters.")]

            public override string ItemCategoryName
            {
                get { return base.ItemCategoryName; }
                set { base.ItemCategoryName = value; }
            }

            [Display(Name = "Is Availlable?")]
            public override bool IsAvailable
            {
                get { return base.IsAvailable; }
                set { base.IsAvailable = value; }
            }

           
            [Display(Name = "Who have created this {0}?")]
            public override string CreatedBy
            {
                get { return base.CreatedBy; }
                set { base.CreatedBy = value; }
            }

            [Display(Name = "When {0} was created?")]
            public override DateTime CreatedDate
            {
                get { return base.CreatedDate; }
                set { base.CreatedDate = value; }
            }

            [Display(Name = "Who have updated this {0}?")]
            public override string UpdatedBy
            {
                get { return base.UpdatedBy; }
                set { base.UpdatedBy = value; }
            }

            [Display(Name = "When {0} was updated?")]
            public override DateTime UpdatedDate
            {
                get { return base.UpdatedDate; }
                set { base.UpdatedDate = value; }
            }

        [Display(Name = "Available  Items in this Category")]
        public override string ItemsAvailable
        {
                get { return base.ItemsAvailable; }
                set { base.ItemsAvailable = value; }
            }
        
    }
}

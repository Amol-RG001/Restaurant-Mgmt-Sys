using System;
using RestroMgmtSystem.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace RestroMgmtSystem.Areas.Manage.ViewModels
{
    public class ItemViewModel
        :Item
    {
        [Display(Name = "Item Id")]
        override public int ItemId
        {
            get { return base.ItemId; }
            set { base.ItemId = value; }
        }
        [Display(Name = "Item Name")]
        [Required(ErrorMessage = "{0} cannot be empty!")]
        [MinLength(3, ErrorMessage = "{0} should have at least {1} characters.")]
        [MaxLength(100, ErrorMessage = "{0} should have at least {1} characters.")]

        public override string ItemName
        {
            get { return base.ItemName; }
            set { base.ItemName = value; }
        }

        [Display(Name = "Item Type")]
        [Required(ErrorMessage = "{0} cannot be empty!")]
        [MinLength(3, ErrorMessage = "{0} should have at least {1} characters.")]
        [MaxLength(20, ErrorMessage = "{0} should have at least {1} characters.")]
        public override string ItemType
        {
            get { return base.ItemType; }
            set { base.ItemType = value; }
        }

        [Display(Name = "Item Description")]
        [Required(ErrorMessage = "{0} cannot be empty!")]
        [MinLength(3, ErrorMessage = "{0} should have at least {1} characters.")]
        [MaxLength(350, ErrorMessage = "{0} should have at least {1} characters.")]
        public override string ItemDescription
        {
            get { return base.ItemDescription; }
            set { base.ItemDescription = value; }
        }
        [Display(Name ="Is Available?")]

        public override bool IsAvailabel
        {
            get { return base.IsAvailabel; }
            set { base.IsAvailabel = value; }
        }

        [Display(Name ="Items Price")]
        [Required]
        [DefaultValue(0.0)]
        [Column(TypeName = "decimal(6,2)")]
        public override decimal Price
        {
            get { return base.Price; }
            set { base.Price = value; }
        }
        [Display(Name ="Who have created this {0}?")]
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

        [Display(Name = "Item Category")]
        public override int ItemCategoryId
        {
            get { return base.ItemCategoryId; }
            set { base.ItemCategoryId = value; }
        }
    }
}

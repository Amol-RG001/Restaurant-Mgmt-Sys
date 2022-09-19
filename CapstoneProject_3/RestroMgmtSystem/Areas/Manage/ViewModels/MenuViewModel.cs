using RestroMgmtSystem.Models;
using System;
using System.ComponentModel.DataAnnotations;


namespace RestroMgmtSystem.Areas.Manage.ViewModels
{
    public class MenuViewModel:Menu
    {
        [Display(Name = "Menu Id")]
        public override int MenuId
        {
            get { return base.MenuId; }
            set { base.MenuId = value; }
        }

        [Display(Name = "Menu Name")]
        [Required(ErrorMessage ="{0} cannot be empty!")]
        [MinLength(3, ErrorMessage ="{0} should have at least {1} characters.")]
        [MaxLength(100, ErrorMessage = "{0} should have at least {1} characters.")]
        public override string MenuName
        {
            get { return base.MenuName; }
            set { base.MenuName = value; }
        }

        [Display(Name ="Who have created {0}?")]
        public override string CreatedBy
        {
            get { return base.CreatedBy; }
            set { base.CreatedBy = value; } 
        }

        [Display(Name ="When {0} was created ?")]
        public override DateTime CreatedDate
        {
            get { return base.CreatedDate; }
            set { base.CreatedDate = value; }
        }

        [Display(Name ="Who have updated this {0}?")]
         public override string UpdatedBy
        {
            get => base.UpdatedBy;
            set => base.UpdatedBy = value;
        }

        [Display(Name = "When {0] was updated?")]
        public override DateTime UpdatedDate
        {
            get=> base.UpdatedDate;
            set => base.UpdatedDate = value;
        }
    }
}

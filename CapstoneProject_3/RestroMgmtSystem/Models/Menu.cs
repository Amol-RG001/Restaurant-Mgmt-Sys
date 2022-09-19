using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestroMgmtSystem.Models
{
    [Table("Menus")]
    public class Menu
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
       virtual public int MenuId { get; set; }

        [Required]
        [StringLength(100)]
       virtual public string MenuName { get; set; }
       virtual public string CreatedBy{get; set; }
       virtual public DateTime CreatedDate { get; set; }
       virtual public string UpdatedBy { get; set; }

       virtual public DateTime UpdatedDate { get; set; }

        #region Navigate to Customer

        public Customer Customer { get; set; }
        public ICollection<ItemCategory> ItemCategories { get; set; }
        #endregion

    }
}

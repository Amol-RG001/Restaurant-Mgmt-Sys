using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestroMgmtSystem.Models
{
    [Table("Items")]
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    
        virtual public int ItemId { get; set; } 
        [Required]
        [StringLength(150)]
        virtual public string ItemName { get; set; }

        [Required]
        [StringLength(20)]
        virtual public string ItemType { get; set; }

        [StringLength(350)]
        virtual public string ItemDescription { get; set; }

        [Required]
        [DefaultValue(true)]
       virtual public bool IsAvailabel { get; set; }

        [Required]
        [DefaultValue(0.0)]
        [Column(TypeName = "decimal(6,2)")]
        virtual public decimal Price { get; set; } = default;

       virtual public string CreatedBy { get; set; }
       virtual public DateTime CreatedDate { get; set; }
       virtual public string UpdatedBy { get; set; }

       virtual public DateTime UpdatedDate { get; set; }

        #region
       virtual public int ItemCategoryId { get; set; }
        [ForeignKey(nameof(Item.ItemCategoryId))]
        public ItemCategory ItemCategory { get; set; }
        #endregion


    }
}

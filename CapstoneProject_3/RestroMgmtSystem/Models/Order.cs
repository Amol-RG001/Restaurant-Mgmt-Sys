using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.ComponentModel;

namespace RestroMgmtSystem.Models
{
    [Table("Orders")]
    public class Order
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        virtual public int OrderId { get; set; }

        virtual public DateTime OrderDate { get; set;}

        [Required]
        virtual public int PaymentTypeId { get; set; }

        [Required]
        [DefaultValue(0.0)]
        [Column(TypeName = "decimal(6,2)")]    // decimal(6,2) 999.99
        virtual public decimal FinalTotal { get; set; } //GrossedTotal

        virtual public string CreatedBy { get; set; }

        virtual public DateTime CreatedDate { get; set; }

        virtual public string UpdateBy { get; set; }

        virtual public DateTime UpdateDate { get; set; }


        public ICollection<OrderDetail> OrderDetails { get; set; }

        #region Navigation Properties to the Customer Model

        [Required]
        [ForeignKey(nameof(Order.CustomerId))]
        virtual public int CustomerId { get; set; }
         public Customer Customer { get; set; }


        #endregion

        #region Navigate Properties to Item Model

         virtual public int ItemId { get; set; }

        [ForeignKey(nameof(Order.ItemId))]

        public Item Item { get; set; }
        virtual public string UpdatedBy { get;  set; }
        virtual public DateTime UpdatedDate { get;  set; }

        #endregion


    }
}

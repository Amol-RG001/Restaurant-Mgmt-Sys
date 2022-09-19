using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestroMgmtSystem.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        virtual public int OrderDetailId { get; set; }

        virtual public int ItemId { get; set; }

        [Required]
        [DefaultValue(0.0)]
        [Column(TypeName = "decimal(6,2)")]
        virtual public decimal UnitPrice { get; set; }

        [Required]
        [DefaultValue(0.0)]
        [Column(TypeName = "decimal(6,2)")]
        virtual public decimal Discount { get; set; }

        [Required]
        [DefaultValue(0.0)]
        [Column(TypeName = "decimal(6,2)")]
        virtual public decimal Total { get; set; } = default;

        [Required]
        [DefaultValue(0.0)]
        [Column(TypeName = "decimal(6,2)")]
        virtual public decimal Quantity { get; set; }  = default;

        virtual public string CreatedBy { get; set; }
        virtual public DateTime CreateDate { get; set; }
        virtual public string UpdatedBy { get; set; }
        virtual public DateTime UpdatedDate { get; set; }

        [Required]
        virtual public int OrderId { get; set; }
        [ForeignKey(nameof(OrderDetail.OrderId))]

        public Order Order { get; set; }

        [NotMapped]
        public ICollection<Order> Orders { get; set; }
     

    }
}

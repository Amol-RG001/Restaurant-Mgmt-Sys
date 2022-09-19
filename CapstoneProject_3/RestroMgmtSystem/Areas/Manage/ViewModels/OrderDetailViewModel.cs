using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestroMgmtSystem.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace RestroMgmtSystem.Areas.Manage.ViewModels
{
    public class OrderDetailViewModel : OrderDetail
    {
        [Display(Name = "Order Detail ID")]
        public override int OrderDetailId
        {
            get
            {
                return base.OrderDetailId;
            }
            set
            {
                base.OrderDetailId = value;
            }
        }
        [Display(Name = "Oredered Item ID")]
        public override int ItemId
        {
            get { return base.ItemId; }
            set { base.ItemId = value; }
        }
        [Display(Name = "Unit Price of that item")]

        [Required]
        [DefaultValue(0.0)]
        [Column(TypeName = "decimal(6,2)")]
        public override decimal UnitPrice
        {
            get { return base.UnitPrice; }
            set { base.UnitPrice = value; }
        }
        [Display(Name = "Discount")]

        [DefaultValue(0.0)]
        [Column(TypeName = "decimal(6,2)")]
        public override decimal Discount
        {
            get { return base.Discount; }
            set { base.Discount = value; }
        }
        [Display(Name = "Total Amount")]
        [Required]
        [DefaultValue(0.0)]
        [Column(TypeName = "decimal(6,2)")]
        public override decimal Total
        {
            get { return base.Total; }
            set { base.Total = value; }
        }
        [Display(Name = "Quantity")]
        [Required]
        [DefaultValue(0.0)]
        [Column(TypeName = "decimal(6,2)")]
        public override decimal Quantity
        {
            get { return base.Quantity; }
            set { base.Quantity = value; }
        }
        [Display(Name = "Who have created this {0}?")]

        public override string CreatedBy
        {
            get => base.CreatedBy;
            set => base.CreatedBy = value;
        }
        [Display(Name = "Who have updated this {0}?")]

        public override string UpdatedBy
        {
            get => base.UpdatedBy;
            set => base.UpdatedBy = value;
        }
        [Display(Name = "When {0} was updated?")]

        public override System.DateTime UpdatedDate
        {
            get => base.UpdatedDate;
            set => base.UpdatedDate = value;
        }
        [Display(Name = "Order Id of the order placed")]
        public override int OrderId
        {
            get => base.OrderId; set => base.OrderId = value;
        }

    }
}

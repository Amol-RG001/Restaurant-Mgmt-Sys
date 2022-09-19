using RestroMgmtSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RestroMgmtSystem.Areas.Manage.ViewModels
{
    public class OrderViewModel : Order
    {
        [Display(Name = "Order ID")]
        override public int OrderId
        {
            get { return base.OrderId; }
            set { base.OrderId = value; }
        }


        [Display(Name = "When Order is placed?")]
        public override System.DateTime OrderDate
        {
            get { return base.OrderDate; }
            set { base.OrderDate = value; }
        }
        [Display(Name = "PaymentType ID")]

        public override int PaymentTypeId
        {
            get { return base.PaymentTypeId; }
            set { base.PaymentTypeId = value; }
        }
        [Display(Name = "Who have created this {0}?")]

        public override string CreatedBy
        {
            get => base.CreatedBy;
            set => base.CreatedBy = value;
        }
        [Display(Name = "When {0} was created?")]

        public override System.DateTime CreatedDate
        {
            get => base.CreatedDate;
            set => base.CreatedDate = value;
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
       
        [Display(Name = "{0} of Customer who placed the Order.")]
        public override int CustomerId
        {
            get => base.CustomerId;
            set => base.CustomerId = value;
        }




    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestroMgmtSystem.Models
{
    [Table("Payments")]
    public class PaymentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        virtual public int PaymentTypeId { get; set; } 

        [Required]
        [StringLength(50)]
        public string PaymentTypeName { get; set; }

        #region Navigation to the Order Details
        
        public ICollection<OrderDetail> OrderDetails { get; set; }

        #endregion

        #region Navigatio properties to the customer model
        virtual public int CustomerId { get; set; }

        [ForeignKey(nameof(PaymentType.CustomerId))]
        public Customer Customer { get; set; }

        #endregion




    }
}

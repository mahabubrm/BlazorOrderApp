using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public string OrderName { get; set; }
        [Required]
        public string OrderState { get; set; }
        public virtual ICollection<OrderWindow> OrderWindows { get; set; }
    }
}

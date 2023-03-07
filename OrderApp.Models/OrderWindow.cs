using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Models
{
    public class OrderWindow
    {
        [Key]
        public int WindowId { get; set; }
        public int OrderId { get; set; }
        public string WindowName { get; set; }
        public int QuantityOfWindow { get; set; }

        public virtual Order Order { get; set; }
        public virtual ICollection<OrderWindowDetail> OrderWindowDetails { get; set; }
    }
}

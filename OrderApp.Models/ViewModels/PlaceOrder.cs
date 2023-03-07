using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Models.ViewModels
{
    public class PlaceOrder
    {
        //public OrderWindow OrderWindow { get; set; }
        //public List<OrderWindowDetail> OrderWindowDetail { get; set; } = new List<OrderWindowDetail>();

        public string? ItemWindowName { get; set; }
        public int ItemQuantityOfWindow { get; set; }
        public int ItemElementNo { set; get; }
        public string? ItemType { get; set; }
        public int ItemWidth { get; set; }
        public int ItemHeight { get; set; }
    }
}

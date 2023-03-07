using OrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.BLL.Interface
{
    public interface IOrderManager:IBaseManager<Order>
    {
        bool CascadeDeleteOrder(int orderId);
        Order GetOrderWithAllRelation(int orderId);
    }
}

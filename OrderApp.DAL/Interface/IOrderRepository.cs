using OrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.DAL.Interface
{
    public interface IOrderRepository:IBaseRepository<Order>
    {
        bool CascadeDeleteOrder(int orderId);
        Order GetOrderWithAllRelation(int orderId);
    }
}

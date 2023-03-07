using OrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.BLL.Interface
{
    public interface IOrderWindowManager:IBaseManager<OrderWindow>
    {
        bool SaveOrderWindow(OrderWindow orderWindow, List<OrderWindowDetail> orderDetails);
        bool CascadeDeleteOrder(int windowId);
    }
}

using OrderApp.Models;
using WireMock.Admin.Mappings;

namespace OrderApp.Services
{
    public interface IOrderService
    {
        List<Order> GetAll();
        Order GetById(int id);
        bool AddOrder(Order order);
        ResponseModel UpdateOrder(Order order);    
        ResponseModel DeleteOrder(int id);

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApp.BLL.Interface;
using OrderApp.Models;

namespace OrderApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _order;
        public OrderController(IOrderManager order) 
        {
            _order = order;
        }

        //[HttpGet]
        //public async Task<IEnumerable<Order>>GetAll()
        //{
        //    return await Task.FromResult(_order.GetOrders());
        //}

    }
}

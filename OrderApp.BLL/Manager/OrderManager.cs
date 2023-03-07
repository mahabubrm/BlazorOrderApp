using OrderApp.BLL.Interface;
using OrderApp.DAL.Interface;
using OrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.BLL.Manager
{
    public class OrderManager : IOrderManager
    {
        private IOrderRepository _orderRepository;
        public OrderManager(IOrderRepository orderRepository) 
        {
            _orderRepository = orderRepository;        
        }

        public bool Add(Order entity)
        {
            return _orderRepository.Add(entity);
        }

        public bool CascadeDeleteOrder(int orderId)
        {
            return _orderRepository.CascadeDeleteOrder(orderId);
        }

        public bool Delete(Order order)
        {
            Order orderModel = _orderRepository.GetById(order.OrderId);
            if (orderModel == null)
            {
                return false;
            }
            else
            {
                _orderRepository.Delete(orderModel);
                return true;
            }
        }
               
        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public Order GetById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public Order GetOrderWithAllRelation(int orderId)
        {
            return _orderRepository.GetOrderWithAllRelation(orderId);
        }

        public bool Update(Order entity)
        {
            Order orderModel = _orderRepository.GetById(entity.OrderId);
            if (orderModel == null)
            {
                return false;
            }
            else
            {
                _orderRepository.Update(orderModel); return true;
            }
        }        
    }
}

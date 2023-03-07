using OrderApp.BLL.Interface;
using OrderApp.DAL.Interface;
using OrderApp.DAL.Repository;
using OrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.BLL.Manager
{
    public class OrderWindowManager : IOrderWindowManager
    {
        private IOrderWindowRepository _orderWindowRepository;        
        public OrderWindowManager(IOrderWindowRepository orderWindowRepository) 
        {
            _orderWindowRepository= orderWindowRepository;            
        }
        public bool Add(OrderWindow entity)
        {
            return _orderWindowRepository.Add(entity);
        }

        public bool CascadeDeleteOrder(int windowId)
        {
            return _orderWindowRepository.CascadeDeleteOrder(windowId);
        }

        public bool Delete(OrderWindow order)
        {
            OrderWindow orderWindowModel = _orderWindowRepository.GetById(order.OrderId);
            if (orderWindowModel == null)
            {
                return false;
            }
            else
            {
                _orderWindowRepository.Delete(orderWindowModel);
                return true;
            }
        }

        public IEnumerable<OrderWindow> GetAll()
        {
            return _orderWindowRepository.GetAll();
        }

        public OrderWindow GetById(int id)
        {
            return _orderWindowRepository.GetById(id);
        }

        public bool SaveOrderWindow(OrderWindow orderWindow, List<OrderWindowDetail> orderDetails)
        {
            return _orderWindowRepository.SaveOrderWindow(orderWindow, orderDetails);
        }

        public bool Update(OrderWindow entity)
        {
            OrderWindow orderWindowModel = _orderWindowRepository.GetById(entity.OrderId);
            if (orderWindowModel == null)
            {
                return false;
            }
            else
            {
                _orderWindowRepository.Update(orderWindowModel); return true;
            }
        }
    }
}

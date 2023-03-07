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
    public class OrderWindowDetailManager : IOrderWindowDetailManager
    {
        private IOrderWindowDetailRepository _orderWindowDetailRepository;
        public OrderWindowDetailManager(IOrderWindowDetailRepository orderWindowDetailManager) 
        {
            _orderWindowDetailRepository = orderWindowDetailManager;
        }
        public bool Add(OrderWindowDetail entity)
        {
            return _orderWindowDetailRepository.Add(entity);
        }

        public bool Delete(OrderWindowDetail order)
        {
            OrderWindowDetail orderWindowDetailModel = _orderWindowDetailRepository.GetById(order.WindowDetailsId);
            if (orderWindowDetailModel == null)
            {
                return false;
            }
            else
            {
                _orderWindowDetailRepository.Delete(orderWindowDetailModel);
                return true;
            }
        }
               

        public IEnumerable<OrderWindowDetail> GetAll()
        {
            return _orderWindowDetailRepository.GetAll();
        }

        public OrderWindowDetail GetById(int id)
        {
            return _orderWindowDetailRepository.GetById(id);
        }

        public bool Update(OrderWindowDetail entity)
        {
            OrderWindowDetail orderWindowDetailModel = _orderWindowDetailRepository.GetById(entity.WindowDetailsId);
            if (orderWindowDetailModel == null)
            {
                return false;
            }
            else
            {
                _orderWindowDetailRepository.Update(orderWindowDetailModel); return true;
            }
        }
    }
}

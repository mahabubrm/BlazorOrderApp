using Microsoft.EntityFrameworkCore;
using OrderApp.DAL.Interface;
using OrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.DAL.Repository
{
    public class OrderRepository : IOrderRepository
    {
        OrderDbContext _dbContext;
        public OrderRepository(OrderDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public bool Add(Order entity)
        {
            var order = _dbContext.Orders.AddAsync(entity);
            return _dbContext.SaveChanges() > 0;            
        }

        public bool CascadeDeleteOrder(int orderId)
        {
            bool isSuccess;

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var orderWindow = _dbContext.OrderWindows.Where(o => o.OrderId == orderId).ToList();
                    if (orderWindow != null)
                    {
                        foreach(var orderItem in orderWindow)
                        {
                            var orderWindowDetails = _dbContext.OrderWindowDetails.Where(o => o.OrderWindowId == orderItem.WindowId).ToList();
                            if (orderWindowDetails != null)
                            {
                                _dbContext.OrderWindowDetails.RemoveRange(orderWindowDetails);
                                _dbContext.SaveChanges();
                            }
                        }

                        _dbContext.OrderWindows.RemoveRange(orderWindow);
                        _dbContext.SaveChanges();
                    }
                                        
                    var order = _dbContext.Orders.Find(orderId);
                    if (order != null)
                    {
                        _dbContext.Orders.Remove(order);
                        _dbContext.SaveChanges();
                    }

                    transaction.Commit();
                    isSuccess = true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    isSuccess = false;
                }
            }
            return isSuccess;
        }

        public bool Delete(Order entity)
        {
            var order = _dbContext.Orders.FirstOrDefaultAsync(o => o.OrderId == entity.OrderId);
             _dbContext.Remove(order);
            return _dbContext.SaveChanges() > 0;
        }

        public IEnumerable<Order> GetAll()
        {
            return _dbContext.Orders.ToList();
        }
               

        public Order GetById(int id)
        {
            return _dbContext.Orders.Find(id);
        }

        public Order GetOrderWithAllRelation(int orderId)
        {
            //var order = _dbContext.Orders.Include(p => p.OrderWindows.Where(p => p.OrderId == orderId));
            return null;
        }

        public bool Update(Order entity)
        {
            _dbContext.Orders.Update(entity);
            return _dbContext.SaveChanges() > 0;
        }
               
    }
}

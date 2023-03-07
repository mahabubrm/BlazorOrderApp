using Microsoft.EntityFrameworkCore;
using OrderApp.DAL.Interface;
using OrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.DAL.Repository
{
    public class OrderWindowRepository : IOrderWindowRepository
    {
        OrderDbContext _dbContext;
        public OrderWindowRepository(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Add(OrderWindow entity)
        {
            _dbContext.OrderWindows.AddAsync(entity);
            return _dbContext.SaveChanges() > 0;
            
        }

        public bool CascadeDeleteOrder(int windowId)
        {
            bool isSuccess;
            
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var orderWindowDetails = _dbContext.OrderWindowDetails.Where(o => o.OrderWindowId == windowId).ToList();
                    if (orderWindowDetails != null)
                    {
                        _dbContext.OrderWindowDetails.RemoveRange(orderWindowDetails);
                        _dbContext.SaveChanges();
                    }
                    var orderWindow = _dbContext.OrderWindows.Find(windowId);
                    if (orderWindow != null)
                    {
                        _dbContext.OrderWindows.Remove(orderWindow);
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

        public bool Delete(OrderWindow entity)
        {
            var order = _dbContext.OrderWindows.FirstOrDefaultAsync(o => o.WindowId == entity.WindowId);
            _dbContext.Remove(order);
            return _dbContext.SaveChanges() > 0;
        }

        public IEnumerable<OrderWindow> GetAll()
        {
            return _dbContext.OrderWindows.ToList();
        }
                
        public OrderWindow GetById(int id)
        {
            return _dbContext.OrderWindows.Find(id);
        }

        public bool SaveOrderWindow(OrderWindow orderWindow, List<OrderWindowDetail> orderDetails)
        {
            bool isSave;
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.OrderWindows.Add(orderWindow);
                    _dbContext.SaveChanges();

                    orderDetails.ForEach(o => o.OrderWindowId=orderWindow.WindowId);
                    _dbContext.OrderWindowDetails.AddRange(orderDetails);
                    _dbContext.SaveChanges();

                    transaction.Commit();
                    isSave=true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    isSave =false;
                }
            }
            return isSave;
        }

        public bool Update(OrderWindow entity)
        {
            _dbContext.OrderWindows.Update(entity);
            return _dbContext.SaveChanges() > 0;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using OrderApp.DAL.Interface;
using OrderApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.DAL.Repository
{
    public class OrderWindowDetailRepository : IOrderWindowDetailRepository
    {
        OrderDbContext _dbContext;
        public OrderWindowDetailRepository(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Add(OrderWindowDetail entity)
        {
            _dbContext.OrderWindowDetails.Add(entity);
            return _dbContext.SaveChanges() > 0;
            
        }

        public bool Delete(OrderWindowDetail entity)
        {
            //var order = _dbContext.OrderWindowDetails.Find(entity.WindowDetailsId);
            _dbContext.Remove(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public IEnumerable<OrderWindowDetail> GetAll()
        {
            return _dbContext.OrderWindowDetails.ToList();
        }               

        public OrderWindowDetail GetById(int id)
        {
            return _dbContext.OrderWindowDetails.Find(id);
        }

        public bool Update(OrderWindowDetail entity)
        {
            _dbContext.OrderWindowDetails.Update(entity);
            return _dbContext.SaveChanges() > 0;
        }
    }
}

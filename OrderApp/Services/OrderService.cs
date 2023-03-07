using OrderApp.DAL;
using OrderApp.Models;
using WireMock.Admin.Mappings;

namespace OrderApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderDbContext _dbContext;
        public OrderService(OrderDbContext dbContext) 
        {
            _dbContext= dbContext;
        }
        public bool AddOrder(Order order)
        {
            bool isSave;
            try
            {                
                _dbContext.Orders.Add(order);
                var saveResult = _dbContext.SaveChanges();
                if (saveResult > 0)
                {
                    isSave = true;
                }
                else
                {
                    isSave = false;
                }   
            }
            catch
            {
                isSave= false;
            }
            return isSave;
        }

        public ResponseModel DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            return _dbContext.Orders.ToList();
        }

        public Order GetById(int id)
        {
            return _dbContext.Orders.Find(id);
        }

        public ResponseModel UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}

using OrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.BLL.Interface
{
    public interface IBaseManager<T>
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T order);
        T GetById(int id);        
        IEnumerable<T> GetAll();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.Abstraction
{
    public interface IService<T>
    {
        T GetById(string id);
    
        void Add(T entity); 

        void Update(T entity);  

        void Delete(T entity);
        List<T> GetAll();
    }
}

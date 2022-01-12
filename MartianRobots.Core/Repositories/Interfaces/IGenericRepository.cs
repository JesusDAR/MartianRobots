using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.Core.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T Get();
        int Add(T entity);
        int Update(T entity);
        int Delete(int id);
    }
}

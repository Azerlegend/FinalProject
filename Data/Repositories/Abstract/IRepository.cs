using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Abstract
{
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> GetAll();
        T Get (int id);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        T GetByName(string name);
    }
}

using Core.Entities;
using Data.Contexts;
using Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Concrete
{
    public class DruggistRepository : IDruggistRepository
    {
        static int id;
        public void Create(Druggist druggist)
        {

            DbContext.Druggists.Add(druggist);  
        }

        public Druggist Get(int id)
        {
            return DbContext.Druggists.FirstOrDefault(d => d.Id == id);
        }

        public List<Druggist> GetAll()
        {
            return DbContext.Druggists;
        }

        public void Update(Druggist druggist)
        {
            var dbdruggist = DbContext.Druggists.FirstOrDefault(g => g.Id == druggist.Id);
            if (dbdruggist != null)
            {
                dbdruggist.Id = druggist.Id;
                dbdruggist.Name = druggist.Name;
                dbdruggist.SurName = druggist.SurName;
                dbdruggist.Age = druggist.Age;
                dbdruggist.Experience = druggist.Experience;
                dbdruggist.Drugstore = druggist.Drugstore;





            }
        }
        public void Delete(Druggist druggist)
        {
            DbContext.Druggists.Remove(druggist);
        }

        public Druggist GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}

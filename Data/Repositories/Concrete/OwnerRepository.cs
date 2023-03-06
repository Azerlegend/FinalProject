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
    public class OwnerRepository : IOwnerRepository
    {
        static int id;
        public void Create(Owner owner)
        {
           
            DbContext.Owners.Add(owner);
        }


        public Owner Get(int id)
        {
            return DbContext.Owners.FirstOrDefault(o => o.Id == id);
        }

        public List<Owner> GetAll()
        {
            return DbContext.Owners;
        }

        public void Update(Owner owner)
        {
            var dbowner = DbContext.Owners.FirstOrDefault(g => g.Id == owner.Id);
            if (dbowner != null)
            {
                dbowner.Id = owner.Id;
                dbowner.Name = owner.Name;
                dbowner.Surname= owner.Surname;
                dbowner.Drugstores = owner.Drugstores;
                
            }
        }
        public void Delete(Owner owner)
        {
            DbContext.Owners.Remove(owner);
        }
        public Owner GetByName(string name) 
        {
            return DbContext.Owners.FirstOrDefault(o => o.Name.ToLower() == name.ToLower());

        }
    }
}

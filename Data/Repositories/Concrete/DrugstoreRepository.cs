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
    public class DrugstoreRepository : IDrugstoreRepository
    {
        static int id;
        public void Create(Drugstore drugstore)
        {

            DbContext.Drugstores.Add(drugstore);
        }


        public Drugstore Get(int id)
        {
            return DbContext.Drugstores.FirstOrDefault(d => d.Id == id);
        }

        public List<Drugstore> GetAll()
        {
            return DbContext.Drugstores;
        }

        public void Update(Drugstore drugstore)
        {
            var dbdrugstore = DbContext.Drugstores.FirstOrDefault(g => g.Id == drugstore.Id);
            if (dbdrugstore != null)
            {
                dbdrugstore.Id = drugstore.Id;
                dbdrugstore.Name = drugstore.Name;
                dbdrugstore.Address =  dbdrugstore.Address;
                dbdrugstore.ContactNumber = drugstore.ContactNumber;
                dbdrugstore.Druggists = dbdrugstore.Druggists;
                dbdrugstore.Drugs = dbdrugstore.Drugs;
                dbdrugstore.Owner = drugstore.Owner;
            }
        }
        public void Delete(Drugstore drugstore)
        {
            DbContext.Drugstores.Remove(drugstore);
        }
        public Drugstore GetByName(string name)                       
        {
            return DbContext.Drugstores.FirstOrDefault(d => d.Name.ToLower() == name.ToLower());

        }
        public bool IsDublicateEmail(string email)
        {
            return DbContext.Drugstores.Any(s => s.Email == email);
        }
    }
}

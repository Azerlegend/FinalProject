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
    public class DrugRepository : IDrugRepository
    {
        static int id;
        public void Create(Drug drug)
        {

            DbContext.Drugs.Add(drug);  
        }


        public Drug Get(int id)
        {
            return DbContext.Drugs.FirstOrDefault(d => d.Id == id);
        }

        public List<Drug> GetAll()
        {
            return DbContext.Drugs;

        }

        public void Update(Drug drug)
        {
var dbdrug = DbContext.Drugs.FirstOrDefault(g => g.Id == drug.Id);
            if (dbdrug != null)
            {
                dbdrug.Id = drug.Id;
                dbdrug.Name = drug.Name;
                dbdrug.Price = drug.Price;
                dbdrug.Count= drug.Count;
                dbdrug.Drugstore = drug.Drugstore;
            }
        }
        public void Delete(Drug drug)
        {
            DbContext.Drugs.Remove(drug);
        }

        public Drug GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}

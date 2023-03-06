using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts
{
    public static class DbContext
    {
        static DbContext()
        {
            Admins= new List<Admin>();
            Drugs = new List<Drug>();
            Druggists = new List<Druggist>();
            Drugstores = new List<Drugstore>();
            Owners = new List<Owner>();
        }
        public static List<Admin> Admins { get; set; }
        public static List<Drug> Drugs { get; set; }
        public static List<Druggist> Druggists { get; set;}
        public static List<Drugstore> Drugstores { get; set; }
        public static List<Owner> Owners { get;set; }


    }
}

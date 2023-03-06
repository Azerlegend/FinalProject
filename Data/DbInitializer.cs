using Core.Entities;
using Core.Helpers;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public static class DbInitializer
    {
        static int id;

        public static void SeedAdmins()
        {
            var admins = new List<Admin>
            {

                new Admin
                {
                    Id = ++id,
                    Username = "Admin1",
                    Password  = PasswordHasher.Encrypt("12345")
                    

                },

                new Admin
                {

                    Id = ++id,
                    Username = "Admin2",
                    Password= PasswordHasher.Encrypt("54321"),
                    

                },
                new Admin
                {

                    Id = ++id,
                    Username = "Admin3",
                    Password= PasswordHasher.Encrypt("6789"),


                }


            };

            DbContext.Admins.AddRange(admins);


        }
    }
}

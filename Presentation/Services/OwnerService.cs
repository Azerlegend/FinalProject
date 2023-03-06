using Core.Entities;
using Core.Helpers;
using Data.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public class OwnerService
    {
        
        private readonly DrugstoreRepository _drugstoreRepository;
        private readonly DruggistRepository _druggistRepository;
        private readonly DrugRepository _drugRepository;
        private readonly OwnerRepository _ownerRepository;

        public OwnerService()
        {
           
            _drugstoreRepository= new DrugstoreRepository();
            _ownerRepository= new OwnerRepository();
            _drugRepository= new DrugRepository();
            _druggistRepository= new DruggistRepository();
        }
        public void GetAll() 
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count == 0)
            {
                ConsoleHelper.WriteWithColor("There is no Owner", ConsoleColor.Red);

            }

            else
            {

            ConsoleHelper.WriteWithColor("=*=*=*=*=*=*=*=ALL Owners=*=*=*=*=*=*=*=", ConsoleColor.DarkCyan);
            foreach (var owner in owners)
            {
                ConsoleHelper.WriteWithColor($"Id: {owner.Id} \n Fullname: {owner.Name} {owner.Surname} \n Owner's drugstores; {owner.Drugstores}", ConsoleColor.DarkYellow);

            }
            }

        }
        int id;
        public void Create()
        {
            id++;
    
            OwnerServiceDesc: ConsoleHelper.WriteWithColor("=*=*=*=*=*=*=*=Enter Owner's Name:=*=*=*=*=*=*=*=", ConsoleColor.DarkMagenta);
            string name = Console.ReadLine();
            var owner = _ownerRepository.GetByName(name);
            if (owner is not null)
            {
                ConsoleHelper.WriteWithColor("We dont have owner in this id", ConsoleColor.Red);
                goto OwnerServiceDesc;

            }
            ConsoleHelper.WriteWithColor("=*=*=*=*=*=*=*=Enter Owner's Surname=*=*=*=*=*=*=*=", ConsoleColor.DarkMagenta);
            string surname = Console.ReadLine();
           owner = _ownerRepository.GetByName(surname);
            if (owner is not null)
            {
                ConsoleHelper.WriteWithColor("We have owner surname in this id", ConsoleColor.Red);
                goto OwnerServiceDesc;

            }

            owner = new Owner
            {
                Name = name,
                Surname = surname,
                Id= id,
            };

            _ownerRepository.Create(owner);
                ConsoleHelper.WriteWithColor($"Owner succesfully added : {owner.Id},Fullname : {owner.Name},{owner.Surname}", ConsoleColor.Green);

        }
        public void Update() 
        {
          OwnerIdDescription: GetAll();

            ConsoleHelper.WriteWithColor("=*=*=*=*=*=*=*=owner's Id=*=*=*=*=*=*=*=", ConsoleColor.Yellow);
            int id;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed ID is not correct format!", ConsoleColor.Red);
                
                goto OwnerIdDescription;
            }
            var owner = _ownerRepository.Get(id);
            if (owner is null)
            {
                ConsoleHelper.WriteWithColor("There is no any owner in this Id!", ConsoleColor.Red);
                goto OwnerIdDescription;

            }
            ConsoleHelper.WriteWithColor("=*=*=*=*=*=*=*=Enter new Name of the owner=*=*=*=*=*=*=*=", ConsoleColor.Yellow);
            string name = Console.ReadLine();
            ConsoleHelper.WriteWithColor("=*=*=*=*=*=*=*=Enter new Surname of the owner=*=*=*=*=*=*=*=", ConsoleColor.Yellow);
            string surname = Console.ReadLine();
        

            
            owner.Name = name;
            owner.Surname = surname;
            

            _ownerRepository.Update(owner);
            ConsoleHelper.WriteWithColor($" Fullname: {owner.Name} {owner.Surname} \n - successfully updated", ConsoleColor.Green);
        }
        public void Delete()
        { GetAll();
        if(_ownerRepository.GetAll().Count == 0)
            {
                ConsoleHelper.WriteWithColor("There is no owner",ConsoleColor.Red);
            }
            else
            {

        IdDescription: ConsoleHelper.WriteWithColor("=*=*=*=*=*=*=*=Enter Id=*=*=*=*=*=*=*=", ConsoleColor.DarkYellow);
            int id;
            bool isSucceded = int.TryParse(Console.ReadLine(), out id);
            if (!isSucceded)
            {
                ConsoleHelper.WriteWithColor("Id is not correct format!", ConsoleColor.Red);
                goto IdDescription;
            }
            var owner = _ownerRepository.Get(id);
            if (owner is null)
            {
                ConsoleHelper.WriteWithColor("There is no any owner in this ID!", ConsoleColor.Red);

            }
            _ownerRepository.Delete(owner);
            Console.WriteLine($"{owner.Name} {owner.Surname} - is successfully deleted", ConsoleColor.Green);
            }


        }
    }
    
}

using Core.Constants;
using Core.Entities;
using Core.Helpers;
using Data.Repositories.Abstract;
using Data.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public class DruggistService
    {
        public DruggistService()
        {
            _drugStoreRepository = new DrugstoreRepository();
            _druggistRepository = new DruggistRepository();
            _drugStoreService = new DrugStoreService();

        }
        public readonly DrugstoreRepository _drugStoreRepository;
        public readonly DruggistRepository _druggistRepository;
        public readonly DrugStoreService _drugStoreService;

        int id;
        public void Create()
        {
            if (_drugStoreRepository.GetAll().Count != 0)
            {
                id++;
                ConsoleHelper.WriteWithColor("Enter name of the Druggist", ConsoleColor.Cyan);
                string name = Console.ReadLine();

                ConsoleHelper.WriteWithColor("Enter surname of the Druggist", ConsoleColor.Cyan);
                string surname = Console.ReadLine();

            DruggistAgeDesc: ConsoleHelper.WriteWithColor("Enter age of the Druggist", ConsoleColor.Cyan);
                int age;
                bool issucceeded = int.TryParse(Console.ReadLine(), out age);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Age is not correct format", ConsoleColor.Red);
                    goto DruggistAgeDesc;
                }

               



            DruggistExperienceDesc: ConsoleHelper.WriteWithColor("Enter experience of the Druggist", ConsoleColor.Cyan);

                int experience;
                issucceeded = int.TryParse(Console.ReadLine(), out experience);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Experience is not correct format", ConsoleColor.Red);
                    goto DruggistExperienceDesc;
                }



                if (age - experience < 18)
                {
                    ConsoleHelper.WriteWithColor("Age of a druggist should be at least 18 years more than experience", ConsoleColor.Red);
                    goto DruggistExperienceDesc;
                }

                _drugStoreService.GetAll();
            DrugStoreIdDesc: ConsoleHelper.WriteWithColor("Enter Id of the drugStore where the druggist works", ConsoleColor.Cyan);
                int drugStoreId;
                issucceeded = int.TryParse(Console.ReadLine(), out drugStoreId);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Id of the Drug store is not  correct format", ConsoleColor.Red);
                    goto DrugStoreIdDesc;
                }

                var drugStore = _drugStoreRepository.Get(drugStoreId);
                if (drugStore is null)
                {
                    ConsoleHelper.WriteWithColor("There is not any drugstore in this id", ConsoleColor.Red);
                    goto DrugStoreIdDesc;
                }

                var druggist = new Druggist
                {
                    Id = id,
                    Name = name,
                    SurName = surname,
                    Age = age,
                    Experience = experience,
                    Drugstore = drugStore
                };

                _druggistRepository.Create(druggist);

                ConsoleHelper.WriteWithColor($"Druggist(Id: {druggist.Id}, Name: {druggist.Name}, Surname: {druggist.SurName}, Age: {druggist.Age}, Experience: {druggist.Experience}, DrugStore Id: {druggist.Drugstore.Id}, DrugStore Name: {druggist.Drugstore.Name}) has been created successfully", ConsoleColor.Green);
            }
            else
            {
                ConsoleHelper.WriteWithColor("First, you should create a drug store", ConsoleColor.Red);
            }

        }

        public void Update()
        {
            if (_druggistRepository.GetAll().Count == 0)
            {
                ConsoleHelper.WriteWithColor("There is not any Druggist to update", ConsoleColor.Red);
            }
            else
            {
                GetAll();
            UpdateDruggistDescription: ConsoleHelper.WriteWithColor("Enter Id of the druggist that you want to update", ConsoleColor.Blue);
                int druggistId;
                bool issucceeded = int.TryParse(Console.ReadLine(), out druggistId);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Druggist Id is not in a correct format", ConsoleColor.Red);
                    goto UpdateDruggistDescription;
                }

                var druggist = _druggistRepository.Get(druggistId);
                if (druggist is null)
                {
                    ConsoleHelper.WriteWithColor("There is not any druggist in this Id", ConsoleColor.Red);
                    goto UpdateDruggistDescription;
                }

                ConsoleHelper.WriteWithColor("Enter new name", ConsoleColor.Cyan);
                string name = Console.ReadLine();

                ConsoleHelper.WriteWithColor("Enter new surname", ConsoleColor.Cyan);
                string surname = Console.ReadLine();

            AgeDesc: ConsoleHelper.WriteWithColor("Enter new age", ConsoleColor.Cyan);
                int age;
                issucceeded = int.TryParse(Console.ReadLine(), out age);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Age is not in a correct format", ConsoleColor.Red);
                    goto AgeDesc;
                }
                if (age < 18 || age > 65)
                {
                    ConsoleHelper.WriteWithColor("Age of a druggist should not be less than 18 or more than 65", ConsoleColor.Red);
                    goto AgeDesc;
                }

            ExperienceDesc: ConsoleHelper.WriteWithColor("Enter new experience", ConsoleColor.Cyan);
                int experience;
                issucceeded = int.TryParse(Console.ReadLine(), out experience);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Experience is not in a correct format", ConsoleColor.Red);
                    goto ExperienceDesc;
                }

                if (age - experience < 18)
                {
                    ConsoleHelper.WriteWithColor("Age of a druggist should be at least 18 years more than experience", ConsoleColor.Red);
                    goto ExperienceDesc;
                }

                _drugStoreService.GetAll();
            DrugStoreDescription: ConsoleHelper.WriteWithColor("Enter id of the new drug store", ConsoleColor.Cyan);

                int drugStoreId;
                issucceeded = int.TryParse(Console.ReadLine(), out drugStoreId);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Drug store Id is not in a correct format", ConsoleColor.Red);
                    goto DrugStoreDescription;
                }

                var drugStore = _drugStoreRepository.Get(drugStoreId);
                if (drugStore is null)
                {
                    ConsoleHelper.WriteWithColor("There is not any drug store in this id", ConsoleColor.Red);
                    goto DrugStoreDescription;
                }

                druggist.Name = name;
                druggist.Name = surname;
                druggist.Age = age;
                druggist.Experience = experience;
                druggist.Drugstore = drugStore;

                _druggistRepository.Update(druggist);

                ConsoleHelper.WriteWithColor($"Druggist has been updated successfully. New name: {druggist.Name}, New surname: {druggist.SurName}, New age: {druggist.Age}, new experience: {druggist.Experience}, Id of the new DrugStore: {druggist.Drugstore.Id}, Name of the new DrugStore: {druggist.Drugstore.Name}", ConsoleColor.Green);
            }
        }

        public void Delete()
        {
            if (_druggistRepository.GetAll().Count != 0)
            {
                GetAll();
            DeleteDruggistDesc: ConsoleHelper.WriteWithColor("Enter Id of the Druggist that you want to delete", ConsoleColor.Blue);
                int druggistId;
                bool issucceeded = int.TryParse(Console.ReadLine(), out druggistId);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Druggist Id is not in a correct format", ConsoleColor.Red);
                    goto DeleteDruggistDesc;
                }

                var druggist = _druggistRepository.Get(druggistId);
                if (druggist is null)
                {
                    ConsoleHelper.WriteWithColor("There is not any druggist in this id", ConsoleColor.Red);
                    goto DeleteDruggistDesc;
                }

                _druggistRepository.Delete(druggist);

                ConsoleHelper.WriteWithColor($"Druggist(Id: {druggist.Id}, Name: {druggist.Name}, Surname: {druggist.SurName}, Age: {druggist.Age}, Experience: {druggist.Experience}, DrugStore Id: {druggist.Drugstore.Id}, DrugStore Name: {druggist.Drugstore.Name}) has been deleted successfully", ConsoleColor.Green);

            }
            else
            {
                ConsoleHelper.WriteWithColor("There is not any druggists to delete", ConsoleColor.Red);
            }
        }

        public void GetAll()
        {
            var druggists = _druggistRepository.GetAll();
            if (druggists.Count == 0)
            {
                ConsoleHelper.WriteWithColor("There is not any druggists to get", ConsoleColor.Red);
            }
            else
            {
                ConsoleHelper.WriteWithColor("--All Druggists--", ConsoleColor.Blue);

                foreach (var druggist in druggists)
                {
                    ConsoleHelper.WriteWithColor($"Id: {druggist.Id}, Name: {druggist.Name}, Surname: {druggist.SurName}, Age: {druggist.Age}, Experience: {druggist.Experience}, DrugStore Id: {druggist.Drugstore.Id}, DrugStore Name: {druggist.Drugstore.Name}", ConsoleColor.Cyan);
                }
            }
        }

        public void GetAllByDrugStore()
        {
            if (_druggistRepository.GetAll().Count == 0)
            {
                ConsoleHelper.WriteWithColor("There is not any druggist to get", ConsoleColor.Red);
            }
            else
            {
                _drugStoreService.GetAll();
            DrugStoreIdDescription: ConsoleHelper.WriteWithColor("Enter Id of the Drug Store", ConsoleColor.Cyan);
                int drugStoreId;
                bool issucceeded = int.TryParse(Console.ReadLine(), out drugStoreId);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Drug store Id is not in a correct format", ConsoleColor.Red);
                    goto DrugStoreIdDescription;
                }

                var drugStore = _drugStoreRepository.Get(drugStoreId);
                if (drugStore is null)
                {
                    ConsoleHelper.WriteWithColor("There is not any drug store in this id", ConsoleColor.Red);
                    goto DrugStoreIdDescription;
                }

                var druggists = _druggistRepository.GetAll().Where(d => d.Drugstore == drugStore);
                if (druggists.Count() == 0)
                {
                    ConsoleHelper.WriteWithColor("There is not any druggist in this drug store", ConsoleColor.Red);
                    goto DrugStoreIdDescription;
                }

                foreach (var druggist in druggists)
                {
                    ConsoleHelper.WriteWithColor($"Id: {druggist.Id}, Name: {druggist.Name}, Surname: {druggist.SurName}, Age: {druggist.Age}, Experience: {druggist.Experience}, DrugStore Id: {druggist.Drugstore.Id}, DrugStore Name: {druggist.Drugstore.Name}", ConsoleColor.Cyan);

                }
            }
        }
    }
}

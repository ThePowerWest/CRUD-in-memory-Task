using ApplicationCore.Entities.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class MainContextSeed
    {
        public static async Task SeedAsync(MainContext mainContext)
        {
            try
            {
                if (!await mainContext.Profiles.AnyAsync())
                {
                    await mainContext.Workers.AddRangeAsync(
                        GetWorkers());

                    await mainContext.SaveChangesAsync();
                }
            }
            catch
            {

                await SeedAsync(mainContext);
                throw;
            }
        }


        static IEnumerable<Worker> GetWorkers()
        {
            return new List<Worker>
            {
                new Worker
                {
                    Id=1,
                    Profile= new Profile
                    {
                        Id = 1,
                        Fullname = "Пупкин Василий Васильевич",
                        Date = new DateTime(1992, 12, 28).ToShortDateString(),
                        Email = "ForExample@gmail.com",
                        Phone = "89995552227"
                    },
                    Position="Junior-разработчик",
                    Salary=40000,
                    Subdivision="Web"
                },
                new Worker
                {
                    Id = 2,
                    Profile = new Profile
                    {
                        Id = 2,
                        Fullname = "Захаров Денис Игоревич",
                        Date = new DateTime(1989, 10, 30).ToShortDateString(),
                        Email = "ForExample2@gmail.com",
                        Phone = "85553338877"
                    },
                    Position = "Менеджер",
                    Salary = 55000,
                    Subdivision = "Management"
                },
                new Worker
                {
                    Id = 3,
                    Profile = new Profile
                    {
                        Id = 3,
                        Fullname = "Егоров Дмитрий Александрович",
                        Date = new DateTime(1984, 08, 18).ToShortDateString(),
                        Email = "ForExample3@gmail.com",
                        Phone = "84447774519"
                    },
                    Position = "Менеджер",
                    Salary = 35000,
                    Subdivision = "Management"
                },
                new Worker
                {
                    Id = 4,
                    Profile = new Profile
                    {
                        Id = 4,
                        Fullname = "Королев Виталий Богданович",
                        Date = new DateTime(1978, 1, 18).ToShortDateString(),
                        Email = "ForExample4@gmail.com",
                        Phone = "85553338877"
                    },
                    Position = "Senior-разработчик",
                    Salary = 170000,
                    Subdivision = "BackEnd"
                },
                new Worker
                {
                    Id = 5,
                    Profile = new Profile
                    {
                        Id = 5,
                        Fullname = "Иванов Соломон Павлович",
                        Date = new DateTime(1979, 3, 26).ToShortDateString(),
                        Email = "ForExample5@gmail.com",
                        Phone = "85553338877"
                    },
                    Position = "Менеджер",
                    Salary = 55000,
                    Subdivision = "Management"
                }

            };
        }

    }
}

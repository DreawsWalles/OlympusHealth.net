using Business.Enties;
using Business.Enties.Address;
using Business.Enties.MedicModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var contex = new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>()))
            {
                if(!contex.SysAdmins.Any())
                {
                    SysAdmin tmp = new SysAdmin()
                    {
                        Login = "admin",
                        Password = "admin"
                    };
                    tmp.Password = new Microsoft.AspNetCore.Identity.PasswordHasher<SysAdmin>().HashPassword(tmp, "admin");
                    contex.Add(tmp);
                }
                if(!contex.Genders.Any())
                {
                    contex.Add(new Gender()
                    {
                        Name = "Мужской"
                    });
                    contex.Add(new Gender()
                    {
                        Name = "Женский"
                    });
                }
                if(!contex.Roles.Any())
                {
                    contex.AddRange(
                        new Role()
                        {
                            Name = "Doctor"
                        },
                        new Role()
                        {
                            Name = "HeadOfDepartment"
                        },
                        new Role()
                        {
                            Name = "MedicRegistrator"
                        },
                        new Role()
                        {
                            Name = "Chief of medical"
                        });
                }

                if(!contex.Accesses.Any())
                {
                    contex.AddRange(
                        new Access()
                        {
                            Name = "default"
                        },
                        new Access()
                        {
                            Name = "canAccept"
                        });
                }
                if(!contex.Countries.Any())
                {
                    contex.Add(
                        new Country()
                        {
                            Name = "Россия",
                            Regions = new List<Region>()
                            {
                                new Region()
                                {
                                    Name = "Воронежская обл",
                                    Citys = new List<City>()
                                    {
                                        new City()
                                        {
                                            Name = "г Воронеж",
                                            Streets = new List<Street>()
                                            {
                                                new Street()
                                                {
                                                    Name = "ул Ленинградская",
                                                    NumberOfHouse = "55А"
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        });
                }
                contex.SaveChanges();
            }
        }
    }
}

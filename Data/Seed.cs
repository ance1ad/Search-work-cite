using FindWorkApp.Data;
using FindWorkApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

namespace FindWorkApp.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();


                if (!context.Addresses.Any())
                {
                    context.Addresses.AddRange(new List<Address>()
                    {

                        new Address()
                        {
                            City = "г. Белгород, ул. Мраморная, дом 13а"
                        },
                        new Address()
                        {
                            City = "г. Белгород, ул. Градиентная, дом 13а"
                        },
                    });
                    context.SaveChanges();
                }

                if (!context.Vacancies.Any())
                {
                    context.Vacancies.AddRange(new List<Vacancy>()
                    {
                        new Vacancy()
                        {
                            WorkExpirienceAge = 1,
                            Salary = 50000,
                            ProgrammingLanguage = "C#",
                            Description = "Требуется разработчик десктопных приложений на Xamarin",
                            Image = "https://sun9-36.userapi.com/impg/hevz9A-krQCv391t3kBBoXgQRXHkMqg_H1eVuQ/TkrXBgWW-zA.jpg?size=1250x702&quality=96&sign=dd32bc8d9b1c825c8bc3220003b57eeb&type=album",
                            Email = "company1@gmail.com",
                            AddressId = 1,
                         },
                        new Vacancy()
                         {
                            WorkExpirienceAge = 2,
                            Salary = 35000,
                            ProgrammingLanguage = "Python",
                            Description = "Требуется тестировщик различных программных продуктов, необходимо знание основ для тестирования и хорошая усидчивость",
                            Image = "https://sun9-9.userapi.com/impg/o5TeRISt32T7XfTG4cCGWzT0vtS4p7IDqKvd2A/q60amjtbIoo.jpg?size=1075x715&quality=96&sign=7e26c075b569fec036fdee28f3b39892&type=album",
                            Email = "company2@gmail.com",
                            AddressId = 2,
                         },
                        new Vacancy()
                         {
                            WorkExpirienceAge = 1,
                            Salary = 150000,
                            ProgrammingLanguage = "Python",
                            Description = "Требуется разработчик нейронных сетей в банковскую сферу, требование: сдача за семестр всех лаб по ТОИ в Шухово, знание на уверенном уровне TensorFLow и Keras",
                            Image = "https://sun9-23.userapi.com/impg/V1I3kq0JEzMCsSQsz_jiSUq65zYhDYjtRl7v_w/d77HuBe4tXk.jpg?size=1153x648&quality=96&sign=a02f475e013eec4fcdfb1b5f735d584b&type=album",
                            Email = "company3@gmail.com",
                            AddressId = 3,
                         },
                    });
                    context.SaveChanges();
                }
                if (!context.JobResumes.Any())
                {
                    context.JobResumes.AddRange(new List<JobResume>()
                    {
                        new JobResume()
                        {
                            CareerObjective = "Разработчик игр на Unity",
                            AddressId = 4,
                            Salary = 40000,
                            FullName = "Бирюков А.П",
                            Gender = "мужской",
                            PhoneNumber = "+79042321156",
                            Education = "Белгородский индустриальный колледж, 09.03.02",
                            Description = "Усидчивый, харизматичный, молодой"
                         },
                        new JobResume()
                         {
                            CareerObjective = "Разработчик шейдеров",
                            AddressId = 5,
                            Salary = 35000,
                            FullName = "Артюх С.В",
                            Gender = "мужской",
                            PhoneNumber = "+79207292315",
                            Education = "Белгородский индустриальный колледж, 09.03.02",
                            Description = "Энергичный, веселый, хороший вкус в музыке"
                         },
                        new JobResume()
                        {
                            CareerObjective = "Разработчик инди игр",
                            AddressId = 6,
                            Salary = 30000,
                            FullName = "Францев Д.Л",
                            Gender = "мужской",
                            PhoneNumber = "+79502283133",
                            Education = "БГТУ им. Шухова, 15.03.04",
                            Description = "Много всего знает, работал ранее с Unity, хороший уровень С#"
                        },
                        new JobResume()
                        {
                            CareerObjective = "Разработчик сайтов на Python",
                            AddressId = 6,
                            Salary = 45000,
                            FullName = "Зотов В.С",
                            Gender = "мужской",
                            PhoneNumber = "+79526282354",
                            Education = "Белгородский индустриальный колледж, 09.03.02",
                            Description = "Стрессоустойчивый, хорошо знает Python"
                         },
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "eugene@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "eugene",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            City = "Белгород",
                        }
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@mail.ru";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            City = "Белгород",
                        }
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
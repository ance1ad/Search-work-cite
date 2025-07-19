using FindWorkApp.Data;
using FindWorkApp.Interfaces;
using FindWorkApp.Models;
using FindWorkApp.Repository;
using FindWorkApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace FindWorkApp.Controllers
{
    public class VacancyController : Controller
    {
        private readonly IVacancyRepository _vacancyRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public VacancyController(IVacancyRepository vacancyRepository, IHttpContextAccessor httpContextAccessor)
        {
            _vacancyRepository = vacancyRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Соискателям()
        {
            IEnumerable<Vacancy> vacancies = await _vacancyRepository.GetAll();
            return View(vacancies);
        }

        public async Task<IActionResult> VacancyDetail(int id) // получаем id
        {
            Vacancy vacancy = await _vacancyRepository.GetByIdAsync(id);
            return View(vacancy);
        }

        public IActionResult Create()
        {
            var curUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            var createVacancyViewModel = new CreateVacancyViewModel { AppUserId = curUserId };
            return View(createVacancyViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVacancyViewModel vacancyVM)
        {
            if (ModelState.IsValid)
            {
                DateTime currentDate = DateTime.Now;
                CultureInfo russianCulture = new CultureInfo("ru-RU");
                string formattedDate = currentDate.ToString("d MMMM yyyy", russianCulture);
                var vacancy = new Vacancy
                {
                    WorkExpirienceAge = vacancyVM.WorkExpirienceAge,
                    Salary = vacancyVM.Salary,
                    ProgrammingLanguage = vacancyVM.ProgrammingLanguage,
                    Description = vacancyVM.Description,
                    Image = vacancyVM.Image,
                    Email = vacancyVM.Email,
                    DistanceWork = vacancyVM.DistanceWork,
                    CompanyInfo = vacancyVM.CompanyInfo,
                    Date = formattedDate,
                    AppUserId = vacancyVM.AppUserId,
                    AddressId = vacancyVM.AddressId,
                    Address = new Address
                    {
                        City = vacancyVM.Address.City,
                    }
                };
                _vacancyRepository.Add(vacancy);
                return RedirectToAction("Dashboard", "Dashboard");
            }
            return View(vacancyVM);
        }


        public async Task<IActionResult> Edit(int id)
        {
            DateTime currentDate = DateTime.Now;
            CultureInfo russianCulture = new CultureInfo("ru-RU");
            string formattedDate = currentDate.ToString("d MMMM yyyy", russianCulture);
            var vacancy = await _vacancyRepository.GetByIdAsync(id);
            if (vacancy == null) return View("Error");
            var vacancyVM = new EditVacancyViewModel
            {
                WorkExpirienceAge = vacancy.WorkExpirienceAge,
                Salary = vacancy.Salary,
                ProgrammingLanguage = vacancy.ProgrammingLanguage,
                AppUserId = vacancy.AppUserId,
                Date = formattedDate,
                Description = vacancy.Description,
                Image = vacancy.Image,
                Email = vacancy.Email,
                DistanceWork = vacancy.DistanceWork,
                CompanyInfo = vacancy.CompanyInfo,
                AddressId = vacancy.AddressId,
                Address = new Address
                {
                    City = vacancy.Address.City,
                }


            };
            return View(vacancyVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditVacancyViewModel vacancyVM)
        {
            DateTime currentDate = DateTime.Now;
            CultureInfo russianCulture = new CultureInfo("ru-RU");
            string formattedDate = currentDate.ToString("d MMMM yyyy", russianCulture);
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Ошибка в редактировании вакансии");
                return View("Edit", vacancyVM);
            }
            var userVacancy = await _vacancyRepository.GetByIdAsyncNoTracking(id);
            if (userVacancy != null)
            {
                var vacancy = new Vacancy
                {
                    Id = vacancyVM.Id,
                    WorkExpirienceAge = vacancyVM.WorkExpirienceAge,
                    Salary = vacancyVM.Salary,
                    Date = formattedDate,
                    ProgrammingLanguage = vacancyVM.ProgrammingLanguage,
                    Description = vacancyVM.Description,
                    AppUserId = vacancyVM.AppUserId,
                    DistanceWork = vacancyVM.DistanceWork,
                    CompanyInfo = vacancyVM.CompanyInfo,
                    Image = vacancyVM.Image,
                    Email = vacancyVM.Email,
                    AddressId = vacancyVM.AddressId,
                    Address = new Address
                    {
                        City = vacancyVM.Address.City,
                    }
                };
                _vacancyRepository.Update(vacancy);
                return RedirectToAction("Dashboard", "Dashboard");
            }
            else return View(vacancyVM);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var vacancyDetail = await _vacancyRepository.GetByIdAsync(id);
            if (vacancyDetail == null) return View("Error");
            return View(vacancyDetail);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteVacancy(int id)
        {
            var vacancyDetail = await _vacancyRepository.GetByIdAsync(id);
            if (vacancyDetail == null) return View("Error");
            _vacancyRepository.Delete(vacancyDetail);
            return RedirectToAction("Dashboard", "Dashboard");
        }
    }
}

using FindWorkApp.Data;
using FindWorkApp.Interfaces;
using FindWorkApp.Models;
using FindWorkApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace FindWorkApp.Controllers
{
    public class JobResumeController : Controller
    {
        private readonly IJobResumeRepository _jobResumeRepository;
        private readonly IHttpContextAccessor _httpContextAccessor; 

        public JobResumeController(IJobResumeRepository jobResumeRepository, IHttpContextAccessor httpContextAccessor)
        {
            _jobResumeRepository = jobResumeRepository; 
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Работодателям()
        {
            // вернем вакансию из бд
            IEnumerable<JobResume> jobResumes = await _jobResumeRepository.GetAll();
            return View(jobResumes);
        }

        public async Task<IActionResult> JobResumeDetail(int id) // получаем id
        {
            JobResume resume = await _jobResumeRepository.GetByIdAsync(id);
            return View(resume);
        }

        public IActionResult Create()
        {
            var curUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            var createJobResumeViewModel = new CreateJobResumeViewModel { AppUserId = curUserId };
            return View(createJobResumeViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateJobResumeViewModel resumeVM)
        {
            if (ModelState.IsValid) 
            {
                DateTime currentDate = DateTime.Now;
                CultureInfo russianCulture = new CultureInfo("ru-RU");
                string formattedDate = currentDate.ToString("d MMMM yyyy", russianCulture);
                var jobResume = new JobResume
                {
                    CareerObjective = resumeVM.CareerObjective,
                    WorkExpirience = resumeVM.WorkExpirience,
                    Salary = resumeVM.Salary,
                    AppUserId = resumeVM.AppUserId,
                    Email = resumeVM.Email,
                    Age = resumeVM.Age,
                    Date = formattedDate,
                    FullName = resumeVM.FullName,
                    Gender = resumeVM.Gender,
                    PhoneNumber = resumeVM.PhoneNumber,
                    Education = resumeVM.Education,
                    Description = resumeVM.Description,
                    Image = resumeVM.Image,
                    Address = new Address
                    {
                        City = resumeVM.Address.City,
                    }
                };
                _jobResumeRepository.Add(jobResume);
                return RedirectToAction("Dashboard", "Dashboard");
            }
            return View(resumeVM);
            
        }

        public async Task<IActionResult> Edit(int id)
        {
            DateTime currentDate = DateTime.Now;
            CultureInfo russianCulture = new CultureInfo("ru-RU");
            string formattedDate = currentDate.ToString("d MMMM yyyy", russianCulture);
            var jobResume = await _jobResumeRepository.GetByIdAsync(id);
            if (jobResume == null) return View("Error");
            var jobResumeVM = new EditJobResumeViewModel
            {
                CareerObjective = jobResume.CareerObjective,
                WorkExpirience = jobResume.WorkExpirience,
                AddressId = jobResume.AddressId,
                Salary = jobResume.Salary,
                Age = jobResume.Age,
                Email = jobResume.Email,
                Date = formattedDate,
                AppUserId = jobResume.AppUserId,
                FullName = jobResume.FullName,
                Gender = jobResume.Gender,
                PhoneNumber = jobResume.PhoneNumber,
                Education = jobResume.Education,
                Description = jobResume.Description,
                Image = jobResume.Image,
                Address = new Address
                {
                    City = jobResume.Address.City,
                }
            };
            return View(jobResumeVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditJobResumeViewModel jobResumeVM)
        {
            DateTime currentDate = DateTime.Now;
            CultureInfo russianCulture = new CultureInfo("ru-RU");
            string formattedDate = currentDate.ToString("d MMMM yyyy", russianCulture);
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Ошибка в редактировании резюме");
                return View("Edit", jobResumeVM);
            }
            var userJobResume = await _jobResumeRepository.GetByIdAsyncNoTracking(id);
            if (userJobResume != null)
            {
                var jobResume = new JobResume
                {
                    Id = jobResumeVM.Id,
                    CareerObjective = jobResumeVM.CareerObjective,
                    WorkExpirience = jobResumeVM.WorkExpirience,
                    Salary = jobResumeVM.Salary,
                    Age = jobResumeVM.Age,
                    Date = formattedDate,
                    AppUserId = jobResumeVM.AppUserId,
                    FullName = jobResumeVM.FullName,
                    Email = jobResumeVM.Email,
                    Gender = jobResumeVM.Gender,
                    PhoneNumber = jobResumeVM.PhoneNumber,
                    Education = jobResumeVM.Education,
                    Description = jobResumeVM.Description,
                    Image = jobResumeVM.Image,
                    Address = new Address
                    {
                        City = jobResumeVM.Address.City,
                    }

                };
                _jobResumeRepository.Update(jobResume);
                return RedirectToAction("Dashboard", "Dashboard");
            }
            else return View(jobResumeVM);
            
           
        }

        public async Task<IActionResult> Delete(int id)
        {
            var resumeDetail = await _jobResumeRepository.GetByIdAsync(id);
            if (resumeDetail == null) return View("Error");
            return View(resumeDetail);
;       }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteJobResume(int id)
        {
            var resumeDetail = await _jobResumeRepository.GetByIdAsync(id);
            if (resumeDetail == null) return View("Error");
            _jobResumeRepository.Delete(resumeDetail);
            return RedirectToAction("Dashboard", "Dashboard");
        }
    }
}

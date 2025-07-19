using FindWorkApp.Data;
using FindWorkApp.Interfaces;
using FindWorkApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FindWorkApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardController(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public async Task<IActionResult> Dashboard()
        {
            var userJobResymes = await _dashboardRepository.GetAllUserJobResume();
            var userVacancies = await _dashboardRepository.GetAllUserVacancy();
            var dashboardViewModel = new DashboardViewModel()
            {
                Resumes = userJobResymes,
                Vacancies = userVacancies,
            };
            return View(dashboardViewModel);
        }
    }
}

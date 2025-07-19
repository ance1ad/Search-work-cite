using FindWorkApp.Data;
using FindWorkApp.Interfaces;
using FindWorkApp.Models;

namespace FindWorkApp.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }



        public async Task<List<JobResume>> GetAllUserJobResume()
        {
            var curUser = _httpContextAccessor.HttpContext?.User;
            var userJobResumes = _context.JobResumes.Where(r => r.AppUser.Id == curUser.GetUserId());
            return userJobResumes.ToList();
        }

        public async Task<List<Vacancy>> GetAllUserVacancy()
        {
            var curUser = _httpContextAccessor.HttpContext?.User;
            var userVacansies= _context.Vacancies.Where(r => r.AppUser.Id == curUser.GetUserId());
            return userVacansies.ToList();
        }
    }
}

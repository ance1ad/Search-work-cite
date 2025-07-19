using FindWorkApp.Models;

namespace FindWorkApp.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Vacancy>> GetAllUserVacancy();
        Task<List<JobResume>> GetAllUserJobResume();
    }
}

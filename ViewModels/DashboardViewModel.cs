using FindWorkApp.Models;

namespace FindWorkApp.ViewModels
{
    public class DashboardViewModel
    {
        public List<JobResume> Resumes { get; set; }
        public List<Vacancy> Vacancies { get; set; }
    }
}

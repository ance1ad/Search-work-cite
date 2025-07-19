using FindWorkApp.Models;

namespace FindWorkApp.Interfaces
{
    public interface IVacancyRepository
    {
        Task<IEnumerable<Vacancy>> GetAll();
        Task<Vacancy> GetByIdAsync(int id); // для тех кто хочет получить id
        Task<Vacancy> GetByIdAsyncNoTracking(int id); // для тех кто хочет получить id
        Task<IEnumerable<Vacancy>> GetVacancyByCity(string city);
        Task<IEnumerable<Vacancy>> GetVacancyByExpirience(int expirience);
        Task<IEnumerable<Vacancy>> GetVacancyByProgrammingLanguage(string progrLanguage);
        bool Add(Vacancy vacancy);
        bool Update(Vacancy vacancy);
        bool Delete(Vacancy vacancy);
        bool Save();

    }
}

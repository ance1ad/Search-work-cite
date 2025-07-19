using FindWorkApp.Data;
using FindWorkApp.Interfaces;
using FindWorkApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FindWorkApp.Repository
{
    public class VacancyRepository : IVacancyRepository
    {
        private readonly ApplicationDbContext _context;
        public VacancyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        

        public bool Add(Vacancy vacancy)
        {
            _context.Add(vacancy);
            return Save();
        }

        public bool Delete(Vacancy vacancy)
        {
            _context.Remove(vacancy);
            return Save();
        }

        // асинхронно создаем процесс для получения списков
        public async Task<IEnumerable<Vacancy>> GetAll()
        {
            return await _context.Vacancies.Include(a => a.Address).ToListAsync();
        }

        // получаем только 1 значение
        public async Task<Vacancy> GetByIdAsync(int id)
        {
            return await _context.Vacancies.Include(a => a.Address).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Vacancy> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Vacancies.Include(a => a.Address).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Vacancy>> GetVacancyByCity(string city)
        {
            return await _context.Vacancies.Where(c=> c.Address.City.Contains(city)).ToListAsync();
        }

        // фильтр для получения ванаский по опыту работы
        public async Task<IEnumerable<Vacancy>> GetVacancyByExpirience(int expirience)
        {
            return await _context.Vacancies.Where(c => c.WorkExpirienceAge == expirience).ToListAsync();
        }

        // фильтр для получения ванаский по языку программирования
        public async Task<IEnumerable<Vacancy>> GetVacancyByProgrammingLanguage(string progrLanguage)
        {
            return await _context.Vacancies.Where(c => c.ProgrammingLanguage == progrLanguage).ToListAsync();
        }

        public bool Save()
        {
            var _saved = _context.SaveChanges();
            return _saved > 0 ? true : false;
        }

        public bool Update(Vacancy vacancy)
        {
            _context.Update(vacancy);
            return Save();
        }
    }
}

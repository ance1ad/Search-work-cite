using FindWorkApp.Data;
using FindWorkApp.Interfaces;
using FindWorkApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FindWorkApp.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;
        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Company company)
        {
            _context.Add(company);
            return Save();
        }

        public bool Delete(Company company)
        {
            _context.Remove(company);
            return Save();
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _context.Companies.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Company> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Companies.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Company>> GetCompanyByCity(string cities)
        {
            return await _context.Companies.Where(c => c.Cities == cities).ToListAsync();
        }

        public async Task<IEnumerable<Company>> GetCompanyByCount(int count)
        {
            return await _context.Companies.Where(c => c.Count == count).ToListAsync();
        }

        public bool Save()
        {
            var _saved = _context.SaveChanges();
            return _saved > 0 ? true : false;
        }

        public bool Update(Company company)
        {
            _context.Update(company);
            return Save();
        }
    }
}

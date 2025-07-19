using FindWorkApp.Data;
using FindWorkApp.Interfaces;
using FindWorkApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FindWorkApp.Repository
{
    public class JobResumeRepository : IJobResumeRepository
    {

        private readonly ApplicationDbContext _context;
        public JobResumeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(JobResume jobresume)
        {
            _context.Add(jobresume);
            return Save();
        }

        public bool Delete(JobResume jobresume)
        {
            _context.Remove(jobresume);
            return Save();
        }
        
        public async Task<IEnumerable<JobResume>> GetAll()
        {
            return await _context.JobResumes.Include(i => i.Address).ToListAsync();
        }

        public async Task<JobResume> GetByIdAsync(int id)
        {
            return await _context.JobResumes.Include(i => i.Address).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<JobResume> GetByIdAsyncNoTracking(int id)
        {
            return await _context.JobResumes.Include(i => i.Address).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<JobResume>> GetJobResumeByCareer(string career)
        {
            return await _context.JobResumes.Where(c => c.CareerObjective == career).ToListAsync();
        }

        public async Task<IEnumerable<JobResume>> GetJobResumeByCity(string city)
        {
            return await _context.JobResumes.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }

        public async Task<IEnumerable<JobResume>> GetJobResumeByExpirience(int workExpirience)
        {
            return await _context.JobResumes.Where(c => c.WorkExpirience == workExpirience).ToListAsync();
        }

        public bool Save()
        {
            var _saved = _context.SaveChanges();
            return _saved > 0 ? true : false;
        }

        public bool Update(JobResume jobresume)
        {
            _context.Update(jobresume);
            return Save();
        }
    }
}

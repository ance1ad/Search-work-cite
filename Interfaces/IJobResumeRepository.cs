using FindWorkApp.Models;

namespace FindWorkApp.Interfaces
{
    public interface IJobResumeRepository
    {
        Task<IEnumerable<JobResume>> GetAll();
        Task<JobResume> GetByIdAsync(int id); // для тех кто хочет получить id
        Task<JobResume> GetByIdAsyncNoTracking(int id); // 
        Task<IEnumerable<JobResume>> GetJobResumeByCity(string city);
        Task<IEnumerable<JobResume>> GetJobResumeByExpirience(int workExpirience);
        Task<IEnumerable<JobResume>> GetJobResumeByCareer(string career);
        bool Add(JobResume jobresume);
        bool Update(JobResume jobresume);
        bool Delete(JobResume jobresume);
        bool Save();
    }
}

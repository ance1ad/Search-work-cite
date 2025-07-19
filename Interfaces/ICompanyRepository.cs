using FindWorkApp.Models;

namespace FindWorkApp.Interfaces
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAll();
        Task<Company> GetByIdAsync(int id); // для тех кто хочет получить id
        Task<Company> GetByIdAsyncNoTracking(int id); // 
        Task<IEnumerable<Company>> GetCompanyByCity(string city);
        Task<IEnumerable<Company>> GetCompanyByCount(int count);
        bool Add(Company company);
        bool Update(Company company);
        bool Delete(Company company);
        bool Save();
    }
}

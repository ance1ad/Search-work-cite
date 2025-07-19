using Microsoft.AspNetCore.Mvc;
using FindWorkApp.Data;
using FindWorkApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FindWorkApp.Interfaces;
using FindWorkApp.Repository;
using FindWorkApp.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FindWorkApp.Controllers
{
    public class CompanyController : Controller
    {

        private readonly ICompanyRepository _companyRepository;
        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task<IActionResult> Company()
        {
            // вернем компанию из бд
            IEnumerable<Company> companies = await _companyRepository.GetAll();
            return View(companies);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Company company)
        {
            if (!ModelState.IsValid) 
            {
                return View(company);
            }
            _companyRepository.Add(company);
            return RedirectToAction("Company");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            if (company == null) return View("Error");
            var companyVM = new EditCompanyViewModel
            {
                Name = company.Name,
                Type = company.Type,
                Description = company.Description,
                Count = company.Count,
                Image = company.Image,
                OfficialSite = company.OfficialSite,
                Cities = company.Cities,
            };
            return View(companyVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditCompanyViewModel companyVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Ошибка в редактировании данных о компании");
                return View("Edit", companyVM);
            }
            var userCompany = await _companyRepository.GetByIdAsyncNoTracking(id);
            if (userCompany != null)
            {
                var company = new Company
                {
                    Id = companyVM.Id,
                    Name = companyVM.Name,
                    Type = companyVM.Type,
                    Description = companyVM.Description,
                    Count = companyVM.Count,
                    Image = companyVM.Image,
                    OfficialSite = companyVM.OfficialSite,
                    Cities = companyVM.Cities,
                };
                _companyRepository.Update(company);
                return RedirectToAction("Company");
            }
            else return View(companyVM);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var companyDetail = await _companyRepository.GetByIdAsync(id);
            if (companyDetail == null) return View("Error");
            return View(companyDetail);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var companyDetail = await _companyRepository.GetByIdAsync(id);
            if (companyDetail == null) return View("Error");
            _companyRepository.Delete(companyDetail);
            return RedirectToAction("Company");
        }
    }
}

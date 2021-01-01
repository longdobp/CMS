using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Models;
using CMS.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CMS.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IActionResult> Index(string keyword, string status, int pageIndex = 1, int pageSize = 10)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var request = new GetPagingRequest()
                {
                    Keyword = keyword,
                    Status = status,
                    pageIndex = pageIndex,
                    pageSize = pageSize
                };
                var result = await _employeeRepository.GetEmployee(request);
                ViewBag.Keyword = keyword;

                return View(result);
            }
        }
    }
}
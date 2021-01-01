using CMS.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Repository
{
    public interface IEmployeeRepository
    {
        Task<PagedResult<EmployeeListViewModel>> GetEmployee(GetPagingRequest request);

        Task<IEnumerable<EmployeeStatusVm>> GetEmployeeStatus();

        Task<IEnumerable<EmployeeListViewModel>> GetEmployeeAll(string fromDate, string toDate);
    }
}
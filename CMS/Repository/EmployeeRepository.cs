using CMS.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Repository
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<PagedResult<EmployeeListViewModel>> GetEmployee(GetPagingRequest request)
        {
            var _params = new DynamicParameters();
            _params.Add("@filter", string.IsNullOrEmpty(request.Keyword) ? "" : request.Keyword);
            _params.Add("@status", string.IsNullOrEmpty(request.Status) ? "" : request.Status);

            return await HisPro78WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<EmployeeListViewModel>("get_list_employee", _params, commandType: CommandType.StoredProcedure);

                var totalRecords = query.Count();
                var items = query
                .Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .ToList();

                var pagination = new PagedResult<EmployeeListViewModel>
                {
                    Items = items,
                    TotalRows = totalRecords,
                    PageIndex = request.pageIndex,
                    PageSize = request.pageSize
                };
                return pagination;
            });
        }

        public async Task<IEnumerable<EmployeeListViewModel>> GetEmployeeAll(string fromDate, string toDate)
        {
            var _params = new DynamicParameters();
            var now = DateTime.Now;

            var _toDate = new DateTime(now.Year, now.Month, 1);
            var _fromDate = _toDate.AddYears(-1);

            _params.Add("@fromDate", string.IsNullOrEmpty(fromDate) ? _fromDate.ToString("yyyy-MM-dd") : fromDate);
            _params.Add("@toDate", string.IsNullOrEmpty(toDate) ? _toDate.ToString("yyyy-MM-dd") : toDate);

            return await HisPro78WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<EmployeeListViewModel>("get_list_employee_all", _params, commandType: CommandType.StoredProcedure);
                return query;
            });
        }

        public async Task<IEnumerable<EmployeeStatusVm>> GetEmployeeStatus()
        {
            return await HisPro78WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<EmployeeStatusVm>("SELECT * FROM employee_status_nl_view");
                return query;
            });
        }
    }
}
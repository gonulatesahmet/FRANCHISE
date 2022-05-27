using Core.Business;
using Core.Utilites.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IEmployeeService : IEntityRepositoryBusiness<Employee> 
    {
        IDataResult<List<EmployeeDto>> EmployeeDtoGetByBranch(int branchId);
        IDataResult<Employee> EmployeeCodeControl(string code, int branchId);
        IDataResult<List<Employee>> CbbEmployeeGetByBranch(int branchId);
    }
}

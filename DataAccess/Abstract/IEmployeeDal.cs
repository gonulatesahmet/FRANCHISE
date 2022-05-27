using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IEmployeeDal :IEntityRepository<Employee>
    {
        List<EmployeeDto> EmployeeDtoGetByBranch(int branchId);
        Employee EmployeeGetByCode(string code);
        List<Employee> CbbEmployeeGetByBranch(int branchId);
    }
}

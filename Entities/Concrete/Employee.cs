using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Employee : IEntity
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeeIdNumber { get; set; }
        public DateTime EmployeeBirthDate { get; set; }
        public string EmployeeCode { get; set; }
        public int BranchId { get; set; }
        public int AppellationId { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeMail { get; set; }
        public string EmployeeAddress { get; set; }
        public bool EmployeeState { get; set; }
    }
}

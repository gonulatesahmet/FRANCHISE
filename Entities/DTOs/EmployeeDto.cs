using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class EmployeeDto : IDTOs
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeeIdNumber { get; set; }
        public DateTime EmployeeBirthDate { get; set; }
        public string EmployeeCode { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int AppellationId { get; set; }
        public string AppellationName { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeMail { get; set; }
        public string EmployeeAddress { get; set; }
        public bool EmployeeState { get; set; }
    }
}

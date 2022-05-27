using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;
        public EmployeeManager(IEmployeeDal employeeDal)
        {
                _employeeDal = employeeDal;
        }
        public IResult Add(Employee entity)
        {
            IResult control = BusinessRules.Run(EmployeeEntityControl(entity),
                                                EmployeeAddCodeControl(entity.EmployeeCode));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _employeeDal.Add(entity);
                return new SuccessResult(Messages.EmployeeAdded);
            }
        }

        public IResult ChangeState(int id, bool state)
        {
            IResult control = BusinessRules.Run(EmployeeIdControl(id));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _employeeDal.ChangeState(id, state);
                return new SuccessResult(Messages.EmployeeChangeState);
            }
        }

        public IResult Delete(int id)
        {
            IResult control = BusinessRules.Run(EmployeeIdControl(id));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _employeeDal.Delete(id);
                return new SuccessResult(Messages.EmployeeDeleted);
            }
        }

        public IDataResult<List<Employee>> GetAll(int? id)
        {
            return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(id), Messages.EmployeeGetAll);
        }

        public IDataResult<Employee> GetById(int id)
        {
            IResult control = BusinessRules.Run(EmployeeIdControl(id));
            if(control != null)
            {
                return new ErrorDataResult<Employee>(control.Message);
            }
            else
            {
                return new SuccessDataResult<Employee>(_employeeDal.GetById(id), Messages.EmployeeGetById);
            }
        }

        public IResult Update(Employee entity)
        {
            IResult control = BusinessRules.Run(EmployeeEntityControl(entity),
                                                EmployeeUpdateCodeControl(entity.EmployeeId, entity.EmployeeCode));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _employeeDal.Update(entity);
                return new SuccessResult(Messages.EmployeeUpdated);
            }
        }




        public IDataResult<List<EmployeeDto>> EmployeeDtoGetByBranch(int branchId)
        {
            return new SuccessDataResult<List<EmployeeDto>>(_employeeDal.EmployeeDtoGetByBranch(branchId),Messages.EmployeeGetAll);
        }

        public IDataResult<List<Employee>> CbbEmployeeGetByBranch(int branchId)
        {
            return new SuccessDataResult<List<Employee>>(_employeeDal.CbbEmployeeGetByBranch(branchId));
        }


        public IDataResult<Employee> EmployeeCodeControl(string code, int branchId)
        {
            var result = _employeeDal.EmployeeGetByCode(code);
            if(result != null)
            {
                IResult control = BusinessRules.Run(EmployeeBranchControl(branchId, result.BranchId),
                                                    EmployeeStateControl(result.EmployeeState));
                if(control != null)
                {
                    return new ErrorDataResult<Employee>(control.Message);
                }
                return new SuccessDataResult<Employee>(result);
            }
            else
            {
                return new ErrorDataResult<Employee>(Messages.EmployeeCodeNotVerified);
            }
            
        }













        ///Rules
        private IResult EmployeeAddCodeControl(string code)
        {
            var result = _employeeDal.EmployeeGetByCode(code);
            if(result != null)
            {
                return new ErrorResult(Messages.EmployeeCodeNotVerified);
            }
            return new SuccessResult();
        }
        private IResult EmployeeUpdateCodeControl(int id, string code)
        {
            var result = _employeeDal.EmployeeGetByCode(code);
            if(result != null)
            {
                if(result.EmployeeId != id)
                {
                    return new ErrorResult(Messages.EmployeeCodeNotVerified);
                }
            }
            return new SuccessResult();
        }
        private IResult EmployeeBranchControl(int availableBranchId, int branchId)
        {
            if (availableBranchId != branchId)
            {
                return new ErrorResult(Messages.EmployeeNotMatchBranch);
            }
            return new SuccessResult();
        }
        private IResult EmployeeStateControl(bool state)
        {
            if(state != true)
            {
                return new ErrorResult(Messages.EmployeeStateFalse);
            }
            return new SuccessResult();
        }
        private IResult EmployeeEntityControl(Employee entity)
        {
            if (string.IsNullOrEmpty(entity.EmployeeName)) return new ErrorResult(Messages.NameCannotBeEmpty);
            if (string.IsNullOrEmpty(entity.EmployeeSurname)) return new ErrorResult(Messages.SurnameCannotBeEmpty);
            if (string.IsNullOrEmpty(entity.EmployeeCode)) return new ErrorResult(Messages.CodeCannotBeEmpty);
            if (string.IsNullOrEmpty(entity.EmployeeIdNumber)) return new ErrorResult(Messages.IdNumberCannotBeEmpty);
            if (entity.EmployeeBirthDate == null && entity.EmployeeBirthDate == System.DateTime.Now) return new ErrorResult(Messages.BirthDateNotVerified);
            if (entity.BranchId <= 0) return new ErrorResult(Messages.BranchCannotBeEmpty);
            if (entity.AppellationId <= 0) return new ErrorResult(Messages.AppellationCannotBeEmpty);
            if (string.IsNullOrEmpty(entity.EmployeePhone)) return new ErrorResult(Messages.PhoneCannotBeEmpty);
            if (string.IsNullOrEmpty(entity.EmployeeMail)) return new ErrorResult(Messages.MailCannotBeEmpty);
            if (string.IsNullOrEmpty(entity.EmployeeAddress)) return new ErrorResult(Messages.AddressCannotBeEmpty);
            return new SuccessResult();
        }
        private IResult EmployeeIdControl(int id)
        {
            if (id == 0) return new ErrorResult(Messages.IdNotFound);
            return new SuccessResult();
        }

    }
}

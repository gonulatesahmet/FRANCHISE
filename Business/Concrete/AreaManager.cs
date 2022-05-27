using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AreaManager : IAreaService
    {
        IAreaDal _areaDal;
        public AreaManager(IAreaDal areaDal)
        {
            _areaDal = areaDal;
        }
        public IResult Add(Area entity)
        {
            IResult control = BusinessRules.Run(AreaEntityControl(entity));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _areaDal.Add(entity);
                return new SuccessResult(Messages.AreaAdded);
            }
        }

        public IResult ChangeState(int id, bool state)
        {
            IResult control = BusinessRules.Run(AreaIdControl(id));
            if (control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _areaDal.ChangeState(id, state);
                return new SuccessResult(Messages.AreaChangeState);
            }
        }

        public IResult Delete(int id)
        {
            IResult control = BusinessRules.Run(AreaIdControl(id));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _areaDal.Delete(id);
                return new SuccessResult(Messages.AreaDeleted);
            }
        }

        public IDataResult<List<Area>> GetAll(int? id)
        {
            return new SuccessDataResult<List<Area>>(_areaDal.GetAll(id), Messages.AreaGetAll);
        }

        public IDataResult<Area> GetById(int id)
        {
            IResult control = BusinessRules.Run(AreaIdControl(id));
            if(control != null)
            {
                return new ErrorDataResult<Area>(control.Message);
            }
            else
            {
                return new SuccessDataResult<Area>(_areaDal.GetById(id), Messages.AreaGetById);
            }
        }

        public IResult Update(Area entity)
        {
            IResult control = BusinessRules.Run(AreaEntityControl(entity));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _areaDal.Update(entity);
                return new SuccessResult(Messages.AreaUpdated);
            }
        }





        public IDataResult<List<CbbArea>> CbbAreaGetAll(int branchId, bool areaState)
        {
            IResult control = BusinessRules.Run(AreaIdControl(branchId));
            if(control != null)
            {
                return new ErrorDataResult<List<CbbArea>>(control.Message);
            }
            else
            {
                return new SuccessDataResult<List<CbbArea>>(_areaDal.CbbAreaGetAll(branchId, areaState));
            }
        }

        public IDataResult<List<AreaDto>> AreaDtoGetByBranch(int branchId)
        {
            IResult control = BusinessRules.Run(AreaIdControl(branchId));
            if(control != null)
            {
                return new ErrorDataResult<List<AreaDto>>(control.Message);
            }
            else
            {
                return new SuccessDataResult<List<AreaDto>>(_areaDal.AreaDtoGetByBranch(branchId), Messages.AreaGetBranch);
            }
        }




        //Rules
        private IResult AreaEntityControl(Area entity)
        {
            if (string.IsNullOrEmpty(entity.AreaName)) return new ErrorResult(Messages.NameCannotBeEmpty);
            if (string.IsNullOrEmpty(entity.AreaCode)) return new ErrorResult(Messages.CodeCannotBeEmpty);
            if (string.IsNullOrEmpty(entity.AreaDescription)) return new ErrorResult(Messages.DescriptionCannotBeEmpty);
            return new SuccessResult();
        }
        private IResult AreaIdControl(int id)
        {
            if (id == 0) return new ErrorResult(Messages.IdNotFound);
            return new SuccessResult();
        }
    }
}

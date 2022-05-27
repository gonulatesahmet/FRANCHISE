using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BranchManager : IBranchService
    {
        IBranchDal _branchDal;
        public BranchManager(IBranchDal branchDal)
        {
            _branchDal = branchDal;
        }

        public IResult Add(Branch entity)
        {
            IResult control = BusinessRules.Run(BranchEntityControl(entity));
            if (control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _branchDal.Add(entity);
                return new SuccessResult(Messages.BranchAdd);
            }
        }
        public IResult ChangeState(int id, bool state)
        {
            _branchDal.ChangeState(id, state);
            return new SuccessResult(Messages.BranchChangeState);
        }

        public IResult Delete(int id)
        {
            _branchDal.Delete(id);
            return new SuccessResult(Messages.BranchDeleted);
        }

        public IDataResult<List<Branch>> GetAll(int? id)
        {
            return new SuccessDataResult<List<Branch>>(_branchDal.GetAll(id), Messages.BranchGetAll);
        }

        public IDataResult<Branch> GetById(int id)
        {
            return new SuccessDataResult<Branch>(_branchDal.GetById(id), Messages.BranchGetById);
        }

        public IResult Update(Branch entity)
        {
            IResult control = BusinessRules.Run(BranchEntityControl(entity));
            if (control != null) return new ErrorResult(control.Message);
            else
            {
                _branchDal.Update(entity);
                return new SuccessResult(Messages.BranchUpdated);
            }
        }


        public IDataResult<List<CbbBranch>> CbbBranchGetAll(int InstitutionId, bool BranchState)
        {
            return new SuccessDataResult<List<CbbBranch>>(_branchDal.CbbBranchGetAll(InstitutionId, BranchState));
        }















        ///Rules


        private IResult BranchEntityControl(Branch entity)
        {
            if (string.IsNullOrEmpty(entity.BranchName)) return new ErrorResult(Messages.NameCannotBeEmpty);
            if (string.IsNullOrEmpty(entity.BranchCode)) return new ErrorResult(Messages.CodeCannotBeEmpty);
            if (string.IsNullOrEmpty(entity.BranchDescription)) return new ErrorResult(Messages.DescriptionCannotBeEmpty);
            if (string.IsNullOrEmpty(entity.AuthorizedPerson)) return new ErrorResult(Messages.AuthorizedPersonCannotBeEmpty);
            if (string.IsNullOrEmpty(entity.BranchPhone)) return new ErrorResult(Messages.PhoneCannotBeEmpty);
            if (string.IsNullOrEmpty(entity.BranchMail)) return new ErrorResult(Messages.MailCannotBeEmpty);
            if (string.IsNullOrEmpty(entity.BranchRegion)) return new ErrorResult(Messages.RegionCannotBeEmpty);
            if (string.IsNullOrEmpty(entity.BranchCity)) return new ErrorResult(Messages.CityCannotBeEmpty);
            if (string.IsNullOrEmpty(entity.BranchDistrict)) return new ErrorResult(Messages.DistrictCannotBeEmpty);
            if (string.IsNullOrEmpty(entity.BranchAddress)) return new ErrorResult(Messages.AddressCannotBeEmpty);
            return new SuccessResult();
        }

    }
}

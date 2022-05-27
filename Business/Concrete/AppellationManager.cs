using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AppellationManager : IAppellationService
    {
        IAppellationDal _appellationDal;
        public AppellationManager(IAppellationDal appellationDal)
        {
            _appellationDal = appellationDal;
        }

        public IResult Add(Appellation entity)
        {
            IResult control = BusinessRules.Run(AppellationEntityControl(entity));
            if (control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _appellationDal.Add(entity);
                return new SuccessResult(Messages.AppellationAdded);
            }
        }

        public IResult ChangeState(int id, bool state)
        {
            IResult control = BusinessRules.Run(AppellationIdControl(id));
            if (control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _appellationDal.ChangeState(id, state);
                return new SuccessResult(Messages.AppellationChangeState);
            }
        }

        public IResult Delete(int id)
        {
            IResult control = BusinessRules.Run(AppellationIdControl(id));
            if (control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _appellationDal.Delete(id);
                return new SuccessResult(Messages.AppellationDeleted);
            }
        }

        public IDataResult<List<Appellation>> GetAll(int? id)
        {
            return new SuccessDataResult<List<Appellation>>(_appellationDal.GetAll(id), Messages.AppellationGetAll);
        }

        public IDataResult<Appellation> GetById(int id)
        {
            IResult control = BusinessRules.Run(AppellationIdControl(id));
            if(control != null)
            {
                return new ErrorDataResult<Appellation>(control.Message);
            }
            else
            {
                return new SuccessDataResult<Appellation>(_appellationDal.GetById(id), Messages.AppellationGetById);
            }
        }

        public IResult Update(Appellation entity)
        {
            IResult control = BusinessRules.Run(AppellationEntityControl(entity),
                                                AppellationIdControl(entity.AppellationId));
            if (control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _appellationDal.Update(entity);
                return new SuccessResult(Messages.AppellationUpdated);
            }
        }

        public IDataResult<List<CbbAppellation>> CbbAppellationGetAll(bool state)
        {
            return new SuccessDataResult<List<CbbAppellation>>(_appellationDal.CbbAppellationGetAll(state), Messages.AppellationGetAll);
        }



        //Rules
        private IResult AppellationEntityControl(Appellation entity)
        {
            if (string.IsNullOrEmpty(entity.AppellationName)) return new ErrorResult(Messages.NameCannotBeEmpty);
            if (string.IsNullOrEmpty(entity.AppellationCode)) return new ErrorResult(Messages.CodeCannotBeEmpty);
            if (string.IsNullOrEmpty(entity.AppellationDescription)) return new ErrorResult(Messages.DescriptionCannotBeEmpty);
            return new SuccessResult();
        }
        private IResult AppellationIdControl(int id)
        {
            if (id == 0) return new ErrorResult(Messages.IdNotFound);
            return new SuccessResult();
        }
    }
}

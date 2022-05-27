using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;
        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }
        public IResult Add(Payment entity)
        {
            IResult control = BusinessRules.Run(TypeOfPaymentIdControl(entity.TypeOfPaymentId));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _paymentDal.Add(entity);
                return new SuccessResult(Messages.PaymentAdded);
            }
        }

        public IResult ChangeState(int id, bool state)
        {
            _paymentDal.ChangeState(id, state);
            return new SuccessResult(Messages.TypeOfPaymentChangeState);
        }

        public IResult Delete(int id)
        {
            _paymentDal.Delete(id);
            return new SuccessResult(Messages.PaymentDeleted);
        }

        public IDataResult<List<Payment>> GetAll(int? id)
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(id), Messages.PaymentGetAll);
        }

        public IDataResult<Payment> GetById(int id)
        {
            return new SuccessDataResult<Payment>(_paymentDal.GetById(id), Messages.PaymentGetById);
        }

        public IResult Update(Payment entity)
        {
            _paymentDal.Update(entity);
            return new SuccessResult(Messages.PaymentUpdated);
        }
        public IDataResult<List<PaymentDto>> PaymentDtoGetBySession(int sessionId)
        {
            return new SuccessDataResult<List<PaymentDto>>(_paymentDal.PaymentDtoGetBySession(sessionId), Messages.PaymentGetAll);
        }

        public IResult PaymentChangeSession(int oldSessionId, int newSessionId)
        {
            _paymentDal.PaymentChangeSession(oldSessionId, newSessionId);
            return new SuccessResult("Odeme Tablosu SessionId Basariyla Degistirildi.");
        }





        //REPORTS
        public IDataResult<List<PaymentDto>> BranchTypeOfPaymentReport(int branchId, DateTime date)
        {
            return new SuccessDataResult<List<PaymentDto>>(_paymentDal.BranchTypeOfPaymentReport(branchId, date), Messages.PaymentGetAll);
        }





        //Rules
        IResult TypeOfPaymentIdControl(int id)
        {
            if (id == 0) return new ErrorResult("Lutfen Gecerli Bir Odeme Yontemi Seciniz.");
            return new SuccessResult();
        }

    }
}

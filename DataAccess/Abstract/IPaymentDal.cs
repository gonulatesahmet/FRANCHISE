using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IPaymentDal : IEntityRepository<Payment>
    {
        List<PaymentDto> PaymentDtoGetBySession(int sessionId);
        List<PaymentDto> BranchTypeOfPaymentReport(int branchId, DateTime date);
        void PaymentChangeSession(int oldSessionId, int newSessionId);
    }
}

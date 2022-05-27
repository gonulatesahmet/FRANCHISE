using Core.Business;
using Core.Utilites.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPaymentService : IEntityRepositoryBusiness<Payment>
    {
        IDataResult<List<PaymentDto>> PaymentDtoGetBySession(int sessionId);
        IResult PaymentChangeSession(int oldSessionId, int newSessionId);


        IDataResult<List<PaymentDto>> BranchTypeOfPaymentReport(int branchId, DateTime date);
    }
}

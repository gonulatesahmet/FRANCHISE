using Core.Business;
using Core.Utilites.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using static Entities.Enums.OrderStateEnum;

namespace Business.Abstract
{
    public interface IOrderService : IEntityRepositoryBusiness<Order> 
    {
        IDataResult<List<OrderDto>> OrderDtoGetBySession(int SessionId);
        IDataResult<List<OrderDto>> OrderDtoDetailGetBySession(int SessionId);
        IDataResult<List<Order>> OrderGetByState(int SessionId, OrderState orderState);
        IResult OrderUpdate(int orderId, OrderState orderState);
        IResult OrderDeleteByState(int sessionId, OrderState state);
        IResult OrderNoteAdd(int orderId, string message);
        IResult OrderChangeSession(int oldSessionId, int newSessionId);






        //REPORTS
        IDataResult<List<Order>> BranchDailyEndorsement(int branchId);
        IDataResult<List<OrderDto>> BranchProductDailySales(int branchId, DateTime date);
        IDataResult<List<OrderDto>> BranchTypeOfOrderReport(int branchId, DateTime date);
        IDataResult<List<OrderDto>> BranchEmployeeSales(int branchId, DateTime date);
        IDataResult<List<OrderDto>> BranchTypeOfProductReport(int branchId, DateTime date);
        IDataResult<List<OrderDto>> BranchDiscountContentReport(int branchId, DateTime date);
        IDataResult<List<OrderDto>> BranchCategoryBasedOrderDetails(int branchId, DateTime date);

    }
}

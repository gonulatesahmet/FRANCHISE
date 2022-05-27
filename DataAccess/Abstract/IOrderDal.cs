using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using static Entities.Enums.OrderStateEnum;

namespace DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order> 
    {
        List<OrderDto> OrderDtoGetBySession(int SessionId);
        List<OrderDto> OrderDtoDetailGetBySession(int SessionId);
        List<Order> OrderGetByState(int SessionId, OrderState orderState);
        void OrderUpdate(int orderId, OrderState state);
        void OrderDelete(int sessionId, OrderState state);
        void OrderNoteAdd(int orderId, string message);
        void OrderChangeSession(int oldSessionId, int newSessionId);



        //Reports
        List<Order> BranchDailyEndorsement(int branchId);
        List<OrderDto> BranchProductDailySales(int branchId, DateTime date);
        List<OrderDto> BranchTypeOfOrderReport(int branchId, DateTime date);
        List<OrderDto> BranchEmplyeeSales(int branchId, DateTime date);
        List<OrderDto> BranchTypeOfProductReport(int branchId, DateTime date);
        List<OrderDto> BranchDiscountContentReport(int branchId, DateTime date);
        List<OrderDto> BranchCategoryBasedOrderDetails(int branchId, DateTime date);
    }
}

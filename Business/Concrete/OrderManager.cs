using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entities.Enums;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public OrderManager()
        {
        }

        public IResult Add(Order entity)
        {
            _orderDal.Add(entity);
            return new SuccessResult(Messages.OrderAdd);
        }

        public IResult ChangeState(int id, bool state)
        {
            throw new System.NotImplementedException();
        }

        public IResult Delete(int id)
        {
            _orderDal.Delete(id);
            return new SuccessResult("Siparis Silindi.");
        }

        public IDataResult<List<Order>> GetAll(int? id)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<Order> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IResult Update(Order entity)
        {
            throw new System.NotImplementedException();
        }


        public IDataResult<List<OrderDto>> OrderDtoGetBySession(int SessionId)
        {
            return new SuccessDataResult<List<OrderDto>>(_orderDal.OrderDtoGetBySession(SessionId),Messages.ProductGetAll);
        }

        public IDataResult<List<OrderDto>> OrderDtoDetailGetBySession(int SessionId)
        {
            return new SuccessDataResult<List<OrderDto>>(_orderDal.OrderDtoDetailGetBySession(SessionId), Messages.ProductGetAll);
        }

        public IDataResult<List<Order>> OrderGetByState(int SessionId, OrderStateEnum.OrderState orderState)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.OrderGetByState(SessionId, orderState), Messages.ProductGetAll);
        }

        public IResult OrderUpdate(int orderId, OrderStateEnum.OrderState orderState)
        {
            _orderDal.OrderUpdate(orderId, orderState);
            return new SuccessResult();
        }

        public IResult OrderDeleteByState(int sessionId, OrderStateEnum.OrderState state)
        {
            _orderDal.OrderDelete(sessionId, state);
            return new SuccessResult();
        }

        public IResult OrderNoteAdd(int orderId, string message)
        {
            _orderDal.OrderNoteAdd(orderId, message);
            return new SuccessResult("Siparis Notu Basariyla Eklendi.");
        }
        public IResult OrderChangeSession(int oldSessionId, int newSessionId)
        {
            _orderDal.OrderChangeSession(oldSessionId, newSessionId);
            return new SuccessResult("Siparis Tablosu SessionId Basariyla Degistirildi.");
        }

















        //REPORTS
        public IDataResult<List<Order>> BranchDailyEndorsement(int branchId)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.BranchDailyEndorsement(branchId));
        }

        public IDataResult<List<OrderDto>> BranchProductDailySales(int branchId, DateTime date)
        {
            return new SuccessDataResult<List<OrderDto>>(_orderDal.BranchProductDailySales(branchId, date));
        }

        public IDataResult<List<OrderDto>> BranchTypeOfOrderReport(int branchId, DateTime date)
        {
            return new SuccessDataResult<List<OrderDto>>(_orderDal.BranchTypeOfOrderReport(branchId, date));
        }

        public IDataResult<List<OrderDto>> BranchEmployeeSales(int branchId, DateTime date)
        {
            return new SuccessDataResult<List<OrderDto>>(_orderDal.BranchEmplyeeSales(branchId, date));
        }

        public IDataResult<List<OrderDto>> BranchTypeOfProductReport(int branchId, DateTime date)
        {
            
            return new SuccessDataResult<List<OrderDto>>(_orderDal.BranchTypeOfProductReport(branchId, date));
        }

        public IDataResult<List<OrderDto>> BranchDiscountContentReport(int branchId, DateTime date)
        {
            return new SuccessDataResult<List<OrderDto>>(_orderDal.BranchDiscountContentReport(branchId, date));
        }

        public IDataResult<List<OrderDto>> BranchCategoryBasedOrderDetails(int branchId, DateTime date)
        {
            return new SuccessDataResult<List<OrderDto>>(_orderDal.BranchCategoryBasedOrderDetails(branchId, date));
        }

    }
}

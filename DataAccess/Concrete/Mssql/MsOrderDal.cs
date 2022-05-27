using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Concrete.Mssql
{
    public class MsOrderDal : IOrderDal
    {
        List<Order> orderList = new List<Order>();
        List<OrderDto> orderDtos = new List<OrderDto>();
        SqlConnection connection;
        public void Add(Order entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_OrderAdd", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchProductId", entity.BranchProductId);
            cmd.Parameters.AddWithValue("OrderPiece", entity.Piece);
            cmd.Parameters.AddWithValue("OrderTotalPrice", entity.TotalPrice);
            cmd.Parameters.AddWithValue("BranchDiscountContentId", entity.BranchDiscountContentId);
            cmd.Parameters.AddWithValue("SessionId", entity.SessionId);
            cmd.Parameters.AddWithValue("TypeOfOrderId", entity.TypeOfOrderId);
            cmd.Parameters.AddWithValue("BranchId", entity.BranchId);
            cmd.Parameters.AddWithValue("OrderDate", entity.OrderDate);
            cmd.Parameters.AddWithValue("EmployeeId", entity.EmployeeId);
            cmd.Parameters.AddWithValue("OrderState", entity.OrderState);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }

        public void ChangeState(int id, bool state)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_OrderDelete", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("OrderId", id);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }

        public Order GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Order> GetAll(int? id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public List<OrderDto> OrderDtoGetBySession(int SessionId)
        {
            orderDtos.Clear();
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_OrderDtoGetBySession", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("SessionId", SessionId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                orderDtos.Add(new OrderDto
                {
                    BranchProductId = Convert.ToInt32(dr["BranchProductId"]),
                    ProductName = Convert.ToString(dr["ProductName"]),
                    OrderPiece = Convert.ToInt32(dr["OrderPiece"]),
                    OrderTotalPrice = Convert.ToDecimal(dr["OrderTotalPrice"]),
                    UnitPrice = Convert.ToDecimal(dr["UnitPrice"]),
                    BranchDiscountContentName = Convert.ToString(dr["BranchDiscountContentName"]),
                    OrderState = (Entities.Enums.OrderStateEnum.OrderState)Convert.ToInt32(dr["OrderState"])
                });
            }
            Connection.endConnection(connection);
            return orderDtos;
        }

        public List<OrderDto> OrderDtoDetailGetBySession(int SessionId)
        {
            orderDtos.Clear();
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_OrderDtoDetailGetBySession", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("SessionId", SessionId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                orderDtos.Add(new OrderDto
                {
                    OrderId = Convert.ToInt32(dr["OrderId"]),
                    SessionId = SessionId,
                    OrderDate = Convert.ToDateTime(dr["OrderDate"]),
                    BranchDiscountContentId = Convert.ToInt32(dr["BranchDiscountContentId"]),
                    BranchDiscountContentName = Convert.ToString(dr["BranchDiscountContentName"]),
                    BranchProductId = Convert.ToInt32(dr["BranchProductId"]),
                    ProductName = Convert.ToString(dr["ProductName"]),
                    OrderPiece = Convert.ToInt32(dr["OrderPiece"]),
                    OrderTotalPrice = Convert.ToDecimal(dr["OrderTotalPrice"]),
                    TypeOfOrderId = Convert.ToInt32(dr["TypeOfOrderId"]),
                    TypeOfOrderName = Convert.ToString(dr["TypeOfOrderName"]),
                    EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                    EmployeeName = Convert.ToString(dr["EmployeeName"]),
                    BranchId = Convert.ToInt32(dr["BranchId"]),
                    BranchName = Convert.ToString(dr["BranchName"]),
                    OrderState = (Entities.Enums.OrderStateEnum.OrderState)Convert.ToInt32(dr["OrderState"])
                });
            }
            Connection.endConnection(connection);
            return orderDtos;
        }

        public List<Order> OrderGetByState(int SessionId, OrderStateEnum.OrderState orderState)
        {
            orderList.Clear();
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_OrderGetByState", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("SessionId", SessionId);
            cmd.Parameters.AddWithValue("OrderState", orderState);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                orderList.Add(new Order
                {
                    OrderId = Convert.ToInt32(dr["OrderId"])
                });
            }
            Connection.endConnection(connection);
            return orderList;
        }

        public void OrderUpdate(int orderId, OrderStateEnum.OrderState state)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_OrderUpdate", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("OrderId", orderId);
            cmd.Parameters.AddWithValue("OrderState", state);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }

        public void OrderDelete(int sessionId, OrderStateEnum.OrderState state)
        {
            connection=Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_OrderDeleteByState", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("SessionId", sessionId);
            cmd.Parameters.AddWithValue("OrderState", state);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }

        public void OrderNoteAdd(int orderId, string message)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_OrderNoteAdd", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("OrderId", orderId);
            cmd.Parameters.AddWithValue("OrderNote", message);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }


        public void OrderChangeSession(int oldSessionId, int newSessionId)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_OrderChangeSession", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("OldSessionId", oldSessionId);
            cmd.Parameters.AddWithValue("NewSessionId", newSessionId);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
















        //REPORTS
        public List<Order> BranchDailyEndorsement(int branchId)
        {
            orderList.Clear();
            connection= Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchDailyEndorsement", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchId", branchId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                orderList.Add(new Order
                {
                    OrderDate = Convert.ToDateTime(dr["OrderDate"]),
                    TotalPrice = Convert.ToDecimal(dr["TotalPrice"])
                });
            }
            Connection.endConnection(connection);
            return orderList;
        }

        public List<OrderDto> BranchProductDailySales(int branchId, DateTime date)
        {
            orderDtos.Clear();
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchProductDailySales", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchId", branchId);
            cmd.Parameters.AddWithValue("ReportDay", date);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                orderDtos.Add(new OrderDto
                {
                    ProductName = Convert.ToString(dr["ProductName"]),
                    OrderPiece = Convert.ToInt32(dr["OrderPiece"])
                });
            }
            Connection.endConnection(connection);
            return orderDtos;
        }

        public List<OrderDto> BranchTypeOfOrderReport(int branchId, DateTime date)
        {
            orderDtos.Clear();
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchTypeOfOrderReport", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchId", branchId);
            cmd.Parameters.AddWithValue("ReportDay", date);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                orderDtos.Add(new OrderDto
                {
                    TypeOfOrderName = Convert.ToString(dr["TypeOfOrderName"]),
                    OrderPiece = Convert.ToInt32(dr["OrderPiece"])
                });
            }
            Connection.endConnection(connection);
            return orderDtos;
        }

        public List<OrderDto> BranchEmplyeeSales(int branchId, DateTime date)
        {
            orderDtos.Clear();
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchEmployeeSales", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchId", branchId);
            cmd.Parameters.AddWithValue("ReportDay", date);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                orderDtos.Add(new OrderDto
                {
                    ProductName = Convert.ToString(dr["ProductName"]),
                    OrderPiece = Convert.ToInt32(dr["OrderPiece"]),
                    EmployeeName = Convert.ToString(dr["EmployeeName"])
                });
            }
            Connection.endConnection(connection);
            return orderDtos;
        }

        public List<OrderDto> BranchTypeOfProductReport(int branchId, DateTime date)
        {
            orderDtos.Clear();
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchTypeOfProductReport", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchId", branchId);
            cmd.Parameters.AddWithValue("ReportDay", date);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                orderDtos.Add(new OrderDto
                {
                    TypeOfOrderName = Convert.ToString(dr["TypeOfProductName"]),
                    OrderPiece = Convert.ToInt32(dr["OrderPiece"])
                });
            }
            Connection.endConnection(connection);
            return orderDtos;
        }

        public List<OrderDto> BranchDiscountContentReport(int branchId, DateTime date)
        {
            orderDtos.Clear();
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchDiscountContentReport", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchId", branchId);
            cmd.Parameters.AddWithValue("ReportDay", date);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                orderDtos.Add(new OrderDto
                {
                    BranchDiscountContentName = Convert.ToString(dr["BranchDiscountContentName"]),
                    OrderPiece = Convert.ToInt32(dr["OrderPiece"])
                });
            }
            Connection.endConnection(connection);
            return orderDtos;
        }

        public List<OrderDto> BranchCategoryBasedOrderDetails(int branchId, DateTime date)
        {
            orderDtos.Clear();
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchCategoryBasedOrderDetails", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchId", branchId);
            cmd.Parameters.AddWithValue("ReportDay", date);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                orderDtos.Add(new OrderDto
                {
                    ProductName = Convert.ToString(dr["CategoryName"]),
                    OrderPiece = Convert.ToInt32(dr["OrderPiece"]),
                    OrderTotalPrice = Convert.ToDecimal(dr["OrderTotalPrice"])
                });
            }
            Connection.endConnection(connection);
            return orderDtos;
        }

    }
}

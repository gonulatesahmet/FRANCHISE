using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Mssql
{
    public class MsPaymentDal : IPaymentDal
    {
        Payment payment = new Payment();
        List<Payment> payments = new List<Payment>();
        List<PaymentDto> paymentDtos = new List<PaymentDto>();
        SqlConnection connection;
        public void Add(Payment entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_PaymentAdd", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("PaymentAmount", entity.PaymentAmount);
            cmd.Parameters.AddWithValue("PaymentDate", entity.PaymentDate);
            cmd.Parameters.AddWithValue("TypeOfPaymentId", entity.TypeOfPaymentId);
            cmd.Parameters.AddWithValue("SessionId", entity.SessionId);
            cmd.Parameters.AddWithValue("BranchId", entity.BranchId);
            cmd.Parameters.AddWithValue("PaymentState", entity.PaymentState);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }

        public void ChangeState(int id, bool state)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_PaymentChangeState", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("PaymentId", id);
            cmd.Parameters.AddWithValue("PaymentState", !state);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }

        public void Delete(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_PaymentDelete", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("PaymentId", id);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }

        public List<Payment> GetAll(int? id)
        {
            payments.Clear();
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_PaymentGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                payments.Add(new Payment
                {
                    PaymentId = Convert.ToInt32(dr["PaymentId"]),
                    PaymentAmount = Convert.ToDecimal(dr["PaymentAmount"]),
                    PaymentDate = Convert.ToDateTime(dr["PaymentDate"]),
                    SessionId = Convert.ToInt32(dr["SessionId"]),
                    TypeOfPaymentId = Convert.ToInt32(dr["TypeOfPaymentId"]),
                    BranchId = Convert.ToInt32(dr["BranchId"]),
                    PaymentState = Convert.ToBoolean(dr["PaymentState"])
                });
            }
            Connection.endConnection(connection);
            return payments;
        }

        public Payment GetById(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_PaymentGetById", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("PaymentId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            payment.PaymentId = id;
            payment.PaymentAmount = Convert.ToDecimal(dr["PaymentAmount"]);
            payment.PaymentDate = Convert.ToDateTime(dr["PaymentDate"]);
            payment.SessionId = Convert.ToInt32(dr["SessionId"]);
            payment.TypeOfPaymentId = Convert.ToInt32(dr["TypeOfPaymentId"]);
            payment.BranchId = Convert.ToInt32(dr["BranchId"]);
            payment.PaymentState = Convert.ToBoolean(dr["PaymentState"]);

            Connection.endConnection(connection);
            return payment;
            
        }

        public void Update(Payment entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_PaymentUpdate", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("PaymentId", entity.PaymentId);
            cmd.Parameters.AddWithValue("PaymentAmount", entity.PaymentAmount);
            cmd.Parameters.AddWithValue("TypeOfPaymentId", entity.TypeOfPaymentId);
            cmd.Parameters.AddWithValue("SessionId", entity.SessionId);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public List<PaymentDto> PaymentDtoGetBySession(int sessionId)
        {
            paymentDtos.Clear();
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_PaymentDtoGetBySession", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("SessionId", sessionId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                paymentDtos.Add(new PaymentDto
                {
                    PaymentId = Convert.ToInt32(dr["PaymentId"]),
                    BranchId = Convert.ToInt32(dr["BranchId"]),
                    BranchName = Convert.ToString(dr["BranchName"]),
                    PaymentAmount = Convert.ToDecimal(dr["PaymentAmount"]),
                    PaymentDate = Convert.ToDateTime(dr["PaymentDate"]),
                    SessionId = sessionId,
                    TypeOfPaymentId = Convert.ToInt32(dr["TypeOfPaymentId"]),
                    TypeOfPaymentName = Convert.ToString(dr["TypeOfPaymentName"]),
                    PaymentState = Convert.ToBoolean(dr["PaymentState"])
                });
            }
            Connection.endConnection(connection);
            return paymentDtos;
        }


        public void PaymentChangeSession(int oldSessionId, int newSessionId)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_PaymentChangeSession", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("OldSessionId", oldSessionId);
            cmd.Parameters.AddWithValue("NewSessionId", newSessionId);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }











        //REPORTS
        public List<PaymentDto> BranchTypeOfPaymentReport(int branchId, DateTime date)
        {
            paymentDtos.Clear();
            connection=Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchTypeOfPaymentReport", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchId", branchId);
            cmd.Parameters.AddWithValue("ReportDay", date);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                paymentDtos.Add(new PaymentDto
                {
                    TypeOfPaymentName = Convert.ToString(dr["TypeOfPaymentName"]),
                    PaymentAmount = Convert.ToDecimal(dr["PaymentAmount"])
                });
            }
            Connection.endConnection(connection);
            return paymentDtos;
        }

    }
}

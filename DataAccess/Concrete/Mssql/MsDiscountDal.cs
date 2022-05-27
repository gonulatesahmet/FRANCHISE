using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Concrete.Mssql
{
    public class MsDiscountDal : IDiscountDal
    {
        List<Discount> discountList = new List<Discount>();
        List<DiscountDto> discountDtoList = new List<DiscountDto>();
        List<CbbDiscount> cbbDiscountList = new List<CbbDiscount>();
        SqlConnection connection;
        public void                         Add(Discount entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_DiscountAdd", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("DiscountName", entity.DiscountName);
            cmd.Parameters.AddWithValue("DiscountCode", entity.DiscountCode);
            cmd.Parameters.AddWithValue("DiscountDescription", entity.DiscountDescription);
            cmd.Parameters.AddWithValue("DiscountAmount", entity.DiscountAmount);
            cmd.Parameters.AddWithValue("TypeOfDiscountId", entity.TypeOfDiscountId);
            cmd.Parameters.AddWithValue("DiscountState", entity.DiscountState);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                         ChangeState(int id, bool state)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_DiscountChangeState", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("DiscountId", id);
            cmd.Parameters.AddWithValue("DiscountState", !state);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                         Delete(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_DiscountDelete", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("DiscountId", id);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public Discount                     GetById(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_DiscountGetById", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("DiscountId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            var discount = new Discount
            {
                DiscountId = id,
                DiscountName = dr["DiscountName"].ToString(),
                DiscountCode = dr["DiscountCode"].ToString(),
                DiscountDescription = dr["DiscountDescription"].ToString(),
                DiscountAmount = Convert.ToDecimal(dr["DiscountAmount"]),
                TypeOfDiscountId = Convert.ToInt32(dr["TypeOfDiscountId"]),
                DiscountState = Convert.ToBoolean(dr["DiscountState"])
            };
            Connection.endConnection(connection);
            return discount;
        }
        public List<Discount>               GetAll(int? id)
        {
            connection = Connection.getConnection(connection);
            discountList.Clear();
            SqlCommand cmd = new SqlCommand("PR_DiscountGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                discountList.Add(new Discount
                {
                    DiscountId = Convert.ToInt32(dr["DiscountId"]),
                    DiscountName = dr["DiscountName"].ToString(),
                    DiscountCode = dr["DiscountCode"].ToString(),
                    DiscountDescription = dr["DiscountDescription"].ToString(),
                    DiscountAmount = Convert.ToDecimal(dr["DiscountAmount"]),
                    TypeOfDiscountId = Convert.ToInt32(dr["TypeOfDiscountId"]),
                    DiscountState = Convert.ToBoolean(dr["DiscountState"])
                });
            }
            Connection.endConnection(connection);
            return discountList;
        }
        public void                         Update(Discount entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_DiscountUpdate", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("DiscountName", entity.DiscountName);
            cmd.Parameters.AddWithValue("DiscountCode", entity.DiscountCode);
            cmd.Parameters.AddWithValue("DiscountDescription", entity.DiscountDescription);
            cmd.Parameters.AddWithValue("DiscountAmount", entity.DiscountAmount);
            cmd.Parameters.AddWithValue("TypeOfDiscountId", entity.TypeOfDiscountId);
            cmd.Parameters.AddWithValue("DiscountId", entity.DiscountId);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public List<CbbDiscount>            CbbDiscountGetAll(bool state)
        {
            connection = Connection.getConnection(connection);
            cbbDiscountList.Clear();
            SqlCommand cmd = new SqlCommand("PR_CbbDiscountGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("DiscountState", state);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbbDiscountList.Add(new CbbDiscount
                {
                    DiscountId = Convert.ToInt32(dr["DiscountId"]),
                    DiscountName = dr["DiscountName"].ToString()
                });
            }
            Connection.endConnection(connection);
            return cbbDiscountList;
        }
        public List<CbbDiscount> DiscountGetNotAvailebleInBranchDiscount(int branchId, bool state)
        {
            cbbDiscountList.Clear();
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_DiscountGetNotAvailableInBranchDiscount", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchId", branchId);
            cmd.Parameters.AddWithValue("DiscountState", state);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbbDiscountList.Add(new CbbDiscount
                {
                    DiscountId = Convert.ToInt32(dr["DiscountId"]),
                    DiscountName = dr["DiscountName"].ToString()
                });
            }
            Connection.endConnection(connection);
            return cbbDiscountList;
        }
        public List<DiscountDto> DiscountDtoGetAll(int? id)
        {
            discountDtoList.Clear();
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_DiscountDtoGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                discountDtoList.Add(new DiscountDto
                {
                    DiscountId = Convert.ToInt32(dr["DiscountId"]),
                    DiscountName = dr["DiscountName"].ToString(),
                    DiscountCode = dr["DiscountCode"].ToString(),
                    DiscountDescription = dr["DiscountDescription"].ToString(),
                    DiscountAmount = Convert.ToDecimal(dr["DiscountAmount"]),
                    TypeOfDiscountId = Convert.ToInt32(dr["TypeOfDiscountId"]),
                    TypeOfDiscountName = Convert.ToString(dr["TypeOfDiscountName"]),
                    DiscountState = Convert.ToBoolean(dr["DiscountState"])
                });
            }
            Connection.endConnection(connection);
            return discountDtoList;
        }
    }
}

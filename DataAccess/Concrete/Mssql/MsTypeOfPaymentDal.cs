using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Concrete.Mssql
{
    public class MsTypeOfPaymentDal : ITypeOfPaymentDal
    {
        List<TypeOfPayment> _typeOfPaymentList = new List<TypeOfPayment>();
        List<CbbTypeOfPayment> _cbbTypeOfPaymentList = new List<CbbTypeOfPayment>();


        SqlConnection connection;
        
        public void                                         Add(TypeOfPayment entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_TypeOfPaymentAdd", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfPaymentName", entity.TypeOfPaymentName);
            cmd.Parameters.AddWithValue("TypeOfPaymentCode", entity.TypeOfPaymentCode);
            cmd.Parameters.AddWithValue("TypeOfPaymentDescription", entity.TypeOfPaymentDescription);
            cmd.Parameters.AddWithValue("TypeOfPaymentState", entity.TypeOfPaymentState);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                                         ChangeState(int id, bool state)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_TypeOfPaymentChangeState", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfPaymentId", id);
            cmd.Parameters.AddWithValue("TypeOfPaymentState", !state);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                                         Delete(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_TypeOfPaymentDelete", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfPaymentId", id);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public TypeOfPayment                                GetById(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_TypeOfPaymentGetById", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfPaymentId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            return new TypeOfPayment
            {
                TypeOfPaymentId = id,
                TypeOfPaymentName = dr["TypeOfPaymentName"].ToString(),
                TypeOfPaymentCode = dr["TypeOfPaymentCode"].ToString(),
                TypeOfPaymentDescription = dr["TypeOfPaymentDescription"].ToString(),
                TypeOfPaymentState = Convert.ToBoolean(dr["TypeOfPaymentState"])
            };
        }
        public List<TypeOfPayment>                          GetAll(int? id)
        {
            connection = Connection.getConnection(connection);
            _typeOfPaymentList.Clear();
            SqlCommand cmd = new SqlCommand("PR_TypeOfPaymentGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _typeOfPaymentList.Add(new TypeOfPayment
                {
                    TypeOfPaymentId = Convert.ToInt32(dr["TypeOfPaymentId"]),
                    TypeOfPaymentName = dr["TypeOfPaymentName"].ToString(),
                    TypeOfPaymentCode = dr["TypeOfPaymentCode"].ToString(),
                    TypeOfPaymentDescription = dr["TypeOfPaymentDescription"].ToString(),
                    TypeOfPaymentState = Convert.ToBoolean(dr["TypeOfPaymentState"])
                });
            }
            Connection.endConnection(connection);
            return _typeOfPaymentList;
        }
        public void                                         Update(TypeOfPayment entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_TypeOfPaymentUpdate", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfPaymentName", entity.TypeOfPaymentName);
            cmd.Parameters.AddWithValue("TypeOfPaymentCode", entity.TypeOfPaymentCode);
            cmd.Parameters.AddWithValue("TypeOfPaymentDescription", entity.TypeOfPaymentDescription);
            cmd.Parameters.AddWithValue("TypeOfPaymentId", entity.TypeOfPaymentId);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public List<CbbTypeOfPayment>                       CbbTypeOfPaymentGetAll(bool state)
        {
            connection = Connection.getConnection(connection);
            _cbbTypeOfPaymentList.Clear();
            SqlCommand cmd = new SqlCommand("PR_CbbTypeOfPaymentGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfPaymentState", state);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _cbbTypeOfPaymentList.Add(new CbbTypeOfPayment
                {
                    TypeOfPaymentId = Convert.ToInt32(dr["TypeOfPaymentId"]),
                    TypeOfPaymentName = Convert.ToString(dr["TypeOfPaymentName"])
                });
            }
            Connection.endConnection(connection);
            return _cbbTypeOfPaymentList;
        }
    }
}

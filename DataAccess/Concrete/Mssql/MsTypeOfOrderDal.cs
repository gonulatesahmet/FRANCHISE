using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Mssql
{
    public class MsTypeOfOrderDal : ITypeOfOrderDal
    {
        List<TypeOfOrder> _typeOfOrderList = new List<TypeOfOrder>();
        List<CbbTypeOfOrder> _cbbTypeOfOrderList = new List<CbbTypeOfOrder>();


        SqlConnection connection;
       
        public void                                         Add(TypeOfOrder entity)
        {
            SqlCommand cmd = new SqlCommand("PR_TypeOfOrderAdd", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfOrderName", entity.TypeOfOrderName);
            cmd.Parameters.AddWithValue("TypeOfOrderCode", entity.TypeOfOrderCode);
            cmd.Parameters.AddWithValue("TypeOfOrderDescription", entity.TypeOfOrderDescription);
            cmd.Parameters.AddWithValue("TypeOfOrderState", entity.TypeOfOrderState);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                                         ChangeState(int id, bool state)
        {
            SqlCommand cmd = new SqlCommand("PR_TypeOfOrderChangeState", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfOrderId", id);
            cmd.Parameters.AddWithValue("TypeOfOrderState", !state);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                                         Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("PR_TypeOfOrderDelete", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfOrderId", id);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public List<TypeOfOrder>                            GetAll(int? id)
        {
            _typeOfOrderList.Clear();
            SqlCommand cmd = new SqlCommand("PR_TypeOfOrderGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _typeOfOrderList.Add(new TypeOfOrder
                {
                    TypeOfOrderId = Convert.ToInt32(dr["TypeOfOrderId"]),
                    TypeOfOrderName = Convert.ToString(dr["TypeOfOrderName"]),
                    TypeOfOrderCode = Convert.ToString(dr["TypeOfOrderCode"]),
                    TypeOfOrderDescription = Convert.ToString(dr["TypeOfOrderDescription"]),
                    TypeOfOrderState = Convert.ToBoolean(dr["TypeOfOrderState"])
                });
            }
            Connection.endConnection(connection);
            return _typeOfOrderList;
        }
        public TypeOfOrder                                  GetById(int id)
        {
            SqlCommand cmd = new SqlCommand("PR_TypeOfOrderGetById", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfOrderId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            return new TypeOfOrder
            {
                TypeOfOrderId = id,
                TypeOfOrderName = Convert.ToString(dr["TypeOfOrderName"]),
                TypeOfOrderCode = Convert.ToString(dr["TypeOfOrderCode"]),
                TypeOfOrderDescription = Convert.ToString(dr["TypeOfOrderDescription"]),
                TypeOfOrderState = Convert.ToBoolean(dr["TypeOfOrderState"])
            };
        }
        public void                                         Update(TypeOfOrder entity)
        {
            SqlCommand cmd = new SqlCommand("PR_TypeOfOrderUpdate", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfOrdenName", entity.TypeOfOrderName);
            cmd.Parameters.AddWithValue("TypeOfOrderCode", entity.TypeOfOrderCode);
            cmd.Parameters.AddWithValue("TypeOfOrderDescription", entity.TypeOfOrderDescription);
            cmd.Parameters.AddWithValue("TypeOfOrderId", entity.TypeOfOrderId);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public List<CbbTypeOfOrder>                         CbbTypeOfOrderGetAll(bool state)
        {
            _cbbTypeOfOrderList.Clear();
            SqlCommand cmd = new SqlCommand("PR_CbbTypeOfOrderGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOrderState", state);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _cbbTypeOfOrderList.Add(new CbbTypeOfOrder
                {
                    TypeOfOrderId = Convert.ToInt32(dr["TypeOfOrderId"]),
                    TypeOfOrderName = Convert.ToString(dr["TypeOfOrderName"])
                });
            }
            Connection.endConnection(connection);
            return _cbbTypeOfOrderList;
        }
    }
}

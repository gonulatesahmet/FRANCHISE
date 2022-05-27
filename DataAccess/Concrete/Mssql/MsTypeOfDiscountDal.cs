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
    public class MsTypeOfDiscountDal : ITypeOfDiscountDal
    {
        List<TypeOfDiscount> _typeOfDiscountList = new List<TypeOfDiscount>();
        List<CbbTypeOfDiscount> _cbbTypeOfDiscountList = new List<CbbTypeOfDiscount>();

        SqlConnection connection;
        
        public void                                                     Add(TypeOfDiscount entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_TypeOfDiscountAdd", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfDiscountName", entity.TypeOfDiscountName);
            cmd.Parameters.AddWithValue("TypeOfDiscountCode", entity.TypeOfDiscountCode);
            cmd.Parameters.AddWithValue("TypeOfDiscountDescription", entity.TypeOfDiscountDescription);
            cmd.Parameters.AddWithValue("TypeOfDiscountState", entity.TypeOfDiscountState);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                                                     ChangeState(int id, bool state)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_TypeOfDiscountChangeState", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfDiscountId", id);
            cmd.Parameters.AddWithValue("TypeOfDiscountState", state);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                                                     Delete(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_TypeOfDiscountDelete", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfDiscountId", id);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public TypeOfDiscount                                           GetById(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_TypeOfDiscountGetById", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfDiscountId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            return new TypeOfDiscount
            {
                TypeOfDiscountId = id,
                TypeOfDiscountName = dr["TypeOfDiscountName"].ToString(),
                TypeOfDiscountCode = dr["TypeOfDiscountCode"].ToString(),
                TypeOfDiscountDescription = dr["TypeOfDiscountDescription"].ToString(),
                TypeOfDiscountState = Convert.ToBoolean(dr["TypeOfDiscountState"])
            };
        }
        public List<TypeOfDiscount>                                     GetAll(int? id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_TypeOfDiscountGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _typeOfDiscountList.Add(new TypeOfDiscount
                {
                    TypeOfDiscountId = Convert.ToInt32(dr["TypeOfDiscountId"]),
                    TypeOfDiscountName = dr["TypeOfDiscountName"].ToString(),
                    TypeOfDiscountCode = dr["TypeOfDiscountCode"].ToString(),
                    TypeOfDiscountDescription = dr["TypeOfDiscountDescription"].ToString(),
                    TypeOfDiscountState = Convert.ToBoolean(dr["TypeOfDiscountState"])
                });
            }
            Connection.endConnection(connection);
            return _typeOfDiscountList;
        }
        public void                                                     Update(TypeOfDiscount entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_TypeOfDiscountUpdate", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfDiscountName", entity.TypeOfDiscountName);
            cmd.Parameters.AddWithValue("TypeOfDiscountCode", entity.TypeOfDiscountCode);
            cmd.Parameters.AddWithValue("TypeOfDiscountDescription", entity.TypeOfDiscountDescription);
            cmd.Parameters.AddWithValue("TypeOfDiscountId", entity.TypeOfDiscountId);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public List<CbbTypeOfDiscount>                                  CbbTypeOfDiscountGetAll(bool state)
        {
            connection = Connection.getConnection(connection);
            _cbbTypeOfDiscountList.Clear();
            SqlCommand cmd = new SqlCommand("PR_CbbTypeOfDiscountGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfDiscountState", state);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _cbbTypeOfDiscountList.Add(new CbbTypeOfDiscount
                {
                    TypeOfDiscountId = Convert.ToInt32(dr["TypeOfDiscountId"]),
                    TypeOfDiscountName = dr["TypeOfDiscountName"].ToString()
                });
            }
            Connection.endConnection(connection);
            return _cbbTypeOfDiscountList;
        }
    }
}

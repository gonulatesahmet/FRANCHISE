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
    public class MsTypeOfProductDal : ITypeOfProductDal
    {
        List<TypeOfProduct> _typeOfProductList = new List<TypeOfProduct>();
        List<CbbTypeOfProduct> _cbbTypeOfProductList = new List<CbbTypeOfProduct>();
        SqlConnection connection;
        
        public void                             Add(TypeOfProduct entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_TypeOfProductAdd", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfProductName", entity.TypeOfProductName);
            cmd.Parameters.AddWithValue("TypeOfProductCode", entity.TypeOfProductCode);
            cmd.Parameters.AddWithValue("TypeOfProductDescription", entity.TypeOfProductDescription);
            cmd.Parameters.AddWithValue("TypeOfProductDisplay", entity.TypeOfProductDisplay);
            cmd.Parameters.AddWithValue("TypeOfProductPrinter", entity.TypeOfProductPrinter);
            cmd.Parameters.AddWithValue("TypeOfProductState", entity.TypeOfProductState);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                             ChangeState(int id, bool state)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_TypeOfProductChangeState", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfProductId", id);
            cmd.Parameters.AddWithValue("TypeOfProductState", !state);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                             Delete(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_TypeOfProductDelete", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfProductId", id);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public List<TypeOfProduct>              GetAll(int? id)
        {
            _typeOfProductList.Clear();
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_TypeOfProductGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _typeOfProductList.Add(new TypeOfProduct
                {
                    TypeOfProductId = Convert.ToInt32(dr["TypeOfProductId"]),
                    TypeOfProductName = Convert.ToString(dr["TypeOfProductName"]),
                    TypeOfProductCode = Convert.ToString(dr["TypeOfProductCode"]),
                    TypeOfProductDescription = Convert.ToString(dr["TypeOfProductDescription"]),
                    TypeOfProductDisplay = Convert.ToBoolean(dr["TypeOfProductDisplay"]),
                    TypeOfProductPrinter = Convert.ToBoolean(dr["TypeOfProductPrinter"]),
                    TypeOfProductState = Convert.ToBoolean(dr["TypeOfProductState"])
                });
            }
            Connection.endConnection(connection);
            return _typeOfProductList;
        }
        public TypeOfProduct                    GetById(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_TypeOfProductGetById", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfProductId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            return new TypeOfProduct
            {
                TypeOfProductId = id,
                TypeOfProductName = Convert.ToString(dr["TypeOfProductName"]),
                TypeOfProductCode = Convert.ToString(dr["TypeOfProductCode"]),
                TypeOfProductDescription = Convert.ToString(dr["TypeOfProductDescription"]),
                TypeOfProductDisplay = Convert.ToBoolean(dr["TypeOfProductDisplay"]),
                TypeOfProductPrinter = Convert.ToBoolean(dr["TypeOfProductPrinter"]),
                TypeOfProductState = Convert.ToBoolean(dr["TypeOfProductState"])
            };
        }
        public void                             Update(TypeOfProduct entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_TypeOfProductUpdate", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfProductName", entity.TypeOfProductName);
            cmd.Parameters.AddWithValue("TypeOfProductCode", entity.TypeOfProductCode);
            cmd.Parameters.AddWithValue("TypeOfProductDescription", entity.TypeOfProductDescription);
            cmd.Parameters.AddWithValue("TypeOfProductDisplay", entity.TypeOfProductDisplay);
            cmd.Parameters.AddWithValue("TypeOfProductPrinter", entity.TypeOfProductPrinter);
            cmd.Parameters.AddWithValue("TypeOfProductId", entity.TypeOfProductId);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public List<CbbTypeOfProduct>           CbbTypeOfProductGetAll(bool state)
        {
            connection = Connection.getConnection(connection);
            _cbbTypeOfProductList.Clear();
            SqlCommand cmd = new SqlCommand("PR_CbbTypeOfProductGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfProductState", state);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _cbbTypeOfProductList.Add(new CbbTypeOfProduct
                {
                    TypeOfProductId = Convert.ToInt32(dr["TypeOfProductId"]),
                    TypeOfProductName = Convert.ToString(dr["TypeOfProductName"])
                });
            }
            Connection.endConnection(connection);
            return _cbbTypeOfProductList;
        }
    }
}

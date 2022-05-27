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
    public class MsBranchDiscountContentBranchProductDal : IBranchDiscountContentBranchProductDal
    {
        List<BranchDiscountContentBranchProduct> branchDiscountContentBranchProducts = new List<BranchDiscountContentBranchProduct>();
        List<BranchDiscountContentBranchProductDto> branchDiscountContentBranchProductDtos = new List<BranchDiscountContentBranchProductDto>();


        SqlConnection connection;
        public void Add(BranchDiscountContentBranchProduct entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchDiscountContentBranchProductAdd", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchDiscountContentId", entity.BranchDiscountContentId);
            cmd.Parameters.AddWithValue("BranchProductId", entity.BranchProductId);
            cmd.Parameters.AddWithValue("BranchDiscountContentBranchProductState", entity.BranchDiscountContentBranchProductState);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void ChangeState(int id, bool state)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchDiscountContentBranchProductChangeState", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchDiscountContentBranchProductId", id);
            cmd.Parameters.AddWithValue("BranchDiscountContentBranchProductState", !state);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }

        public void Delete(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchDiscountContentBranchProductDelete", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchDiscountContentBranchProductId", id);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }

        public BranchDiscountContentBranchProduct GetById(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchDiscountContentBranchProductGetById", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchDiscountContentBranchProductId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            Connection.endConnection(connection);
            return new BranchDiscountContentBranchProduct
            {
                BranchDiscountContentBranchProductId = id,
                BranchDiscountContentId = Convert.ToInt32(dr["BranchDiscountContentId"]),
                BranchProductId = Convert.ToInt32(dr["BranchProductId"]),
                BranchDiscountContentBranchProductPrice = Convert.ToDecimal(dr["BranchDiscountContentBranchProductPrice"]),
                BranchDiscountContentBranchProductState = Convert.ToBoolean(dr["BranchDiscountContentBranchProductState"])
            };
        }

        public List<BranchDiscountContentBranchProduct> GetAll(int? id)
        {
            connection = Connection.getConnection(connection);
            branchDiscountContentBranchProducts.Clear();
            SqlCommand cmd = new SqlCommand("PR_BranchDiscountContentBranchProductGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                branchDiscountContentBranchProducts.Add(new BranchDiscountContentBranchProduct
                {
                    BranchDiscountContentBranchProductId = Convert.ToInt32(dr["BranchDiscountContentBranchProductId"]),
                    BranchDiscountContentId = Convert.ToInt32(dr["BranchDiscountContentId"]),
                    BranchProductId = Convert.ToInt32(dr["BranchProductId"]),
                    BranchDiscountContentBranchProductPrice = Convert.ToDecimal(dr["BranchDiscountContentBranchProductPrice"]),
                    BranchDiscountContentBranchProductState = Convert.ToBoolean(dr["BranchDiscountContentBranchProductState"])
                });
            }
            Connection.endConnection(connection);
            return branchDiscountContentBranchProducts;
        }

        public void Update(BranchDiscountContentBranchProduct entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchDiscountContentBranchProductUpdate", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchDiscountContentId", entity.BranchDiscountContentId);
            cmd.Parameters.AddWithValue("BranchProductId", entity.BranchProductId);
            cmd.Parameters.AddWithValue("BranchDiscountContentBranchProductId", entity.BranchDiscountContentBranchProductId);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public List<BranchDiscountContentBranchProductDto> BranchDiscountContentBranchProductDtoGetByBranchDiscountContent(int branchDiscountContent)
        {
            connection = Connection.getConnection(connection);
            branchDiscountContentBranchProductDtos.Clear();
            SqlCommand cmd = new SqlCommand("PR_BranchDiscountContentBranchProductDtoGetByBranchDiscountContent", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchDiscountContentId", branchDiscountContent);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                branchDiscountContentBranchProductDtos.Add(new BranchDiscountContentBranchProductDto
                {
                    BranchDiscountContentBranchProductId = Convert.ToInt32(dr["BranchDiscountContentBranchProductId"]),
                    BranchDiscountContentId = Convert.ToInt32(dr["BranchDiscountContentId"]),
                    BranchDiscountContentName = Convert.ToString(dr["BranchDiscountContentName"]),
                    BranchProductId = Convert.ToInt32(dr["BranchProductId"]),
                    BranchProductName = Convert.ToString(dr["ProductName"]),
                    BranchDiscountContentBranchProductPrice = Convert.ToDecimal(dr["BranchDiscountContentBranchProductPrice"]),
                    BranchDiscountContentBranchProductState = Convert.ToBoolean(dr["BranchDiscountContentBranchProductState"])
                });
            }
            Connection.endConnection(connection);
            return branchDiscountContentBranchProductDtos;
        }

        public List<BranchDiscountContentBranchProduct> BranchDiscountContentBranchProductGetByBranchDiscountContent(int branchDiscountContentId, bool state)
        {
            connection = Connection.getConnection(connection);
            branchDiscountContentBranchProducts.Clear();
            SqlCommand cmd = new SqlCommand("PR_BranchDiscountContentBranchProductGetByBranchDiscountContent", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchDiscountContentId", branchDiscountContentId);
            cmd.Parameters.AddWithValue("BranchDiscountContentBranchProductState", state);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                branchDiscountContentBranchProducts.Add(new BranchDiscountContentBranchProduct
                {
                    BranchDiscountContentBranchProductId = Convert.ToInt32(dr["BranchDiscountContentBranchProductId"]),
                    BranchProductId = Convert.ToInt32(dr["BranchProductId"]),
                    BranchDiscountContentBranchProductPrice = Convert.ToDecimal(dr["BranchDiscountContentBranchProductPrice"])
                });
            }
            Connection.endConnection(connection);
            return branchDiscountContentBranchProducts;
        }

        public List<BranchDiscountContentBranchProductDto> BranchDiscountContentBranchProductDtoGetByBranchDiscountContent(int branchDiscountContentId, bool state)
        {
            branchDiscountContentBranchProductDtos.Clear();
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchDiscountContentBranchProductDtoGetByOrderBranchDiscountContent", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchDiscountContentId", branchDiscountContentId);
            cmd.Parameters.AddWithValue("BranchDiscountContentBranchProductState", state);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                branchDiscountContentBranchProductDtos.Add(new BranchDiscountContentBranchProductDto
                {
                    BranchDiscountContentBranchProductId = Convert.ToInt32(dr["BranchDiscountContentBranchProductId"]),
                    BranchDiscountContentId = Convert.ToInt32(dr["BranchDiscountContentId"]),
                    BranchDiscountContentName = Convert.ToString(dr["BranchDiscountContentName"]),
                    BranchProductId = Convert.ToInt32(dr["BranchProductId"]),
                    BranchProductName = Convert.ToString(dr["ProductName"]),
                    BranchDiscountContentBranchProductPrice = Convert.ToDecimal(dr["BranchDiscountContentBranchProductPrice"]),
                    BranchDiscountContentBranchProductState = Convert.ToBoolean(dr["BranchDiscountContentBranchProductState"])
                });
            }
            Connection.endConnection(connection);
            return branchDiscountContentBranchProductDtos;
        }
    }
}

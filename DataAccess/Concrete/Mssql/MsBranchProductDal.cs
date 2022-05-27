using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Mssql
{
    public class MsBranchProductDal : IBranchProductDal
    {
        List<BranchProductDto> _branchProductDtoList= new List<BranchProductDto>();
        List<BranchProduct> _branchProductList = new List<BranchProduct>();
        List<CbbBranchProduct> _cbbBranchProductList = new List<CbbBranchProduct>();


        SqlConnection connection;
        public void                         Add(BranchProduct entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchProductAdd", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ProductId", entity.ProductId);
            cmd.Parameters.AddWithValue("BranchProductPrice", entity.BranchProductPrice);
            cmd.Parameters.AddWithValue("BranchId", entity.BranchId);
            cmd.Parameters.AddWithValue("BranchStockStatus", entity.StockStatus);
            cmd.Parameters.AddWithValue("BranchProductState", entity.BranchProductState);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                         ChangeState(int id, bool state)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchProductChangeState", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchProductId", id);
            cmd.Parameters.AddWithValue("BranchProductState", !state);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                         Delete(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchProductDelete", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchProductId", id);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public BranchProduct                GetById(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchProductGetById", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchProductId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            return new BranchProduct
            {
                BranchProductId = id,
                BranchId = Convert.ToInt32(dr["BranchId"]),
                ProductId = Convert.ToInt32(dr["ProductId"]),
                BranchProductPrice = Convert.ToDecimal(dr["BranchProductPrice"]),
                StockStatus = Convert.ToBoolean(dr["BranchProductStockStatus"]),
                BranchProductState = Convert.ToBoolean(dr["BranchProductState"]),
            };
        }
        public List<BranchProduct>          GetAll(int? id)
        {
            connection = Connection.getConnection(connection);
            _branchProductList.Clear();
            SqlCommand cmd = new SqlCommand("PR_BranchProductGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _branchProductList.Add(new BranchProduct
                {
                    BranchProductId = Convert.ToInt32(dr["BranchProductId"]),
                    BranchId = Convert.ToInt32(dr["BranchId"]),
                    ProductId = Convert.ToInt32(dr["ProductId"]),
                    BranchProductPrice = Convert.ToDecimal(dr["BranchProductPrice"]),
                    StockStatus = Convert.ToBoolean(dr["BranchStockStatus"]),
                    BranchProductState = Convert.ToBoolean(dr["BranchProductState"])
                });
            }
            Connection.endConnection(connection);
            return _branchProductList;
        }
        public void                         Update(BranchProduct entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchProductUpdate", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchProductId", entity.BranchProductId);
            cmd.Parameters.AddWithValue("BranchProductPrice", entity.BranchProductPrice);
            cmd.Parameters.AddWithValue("BranchStockStatus", entity.StockStatus);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public List<BranchProductDto>       BranchProductDtoGetByBranch(int branchId, bool state)
        {
            connection = Connection.getConnection(connection);
            _branchProductDtoList.Clear();
            SqlCommand cmd = new SqlCommand("PR_BranchProductDtoGetByBranch", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchId", branchId);
            cmd.Parameters.AddWithValue("ProductState", state);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _branchProductDtoList.Add(new BranchProductDto
                {
                    BranchProductId = Convert.ToInt32(dr["BranchProductId"]),
                    ProductId = Convert.ToInt32(dr["ProductId"]),
                    ProductName = dr["ProductName"].ToString(),
                    BranchProductPrice = Convert.ToDecimal(dr["BranchProductPrice"]),
                    StockStatus = Convert.ToBoolean(dr["BranchStockStatus"]),
                    BranchProductState = Convert.ToBoolean(dr["BranchProductState"]),
                    ProductPrice = Convert.ToDecimal(dr["ProductPrice"]),
                    CategoryId = Convert.ToInt32(dr["CategoryId"]),
                    CategoryName =Convert.ToString(dr["CategoryName"]),
                    TypeOfProductId = Convert.ToInt32(dr["TypeOfProductId"]),
                    TypeOfProductName = Convert.ToString(dr["TypeOfProductName"])
                });
            }
            Connection.endConnection(connection);
            return _branchProductDtoList;
        }
        public List<BranchProductDto>       BranchProductDtoGetByCategory(int branchId, int categoryId, bool state)
        {
            connection = Connection.getConnection(connection);
            _branchProductDtoList.Clear();
            SqlCommand cmd = new SqlCommand("PR_BranchProductDtoGetByCategory", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchId", branchId);
            cmd.Parameters.AddWithValue("CategoryId", categoryId);
            cmd.Parameters.AddWithValue("BranchProductState", state);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _branchProductDtoList.Add(new BranchProductDto
                {
                    BranchProductId = Convert.ToInt32(dr["BranchProductId"].ToString()),
                    ProductId = Convert.ToInt32(dr["ProductId"]),
                    ProductName = dr["ProductName"].ToString(),
                    BranchProductPrice = Convert.ToDecimal(dr["BranchProductPrice"]),
                });
            }
            Connection.endConnection(connection);
            return _branchProductDtoList;
        }
        public List<CbbBranchProduct>       CbbBranchProductGetByBranch(int branchId, bool state)
        {
            connection = Connection.getConnection(connection);
            _cbbBranchProductList.Clear();
            SqlCommand cmd = new SqlCommand("PR_CbbBranchProductGetByBranch", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchId", branchId);
            cmd.Parameters.AddWithValue("BranchProductState", state);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _cbbBranchProductList.Add(new CbbBranchProduct
                {
                    BranchProductId = Convert.ToInt32(dr["BranchProductId"]),
                    ProductName = Convert.ToString(dr["ProductName"])
                });
            }
            Connection.endConnection(connection);
            return _cbbBranchProductList;
        }

    }
}

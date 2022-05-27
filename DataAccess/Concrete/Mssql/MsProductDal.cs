using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Concrete.Mssql
{
    public class MsProductDal : IProductDal
    {
        List<Product> _productList = new List<Product>();
        List<ProductDto> _productDtoList = new List<ProductDto>();
        List<CbbProduct> _cbbProductList = new List<CbbProduct>();

        SqlConnection connection;
        public void                                     Add(Product entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_ProductAdd", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ProductName", entity.ProductName);
            cmd.Parameters.AddWithValue("ProductCode", entity.ProductCode);
            cmd.Parameters.AddWithValue("ProductDescription", entity.ProductDescription);
            cmd.Parameters.AddWithValue("ProductPrice", entity.ProductPrice);
            cmd.Parameters.AddWithValue("CategoryId", entity.CategoryId);
            cmd.Parameters.AddWithValue("StockStatus", entity.StockStatus);
            cmd.Parameters.AddWithValue("TypeOfProductId", entity.TypeOfProductId);
            cmd.Parameters.AddWithValue("ProductState", entity.ProductState);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                                     ChangeState(int id, bool state)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_ProductChangeState", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ProductId", id);
            cmd.Parameters.AddWithValue("ProductState", !state);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                                     Delete(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_ProductDelete", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ProductId", id);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public Product                                  GetById(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_ProductGetById", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ProductId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            var product = new Product
            {
                ProductId = id,
                ProductName = dr["ProductName"].ToString(),
                ProductCode = dr["ProductCode"].ToString(),
                ProductDescription = dr["ProductDescription"].ToString(),
                ProductPrice = Convert.ToDecimal(dr["ProductPrice"]),
                StockStatus = Convert.ToBoolean(dr["StockStatus"]),
                CategoryId = Convert.ToInt32(dr["CategoryId"]),
                TypeOfProductId = Convert.ToInt32(dr["TypeOfProductId"]),
                ProductState = Convert.ToBoolean(dr["ProductState"])
            };
            Connection.endConnection(connection);
            return product;
        }
        public List<Product>                            GetAll(int? id)
        {
            connection = Connection.getConnection(connection);
            _productList.Clear();
            SqlCommand cmd = new SqlCommand("PR_ProductGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _productList.Add(new Product
                {
                    ProductId = Convert.ToInt32(dr["ProductId"]),
                    ProductName = dr["ProductName"].ToString(),
                    ProductCode = dr["ProductCode"].ToString(),
                    ProductDescription = dr["ProductDescription"].ToString(),
                    ProductPrice = Convert.ToDecimal(dr["ProductPrice"]),
                    CategoryId = Convert.ToInt32(dr["CategoryId"]),
                    StockStatus = Convert.ToBoolean(dr["StockStatus"]),
                    TypeOfProductId = Convert.ToInt32(dr["TypeOfProductId"]),
                    ProductState = Convert.ToBoolean(dr["ProductState"])
                });
            }
            Connection.endConnection(connection);
            return _productList;
        }
        public void                                     Update(Product entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_ProductUpdate", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ProductName", entity.ProductName);
            cmd.Parameters.AddWithValue("ProductCode", entity.ProductCode);
            cmd.Parameters.AddWithValue("ProductDescription", entity.ProductDescription);
            cmd.Parameters.AddWithValue("ProductPrice", entity.ProductPrice);
            cmd.Parameters.AddWithValue("StockStatus", entity.StockStatus);
            cmd.Parameters.AddWithValue("CategoryId", entity.CategoryId);
            cmd.Parameters.AddWithValue("TypeOfProductId", entity.TypeOfProductId);
            cmd.Parameters.AddWithValue("ProductId", entity.ProductId);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public List<ProductDto>                         ProductDtoGetAll()
        {
            connection = Connection.getConnection(connection);
            _productDtoList.Clear();
            SqlCommand cmd = new SqlCommand("PR_ProductDtoGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _productDtoList.Add(new ProductDto
                {
                    ProductId = Convert.ToInt32(dr["ProductId"]),
                    ProductName = dr["ProductName"].ToString(),
                    ProductCode = dr["ProductCode"].ToString(),
                    ProductDescription = dr["ProductDescription"].ToString(),
                    ProductPrice = Convert.ToDecimal(dr["ProductPrice"]),
                    StockStatus = Convert.ToBoolean(dr["StockStatus"]),
                    CategoryId = Convert.ToInt32(dr["CategoryId"]),
                    CategoryName = dr["CategoryName"].ToString(),
                    TypeOfProductId = Convert.ToInt32(dr["TypeOfProductId"]),
                    TypeOfProductName = dr["TypeOfProductName"].ToString(),
                    ProductState = Convert.ToBoolean(dr["ProductState"])
                });
            }
            Connection.endConnection(connection);
            return _productDtoList;
        }
        public List<CbbProduct>                         CbbProductGetNotAvailableInBranchProduct(int branchId, bool state)
        {
            connection = Connection.getConnection(connection);
            _cbbProductList.Clear();
            SqlCommand cmd = new SqlCommand("PR_CbbProductGetNotAvailableInBranchProduct", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchId", branchId);
            cmd.Parameters.AddWithValue("ProductState", state);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _cbbProductList.Add(new CbbProduct
                {
                    ProductId = Convert.ToInt32(dr["ProductId"]),
                    ProductName = Convert.ToString(dr["ProductName"])
                });
            }
            Connection.endConnection(connection);
            return _cbbProductList;
        }
        public List<Product>                            ProductGetByCategory(int categoryId, bool state)
        {
            connection = Connection.getConnection(connection);
            _productList.Clear();
            SqlCommand cmd = new SqlCommand("PR_ProductGetByCategory", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("CategoryId", categoryId);
            cmd.Parameters.AddWithValue("ProductState", state);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _productList.Add(new Product
                {
                    ProductId = Convert.ToInt32(dr["ProductId"]),
                    ProductName = dr["ProductName"].ToString(),
                    ProductCode = dr["ProductCode"].ToString(),
                    ProductDescription = dr["ProductDescription"].ToString(),
                    ProductPrice = Convert.ToDecimal(dr["ProductPrice"]),
                    CategoryId = Convert.ToInt32(dr["CategoryId"]),
                    TypeOfProductId = Convert.ToInt32(dr["TypeOfProductId"]),
                    StockStatus = Convert.ToBoolean(dr["StockStatus"]),
                    ProductState = Convert.ToBoolean(dr["ProductState"])
                });
            }
            Connection.endConnection(connection);
            return _productList;
        }
    }
}

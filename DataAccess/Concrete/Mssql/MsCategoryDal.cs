using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Concrete.Mssql
{
    public class MsCategoryDal : ICategoryDal
    {
        List<Category> _categoryList = new List<Category>();
        List<CbbCategory> _cbbCategoryList = new List<CbbCategory>();
        private SqlConnection connection;
        public void                                 Add(Category entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_CategoryAdd", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("CategoryName", entity.CategoryName);
            cmd.Parameters.AddWithValue("CategoryCode", entity.CategoryCode);
            cmd.Parameters.AddWithValue("CategoryDescription", entity.CategoryDescription);
            cmd.Parameters.AddWithValue("CategoryState", entity.CategoryState);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                                 ChangeState(int id, bool state)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_CategoryChangeState", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("CategoryId", id);
            cmd.Parameters.AddWithValue("CategoryState", !state);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                                 Delete(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_CategoryDelete", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("CategoryId", id);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public Category                             GetById(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_CategoryGetById", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("CategoryId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            var category = new Category
            {
                CategoryId = id,
                CategoryName = dr["CategoryName"].ToString(),
                CategoryCode = dr["CategoryCode"].ToString(),
                CategoryDescription = dr["CategoryDescription"].ToString(),
                CategoryState = Convert.ToBoolean(dr["CategoryState"])
            };
            Connection.endConnection(connection);
            return category;
        }
        public List<Category>                       GetAll(int? id)
        {
            connection = Connection.getConnection(connection);
            _categoryList.Clear();
            SqlCommand cmd = new SqlCommand("PR_CategoryGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _categoryList.Add(new Category
                {
                    CategoryId = Convert.ToInt32(dr["CategoryId"]),
                    CategoryName = dr["CategoryName"].ToString(),
                    CategoryCode = dr["CategoryCode"].ToString(),
                    CategoryDescription = dr["CategoryDescription"].ToString(),
                    CategoryState = Convert.ToBoolean(dr["CategoryState"])
                });
            }
            Connection.endConnection(connection);
            return _categoryList;
        }
        public void                                 Update(Category entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_CategoryUpdate", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("CategoryName", entity.CategoryName);
            cmd.Parameters.AddWithValue("CategoryCode", entity.CategoryCode);
            cmd.Parameters.AddWithValue("CategoryDescription", entity.CategoryDescription);
            cmd.Parameters.AddWithValue("CategoryId", entity.CategoryId);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public List<CbbCategory>                    CbbCategoryGetAll(bool state)
        {
            connection = Connection.getConnection(connection);
            _cbbCategoryList.Clear();
            SqlCommand cmd = new SqlCommand("PR_CbbCategoryGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("CategoryState", state);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _cbbCategoryList.Add(new CbbCategory
                {
                    CategoryId = Convert.ToInt32(dr["CategoryId"]),
                    CategoryName = dr["CategoryName"].ToString()
                });
            }
            Connection.endConnection(connection);
            return _cbbCategoryList;
        }
    }
}

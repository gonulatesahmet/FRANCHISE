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
    public class MsPageAuthDal : IPageAuthDal
    {
        List<PageAuth> pageAuthList = new List<PageAuth>();
        List<PageAuthDto> pageAuthDtos = new List<PageAuthDto>();
        SqlConnection connection;
        public void Add(PageAuth entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_PageAuthAdd", connection);
            cmd.Parameters.AddWithValue("PageId", entity.PageId);
            cmd.Parameters.AddWithValue("AuthId", entity.AuthId);
            cmd.Parameters.AddWithValue("PageAuthState", entity.PageAuthState);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }

        public void ChangeState(int id, bool state)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_PageAuthChangeState", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("PageAuthId", id);
            cmd.Parameters.AddWithValue("PageAuthState", state);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }

        public void Delete(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_PageAuthDelete", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("PageAuthId", id);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }

        public List<PageAuth> GetAll(int? id)
        {
            pageAuthList.Clear();
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_PageAuthGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                pageAuthList.Add(new PageAuth
                {
                    PageAuthId = Convert.ToInt32(dr["PageAuthId"]),
                    AuthId = Convert.ToInt32(dr["AuthId"]),
                    PageId = Convert.ToInt32(dr["PageId"]),
                    PageAuthState = Convert.ToBoolean(dr["PageAuthState"])
                });
            }
            Connection.endConnection(connection);
            return pageAuthList;
        }

        public PageAuth GetById(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_PageAuthGetById", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("PageAuthId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                var pageAuth = new PageAuth
                {
                    PageAuthId = id,
                    AuthId = Convert.ToInt32(dr["AuthId"]),
                    PageId = Convert.ToInt32(dr["PageId"]),
                    PageAuthState = Convert.ToBoolean(dr["PageAuthState"])
                };
                return pageAuth;
            }
            else return null;
        }

        public void Update(PageAuth entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_PageAuthUpdate", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("PageId", entity.PageId);
            cmd.Parameters.AddWithValue("AuthId", entity.AuthId);
            cmd.Parameters.AddWithValue("PageAuthId", entity.PageAuthId);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public List<PageAuthDto> PageAuthDtoGetByAuth(int AuthId)
        {
            pageAuthDtos.Clear();
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_PageAuthDtoGetByAuth", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AuthId", AuthId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                pageAuthDtos.Add(new PageAuthDto
                {
                    PageAuthId = Convert.ToInt32(dr["PageAuthId"]),
                    PageId = Convert.ToInt32(dr["PageId"]),
                    PageText = Convert.ToString(dr["PageText"]),
                    AuthId = AuthId,
                    AuthName = Convert.ToString(dr["AuthName"]),
                    PageAuthState = Convert.ToBoolean(dr["PageAuthState"])
                });
            }
            Connection.endConnection(connection);
            return pageAuthDtos;
        }

        public List<PageAuth> PageAuthGetByAuth(int AuthId)
        {
            pageAuthList.Clear();
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_PageAuthGetByAuth", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AuthId", AuthId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                pageAuthList.Add(new PageAuth
                {
                    PageAuthId = Convert.ToInt32(dr["PageAuthId"]),
                    AuthId = AuthId,
                    PageId = Convert.ToInt32(dr["PageId"]),
                    PageAuthState = Convert.ToBoolean(dr["PageAuthState"])
                });
            }
            Connection.endConnection(connection);
            return pageAuthList;
        }

    }
}

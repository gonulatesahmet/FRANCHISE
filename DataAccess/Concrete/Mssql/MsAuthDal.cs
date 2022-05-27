using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Concrete.Mssql
{
    public class MsAuthDal : IAuthDal
    {
        List<Auth> authList = new List<Auth>();
        List<CbbAuth> cbbAuthList = new List<CbbAuth>();

        SqlConnection connection;
        public void Add(Auth entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_AuthAdd", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AuthName", entity.AuthName);
            cmd.Parameters.AddWithValue("AuthCode", entity.AuthCode);
            cmd.Parameters.AddWithValue("AuthDescription", entity.AuthDescription);
            cmd.Parameters.AddWithValue("AuthState", entity.AuthState);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }

        public void ChangeState(int id, bool state)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_AuthChangeState", connection);
            cmd.CommandType= System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AuthId", id);
            cmd.Parameters.AddWithValue("AuthState", !state);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }

        public void Delete(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_AuthDelete", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AuthId", id);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }

        public Auth GetById(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_AuthGetById", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AuthId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            return (new Auth
            {
                AuthId = id,
                AuthName = dr["AuthName"].ToString(),
                AuthCode = dr["AuthCode"].ToString(),
                AuthDescription = dr["AuthDescription"].ToString(),
                AuthState = Convert.ToBoolean(dr["AuthState"])
            });
        }

        public List<Auth> GetAll(int? id)
        {
            connection = Connection.getConnection(connection);
            authList.Clear();
            SqlCommand cmd = new SqlCommand("PR_AuthGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                authList.Add(new Auth
                {
                    AuthId = Convert.ToInt32(dr["AuthId"]),
                    AuthName = dr["AuthName"].ToString(),
                    AuthCode = dr["AuthCode"].ToString(),
                    AuthDescription = dr["AuthDescription"].ToString(),
                    AuthState = Convert.ToBoolean(dr["AuthState"])
                });
            }
            Connection.endConnection(connection);
            return authList;
        }

        public void Update(Auth entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_AuthUpdate", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AuthName", entity.AuthName);
            cmd.Parameters.AddWithValue("AuthCode", entity.AuthCode);
            cmd.Parameters.AddWithValue("AuthDescription", entity.AuthDescription);
            cmd.Parameters.AddWithValue("AuthId", entity.AuthId);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }

        public List<CbbAuth> CbbAuthGetAll(bool state)
        {
            connection=Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_CbbAuthGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AuthState", state);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbbAuthList.Add(new CbbAuth
                {
                    AuthId = Convert.ToInt32(dr["AuthId"]),
                    AuthName = Convert.ToString(dr["AuthName"])
                });
            }
            Connection.endConnection(connection);
            return cbbAuthList;
        }
    }
}

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
    public class MsAppellationDal : IAppellationDal
    {
        List<Appellation> appellation = new List<Appellation>();
        List<CbbAppellation> cbbAppellation = new List<CbbAppellation>();
        SqlConnection connection;
        public void                     Add(Appellation entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_AppellationAdd", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AppellationName", entity.AppellationName);
            cmd.Parameters.AddWithValue("AppellationCode", entity.AppellationCode);
            cmd.Parameters.AddWithValue("AppellationDescription", entity.AppellationDescription);
            cmd.Parameters.AddWithValue("AppellationState", entity.AppellationState);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                     ChangeState(int id, bool state)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_AppellationChangeState", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AppellationId", id);
            cmd.Parameters.AddWithValue("AppellationState", !state);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                     Delete(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_AppellationDelete", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AppellationId", id);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public Appellation              GetById(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_AppellationGetById", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AppellationId", id);
            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();
            var appellation = new Appellation
            {
                AppellationId = id,
                AppellationName = dr["AppellationName"].ToString(),
                AppellationCode = dr["AppellationCode"].ToString(),
                AppellationDescription = dr["AppellationDescription"].ToString(),
                AppellationState = Convert.ToBoolean(dr["AppellationState"])
            };
            Connection.endConnection(connection);
            return appellation;
        }
        public List<Appellation>        GetAll(int? id)
        {
            connection = Connection.getConnection(connection);
            appellation.Clear();
            SqlCommand cmd = new SqlCommand("PR_AppellationGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                appellation.Add(new Appellation
                {
                    AppellationId = Convert.ToInt32(dr["AppellationId"]),
                    AppellationName = Convert.ToString(dr["AppellationName"]),
                    AppellationCode = Convert.ToString(dr["AppellationCode"]),
                    AppellationDescription = Convert.ToString(dr["AppellationDescription"]),
                    AppellationState = Convert.ToBoolean(dr["AppellationState"])
                });
            }
            Connection.endConnection(connection);
            return appellation;
        }
        public void                     Update(Appellation entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_AppellationUpdate", connection);
            cmd.CommandType= System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AppellationName", entity.AppellationName);
            cmd.Parameters.AddWithValue("AppellationCode", entity.AppellationCode);
            cmd.Parameters.AddWithValue("AppellationDescription", entity.AppellationDescription);
            cmd.Parameters.AddWithValue("AppellationId", entity.AppellationId);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public List<CbbAppellation>     CbbAppellationGetAll(bool state)
        {
            connection = Connection.getConnection(connection);
            cbbAppellation.Clear();
            SqlCommand cmd = new SqlCommand("PR_CbbAppellationGetAll", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
            };
            cmd.Parameters.AddWithValue("AppellationState", state);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbbAppellation.Add(new CbbAppellation
                {
                    AppellationId = Convert.ToInt32(dr["AppellationId"]),
                    AppellationName = Convert.ToString(dr["AppellationName"])
                });
            }
            Connection.endConnection(connection);
            return cbbAppellation;
        }
    }
}

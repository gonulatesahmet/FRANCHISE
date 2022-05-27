using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Concrete.Mssql
{
    public class MsSessionDal : ISessionDal
    {
        Session session = new Session();
        SqlConnection connection;
        public void Add(Session entity)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeState(int id, bool state)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_SessionDelete", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("SessionId", id);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }

        public Session GetById(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_SessionGetById", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("SessionId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                session.StartDate = Convert.ToDateTime(dr["SessionStartDate"]);
                session.TableId = Convert.ToInt32(dr["TableId"]);
                session.TotalPrice = Convert.ToDecimal(dr["SessionTotalPrice"]);
                session.BranchId = Convert.ToInt32(dr["BranchId"]);
                session.SessionState = Convert.ToBoolean(dr["SessionState"]);
                session.SessionId = id;
            }
            Connection.endConnection(connection);
            return session;
            
        }

        public List<Session> GetAll(int? id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Session entity)
        {
            throw new System.NotImplementedException();
        }

        public int SessionAdd(Session entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_SessionAdd", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("SessionStartDate", entity.StartDate);
            cmd.Parameters.AddWithValue("SessionTotalPrice", entity.TotalPrice);
            cmd.Parameters.AddWithValue("TableId", entity.TableId);
            cmd.Parameters.AddWithValue("BranchId", entity.BranchId);
            cmd.Parameters.AddWithValue("SessionState", entity.SessionState);
            cmd.Parameters.Add("SessionId", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();
            int SessionId = Convert.ToInt32(cmd.Parameters["SessionId"].Value);
            Connection.endConnection(connection);
            return SessionId;
        }
        public Session SessionControl(int tableId, bool state)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_SessionControl", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TableId", tableId);
            cmd.Parameters.AddWithValue("SessionState", state);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                var session = new Session
                {
                    SessionId = Convert.ToInt32(dr["SessionId"]),
                    TableId = tableId,
                    StartDate = Convert.ToDateTime(dr["SessionStartDate"]),
                    TotalPrice = Convert.ToDecimal(dr["SessionTotalPrice"])
                };
                Connection.endConnection(connection);
                return session;
            }
            else return null;
        }

        public void SessionEnd(Session entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_SessionEnd", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("SessionId", entity.SessionId);
            cmd.Parameters.AddWithValue("SessionDueDate", entity.DueDate);
            cmd.Parameters.AddWithValue("SessionState", entity.SessionState);
            cmd.Parameters.AddWithValue("SessionTotalPrice", entity.TotalPrice);

            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }

        public void MoveTheTable(int sessionId, int tableId)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_MoveTheTable", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("SessionId", sessionId);
            cmd.Parameters.AddWithValue("TableId", tableId);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
    }
}

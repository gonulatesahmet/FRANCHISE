using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Mssql
{
    public class MsInstitutionDal : IInstitutionDal
    {
        List<Institution> _institutionList = new List<Institution>();
        SqlConnection connection;
        public void                             Add(Institution entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_InstitutionAdd", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("InstitutionName", entity.InstitutionName);
            cmd.Parameters.AddWithValue("InstitutionCode", entity.InstitutionCode);
            cmd.Parameters.AddWithValue("InstitutionDescription", entity.InstitutionDescription);
            cmd.Parameters.AddWithValue("UserName", entity.UserName);
            cmd.Parameters.AddWithValue("UserPassword", entity.UserPassword);
            cmd.Parameters.AddWithValue("InstitutionMail", entity.InstitutionMail);
            cmd.Parameters.AddWithValue("InstitutionPhone", entity.InstitutionPhone);
            cmd.Parameters.AddWithValue("InstitutionAddress", entity.InstitutionAddress);
            cmd.Parameters.AddWithValue("InstitutionState", entity.InstitutionState);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                             ChangeState(int id, bool state)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_InstitutionChangeState", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("InstitutionId", id);
            cmd.Parameters.AddWithValue("InstitutionState", state);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);

        }
        public void                             Delete(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_InstitutionDelete", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("InstitutionId", id);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public Institution                      GetById(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_InstitutionGetById", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("InstitutionId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            Institution institution = new Institution
            {
                InstitutionId = id,
                InstitutionName = Convert.ToString(dr["InstitutionName"]),
                InstitutionCode = Convert.ToString(dr["InstitutionCode"]),
                InstitutionDescription = Convert.ToString(dr["InstitutionDescription"]),
                UserName = Convert.ToString(dr["UserName"]),
                UserPassword = Convert.ToString(dr["UserPassword"]),
                InstitutionMail = Convert.ToString(dr["InstitutionMail"]),
                InstitutionPhone = Convert.ToString(dr["InstitutionPhone"]),
                InstitutionAddress = Convert.ToString(dr["InstitutionAddress"]),
                InstitutionState = Convert.ToBoolean(dr["InstitutionState"])
            };
            dr.Close();
            Connection.endConnection(connection);
            return institution;
        }
        public List<Institution>                GetAll(int? id)
        {
            connection = Connection.getConnection(connection);
            _institutionList.Clear();
            SqlCommand cmd = new SqlCommand("PR_InstitutionGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _institutionList.Add(new Institution
                {
                    InstitutionId = Convert.ToInt32(dr["InstitutionId"]),
                    InstitutionName = Convert.ToString(dr["InstitutionName"]),
                    InstitutionCode = Convert.ToString(dr["InstitutionCode"]),
                    InstitutionDescription = Convert.ToString(dr["InstitutionDescription"]),
                    UserName = Convert.ToString(dr["UserName"]),
                    UserPassword = Convert.ToString(dr["UserPassword"]),
                    InstitutionMail = Convert.ToString(dr["InstitutionMail"]),
                    InstitutionPhone = Convert.ToString(dr["InstitutionPhone"]),
                    InstitutionAddress = Convert.ToString(dr["InstitutionAddress"]),
                    InstitutionState = Convert.ToBoolean(dr["InstitutionState"])
                });
            }
            Connection.endConnection(connection);
            return _institutionList;
        }
        public List<Institution>                InstitutionGetByState(bool state)
        {
            connection = Connection.getConnection(connection);
            _institutionList.Clear();
            SqlCommand cmd = new SqlCommand("PR_InstitutionGetByState", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("InstitutionState", state);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _institutionList.Add(new Institution
                {
                    InstitutionId = Convert.ToInt32(dr["InstitutionId"]),
                    InstitutionName = Convert.ToString(dr["InstitutionName"]),
                    InstitutionCode = Convert.ToString(dr["InstitutionCode"]),
                    InstitutionDescription = Convert.ToString(dr["InstitutionDescription"]),
                    UserName = Convert.ToString(dr["UserName"]),
                    UserPassword = Convert.ToString(dr["UserPassword"]),
                    InstitutionMail = Convert.ToString(dr["InstitutionMail"]),
                    InstitutionPhone = Convert.ToString(dr["InstitutionPhone"]),
                    InstitutionAddress = Convert.ToString(dr["InstitutionAddress"]),
                    InstitutionState = Convert.ToBoolean(dr["InstitutionState"])
                });
            }
            Connection.endConnection(connection);
            return _institutionList;
        }
        public void                             Update(Institution entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_InstitutionUpdate", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("InstitutionName", entity.InstitutionName);
            cmd.Parameters.AddWithValue("InstitutionCode", entity.InstitutionCode);
            cmd.Parameters.AddWithValue("InstitutionDescription", entity.InstitutionDescription);
            cmd.Parameters.AddWithValue("UserName", entity.UserName);
            cmd.Parameters.AddWithValue("UserPassword", entity.UserPassword);
            cmd.Parameters.AddWithValue("InstitutionMail", entity.InstitutionMail);
            cmd.Parameters.AddWithValue("InstitutionPhone", entity.InstitutionPhone);
            cmd.Parameters.AddWithValue("InstitutionAddress", entity.InstitutionAddress);
            cmd.Parameters.AddWithValue("InstitutionId", entity.InstitutionId);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
    }
}

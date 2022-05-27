using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Concrete.Mssql
{
    public class MsBranchDal : IBranchDal
    {
        List<Branch> branchList = new List<Branch>();
        List<CbbBranch> cbbBranchList = new List<CbbBranch>();

        SqlConnection connection;
        public void                             Add(Branch entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchAdd", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchName", entity.BranchName);
            cmd.Parameters.AddWithValue("BranchCode", entity.BranchCode);
            cmd.Parameters.AddWithValue("BranchDescription", entity.BranchDescription);
            cmd.Parameters.AddWithValue("AuthorizedPerson", entity.AuthorizedPerson);
            cmd.Parameters.AddWithValue("BranchPhone", entity.BranchPhone);
            cmd.Parameters.AddWithValue("BranchMail", entity.BranchMail);
            cmd.Parameters.AddWithValue("BranchAddress", entity.BranchAddress);
            cmd.Parameters.AddWithValue("BranchRegion", entity.BranchRegion);
            cmd.Parameters.AddWithValue("BranchCity", entity.BranchCity);
            cmd.Parameters.AddWithValue("BranchDistrict", entity.BranchDistrict);
            cmd.Parameters.AddWithValue("BranchState", entity.BranchState);
            cmd.Parameters.AddWithValue("InstitutionId", entity.InstitutionId);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                             Update(Branch entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchUpdate", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchName", entity.BranchName);
            cmd.Parameters.AddWithValue("BranchCode", entity.BranchCode);
            cmd.Parameters.AddWithValue("BranchDescription", entity.BranchDescription);
            cmd.Parameters.AddWithValue("AuthorizedPerson", entity.AuthorizedPerson);
            cmd.Parameters.AddWithValue("BranchPhone", entity.BranchPhone);
            cmd.Parameters.AddWithValue("BranchMail", entity.BranchMail);
            cmd.Parameters.AddWithValue("BranchRegion", entity.BranchRegion);
            cmd.Parameters.AddWithValue("BranchCity", entity.BranchCity);
            cmd.Parameters.AddWithValue("BranchDistrict", entity.BranchDistrict);
            cmd.Parameters.AddWithValue("BranchAddress", entity.BranchAddress);
            cmd.Parameters.AddWithValue("BranchId", entity.BranchId);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                             ChangeState(int id, bool state)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchChangeState", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchId", id);
            cmd.Parameters.AddWithValue("BranchState", !state);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                             Delete(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchDelete", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchId", id);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public Branch                           GetById(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchGetById", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchId", id);
            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();
            return new Branch
            {
                BranchId = id,
                InstitutionId = Convert.ToInt32(dr["InstitutionId"]),
                BranchName = dr["BranchName"].ToString(),
                BranchCode = dr["BranchCode"].ToString(),
                BranchDescription = dr["BranchDescription"].ToString(),
                AuthorizedPerson = dr["AuthorizedPerson"].ToString(),
                BranchMail = dr["BranchMail"].ToString(),
                BranchPhone = dr["BranchPhone"].ToString(),
                BranchAddress = dr["BranchAddress"].ToString(),
                BranchRegion = dr["BranchRegion"].ToString(),
                BranchCity = dr["BranchCity"].ToString(),
                BranchDistrict = dr["BranchDistrict"].ToString(),
                BranchState = Convert.ToBoolean(dr["BranchState"])
            };
        }
        public List<Branch>                     GetAll(int? id)
        {
            connection = Connection.getConnection(connection);
            branchList.Clear();
            SqlCommand cmd = new SqlCommand("PR_BranchGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("InstitutionId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                branchList.Add(new Branch
                {
                    BranchId = Convert.ToInt32(dr["BranchId"]),
                    BranchName = dr["BranchName"].ToString(),
                    BranchCode = dr["BranchCode"].ToString(),
                    BranchDescription = dr["BranchDescription"].ToString(),
                    AuthorizedPerson = dr["AuthorizedPerson"].ToString(),
                    BranchMail = dr["BranchMail"].ToString(),
                    BranchPhone = dr["BranchPhone"].ToString(),
                    BranchAddress = dr["BranchAddress"].ToString(),
                    BranchRegion = dr["BranchRegion"].ToString(),
                    BranchCity = dr["BranchCity"].ToString(),
                    BranchDistrict = dr["BranchDistrict"].ToString(),
                    InstitutionId = Convert.ToInt32(dr["InstitutionId"]),
                    BranchState = Convert.ToBoolean(dr["BranchState"])
                });
            }
            Connection.endConnection(connection);
            return branchList;
        }
        public List<CbbBranch>                  CbbBranchGetAll(int InstitutionId, bool BranchState)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_CbbBranchGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchState", BranchState);
            cmd.Parameters.AddWithValue("InstitutionId", InstitutionId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbbBranchList.Add(new CbbBranch
                {
                    BranchId = Convert.ToInt32(dr["BranchId"]),
                    BranchName = dr["BranchName"].ToString()
                });
            }
            Connection.endConnection(connection);
            return cbbBranchList;
        }
    }
}

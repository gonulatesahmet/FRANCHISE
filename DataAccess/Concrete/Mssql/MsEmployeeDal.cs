using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Concrete.Mssql
{
    public class MsEmployeeDal : IEmployeeDal
    {
        List<Employee> _employeeList = new List<Employee>();
        List<EmployeeDto> _employeeDtoList = new List<EmployeeDto>();

        SqlConnection connection;
        public void                                     Add(Employee entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_EmployeeAdd", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("EmployeeName", entity.EmployeeName);
            cmd.Parameters.AddWithValue("EmployeeSurname", entity.EmployeeSurname);
            cmd.Parameters.AddWithValue("EmployeeIdNumber", entity.EmployeeIdNumber);
            cmd.Parameters.AddWithValue("EmployeeBirthDate", entity.EmployeeBirthDate);
            cmd.Parameters.AddWithValue("EmployeeCode", entity.EmployeeCode);
            cmd.Parameters.AddWithValue("EmployeePhone", entity.EmployeePhone);
            cmd.Parameters.AddWithValue("EmployeeMail", entity.EmployeeMail);
            cmd.Parameters.AddWithValue("EmployeeAddress", entity.EmployeeAddress);
            cmd.Parameters.AddWithValue("AppellationId", entity.AppellationId);
            cmd.Parameters.AddWithValue("BranchId", entity.BranchId);
            cmd.Parameters.AddWithValue("EmployeeState", entity.EmployeeState);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                                     ChangeState(int id, bool state)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_EmployeeChangeState", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("EmployeeId", id);
            cmd.Parameters.AddWithValue("EmployeeState", !state);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                                     Delete(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_EmployeeDelete", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("EmployeeId", id);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public Employee                                 GetById(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_EmployeeGetById", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("EmployeeId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            return new Employee
            {
                EmployeeId = id,
                EmployeeName = dr["EmployeeName"].ToString(),
                EmployeeSurname = dr["EmployeeSurname"].ToString(),
                EmployeeIdNumber = dr["EmployeeIdNumber"].ToString(),
                EmployeeBirthDate = Convert.ToDateTime(dr["EmployeeBirthDate"]),
                EmployeeCode = dr["EmployeeCode"].ToString(),
                EmployeePhone = dr["EmployeePhone"].ToString(),
                EmployeeMail = dr["EmployeeMail"].ToString(),
                EmployeeAddress = dr["EmployeeAddress"].ToString(),
                AppellationId = Convert.ToInt32(dr["AppellationId"]),
                BranchId = Convert.ToInt32(dr["BranchId"]),
                EmployeeState = Convert.ToBoolean(dr["EmployeeState"])
            };
        }
        public List<Employee>                           GetAll(int? id)
        {
            connection = Connection.getConnection(connection);
            _employeeList.Clear();
            SqlCommand cmd = new SqlCommand("PR_EmployeeGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _employeeList.Add(new Employee
                {
                    EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                    EmployeeName = dr["EmployeeName"].ToString(),
                    EmployeeSurname = dr["EmployeeSurname"].ToString(),
                    EmployeeIdNumber = dr["EmployeeIdNumber"].ToString(),
                    EmployeeBirthDate = Convert.ToDateTime(dr["EmployeeBirthDate"]),
                    EmployeeCode = dr["EmployeeCode"].ToString(),
                    EmployeePhone = dr["EmployeePhone"].ToString(),
                    EmployeeMail = dr["EmployeeMail"].ToString(),
                    EmployeeAddress = dr["EmployeeAddress"].ToString(),
                    AppellationId = Convert.ToInt32(dr["AppellationId"]),
                    BranchId = Convert.ToInt32(dr["BranchId"]),
                    EmployeeState = Convert.ToBoolean(dr["EmployeeState"])
                });
            }
            Connection.endConnection(connection);
            return _employeeList;
        }
        public void                                     Update(Employee entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_EmployeeUpdate", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("EmployeeName", entity.EmployeeName);
            cmd.Parameters.AddWithValue("EmployeeSurname", entity.EmployeeSurname);
            cmd.Parameters.AddWithValue("EmployeeIdNumber", entity.EmployeeIdNumber);
            cmd.Parameters.AddWithValue("EmployeeBirthDate", entity.EmployeeBirthDate);
            cmd.Parameters.AddWithValue("EmployeeCode", entity.EmployeeCode);
            cmd.Parameters.AddWithValue("EmployeePhone", entity.EmployeePhone);
            cmd.Parameters.AddWithValue("EmployeeMail", entity.EmployeeMail);
            cmd.Parameters.AddWithValue("EmployeeAddress", entity.EmployeeAddress);
            cmd.Parameters.AddWithValue("AppellationId", entity.AppellationId);
            cmd.Parameters.AddWithValue("BranchId", entity.BranchId);
            cmd.Parameters.AddWithValue("EmployeeId", entity.EmployeeId);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public List<EmployeeDto>                        EmployeeDtoGetByBranch(int branchId)
        {
            connection = Connection.getConnection(connection);
            _employeeDtoList.Clear();
            SqlCommand cmd = new SqlCommand("PR_EmployeeDtoGetByBranch", connection);
            cmd.CommandType=System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchId", branchId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                connection = Connection.getConnection(connection);
                _employeeDtoList.Add(new EmployeeDto
                {
                    EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                    EmployeeName = dr["EmployeeName"].ToString(),
                    EmployeeSurname = dr["EmployeeSurname"].ToString(),
                    EmployeeIdNumber = dr["EmployeeIdNumber"].ToString(),
                    EmployeeBirthDate = Convert.ToDateTime(dr["EmployeeBirthDate"]),
                    EmployeeCode = dr["EmployeeCode"].ToString(),
                    EmployeePhone = dr["EmployeePhone"].ToString(),
                    EmployeeMail = dr["EmployeeMail"].ToString(),
                    EmployeeAddress = dr["EmployeeAddress"].ToString(),
                    AppellationId = Convert.ToInt32(dr["AppellationId"]),
                    AppellationName = dr["AppellationName"].ToString(),
                    BranchId = Convert.ToInt32(dr["BranchId"]),
                    BranchName = dr["BranchName"].ToString(),
                    EmployeeState = Convert.ToBoolean(dr["EmployeeState"])
                });
            }
            Connection.endConnection(connection);
            return _employeeDtoList;
        }
        public Employee                                 EmployeeGetByCode(string code)
        {
            try
            {
                connection = Connection.getConnection(connection);
                SqlCommand cmd = new SqlCommand("PR_EmployeeGetByCode", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("EmployeeCode", code);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    var employee = new Employee
                    {
                        EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                        EmployeeName = dr["EmployeeName"].ToString(),
                        EmployeeSurname = dr["EmployeeSurname"].ToString(),
                        EmployeeIdNumber = dr["EmployeeIdNumber"].ToString(),
                        EmployeeBirthDate = Convert.ToDateTime(dr["EmployeeBirthDate"]),
                        EmployeeCode = dr["EmployeeCode"].ToString(),
                        EmployeePhone = dr["EmployeePhone"].ToString(),
                        EmployeeMail = dr["EmployeeMail"].ToString(),
                        EmployeeAddress = dr["EmployeeAddress"].ToString(),
                        AppellationId = Convert.ToInt32(dr["AppellationId"]),
                        BranchId = Convert.ToInt32(dr["BranchId"]),
                        EmployeeState = Convert.ToBoolean(dr["EmployeeState"])
                    };
                    Connection.endConnection(connection);
                    return employee;
                }
                else return null;
                
            }
            catch (Exception)
            {
                Connection.endConnection(connection);
                return null;
            }
        }

        public List<Employee> CbbEmployeeGetByBranch(int branchId)
        {
            _employeeList.Clear();
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_CbbEmployeeGetByBranch", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchId", branchId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _employeeList.Add(new Employee
                {
                    EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                    EmployeeName = Convert.ToString(dr["EmployeeName"])
                });
            }
            Connection.endConnection(connection);
            return _employeeList;
        }
    }
}

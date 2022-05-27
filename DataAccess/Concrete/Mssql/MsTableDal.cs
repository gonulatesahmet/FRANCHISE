using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Concrete.Mssql
{
    public class MsTableDal : ITableDal
    {
        List<Table> _tableList= new List<Table>();
        List<TableDto> _tableDtoList = new List<TableDto>();
        List<CbbTable> _cbbTableList = new List<CbbTable>();

        SqlConnection connection;
       
        public void                     Add(Table entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_TableAdd", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TableName", entity.TableName);
            cmd.Parameters.AddWithValue("TableCode", entity.TableCode);
            cmd.Parameters.AddWithValue("TableDescription", entity.TableDescription);
            cmd.Parameters.AddWithValue("TableDisplay", entity.Display);
            cmd.Parameters.AddWithValue("AreaId", entity.AreaId);
            cmd.Parameters.AddWithValue("TableState", entity.TableState);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                     ChangeState(int id, bool state)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_TableChangeState", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TableId", id);
            cmd.Parameters.AddWithValue("TableState", !state);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                     Delete(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_TableDelete", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TableId", id);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public Table                    GetById(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_TableGetById", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TableId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            return new Table
            {
                TableId = id,
                TableName = dr["TableName"].ToString(),
                TableCode = dr["TableCode"].ToString(),
                TableDescription = dr["TableDescription"].ToString(),
                AreaId = Convert.ToInt32(dr["AreaId"]),
                Display = Convert.ToBoolean(dr["TableDisplay"]),
                TableState = Convert.ToBoolean(dr["TableState"])
            };
        }
        public List<Table>              GetAll(int? id)
        {
            connection = Connection.getConnection(connection);
            _tableList.Clear();
            SqlCommand cmd = new SqlCommand("PR_TableGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AreaId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _tableList.Add(new Table
                {
                    TableId = Convert.ToInt32(dr["TableId"]),
                    TableName = dr["TableName"].ToString(),
                    TableCode = dr["TableCode"].ToString(),
                    TableDescription = dr["TableDescription"].ToString(),
                    AreaId = Convert.ToInt32(dr["AreaId"]),
                    Display = Convert.ToBoolean(dr["TableDisplay"]),
                    TableState = Convert.ToBoolean(dr["TableState"])

                });
            }
            Connection.endConnection(connection);
            return _tableList;
        }
        public void                     Update(Table entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_TableUpdate", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TableName", entity.TableName);
            cmd.Parameters.AddWithValue("TableCode", entity.TableCode);
            cmd.Parameters.AddWithValue("TableDescription", entity.TableDescription);
            cmd.Parameters.AddWithValue("TableId", entity.TableId);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public List<TableDto>           TableDtoGetByArea(int AreaId)
        {
            connection = Connection.getConnection(connection);
            _tableDtoList.Clear();
            SqlCommand cmd = new SqlCommand("PR_TableDtoGetByArea", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AreaId", AreaId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _tableDtoList.Add(new TableDto
                {
                    TableId = Convert.ToInt32(dr["TableId"]),
                    TableName = dr["TableName"].ToString(),
                    TableCode = dr["TableCode"].ToString(),
                    TableDescription = dr["TableDescription"].ToString(),
                    AreaId = Convert.ToInt32(dr["AreaId"]),
                    AreaName = dr["AreaName"].ToString(),
                    TableState = Convert.ToBoolean(dr["TableState"])
                });
            }
            Connection.endConnection(connection);
            return _tableDtoList;
        }
        public List<CbbTable>           CbbTableGetByArea(int areaId, bool state)
        {
            connection = Connection.getConnection(connection);
            _cbbTableList.Clear();
            SqlCommand cmd = new SqlCommand("PR_CbbTableGetByArea", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AreaId", areaId);
            cmd.Parameters.AddWithValue("TableState", state);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _cbbTableList.Add(new CbbTable
                {
                    TableId = Convert.ToInt32(dr["TableId"]),
                    TableName = Convert.ToString(dr["TableName"])
                });
            }
            Connection.endConnection(connection);
            return _cbbTableList;
        }
        public void                     TableChangeDisplay(int id, bool display)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_TableChangeDisplay", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TableId", id);
            cmd.Parameters.AddWithValue("TableDisplay", display);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public List<Table>              TableGetByArea(int id, bool state)
        {
            connection = Connection.getConnection(connection);
            _tableList.Clear();
            SqlCommand cmd = new SqlCommand("PR_TableGetByArea", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AreaId", id);
            cmd.Parameters.AddWithValue("TableState", state);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _tableList.Add(new Table
                {
                    TableId = Convert.ToInt32(dr["TableId"]),
                    TableName = dr["TableName"].ToString(),
                    TableCode = dr["TableCode"].ToString(),
                    TableDescription = dr["TableDescription"].ToString(),
                    AreaId = Convert.ToInt32(dr["AreaId"]),
                    Display = Convert.ToBoolean(dr["TableDisplay"]),
                    TableState = Convert.ToBoolean(dr["TableState"])

                });
            }
            Connection.endConnection(connection);
            return _tableList;
        }
    }
}

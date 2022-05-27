using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using Entities.DTOs;

namespace DataAccess.Concrete.Mssql
{
    public class MsAreaDal : IAreaDal
    {
        List<Area> _areaList = new List<Area>();
        List<CbbArea> _cbbAreaList = new List<CbbArea>();
        List<AreaDto> _areaDtoList = new List<AreaDto>();


        SqlConnection connection;
        public void                             Add(Area entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_AreaAdd", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AreaName", entity.AreaName);
            cmd.Parameters.AddWithValue("AreaCode", entity.AreaCode);
            cmd.Parameters.AddWithValue("AreaDescription", entity.AreaDescription);
            cmd.Parameters.AddWithValue("BranchId", entity.BranchId);
            cmd.Parameters.AddWithValue("AreaState", entity.AreaState);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                             ChangeState(int id, bool state)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_AreaChangeState", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AreaId", id);
            cmd.Parameters.AddWithValue("AreaState", !state);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                             Delete(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_AreaDelete", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AreaId", id);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public Area                             GetById(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_AreaGetById", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AreaId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            var area = new Area
            {
                AreaId = id,
                AreaName = dr["AreaName"].ToString(),
                AreaCode = dr["AreaCode"].ToString(),
                AreaDescription = dr["AreaDescription"].ToString(),
                BranchId = Convert.ToInt32(dr["BranchId"]),
                AreaState = Convert.ToBoolean(dr["AreaState"])
            };
            Connection.endConnection(connection);
            return area;
        }
        public List<Area>                       GetAll(int? id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_AreaGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _areaList.Add(new Area
                {
                    AreaId = Convert.ToInt32(dr["AreaId"]),
                    AreaName = dr["AreaName"].ToString(),
                    AreaCode = dr["AreaCode"].ToString(),
                    AreaDescription = dr["AreaDescription"].ToString(),
                    BranchId = Convert.ToInt32(dr["BranchId"]),
                    AreaState = Convert.ToBoolean(dr["AreaState"])
                });
            }
            Connection.endConnection(connection);
            return _areaList;
        }
        public void                             Update(Area entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_AreaUpdate", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AreaName", entity.AreaName);
            cmd.Parameters.AddWithValue("AreaCode", entity.AreaCode);
            cmd.Parameters.AddWithValue("AreaDescription", entity.AreaDescription);
            cmd.Parameters.AddWithValue("AreaId", entity.AreaId);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public List<CbbArea>                    CbbAreaGetAll(int branchId, bool areaState)
        {
            connection = Connection.getConnection(connection);
            _cbbAreaList.Clear();
            SqlCommand cmd = new SqlCommand("PR_CbbAreaGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchId", branchId);
            cmd.Parameters.AddWithValue("AreaState", areaState);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _cbbAreaList.Add(new CbbArea
                {
                    AreaId = Convert.ToInt32(dr["AreaId"]),
                    AreaName = dr["AreaName"].ToString(),
                });
            }
            Connection.endConnection(connection);
            return _cbbAreaList;
        }
        public List<AreaDto>                    AreaDtoGetByBranch(int branchId)
        {
            connection = Connection.getConnection(connection);
            _areaDtoList.Clear();
            SqlCommand cmd = new SqlCommand("PR_AreaDtoGetByBranch", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchId", branchId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _areaDtoList.Add(new AreaDto
                {
                    AreaId = Convert.ToInt32(dr["AreaId"]),
                    AreaName = dr["AreaName"].ToString(),
                    AreaCode = dr["AreaCode"].ToString(),
                    AreaDescription = dr["AreaDescription"].ToString(),
                    BranchId = Convert.ToInt32(dr["BranchId"]),
                    BranchName = dr["BranchName"].ToString(),
                    AreaState = Convert.ToBoolean(dr["AreaState"])
                });
            }
            Connection.endConnection(connection);
            return  _areaDtoList;
        }
    }
}

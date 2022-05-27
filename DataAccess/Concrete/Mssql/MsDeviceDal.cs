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
    public class MsDeviceDal : IDeviceDal
    {
        List<Device> deviceList = new List<Device>();
        List<DeviceDto> deviceDtoList = new List<DeviceDto>();


        SqlConnection connection;
        

        public void                  Add(Device entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_DeviceAdd", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("DeviceName", entity.DeviceName);
            cmd.Parameters.AddWithValue("DeviceCode", entity.DeviceCode);
            cmd.Parameters.AddWithValue("DeviceDescription", entity.DeviceDescription);
            cmd.Parameters.AddWithValue("DeviceMac", entity.DeviceMac);
            cmd.Parameters.AddWithValue("InstitutionId", entity.InstitutionId);
            cmd.Parameters.AddWithValue("BranchId", entity.BranchId);
            cmd.Parameters.AddWithValue("AreaId", entity.AreaId);
            cmd.Parameters.AddWithValue("TypeOfDeviceId", entity.TypeOfDeviceId);
            cmd.Parameters.AddWithValue("DeviceState", entity.DeviceState);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                  ChangeState(int id, bool state)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_DeviceChangeState", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("DeviceId", id);
            cmd.Parameters.AddWithValue("DeviceState", state);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                  Delete(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_DeviceDelete", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("DeviceId", id);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public Device                GetById(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_DeviceGetById", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("DeviceId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            Device device = new Device
            {
                DeviceId = id,
                DeviceName = dr["DeviceName"].ToString(),
                DeviceCode = dr["DeviceCode"].ToString(),
                DeviceDescription = dr["DeviceDescription"].ToString(),
                DeviceMac = dr["DeviceMac"].ToString(),
                InstitutionId = Convert.ToInt32(dr["InstitutionId"]),
                BranchId = Convert.ToInt32(dr["BranchId"]),
                AreaId = Convert.ToInt32(dr["AreaId"]),
                TypeOfDeviceId = Convert.ToInt32(dr["TypeOfDeviceId"]),
                DeviceState = Convert.ToBoolean(dr["DeviceState"])

            };
            dr.Close();
            return device;
        }
        public List<Device>          GetAll(int? id)
        {
            connection = Connection.getConnection(connection);
            deviceList.Clear();
            SqlCommand cmd = new SqlCommand("PR_DeviceGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                deviceList.Add(new Device
                {
                    DeviceId = Convert.ToInt32(dr["DeviceId"]),
                    DeviceName = dr["DeviceName"].ToString(),
                    DeviceCode = dr["DeviceCode"].ToString(),
                    DeviceDescription = dr["DeviceDescription"].ToString(),
                    DeviceMac = dr["DeviceMac"].ToString(),
                    InstitutionId = Convert.ToInt32(dr["InstitutionId"]),
                    BranchId = Convert.ToInt32(dr["BranchId"]),
                    AreaId = Convert.ToInt32(dr["AreaId"]),
                    TypeOfDeviceId = Convert.ToInt32(dr["TypeOfDeviceId"]),
                    DeviceState = Convert.ToBoolean(dr["DeviceState"])
                });
            }
            dr.Close();
            Connection.endConnection(connection);
            return deviceList;
        }
        public void                  Update(Device entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_DeviceUpdate", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("DeviceName", entity.DeviceName);
            cmd.Parameters.AddWithValue("DeviceCode", entity.DeviceCode);
            cmd.Parameters.AddWithValue("DeviceDescription", entity.DeviceDescription);
            cmd.Parameters.AddWithValue("DeviceMac", entity.DeviceMac);
            cmd.Parameters.AddWithValue("BranchId", entity.BranchId);
            cmd.Parameters.AddWithValue("AreaId", entity.AreaId);
            cmd.Parameters.AddWithValue("TypeOfDeviceId", entity.TypeOfDeviceId);
            cmd.Parameters.AddWithValue("DeviceId", entity.DeviceId);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public List<DeviceDto>       DeviceDtoGetAll()
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_DeviceDtoGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                deviceDtoList.Add(new DeviceDto
                {
                    DeviceId = Convert.ToInt32(dr["DeviceId"]),
                    DeviceName = dr["DeviceName"].ToString(),
                    DeviceCode = dr["DeviceCode"].ToString(),
                    DeviceDescription = dr["DeviceDescription"].ToString(),
                    DeviceMac = dr["DeviceMac"].ToString(),
                    DeviceState = Convert.ToBoolean(dr["DeviceState"]),
                    InstitutionId = Convert.ToInt32(dr["InstitutionId"]),
                    InstitutionName = Convert.ToString(dr["InstitutionName"]),
                    BranchId = Convert.ToInt32(dr["BranchId"]),
                    BranchName = dr["BranchName"].ToString(),
                    AreaId = Convert.ToInt32(dr["AreaId"]),
                    AreaName = dr["AreaName"].ToString(),
                    TypeOfDeviceId = Convert.ToInt32(dr["TypeOfDeviceId"]),
                    TypeOfDeviceName = dr["TypeOfDeviceName"].ToString()

                });
            }
            Connection.endConnection(connection);
            return deviceDtoList;
        }
        public DeviceDto             DeviceDtoGetByDeviceMac(string deviceMac)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_DeviceDtoGetByDeviceMac",connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("DeviceMac", deviceMac);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                return new DeviceDto
                {
                    DeviceId = Convert.ToInt32(dr["DeviceId"]),
                    DeviceName = dr["DeviceName"].ToString(),
                    DeviceCode = dr["DeviceCode"].ToString(),
                    DeviceDescription = dr["DeviceDescription"].ToString(),
                    DeviceMac = dr["DeviceMac"].ToString(),
                    DeviceState = Convert.ToBoolean(dr["DeviceState"]),
                    InstitutionId = Convert.ToInt32(dr["InstitutionId"]),
                    BranchId = Convert.ToInt32(dr["BranchId"]),
                    AreaId = Convert.ToInt32(dr["AreaId"]),
                    TypeOfDeviceId = Convert.ToInt32(dr["TypeOfDeviceId"]),
                    BranchName = dr["BranchName"].ToString(),
                    AreaName = dr["AreaName"].ToString(),
                    TypeOfDeviceName = dr["TypeOfDeviceName"].ToString()
                };
            }
            else
            {
                Connection.endConnection(connection);
                return null;
            }
        }
    }
}

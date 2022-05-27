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
    public class MsTypeOfDeviceDal : ITypeOfDeviceDal
    {
        List<TypeOfDevice> _typeOfDeviceList = new List<TypeOfDevice>();
        List<CbbTypeOfDevice> _cbbTypeOfDeviceList = new List<CbbTypeOfDevice>();


        SqlConnection connection;
        
        public void                             Add(TypeOfDevice entity)
        {
            SqlCommand cmd = new SqlCommand("PR_TypeOfDeviceAdd", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfDeviceName", entity.TypeOfDeviceName);
            cmd.Parameters.AddWithValue("TypeOfDeviceCode", entity.TypeOfDeviceCode);
            cmd.Parameters.AddWithValue("TypeOfDeviceDescription", entity.TypeOfDeviceDescription);
            cmd.Parameters.AddWithValue("TypeOfDeviceState", entity.TypeOfDeviceState);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                             ChangeState(int id, bool state)
        {
            SqlCommand cmd = new SqlCommand("PR_TypeOfDeviceChangeState", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfDeviceId", id);
            cmd.Parameters.AddWithValue("TypeOfDeviceState", !state);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                             Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("PR_TypeOfDeviceDelete", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfDeviceId", id);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public TypeOfDevice                     GetById(int id)
        {
            SqlCommand cmd = new SqlCommand("PR_TypeOfDeviceGetById", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfDeviceId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            return new TypeOfDevice
            {
                TypeOfDeviceId = id,
                TypeOfDeviceName = dr["TypeOfDeviceName"].ToString(),
                TypeOfDeviceCode = dr["TypeOfDeviceCode"].ToString(),
                TypeOfDeviceDescription = dr["TypeOfDeviceDescription"].ToString(),
                TypeOfDeviceState = Convert.ToBoolean(dr["TypeOfDeviceState"])
            };
        }
        public List<TypeOfDevice>               GetAll(int? id)
        {
            _typeOfDeviceList.Clear();
            SqlCommand cmd = new SqlCommand("PR_TypeOfDeviceGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _typeOfDeviceList.Add(new TypeOfDevice
                {
                    TypeOfDeviceId = Convert.ToInt32(dr["TypeOfDeviceId"]),
                    TypeOfDeviceName = dr["TypeOfDeviceName"].ToString(),
                    TypeOfDeviceCode = dr["TypeOfDeviceCode"].ToString(),
                    TypeOfDeviceDescription = dr["TypeOfDeviceDescription"].ToString(),
                    TypeOfDeviceState = Convert.ToBoolean(dr["TypeOfDeviceState"])
                });
            }
            Connection.endConnection(connection);
            return _typeOfDeviceList;
        }
        public void                             Update(TypeOfDevice entity)
        {
            SqlCommand cmd = new SqlCommand("PR_TypeOfDeviceUpdate", connection);
            cmd.CommandType= System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfDeviceName", entity.TypeOfDeviceName);
            cmd.Parameters.AddWithValue("TypeOfDeviceCode", entity.TypeOfDeviceCode);
            cmd.Parameters.AddWithValue("TypeOfDeviceDescription", entity.TypeOfDeviceDescription);
            cmd.Parameters.AddWithValue("TypeOfDeviceId", entity.TypeOfDeviceId);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public List<CbbTypeOfDevice>            CbbTypeOfDeviceGetAll(bool state)
        {
            _cbbTypeOfDeviceList.Clear();
            SqlCommand cmd = new SqlCommand("PR_CbbTypeOfDeviceGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfDeviceState", state);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _cbbTypeOfDeviceList.Add(new CbbTypeOfDevice
                {
                    TypeOfDeviceId = Convert.ToInt32(dr["TypeOfDeviceId"]),
                    TypeOfDeviceName = dr["TypeOfDeviceName"].ToString()
                });
            }
            Connection.endConnection(connection);
            return _cbbTypeOfDeviceList;
        }
    }
}

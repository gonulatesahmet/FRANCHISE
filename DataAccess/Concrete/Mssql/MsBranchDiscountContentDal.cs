using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Mssql
{
    public class MsBranchDiscountContentDal : IBranchDiscountContentDal
    {
        List<BranchDiscountContent> _branchDiscountContentList = new List<BranchDiscountContent>();
        List<BranchDiscountContentDto> _branchDiscountContentDtoList = new List<BranchDiscountContentDto>();
        List<CbbBranchDiscountContent> _cbbBranchDiscountContentList = new List<CbbBranchDiscountContent>();


        SqlConnection connection;
        public void                                 Add(BranchDiscountContent entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchDiscountContentAdd", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchDiscountContentName", entity.BranchDiscountContentName);
            cmd.Parameters.AddWithValue("BranchDiscountContentCode", entity.BranchDiscountContentCode);
            cmd.Parameters.AddWithValue("BranchDiscountContentDescription",entity.BranchDiscountContentDescription);
            cmd.Parameters.AddWithValue("BranchDiscountId", entity.BranchDiscountId);
            cmd.Parameters.AddWithValue("BranchDiscountContentState", entity.BranchDiscountContentState);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                                 ChangeState(int id, bool state)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchDiscountContentChangeState",connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchDiscountContentId", id);
            cmd.Parameters.AddWithValue("BranchDiscountContentState", !state);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                                 Delete(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchDiscountContentDelete", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchDiscountContentId", id);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public BranchDiscountContent                GetById(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchDiscountContentGetById", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchDiscountContentId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            return new BranchDiscountContent
            {
                BranchDiscountContentId = Convert.ToInt32(dr["BranchDiscountContentId"]),
                BranchDiscountContentName = Convert.ToString(dr["BranchDiscountContentName"]),
                BranchDiscountContentCode = Convert.ToString(dr["BranchDiscountContentCode"]),
                BranchDiscountContentDescription = Convert.ToString(dr["BranchDiscountContentDescription"]),
                BranchDiscountId = Convert.ToInt32(dr["BranchDiscountId"]),
                BranchDiscountContentState = Convert.ToBoolean(dr["BranchDiscountContentState"])
            };
        }
        public List<BranchDiscountContent>          GetAll(int? id)
        {
            connection = Connection.getConnection(connection);
            _branchDiscountContentList.Clear();
            SqlCommand cmd = new SqlCommand("PR_BranchDiscountContentGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchDiscountId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _branchDiscountContentList.Add(new BranchDiscountContent
                {
                    BranchDiscountContentId = Convert.ToInt32(dr["BranchDiscountContentId"]),
                    BranchDiscountContentName = Convert.ToString(dr["BranchDiscountContentName"]),
                    BranchDiscountContentCode = Convert.ToString(dr["BranchDiscountContentCode"]),
                    BranchDiscountContentDescription = Convert.ToString(dr["BranchDiscountContentDescription"]),
                    BranchDiscountId = Convert.ToInt32(dr["BranchDiscountId"]),
                    BranchDiscountContentState = Convert.ToBoolean(dr["BranchDiscountContentState"])
                });
            }
            Connection.endConnection(connection);
            return _branchDiscountContentList;
        }
        public void                                 Update(BranchDiscountContent entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchDiscountContentUpdate", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchDiscountContentName", entity.BranchDiscountContentName);
            cmd.Parameters.AddWithValue("BranchDiscountContentCode", entity.BranchDiscountContentCode);
            cmd.Parameters.AddWithValue("BranchDiscountContentDescription", entity.BranchDiscountContentDescription);
            cmd.Parameters.AddWithValue("BranchDiscountContentId", entity.BranchDiscountContentId);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public List<BranchDiscountContentDto>       BranchDiscountContentDtoGetByBranch(int branchId)
        {
            connection = Connection.getConnection(connection);
            _branchDiscountContentDtoList.Clear();
            SqlCommand cmd = new SqlCommand("PR_BranchDiscountContentDtoGetByBranch", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchId", branchId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _branchDiscountContentDtoList.Add(new BranchDiscountContentDto
                {
                    BranchDiscountContentId = Convert.ToInt32(dr["BranchDiscountContentId"]),
                    BranchDiscountContentName = Convert.ToString(dr["BranchDiscountContentName"]),
                    BranchDiscountContentCode = Convert.ToString(dr["BranchDiscountContentCode"]),
                    BranchDiscountContentDescription = Convert.ToString(dr["BranchDiscountContentDescription"]),
                    BranchDiscountId = Convert.ToInt32(dr["BranchDiscountId"]),
                    BranchDiscountName = Convert.ToString(dr["DiscountName"]),
                    BranchDiscountContentState = Convert.ToBoolean(dr["BranchDiscountContentState"])
                });
            }
            Connection.endConnection(connection);
            return _branchDiscountContentDtoList;
        }
        public List<CbbBranchDiscountContent>       CbbBranchDiscountContentGetByBranch(int branchId, bool state)
        {
            connection = Connection.getConnection(connection);
            _cbbBranchDiscountContentList.Clear();
            SqlCommand cmd = new SqlCommand("PR_CbbBranchDiscountContentGetByBranch", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchId", branchId);
            cmd.Parameters.AddWithValue("BranchDiscountContentState", state);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _cbbBranchDiscountContentList.Add(new CbbBranchDiscountContent
                {
                    BranchDiscountContentId = Convert.ToInt32(dr["BranchDiscountContentId"]),
                    BranchDiscountContentName = Convert.ToString(dr["BranchDiscountContentName"])
                });
            }
            Connection.endConnection(connection);
            return _cbbBranchDiscountContentList;
        }
        public List<CbbBranchDiscountContent>       CbbBranchDiscountContentGetByBranchDiscount(int branchDiscountId, bool state)
        {
            connection = Connection.getConnection(connection);
            _cbbBranchDiscountContentList.Clear();
            SqlCommand cmd = new SqlCommand("PR_CbbBranchDiscountContentGetByBranchDiscount", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchDiscountId", branchDiscountId);
            cmd.Parameters.AddWithValue("BranchDiscountContentState", state);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _cbbBranchDiscountContentList.Add(new CbbBranchDiscountContent
                {
                    BranchDiscountContentId = Convert.ToInt32(dr["BranchDiscountContentId"]),
                    BranchDiscountContentName = Convert.ToString(dr["BranchDiscountContentName"])
                });
            }
            Connection.endConnection(connection);
            return _cbbBranchDiscountContentList;
        }
        
    }
}

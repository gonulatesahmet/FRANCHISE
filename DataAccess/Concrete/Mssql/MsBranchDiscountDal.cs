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
    public class MsBranchDiscountDal : IBranchDiscountDal
    {
        List<BranchDiscount> _branchDiscountList = new List<BranchDiscount>();
        List<BranchDiscountDto> _branchDiscountDtoList = new List<BranchDiscountDto>();
        List<CbbBranchDiscount> _cbbBranchDiscountList = new List<CbbBranchDiscount>();


        SqlConnection connection;
        public void                     Add(BranchDiscount entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchDiscountAdd", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchDiscountAmount", entity.BranchDiscountAmount);
            cmd.Parameters.AddWithValue("BranchId", entity.BranchId);
            cmd.Parameters.AddWithValue("DiscountId", entity.DiscountId);
            cmd.Parameters.AddWithValue("TypeOfDiscountId", entity.TypeOfDiscountId);
            cmd.Parameters.AddWithValue("BranchDiscountState", entity.BranchDiscountState);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                     ChangeState(int id, bool state)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchDiscountChangeState", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchDiscountId", id);
            cmd.Parameters.AddWithValue("BranchDiscountState", !state);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public void                     Delete(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchDiscountDelete", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchDiscountId", id);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public BranchDiscount           GetById(int id)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchDiscountGetById", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchDiscountId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            return new BranchDiscount
            {
                BranchDiscountId = id,
                BranchId = Convert.ToInt32(dr["BranchId"]),
                DiscountId = Convert.ToInt32(dr["DiscountId"]),
                TypeOfDiscountId = Convert.ToInt32(dr["TypeOfDiscountId"]),
                BranchDiscountAmount = Convert.ToInt32(dr["BranchDiscountAmount"]),
                BranchDiscountState = Convert.ToBoolean(dr["BranchDiscountState"]),
            };
        }
        public List<BranchDiscount>     GetAll(int? id)
        {
            connection = Connection.getConnection(connection);
            _branchDiscountList.Clear();
            SqlCommand cmd = new SqlCommand("PR_BranchDiscountGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _branchDiscountList.Add(new BranchDiscount
                {
                    BranchDiscountId = Convert.ToInt32(dr["BranchDiscountId"]),
                    BranchId = Convert.ToInt32(dr["BranchId"]),
                    DiscountId = Convert.ToInt32(dr["DiscountId"]),
                    TypeOfDiscountId = Convert.ToInt32(dr["TypeOfDiscountId"]),
                    BranchDiscountAmount = Convert.ToInt32(dr["BranchDiscountAmount"]),
                    BranchDiscountState = Convert.ToBoolean(dr["BranchDiscountState"]),
                });
            }
            Connection.endConnection(connection);
            return _branchDiscountList;
        }
        public void                     Update(BranchDiscount entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_BranchDiscountUpdate", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TypeOfDiscountId", entity.TypeOfDiscountId);
            cmd.Parameters.AddWithValue("BranchDiscountAmount", entity.BranchDiscountAmount);
            cmd.Parameters.AddWithValue("BranchDiscountId", entity.BranchDiscountId);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
        public List<BranchDiscountDto>  BranchDiscountDtoGetByBranch(int branchId)
        {
            connection = Connection.getConnection(connection);
            _branchDiscountDtoList.Clear();
            SqlCommand cmd = new SqlCommand("PR_BranchDiscountDtoGetByBranch",connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchId", branchId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _branchDiscountDtoList.Add(new BranchDiscountDto
                {
                    BranchDiscountId = Convert.ToInt32(dr["BranchDiscountId"]),
                    DiscountId = Convert.ToInt32(dr["DiscountId"]),
                    DiscountName = dr["DiscountName"].ToString(),
                    TypeOfDiscountId = Convert.ToInt32(dr["TypeOfDiscountId"]),
                    TypeOfDiscountName = dr["TypeOfDiscountName"].ToString(),
                    BranchDiscountAmount = Convert.ToInt32(dr["BranchDiscountAmount"]),
                    BranchDiscountState = Convert.ToBoolean(dr["BranchDiscountState"]),
                });
            }
            Connection.endConnection(connection);
            return _branchDiscountDtoList;
        }
        public List<CbbBranchDiscount>  CbbBranchDiscountGetByBranch(int branchId, bool state)
        {
            connection = Connection.getConnection(connection);
            _cbbBranchDiscountList.Clear();
            SqlCommand cmd = new SqlCommand("PR_CbbBranchDiscountGetByBranch", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BranchId", branchId);
            cmd.Parameters.AddWithValue("BranchDiscountState", state);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _cbbBranchDiscountList.Add(new CbbBranchDiscount
                {
                    BranchDiscountId = Convert.ToInt32(dr["BranchDiscountId"]),
                    BranchDiscountName = Convert.ToString(dr["DiscountName"])
                });
            }
            Connection.endConnection(connection);
            return _cbbBranchDiscountList;
        }
    }
}

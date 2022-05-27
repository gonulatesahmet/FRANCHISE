using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Concrete.Mssql
{
    public class MsPageDal : IPageDal
    {
        List<Page> pageList = new List<Page>();
        SqlConnection connection;
        public void Add(Page entity)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeState(int id, bool state)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Page GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Page> GetAll(int? id)
        {
            pageList.Clear();
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_PageGetAll", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                pageList.Add(new Page
                {
                    PageId = Convert.ToInt32(dr["PageId"]),
                    PageName = Convert.ToString(dr["PageName"]),
                    PageText = Convert.ToString(dr["PageText"]),
                    PageIcon = Convert.ToString(dr["PageIcon"]),
                    PageState = Convert.ToBoolean(dr["PageState"])
                });
            }
            Connection.endConnection(connection);
            return pageList;
        }

        public void Update(Page entity)
        {
            connection = Connection.getConnection(connection);
            SqlCommand cmd = new SqlCommand("PR_PageUpdate", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("PageName", entity.PageName);
            cmd.Parameters.AddWithValue("PageText", entity.PageText);
            cmd.Parameters.AddWithValue("PageIcon", entity.PageIcon);
            cmd.Parameters.AddWithValue("PageId", entity.PageId);
            cmd.ExecuteNonQuery();
            Connection.endConnection(connection);
        }
    }
}

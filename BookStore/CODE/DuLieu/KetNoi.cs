using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookStore.CODE.DuLieu
{
    
    public class KetNoi:System.Web.UI.Page
    {
        SqlConnection conn;
       
        public KetNoi()
        {
            String strConn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Server.MapPath("/App_Data/") + @"dbBookStore.mdf;Integrated Security=True";
            conn = new SqlConnection(strConn);
        }
        public DataTable getDataTable(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public bool AddDataToTable(string sql)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                return cmd.ExecuteNonQuery() > 0 ? true:false;
            }catch(Exception e)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool EditData(string sql)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool DeleteData(string sql)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public int getScalar(string sql)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                return (int)cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
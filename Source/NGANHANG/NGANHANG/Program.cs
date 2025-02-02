﻿using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using NGANHANG.View;


namespace NGANHANG
{
    static class Program
    {
      
        public static SqlConnection conn = new SqlConnection();
        public static String connstr;
     //   public static string connstr = "Data Source=DESKTOP-ICQO1SV\\MSSQLSERVER1;Initial Catalog=NGANHANG;User ID=sa;Password=1234";
     //   public static String connstr_publisher = "Data Source=DESKTOP-VG42JCK;Initial Catalog=QLVT;Integrated Security=True";

        public static SqlDataReader myReader;
        public static String servername = "DESKTOP-ICQO1SV\\MSSQLSERVER1";
        public static String username = "";
        public static String mlogin = "sa";
        public static String password = "1234";

        public static String database = "NGANHANG";
        public static String remotelogin = "";
        public static String remotepassword = "";

        public static String mloginDN = "";
        public static String passwordDN = "";
        public static String mGroup = "";
        public static String maNV = "";
        public static String mHoten = "";

        public static string maChinhanh ="";

        public static BindingSource bds_dspm = new BindingSource();  // giữ bdsPM khi đăng nhập
        public static frmMain frmChinh;

        public static int KetNoi()
        {
            if (Program.conn != null && Program.conn.State == ConnectionState.Open)
                Program.conn.Close();
            try
            {
                Program.connstr = "Data Source=" + Program.servername + ";Initial Catalog=" +
                      Program.database + ";User ID=" +
                      Program.mlogin + ";password=" + Program.password;
                Program.conn.ConnectionString = Program.connstr;
                Program.conn.Open();
                return 1;
            }

            catch (Exception e)
            {
                return 0;
            }
        }

        public static SqlDataReader ExecSqlDataReader(String strLenh) 
        {
            SqlDataReader myreader;
            SqlCommand sqlcmd = new SqlCommand(strLenh, Program.conn);
            sqlcmd.CommandType = CommandType.Text;
            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            try
            {
                myreader = sqlcmd.ExecuteReader(); return myreader;

            }
            catch (SqlException ex)
            {
                Program.conn.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }
 
        public static int ExecSqlNonQuery(String strlenh)
        {
            SqlCommand Sqlcmd = new SqlCommand(strlenh, conn);
            Sqlcmd.CommandType = CommandType.Text;
            Sqlcmd.CommandTimeout = 600;// 10 phut 
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sqlcmd.ExecuteNonQuery(); conn.Close();
                return 0;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
                return ex.State; // trang thai lỗi gởi từ RAISERROR trong SQL Server qua
            }
        }

        public static int ExecSqlKiemTra1(String tenSP, String a)
        {
            String sql = $"DECLARE @return_value int EXEC @return_value = [dbo].[{tenSP}] @a SELECT 'Return Value' = @return_value";

            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            if (conn.State == ConnectionState.Closed) conn.Open();
            sqlCommand.Parameters.AddWithValue("@a", a);
            SqlDataReader dataReader = null;
            try
            {
                dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();
                int result_value = int.Parse(dataReader.GetValue(0).ToString());
                conn.Close();
                return result_value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
                return -1;
            }
        }

        public static int ExecSqlKiemTra2(String tenSP, String a, String b)
        {
            String sql = $"DECLARE @return_value int EXEC @return_value = [dbo].[{tenSP}] @a, @b SELECT 'Return Value' = @return_value";

            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            if (conn.State == ConnectionState.Closed) conn.Open();
            sqlCommand.Parameters.AddWithValue("@a", a);
            sqlCommand.Parameters.AddWithValue("@b", b);
            SqlDataReader dataReader = null;
            try
            {
                dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();
                int result_value = int.Parse(dataReader.GetValue(0).ToString());
                conn.Close();
                return result_value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
                return -1;
            }
        }
        [STAThread]
        static void Main()
        {
            KetNoi();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace hepsinideneme
{
    class veritabanı
    {
        static SqlDataAdapter da;
        static SqlConnection con;
        static DataSet ds;
        static SqlCommand cmd;
        static SqlDataReader dr;
        public static string sqlcon = @"Data Source=DESKTOP-75U42TN\SQLEXPRESS;Initial Catalog=deneme;Integrated Security=True";
        public static bool baglantıdurum()
        {
            using (con = new SqlConnection(sqlcon))
            {
                try
                {
                    con.Open();
                    return true;
                }
                catch (SqlException exp)
                {
                    MessageBox.Show(exp.Message);
                    return false;
                }
            }
        }
        public static DataGridView griddoldur(DataGridView gridim, string sqlselectsorgu)
        {
            con = new SqlConnection(sqlcon);
            da = new SqlDataAdapter(sqlselectsorgu, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, sqlselectsorgu);
            gridim.DataSource = ds.Tables[sqlselectsorgu];
            return gridim;
        }
        
        public static bool login(string kullanıcıadı, string sıfre)
        {
            string  sorgu = "select *from tbl_login where kullanıcı=@user and sıfre=@pass";
            con = new SqlConnection(sqlcon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", kullanıcıadı);
            cmd.Parameters.AddWithValue("@pass", veritabanı.md5sıfre(sıfre));
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }

        public static string md5sıfre(string sıfrelenecek)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dizi = Encoding.UTF8.GetBytes(sıfrelenecek);
            dizi = md5.ComputeHash(dizi);
            StringBuilder sb = new StringBuilder();
            foreach (byte item in dizi)
                sb.Append(item.ToString("x2").ToLower());
            return sb.ToString();
        }
        public static string sha256sıfrele(string sifrelenecek)
        {
            SHA256 sha256hash = SHA256.Create();
            byte[] dizi = Encoding.UTF8.GetBytes(sifrelenecek);
            dizi = sha256hash.ComputeHash(dizi);
            StringBuilder sb = new StringBuilder();
            foreach (byte item in dizi)
                sb.Append(item.ToString("x2").ToLower());
            return sb.ToString();
        }
        public static void komutyolla(string sql)
        {
            con = new SqlConnection(sqlcon);
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void komutyollaparametreli(string sql,SqlCommand cmd)
        {
            con = new SqlConnection(sqlcon);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

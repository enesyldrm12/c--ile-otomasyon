using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace hepsinideneme
{
    public partial class yönetici_innerjoin : Form
    {
        public yönetici_innerjoin()
        {
            InitializeComponent();
        }
        static SqlDataAdapter da;
        static SqlConnection con;
        static DataSet ds;
        public static string sqlcon = @"Data Source=DESKTOP-75U42TN\SQLEXPRESS;Initial Catalog=deneme;Integrated Security=True";

        
        public static string sqlsorgu;
        void griddoldur(string sql)
        {
            con = new SqlConnection(sqlcon);
            da = new SqlDataAdapter(sql, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "tbl_urunler");
            dataGridView1.DataSource = ds.Tables["tbl_urunler"];
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                sqlsorgu = "select tbl_urunler.*,tbl_islemler.* from tbl_urunler INNER JOIN tbl_islemler ON tbl_urunler.urunıd=tbl_islemler.urunıd  where tbl_urunler.urunad like '%" + textBox1.Text + "%'";
                griddoldur(sqlsorgu);
              
            }
        }

        private void yönetici_innerjoin_Load(object sender, EventArgs e)
        {
            sqlsorgu = "select tbl_urunler.*,tbl_islemler.* from tbl_urunler INNER JOIN tbl_islemler";
        }
    }
}

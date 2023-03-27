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
    public partial class işlemler_yönetici : Form
    {
        public işlemler_yönetici()
        {
            InitializeComponent();
        }
        static SqlDataAdapter da;
        static SqlConnection con;
        static DataSet ds;
        static SqlCommand cmd, cmd1;
        static SqlDataReader dr;
        public static string sqlcon = @"Data Source=DESKTOP-75U42TN\SQLEXPRESS;Initial Catalog=deneme;Integrated Security=True";
      
        public int urunıd;
        public static string  sqlsorgu;
        void griddoldur(string sql)
        {
            con = new SqlConnection(sqlcon);
            da = new SqlDataAdapter(sql, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds,"tbl_urunler");
            dataGridView1.DataSource = ds.Tables["tbl_urunler"];
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                if (radioButton1.Checked)
                {
                    //isme göre
                    if (radioButton5.Checked)
                    {
                      
                        sqlsorgu = "select *from tbl_urunler where urunad like '%" + textBox1.Text + "%'order by urunad ASC";
                        griddoldur(sqlsorgu);
                    }
                    else if (radioButton6.Checked)
                    {
                        sqlsorgu = "select *from tbl_urunler where urunad like '%" + textBox1.Text + "%'order by urunad DESC";
                        griddoldur(sqlsorgu);
                    }
                    
                }
                else if (radioButton2.Checked)
                {
                    //stok miktarı
                    if (radioButton5.Checked)
                    {

                        sqlsorgu = "select *from tbl_urunler where urunstok>" + textBox1.Text;
                        griddoldur(sqlsorgu);
                    }
                    else if (radioButton6.Checked)
                    {
                        sqlsorgu = "select *from tbl_urunler where urunstok<" + textBox1.Text;
                        griddoldur(sqlsorgu);
                    }
                }
                else if (radioButton3.Checked)
                {
                    //tarihi
                  
                }
                else if (radioButton4.Checked)
                {
                    //fiyat
                    if (radioButton5.Checked)
                    {
                        sqlsorgu = "select *from tbl_urunler where urunfıyat>"+textBox1.Text+"*0.9 and urunfıyat<"+textBox1.Text+"*1.1 ORDER BY urunfıyat ASC";
                        griddoldur(sqlsorgu);
                    }
                    else if (radioButton6.Checked)
                    {
                        sqlsorgu = "select *from tbl_urunler where urunfıyat>" + textBox1.Text + "*0.9 and urunfıyat<" + textBox1.Text + "*1.1 ORDER BY urunfıyat DESC";
                        griddoldur(sqlsorgu);
                    }
                }
            }
          
        }

      
        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton5.Checked)
                {
                    sqlsorgu = "select *from tbl_urunler where urunsondagıtımtarih>'" + dateTimePicker1.Value.ToString() + "' AND urunsondagıtımtarih<'" + dateTimePicker2.Value.ToString() + "'ORDER BY urunsondagıtımtarih ASC";
                    griddoldur(sqlsorgu);
                }
                else if (radioButton6.Checked)
                {
                    sqlsorgu = "select *from tbl_urunler where urunsondagıtımtarih>'" + dateTimePicker1.Value.ToString() + "' AND urunsondagıtımtarih<'" + dateTimePicker2.Value.ToString() + "'ORDER BY urunsondagıtımtarih DESC";
                    griddoldur(sqlsorgu);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ex");
            }
          
        }
    }
}

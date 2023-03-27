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
   
    public partial class Form6 : Form
    {
        static SqlDataAdapter da;
        static SqlConnection con;
        static DataSet ds;
        static SqlCommand cmd,cmd1;
        static SqlDataReader dr;
        public static string sqlcon = @"Data Source=DESKTOP-75U42TN\SQLEXPRESS;Initial Catalog=deneme;Integrated Security=True";
        public Form6()
        {
            InitializeComponent();
        }
        public int urunıd;
        void griddoldur()
        {
            con = new SqlConnection(sqlcon);
            da = new SqlDataAdapter("select *from tbl_urunler where urunstok>0",con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "tbl_urunler");
            dataGridView1.DataSource = ds.Tables["tbl_urunler"];
            con.Close();
        }
       

        
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
        private void Form6_Load(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = 0;
            griddoldur();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[1].HeaderText = "ürünler";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            string sql = "insert into tbl_islemler (islemtutar,islemtarih,islemacıklama,islembirim,kullanıcıadı,urunıd) values (@tutar,@tarih,@acıklama,@birim,@user,@ıd)";
            
            cmd.Parameters.AddWithValue("@tutar",Convert.ToDouble(label6_tutar.Text));
            cmd.Parameters.AddWithValue("@acıklama",richTextBox1.Text);
            cmd.Parameters.AddWithValue("@tarih", DateTime.Now);
            cmd.Parameters.AddWithValue("@birim",Convert.ToDouble(comboBox2.Text));
            cmd.Parameters.AddWithValue("@user",Form1.kullanıcsession);
            cmd.Parameters.AddWithValue("@ıd", urunıd);

            veritabanı.komutyollaparametreli(sql, cmd);
            cmd1 = new SqlCommand();
            sql = "update tbl_urunler set urunstok=urunstok-@birim where urunıd=@ıd";
            cmd1.Parameters.AddWithValue("@birim", Convert.ToDouble(comboBox2.Text));
            cmd1.Parameters.AddWithValue("@ıd",urunıd);
            veritabanı.komutyollaparametreli(sql, cmd1);
            label6.Text = "satış başarılı";
        }

        

        private void dataGridView1_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            urunıd = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            label6_ürün.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            label6_fiyat.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                sqlsorgu = "select *from tbl_urunler where urunad like '%" + textBox1.Text + "%'order by urunad ASC";
                griddoldur(sqlsorgu);

                //isme göre



            }

                
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text != "seçiniz...")
               label6_tutar.Text = (Convert.ToDouble(comboBox2.Text) * Convert.ToDouble(label6_fiyat.Text)).ToString();
        }

      
    }
}

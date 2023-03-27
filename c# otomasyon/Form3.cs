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
    public partial class Form3 : Form
    {
        static SqlDataAdapter da;
        static SqlConnection con;
        static DataSet ds;
        static SqlCommand cmd;
        static SqlDataReader dr;
        static string sqlcon = @"Data Source=DESKTOP-75U42TN\SQLEXPRESS;Initial Catalog=deneme;Integrated Security=True";
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
           
            con = new SqlConnection(sqlcon);
            string sql = "insert into tbl_login (kullanıcı,sıfre,tarih) values (@user,@pass,@tarih)";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@user", textBox2.Text);
            cmd.Parameters.AddWithValue("@pass", veritabanı.md5sıfre(textBox3.Text));
            cmd.Parameters.AddWithValue("@tarih", DateTime.Now);
            veritabanı.komutyollaparametreli(sql, cmd);
            veritabanı.griddoldur(dataGridView1, "select *from tbl_login");
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlcon);
            string sql = "delete from  tbl_login where kullanıcı=@user and sıfre=@pass and kID=@ıdm";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@user", textBox2.Text);
            cmd.Parameters.AddWithValue("@pass", textBox3.Text);
            cmd.Parameters.AddWithValue("@ıdm", Convert.ToInt32(textBox1.Text));
            veritabanı.komutyollaparametreli(sql, cmd);
            veritabanı.griddoldur(dataGridView1, "select *from tbl_login");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlcon);
            string sql = "update  tbl_login set sıfre=@pass where kullanıcı=@user and kID=@ıdm";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@user", textBox2.Text);
            cmd.Parameters.AddWithValue("@pass", veritabanı.md5sıfre(textBox3.Text));
            cmd.Parameters.AddWithValue("@ıdm", Convert.ToInt32(textBox1.Text));
            veritabanı.komutyollaparametreli(sql, cmd);
            veritabanı.griddoldur(dataGridView1, "select *from tbl_login");
        }



        private void Form3_Load_1(object sender, EventArgs e)
        {
            veritabanı.griddoldur(dataGridView1, "select * from tbl_login");
        }

        private void dataGridView1_CellMouseEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }


        private void şİFREİŞLEMLERİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 a = new Form4();
            a.ShowDialog();
        }

        private void pERSONELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 a = new Form5();
            a.ShowDialog();
        }

        private void iŞLEMLERToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void kARGOARAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            işlemler_yönetici a = new işlemler_yönetici();
            a.Show();
        }

        private void kARGOBİLGİLERİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yönetici_innerjoin m = new yönetici_innerjoin();
            m.Show();
        }

        private void satışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 a = new Form6();
            a.Show();
        }

        private void kargomNeredeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kargom a = new kargom();
            a.Show();
        }
    }
}

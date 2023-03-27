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
    public partial class Form4 : Form
    {
        static SqlDataAdapter da;
        static SqlConnection con;
        static DataSet ds;
        static SqlCommand cmd;
        static SqlDataReader dr;
        public static string sqlcon = @"Data Source=DESKTOP-75U42TN\SQLEXPRESS;Initial Catalog=deneme;Integrated Security=True";
        public int sonuc = 0;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == sonuc.ToString())
            {
                label5.Text = "";
                if (textBox2.Text == textBox3.Text)
                {
                    eskişifrekontrol();
                }
                else
                {
                    label5.Text = "yeni şifre ve tekrarı aynı değil!!";
                    captcholustur();
                }
            }
            else
            {
                label5.Text = "işlem hatalı yapıldı!!";
                captcholustur();

            }
        }
        public void eskişifrekontrol()
        {
            string sorgu = "select sıfre from tbl_login where kullanıcı=@user and sıfre=@pass";
            con = new SqlConnection(sqlcon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", Form1.kullanıcsession);
            cmd.Parameters.AddWithValue("@pass", veritabanı.md5sıfre(textBox1.Text));
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                //eski şifre doğru ise yapılacak işlemler
                string sql = "update tbl_login set sıfre='" + veritabanı.md5sıfre(textBox2.Text) + "'";

                veritabanı.komutyolla(sql);
                MessageBox.Show("şifre değiştirme işlemi başarılıdır!");
                label5.Text = "şifreniz başarıyla değişitirldi...";
            }
            else
            {
                label5.Text = "eski şifre hatalı!!";
                captcholustur();
            }
            con.Close();
        }
        public void captcholustur()
        {
            Random r = new Random();
            int ilk = r.Next(0, 50);
            int ikinci = r.Next(0, 50);
            sonuc = ilk + ikinci;
            label4.Text = ilk.ToString() + "+" + ikinci.ToString() + "=";
            //label5.Text = Form1.kullanıcsession;
            textBox4.Clear();

        }
        private void Form4_Load(object sender, EventArgs e)
        {
            label6.Text = Form1.kullanıcsession+" kullanıcısı";
            label5.Text = "";
            captcholustur();
        }

        
    }
}

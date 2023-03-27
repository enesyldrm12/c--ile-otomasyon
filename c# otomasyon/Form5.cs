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

    
    public partial class Form5 : Form
    {
        SqlDataAdapter da;
        SqlConnection con;
        DataSet ds;
        SqlCommand cmd;
        SqlDataReader dr;
        public static string sqlcon = @"Data Source=DESKTOP-75U42TN\SQLEXPRESS;Initial Catalog=deneme;Integrated Security=True";
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'denemeDataSet.tbl_login' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_loginTableAdapter.Fill(this.denemeDataSet.tbl_login);
            veribaglantılarınavigasyon();

        }
        public void veribaglantılarınavigasyon()
        {
            con = new SqlConnection(sqlcon);
            da = new SqlDataAdapter("select *from tbl_login", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds,"tbl_login");
            con.Close();
            bindingSource1.DataSource = ds.Tables[0];
            bindingNavigator1.BindingSource = bindingSource1;
            label1.DataBindings.Add(new Binding("Text",bindingSource1,"kID"));
            textBox1.DataBindings.Add(new Binding("Text", bindingSource1, "kullanıcı"));
            textBox2.DataBindings.Add(new Binding("Text", bindingSource1, "sıfre"));
            dateTimePicker1.DataBindings.Add(new Binding("Text", bindingSource1, "tarih"));

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label6.Text = comboBox1.Text;
            label7.Text = comboBox1.SelectedValue.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

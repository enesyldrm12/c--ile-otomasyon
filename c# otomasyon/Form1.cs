using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hepsinideneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public static string kullanıcsession = "";
        int deneme = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            if (veritabanı.login(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("GİRİŞ BAŞARILIDIR!!!");
                this.Hide();

                kullanıcsession = textBox1.Text;
                if (kullanıcsession == "iste")
                {
                    //yönetici olan kullanıcı  için
                    Form3 f3 = new Form3();
                    f3.Show();
                    //işlemler_yönetici a = new işlemler_yönetici();
                    // a.Show();
                    
                   //yönetici_innerjoin a = new yönetici_innerjoin();
                   // a.Show();
                }
                else
                {
                    Form2 f2 = new Form2();
                    f2.Show();
                    //diğer kullanıcılar için
                }


            }
            else
            {
                MessageBox.Show("GİRİŞ BAŞARISIZ!!!");
                deneme++;
                if (deneme == 3)
                {
                    MessageBox.Show("3 KERE YANLİŞ GİRİLDİ!!");
                    Application.Exit();
                }
            }
        }
    }
}

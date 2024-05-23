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
namespace Kütüphane_Projesi
{
    public partial class Kullanıcı_Giris : Form
    {
        public Kullanıcı_Giris()
        {
            InitializeComponent();
        }
        Baglanti con= new Baglanti();
        
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select userTc, userSifre from Tbl_User where userTc=@p1 and userSifre=@p2", con.baglanti());
            cmd.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@p2", maskedTextBox2.Text);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                Kullanıcı_Panel kp= new Kullanıcı_Panel();
                kp.tc = maskedTextBox1.Text;
                kp.Show();
                
                this.Hide();
                con.baglanti().Close();
            }
            else
            {
                MessageBox.Show("Girilen Bilgiler Yanlış");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            Giris g = new Giris();
            g.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

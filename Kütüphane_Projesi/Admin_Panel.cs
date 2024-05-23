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
using System.Data.Common;

namespace Kütüphane_Projesi
{
    public partial class Admin_Panel : Form
    {
        public Admin_Panel()
        {
            InitializeComponent();
        }
        Baglanti con = new Baglanti();
        public void listele1()
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from Tbl_User", con.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            con.baglanti().Close();
        }
        public void listele2()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select * from Tbl_Kitap", con.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            con.baglanti().Close();
        }
        public void temizle1()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
        }
        public void temizle2()
        {
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            maskedTextBox4.Text = "";
            comboBox1.Text = "";
        }
        private void Admin_Panel_Load(object sender, EventArgs e)
        {
            listele1();

            listele2();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("insert into Tbl_User (userAd,userSoyad,userTc,userCinsiyet,userTelefon,userSifre )values (@p1,@p2,@p3,@p4,@p5,@p6)",con.baglanti());
            cmd2.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd2.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd2.Parameters.AddWithValue("@p3", maskedTextBox1.Text);
            if (radioButton1.Checked)
            {
                cmd2.Parameters.AddWithValue("@p4", radioButton1.Text);
            }
            else
            {
                cmd2.Parameters.AddWithValue("@p4", radioButton2.Text);
            }
            cmd2.Parameters.AddWithValue("@p5", maskedTextBox2.Text);
            cmd2.Parameters.AddWithValue("@p6", textBox3.Text);
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Kullanıcı Başarılı Bir Şekilde Kaydedildi");
            temizle1();
            listele1();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd3 = new SqlCommand("update Tbl_User set userAd=@k1, userSoyad=@k2, userTc=@k3, userCinsiyet=@k4, userTelefon=@k5, userSifre=@k6 where userID=@k7", con.baglanti());
            cmd3.Parameters.AddWithValue("@k1", textBox1.Text);
            cmd3.Parameters.AddWithValue("@k2", textBox2.Text);
            cmd3.Parameters.AddWithValue("@k3", maskedTextBox1.Text);
            if (radioButton1.Checked)
            {
                cmd3.Parameters.AddWithValue("@k4", radioButton1.Text);
            }
            else
            {
                cmd3.Parameters.AddWithValue("@k4", radioButton2.Text);
            }
            cmd3.Parameters.AddWithValue("@k5", maskedTextBox2.Text);
            cmd3.Parameters.AddWithValue("@k6", textBox3.Text);
            cmd3.Parameters.AddWithValue("@k7", textBox4.Text);
            cmd3.ExecuteNonQuery();
            MessageBox.Show("Kullanıcı Başarılı Bir Şekilde Güncellendi");
            temizle1();
            listele1();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox4.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            maskedTextBox2.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listele1();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd3 = new SqlCommand("delete from Tbl_User  where userID=@s1", con.baglanti());
            
            cmd3.Parameters.AddWithValue("@s1", textBox4.Text);
            cmd3.ExecuteNonQuery();
            MessageBox.Show("Kullanıcı Başarılı Bir Şekilde Silindi");
            temizle1();
            listele1();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand cmd5 = new SqlCommand("insert into Tbl_Kitap (kitapAd,kitapYazar,kitapSayfa,kitapTür)values (@m1,@m2,@m3,@m4)", con.baglanti());
            cmd5.Parameters.AddWithValue("@m1", textBox6.Text);
            cmd5.Parameters.AddWithValue("@m2", textBox5.Text);
            cmd5.Parameters.AddWithValue("@m3", maskedTextBox4.Text);
            
            cmd5.Parameters.AddWithValue("@m4", comboBox1.Text);
            cmd5.ExecuteNonQuery();
            MessageBox.Show("Kitap Başarılı Bir Şekilde Kaydedildi");
            temizle2();
            listele2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd6 = new SqlCommand("update Tbl_Kitap set kitapAd=@h1,kitapYazar=@h2,kitapSayfa=@h3,kitapTür=@h4 where kitapID=@h5  ", con.baglanti());
            cmd6.Parameters.AddWithValue("@h1", textBox6.Text);
            cmd6.Parameters.AddWithValue("@h2", textBox5.Text);
            cmd6.Parameters.AddWithValue("@h3", maskedTextBox4.Text);
            cmd6.Parameters.AddWithValue("@h5", textBox7.Text);
            cmd6.Parameters.AddWithValue("@h4", comboBox1.Text);
            cmd6.ExecuteNonQuery();
            MessageBox.Show("Kitap Başarılı Bir Şekilde Güncellendi");
            temizle2();
            listele2();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            textBox7.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
            textBox6.Text = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
            textBox5.Text = dataGridView2.Rows[secilen].Cells[2].Value.ToString();
            maskedTextBox4.Text = dataGridView2.Rows[secilen].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView2.Rows[secilen].Cells[4].Value.ToString();


        }

        private void button7_Click(object sender, EventArgs e)
        {
            listele2();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlCommand cmd6 = new SqlCommand("delete from Tbl_Kitap where kitapID=@s1  ", con.baglanti());
            
            cmd6.Parameters.AddWithValue("@s1", textBox7.Text);
            
            cmd6.ExecuteNonQuery();
            MessageBox.Show("Kitap Başarılı Bir Şekilde Silindi");
            temizle2();
            listele2();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Admin_Giris ag2 = new Admin_Giris();
            ag2.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

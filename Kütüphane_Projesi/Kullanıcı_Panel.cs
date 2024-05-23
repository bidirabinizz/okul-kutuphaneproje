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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kütüphane_Projesi
{
    public partial class Kullanıcı_Panel : Form
    {
        public Kullanıcı_Panel()
        {
            InitializeComponent();
        }
        public string tc;
        Baglanti con=new Baglanti();
        public void listele()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter da= new SqlDataAdapter("select * from Tbl_Kitap",con.baglanti());
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
        public void listele2()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Operation where userAd='"+ label4.Text +"'and userSoyad='"+label5.Text+"' ", con.baglanti());
            
            da.Fill(dataTable);
            dataGridView2.DataSource = dataTable;
        }
        public void temizle() 
        {
            textBox7.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            maskedTextBox1.Text = "";
        }
        private void Kullanıcı_Panel_Load(object sender, EventArgs e)
        {
            label6.Text = tc;
            SqlCommand cmd = new SqlCommand("select userAd, userSoyad from Tbl_User where userTc=@p1", con.baglanti());
            cmd.Parameters.AddWithValue("@p1",label6.Text);
            SqlDataReader rd= cmd.ExecuteReader();
            while(rd.Read()) 
            {
                label4.Text = rd[0].ToString();
                label5.Text = rd[1].ToString();
            }
            con.baglanti().Close();
            listele();
            listele2();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox7.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox6.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Tbl_Operation (userAd,userSoyad,kitapAd,kitapYazar,tarih) values(@p1,@p2,@p3,@p4,@p5) ", con.baglanti());
            cmd.Parameters.AddWithValue("@p1", label4.Text);
            cmd.Parameters.AddWithValue("@p2",label5.Text);          
            cmd.Parameters.AddWithValue("@p3", textBox6.Text);
            cmd.Parameters.AddWithValue("@p4", textBox5.Text);
            cmd.Parameters.AddWithValue("@p5", maskedTextBox1.Text);
            SqlCommand cmd3 = new SqlCommand("select kitapAd from Tbl_Kitap where kitapDurum=@x1 and kitapID=@x2", con.baglanti());
            cmd3.Parameters.AddWithValue("@x1", "Müsait");
            cmd3.Parameters.AddWithValue("@x2",textBox7.Text);
            SqlDataReader rd=cmd3.ExecuteReader();
            if (rd.Read())
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kitap Kiralandı");
            }
            else
            {
                MessageBox.Show("Kitap Zaten Kirada. Lütfen Başka Bir Kitap Seçiniz");
            }
            
            con.baglanti().Close();
            SqlCommand cmd2=new SqlCommand("update Tbl_Kitap set kitapDurum=@l1 where kitapID=@l2",con.baglanti());
            cmd2.Parameters.AddWithValue("@l1","Kirada");
            cmd2.Parameters.AddWithValue("@l2", textBox7.Text);
            cmd2.ExecuteNonQuery();
            listele2();
            listele();
            temizle();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Kullanıcı_Giris kg2= new Kullanıcı_Giris();
            kg2.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

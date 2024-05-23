using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kütüphane_Projesi
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_Giris ag=new Admin_Giris();
            ag.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kullanıcı_Giris kg=new Kullanıcı_Giris();
            kg.Show();
            this.Hide();
        }
    }
}

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
namespace gestion_vente
{
    public partial class Form1 : Form
    {
        BL.Login log = new BL.Login();
        public Form1()
        {
           
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = log.LOGIN(txtID.Text, txtPWD.Text);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("bienvenue ");
                Menu n = new Menu();
                n.ShowDialog();
                this.Close();

            }
            else
            {
                MessageBox.Show("Probleme dans la Connection");
            }
        }
    }
}


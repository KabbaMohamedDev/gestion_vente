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
    public partial class Commande : Form
    {

        SqlConnection cn = new SqlConnection(@"Data Source=.;Initial Catalog=gestion vente;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter Da;
        DataTable dt = new DataTable();
        DataTable dtt = new DataTable();
        DataTable dts = new DataTable();
        public Commande()
        {
            InitializeComponent();
            DataGrid();


            Da = new SqlDataAdapter("select * from Client", cn);
            Da.Fill(dts);
            comboBox2.DataSource = dts;
            comboBox2.DisplayMember = "Id_client";

            Da = new SqlDataAdapter("select * from Commande", cn);
            Da.Fill(dtt);
            comboBox1.DataSource = dtt;
            comboBox1.DisplayMember = "Id_commande";
        }
        public void DataGrid()
        {

            dt.Clear();
            cmd = new SqlCommand("selectcommande", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);
            this.dataGridView1.DataSource = dt;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Commande_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("Ajoutercommande", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@date", SqlDbType.Date);
                param[0].Value = date.Value;
                param[1] = new SqlParameter("@id", SqlDbType.Int);
                param[1].Value = comboBox2.Text;
                cmd.Parameters.AddRange(param);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Bien Ajouter", "add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
                DataGrid();

            }
            catch
            {
                MessageBox.Show("Non Ajouter", "add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("supcmd", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param = new SqlParameter("@id", SqlDbType.Int);
                param.Value = comboBox1.Text;
                cmd.Parameters.Add(param);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Supprimer ", "del", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
                DataGrid();
            }
            catch
            {
                MessageBox.Show(" Non Supprimer ", "del", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("modifier", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@id", SqlDbType.Int);
                param[0].Value = comboBox1.Text;
                param[1] = new SqlParameter("@idc", SqlDbType.Int);
                param[1].Value = comboBox2.Text;
                param[2] = new SqlParameter("@date", SqlDbType.Date);
                param[2].Value = date.Text;

                cmd.Parameters.AddRange(param);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Bien Modifier", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
                DataGrid();
            }
            catch
            {
                MessageBox.Show("Non Modifier", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pos = dataGridView1.CurrentRow.Index;
            comboBox1.Text = dataGridView1.Rows[pos].Cells[0].Value.ToString();
           date.Text = dataGridView1.Rows[pos].Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[pos].Cells[2].Value.ToString();
        }
    }
}

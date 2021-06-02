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
    public partial class DetailleCommande : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.;Initial Catalog=gestion vente;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter Da;
        DataTable dt = new DataTable();
        DataTable dtt = new DataTable();
        DataTable dts = new DataTable();
        public DetailleCommande()
        {
            InitializeComponent();
            DataGrid();
            Da = new SqlDataAdapter("select * from Commande", cn);
            Da.Fill(dtt);
            comboBox2.DataSource = dtt;
            comboBox2.DisplayMember = "Id_commande";

            Da = new SqlDataAdapter("select * from Produits", cn);
            Da.Fill(dts);
            comboBox1.DataSource = dts;
            comboBox1.DisplayMember = "Id_produit";

        }
        void DataGrid()
        {
            dt.Clear();
            cmd = new SqlCommand("selectdtcmd", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);
            this.dataGridView1.DataSource = dt;
        }
        private void DetailleCommande_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    cmd = new SqlCommand("ajouterdt", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[3];
                    param[0] = new SqlParameter("@idp", SqlDbType.Int);
                    param[0].Value = comboBox1.Text;
                    param[1] = new SqlParameter("@idc", SqlDbType.Int);
                    param[1].Value = comboBox2.Text;
                    param[2] = new SqlParameter("@qt", SqlDbType.Int);
                    param[2].Value = textBox1.Text;
                    cmd.Parameters.AddRange(param);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Bien Ajouter", "add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                    DataGrid();
                }
                else
                {
                    MessageBox.Show("non Ajouter", "add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Vous devez remplir tous les champs obligatoires", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                }
            }
            catch
            {
                MessageBox.Show("Non Ajouter", "add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("supdt", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@idp", SqlDbType.Int);
                param[0].Value = comboBox1.Text;
                param[1] = new SqlParameter("@idc", SqlDbType.Int);
                param[1].Value = comboBox2.Text;
                cmd.Parameters.AddRange(param);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Supprimer ", "del", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataGrid();
            }
            catch
            {

                MessageBox.Show(" Non Supprimer ", "del", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    cmd = new SqlCommand("modidt", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[3];
                    param[0] = new SqlParameter("@idp", SqlDbType.Int);
                    param[0].Value = comboBox1.Text;
                    param[1] = new SqlParameter("@idc", SqlDbType.Int);
                    param[1].Value = comboBox2.Text;
                    param[2] = new SqlParameter("@qt", SqlDbType.Int);
                    param[2].Value = textBox1.Text;

                    cmd.Parameters.AddRange(param);
                    cn.Open();
                    cmd.ExecuteNonQuery();

                    cn.Close();
                    MessageBox.Show("Bien Modifier", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                    DataGrid();
                }
                else
                {
                    MessageBox.Show("Non Modifier", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Vous devez remplir tous les champs obligatoires", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Non Modifier", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pos = dataGridView1.CurrentRow.Index;
            comboBox1.Text = dataGridView1.Rows[pos].Cells[0].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[pos].Cells[1].Value.ToString();
         textBox1.Text = dataGridView1.Rows[pos].Cells[2].Value.ToString();
        }
    }
}

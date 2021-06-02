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
    public partial class Clients : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.;Initial Catalog=gestion vente;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter Da;
        DataTable dt = new DataTable();
        DataTable dtt = new DataTable();
        public Clients()
        {
            InitializeComponent();
            DataGrid();
            Da = new SqlDataAdapter("select * from Client", cn);
            Da.Fill(dtt);
            cmbid.DataSource = dt;
            cmbid.DisplayMember = "Id_Client";
        }
        void DataGrid()
        {
            dt.Clear();
            cmd = new SqlCommand("selectclient", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);
            this.dataGridView1.DataSource = dt;
        }

        private void Clients_Load(object sender, EventArgs e)
        {

        }

        private void btnajouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcin.Text != "" && txtnom.Text != "" && txtprenom.Text != "" && txtemail.Text != "" && txttele.Text != "" && txtville.Text != "")
                {
                    cmd = new SqlCommand("ajouterClient", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[6];
                    param[0] = new SqlParameter("@nom", SqlDbType.VarChar, 20);
                    param[0].Value = txtnom.Text;
                    param[1] = new SqlParameter("@prenom", SqlDbType.VarChar, 20);
                    param[1].Value = txtprenom.Text;
                    param[2] = new SqlParameter("@tele", SqlDbType.VarChar, 20);
                    param[2].Value = txttele.Text;
                    param[3] = new SqlParameter("@email", SqlDbType.VarChar, 20);
                    param[3].Value = txtemail.Text;
                    param[4] = new SqlParameter("@CIN", SqlDbType.NVarChar, 20);
                    param[4].Value = txtcin.Text;

                    param[5] = new SqlParameter("@ville", SqlDbType.VarChar, 20);
                    param[5].Value = txtville.Text;
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
                    MessageBox.Show("Non Modifier", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Vous devez remplir tous les champs obligatoires", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           try
            {
                if (txtcin.Text != "" && txtnom.Text != "" && txtprenom.Text != "" && txtemail.Text != "" && txttele.Text != "" && txtville.Text != "")
                {
            cmd = new SqlCommand("modifiercli", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[7];
                    param[0] = new SqlParameter("@id", SqlDbType.Int);
                    param[0].Value = cmbid.Text;
                    param[1] = new SqlParameter("@nom", SqlDbType.VarChar, 20);
                    param[1].Value = txtnom.Text;
                    param[2] = new SqlParameter("@prenom", SqlDbType.VarChar, 20);
                    param[2].Value = txtprenom.Text;
                    param[3] = new SqlParameter("@tele", SqlDbType.VarChar, 20);
                    param[3].Value = txttele.Text;
                    param[4] = new SqlParameter("@email", SqlDbType.VarChar, 20);
                    param[4].Value = txtemail.Text;
                    param[5] = new SqlParameter("@cin", SqlDbType.NVarChar, 20);
                    param[5].Value = txtcin.Text;
                    param[6] = new SqlParameter("@ville", SqlDbType.VarChar, 20);
                    param[6].Value = txtville.Text;
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
            catch
            {
                MessageBox.Show("Non Modifier", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                cmd = new SqlCommand("supclient", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param = new SqlParameter("@id", SqlDbType.Int);
                param.Value = cmbid.Text;
                cmd.Parameters.Add(param);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pos = dataGridView1.CurrentRow.Index;
            cmbid.Text = dataGridView1.Rows[pos].Cells[0].Value.ToString();
            txtnom.Text = dataGridView1.Rows[pos].Cells[1].Value.ToString();
            txtprenom.Text = dataGridView1.Rows[pos].Cells[2].Value.ToString();
            txttele.Text = dataGridView1.Rows[pos].Cells[3].Value.ToString();
            txtemail.Text = dataGridView1.Rows[pos].Cells[4].Value.ToString();
            txtcin.Text = dataGridView1.Rows[pos].Cells[5].Value.ToString();
            txtville.Text = dataGridView1.Rows[pos].Cells[6].Value.ToString();
        }
    }
}
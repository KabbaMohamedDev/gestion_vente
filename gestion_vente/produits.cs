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
    public partial class produits : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.;Initial Catalog=gestion vente;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter Da;
        DataTable dt = new DataTable();
        DataTable dts = new DataTable();
        DataTable dtt = new DataTable();

        public produits()
        {
            InitializeComponent();
            DataGrid();
            Da = new SqlDataAdapter("select * from categories", cn);
            Da.Fill(dtt);
            comboBox2.DataSource = dtt;
            comboBox2.DisplayMember = "id_categories";

            Da = new SqlDataAdapter("select * from produits", cn);
            Da.Fill(dts);
            comboBox1.DataSource = dts;
            comboBox1.DisplayMember = "id_produit";
        }
        void DataGrid()
        {
            dt.Clear();
            cmd = new SqlCommand("selectproduit", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);
            this.dataGridView1.DataSource = dt;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void produits_Load(object sender, EventArgs e)

        {


        }

        private void btnajouter_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void btnajouter_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    cmd = new SqlCommand("ajouterproduit", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[4];
                    param[0] = new SqlParameter("@nom", SqlDbType.VarChar, 20);
                    param[0].Value = textBox1.Text;
                    param[1] = new SqlParameter("@qnt", SqlDbType.Int);
                    param[1].Value = textBox3.Text;
                    param[2] = new SqlParameter("@prix", SqlDbType.VarChar, 20);
                    param[2].Value = textBox2.Text;
                    param[3] = new SqlParameter("@idcat", SqlDbType.Int);
                    param[3].Value = comboBox2.Text;
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
                MessageBox.Show("problem dans le saisie", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
            }
        
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    cmd = new SqlCommand("modifierprod", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[5];
                    param[0] = new SqlParameter("@id", SqlDbType.Int);
                    param[0].Value = comboBox1.Text;
                    param[1] = new SqlParameter("@nom", SqlDbType.VarChar, 20);
                    param[1].Value = textBox1.Text;
                    param[2] = new SqlParameter("@qnt", SqlDbType.Int);
                    param[2].Value = textBox3.Text;
                    param[3] = new SqlParameter("@pr", SqlDbType.VarChar, 20);
                    param[3].Value = textBox2.Text;
                    param[4] = new SqlParameter("@idc", SqlDbType.Int);
                    param[4].Value = comboBox2.Text;
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("supprimerproduit", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param = new SqlParameter("@id", SqlDbType.Int);
                param.Value = comboBox1.Text;
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

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pos = dataGridView1.CurrentRow.Index;
            comboBox1.Text = dataGridView1.Rows[pos].Cells[0].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[pos].Cells[4].Value.ToString();
            textBox1.Text = dataGridView1.Rows[pos].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[pos].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[pos].Cells[3].Value.ToString();
        }
    }
}

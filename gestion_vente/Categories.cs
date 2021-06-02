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
    public partial class Categories : Form
    {
       
         SqlConnection cn = new SqlConnection(@"Data Source=.;Initial Catalog=gestion vente;Integrated Security=True");
         SqlCommand cmd;
         SqlDataAdapter Da;
         DataTable dt = new DataTable();
         DataTable dtt = new DataTable();

        public Categories()
        {
            InitializeComponent();
            DataGrid();
            Da = new SqlDataAdapter("select * from categories", cn);
            Da.Fill(dtt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "id_categories";
        }
        void DataGrid()
        {
            dt.Clear();
            cmd = new SqlCommand("selectcategories", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);
            this.dataGridView1.DataSource = dt;
        }

        
        private void Categories_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAjo_Click(object sender, EventArgs e)
        {
            //fais ajoutement avec la procedure stocke cree dans sqlserver
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    cmd = new SqlCommand("ajouterCategorie", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[2];
                    param[0] = new SqlParameter("@des", SqlDbType.VarChar, 20);
                    param[0].Value = textBox2.Text;
                    param[1] = new SqlParameter("@nom", SqlDbType.VarChar, 20);
                    param[1].Value = textBox1.Text;
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("supprimercategories", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param = new SqlParameter("@id", SqlDbType.Int);
                param.Value = comboBox1.Text;
                cmd.Parameters.Add(param);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("bien Supprimer ", "supprimer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataGrid();
            }
            catch
            {
                MessageBox.Show(" Non Supprimer ", "Supprimer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
            }

        }

        private void btnModi_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    cmd = new SqlCommand("modifiercategories", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[3];
                    param[0] = new SqlParameter("@id", SqlDbType.Int);
                    param[0].Value = comboBox1.Text;
                    param[1] = new SqlParameter("@des", SqlDbType.VarChar, 25);
                    param[1].Value = textBox2.Text;
                    param[2] = new SqlParameter("@nom", SqlDbType.VarChar, 50);
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
            textBox2.Text = dataGridView1.Rows[pos].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.Rows[pos].Cells[2].Value.ToString();
        }
    }
}

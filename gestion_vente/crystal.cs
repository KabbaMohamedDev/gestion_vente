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
    public partial class crystal : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.;Initial Catalog=gestion vente;Integrated Security=True");
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        public crystal()
        {
            InitializeComponent();
            da = new SqlDataAdapter("select * from Client",cn);
            da.Fill(dt);
            this.dataGridView1.DataSource = dt;

        }

        private void crystal_Load(object sender, EventArgs e)
        {

        }
    }
}

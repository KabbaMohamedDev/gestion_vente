using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestion_vente
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Categories ct = new Categories();
            ct.ShowDialog();
        }

        private void produitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            produits prd = new produits();
            prd.ShowDialog();
        }

        private void clienbtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clients cl = new Clients();
           cl.ShowDialog();
        }

        private void commandeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commande cmd = new Commande();
            cmd.ShowDialog();
        }

        private void detailleCommandeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetailleCommande dt = new DetailleCommande();
            dt.ShowDialog();
        }
    }
}

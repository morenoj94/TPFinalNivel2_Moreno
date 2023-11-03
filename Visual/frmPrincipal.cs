using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual
{
    public partial class frmPrincipal : Form
    {
        private List<Article> articlesList;
        public frmPrincipal()
        {
            InitializeComponent();
        }
        private void load() 
        {
            BusinessArticle business = new BusinessArticle();
            try
            {
                articlesList = business.listar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            dgvArticle.DataSource = articlesList;
            hideColums();
        }

        private void hideColums()
        {
            dgvArticle.Columns["id"].Visible = false;
            dgvArticle.Columns["urlImagen"].Visible = false;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}

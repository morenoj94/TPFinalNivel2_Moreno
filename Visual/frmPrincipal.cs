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

        private void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Article> filteredList;
            string filter = txtFiltroRapido.Text;
            if (txtFiltroRapido.TextLength > 1)
            {
                //la lista filtrada busca por nombre, codigo, marca o categoria
                filteredList = articlesList.FindAll(x => x.Name.ToLower().Contains(filter.ToLower()) || x.Code.ToLower().Contains(filter.ToLower()) || x.articleBrand.Description.ToLower().Contains(filter.ToLower()) || x.articleCategory.Description.ToLower().Contains(filter.ToLower()));
            }
            else
            {
                filteredList = articlesList;
            }
            dgvArticle.DataSource = null;
            dgvArticle.DataSource = filteredList;
            hideColums();
        }
    }
}

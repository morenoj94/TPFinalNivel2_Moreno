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
            cbElemento.Items.Add("Nombre");
            cbElemento.Items.Add("Categoria");
            cbElemento.Items.Add("Marca");
            cbElemento.Items.Add("Precio");
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

        private void cbElemento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbElemento.SelectedItem.ToString() == "Precio")
            {
                cbTipo.Items.Clear();
                cbTipo.Items.Add("Mayor que");
                cbTipo.Items.Add("Igual a");
                cbTipo.Items.Add("Menor que");
            }
            else
            {
                cbTipo.Items.Clear();
                cbTipo.Items.Add("Que inicie con");
                cbTipo.Items.Add("Que termine con");
                cbTipo.Items.Add("Que contenga");
            }
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            BusinessArticle business = new BusinessArticle();
            string elemento, tipo, filtro;
            try
            {
                elemento = cbElemento.SelectedItem.ToString();
                tipo = cbTipo.SelectedItem.ToString();
                filtro = txtFiltroAvanzado.Text;
                dgvArticle.DataSource = business.filter(elemento, tipo, filtro);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

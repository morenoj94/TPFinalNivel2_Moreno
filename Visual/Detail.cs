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
    public partial class Detail : Form
    {
        private Article article = null;
        public Detail()
        {
            InitializeComponent();
            Text = "Agregar Articulo";            
        }
        public Detail(Article article) 
        {
            InitializeComponent();
            this.article = article;
            Text = "Detalles del articulo";
            btnAgregar.Text = "Modificar articulo";
        }

        private void Detail_Load(object sender, EventArgs e)
        {
            BusinessBrand brand = new BusinessBrand();
            BusinessCategory category = new BusinessCategory();
            try
            {
                cbMarca.DataSource = brand.listar();
                cbMarca.ValueMember = "Id";
                cbMarca.DisplayMember = "Description";
                cbCategoria.DataSource = category.listar();
                cbCategoria.ValueMember = "Id";
                cbCategoria.DisplayMember = "Description";

                if (article != null)
                {
                    txtCodigo.Text = article.Code;
                    txtNombre.Text = article.Name;
                    txtDescripcion.Text = article.Desciption;
                    txtUrlImagen.Text = article.imageUrl;
                    loadPicture(article.imageUrl);
                    cbMarca.SelectedValue = article.articleBrand.Id;
                    cbCategoria.SelectedValue = article.articleCategory.Id;
                    txtPrecio.Text = article.Price.ToString();
                }
                else
                {
                    cbMarca.SelectedIndex = -1;
                    cbCategoria.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {

                
                
                throw ex;
            }
            
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (article == null)
            {
                article = new Article();
            }
            article.Code = txtCodigo.Text;
            article.Name = txtNombre.Text;
            article.Desciption = txtDescripcion.Text;
            article.articleBrand = (Brand)cbMarca.SelectedItem;
            article.articleCategory = (Category)cbCategoria.SelectedItem;
            article.imageUrl = txtUrlImagen.Text;
            article.Price = decimal.Parse(txtPrecio.Text);

            BusinessArticle business = new BusinessArticle();
            if (article.Id != 0)
            {
                business.modifyArticle(article);
                MessageBox.Show("Modificado exitosamente");
            }
            else
            {
                business.addArticle(article);
                MessageBox.Show("Agregado exitosamente");
            }
            Close();
        }
        private void loadPicture(string picture) 
        {
            try
            {
                pbArticulo.Load(picture);
            }
            catch (Exception ex)
            {

                pbArticulo.Load("https://media.prodalam.cl/default/default.png");
            }
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            loadPicture(txtUrlImagen.Text);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

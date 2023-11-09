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
            if (validate())
            {
                return;
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

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            loadPicture(txtUrlImagen.Text);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            newBrand();
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            newCategory();
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


        //Inician las validaciones 
        private bool validate()
        {
            if (textBoxEmpty()) 
            {
                MessageBox.Show("Debes llenar todos los campos");
                return true;
            }
            if (comboBoxEmpty())
                {
                    MessageBox.Show("Debes seleccionar un elemento de la lista o agregarlo con el boton \"+\"");
                    return true;
                }            
            if (!(justDecimal(txtPrecio.Text)))
            {
                MessageBox.Show("Solo puedes ingresar numeros en la casilla de precio");
                return true;
            }
            return false;
        }
        
        private bool justDecimal(string text)
        {
            decimal price;
            if (decimal.TryParse(text, out price))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool textBoxEmpty() 
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    if (string.IsNullOrEmpty(control.Text))
                    {                        
                        return true;
                    }
                }
            }
            return false;
        }
        private bool comboBoxEmpty() 
        {
            foreach (Control control in this.Controls) 
            {
                if (control is ComboBox) 
                {
                    ComboBox cb = (ComboBox)control;
                    if (cb.SelectedIndex < 0) 
                    {                        
                        return true;
                    }
                }
            }
            return false;
        }
        
        private void newBrand() 
        {
            bool newB = true;
            foreach (Brand item in cbMarca.Items) 
            {
                if (item.ToString().ToLower() == cbMarca.Text.ToLower())
                {
                    newB = false;
                    break;
                }
            }
            if (newB)
            {
                string newBrand = char.ToUpper(cbMarca.Text[0]) + cbMarca.Text.Substring(1).ToLower();
                BusinessBrand brand = new BusinessBrand();
                brand.addBrand(newBrand);
                cbMarca.DataSource = brand.listar();
                cbMarca.SelectedIndex = -1;
                cbMarca.Text = newBrand;
                MessageBox.Show("Se agrego una nueva marca");
                
            }
            
            
        }
        private void newCategory() 
        {
            bool newC = true;
            foreach (Category item in cbCategoria.Items)
            {
                if (item.ToString().ToLower() == cbCategoria.Text.ToLower())
                {
                    newC = false;
                    break;
                }
            }
            if (newC) 
            {
                string newCategory = char.ToUpper(cbCategoria.Text[0]) + cbCategoria.Text.Substring(1).ToLower();
                BusinessCategory category = new BusinessCategory();
                category.addCategory(newCategory);
                cbCategoria.DataSource = category.listar();
                cbCategoria.SelectedIndex = -1;
                cbCategoria.Text = newCategory;
                MessageBox.Show("Se agrego una nueva categoria");
            }
            
            
        }

    }
}

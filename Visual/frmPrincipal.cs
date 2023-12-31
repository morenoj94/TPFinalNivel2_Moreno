﻿using Business;
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
            Style();
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

        private void Style()
        {
            BackColor = Color.FromArgb(208, 212, 211);
            dgvArticle.BackgroundColor = BackColor;
            dgvArticle.RowHeadersVisible = false;
            dgvArticle.CellFormatting += dgvArticle_CellFormatting;
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    c.BackColor = Color.FromArgb(8, 39, 70);
                    c.ForeColor = BackColor;
                }
            }
        }

        private void hideColums()
        {
            
            dgvArticle.Columns["id"].Visible = false;
            dgvArticle.Columns["imageUrl"].Visible = false;
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
                cbTipo.SelectedIndex = 1;
            }
            else
            {
                cbTipo.Items.Clear();
                cbTipo.Items.Add("Que inicie con");
                cbTipo.Items.Add("Que termine con");
                cbTipo.Items.Add("Que contenga");
                cbTipo.SelectedIndex = 2;
            }
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            BusinessArticle business = new BusinessArticle();
            string elemento, tipo, filtro;
            try
            {
                if (validateFilter())
                {
                    return;
                }
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

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Article selected;
            if (validateButtons()) { return;}
            selected = (Article)dgvArticle.CurrentRow.DataBoundItem;
            Detail articleDetail = new Detail(selected);
            articleDetail.ShowDialog();
            load();
            
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Detail addArticle = new Detail();
            addArticle.ShowDialog();
            load();
            hideColums();
        }

        private void btnModifcar_Click(object sender, EventArgs e)
        {
            btnDetalle_Click(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            BusinessArticle business = new BusinessArticle();
            Article seleted;
            if (validateButtons()) { return; }
            seleted = (Article)dgvArticle.CurrentRow.DataBoundItem;
            DialogResult resultado = MessageBox.Show("¿Seguro que quieres borrar este elemento? \n    Al borrarlo ya no podras acceder a el", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultado == DialogResult.Yes)
            {
                business.eliminar(seleted);
                MessageBox.Show("Articulo eliminado");                    
            }
            else
            {
                MessageBox.Show("No se elmino el articulo");
            }
            load();
            hideColums();
        }

        private void txtFiltroAvanzado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnFiltro_Click(sender, e);
            }
        }

        private void dgvArticle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDetalle_Click(sender, e);
        }

        //Inician las validaciones
        private bool validateFilter()
        {
            if (cbElemento.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el Elemento para filtar");
                return true;
            }
            if (cbTipo.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el tipo de criterio para filtrar");
                return true;
            }
            if (cbElemento.SelectedItem.ToString() == "Precio")
            {
                if (!(justDecimal(txtFiltroAvanzado.Text)) || string.IsNullOrEmpty(txtFiltroAvanzado.Text))
                {
                    MessageBox.Show("Solo puedes ingresar numeros cuando el elemto a filtrar es el precio");
                    return true;
                }
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
        private bool validateButtons() 
        {
            if (dgvArticle.CurrentRow == null)
            {
                MessageBox.Show("Por favor selecciona un articulo");
                return true;
            }
            else
            {
                return false;
            }

        }

        private void dgvArticle_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvArticle.Columns["Price"].Index && e.Value != null)
            {
                // Limitar la cantidad de decimales a dos
                double valor = Convert.ToDouble(e.Value);
                e.Value = valor.ToString("0.00");
                e.FormattingApplied = true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pyInventario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conexionBD BD = new conexionBD();
            BD.mostrarProductos(dgvProductos);

            string[] categorias = new string[] { "Electronicos", "Hogar", "Deportes", "Libros", "Accesorios", "Herramientas","Cocina", "Oficina" };

            foreach (var categoria in categorias)
            {
                cmbCategorias.Items.Add(categoria);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Productos productoNuevo = new Productos();
                conexionBD BD = new conexionBD();

                productoNuevo.Nombre = txtNombre.Text;
                productoNuevo.Descripcion = txtDescripcion.Text;
                productoNuevo.Precio = Convert.ToInt32(numPrecio.Value); 
                productoNuevo.Stock = Convert.ToInt32(numStock.Value);    
                productoNuevo.Categoria = cmbCategorias.Text;

                BD.agregarProductos(productoNuevo);
                BD.mostrarProductos(dgvProductos);

                MessageBox.Show("Producto agregado con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                conexionBD BD = new conexionBD();
                string ID = txtCodigo.Text;

                if (string.IsNullOrEmpty(ID))
                {
                    MessageBox.Show("Por favor ingrese un código de producto.");
                    return;
                }

                BD.eliminarProducto(ID);
                BD.mostrarProductos(dgvProductos);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el producto: {ex.Message}");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    MessageBox.Show("Ingrese un código de producto para actualizar.");
                    return;
                }

                Productos productoActualizado = new Productos()
                {
                    ID = Convert.ToInt32(txtCodigo.Text),
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = Convert.ToInt32(numPrecio.Value),
                    Stock = Convert.ToInt32(numStock.Value),
                    Categoria = cmbCategorias.Text
                };

                conexionBD BD = new conexionBD();
                BD.modificarProductos(productoActualizado);
                BD.mostrarProductos(dgvProductos);

                MessageBox.Show("Producto modificado con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el producto: {ex.Message}");
            }
        }

        private void Acciones_Enter(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtBuscarProducto.Text.Trim();

                if (string.IsNullOrEmpty(id))
                {
                    MessageBox.Show("Por favor ingrese un ID para buscar.");
                    return;
                }

                conexionBD BD = new conexionBD();
                BD.buscarProductoPorID(id, dgvProductos);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar la búsqueda: {ex.Message}");
            }
            txtBuscarProducto.Text = "";
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            conexionBD BD = new conexionBD();
            BD.mostrarProductos(dgvProductos);
        }
    }
}

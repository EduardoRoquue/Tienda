using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tienda.BLL;
using Tienda.DAL;

namespace Tienda.PL
{
    public partial class frmProductos : Form
    {
        ProductosDAL oProductosDAL;

        public frmProductos()
        {
            oProductosDAL = new ProductosDAL();
            InitializeComponent();
            dgvConsultas.DataSource = oProductosDAL.MostrarProductos().Tables[0];
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Exito ");
            //Utilizar DAL ... Informacion de la GUI
            oProductosDAL.Agregar(RecuperarInformacion());
        }

        private ProductoBLL RecuperarInformacion()
        {
            ProductoBLL oProductoBLL = new ProductoBLL();

            int ID = 0; int.TryParse(txtID.Text, out ID);
            oProductoBLL.ID = ID;

            oProductoBLL.Producto = txtNombre.Text;

          int Precio = 0; int.TryParse(txtPrecio.Text, out Precio);
            oProductoBLL.Precio = Precio;

            int Cantidad = 0; int.TryParse(txtCantidad.Text, out Cantidad);
            oProductoBLL.Cantidad = Cantidad;

            return oProductoBLL;
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;
            txtID.Text = dgvConsultas.Rows[indice].Cells[0].Value.ToString();
            txtNombre.Text = dgvConsultas.Rows[indice].Cells[1].Value.ToString();
            txtPrecio.Text = dgvConsultas.Rows[indice].Cells[2].Value.ToString();
            txtCantidad.Text = dgvConsultas.Rows[indice].Cells[3].Value.ToString();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            oProductosDAL.Eliminar(RecuperarInformacion());
            dgvConsultas.DataSource = oProductosDAL.MostrarProductos().Tables[0];
        }
    }
}

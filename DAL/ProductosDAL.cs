using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Tienda.BLL;

namespace Tienda.DAL
{
    class ProductosDAL
    {
        ConexionDAL conexion;
        public ProductosDAL()
        {
            conexion = new ConexionDAL();
        }

        public bool Agregar(ProductoBLL oProductoBLL)
        {
            return conexion.ejecutarComandoSinRetornoDatos("INSERT INTO bebibles(NOMBRE_BEBIBLES, PRECIO, CANTIDAD) VALUES('"+oProductoBLL.Producto+"')");

        }

        public int Eliminar(ProductoBLL oProductoBLL)
        {
            conexion.ejecutarComandoSinRetornoDatos("DELETE FROM bebibles WHERE ID="+ oProductoBLL.ID);
            return 1;
        }

        public DataSet MostrarProductos()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM bebibles");
            return conexion.EjecutarSentencia(sentencia);
        }
    }
}

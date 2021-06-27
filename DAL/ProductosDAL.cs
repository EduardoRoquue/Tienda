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
            return conexion.ejecutarComandoSinRetornoDatos("INSERT INTO bebibles (ID_bebibles, NOMBRE_BEBIBLES, PRECIO, CANTIDAD) " +
                "VALUES ('" + oProductoBLL.ID + "', '" + oProductoBLL.Producto+"', '"+oProductoBLL.Precio+"', '"+oProductoBLL.Cantidad+"')");            
        }
        public int Eliminar(ProductoBLL oProductoBLL)
             {
            conexion.ejecutarComandoSinRetornoDatos("DELETE FROM bebibles WHERE ID_bebibles="+oProductoBLL.ID);
            return 1;
        }

        public int Modificar(ProductoBLL oProductoBLL)
        {
             conexion.ejecutarComandoSinRetornoDatos("UPDATE bebibles" +
                "SET NOMBRE_BEBIBLES='"+oProductoBLL.Producto+"' "+
                "PRECIO='"+oProductoBLL.Precio+"' "+
                "CANTIDAD='"+oProductoBLL.Cantidad+"' "+
                "WHERE ID_bebibles='"+oProductoBLL.ID+"'");
            return 1;
        }

        public int Consulta(ProductoBLL oProductoBLL)
        {
            conexion.ejecutarComandoSinRetornoDatos("SELECT * FROM bebibles WHERE NOMBRE_BEBIBLES=" + oProductoBLL.Consulta);
            return 1;
        }

       public DataSet nombres( )
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM bebibles WHERE NOMBRE_BEBIBLES");
            return conexion.EjecutarSentencia(sentencia);
        }

        public DataSet MostrarProductos()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM bebibles");
            return conexion.EjecutarSentencia(sentencia);
        }
    }
}

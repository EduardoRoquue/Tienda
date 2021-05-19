using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Tienda.DAL
{
    class ConexionDAL
    {
        private string CadenaConexion = "Data Source=EDROCK\\SERVIDORTESI; Initial Catalog=tienda; Integrated Security= True";
        SqlConnection Conexion;

        public SqlConnection EstablecerConexion()
        {
             this.Conexion = new SqlConnection(this.CadenaConexion);
            return this.Conexion;
        }
        //CRUD 
        public bool ejecutarComandoSinRetornoDatos(string strComando)
        {
            try
            {
                SqlCommand Comando = new SqlCommand();

                Comando.CommandText = strComando;
                Comando.Connection = this.EstablecerConexion();
                Conexion.Open();
                Comando.ExecuteNonQuery();
                Conexion.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        //SELECT
        public DataSet EjecutarSentencia(SqlCommand sqlComando)
        {
            DataSet DS = new DataSet();
            SqlDataAdapter Adaptador = new SqlDataAdapter();

            try
            {
                SqlCommand Comando = new SqlCommand();
                Comando = sqlComando;
                Comando.Connection = EstablecerConexion();
                Adaptador.SelectCommand = Comando;
                Conexion.Open();
                Adaptador.Fill(DS);
                Conexion.Close();
                return DS;
            }
            catch
            {
                return DS;
            }
        }
    }
}

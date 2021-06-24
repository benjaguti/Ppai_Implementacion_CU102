using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PpaiImplementacion.IU.Entidades
{
    public class Sede
    {
        public Sede()
        {

        }

        private int idSede;
        private string nombre;
        private string descripcion;
        private int cantMaxVisitantes;
        private int cantMaxPorGuia;
        private int idTarifa;
        private int idExposicion;
        private int idEmpleado;

        public int idSedeEmp
        {
            get => idSede;
            set => idSede = value;
        }
        public string nombreSede
        {
            get => nombre;
            set => nombre = value;
        }
        public string descSede
        {
            get => descripcion;
            set => descripcion = value;
        }
        public int cantMaxVisi
        {
            get => cantMaxVisitantes;
            set => cantMaxVisitantes = value;
        }
        public int cantPorGuia
        {
            get => cantMaxPorGuia;
            set => cantMaxPorGuia = value;
        }
        public int idTarifaExp
        {
            get => idTarifa;
            set => idTarifa = value;
        }
        public int idExp
        {
            get => idExposicion;
            set => idExposicion = value;
        }
        public int idEmple
        {
            get => idEmpleado;
            set => idEmpleado = value;
        }

        public static DataTable obtenerTarifasVigentes(int id_usu)
        {
            //Patron Experto en informacion, vamos a Clase Tarifa prarmetro:idTarifa
            try
            {                 
                DataTable grilla = Tarifa.mostrarMontosVigentes(id_usu);

                return grilla;
            }
            catch
            {
                throw;
            }


        }

        public static string calcularDuracionExposicionVigente() 
        {
            //Patron experto en informacion Exposicion 
            var lista = Exposicion.esVigente();
            string total = Exposicion.calcularDuracionObrasExpuestas(lista);
            return total;
        }

        public static int mostrarCantidadMaximaVisitantes()
        {
            String cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaDB"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            Sede u = new Sede();
            try
            {
                SqlCommand comando = new SqlCommand();
                String consulta = "select cantMaxVisitantes from Sede where idSede = 1";
                //comando.Parameters.AddWithValue("@idUsuario, ");
                comando.CommandType = CommandType.Text;
                comando.CommandText = consulta;
                cn.Open();
                comando.Connection = cn;
                SqlDataReader dr = comando.ExecuteReader();
                if (dr != null & dr.Read())
                {
                    u.cantMaxVisitantes = int.Parse(dr["cantMaxVisitantes"].ToString());

                }

                int cantidadVisitantes = u.cantMaxVisitantes;
                return cantidadVisitantes;

            }
            catch
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PpaiImplementacion.IU.Entidades
{
    public class Entrada
    {
        public Entrada()
        {

        }

        private int idEntrada;
        private string fechaVenta;
        private string horaVenta;
        private int monto;
        private int idSede;
        private int idTarifa;

        public int idEntra { get => idEntrada; set => idEntrada = value; }
        public string fechaVentaEnt{ get => fechaVenta; set => fechaVenta = value; }
        public string horaVentaEnt { get => horaVenta; set => horaVenta = value; }
        public int montoEnt { get => monto; set => monto = value; }
        public int idSedeEnt { get => idSede; set => idSede = value; }
        public int idTarifaEnt { get => idTarifa; set => idTarifa = value; }


        public static int sonDeFechaHoraEnSede() 
        {
            List<Entrada> listaEntra = new List<Entrada>();
            String cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaDB"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand comando = new SqlCommand();
                String consulta = "select * from Entrada where idSede = 1 AND fechaVenta = CONVERT(DATE, GETDATE())";
                //comando.Parameters.AddWithValue("@idUsuario, ");
                comando.CommandType = CommandType.Text;
                comando.CommandText = consulta;
                cn.Open();
                comando.Connection = cn;
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    Entrada entra = new Entrada();
                    entra.idEntrada = int.Parse(dr["idEntrada"].ToString());
                    listaEntra.Add(entra);
                }
                int visitantes = listaEntra.Count();
 
                return visitantes;

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

        public static int getNro() 
        {
            Entrada entra = new Entrada();
            String cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaDB"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {

                SqlCommand comando = new SqlCommand();
                String consulta = "select Max(idEntrada) as idEntra from Entrada";
                //comando.Parameters.AddWithValue("@idDetalle", item);
                comando.CommandType = CommandType.Text;
                comando.CommandText = consulta;
                cn.Open();
                comando.Connection = cn;
                SqlDataReader dr = comando.ExecuteReader();
                if (dr != null & dr.Read())
                {
                    entra.idEntrada = int.Parse(dr["idEntra"].ToString());

                }
                int ultimo = entra.idEntrada;

                return ultimo;

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

        //Patron Creador, Crea nuevos objetos de la Clase entrada
        public static int nuevaEntrada(int ultimo, int entradas, string fechaVta, string horaVta, int monto, int idSede, int idTarifa) 
        {
            for (int i = ultimo + 1; i <= ultimo + entradas; i++)
            {
                String cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaDB"];
                SqlConnection cn = new SqlConnection(cadenaConexion);
                try
                {
                    SqlCommand comando = new SqlCommand();
                    String consulta = "INSERT INTO Entrada(idEntrada,fechaVenta,horaVenta,monto,idSede,idTarifa) VALUES(@idEntrada, @fechaVenta, @horaVenta, @monto, @idSede, @idTarifa)";
                    comando.Parameters.Clear();
                    comando.Parameters.AddWithValue("@idEntrada", i);
                    comando.Parameters.AddWithValue("@fechaVenta", fechaVta);
                    comando.Parameters.AddWithValue("@horaVenta", horaVta);
                    comando.Parameters.AddWithValue("@monto", monto);
                    comando.Parameters.AddWithValue("@idSede", idSede);
                    comando.Parameters.AddWithValue("@idTarifa", idTarifa);
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = consulta;
                    cn.Open();
                    comando.Connection = cn;
                    comando.ExecuteNonQuery();


                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    cn.Close();
                }
            }

            return 1;
        }
    }
}

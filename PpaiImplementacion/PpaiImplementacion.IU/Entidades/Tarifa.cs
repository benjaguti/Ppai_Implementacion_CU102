using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PpaiImplementacion.IU.Entidades
{
    public class Tarifa
    {
        public Tarifa() 
        {

        }

        private int idTarifa;
        private string fechaFinVigencia;
        private string fechaInicioVigencia;
        private int monto;
        private int montoAdicionalGuia;
        private int idTipoVisita;
        private int idTipoEntrada;

        public int idTarifas 
        {
            get => idTarifa;
            set => idTarifa = value;
        }

        public string fechaFinVig
        {
            get => fechaFinVigencia;
            set => fechaFinVigencia = value;
        }

        public string fechaIniVig
        {
            get => fechaInicioVigencia;
            set => fechaInicioVigencia = value;
        }

        public int montoTarifa
        {
            get => monto;
            set => monto = value;
        }

        public int montoAdiGuia
        {
            get => montoAdicionalGuia;
            set => montoAdicionalGuia = value;
        }

        public int idTipoVisi
        {
            get => idTipoVisita;
            set => idTipoVisita = value;
        }

        public int idTipoEntra
        {
            get => idTipoEntrada;
            set => idTipoEntrada = value;
        }


        // con este metodo creo que no haria falta el de arriba y los dos metodos  que acceden a las
        // tablas tipos de entrada y tipo de visita.....
        public static DataTable mostrarMontosVigentes(int id_usu)
        {
            String cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaDB"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand comando = new SqlCommand();
                String consulta = "select t.idTarifa, t.fechaFinVigencia, t.monto, te.nombre, tv.nombre from Tarifa t, TipoDeEntrada te, TipoVisita tv where t.idTipoEntrada = te.idTipoEntrada AND t.idTipoVisita = tv.idTipoVisita AND t.fechaFinVigencia > getdate()";
                comando.Parameters.AddWithValue("@idSede", id_usu.ToString());
                comando.CommandType = CommandType.Text;
                comando.CommandText = consulta;
                cn.Open();
                comando.Connection = cn;
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                da.Fill(tabla);
                return tabla;

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
        public static Tarifa ObtenerDatosParaMonto(string Nro)
        {
            String cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaDB"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            Tarifa te = new Tarifa();
            try
            {
                SqlCommand comando = new SqlCommand();
                String consulta = "SELECT * FROM Tarifa where idTarifa like @Nro";
                comando.Parameters.AddWithValue("@Nro", Nro);
                comando.CommandType = CommandType.Text;
                comando.CommandText = consulta;
                cn.Open();
                comando.Connection = cn;
                SqlDataReader dr = comando.ExecuteReader();

                if (dr != null & dr.Read())
                {
                    te.idTarifa = int.Parse(dr["idTarifa"].ToString()); 
                    te.fechaFinVigencia = dr["fechaFinVigencia"].ToString();
                    te.fechaInicioVigencia = dr["fechaInicioVigencia"].ToString();
                    te.monto = int.Parse(dr["monto"].ToString());
                    te.montoAdicionalGuia = int.Parse(dr["montoAdicionalGuia"].ToString()); 
                    te.idTipoVisita = int.Parse(dr["idTipoVisita"].ToString()); 
                    te.idTipoEntrada= int.Parse(dr["idTipoEntrada"].ToString()); 
                }

                return te;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }

            return te;
        }
    }
}

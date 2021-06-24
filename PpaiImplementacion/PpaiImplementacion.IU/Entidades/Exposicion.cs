using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PpaiImplementacion.IU.Entidades
{
    public class Exposicion
    {
        public Exposicion() 
        {

        }

        private int idExposicion;
        private string nombreExp;
        private string fechaInicio;
        private string fechaFin;
        private string fechaInicioReplanificada;
        private string fechaFinReplanificada;
        private string horaApertura;
        private string horaCierre;
        private int idEmple;
        private int idDetalle;

        public int idExp
        {
            get => idExposicion;
            set => idExposicion = value;
        }
        public string fechaIniExposicion
        {
            get => fechaInicio;
            set => fechaInicio = value;
        }

        public string fechaFinExposicion
        {
            get => fechaFin;
            set => fechaFin = value;
        }
        public string fechaIniRepla
        {
            get => fechaInicioReplanificada;
            set => fechaInicioReplanificada = value;
        }
        public string fechaFinRepla
        {
            get => fechaFinReplanificada;
            set => fechaFinReplanificada = value;
        }
        public string horaIni
        {
            get => horaApertura;
            set => horaApertura = value;
        }
        public string horaFin
        {
            get => horaCierre;
            set => horaCierre = value;
        }

        public int idEmpleado
        {
            get => idEmple;
            set => idEmple = value;
        }
        public int idDetalleExpo
        {
            get => idDetalle;
            set => idDetalle = value;
        }


        public static List<Exposicion > esVigente() 
        {
            List<Exposicion> Lista = new List<Exposicion>();
            String cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaDB"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            
            try
            {
                 SqlCommand comando = new SqlCommand();
                //Modificar consulta a solo Fecha
                 String consulta = "select * from Exposicion where fechaFin > getdate();";
                // comando.Parameters.AddWithValue("@Nro", Nro);
                 comando.CommandType = CommandType.Text;
                 comando.CommandText = consulta;
                 cn.Open();
                 comando.Connection = cn;
                 SqlDataReader dr = comando.ExecuteReader();
                 while(dr.Read())
                 {
                    Exposicion te = new Exposicion();
                    te.idExposicion= int.Parse(dr["idExposicion"].ToString()); ;
                    te.nombreExp = dr["nombre"].ToString();
                    te.fechaInicio = dr["fechaInicio"].ToString();
                    te.fechaFin = dr["fechaFin"].ToString();
                    te.fechaInicioReplanificada = dr["fechaInicioReplanificada"].ToString();
                    te.fechaFinReplanificada = dr["fechaFinReplanificada"].ToString();
                    te.horaApertura = dr["horaApertura"].ToString();
                    te.horaCierre = dr["horaCierre"].ToString();
                    te.idEmple = int.Parse(dr["idEmpleado"].ToString());
                    te.idDetalle = int.Parse(dr["idDetalleExposicion"].ToString());
                    Lista.Add(te);
                 }

                 return Lista;

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

        public static string calcularDuracionObrasExpuestas(List<Exposicion> lista) 
        {
            //Paso por parametro la lista
            List<int> detalles = new List<int>();
            foreach (var item in lista)
            {
                detalles.Add(item.idDetalleExpo);
            }
            string total = DetalleExposicion.buscarDuracionObra(detalles);
            return total;
        }

    }
}

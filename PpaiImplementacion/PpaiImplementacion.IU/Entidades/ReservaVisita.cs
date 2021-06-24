using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PpaiImplementacion.IU.Entidades
{
    public class ReservaVisita
    {
        public ReservaVisita() 
        {

        }

        private int idReservaVisita;
        private int cantAlumnos;
        private int cantAlumnosConfirmada;
        private int duracionEstimada;
        private int fechaHoraCreacion;
        private int fechaHoraReserva;
        private int horaFinReal;
        private int horaInicioReal;
        private int idSede;
        private int idEmpleado;

        public int idReserva { get => idReservaVisita; set => idReservaVisita = value; }
        public int cantAlumno { get => cantAlumnos; set => cantAlumnos = value; }
        public int cantAlumnoConfirmada { get => cantAlumnosConfirmada; set => cantAlumnosConfirmada = value; }
        public int duracionEst { get => duracionEstimada; set => duracionEstimada = value; }
        public int fechaHoraCrea { get => fechaHoraCreacion; set => fechaHoraCreacion = value; }
        public int fechaHoraReser { get => fechaHoraReserva; set => fechaHoraReserva = value; }
        public int horaFinTrue { get => horaFinReal; set => horaFinReal = value; }

        public int horaInicioTrue { get => horaInicioReal; set => horaInicioReal = value; }
        public int idSedee { get => idSede; set => idSede = value; }
        public int idEmpleadoo { get => idEmpleado; set => idEmpleado = value; }


        public static int sonParaHoraFechaYSede() 
        {
            List<ReservaVisita> listaEntra = new List<ReservaVisita>();
            String cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaDB"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand comando = new SqlCommand();
                String consulta = "select * from ReservaVisita where idSede = 1 AND fechaHoraReserva = CONVERT(DATE, GETDATE())";
                //comando.Parameters.AddWithValue("@idUsuario, ");
                comando.CommandType = CommandType.Text;
                comando.CommandText = consulta;
                cn.Open();
                comando.Connection = cn;
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    ReservaVisita reservaVisi = new ReservaVisita();
                    reservaVisi.idReservaVisita = int.Parse(dr["idReservaVisita"].ToString());
                    listaEntra.Add(reservaVisi);
                }
                int reservas = listaEntra.Count();

                return reservas;

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

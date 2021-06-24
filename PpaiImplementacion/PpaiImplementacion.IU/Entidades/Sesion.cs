using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PpaiImplementacion.IU.Entidades
{
    public class Sesion
    {
        public Sesion()
        {

        }

        private int idSesion;
        private string fechaInicio;
        private string fechaFin;
        private string horaInicio;
        private string horaFin;
        private int idUsuario;

        public int iDSesion
        {
            get => idSesion;
            set => idSesion = value;
        }

        public int iDUsu
        {
            get => idUsuario;
            set => idUsuario = value;
        }

        public string fechaIni
        {
            get => fechaInicio;
            set => fechaInicio = value;
        }

        public string fechaF
        {
            get => fechaFin;
            set => fechaFin = value;
        }

        public string horaIni
        {
            get => horaInicio;
            set => horaInicio = value;
        }

        public string horaF
        {
            get => horaFin;
            set => horaFin = value;
        }


        public static Usuario getEmpleadoEnSesion(int id_ses)
        {
            String cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaDB"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            Sesion u = new Sesion();
            try
            {

                SqlCommand comando = new SqlCommand();
                String consulta = "SELECT * FROM Sesion where idSesion like @idsesion";
                comando.Parameters.AddWithValue("@idsesion", id_ses);
                comando.CommandType = CommandType.Text;
                comando.CommandText = consulta;
                cn.Open();
                comando.Connection = cn;
                SqlDataReader dr = comando.ExecuteReader();
                if (dr != null & dr.Read())
                {
                    u.idSesion = int.Parse(dr["idSesion"].ToString());
                    u.horaFin = dr["horaFin"].ToString();
                    u.horaInicio = dr["horaInicio"].ToString();
                    u.fechaFin = dr["fechaFin"].ToString();
                    u.fechaInicio = dr["fechaInicio"].ToString(); ;
                    u.idUsuario = int.Parse(dr["idUsuario"].ToString()); ;
                }
                int usu = u.idUsuario;
                
                var emple = Usuario.obtenerEmpleado(usu);

                return emple;

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

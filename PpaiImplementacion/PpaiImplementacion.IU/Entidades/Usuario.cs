using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PpaiImplementacion.IU.Entidades
{
    public class Usuario
    {
        public Usuario()
        {

        }

        private int idUsuario;
        private string nombre;
        private string caducidad;
        private string contraseña;
        private int idEmpleado;

        public int idUsu
        {
            get => idUsuario;
            set => idUsuario = value;
        }

        public string nombreUsu
        {
            get => nombre;
            set => nombre = value;
        }


        public string caducida
        {
            get => caducidad;
            set => caducidad = value;
        }


        public string contra
        {
            get => contraseña;
            set => contraseña = value;
        }


        public int nombreEmpl
        {
            get => idEmpleado;
            set => idEmpleado = value;
        }

        public static Usuario obtenerEmpleado(int id_usu)
        {
            String cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaDB"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            Usuario u = new Usuario();
            try
            {

                SqlCommand comando = new SqlCommand();
                String consulta = "SELECT * FROM Usuario where idUsuario like @idUsuario";
                comando.Parameters.AddWithValue("@idUsuario", id_usu);
                comando.CommandType = CommandType.Text;
                comando.CommandText = consulta;
                cn.Open();
                comando.Connection = cn;
                SqlDataReader dr = comando.ExecuteReader();
                if (dr != null & dr.Read())
                {
                    u.idUsuario = int.Parse(dr["idUsuario"].ToString());
                    u.nombre = dr["nombre"].ToString();
                    u.caducidad = dr["caducidad"].ToString();
                    u.contraseña = dr["contraseña"].ToString();
                    u.idEmpleado = int.Parse(dr["idEmpleado"].ToString()); 
                }

                return u;

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

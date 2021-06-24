using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PpaiImplementacion.IU.Entidades
{
    public class Empleado
    {
        public Empleado() 
        {

        }

        private int idEmpleado;
        private int codigoValidacion;
        private string nombre;
        private string apellido;
        private string tipoDocumento;
        private int nroDocumento;
        private int cuit;
        private string calle;
        private int idBarrio;
        private string fechaIngreso;
        private string fechaNacimiento;
        private string email;
        private string sexo;
        private int telefono;

        public int idEmple 
        {
            get => idEmpleado;
            set => idEmpleado = value;
        }
        public int codVal
        {
            get => codigoValidacion;
            set => codigoValidacion = value;
        }
        public string nombreEmp
        {
            get => nombre;
            set => nombre = value;
        }
        public string apellidoEmp
        {
            get => apellido;
            set => apellido = value;
        }
        public string tipoDoc
        {
            get => tipoDocumento;
            set => tipoDocumento = value;
        }
        public int nroDoc
        {
            get => nroDocumento;
            set => nroDocumento = value;
        }
        public int cuitEmp
        {
            get => cuit;
            set => cuit = value;
        }
        public string calleEmp
        {
            get => calle;
            set => calle = value;
        }
        public int idBarrioEmp
        {
            get => idBarrio;
            set => idBarrio = value;
        }
        public string fechaIngresoEmp
        {
            get => fechaIngreso;
            set => fechaIngreso = value;
        }

        public string fechaNac
        {
            get => fechaNacimiento;
            set => fechaNacimiento = value;
        }
        public string mailEmp
        {
            get => email;
            set => email = value;
        }

        public string sexoEmp 
        {
            get => sexo;
            set => sexo = value;
        }


        public int telEmp 
        {
            get => telefono;
            set => telefono = value;

        }


        public static Sede obtenerSede(int id_usu)
        {
            String cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaDB"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            Sede u = new Sede();
            try
            {

                SqlCommand comando = new SqlCommand();
                String consulta = "SELECT * FROM Sede where idEmpleado like @idUsuario";
                comando.Parameters.AddWithValue("@idUsuario", id_usu);
                comando.CommandType = CommandType.Text;
                comando.CommandText = consulta;
                cn.Open();
                comando.Connection = cn;
                SqlDataReader dr = comando.ExecuteReader();
                if (dr != null & dr.Read())
                {
                    u.idSedeEmp= int.Parse(dr["idSede"].ToString());

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

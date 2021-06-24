using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PpaiImplementacion.IU.Entidades
{
    public class Obra
    {
        public Obra() 
        {

        }

        private int idObra;
        private int alto;
        private int ancho;
        private int codigoSensor;
        private string descripcion;
        private int duracionExtendida;
        private string duracionResumida;
        private int fechaCreacion;
        private int fechaPrimeroIngreso;
        private string nombreObra;
        private int peso;
        private int valuacion;
        private int idEmpleado;

        public int idObrra { get => idObra; set => idObra = value; }
        public int altura { get => alto; set => alto = value; }
        public int anchura { get => ancho; set => ancho = value; }
        public int codSensor { get => codigoSensor; set => codigoSensor = value; }
        public string descri { get => descripcion; set => descripcion = value; }
        public int duracionExt { get => duracionExtendida; set => duracionExtendida = value; }
        public string duracionResu { get => duracionResumida; set => duracionResumida = value; }
        public int fechaCrea { get => fechaCreacion; set => fechaCreacion = value; }
        public int fechaPrimeroI { get => fechaPrimeroIngreso; set => fechaPrimeroIngreso = value; }
        public string nombreOb { get => nombreObra; set => nombreObra = value; }
        public int pesoObra { get => peso; set => peso = value; }
        public int valuacionObra{ get => valuacion; set => valuacion = value; }
        public int idEmpleadoS { get => idEmpleado; set => idEmpleado = value; }



        public static string getDuracionResumida(List<int> lista)
        {
            List<Obra> detalle = new List<Obra>();
            List<TimeSpan> listaObras = new List<TimeSpan>();
            foreach (var item in lista)
            {
                Obra u = new Obra();
                String cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaDB"];
                SqlConnection cn = new SqlConnection(cadenaConexion);
                try
                {

                    SqlCommand comando = new SqlCommand();
                    String consulta = "SELECT * FROM Obra where idObra like @idDetalle";
                    comando.Parameters.AddWithValue("@idDetalle", item);
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = consulta;
                    cn.Open();
                    comando.Connection = cn;
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr != null & dr.Read())
                    {
                        u.idObra = int.Parse(dr["idObra"].ToString());

                        u.duracionResumida = dr["duracionResumida"].ToString();

                    }
                    detalle.Add(u);


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

            foreach (var it in detalle)
            {
                listaObras.Add(TimeSpan.Parse(it.duracionResumida));
            }


            TimeSpan suma = TimeSpan.Parse("00:00:00");

            // SE usa esto para calcular la duracion resumida
            foreach (var item in listaObras)
            {
                suma = suma + item;
            }

            return suma.ToString();
        }
    }
}

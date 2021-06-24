using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PpaiImplementacion.IU.Entidades
{
    public class DetalleExposicion
    {
        public DetalleExposicion() 
        {

        }

        private int idDetalleExposicion;
        private string lugarAsignado;
        private int idObra;

        public int idDetExp 
        {
            get => idDetalleExposicion;
            set => idDetalleExposicion = value;
        }

        public string lugar 
        {
            get => lugarAsignado;
            set => lugarAsignado = value;
        }
        public int idObras
        {
            get => idObra;
            set => idObra = value;
        }

        //Se debe verificar si la lista compila con la consulta o hacer una consulta directa.
        public static string buscarDuracionObra(List<int> lista) 
        {
            List<DetalleExposicion> detalle = new List<DetalleExposicion>();
            List<int> listaObras = new List<int>();
            foreach (var item in lista)
            {
                DetalleExposicion u = new DetalleExposicion();
                String cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaDB"];
                SqlConnection cn = new SqlConnection(cadenaConexion);
                try
                {

                    SqlCommand comando = new SqlCommand();
                    String consulta = "SELECT * FROM DetalleExposicion where idDetalleExposicion like @idDetalle";
                    comando.Parameters.AddWithValue("@idDetalle", item);
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = consulta;
                    cn.Open();
                    comando.Connection = cn;
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr != null & dr.Read())
                    {
                        u.idDetalleExposicion = int.Parse(dr["idDetalleExposicion"].ToString());
                        u.lugarAsignado = dr["lugarAsignado"].ToString();
                        u.idObra = int.Parse(dr["idObra"].ToString());
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
                listaObras.Add(it.idObra);
            }

            string total = Obra.getDuracionResumida(listaObras);

            return total;


        }

    }
}

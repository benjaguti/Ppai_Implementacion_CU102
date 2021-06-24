using PpaiImplementacion.IU.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PpaiImplementacion.IU.Logica
{
    public class GestorVentasEntradas
    {
        // Se llama al siguiente metodo, que debe devolver una tabla

        //disparador de otro metodo
        public static DataTable opcionVentaEntradas() 
        {
            DataTable grilla = buscarEmpleadoLogueado();
            return grilla;
        }

        public static DataTable buscarEmpleadoLogueado()
        {
            //busca el emplado Logueado, Metodo ubicado en Sesion.
            var emple = Sesion.getEmpleadoEnSesion(1);
            int i = emple.nombreEmpl;
            DataTable grilla = buscarSede(i);
            return grilla;
        }

        public static DataTable buscarSede(int idEmple) 
        {
            // se busca la sede por medio del id del empleado
            var sede = Empleado.obtenerSede(idEmple);
            int idSed = sede.idSedeEmp;
            DataTable grilla = buscarTarifaSede(idSed);
            return grilla;
        }

        public static DataTable buscarTarifaSede(int idSede) 
        {
            DataTable grilla = Sede.obtenerTarifasVigentes(idSede);

            return grilla;
        }

        public static string buscarExposicionVigente() 
        {
            string total = Sede.calcularDuracionExposicionVigente();
            return total;
        }

        public static int cantidadEntradasAEmitir(int entradas) 
        {
            //Este metodo sigue
            int capacidad = buscarCapacidadSede();
            //Este añadido para el disparador
            int ocupado = validarLimitesVisitantes();
            int total = capacidad - ocupado;
            if (total >= entradas)
            {
                return ocupado + entradas;
            }
            else
            {
                return -1;
            }
        }

        public static int buscarCapacidadSede() 
        {
            int t = Sede.mostrarCantidadMaximaVisitantes();

            return t;
            
        }
        public static DateTime obtenerFechaHoraActual() 
        {
            DateTime today = DateTime.Today;
            return today;
        }
        //Busca los asistentes validando el dia y hora
        public static int buscarVisitanteEnSede() 
        {
            int visitantes = Entrada.sonDeFechaHoraEnSede();
            return visitantes;
        }

        //Busca Reservas que son para esa Fecha y hora
        public static int buscarReservaParaAsistir() 
        {
            int reservaciones = ReservaVisita.sonParaHoraFechaYSede();
            return reservaciones;
        }


        public static int validarLimitesVisitantes() 
        {
            int visi = buscarVisitanteEnSede();
            int reser = buscarReservaParaAsistir();

            int cantidadAtual = visi + reser;
            return cantidadAtual;

        }

        public static int calcularTotalVenta(int entradas, int precio) 
        {
            int total = entradas * precio;
            return total;
        }

        public static int tomarConfirmacionVenta(int entradas, string fechaVta, string horaVta, int monto, int idSede, int idTarifa) 
        {
            int ultimo = buscarUltimoNroEntrada();
            int devuelve = generarEntrada(ultimo,entradas,fechaVta,horaVta,monto, idSede,idTarifa);
            return devuelve;
        }

        public static int buscarUltimoNroEntrada() 
        {
            int ultimo = Entrada.getNro();
            return ultimo;
        }

        public static int generarEntrada(int ultimo,int entradas, string fechaVta, string horaVta, int monto, int idSede, int idTarifa) 
        {
            //El metodo New
            int devuelve = Entrada.nuevaEntrada(ultimo,entradas,fechaVta,horaVta,monto,idSede,idTarifa);
            return devuelve;
        }

        public void imprimirEntradas() 
        {

        }
        
        public static string actualizarVisitantesEnPantallas() 
        {
            string actualizar = validarLimitesVisitantes().ToString();
            return actualizar;
        }
       
    }
}

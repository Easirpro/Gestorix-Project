using CapaDatos.NegocioDatos;
using CapaEntidades.NegocioEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica.NegocioLogica
{
    public class ClsCajaLogica
    {
        // El kiosco trabaja con una sola caja ("Caja 1", IdCaja = 1).
        public const int ID_CAJA_PRINCIPAL = 1;

        private ClsCajaDatos datos = new ClsCajaDatos();

        public ClsSesionCajaEntidad ObtenerSesionAbierta()
        {
            return datos.ObtenerSesionAbierta(ID_CAJA_PRINCIPAL);
        }

        public bool HayCajaAbierta()
        {
            return datos.ObtenerSesionAbierta(ID_CAJA_PRINCIPAL) != null;
        }

        public int AbrirCaja(int idUsuario, decimal montoInicial)
        {
            return datos.AbrirCaja(ID_CAJA_PRINCIPAL, idUsuario, montoInicial);
        }

        public DataTable ObtenerConceptos(string tipo)
        {
            return datos.ObtenerConceptos(tipo);
        }

        public int RegistrarMovimiento(ClsMovimientoCajaEntidad movimiento)
        {
            return datos.RegistrarMovimiento(movimiento);
        }

        public void AnularMovimiento(int idMovimientoCaja, string motivo, int idUsuario)
        {
            datos.AnularMovimiento(idMovimientoCaja, motivo, idUsuario);
        }

        public ClsCierreCajaEntidad CerrarCaja(ClsCierreCajaEntidad cierre)
        {
            return datos.CerrarCaja(cierre);
        }

        public DataTable ObtenerMovimientosSesion(int idSesionCaja)
        {
            return datos.ObtenerMovimientosSesion(idSesionCaja);
        }

        public DataTable ObtenerSesiones(DateTime desde, DateTime hasta)
        {
            return datos.ObtenerSesiones(desde, hasta);
        }

        public DataTable ObtenerEmpleadosActivos()
        {
            return datos.ObtenerEmpleadosActivos();
        }

        public DataTable ObtenerMetodosPago()
        {
            return datos.ObtenerMetodosPago();
        }
    }
}

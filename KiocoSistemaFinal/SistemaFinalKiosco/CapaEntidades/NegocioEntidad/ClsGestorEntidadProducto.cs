using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.NegocioEntidad
{
    public class ClsGestorEntidadProducto
    {
        public class ClsCategoria
        {
            public int IdCategoria { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public bool Activo { get; set; }

        }
        public class ClsIVA
        {
            public int IdIVA { get; set; }
            public string Descripcion { get; set; }
            public decimal Alicuota { get; set; }
            public bool Activo { get; set; }
        }
        public class ClsLote
        {
            public int IdLote { get; set; }
            public int IdProducto { get; set; }
            public string CodigoLote { get; set; }
            public DateTime FechaFabricacion { get; set; }
            public DateTime FechaVencimiento { get; set; }
            public DateTime FechaIngreso { get; set; }
            public decimal Stock { get; set; }
            public bool Activo { get; set; }
            public int IdSucursal { get; set; }
            // Días antes del vencimiento en que avisa la alerta (null: avisa el día que vence).
            public int? DiasAlertaVencimiento { get; set; }

        }
        public class ClsMarca
            {
                public int IdMarca { get; set; }
                public string Nombre { get; set; }
                public bool Activo { get; set; }

            }
        public class ClsProducto
        {
            public int IdProducto { get; set; }
            public string CodigoBarra { get; set; }
            public string SKU { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public int IdMarca { get; set; }
            public int IdCategoria { get; set; }
            public int IdUnidad { get; set; }
            public int IdIVA { get; set; }
            public decimal PrecioVenta { get; set; }
            public bool Activo { get; set; }

        }
        public class ClsStock
        {
            public int IdStock { get; set; }
            public int IdProducto { get; set; }
            public decimal CantidadActual { get; set; }
            public decimal StockMinimo { get; set; }
            public decimal StockIdeal { get; set; }


        }
        public class ClsUnidad
        {
            public int IdUnidad { get; set; }
            public string Nombre { get; set; }
            public string Simbolo { get; set; }
            public string Categoria { get; set; }
        }
        public class ClsProveedor
        {
            public int IdProveedor { get; set; }
            public string Nombre { get; set; }
            public string CUIT { get; set; }
            public bool Activo { get; set; }

        }
        public class ClsSucursalProveedor
        {
            public int IdSucursal { get; set; }
            public int IdProveedor { get; set; }
            public string Nombre { get; set; }
            public bool Activo { get; set; }
            public int IdDireccion { get; set; }
            public string CondicionIVA { get; set; }
            public string Observacion { get; set; }
        }
        public class ClsProductoSucursalProveedor
        {
            public int IdProducto { get; set; }
            public int IdSucursal { get; set; }
            public decimal? PrecioCompra { get; set; }
            public DateTime? FechaPrecioCompra { get; set; }
            public string CodigoProveedor { get; set; }
            public bool Activo { get; set; }
        }
        public class ClsDireccion 
        { 
            public int IdDireccion { get; set; } 
            public string Calle { get; set; } 
            public int? Altura { get; set; } 
            public string Piso { get; set; } 
            public string Departamento { get; set; } 
            public int IdLocalidad { get; set; } }
        public class ClsTelefono 
        { 
            public int IdTelefono { get; set; } 
            public string NumTelefono { get; set; } 
            public int IdTipo { get; set; } }
        public class ClsSucursalProveedorTelefono 
        { 
            public int IdSucursal { get; set; } 
            public int IdTelefono { get; set; } 
            public bool Activo { get; set; } 
            public string NombreTelefono { get; set; } 
            public string DescripcionTelefono { get; set; }
        }
        public class ClsCorreo
        {
            public int IdCorreo { get; set; }
            public string Correo { get; set; }
        }
        public class ClsImportacionProveedorCosto
        {
            public string CodigoBarra { get; set; }
            public string Proveedor { get; set; }
            public string Sucursal { get; set; }
            public decimal PrecioCompra { get; set; }
        }

        public class ClsResultadoImportacion
        {
            public bool Exito { get; set; }
            public bool Advertencia { get; set; }
            public string Titulo { get; set; }
            public string Mensaje { get; set; }
            public int CantidadArticulos { get; set; }
            public int CantidadRelaciones { get; set; }

        public static ClsResultadoImportacion Exitoso(string mensaje, int cantidadArticulos, int cantidadRelaciones)
        {
        return new ClsResultadoImportacion
        {
            Exito = true,
            Titulo = "Importación de artículos",
            Mensaje = mensaje,
            CantidadArticulos = cantidadArticulos,
            CantidadRelaciones = cantidadRelaciones
            };
        }

        public static ClsResultadoImportacion Error(string mensaje, string titulo = "Importación de artículos")
        {
            return new ClsResultadoImportacion
            {
            Exito = false,
            Titulo = titulo,
            Mensaje = mensaje
            };
            }

        public static ClsResultadoImportacion AdvertenciaResultado(string mensaje, string titulo = "Importación de artículos")
        {
            return new ClsResultadoImportacion
            {
                Exito = false,
                Advertencia = true,
                Titulo = titulo,
                Mensaje = mensaje
            };
        }
        }

        public class ClsSucursalProveedorCorreo 
        {
            public int IdCorreo { get; set; } 
            public int IdSucursal { get; set; } 
            public bool Activo { get; set; } 
            public string TipoCorreo { get; set; } 
            public string DescripcionCorreo { get; set; } 
        }






    }
}

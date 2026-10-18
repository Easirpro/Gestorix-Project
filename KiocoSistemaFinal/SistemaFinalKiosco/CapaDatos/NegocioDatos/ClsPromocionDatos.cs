using CapaEntidades;
using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System.Collections.Generic;
using System.Data;

namespace CapaDatos.NegocioDatos
{
    public class ClsPromocionDatos
    {
        private Conexion cn = new Conexion();

        public DataTable BuscarProductos(string texto)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_BuscarProductosPromocion", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Texto", SqlDbType.NVarChar, 200).Value = texto ?? string.Empty;

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
        }
        public DataTable ObtenerTiposPromocion()
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(
                    @"SELECT
                        IdTipoPromocion,
                        Nombre,
                        Descripcion,
                        CantidadLleva,
                        CantidadPaga
                    FROM dbo.TipoPromocion
                    ORDER BY IdTipoPromocion", conexion))
                {
                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
        }
        public int GuardarPromocion(ClsPromocion promocion, List<ClsDetallePromocion> detalles, out string codigoPromocion)
        {
            codigoPromocion = string.Empty;

            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                conexion.Open();

                using (SqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        int idPromocion;

                        using (SqlCommand cmd = new SqlCommand("sp_GuardarPromocion", conexion, transaccion))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = promocion.Nombre;
                            cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 255).Value = string.IsNullOrWhiteSpace(promocion.Descripcion) ? DBNull.Value : promocion.Descripcion;
                            cmd.Parameters.Add("@IdTipoPromocion", SqlDbType.Int).Value = promocion.IdTipoPromocion;
                            cmd.Parameters.Add("@Valor", SqlDbType.Decimal).Value = promocion.Valor;
                            cmd.Parameters["@Valor"].Precision = 18;
                            cmd.Parameters["@Valor"].Scale = 2;
                            cmd.Parameters.Add("@FechaInicio", SqlDbType.DateTime2).Value = promocion.FechaInicio;
                            cmd.Parameters.Add("@FechaFin", SqlDbType.DateTime2).Value = promocion.FechaFin.HasValue ? promocion.FechaFin.Value : DBNull.Value;
                            cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = promocion.Activo;

                            SqlParameter parametroId = cmd.Parameters.Add("@IdPromocion", SqlDbType.Int);

                            parametroId.Direction = ParameterDirection.Output;

                            SqlParameter parametroCodigo = cmd.Parameters.Add("@CodigoPromocion", SqlDbType.NVarChar, 20);

                            parametroCodigo.Direction = ParameterDirection.Output;

                            cmd.ExecuteNonQuery();

                            idPromocion = Convert.ToInt32(parametroId.Value);

                            codigoPromocion = Convert.ToString(parametroCodigo.Value);
                        }

                        foreach (ClsDetallePromocion detalle in detalles)
                        {
                            using (SqlCommand cmd = new SqlCommand("sp_GuardarDetallePromocion", conexion, transaccion))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@IdPromocion", SqlDbType.Int).Value = idPromocion;
                                cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = detalle.IdProducto;

                                SqlParameter cantidad = cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal);

                                cantidad.Precision = 18;
                                cantidad.Scale = 2;
                                cantidad.Value = detalle.Cantidad;

                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaccion.Commit();

                        return idPromocion;
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            if (conexion.State == System.Data.ConnectionState.Open)
                            {
                                transaccion.Rollback();
                            }
                        }
                        catch (Exception exRollback)
                        {
                            throw new Exception("Error original al guardar la promoción: " + ex.Message +
                                " | Error al revertir la transacción: " + exRollback.Message, ex);
                        }

                        throw new Exception("Error original al guardar la promoción: " + ex.Message,ex);
                    }
                }
            }
        }
        public DataTable BuscarPromociones(string texto)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_BuscarPromociones", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Texto", SqlDbType.NVarChar, 200).Value = texto ?? string.Empty;

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
        }
        public DataSet ObtenerPromocionPorId(int idPromocion)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ObtenerPromocionPorId", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@IdPromocion", SqlDbType.Int).Value = idPromocion;

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    DataSet datosPromocion = new DataSet();

                    adaptador.Fill(datosPromocion);

                    return datosPromocion;
                }
            }
        }
        public void EliminarPromocion(int idPromocion)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_EliminarPromocion", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@IdPromocion", SqlDbType.Int).Value = idPromocion;

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void ModificarPromocion(ClsPromocion promocion, List<ClsDetallePromocion> detalles)
        {
            if (promocion == null)
                throw new Exception("La promoción no contiene datos.");

            if (detalles == null || detalles.Count == 0)
                throw new Exception("Debe agregar al menos un artículo a la promoción.");

            foreach (ClsDetallePromocion detalle in detalles)
            {
                if (detalle == null || detalle.IdProducto <= 0)
                    throw new Exception("Hay un artículo inválido en la promoción.");

                if (detalle.Cantidad <= 0)
                    throw new Exception("La cantidad de cada artículo debe ser mayor que cero.");
            }

            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                conexion.Open();

                using (SqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_ModificarPromocion", conexion, transaccion))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@IdPromocion", SqlDbType.Int).Value = promocion.IdPromocion;
                            cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = promocion.Nombre;
                            cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 255).Value = string.IsNullOrWhiteSpace(promocion.Descripcion) ? (object)DBNull.Value : promocion.Descripcion;
                            cmd.Parameters.Add("@IdTipoPromocion", SqlDbType.Int).Value = promocion.IdTipoPromocion;

                            SqlParameter parametroValor = cmd.Parameters.Add("@Valor", SqlDbType.Decimal);

                            parametroValor.Precision = 18;
                            parametroValor.Scale = 2;
                            parametroValor.Value = promocion.Valor;

                            cmd.Parameters.Add("@FechaInicio", SqlDbType.DateTime2).Value = promocion.FechaInicio;
                            cmd.Parameters.Add("@FechaFin", SqlDbType.DateTime2).Value = promocion.FechaFin.HasValue ? (object)promocion.FechaFin.Value : DBNull.Value;
                            cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = promocion.Activo;

                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand cmd = new SqlCommand(@"DELETE FROM dbo.DetallePromocion WHERE IdPromocion = @IdPromocion", conexion, transaccion))
                        {
                            cmd.Parameters.Add("@IdPromocion", SqlDbType.Int).Value = promocion.IdPromocion;

                            cmd.ExecuteNonQuery();
                        }

                        foreach (ClsDetallePromocion detalle in detalles)
                        {
                            using (SqlCommand cmd = new SqlCommand("sp_GuardarDetallePromocion", conexion, transaccion))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@IdPromocion", SqlDbType.Int).Value = promocion.IdPromocion;
                                cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = detalle.IdProducto;

                                SqlParameter parametroCantidad = cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal);

                                parametroCantidad.Precision = 18;
                                parametroCantidad.Scale = 2;
                                parametroCantidad.Value = detalle.Cantidad;

                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            transaccion.Rollback();
                        }
                        catch (Exception exRollback)
                        {
                            throw new AggregateException("Ocurrió un error al modificar la promoción y también al revertir la transacción.", ex, exRollback);
                        }

                        throw new Exception("No se pudo modificar la promoción: " + ex.Message, ex);
                    }
                }
            }
        }
        public void CambiarEstadoPromocion(int idPromocion, bool activo)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(
                @"UPDATE dbo.Promocion
                SET Activo = @Activo
                WHERE IdPromocion = @IdPromocion", conexion))
            {
                cmd.Parameters.Add("@IdPromocion", SqlDbType.Int).Value = idPromocion;
                cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = activo;

                conexion.Open();

                int filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas == 0)
                    throw new Exception("No se encontró la promoción para cambiar su estado.");
            }
        }
        public int AgregarMecanicaVolumen(string nombre, int lleva, int paga)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_AgregarMecanicaVolumen", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 60).Value = nombre;
                cmd.Parameters.Add("@CantidadLleva", SqlDbType.Int).Value = lleva;
                cmd.Parameters.Add("@CantidadPaga", SqlDbType.Int).Value = paga;

                SqlParameter parametroId = cmd.Parameters.Add("@IdTipoPromocion", SqlDbType.Int);

                parametroId.Direction = ParameterDirection.Output;

                conexion.Open();
                cmd.ExecuteNonQuery();

                return Convert.ToInt32(parametroId.Value);
            }
        }




    }
}
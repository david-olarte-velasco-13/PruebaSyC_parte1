using pruebaparte1.Models;
using System.Data.SqlClient;
using System.Data;

namespace pruebaparte1.Datos
{
    public class FacturaDatos
    {

        public List<FacturaModel> Listar() {

            var oLista = new List<FacturaModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL())) {

                conexion.Open();

                SqlCommand cmd = new SqlCommand("Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader()) {

                    while (dr.Read()) {
                        oLista.Add(new FacturaModel() { 
                            Idcliente = Convert.ToInt32(dr["Idcliente"]),
                            Nombre = dr["Nombre"].ToString(),
                            Documento = Convert.ToInt32(dr["Documento"]),
                            Valor_factura = Convert.ToInt32(dr["Valor_factura"]),
                            Fecha_factura = Convert.ToDateTime(dr["Fecha_factura"]),
                            Estado_Factura = Convert.ToInt32(dr["Estado_factura"]),
                            Descripcion = dr["Descripcion"].ToString()
                        });
                    }
                }
            }

            return oLista;
        }

        public FacturaModel Obtener(int Idcliente)
        {

            var oFactura = new FacturaModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {

                conexion.Open();

                SqlCommand cmd = new SqlCommand("Obtener", conexion);
                cmd.Parameters.AddWithValue("Idcliente", Idcliente);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {

                        oFactura.Idcliente = Convert.ToInt32(dr["Idcliente"]);
                        oFactura.Nombre = dr["Nombre"].ToString();
                        oFactura.Documento = Convert.ToInt32(dr["Documento"]);
                        oFactura.Valor_factura = Convert.ToInt32(dr["Valor_factura"]);
                        oFactura.Fecha_factura = Convert.ToDateTime(dr["Fecha_factura"]);
                        oFactura.Estado_Factura = Convert.ToInt32(dr["Estado_factura"]);
                        oFactura.Descripcion = dr["Descripcion"].ToString();
                        
                    }
                }
            }

            return oFactura;
        }

        public bool Guardar(FacturaModel ofactura) {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {

                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", ofactura.Nombre);
                    cmd.Parameters.AddWithValue("Documento", ofactura.Documento);
                    cmd.Parameters.AddWithValue("Fecha_factura", ofactura.Fecha_factura);
                    cmd.Parameters.AddWithValue("Valor_factura", ofactura.Valor_factura);
                    cmd.Parameters.AddWithValue("Estado_factura", ofactura.Estado_Factura);
                    cmd.Parameters.AddWithValue("Descripcion", ofactura.Descripcion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;

            }

            return rpta;
        }

        public bool Editar(FacturaModel ofactura)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {

                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("Editar", conexion);
                    cmd.Parameters.AddWithValue("Idcliente", ofactura.Idcliente);
                    cmd.Parameters.AddWithValue("Nombre", ofactura.Nombre);
                    cmd.Parameters.AddWithValue("Documento", ofactura.Documento);
                    cmd.Parameters.AddWithValue("Fecha_factura", ofactura.Fecha_factura);
                    cmd.Parameters.AddWithValue("Valor_factura", ofactura.Valor_factura);
                    cmd.Parameters.AddWithValue("Estado_factura", ofactura.Estado_Factura);
                    cmd.Parameters.AddWithValue("Descripcion", ofactura.Descripcion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;

            }

            return rpta;
        }


        public bool Eliminar(int Idcliente)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Eliminar", conexion);
                    cmd.Parameters.AddWithValue("Idcliente", Idcliente);
                    cmd.CommandType=CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta=true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta=false;
            }
            return rpta;
        }

        public int ValorByDocumento(int documento)
        {
            
            var oFactura = new List<FacturaModel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Consultar", conexion);
                cmd.Parameters.AddWithValue("Documento", documento);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oFactura.Add(new FacturaModel()
                        {
                            Idcliente = Convert.ToInt32(dr["Idcliente"]),
                            Nombre = dr["Nombre"].ToString(),
                            Documento = Convert.ToInt32(dr["Documento"]),
                            Valor_factura = Convert.ToInt32(dr["Valor_factura"]),
                            Fecha_factura = Convert.ToDateTime(dr["Fecha_factura"]),
                            Estado_Factura = Convert.ToInt32(dr["Estado_factura"]),
                            Descripcion = dr["Descripcion"].ToString()
                        });

                    }
                }

            }

            int suma = 0;
            foreach (var item in oFactura)
            {
                suma = suma + item.Valor_factura;
            }

            return suma;
            
            
        }
    }
}

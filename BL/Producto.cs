using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        public static ML.Result Add(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "ProductoAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter[] Collection = new SqlParameter[3];

                        Collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                        Collection[0].Value = producto.Nombre;

                        Collection[1] = new SqlParameter("@Descripcion", SqlDbType.VarChar);
                        Collection[1].Value = producto.Descripcion;

                        Collection[2] = new SqlParameter("@FechaCreacion", SqlDbType.VarChar);
                        Collection[2].Value = producto.FechaCracion;

                        cmd.Parameters.AddRange(Collection);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "GetAllCatalogoProd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable tableUsuario = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(tableUsuario);

                        if (tableUsuario.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in tableUsuario.Rows)
                            {
                                ML.Producto producto = new ML.Producto();
                                producto.IdProducto = int.Parse(row[0].ToString());
                                producto.Nombre = row[1].ToString();
                                producto.Descripcion = row[2].ToString();
                                producto.IdUsuario = int.Parse(row[3].ToString());
                                producto.FechaCracion = row[4].ToString();
                                result.Objects.Add(producto);

                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }

        public static ML.Result Update(ML.Producto producto) 
        { 
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection())) 
                {
                    string query = "ProductoUpdate";
                    using (SqlCommand cmd = new SqlCommand()) 
                    { 
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[4];

                        collection [0] = new SqlParameter ("@IdUsuario", SqlDbType.Int);
                        collection[0].Value = producto.IdUsuario;

                        collection[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                        collection[1].Value = producto.Nombre;

                        collection[2] = new SqlParameter("@Descripcion", SqlDbType.VarChar);
                        collection[2].Value = producto.Descripcion;

                        collection[3] = new SqlParameter("@FechaCreacion", SqlDbType.VarChar);
                        collection[3].Value = producto.FechaCracion;

                        cmd.Parameters.AddRange (collection);
                        cmd.Connection.Open();
                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else 
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct=false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Delete(int IdProducto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "DelExaCatalogoProducto ";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdProducto", SqlDbType.Int);
                        collection[0].Value = IdProducto;


                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result GetById(int IdProducto) 
        
        { 
            ML.Result result =new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection())) 
                { 
                    string query = "ProductoGetById";
                    using (SqlCommand cmd = new SqlCommand()) 
                    { 
                        cmd.CommandText= query;
                        cmd.Connection= context;
                        cmd.CommandType= CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdProducto", SqlDbType.Int);
                        collection[0].Value = IdProducto;


                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow row = dt.Rows[0];
                            ML.Producto producto = new ML.Producto();
                            producto.IdProducto = int.Parse(row[0].ToString());
                            producto.Nombre = row[1].ToString();
                            producto.Descripcion = row[2].ToString();
                            producto.FechaCracion = row[3].ToString();
                            result.Object = producto;
                            result.Correct = true;


                        }
                        else 
                        { 
                            result.Correct = false;
                        }

                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex) 
            { 
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            
            return result;
        }
    }
}

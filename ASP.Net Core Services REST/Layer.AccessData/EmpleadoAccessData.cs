using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Layer.Entity;
namespace Layer.AccessData
{
    public class EmpleadoAccessData
    {
        public static List<EmpleadoEntity> Listar()
        {
            var lista = new List<EmpleadoEntity>();
            string cadenaConexion = "Data Source=MORALES\\SQL2012;DataBase=BD_Empresa;Integrated Security=true";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand("usp_Empleado_Listar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drlector = cmd.ExecuteReader();


            while (drlector.Read())
            {
                EmpleadoEntity oEmpleadoEntity = new EmpleadoEntity();
                oEmpleadoEntity.CodiEmpleado = Convert.ToInt32(drlector["Codi_Empleado"]);
                oEmpleadoEntity.NombresEmpleado = drlector["Nombres_Empleado"].ToString().Trim();
                oEmpleadoEntity.ApellidosEmpleado = drlector["Apellidos_Empleado"].ToString().Trim();
                oEmpleadoEntity.DireccionEmpleado = drlector["Direccion_Empleado"].ToString().Trim();
                oEmpleadoEntity.TelefonoEmpleado = drlector["Telefono_Empleado"].ToString().Trim();
                oEmpleadoEntity.EmailEmpleado = drlector["Email_Empleado"].ToString().Trim();
                oEmpleadoEntity.FechaNacimientoEmpleado = Convert.ToDateTime(drlector["FechaNacimiento_Empleado"]).ToString("dd/MM/yyyy");
                oEmpleadoEntity.SueldoEmpleado = Convert.ToDouble(drlector["Sueldo_Empleado"]);
                oEmpleadoEntity.Activo = Convert.ToBoolean(drlector["Activo"]);
                lista.Add(oEmpleadoEntity);
            }
            return lista;
        }

        public static List<EmpleadoEntity> Filtrar(EmpleadoEntity entidad)
        {
            var lista = new List<EmpleadoEntity>();
            string cadenaConexion = "Data Source=MORALES\\SQL2012;DataBase=BD_Empresa;Integrated Security=true";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand("usp_Empleado_Filtrar", cn);
            cmd.Parameters.Add(new SqlParameter("@Nombres_Empleado", SqlDbType.VarChar, 100)).Value = entidad.NombresEmpleado;
            cmd.Parameters.Add(new SqlParameter("@Apellidos_Empleado", SqlDbType.VarChar, 100)).Value = entidad.ApellidosEmpleado;

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drlector = cmd.ExecuteReader();


            while (drlector.Read())
            {
                EmpleadoEntity oEmpleadoEntity = new EmpleadoEntity();
                oEmpleadoEntity.CodiEmpleado = Convert.ToInt32(drlector["Codi_Empleado"]);
                oEmpleadoEntity.NombresEmpleado = drlector["Nombres_Empleado"].ToString().Trim();
                oEmpleadoEntity.ApellidosEmpleado = drlector["Apellidos_Empleado"].ToString().Trim();
                oEmpleadoEntity.DireccionEmpleado = drlector["Direccion_Empleado"].ToString().Trim();
                oEmpleadoEntity.TelefonoEmpleado = drlector["Telefono_Empleado"].ToString().Trim();
                oEmpleadoEntity.EmailEmpleado = drlector["Email_Empleado"].ToString().Trim();
                oEmpleadoEntity.FechaNacimientoEmpleado = Convert.ToDateTime(drlector["FechaNacimiento_Empleado"]).ToString("dd/MM/yyyy");
                oEmpleadoEntity.SueldoEmpleado = Convert.ToDouble(drlector["Sueldo_Empleado"]);
                oEmpleadoEntity.Activo = Convert.ToBoolean(drlector["Activo"]);
                lista.Add(oEmpleadoEntity);
            }
            return lista;
        }

        public static string Registrar(EmpleadoEntity entidad)
        {
            var lista = new List<EmpleadoEntity>();
            string cadenaConexion = "Data Source=MORALES\\SQL2012;DataBase=BD_Empresa;Integrated Security=true";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand("usp_Empleado_Registrar", cn);
            cmd.Parameters.Add(new SqlParameter("@Nombres_Empleado", SqlDbType.VarChar, 100)).Value = entidad.NombresEmpleado;
            cmd.Parameters.Add(new SqlParameter("@Apellidos_Empleado", SqlDbType.VarChar, 100)).Value = entidad.ApellidosEmpleado;
            cmd.Parameters.Add(new SqlParameter("@Direccion_Empleado", SqlDbType.VarChar, 200)).Value = entidad.DireccionEmpleado;
            cmd.Parameters.Add(new SqlParameter("@Telefono_Empleado", SqlDbType.VarChar, 200)).Value = entidad.TelefonoEmpleado;
            cmd.Parameters.Add(new SqlParameter("@Email_Empleado", SqlDbType.VarChar, 200)).Value = entidad.EmailEmpleado;
            cmd.Parameters.Add(new SqlParameter("@FechaNacimiento_Empleado", SqlDbType.DateTime)).Value = DateTime.Parse(entidad.FechaNacimientoEmpleado);
            cmd.Parameters.Add(new SqlParameter("@Sueldo_Empleado", SqlDbType.Real)).Value = entidad.SueldoEmpleado;
            cmd.Parameters.Add(new SqlParameter("@Activo", SqlDbType.VarChar, 100)).Value = entidad.Activo;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            return "Registro Exitoso";

        }

        public static string Modificar(EmpleadoEntity entidad)
        {
            var lista = new List<EmpleadoEntity>();
            string cadenaConexion = "Data Source=MORALES\\SQL2012;DataBase=BD_Empresa;Integrated Security=true";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand("usp_Empleado_Modificar", cn);
            cmd.Parameters.Add(new SqlParameter("@Codi_Empleado", SqlDbType.Int)).Value = entidad.CodiEmpleado;
            cmd.Parameters.Add(new SqlParameter("@Nombres_Empleado", SqlDbType.VarChar, 100)).Value = entidad.NombresEmpleado;
            cmd.Parameters.Add(new SqlParameter("@Apellidos_Empleado", SqlDbType.VarChar, 100)).Value = entidad.ApellidosEmpleado;
            cmd.Parameters.Add(new SqlParameter("@Direccion_Empleado", SqlDbType.VarChar, 200)).Value = entidad.DireccionEmpleado;
            cmd.Parameters.Add(new SqlParameter("@Telefono_Empleado", SqlDbType.VarChar, 200)).Value = entidad.TelefonoEmpleado;
            cmd.Parameters.Add(new SqlParameter("@Email_Empleado", SqlDbType.VarChar, 200)).Value = entidad.EmailEmpleado;
            cmd.Parameters.Add(new SqlParameter("@FechaNacimiento_Empleado", SqlDbType.DateTime)).Value = DateTime.Parse(entidad.FechaNacimientoEmpleado);
            cmd.Parameters.Add(new SqlParameter("@Sueldo_Empleado", SqlDbType.Real)).Value = entidad.SueldoEmpleado;
            cmd.Parameters.Add(new SqlParameter("@Activo", SqlDbType.VarChar, 100)).Value = entidad.Activo;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            return "Modificación Exitosa";

        }

        public static string Eliminar(EmpleadoEntity entidad)
        {
            var lista = new List<EmpleadoEntity>();
            string cadenaConexion = "Data Source=MORALES\\SQL2012;DataBase=BD_Empresa;Integrated Security=true";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand("usp_Empleado_Eliminar", cn);
            cmd.Parameters.Add(new SqlParameter("@Codi_Empleado", SqlDbType.Int)).Value = entidad.CodiEmpleado;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            return "Eliminación Exitosa";

        }
    }
}

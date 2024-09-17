using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace DAL
{
    public class Conexion
    {
        private string StringConexion;


        private SqlConnection _connection;


        private SqlCommand _command;


        private SqlDataReader _reader;


        public Conexion(string pStringCnx)
        {
            StringConexion = pStringCnx;
        }


        public DataSet BuscarTiquete(string nombre)
        {
            try
            {
                _connection = new SqlConnection(StringConexion);
                _connection.Open();

                _command = new SqlCommand();
                _command.Connection = _connection;
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[Sp_Buscar_Tiquetes]";
                _command.Parameters.AddWithValue("@nombreCompleto", nombre);

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet datos = new DataSet();
                adapter.SelectCommand = _command;
                adapter.Fill(datos);

                _connection.Close();
                _connection.Dispose();
                _command.Dispose();
                adapter.Dispose();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarTiquete(string nombre)
        {
            try
            {
                _connection = new SqlConnection(StringConexion);
                _connection.Open();
                _command = new SqlCommand();
                _command.Connection = _connection;
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[Sp_Del_Tiquete]";
                _command.Parameters.AddWithValue("@nombreCompleto", nombre);

                _command.ExecuteNonQuery(); 

                _connection.Close();
                _connection.Dispose();
                _command.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void GuardarTiquete(Tiquete tiquete)
        {
            try
            {
                _connection = new SqlConnection(StringConexion);
                _connection.Open();
                _command = new SqlCommand();
                _command.Connection = _connection;
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[Sp_Ins_Tiquete]";
                _command.Parameters.AddWithValue("@cedula", tiquete.cedula);
                _command.Parameters.AddWithValue("@nombreCompleto", tiquete.nombreCompleto);
                _command.Parameters.AddWithValue("@lugarDestino", tiquete.lugarDestino);
                _command.Parameters.AddWithValue("@aerolinea", tiquete.aerolinea);
                _command.Parameters.AddWithValue("@pagoTiquete", tiquete.pagoTiquete);
                _command.Parameters.AddWithValue("@impuesto", tiquete.impuesto);
                _command.Parameters.AddWithValue("@precioFinal", tiquete.precioFinal);

                _command.ExecuteNonQuery();
                _connection.Close();
                _connection.Dispose();
                _command.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ModificarTiquete(Tiquete tiquete)
        {
            try
            {
                _connection = new SqlConnection(StringConexion);
                _connection.Open();
                _command = new SqlCommand();
                _command.Connection = _connection;
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[Sp_Modificar_Tiquete]";
                _command.Parameters.AddWithValue("@nombreCompleto", tiquete.nombreCompleto);
                _command.Parameters.AddWithValue("@lugarDestino", tiquete.lugarDestino);
                _command.Parameters.AddWithValue("@aerolinea", tiquete.aerolinea);
                _command.Parameters.AddWithValue("@pagoTiquete", tiquete.pagoTiquete);
                _command.Parameters.AddWithValue("@impuesto", tiquete.impuesto);
                _command.Parameters.AddWithValue("@precioFinal", tiquete.precioFinal);

                _command.ExecuteNonQuery();
                _connection.Close();
                _connection.Dispose();
                _command.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ModificarCliente(Cliente cliente)
        {
            try
            {
                _connection = new SqlConnection(StringConexion);
                _connection.Open();
                _command = new SqlCommand();
                _command.Connection = _connection;
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[Sp_Modificar_Cliente]";
                _command.Parameters.AddWithValue("@nombreCompleto", cliente.nombreCompleto);
                _command.Parameters.AddWithValue("@lugarDestino", cliente.lugarDestino);
                _command.ExecuteNonQuery();
                _connection.Close();
                _connection.Dispose();
                _command.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GuardarCliente(Cliente cliente)
        {
            try
            {
                _connection = new SqlConnection(StringConexion);
                _connection.Open();
                _command = new SqlCommand();
                _command.Connection = _connection;
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[Sp_Ins_Cliente]";
                _command.Parameters.AddWithValue("@cedula", cliente.cedula);
                _command.Parameters.AddWithValue("@nombreCompleto", cliente.nombreCompleto);
                _command.Parameters.AddWithValue("@lugarDestino", cliente.lugarDestino);

                _command.ExecuteNonQuery();
                _connection.Close();
                _connection.Dispose();
                _command.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarCliente(string nombre)
        {
            try
            {
                _connection = new SqlConnection(StringConexion);
                _connection.Open();
                _command = new SqlCommand();
                _command.Connection = _connection;
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[Sp_Del_Cliente]";
                _command.Parameters.AddWithValue("@nombreCompleto", nombre);

                _command.ExecuteNonQuery();

                _connection.Close();
                _connection.Dispose();
                _command.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet BuscarCliente(string nombre)
        {
            try
            {
                _connection = new SqlConnection(StringConexion);
                _connection.Open();

                _command = new SqlCommand();
                _command.Connection = _connection;
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[Sp_Buscar_Clientes]";
                _command.Parameters.AddWithValue("@nombreCompleto", nombre);

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet datos = new DataSet();
                adapter.SelectCommand = _command;
                adapter.Fill(datos);

                _connection.Close();
                _connection.Dispose();
                _command.Dispose();
                adapter.Dispose();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

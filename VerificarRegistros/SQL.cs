using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Data.SqlClient;
namespace VerificarRegistros
{
    class SQL
    {
        public string consultarExistencia(String id)
        {
            using (SqlConnection Conexion = new SqlConnection(Properties.Settings.Default.CadenaDeConexion))
            {
                try
                {
                    Conexion.Open();
                    Query.CommandText = "SELECT idUsuario FROM usuarios WHERE idUsuario='" + id + "'";
                    Query.Connection = Conexion;
                    consultar = Query.ExecuteReader();
                    if (consultar.Read())
                    {
                        return "Ya existe: " + consultar.GetString(0);
                    }
                    else { return "No existe"; }
                }
                catch (SqlException)
                {
                    return "Error";
                }
            }

        }
        SqlDataReader consultar;
        SqlCommand Query = new SqlCommand();
    }
}
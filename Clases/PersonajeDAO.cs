using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using MySql.Data.MySqlClient;

namespace Clases
{
    public static class PersonajeDAO
    {
        private static string connectionString;
        public static void Inicializar(string server, string db)
        {
            connectionString = $"Server={server};Database={db};User ID=root;Password=;SslMode=None;";
        }

        public static Personaje ObtenerPersonajePorId(int id)
        {
            string query = "SELECT * FROM personajes WHERE ID = @ID";
            Personaje personaje = null;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string nombre = reader.GetString("Nombre");
                                short nivel = reader.GetInt16("Nivel");
                                short clase = reader.GetInt16("Clase");
                                string titulo = reader.GetString("Titulo");

                                switch (clase)
                                {
                                    case 1:
                                        personaje = new Guerrero(id, nombre, nivel);
                                        break;
                                    case 2:
                                        personaje = new Hechicero(id, nombre, nivel);
                                        break;
                                    default:
                                        Console.WriteLine("ID de personaje no encontrado.");
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al intentar obtener el personaje: {ex.Message}");
            }

            return personaje;
        }
    }
}

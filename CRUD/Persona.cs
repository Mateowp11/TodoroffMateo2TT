using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using static CRUD.PersonaDB;

namespace CRUD
{
    public class PersonaDB
    {
        private string connectionString =
    "Data Source=localhost\\SQLEXPRESS;Initial Catalog=CrudWindowsForm1;Integrated Security=True;TrustServerCertificate=True;";



        public bool Ok()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }

        }

        public List<Persona> Get() 
        {
            List<Persona> persona = new List<Persona>();

            string query = "select id,nombre,edad from persona";

            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) 
                    {
                        Persona unaPersona = new Persona();

                        unaPersona.Id = reader.GetInt32(0);
                        unaPersona.Nombre = reader.GetString(1);
                        unaPersona.Edad = reader.GetInt32(2);

                        persona.Add(unaPersona);
                    }

                    reader.Close();
                    connection.Close();
                }
                catch(Exception ex) 
                {
                    throw new Exception("Hay un error en la bd" + ex.Message);
                }
            }
                return persona;
        }


        public Persona Get(int Id)
        {

            string query = "select id,nombre,edad from persona" +
                " where id=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);
                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();
                    
                    Persona unaPersona = new Persona();

                    unaPersona.Id = reader.GetInt32(0);
                    unaPersona.Nombre = reader.GetString(1);
                    unaPersona.Edad = reader.GetInt32(2);

                    reader.Close();
                    connection.Close();

                    return unaPersona;


                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd" + ex.Message);
                }
            }

        }

        public void Add(string Nombre, int Edad) 
        {
            string query = "insert into persona(nombre, edad) values (@nombre, @edad) ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", Nombre);
                command.Parameters.AddWithValue("@edad", Edad);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();


                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd" + ex.Message);
                }
            }

            
        }

        public void Update(string Nombre, int Edad, int Id)
        {
            string query = "update persona set nombre=@nombre, edad=@edad" + 
                " where id =@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", Nombre);
                command.Parameters.AddWithValue("@edad", Edad);
                command.Parameters.AddWithValue("@id", Id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();


                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd" + ex.Message);
                }
            }


        }


        public void Delete(int Id)
        {
            string query = "delete from persona where id=@id ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();


                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd" + ex.Message);
                }
            }


        }
    }

    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }


}

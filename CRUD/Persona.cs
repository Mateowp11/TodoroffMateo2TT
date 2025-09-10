using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CRUD
{
    public class Persona
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

    }


}

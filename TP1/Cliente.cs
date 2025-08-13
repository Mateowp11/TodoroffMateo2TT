using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Cliente
    {
        private string nombre;
        private string apellido;
        private int dni;
        private int telefono;
        private string email;
        private DateTime nacimiento;
        private List<Cuenta> listaCuentas;

        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Apellido { get { return apellido; } set { apellido = value; } }
        public int Dni { get { return dni; } set { dni = value; } }
        public int Telefono { get { return telefono; } set { telefono = value; } }
        public string Email { get { return email; } set { email = value; } }
        public DateTime Nacimiento { get { return nacimiento; } set { nacimiento = value; } }
        public List<Cuenta> ListaCuentas { get { return listaCuentas; } set { listaCuentas = value; } }
        
    }
}

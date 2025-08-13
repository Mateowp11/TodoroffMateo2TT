using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Repositorio
    {
        private List<Cliente> clientes = new List<Cliente>();
        private List<Cuenta> cuentas = new List<Cuenta>();

        public bool AgregarCliente(Cliente c ) 
        {
            if (clientes.Any(cli => cli.Dni == c.Dni))
                return false;
            clientes.Add(c);
            return true;
        }

        public Cliente BuscarCliente(int dni)
        {
            return clientes.FirstOrDefault(c => c.Dni == dni);
        }

        public bool EliminarCliente(int dni)
        {
            var cliente = BuscarCliente(dni);
            if (cliente == null) return false;
            if (cliente.ListaCuentas.Any()) return false; 
            clientes.Remove(cliente);
            return true;
        }

        public bool AgregarCuenta(int dniCliente, Cuenta cuenta)
        {
            var cliente = BuscarCliente(dniCliente);
            if (cliente == null) return false;
            if (cliente.ListaCuentas.Any(c => c.Codigo == cuenta.Codigo))
                return false; 
            cliente.ListaCuentas.Add(cuenta);
            return true;
        }

        public bool Depositar(int dniCliente, int codigoCuenta, int monto)
        {
            var cliente = BuscarCliente(dniCliente);
            if (cliente == null) return false;
            var cuenta = cliente.ListaCuentas.FirstOrDefault(c => c.Codigo == codigoCuenta);
            if (cuenta == null) return false;
            cuenta.Depositar(monto);
            return true;
        }

        public bool Extraer(int dniCliente, int codigoCuenta, int monto)
        {
            var cliente = BuscarCliente(dniCliente);
            if (cliente == null) return false;
            var cuenta = cliente.ListaCuentas.FirstOrDefault(c => c.Codigo == codigoCuenta);
            if (cuenta == null) return false;
            return cuenta.Extraer(monto);
        }

        public void ListarClientes()
        {
            foreach (var c in clientes)
            {
                Console.WriteLine($"{c.Nombre} {c.Apellido} - DNI: {c.Dni}");
                foreach (var cu in c.ListaCuentas) 
                {
                    Console.WriteLine($"  Cuenta {cu.Codigo} - Saldo: {cu.Saldo}");
                }
            }
        }
    }


}

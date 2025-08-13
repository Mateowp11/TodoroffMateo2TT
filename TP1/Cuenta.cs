using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public abstract class Cuenta
    {
        private int saldo;
        private int codigo;

        public int Saldo { get { return saldo; } set { saldo = value; } }
        public int Codigo { get { return codigo; } set { codigo = value; } }
    
    
    public Cuenta(int codigo, int saldoInicial) 
        {
            Codigo = codigo;
            Saldo = saldoInicial;
        }


        public abstract void Depositar(int monto);

        public abstract bool Extraer(int monto);

        public void MostrarSaldo() 
        {
            Console.WriteLine($"Cuenta {Codigo} - Saldo: {Saldo}");
        }
    }
}
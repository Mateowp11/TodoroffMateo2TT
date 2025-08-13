using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class CajaAhorro : Cuenta
    {
        public CajaAhorro(int codigo, int saldoInicial)
            : base(codigo, saldoInicial) { }

        public override void Depositar(int monto)
        {
            Saldo += monto;
            Console.WriteLine($"Se depositaron {monto} en la Caja de Ahorro.");
        }

        public override bool Extraer(int monto)
        {
            if (monto <= Saldo)
            {
                Saldo -= monto;
                Console.WriteLine($"Se extrajeron {monto} de la Caja de Ahorro.");
                return true;
            }
            Console.WriteLine("Fondos insuficientes.");
            return false;
        }
    }
}

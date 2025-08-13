using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class CuentaCorriente : Cuenta
    {
        private int descubiertoPermitido = 500; // ejemplo

        public CuentaCorriente(int codigo, int saldoInicial)
            : base(codigo, saldoInicial) { }

        public override void Depositar(int monto)
        {
            Saldo += monto;
            Console.WriteLine($"Se depositaron {monto} en la Cuenta Corriente.");
        }

        public override bool Extraer(int monto)
        {
            if (monto <= Saldo + descubiertoPermitido)
            {
                Saldo -= monto;
                Console.WriteLine($"Se extrajeron {monto} de la Cuenta Corriente.");
                return true;
            }
            Console.WriteLine("No se puede extraer: límite de descubierto superado.");
            return false;
        }
    }
}

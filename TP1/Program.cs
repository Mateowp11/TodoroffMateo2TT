namespace TP1 
{
    public class Program
    {
        public static void Main()
        { 
            Repositorio repo = new Repositorio();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("--PROGRAMA BANCARIO--");
                Console.WriteLine("Menu de opciones");
                Console.WriteLine("Seleccione la opcion");
                Console.WriteLine("1. Agregar cliente");
                Console.WriteLine("2. Eliminar cliente");
                Console.WriteLine("3. Agregar cuenta");
                Console.WriteLine("4. Depositar");
                Console.WriteLine("5. Extraccion");
                Console.WriteLine("6. Listar clientes");
                Console.WriteLine("0. salir");

                int opcion = int.Parse(Console.ReadLine());
                
                switch (opcion) 
                {
                    case 1:
                        Console.Write("DNI: "); int dni = int.Parse(Console.ReadLine());
                        Console.Write("Nombre: "); string nombre = Console.ReadLine();
                        Console.Write("Apellido: "); string apellido = Console.ReadLine();
                        Console.Write("Teléfono: "); int tel = int.Parse(Console.ReadLine());
                        Console.Write("Email: "); string email = Console.ReadLine();
                        Console.Write("Fecha nacimiento (yyyy-mm-dd): "); DateTime nac = DateTime.Parse(Console.ReadLine());

                        Cliente c = new Cliente { Dni = dni, Nombre = nombre, Apellido = apellido, Telefono = tel, Email = email, Nacimiento = nac };
                        if (repo.AgregarCliente(c))
                            Console.WriteLine("Cliente agregado.");
                        else
                            Console.WriteLine("Error: DNI ya existe.");
                        break;

                    case 2:
                        Console.Write("DNI a eliminar: "); int dniEliminar = int.Parse(Console.ReadLine());
                        if (repo.EliminarCliente(dniEliminar))
                            Console.WriteLine("Cliente eliminado.");
                        else
                            Console.WriteLine("No se pudo eliminar.");
                        break;

                    case 3:
                        Console.Write("DNI del cliente: "); int dniCli = int.Parse(Console.ReadLine());
                        Console.Write("Código de cuenta: "); int codCuenta = int.Parse(Console.ReadLine());
                        Console.Write("Tipo (1-CajaAhorro, 2-Corriente): "); int tipo = int.Parse(Console.ReadLine());
                        Console.Write("Saldo inicial: "); int saldoIni = int.Parse(Console.ReadLine());

                        Cuenta cuenta = tipo == 1 ? new CajaAhorro(codCuenta, saldoIni) : new CuentaCorriente(codCuenta, saldoIni);
                        if (repo.AgregarCuenta(dniCli, cuenta))
                            Console.WriteLine("Cuenta agregada.");
                        else
                            Console.WriteLine("Error agregando cuenta.");
                        break;

                    case 4:
                        Console.Write("DNI cliente: "); int dniDep = int.Parse(Console.ReadLine());
                        Console.Write("Código cuenta: "); int codDep = int.Parse(Console.ReadLine());
                        Console.Write("Monto a depositar: "); int montoDep = int.Parse(Console.ReadLine());
                        if (repo.Depositar(dniDep, codDep, montoDep))
                            Console.WriteLine("Depósito realizado.");
                        else
                            Console.WriteLine("Error depósito.");
                        break;

                    case 5:
                        Console.Write("DNI cliente: "); int dniExt = int.Parse(Console.ReadLine());
                        Console.Write("Código cuenta: "); int codExt = int.Parse(Console.ReadLine());
                        Console.Write("Monto a extraer: "); int montoExt = int.Parse(Console.ReadLine());
                        if (repo.Extraer(dniExt, codExt, montoExt))
                            Console.WriteLine("Extracción realizada.");
                        else
                            Console.WriteLine("Error extracción.");
                        break;

                    case 6:
                        repo.ListarClientes();
                        break;

                    case 0:
                        continuar = false;
                        break;
                }

                Console.WriteLine();
            }   
         }

    }
}
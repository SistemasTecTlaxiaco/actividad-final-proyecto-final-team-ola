using BibliotecaCola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool salir = true; 
            while (salir)
            {
                Console.WriteLine("1.-Generar ficha");
                Console.WriteLine("2.-Mostrar fichas generadas");
                Console.WriteLine("3.-Salir");
                Console.WriteLine("Elige una opción:");
                int valor = int.Parse(Console.ReadLine());
                switch (valor)
                {
                    case 1:
                        Console.Write("Ingrese su nombre: ");
                        string nombre = Console.ReadLine();
                        Console.WriteLine(Cola.Encolar(nombre));
                        break;
                    case 2:
                        Cola.ImprimirCola();
                        break;
                    case 3:
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }


        }
    }
}

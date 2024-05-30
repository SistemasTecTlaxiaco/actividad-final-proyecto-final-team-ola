using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCola
{
    public class Cola
    {
        static Nodo frente;
        static Nodo final;
        static int turnoActual;

        static Cola()
        {
            frente = null;
            final = null;
            turnoActual = 0;
        }

        public static bool Vacia()
        {
            return frente == null;
        }

        public static string Encolar(string nombre, string numeroDeControl)
        {
            Nodo nuevo = new Nodo(turnoActual, nombre, numeroDeControl);
            turnoActual++;

            if (Vacia())
            {
                frente = nuevo;
                final = nuevo;
            }
            else
            {
                final.Siguiente = nuevo;
                final = nuevo;
            }
            return $"El turno de {nombre} es {turnoActual}";
        }

        public static bool ExisteNumeroDeControl(string numeroDeControl)
        {
            Nodo recorrido = frente;
            while (recorrido != null)
            {
                if (recorrido.NumeroDeControl == numeroDeControl)
                {
                    return true;
                }
                recorrido = recorrido.Siguiente;
            }
            return false;
        }

        public static void ImprimirCola()
        {
            Nodo recorrido = frente;
            while (recorrido != null)
            {
                Console.WriteLine($"{recorrido.Nombre} - Turno: {recorrido.Turno + 1} - Número de Control: {recorrido.NumeroDeControl}");
                recorrido = recorrido.Siguiente;
            }
        }
    }

    public class Nodo
    {
        public int Turno;
        public string Nombre;
        public string NumeroDeControl;
        public Nodo Siguiente;

        public Nodo(int turno, string nombre, string numeroDeControl)
        {
            Turno = turno;
            Nombre = nombre;
            NumeroDeControl = numeroDeControl;
            Siguiente = null;
        }
    }
}
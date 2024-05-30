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
        static int tamaño;
        static int turnoActual;

        static Cola()
        {
            frente = null;
            final = null;
            tamaño = 0;
            turnoActual = 0;
        }

        public static bool Vacia()
        {
            return frente == null;
        }

        public static string Encolar(string nombre)
        {
            Nodo nuevo = new Nodo(turnoActual, nombre);
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
            tamaño++;
            return $"Turno de {nombre} es {turnoActual}";
        }

        public static void ImprimirCola()
        {
            Nodo recorrido = frente;
            while (recorrido != null)
            {
                Console.WriteLine($"{recorrido.Nombre} - Turno: {recorrido.Turno}");
                recorrido = recorrido.Siguiente;
            }
        }
    }

    public class Nodo
    {
        public int Turno;
        public string Nombre;
        public Nodo Siguiente;

        public Nodo(int turno, string nombre)
        {
            Turno = turno;
            Nombre = nombre;
            Siguiente = null;
        }
    }
}
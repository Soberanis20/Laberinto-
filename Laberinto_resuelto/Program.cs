using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laberinto_resuelto
{
    internal class Program
    {
        public class Posicion
        {
            public int Fila { get; set; }
            public int Columna { get; set; }

            public Posicion(int fila, int columna)
            {
                Fila = fila;
                Columna = columna;
            }
        }

        public static bool EncontrarSalidaIterativo(int[][] laberinto, int filaInicial, int columnaInicial, int filaFinal, int columnaFinal)
        {
            Stack<Posicion> pila = new Stack<Posicion>();
            pila.Push(new Posicion(filaInicial, columnaInicial));

            int filas = laberinto.Length;
            int columnas = laberinto[0].Length;

            int[] desplazamientosFila = { 1, -1, 0, 0 };
            int[] desplazamientosColumna = { 0, 0, 1, -1 };

            while (pila.Count > 0)
            {
                Posicion actual = pila.Pop();
                int fila = actual.Fila;
                int columna = actual.Columna;

                // Verificar si hemos llegado a la salida
                if (fila == filaFinal && columna == columnaFinal)
                {
                    return true;
                }

                laberinto[fila][columna] = -1;

                for (int i = 0; i < 4; i++)
                {
                    int nuevaFila = fila + desplazamientosFila[i];
                    int nuevaColumna = columna + desplazamientosColumna[i];


                    if (nuevaFila >= 0 && nuevaFila < filas && nuevaColumna >= 0 && nuevaColumna < columnas && laberinto[nuevaFila][nuevaColumna] == 0)
                    {
                        pila.Push(new Posicion(nuevaFila, nuevaColumna));
                    }
                }
            }


            return false;
        }
        public static void Main()
        {
            int[][] laberinto1 = new int[][]
        {
            new int[] { 0, 1, 0, 0, 0 },
            new int[] { 0, 1, 1, 1, 0 },
            new int[] { 0, 0, 0, 1, 0 },
            new int[] { 1, 1, 0, 1, 1 },
            new int[] { 0, 0, 0, 0, 0 }
        };

            int[][] laberinto2 = new int[][]
            {
            new int[] { 0, 0, 1, 1, 1, 0, 0, 0 },
            new int[] { 1, 0, 1, 0, 0, 0, 1, 1 },
            new int[] { 1, 0, 0, 0, 1, 1, 0, 1 },
            new int[] { 0, 1, 1, 1, 0, 0, 0, 0 },
            new int[] { 0, 0, 0, 1, 1, 1, 1, 0 },
            new int[] { 1, 1, 0, 0, 0, 0, 1, 0 },
            new int[] { 0, 1, 1, 1, 0, 1, 0, 0 },
            new int[] { 0, 0, 0, 0, 0, 1, 1, 0 }
            };

            int[][] laberinto3 = new int[][]
            {
            new int[] { 0, 1, 0, 0, 0, 1, 0, 0, 0, 1 },
            new int[] { 0, 1, 1, 1, 0, 1, 1, 1, 0, 1 },
            new int[] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 1 },
            new int[] { 1, 1, 0, 1, 1, 1, 0, 0, 0, 0 },
            new int[] { 0, 0, 0, 0, 0, 1, 1, 1, 1, 0 },
            new int[] { 1, 1, 1, 1, 0, 0, 0, 0, 0, 0 },
            new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
            new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
            new int[] { 1, 1, 1, 1, 1, 1, 1, 0, 1, 0 },
            new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            bool resultado1 = EncontrarSalidaIterativo(laberinto1, 0, 0, 4, 4);
            Console.WriteLine("¿Existe un camino en el laberinto 1? " + resultado1);

            bool resultado2 = EncontrarSalidaIterativo(laberinto2, 0, 0, 7, 4);
            Console.WriteLine("¿Existe un camino en el laberinto 2? " + resultado2);

            bool resultado3 = EncontrarSalidaIterativo(laberinto3, 0, 0, 9, 9);
            Console.WriteLine("¿Existe un camino en el laberinto 3? " + resultado3);
            Console.ReadKey();
        }
    }
}

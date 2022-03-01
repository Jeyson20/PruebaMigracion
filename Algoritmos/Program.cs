using System;
using System.Collections.Generic;
using System.Linq;

namespace Algoritmos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Menu:\n" +
                "1- Lista de numeros\n" +
                "2- Serie Fibonacci\n" +
                "3- Desglosador de Billetes\n");

            Console.WriteLine("Seleccione un numero: ");
            int number = int.Parse(Console.ReadLine());
            if (number ==1)
            {
                List<int>[] arrayList = new List<int>[3];
                arrayList[0] = new List<int> { 1, 2, 3 };
                arrayList[1] = new List<int> { 4, 5, 6,18 };
                arrayList[2] = new List<int> { 7, 8, 9,10,12,15};
                ListaNumeros(arrayList);
            }
            else if (number ==2)
            {
                Console.WriteLine("Introduzca un numero: ");
                int n = int.Parse(Console.ReadLine());
                SerieFibonacci(n);
            }
            else if (number ==3)
            {
                Console.WriteLine("Introduzca un Monto: ");
                int monto = int.Parse(Console.ReadLine());
                DesgloseBilletes(monto);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nNumero incorrecto!!\n");
                Main(args);
            }
        }

        private static void DesgloseBilletes(int monto)
        {
            Console.WriteLine("\nDesglose de Billetes \n");

            int[] billetes = { 2000, 1000, 500, 200, 100, 50, 25, 10, 5, 1 };
            int[] cambio = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 0; i < billetes.Length; i++)
            {
                if (monto >= billetes[i])
                {
                    cambio[i] = (monto / billetes[i]);
                    monto = (monto - (cambio[i] * billetes[i])).GetHashCode();
                }
            }

            for (int i = 0; i < billetes.Length; i++)
            {
                if (cambio[i] > 0)
                {
                    Console.WriteLine(cambio[i] + " x " + billetes[i] + " = " + billetes[i] * cambio[i]);
                }
            }
            Console.ReadKey();
        }

        private static void SerieFibonacci(int n)
        {
            int a = 0, b = 1, c;

            Console.WriteLine("Serie Fibonacci \n");

                for (int i = 0; i< n ; i++)
                {
                    Console.WriteLine($"({i + 1})" + " " + a);
                    c = a;
                    a = b;
                    b = a + c;
                }
            
            Console.ReadKey();
        }

        private static void ListaNumeros(List<int>[]arrayList)
        {
            int Mayorlista;
            int MayorCantidad;
            List<int> lista1 = new List<int>();
            List<int> lista2 = new List<int>();

            foreach (var list in arrayList)
            {
                Mayorlista = list.Max();
                MayorCantidad =list.Count;
                lista1.Add(Mayorlista);
                lista2.Add(MayorCantidad);

                // var lista =
            }
            Console.WriteLine("El mayor de las listas es: " + lista1.Max() +
                              $"\nLa mayor lista contiene {lista2.Max()} numeros");
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Cesar Chavez Zamorano
 * UAEM
 * ICO
 * Sistemas Expertos
 * Algoditormo genetico (palabra)
 */
namespace Algo_gene
{
    class Program
    {

        public static string palabra;
        static void Main(string[] args)
        {
            string palabra;
            int num_indi;
            double num = 0;
            Console.WriteLine("Introduce una palabra");
            palabra = Console.ReadLine();
            Console.WriteLine("Introduce numero de individuos");
            num_indi = int.Parse(System.Console.ReadLine());
            //Console.Read();

            Console.WriteLine("Palabra generada: {0}", palabra);
            //palabra = "Hola"; //cadena generada string
            //int num_indi = 100; //Se puede experimentar con la variacion de numero de individuos y tasa de mutacion
            Console.WriteLine("Inicializando Metodo");
            float tasa_mutacion = 0.02f; //tasa de mutacion var
            Poblacion poblacion = new Poblacion(tasa_mutacion, num_indi, palabra);
            while (true)
            {
                Console.WriteLine("Generacion: " + poblacion.generacion + "\nMutando: " + poblacion.Mejor_individuo());
                //Console.WriteLine(" Generacion: " + poblacion.generacion + "\nMejor Individuo= " + poblacion.Mejor_individuo());
                //+ " | Promedio de aptitud por generación= " + poblacion.Promedio());
                poblacion.Seleccion();
                poblacion.Generacion();
                if (poblacion.Mejor_individuo() == palabra) 
                {
                    //break;
                    Console.WriteLine("\nPalabra encontrada...\n");
                    Console.WriteLine("1)Colocar otra palabra");
                    Console.WriteLine("2)Salir");

                    num  = Int32.Parse(Console.ReadLine());
                    //Console.ReadKey();
                    switch (num)
                    {
                        case 1:
                            //return 1;
                            //Console.WriteLine("Introduce una nueva palabra");
                            //palabra = Console.ReadLine();
                            //Console.WriteLine("Introduce numero de individuos");
                            //num_indi = int.Parse(System.Console.ReadLine());
                            poblacion.Calcular_aptitud();
                            break;

                        case 2:
                            Console.WriteLine("Finalizando\n");
                            //System.Windows.Forms.Application.ExitThread();
                            Environment.Exit(0);
                            break;

                    }
                    //break;
                } 
                poblacion.Calcular_aptitud();
            }
            //Console.ReadKey();
        }

        //Generador de numeros aleatorios enteros entre n1 y n2-1, Lista de valores. Cada uno representa una solución a un problema.
        //No es "completamente" necesario, pero sirve para crear la lista de valores inicial. Le pasamos por parámetro la cantidad de genes.

        //public List genes;
        public static int random_entero(int n1, int n2)
        {
            Guid guid = Guid.NewGuid();
            string solo_num = new String(guid.ToString().Where(Char.IsDigit).ToArray());
            int semi = int.Parse(solo_num.Substring(0, 4));
            Random random = new Random(semi);
            return random.Next(n1, n2);
        }

        //Generador de numeros aleatorios decimales entre  0 y 1
        public static double random_decimal()
        {
            Guid guid = Guid.NewGuid();
            string solo_num = new String(guid.ToString().Where(Char.IsDigit).ToArray());
            int semi = int.Parse(solo_num.Substring(0, 4));
            Random random = new Random(semi);
            return random.NextDouble();
        }
    }
}
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
    class Poblacion
    {
        public int generacion=1;
        public ADN_indi[] poblacion;
        List<ADN_indi> contenedor;
        float tasa_mutacion;
        string palabra;

        //Constructor de la población X
        public Poblacion(float tm, int num,string palabra)
        {
            this.palabra = palabra;
            tasa_mutacion = tm;
            poblacion = new ADN_indi[num];
            for (int i = 0; i < poblacion.Length; i++)  poblacion[i] = new ADN_indi(palabra.Length);
            contenedor = new List<ADN_indi>();
            Calcular_aptitud();
        }

        //Se calcula la aptitud de cada uno de los individuos de la poblacion. La mayor aptitud es de 1
        public void Calcular_aptitud()
        {
            for (int i = 0; i < poblacion.Length; i++) poblacion[i].Aptitud(palabra);
        }

        /*seleccion*/
        //Se le asigna al contenedor cuantas veces sea un individuo en proporcion a su aptitud. Mayor aptitud, mayor veces estara ese individuo en nuestro contenedor
        public void Seleccion()
        {
            float val_Max = 0;
            contenedor.Clear();
            for (int i = 0; i < poblacion.Length; i++) if (poblacion[i].aptitud > val_Max)  val_Max = poblacion[i].aptitud;
            for (int i = 0; i < poblacion.Length; i++)
            {
                float map_aptitud = Map(poblacion[i].aptitud, 0, val_Max, 0, 1);
                int numero = (int)(map_aptitud)*100;
                for (int j = 0; j < numero; j++) contenedor.Add(poblacion[i]);
            }     
        }

        /*
            *Se selecciona al azar individuos de nuestro contenedor para realizar su cruza, obtener el hijo
            *y remplazar la antigua generacion con los nuevos hijos
        */

        public void Generacion()
        {
            for(int i=0;i<poblacion.Length;i++)
            {
                int A = Program.random_entero(0, contenedor.Count - 1);
                int B = Program.random_entero(0, contenedor.Count - 1);
                ADN_indi madre = contenedor[A];
                ADN_indi padre = contenedor[B];
                ADN_indi hijo = madre.Reproduccion(padre);
                hijo.Mutacion(tasa_mutacion);
                poblacion[i] = hijo;
            }
            generacion++;
        }
        
        //Se selecciona el mejor individuo de la generacion para retornar su string
        public string Mejor_individuo()
        {
            float val_Max = 0;
            int indice = 0;
            for (int i = 0; i < poblacion.Length; i++)
            {
                if (poblacion[i].aptitud > val_Max)
                {
                    val_Max = poblacion[i].aptitud;
                    indice = i;
                }
            }
            return new string(poblacion[indice].genes);
        }

        // Se calcula el promedio de aptitud por generacion
        public float Promedio()
        {
            float promedio = 0;
            for (int i = 0; i < poblacion.Length; i++) 
            {
                promedio += poblacion[i].aptitud; 
            }
            return (float)promedio / (poblacion.Length);
        }

        //Método de mapeo  extraer campos de datos de uno
        float Map(float val, float x1, float x2, float y1, float y2)
        {
            return ((val - x1) / (x2 - x1)) * (y2 - y1) + y1;
        }
    }
}
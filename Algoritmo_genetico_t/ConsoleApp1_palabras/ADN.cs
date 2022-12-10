using System;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;


/*
 * Cesar Chavez Zamorano
 * UAEM
 * ICO
 * Sistemas Expertos
 * Algoditormo genetico (palabra)
 */

namespace Algo_gene
{
    class ADN_indi
    {
        public char[] genes;
        public float aptitud;

        //Constructor clase ADN_indi
        public ADN_indi(int num)
        {
            genes = new char[num];
            for (int i = 0; i < genes.Length; i++) 
            { 
                genes[i] = Convert.ToChar(Program.random_entero(32, 129)); 
            }
        }

        //Convertimos nuestra cadena de caracteres a string en caso de ser char
        public string ConseguirADN_indi()
        {
            return new string(genes);
        }
        

        /*aptitud*/
        //Calculamos la aptitud comparando elemento a elemento el string del ADN_indi con el palabra
        public float Aptitud(string palabra)
        {
            int puntos = 0;
            for (int i = 0; i < genes.Length; i++) if (genes[i] == palabra[i]) puntos++;
            aptitud = (float)puntos / (float)palabra.Length;
            return aptitud;
        }

        /*mezcla*/
        //Se mezcla la la informacion entre dos ADN_indi  para crear un hijo
        public ADN_indi Reproduccion(ADN_indi padre)
        {
            int punto_cruce = Program.random_entero(0, genes.Length);
            ADN_indi hijo = new ADN_indi(genes.Length);
            for (int i=0;i<genes.Length;i++)
            {
                if (i < punto_cruce) hijo.genes[i] = genes[i];
                else hijo.genes[i] = padre.genes[i];
            }
            return hijo;
        }

        /*mutacion*/
        //Se mutacion(modifica) el elemento del ADN_indi si el numero obtenido aleatoriamente es menor que la tasa de mutacion
        public void Mutacion(float tasa_mutacion)
        {
            for (int i = 0;i< genes.Length; i++)
            {
                if (Program.random_decimal() < tasa_mutacion) genes[i] = Convert.ToChar(Program.random_entero(32, 129));
            }
        }
    }
}
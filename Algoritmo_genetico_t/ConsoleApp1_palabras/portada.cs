//using System.Collection.Generic;
//public List genes;
public class Chromosome
{
    //Lista de valores. Cada uno representa una solución a un problema.
    //Generalmente se rellena con valores entre -1 y 1.
    //No es "completamente" necesario, pero sirve para crear la lista
    //de valores inicial. Le pasamos por parámetro la cantidad de genes.
    //Deberíamos usar un gen para cada problema a resolver.
    //Por ejemplo, si lo querémos usar como dirección, necesitamos 3:
    //x, y, z.
    public void Create(int count, float min, float max)
    {
        //genes = new List();
        for(int i=0; i<count; i++)
        {
            //genes[i] = Random.Range(min, max);
        }
    }
}
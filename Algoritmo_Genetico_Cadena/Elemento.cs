using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmo_Genetico_Cadena
{
    class Elemento
    {
        private char[] genoma;
        Random r = new Random();

        public Elemento(int cantidad)
        {
            Genoma = new char[cantidad];
            for (int i = 0; i < Genoma.Length; i++)
            {
                Genoma[i] = Convert.ToChar(r.Next(32, 130));
            }
        }

        //Calculamos la aptitud comparando elemento a elemento el string del ADN con el valor_esperado
        public float Aptitud_Individuo(string valor_esperado)
        {
            int puntos = 0;
            for (int i = 0; i < Genoma.Length; i++)
            {
                if (Genoma[i] == valor_esperado[i])
                {
                    puntos++;
                }
            }
            return (float)puntos / (float)valor_esperado.Length;
        }

        //Se mezcla la la informacion entre dos elementos  para crear un hijo
        public Elemento Reproduccion(Elemento padre)
        {
            int punto_cruce = r.Next(0, Genoma.Length);
            Elemento hijo = new Elemento(Genoma.Length);
            for (int i = 0; i < Genoma.Length; i++)
            {
                if (i < punto_cruce)
                {
                    hijo.Genoma[i] = Genoma[i];
                }
                else
                {
                    hijo.Genoma[i] = padre.Genoma[i];
                }
            }
            return hijo;
        }

        //Se muta(modifica) el elemento del ADN si el numero obtenido aleatoriamente es menor que la tasa de mutacion
        public void Mutacion(float tasa_mutacion)
        {
            for (int i = 0; i < Genoma.Length; i++)
            {
                if (r.NextDouble() < tasa_mutacion)
                {
                    Genoma[i] = Convert.ToChar(r.Next(32, 130));
                }
            }

        }
        public char[] Genoma { get => genoma; set => genoma = value; }
    }
}

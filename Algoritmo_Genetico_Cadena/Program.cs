using System;

namespace Algoritmo_Genetico_Cadena
{
    class Program
    {
        static void Main(string[] args)
        {
            //0. Valores Entrada
            Cruzamiento cruzamiento = new Cruzamiento();
            cruzamiento.Valor_esperado = "Politecnico Jaime Isaza Cadavid";
            cruzamiento.Individuos = 100;//TODO: por qué este valor?
            cruzamiento.Tasa_mutacion = 0.02f;//TODO: por qué este valor?

            //1. Generar Aleatoriamente una población inicial
            cruzamiento.Generar_Aleatoriamente_Poblacion_Inicial();

            //Ciclar hasta que cierta condición se satisfaga
            string fitness = cruzamiento.Fitness();

            while (fitness != cruzamiento.Valor_esperado)
            {
                //2. Calcular aptitud de cada individuo
                cruzamiento.Calcular_aptitud_individuo();

                //3. Seleccionar(probabilisticamente) en base aptitud
                cruzamiento.Seleccionar_Probabilisticamente_Individuo();

                //4. Aplicar Operadores geneticos(cruza y mutación) para generar la siguiente población
                cruzamiento.Generar_Nueva_Poblacion();

                fitness = cruzamiento.Fitness();

                //Visualizar Generación
                Console.WriteLine(String.Format("Generación: {0} Fitness: {1} ", cruzamiento.Generacion, fitness));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmo_Genetico_Cadena
{
    class Cruzamiento
    {
        private int generacion = 1;
        private Elemento[] poblacion;
        private List<Elemento> cont_elementos;
        private float tasa_mutacion;
        private string valor_esperado;
        private int individuos;

        public void Generar_Aleatoriamente_Poblacion_Inicial()
        {
            this.poblacion = new Elemento[individuos];
            for (int i = 0; i < poblacion.Length; i++)
            {
                poblacion[i] = new Elemento(Valor_esperado.Length);
                cont_elementos = new List<Elemento>();
            }
        }

        public void Calcular_aptitud_individuo()
        {
            for (int i = 0; i < poblacion.Length; i++) poblacion[i].Aptitud_Individuo(valor_esperado);
        }

        public void Seleccionar_Probabilisticamente_Individuo()
        {
            float val_Max = 0;
            cont_elementos.Clear();

            for (int i = 0; i < poblacion.Length; i++)
            {
                if (poblacion[i].Aptitud_Individuo(valor_esperado) > val_Max)
                {
                    val_Max = poblacion[i].Aptitud_Individuo(valor_esperado);
                }
            }

            for (int i = 0; i < poblacion.Length; i++)
            {
                float map_aptitud = Utilidades.Transformar(poblacion[i].Aptitud_Individuo(valor_esperado), 0, val_Max, 0, 1);
                int numero = (int)(map_aptitud) * 100;
                for (int j = 0; j < numero; j++)
                {
                    cont_elementos.Add(poblacion[i]);
                }
            }
        }

        public void Generar_Nueva_Poblacion()
        {

            for (int i = 0; i < poblacion.Length; i++)
            {
                Random r = new Random();
                int A = r.Next(0, cont_elementos.Count - 1);
                int B = r.Next(0, cont_elementos.Count - 1);
                Elemento madre = cont_elementos[A];
                Elemento padre = cont_elementos[B];
                Elemento hijo = madre.Reproduccion(padre);
                hijo.Mutacion(Tasa_mutacion);
                poblacion[i] = hijo;
            }
            this.generacion++;
        }

        //Seleccionar el mejor a través de la función Fitness
        public string Fitness()
        {
            float val_Max = 0;
            int indice = 0;
            for (int i = 0; i < poblacion.Length; i++)
            {
                if (poblacion[i].Aptitud_Individuo(valor_esperado) > val_Max)
                {
                    val_Max = poblacion[i].Aptitud_Individuo(valor_esperado);
                    indice = i;
                }
            }
            return new string(poblacion[indice].Genoma);
        }

        public float Tasa_mutacion { get => tasa_mutacion; set => tasa_mutacion = value; }
        public int Individuos { get => individuos; set => individuos = value; }
        public string Valor_esperado { get => valor_esperado; set => valor_esperado = value; }
        public int Generacion { get => generacion; set => generacion = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmo_Genetico_Cadena
{
    class Utilidades
    {
        public static float Transformar(float val, float x1, float x2, float y1, float y2)
        {
            return ((val - x1) / (x2 - x1)) * (y2 - y1) + y1;
        }
    }
}

using System;
using System.Collections.Generic;

namespace Snake
{
    // La clase Direccion representa las direcciones posibles en el juego (arriba, abajo, izquierda, derecha).
    public class Direccion
    {
        // direcciones posibles.
        public static Direccion Izquierda = new Direccion(0, -1);
        public static Direccion Derecha = new Direccion(0, 1);
        public static Direccion Arriba = new Direccion(-1, 0);
        public static Direccion Abajo = new Direccion(1, 0);

        // Propiedades de solo lectura para la fila y columna de la dirección.
        public int Fila { get; }
        public int Columna { get; }

        // Constructor privado para crear instancias de la clase Direccion.
        private Direccion(int fila, int columna)
        {
            this.Fila = fila;
            this.Columna = columna;
        }

        // Método para obtener la dirección opuesta.
        public Direccion Opposite()
        {
            return new Direccion(-Fila, -Columna);
        }

        // Métodos Equals y GetHashCode para permitir la comparación de direcciones.
        public override bool Equals(object? obj)
        {
            return obj is Direccion direccion &&
                   Fila == direccion.Fila &&
                   Columna == direccion.Columna;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Fila, Columna);
        }

        // Sobrecargas de operadores de igualdad para comparar direcciones, se crean con la opcion de acciones rapidas de visual Studio
        public static bool operator ==(Direccion? left, Direccion? right)
        {
            return EqualityComparer<Direccion>.Default.Equals(left, right);
        }

        public static bool operator !=(Direccion? left, Direccion? right)
        {
            return !(left == right);
        }
    }
}

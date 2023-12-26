using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    // La clase Posicion representa una posición en el tablero con filas y columnas.
    public class Posicion
    {

        public int Fila { get; }
        public int Columna { get; }

        // Constructor que inicializa las coordenadas de la posición.
        public Posicion(int Fila, int Columna)
        {
            this.Fila = Fila;
            this.Columna = Columna;
        }

        // Método para mover la posición según una dirección dada.
        public Posicion Translate(Direccion dir)
        {
            return new Posicion(Fila + dir.Fila, Columna + dir.Columna);
        }

        // Métodos Equals y GetHashCode para permitir la comparación de posiciones.
        public override bool Equals(object? obj)
        {
            return obj is Posicion posicion &&
                   Fila == posicion.Fila &&
                   Columna == posicion.Columna;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Fila, Columna);
        }

        // Sobrecargas de operadores de igualdad para simplificar la comparación, se realiza con las acciones rapidas de visual codeS
        public static bool operator ==(Posicion? left, Posicion? right)
        {
            return EqualityComparer<Posicion>.Default.Equals(left, right);
        }

        public static bool operator !=(Posicion? left, Posicion? right)
        {
            return !(left == right);
        }
    }
}

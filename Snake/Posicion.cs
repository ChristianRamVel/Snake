using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Posicion
    { 
        public int Fila { get; }
        public int Columna { get; }

        public Posicion(int Fila, int Columna)
        {
            this.Fila = Fila;
            this.Columna = Columna;
        }

        public Posicion Translate(Direccion dir) {

            return new Posicion(Fila + dir.Fila, Columna + dir.Columna);
        }

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

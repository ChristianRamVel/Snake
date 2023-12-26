using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Snake
{
    public class EstadoJuego
    {
        // Propiedades públicas de solo lectura que representan las dimensiones del tablero y su estado.
        public int Filas { get; }
        public int Columnas { get; }
        public GridValue[,] Grid { get; }
        public Direccion Dir { get; private set; }
        public int Score { get; private set; }
        public bool GameOver { get; private set; }

        //lista para guardar los cambios de direccion al jugar y asi no permitir que se hagan movimientos que no son correctos para la logica del juego, como por ejemplo
        //estar moviendote a la derecha y directamente intentar mvoerte ala izquierda.
        private readonly LinkedList<Direccion> cambiosDireccion = new LinkedList<Direccion>();
        private readonly LinkedList<Posicion> posicionesSerpiente = new LinkedList<Posicion>();
        private readonly Random random = new Random();

        // Constructor que inicializa el estado inicial del juego.
        public EstadoJuego(int filas, int columnas)
        {
            Filas = filas;
            Columnas = columnas;
            Grid = new GridValue[Filas, Columnas];
            Dir = Direccion.Derecha;

            anadirSnake();
            anadirComida();
        }

        // Método privado para inicializar la serpiente en el tablero.
        private void anadirSnake()
        {
            int r = Filas / 2;

            for (int c = 1; c <= 3; c++)
            {
                Grid[r, c] = GridValue.Snake;
                posicionesSerpiente.AddFirst(new Posicion(r, c));
            }
        }

        // Método privado que devuelve las posiciones vacías en el tablero.
        private IEnumerable<Posicion> PosicionesVacias()
        {
            for (int f = 0; f < Filas; f++)
            {
                for (int c = 0; c < Columnas; c++)
                {
                    if (Grid[f, c] == GridValue.Empty)
                    {
                        //yield se utiliza cuando se retornan colecciones, y lo que hace es retornar el valor concreto de esa coleccion dentro de el bucle for
                        yield return new Posicion(f, c);
                    }
                }
            }
        }

        // Método privado para agregar comida al tablero en una posición aleatoria.
        private void anadirComida()
        {
            List<Posicion> empty = new List<Posicion>(PosicionesVacias());

            if (empty.Count == 0)
            {
                return;
            }

            Posicion pos = empty[random.Next(empty.Count)];
            Grid[pos.Fila, pos.Columna] = GridValue.Food;
        }

        // Métodos para obtener la posición de la cabeza cuerpo y cola de la serpiente.
        public Posicion PosicionCabeza()
        {
            return posicionesSerpiente.First.Value;
        }

        public Posicion PosicionCola()
        {
            return posicionesSerpiente.Last.Value;
        }

        public IEnumerable<Posicion> PosicionesSnake()
        {
            return posicionesSerpiente;
        }

        // Método privado para agregar una nueva posición como cabeza de la serpiente.
        private void AnadirCabeza(Posicion pos)
        {
            posicionesSerpiente.AddFirst(pos);
            Grid[pos.Fila, pos.Columna] = GridValue.Snake;
        }

        // Método privado para borrar la cola de la serpiente.
        private void BorrarCola()
        {
            Posicion cola = posicionesSerpiente.Last.Value;
            Grid[cola.Fila, cola.Columna] = GridValue.Empty;
            posicionesSerpiente.RemoveLast();
        }

        // Método privado para obtener la última dirección registrada.
        private Direccion cogerUltuimaDireccion()
        {
            if (cambiosDireccion.Count == 0)
            {
                return Dir;
            }
            //si la cantidad de cambios de direccion es distinto de 0, retornamos el ultimo valor
            return cambiosDireccion.Last.Value;
        }

        // Método privado que verifica si se puede cambiar la dirección actual.
        private Boolean PuedeCambiarDireccion(Direccion nuevaDireccion)
        {
            if (cambiosDireccion.Count == 2)
            {
                return false;
            }

            Direccion ultimaDireccion = cogerUltuimaDireccion();
            //si no se cumplen que la nueva sea distinta a la ultima, o a la opuesta a la ultima, retornara false, si lo cumple, retornara true
            return nuevaDireccion != ultimaDireccion && nuevaDireccion != ultimaDireccion.Opposite();
        }

        // Método público para cambiar la dirección de la serpiente.
        public void CambioDeDireccion(Direccion dir)
        {
            if (PuedeCambiarDireccion(dir))
            {
                cambiosDireccion.AddLast(dir);
            }
        }

        // Método privado que verifica si una posición está fuera de los límites del tablero.
        private bool Limites(Posicion pos)
        {
            return pos.Fila < 0 || pos.Fila >= Filas || pos.Columna < 0 || pos.Columna >= Columnas;
        }

        // Método privado que determina qué objeto se encuentra en la posición especificada.
        private GridValue VaAChocar(Posicion nuevaPosicionCabeza)
        {
            if (Limites(nuevaPosicionCabeza))
            {
                return GridValue.Pared;
            }

            if (nuevaPosicionCabeza == PosicionCola())
            {
                return GridValue.Empty;
            }

            return Grid[nuevaPosicionCabeza.Fila, nuevaPosicionCabeza.Columna];
        }

        // Método público que realiza el movimiento de la serpiente.
        public void Mover()
        {
            if (cambiosDireccion.Count > 0)
            {
                Dir = cambiosDireccion.First.Value;
                cambiosDireccion.RemoveFirst();
            }

            Posicion nuevaPosicionCabeza = PosicionCabeza().Translate(Dir);
            GridValue hit = VaAChocar(nuevaPosicionCabeza);

            //si el siguiente movimiento es un limite del tablero o la propia snake, se pierde la partida
            if (hit == GridValue.Pared || hit == GridValue.Snake)
            {
                GameOver = true;
            }
            //si no, se borra la ultima posicion de la cola y se añade uno a la nueva posicion que va a tener en el siguiente movimiento
            else if (hit == GridValue.Empty)
            {
                BorrarCola();
                AnadirCabeza(nuevaPosicionCabeza);
            }
            //si el siguiente movimiento es comida,no borramos la cola, pero si añadimos la nueva posicion del siguiente movimiento y sumamos 1 a la variable Score
            else if (hit == GridValue.Food)
            {
                AnadirCabeza(nuevaPosicionCabeza);
                Score++;
                anadirComida();
            }
        }
    }
}

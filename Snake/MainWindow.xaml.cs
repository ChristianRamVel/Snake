// Importaciones de espacios de nombres necesarios para la aplicación WPF.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Snake
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Diccionario que mapea los valores del tablero a las imágenes correspondientes.
        private readonly Dictionary<GridValue, ImageSource> gridValToImage = new()
        {
            {GridValue.Empty, Imagenes.Empty },
            {GridValue.Snake, Imagenes.Body },
            {GridValue.Food, Imagenes.Food },
        };

        // Dimensiones del tablero y matriz de imágenes para representar el estado del juego.
        private readonly int rows = 15, cols = 15;
        private readonly Image[,] gridImages;
        private EstadoJuego estadoJuego;

        // Constructor de la ventana principal.
        public MainWindow()
        {
            InitializeComponent();
            gridImages = SetupGrid();  // Inicializa la matriz de imágenes que representan el tablero.
            estadoJuego = new EstadoJuego(rows, cols);  // Inicializa el estado del juego.
        }

        // Evento que se ejecuta cuando la ventana se carga por completo.
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Draw();  // Dibuja el estado inicial del juego.
            await GameLoop();  // Inicia el bucle principal del juego de forma asíncrona.
        }

        // Evento que se ejecuta cuando se presiona una tecla.
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (estadoJuego.GameOver)
            {
                return;
            }

            // Maneja la entrada del teclado para cambiar la dirección de la serpiente.
            switch (e.Key)
            {
                case Key.Left:
                    estadoJuego.CambioDeDireccion(Direccion.Izquierda);
                    break;
                case Key.Right:
                    estadoJuego.CambioDeDireccion(Direccion.Derecha);
                    break;
                case Key.Up:
                    estadoJuego.CambioDeDireccion(Direccion.Arriba);
                    break;
                case Key.Down:
                    estadoJuego.CambioDeDireccion(Direccion.Abajo);
                    break;
            }
        }

        // Bucle principal del juego que se ejecuta de forma asíncrona.
        private async Task GameLoop()
        {
            while (!estadoJuego.GameOver)
            {
                if (estadoJuego.Score < 10)
                {
                    await Task.Delay(200);  // Espera 300 milisegundos entre cada iteración del bucle.
                }
                else if (estadoJuego.Score < 20)
                {
                    await Task.Delay(150);
                }
                else {
                    await Task.Delay(100);
                }
                
                estadoJuego.Mover();  // Realiza el movimiento de la serpiente.
                
                // Utiliza Dispatcher.Invoke para asegurarte de que la actualización del UI se realice en el hilo de la interfaz de usuario.
                Dispatcher.Invoke(() =>
                {
                    Draw();  // Dibuja el nuevo estado del juego en la interfaz gráfica.
                });
            }
        }

        // Inicializa el tablero visual del juego y devuelve la matriz de imágenes asociada.
        private Image[,] SetupGrid()
        {
            Image[,] imagenes = new Image[rows, cols];
            GameGrid.Rows = rows;
            GameGrid.Columns = cols;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Image imagen = new Image
                    {
                        Source = Imagenes.Empty
                    };

                    imagenes[r, c] = imagen;
                    GameGrid.Children.Add(imagen);
                }
            }

            return imagenes;
        }

        // Método que actualiza la interfaz gráfica con el estado actual del juego.
        private void Draw()
        {
            DrawGrid();  // Dibuja el tablero del juego.
            ScoreText.Text = $"SCORE {estadoJuego.Score}";  // Actualiza el texto de puntuación.
        }

        // Método que actualiza la representación visual del tablero del juego.
        private void DrawGrid()
        {
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    GridValue gridVal = estadoJuego.Grid[r, c];
                    gridImages[r, c].Source = gridValToImage[gridVal];
                }
            }
        }
    }
}

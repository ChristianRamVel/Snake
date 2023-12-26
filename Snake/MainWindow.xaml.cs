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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly int filas = 15, columnas = 15;
        private readonly Image[,] gridImages;
        
        public MainWindow()
        {
            InitializeComponent();
            gridImages = SetupGrid();
        }

        private  Image[,] SetupGrid()
        {
            Image[,] imagenes = new Image[filas, columnas];
            GameGrid.Rows = filas;
            GameGrid.Columns = columnas;

            for(int r=0; r<filas; r++)
            {
                for(int c=0; c<columnas; c++)
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
    }
}

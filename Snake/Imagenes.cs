using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Snake
{
    public static class Imagenes
    {
        public readonly static   ImageSource Empty = CargarImagen("Empty.png");
        public readonly static ImageSource Body = CargarImagen("Body.png");
        public readonly static  ImageSource Food = CargarImagen("Food.png");


        private static ImageSource CargarImagen(string nombreArchivo)
        {   

            return new BitmapImage(new Uri($"Assets/{nombreArchivo}", UriKind.Relative));
        }
    }
}

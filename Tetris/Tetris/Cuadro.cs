using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    public class Cuadro
    {
        Point coordenadas;
        public bool Estado;
        public Pen color;
        public Rectangle Rect;
        Size tam = new Size(20, 20);
        
        public Cuadro(Point coord)
        {
            coordenadas = coord;
            Estado = false;
            color = new Pen(Color.Black);
            Rect = new Rectangle(coord, tam);
        }
    }
}

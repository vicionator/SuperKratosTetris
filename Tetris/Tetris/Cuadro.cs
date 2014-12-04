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
        public SolidBrush Brocha;
        public SolidBrush Brocha1;
        public SolidBrush Brocha2;
        public SolidBrush Brocha3;
        public SolidBrush Brocha4;
        public SolidBrush Brocha5;
        public SolidBrush Brocha6;
        public Rectangle Rect;
        Size tam = new Size(20, 20);
        
        public Cuadro(Point coord)
        {
            coordenadas = coord;
            Estado = false;
            color = new Pen(Color.Black);
            Brocha = new SolidBrush(Color.Red);
            Brocha1 = new SolidBrush(Color.Orange);
            Brocha2 = new SolidBrush(Color.Yellow);
            Brocha3 = new SolidBrush(Color.Green);
            Brocha4 = new SolidBrush(Color.Blue);
            Brocha5 = new SolidBrush(Color.Indigo);
            Brocha6 = new SolidBrush(Color.Violet);
            Rect = new Rectangle(coord, tam);
        }
    }
}

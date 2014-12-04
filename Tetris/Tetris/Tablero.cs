using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public class Tablero
    {
        public List<Cuadro> cuadritos = new List<Cuadro>();
        Point inicial = new Point(0, 0);
        Rectangle rect;
        
        

        public Tablero()
        {
        }
               
        public void CreacionTab()
        {
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    cuadritos.Add(new Cuadro(inicial));
                    
                    inicial.X += 20;
                }
                inicial.X = 0;
                inicial.Y += 20;
            }
        }
        public void Dibuja(PictureBox p) 
        {
            Graphics g = p.CreateGraphics();
            Size tam = new Size(20, 20);

            foreach (Cuadro c in cuadritos)
            {
                if (c.Estado == true)
                {
                    rect = new Rectangle(c.coordenadas, tam);
                    g.FillRectangle(c.Brocha4, rect);
                    ControlPaint.DrawBorder(g, rect, Color.Black, ButtonBorderStyle.Inset);
                }
            }
        }
    }
}

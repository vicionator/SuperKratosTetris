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
        List<Cuadro> cuadritos = new List<Cuadro>();
        Point inicial = new Point(0, 0);
        
        

        public Tablero()
        {
        }
               
        public void CreacionTab(PictureBox p)
        {
            Graphics g = p.CreateGraphics();

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
            foreach (Cuadro c in cuadritos)
            {
                g.DrawRectangle(c.color, c.Rect);

            }
        }
    }
}

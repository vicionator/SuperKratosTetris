using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public class Zeta
    {
        List<Cuadro> PiezaZ = new List<Cuadro>();
        bool agrega = false;

        public Zeta(Point co)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((i == 0 & j == 2) || (i == 1 & j == 0))
                    {
                        agrega = false;
                    }
                    else
                    {
                        agrega = true;
                    }
                    if (agrega == true)
                    {
                        PiezaZ.Add(new Cuadro(co));
                    }
                    co.X += 20;
                }
                co.X -= 60;
                co.Y += 20;
            }
        }
        public void Dibujar(PictureBox pb)
        {
            Graphics g = pb.CreateGraphics();
            Rectangle rect;
            Size tam = new Size(20, 20);

            foreach (Cuadro c in PiezaZ)
            {
                c.Estado = true;
                rect = new Rectangle(c.coordenadas, tam);
                g.FillRectangle(c.Brocha5, rect);
                ControlPaint.DrawBorder(g, rect, Color.Black, ButtonBorderStyle.Inset);
            }
        }
    }
}

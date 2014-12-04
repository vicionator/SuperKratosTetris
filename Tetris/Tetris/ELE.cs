using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public class ELE
    {
        List<Cuadro> PiezaL = new List<Cuadro>();
        bool agrega = false;

        public ELE(Point co)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 0) 
                    {
                        agrega = true;
                    }
                    else if (i == 1) 
                    {
                        agrega = false;
                    }
                    if (i == 1 && j == 2) 
                    {
                        agrega = true;
                    }
                    if (agrega == true)
                    {
                        PiezaL.Add(new Cuadro(co));
                    }
                    co.Y += 20;
                }
                co.Y -= 60;
                co.X += 20;
            }
        }
        public void Dibujar(PictureBox pb)
        {
            Graphics g = pb.CreateGraphics();

            foreach (Cuadro c in PiezaL)
            {
                g.FillRectangle(c.Brocha1, c.Rect);
                ControlPaint.DrawBorder(g, c.Rect, Color.Black, ButtonBorderStyle.Inset);
            }
        }
    }
}

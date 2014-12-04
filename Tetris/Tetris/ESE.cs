using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public class ESE
    {
        List<Cuadro> PiezaS = new List<Cuadro>();
        bool agrega = false;

        public ESE(Point co)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((i == 0 & j == 0) || (i == 1 & j == 2)) 
                    {
                        agrega = false;
                    }
                    else
                    {
                        agrega = true;
                    }
                    if (agrega == true)
                    {
                        PiezaS.Add(new Cuadro(co));
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

            foreach (Cuadro c in PiezaS)
            {
                g.FillRectangle(c.Brocha4, c.Rect);
                ControlPaint.DrawBorder(g, c.Rect, Color.Black, ButtonBorderStyle.Inset);
            }
        }
    }
}

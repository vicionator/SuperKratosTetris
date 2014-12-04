using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public class Jota
    {
        List<Cuadro> PiezaJ = new List<Cuadro>();
        bool agrega = false;

        public Jota(Point co)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 0) 
                    {
                        agrega = false;
                    }
                    else if (i == 1) 
                    {
                        agrega = true;
                    }
                    if (i == 0 && j == 2) 
                    {
                        agrega = true;
                    }
                    if (agrega == true)
                    {
                        PiezaJ.Add(new Cuadro(co));
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

            foreach (Cuadro c in PiezaJ)
            {
                g.FillRectangle(c.Brocha2, c.Rect);
                ControlPaint.DrawBorder(g, c.Rect, Color.Black, ButtonBorderStyle.Inset);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Tetris.Piezas;

namespace Tetris
{
    public class Jota:IPieza
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
            Rectangle rect;
            Size tam = new Size(20, 20);

            foreach (Cuadro c in PiezaJ)
            {
                c.Estado = true;
                rect = new Rectangle(c.coordenadas, tam);
                g.FillRectangle(c.Brocha2, rect);
                ControlPaint.DrawBorder(g, rect, Color.Black, ButtonBorderStyle.Inset);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public class Cubo
    {

        List<Cuadro> PiezaO = new List<Cuadro>();


        public Cubo(Point co)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    PiezaO.Add(new Cuadro(co));
                    co.X += 20;
                }
                co.X -= 40;
                co.Y += 20;
            }
        }
        public void Dibujar(PictureBox pb) 
        {
            Graphics g = pb.CreateGraphics();

            foreach (Cuadro c in PiezaO)
            {
                g.FillRectangle(c.Brocha, c.Rect);
                ControlPaint.DrawBorder(g, c.Rect, Color.Black, ButtonBorderStyle.Inset);
            }
        }
    }
}

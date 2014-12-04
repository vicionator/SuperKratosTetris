using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public class I
    {
        List<Cuadro> PiezaI = new List<Cuadro>();

        public I(Point co)
        {
            for (int i = 0; i < 4; i++)
            {
                PiezaI.Add(new Cuadro(co));
                co.X += 20;
            }
        }
        public void Dibujar(PictureBox pb)
        {
            Graphics g = pb.CreateGraphics();

            foreach (Cuadro c in PiezaI)
            {
                g.FillRectangle(c.Brocha3, c.Rect);
                ControlPaint.DrawBorder(g, c.Rect, Color.Black, ButtonBorderStyle.Inset);
            }
        }
    }
}

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
    public class I:IPieza
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
            Rectangle rect;
            Size tam = new Size(20, 20);

            foreach (Cuadro c in PiezaI)
            {
                c.Estado = true;
                rect = new Rectangle(c.coordenadas, tam);
                g.FillRectangle(c.Brocha3, rect);
                ControlPaint.DrawBorder(g, rect, Color.Black, ButtonBorderStyle.Inset);
            }
        }
    }
}

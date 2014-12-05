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
        public I()
        {
            
        }
        public List<Cuadro> Formar(Point co)
        {
            List<Cuadro> PiezaO = new List<Cuadro>();
            for (int i = 0; i < 4; i++)
            {
                PiezaO.Add(new Cuadro(co));
                co.X += 20;
            }
            return PiezaO;
        }
        public void Dibujar(ref List<Cuadro> PiezaO, PictureBox pb)
        {
            Graphics g = pb.CreateGraphics();
            Rectangle rect;
            Size tam = new Size(20, 20);

            foreach (Cuadro c in PiezaO)
            {
                c.Estado = true;
                rect = new Rectangle(c.coordenadas, tam);
                g.FillRectangle(c.Brocha3, rect);
                ControlPaint.DrawBorder(g, rect, Color.Black, ButtonBorderStyle.Inset);
            }
        }
        public void MoverDerecha(ref List<Cuadro> PiezaO, Tablero tab)
        {
            throw new NotImplementedException();
        }
        public void MoverIzquierda(ref List<Cuadro> PiezaO, Tablero tab)
        {
            throw new NotImplementedException();
        }
        public bool MoverAbajo(ref List<Cuadro> PiezaO, Tablero tab)
        {
            throw new NotImplementedException();
        }
        public void Rotar(ref List<Cuadro> PiezaO, Tablero tab)
        {
            throw new NotImplementedException();
        }


    }
}

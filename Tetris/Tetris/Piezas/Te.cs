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
    public class Te:IPieza
    {
        List<Cuadro> PiezaT = new List<Cuadro>();
        bool agrega = false;
        public Te()
        {

        }
        public Te(Point co)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((i == 1 & j == 2) || (i == 1 & j == 0))
                    {
                        agrega = false;
                    }
                    else
                    {
                        agrega = true;
                    }
                    if (agrega == true)
                    {
                        PiezaT.Add(new Cuadro(co));
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

            foreach (Cuadro c in PiezaT)
            {
                c.Estado = true;
                rect = new Rectangle(c.coordenadas, tam);
                g.FillRectangle(c.Brocha6, rect);
                ControlPaint.DrawBorder(g, rect, Color.Black, ButtonBorderStyle.Inset);
            }
        }

        public List<Cuadro> Formar(Point co)
        {
            throw new NotImplementedException();
        }

        public void Dibujar(List<Cuadro> PiezaO, PictureBox pb)
        {
            throw new NotImplementedException();
        }

        public void MoverDerecha(List<Cuadro> PiezaO, Tablero tab)
        {
            throw new NotImplementedException();
        }

        public void MoverIzquierda(List<Cuadro> PiezaO, Tablero tab)
        {
            throw new NotImplementedException();
        }

        public bool MoverAbajo(List<Cuadro> PiezaO, Tablero tab)
        {
            throw new NotImplementedException();
        }

        public void Rotar(List<Cuadro> PiezaO, Tablero tab)
        {
            throw new NotImplementedException();
        }


        public void Dibujar(ref List<Cuadro> PiezaO, PictureBox pb)
        {
            throw new NotImplementedException();
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

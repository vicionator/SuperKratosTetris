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
    public class ELE:IPieza
    {
        List<Cuadro> PiezaL = new List<Cuadro>();
        bool agrega = false;
        public ELE()
        {

        }
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
            Rectangle rect;
            Size tam = new Size(20, 20);

            foreach (Cuadro c in PiezaL)
            {
                c.Estado = true;
                rect = new Rectangle(c.coordenadas, tam);
                g.FillRectangle(c.Brocha1, rect);
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

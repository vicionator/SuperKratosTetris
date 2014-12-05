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

        public Jota()
        {

        }

        public List<Cuadro> Formar(Point co, OrientacionPieza op)
        {
            List<Cuadro> PiezaJ = new List<Cuadro>();
            bool agrega = false;
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
            return PiezaJ;
        }

        public void Dibujar(ref List<Cuadro> PiezaJ, PictureBox pb)
        {

            Graphics g = pb.CreateGraphics();
            Rectangle rect;
            Size tam = new Size(20, 20);

            foreach (Cuadro c in PiezaJ)
            {
                rect = new Rectangle(c.coordenadas, tam);
                g.FillRectangle(c.Brocha2, rect);
                ControlPaint.DrawBorder(g, rect, Color.Black, ButtonBorderStyle.Inset);
            }
        }

        public bool MoverAbajo(ref List<Cuadro> PiezaJ, Tablero tab)
        {
            bool verificar = false;
            foreach (Cuadro c in PiezaJ)
            {
                if (c.Estado == false)
                {
                    foreach (Cuadro ta in tab.cuadritos)
                    {
                        if (ta.Estado == true)
                        {
                            if ((ta.coordenadas.X == PiezaJ[0].coordenadas.X && ta.coordenadas.Y - 20 == PiezaJ[0].coordenadas.Y && ta.coordenadas.Y - 20 == PiezaJ[3].coordenadas.Y)
                                || (ta.coordenadas.X == PiezaJ[3].coordenadas.X && ta.coordenadas.Y - 20 == PiezaJ[3].coordenadas.Y
                                && ta.coordenadas.Y - 20 == PiezaJ[0].coordenadas.Y))
                            {
                                foreach (Cuadro c2 in PiezaJ)
                                {
                                    foreach (Cuadro t in tab.cuadritos)
                                    {
                                        if (c2.coordenadas.X == t.coordenadas.X && c2.coordenadas.Y == t.coordenadas.Y)
                                        {
                                            t.Estado = true;
                                            t.Brocha4 = c2.Brocha2;
                                        }
                                    }
                                    c2.Estado = true;
                                }
                                verificar = true;
                                break;
                            }
                        }
                    }
                    c.coordenadas.Y += 20;
                    if (PiezaJ[PiezaJ.Count - 1].coordenadas.Y == 380)
                    {
                        foreach (Cuadro c2 in PiezaJ)
                        {
                            foreach (Cuadro t in tab.cuadritos)
                            {
                                if (c2.coordenadas.X == t.coordenadas.X && c2.coordenadas.Y == t.coordenadas.Y)
                                {
                                    t.Estado = true;
                                    t.Brocha4 = c2.Brocha2;
                                }
                            }
                            c2.Estado = true;
                        }
                        verificar = true;
                        break;
                    }
                }
            }
            return verificar;

        }
        public void MoverDerecha(ref List<Cuadro> PiezaJ, Tablero tab)
        {
            bool mover = true;
            foreach (Cuadro c in PiezaJ)
            {
                if (c.Estado == false)
                {
                    foreach (Cuadro t in tab.cuadritos)
                    {
                        if (t.Estado == true)
                        {
                            if ((t.coordenadas.X == PiezaJ[2].coordenadas.X + 20 && t.coordenadas.Y == PiezaJ[2].coordenadas.Y)
                                || (t.coordenadas.X == PiezaJ[1].coordenadas.X + 20 && t.coordenadas.Y == PiezaJ[1].coordenadas.Y)
                                || (t.coordenadas.X == PiezaJ[3].coordenadas.X + 20 && t.coordenadas.Y == PiezaJ[3].coordenadas.Y))
                            {
                                //c.coordenadas.X -= 20;
                                mover = false;
                                break;
                            }
                        }
                    }
                    if ((PiezaJ[PiezaJ.Count - 1].coordenadas.X == 180))
                    {
                        mover = false;
                    }
                }
            }
            foreach (Cuadro c in PiezaJ)
            {
                if (mover)
                {
                    c.coordenadas.X += 20;
                }
            }

        }
        public void MoverIzquierda(ref List<Cuadro> PiezaJ, Tablero tab)
        {
            bool mover = true;
            foreach (Cuadro c in PiezaJ)
            {
                if (c.Estado == false)
                {
                    foreach (Cuadro t in tab.cuadritos)
                    {
                        if (t.Estado == true)
                        {
                            if ((t.coordenadas.X == PiezaJ[0].coordenadas.X - 20 && t.coordenadas.Y == PiezaJ[0].coordenadas.Y)
                                || (t.coordenadas.X == PiezaJ[1].coordenadas.X - 20 && t.coordenadas.Y == PiezaJ[1].coordenadas.Y)
                                || (t.coordenadas.X == PiezaJ[2].coordenadas.X - 20 && t.coordenadas.Y == PiezaJ[2].coordenadas.Y))
                            {
                                //c.coordenadas.X -= 20;
                                mover = false;
                                break;
                            }
                        }
                    }
                    if ((PiezaJ[0].coordenadas.X == 0))
                    {
                        mover = false;
                    }
                }
            }
            foreach (Cuadro c in PiezaJ)
            {
                if (mover)
                {
                    c.coordenadas.X -= 20;
                }
            }

        }
        public List<Cuadro> Rotar(Tablero tab, ref OrientacionPieza op)
        {
            throw new NotImplementedException();
        }
    }
}

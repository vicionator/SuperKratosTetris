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

        public List<Cuadro> Formar(Point co, OrientacionPieza op)
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
            return PiezaL;
        }

        public void Dibujar(ref List<Cuadro> PiezaL, PictureBox pb)
        {
            Graphics g = pb.CreateGraphics();
            Rectangle rect;
            Size tam = new Size(20, 20);

            foreach (Cuadro c in PiezaL)
            {
                c.Estado = false;
                rect = new Rectangle(c.coordenadas, tam);
                g.FillRectangle(c.Brocha1, rect);
                ControlPaint.DrawBorder(g, rect, Color.Black, ButtonBorderStyle.Inset);
            }
        }
        public bool MoverAbajo(ref List<Cuadro> PiezaL, Tablero tab)
        {
            bool verificar = false;
            foreach (Cuadro c in PiezaL)
            {
                if (c.Estado == false)
                {
                    foreach (Cuadro ta in tab.cuadritos)
                    {
                        if (ta.Estado == true)
                        {
                            if ((ta.coordenadas.X == PiezaL[PiezaL.Count - 1].coordenadas.X && ta.coordenadas.Y - 20 == PiezaL[PiezaL.Count - 1].coordenadas.Y)
                                || (ta.coordenadas.X == PiezaL[PiezaL.Count - 2].coordenadas.X && ta.coordenadas.Y - 20 == PiezaL[PiezaL.Count - 2].coordenadas.Y
                                && ta.coordenadas.Y - 20 == PiezaL[PiezaL.Count - 1].coordenadas.Y))
                            {
                                foreach (Cuadro c2 in PiezaL)
                                {
                                    foreach (Cuadro t in tab.cuadritos)
                                    {
                                        if (c2.coordenadas.X == t.coordenadas.X && c2.coordenadas.Y == t.coordenadas.Y)
                                        {
                                            t.Estado = true;
                                            t.Brocha4 = c2.Brocha1;
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
                    if (PiezaL[PiezaL.Count - 1].coordenadas.Y == 380)
                    {
                        foreach (Cuadro c2 in PiezaL)
                        {
                            foreach (Cuadro t in tab.cuadritos)
                            {
                                if (c2.coordenadas.X == t.coordenadas.X && c2.coordenadas.Y == t.coordenadas.Y)
                                {
                                    t.Estado = true;
                                    t.Brocha4 = c2.Brocha1;
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
        public void MoverDerecha(ref List<Cuadro> PiezaL, Tablero tab)
        {
            bool mover = true;
            foreach (Cuadro c in PiezaL)
            {
                if (c.Estado == false)
                {
                    foreach (Cuadro t in tab.cuadritos)
                    {
                        if (t.Estado == true)
                        {
                            if ((t.coordenadas.X == PiezaL[3].coordenadas.X + 20 && t.coordenadas.Y == PiezaL[3].coordenadas.Y)
                                || (t.coordenadas.X == PiezaL[1].coordenadas.X + 20 && t.coordenadas.Y == PiezaL[1].coordenadas.Y))
                            {
                                //c.coordenadas.X -= 20;
                                mover = false;
                                break;
                            }
                        }
                    }
                    if ((PiezaL[PiezaL.Count - 1].coordenadas.X == 180))
                    {
                        mover = false;
                    }
                }
            }
            foreach (Cuadro c in PiezaL)
            {
                if (mover)
                {
                    c.coordenadas.X += 20;
                }
            }

        }
        public void MoverIzquierda(ref List<Cuadro> PiezaL, Tablero tab)
        {
            bool mover = true;
            foreach (Cuadro c in PiezaL)
            {
                if (c.Estado == false)
                {
                    foreach (Cuadro t in tab.cuadritos)
                    {
                        if (t.Estado == true)
                        {
                            if ((t.coordenadas.X == PiezaL[2].coordenadas.X - 20 && t.coordenadas.Y == PiezaL[2].coordenadas.Y)
                                || (t.coordenadas.X == PiezaL[0].coordenadas.X - 20 && t.coordenadas.Y == PiezaL[0].coordenadas.Y)
                                || (t.coordenadas.X == PiezaL[1].coordenadas.X - 20 && t.coordenadas.Y == PiezaL[1].coordenadas.Y))
                            {
                                //c.coordenadas.X -= 20;
                                mover = false;
                                break;
                            }
                        }
                    }
                    if ((PiezaL[2].coordenadas.X == 0))
                    {
                        mover = false;
                    }
                }
            }
            foreach (Cuadro c in PiezaL)
            {
                if (mover)
                {
                    c.coordenadas.X -= 20;
                }
            }

        }
        public List<Cuadro> Rotar(Tablero tab, ref OrientacionPieza op, List<Cuadro> Pieza)
        {
            throw new NotImplementedException();
        }
    }
}

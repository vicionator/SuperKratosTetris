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
    public class Te :IPieza
    {
        List<Cuadro> PiezaT = new List<Cuadro>();
        bool agrega = false;
        public Te()
        {

        }

        public List<Cuadro> Formar(Point co, OrientacionPieza op)
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
            return PiezaT;
        }

        public void Dibujar(ref List<Cuadro> PiezaT, PictureBox pb)
        {
            Graphics g = pb.CreateGraphics();
            Rectangle rect;
            Size tam = new Size(20, 20);

            foreach (Cuadro c in PiezaT)
            {
                rect = new Rectangle(c.coordenadas, tam);
                g.FillRectangle(c.Brocha6, rect);
                ControlPaint.DrawBorder(g, rect, Color.Black, ButtonBorderStyle.Inset);
            }
        }
        public bool MoverAbajo(ref List<Cuadro> PiezaT, Tablero tab)
        {
            bool verificar = false;
            foreach (Cuadro c in PiezaT)
            {
                if (c.Estado == false)
                {
                    foreach (Cuadro ta in tab.cuadritos)
                    {
                        if (ta.Estado == true)
                        {
                            if ((ta.coordenadas.X == PiezaT[3].coordenadas.X && ta.coordenadas.Y - 20 == PiezaT[3].coordenadas.Y )
                                || (ta.coordenadas.X == PiezaT[0].coordenadas.X && ta.coordenadas.Y - 20 == PiezaT[0].coordenadas.Y && ta.coordenadas.Y == PiezaT[3].coordenadas.Y)
                                || (ta.coordenadas.X == PiezaT[2].coordenadas.X && ta.coordenadas.Y - 20 == PiezaT[2].coordenadas.Y && ta.coordenadas.Y - 20 == PiezaT[0].coordenadas.Y && ta.coordenadas.Y == PiezaT[3].coordenadas.Y))
                            {
                                foreach (Cuadro c2 in PiezaT)
                                {
                                    foreach (Cuadro t in tab.cuadritos)
                                    {
                                        if (c2.coordenadas.X == t.coordenadas.X && c2.coordenadas.Y == t.coordenadas.Y)
                                        {
                                            t.Estado = true;
                                            t.Brocha4 = c2.Brocha6;
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
                    if (PiezaT[PiezaT.Count - 1].coordenadas.Y == 380)
                    {
                        foreach (Cuadro c2 in PiezaT)
                        {
                            foreach (Cuadro t in tab.cuadritos)
                            {
                                if (c2.coordenadas.X == t.coordenadas.X && c2.coordenadas.Y == t.coordenadas.Y)
                                {
                                    t.Estado = true;
                                    t.Brocha4 = c2.Brocha6;
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
        public void MoverDerecha(ref List<Cuadro> PiezaT, Tablero tab)
        {
            bool mover = true;
            foreach (Cuadro c in PiezaT)
            {
                if (c.Estado == false)
                {
                    foreach (Cuadro t in tab.cuadritos)
                    {
                        if (t.Estado == true)
                        {
                            if ((t.coordenadas.X == PiezaT[3].coordenadas.X + 20 && t.coordenadas.Y == PiezaT[3].coordenadas.Y)
                                || (t.coordenadas.X == PiezaT[2].coordenadas.X + 20 && t.coordenadas.Y == PiezaT[2].coordenadas.Y))
                            {
                                //c.coordenadas.X -= 20;
                                mover = false;
                                break;
                            }
                        }
                    }
                    if ((PiezaT[2].coordenadas.X == 180))
                    {
                        mover = false;
                    }
                }
            }
            foreach (Cuadro c in PiezaT)
            {
                if (mover)
                {
                    c.coordenadas.X += 20;
                }
            }

        }
        public void MoverIzquierda(ref List<Cuadro> PiezaT, Tablero tab)
        {
            bool mover = true;
            foreach (Cuadro c in PiezaT)
            {
                if (c.Estado == false)
                {
                    foreach (Cuadro t in tab.cuadritos)
                    {
                        if (t.Estado == true)
                        {
                            if ((t.coordenadas.X == PiezaT[3].coordenadas.X - 20 && t.coordenadas.Y == PiezaT[3].coordenadas.Y)
                                || (t.coordenadas.X == PiezaT[0].coordenadas.X - 20 && t.coordenadas.Y == PiezaT[0].coordenadas.Y))
                            {
                                //c.coordenadas.X -= 20;
                                mover = false;
                                break;
                            }
                        }
                    }
                    if ((PiezaT[0].coordenadas.X == 0))
                    {
                        mover = false;
                    }
                }
            }
            foreach (Cuadro c in PiezaT)
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

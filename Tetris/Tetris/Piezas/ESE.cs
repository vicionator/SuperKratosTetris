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
    public class ESE:IPieza
    {
        
        
        public ESE()
        {

        }
        public List<Cuadro> Formar(Point co, OrientacionPieza op)
        {
            List<Cuadro> PiezaS = new List<Cuadro>();
            bool agrega = false;
            if (op == OrientacionPieza.Arriba||op==OrientacionPieza.Abajo)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if ((i == 0 & j == 0) || (i == 1 & j == 2))
                        {
                            agrega = false;
                        }
                        else
                        {
                            agrega = true;
                        }
                        if (agrega == true)
                        {
                            PiezaS.Add(new Cuadro(co));
                        }
                        co.X += 20;
                    }
                    co.X -= 60;
                    co.Y += 20;
                }
            }
            else if (op == OrientacionPieza.Derecha||op == OrientacionPieza.Izquierda)
            {
                PiezaS.Add(new Cuadro(new Point(co.X - 20, co.Y - 20)));
                PiezaS.Add(new Cuadro(new Point(co.X - 20, co.Y)));
                PiezaS.Add(new Cuadro(new Point(co.X, co.Y + 20)));
                PiezaS.Add(new Cuadro(new Point(co.X, co.Y)));
            }
            return PiezaS;
        }
        public void Dibujar(ref List<Cuadro> PiezaS, PictureBox pb)
        {
            Graphics g = pb.CreateGraphics();
            Rectangle rect;
            Size tam = new Size(20, 20);

            foreach (Cuadro c in PiezaS)
            {
                rect = new Rectangle(c.coordenadas, tam);
                g.FillRectangle(c.Brocha4, rect);
                ControlPaint.DrawBorder(g, rect, Color.Black, ButtonBorderStyle.Inset);
            }
        }
        public bool MoverAbajo(ref List<Cuadro> PiezaS, Tablero tab, OrientacionPieza op)
        {
            bool verificar = false;
            foreach (Cuadro c in PiezaS)
            {
                if (c.Estado == false)
                {
                    foreach (Cuadro ta in tab.cuadritos)
                    {
                        if (ta.Estado == true)
                        {
                            if ((ta.coordenadas.X == PiezaS[3].coordenadas.X && ta.coordenadas.Y - 20 == PiezaS[3].coordenadas.Y && ta.coordenadas.Y -20 == PiezaS[2].coordenadas.Y)
                                || (ta.coordenadas.X == PiezaS[2].coordenadas.X && ta.coordenadas.Y - 20 == PiezaS[2].coordenadas.Y && ta.coordenadas.Y - 20 == PiezaS[3].coordenadas.Y)
                                || (ta.coordenadas.X == PiezaS[1].coordenadas.X && ta.coordenadas.Y - 20 == PiezaS[1].coordenadas.Y && ta.coordenadas.Y - 20 == PiezaS[1].coordenadas.Y && ta.coordenadas.Y - 20 == PiezaS[1].coordenadas.Y && ta.coordenadas.Y == PiezaS[3].coordenadas.Y))
                            {
                                foreach (Cuadro c2 in PiezaS)
                                {
                                    foreach (Cuadro t in tab.cuadritos)
                                    {
                                        if (c2.coordenadas.X == t.coordenadas.X && c2.coordenadas.Y == t.coordenadas.Y)
                                        {
                                            t.Estado = true;
                                            t.Brocha4 = c2.Brocha4;
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
                    if (PiezaS[PiezaS.Count - 1].coordenadas.Y == 380)
                    {
                        foreach (Cuadro c2 in PiezaS)
                        {
                            foreach (Cuadro t in tab.cuadritos)
                            {
                                if (c2.coordenadas.X == t.coordenadas.X && c2.coordenadas.Y == t.coordenadas.Y)
                                {
                                    t.Estado = true;
                                    t.Brocha4 = c2.Brocha4;
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
        public void MoverDerecha(ref List<Cuadro> PiezaS, Tablero tab, OrientacionPieza op)
        {
            bool mover = true;
            foreach (Cuadro c in PiezaS)
            {
                if (c.Estado == false)
                {
                    foreach (Cuadro t in tab.cuadritos)
                    {
                        if (t.Estado == true)
                        {
                            if ((t.coordenadas.X == PiezaS[3].coordenadas.X + 20 && t.coordenadas.Y == PiezaS[3].coordenadas.Y)
                                || (t.coordenadas.X == PiezaS[1].coordenadas.X + 20 && t.coordenadas.Y == PiezaS[1].coordenadas.Y))
                            {
                                //c.coordenadas.X -= 20;
                                mover = false;
                                break;
                            }
                        }
                    }
                    if ((PiezaS[1].coordenadas.X == 180))
                    {
                        mover = false;
                    }
                }
            }
            foreach (Cuadro c in PiezaS)
            {
                if (mover)
                {
                    c.coordenadas.X += 20;
                }
            }

        }
        public void MoverIzquierda(ref List<Cuadro> PiezaS, Tablero tab, OrientacionPieza op)
        {
            bool mover = true;
            foreach (Cuadro c in PiezaS)
            {
                if (c.Estado == false)
                {
                    foreach (Cuadro t in tab.cuadritos)
                    {
                        if (t.Estado == true)
                        {
                            if ((t.coordenadas.X == PiezaS[2].coordenadas.X - 20 && t.coordenadas.Y == PiezaS[2].coordenadas.Y)
                                || (t.coordenadas.X == PiezaS[0].coordenadas.X - 20 && t.coordenadas.Y == PiezaS[0].coordenadas.Y))
                            {
                                //c.coordenadas.X -= 20;
                                mover = false;
                                break;
                            }
                        }
                    }
                    if ((PiezaS[2].coordenadas.X == 0))
                    {
                        mover = false;
                    }
                }
            }
            foreach (Cuadro c in PiezaS)
            {
                if (mover)
                {
                    c.coordenadas.X -= 20;
                }
            }

        }
        public List<Cuadro> Rotar(Tablero tab, ref OrientacionPieza op, List<Cuadro> Pieza)
        {
            switch(op)
            {
                case OrientacionPieza.Arriba:
                    op = OrientacionPieza.Izquierda;
                    break;
                case OrientacionPieza.Izquierda:
                    op = OrientacionPieza.Abajo;
                    break;
                case OrientacionPieza.Abajo:
                    op = OrientacionPieza.Derecha;
                    break;
                case OrientacionPieza.Derecha:
                    op = OrientacionPieza.Arriba;
                    break;
            }
            return Formar(Pieza[3].coordenadas, op);
        }
    }
}

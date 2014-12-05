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

        public ELE()
        {

        }

        public List<Cuadro> Formar(Point co, OrientacionPieza op)
        {
            List<Cuadro> PiezaL = new List<Cuadro>();
            bool agrega = false;
            if (op == OrientacionPieza.Arriba) 
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
            if (op == OrientacionPieza.Izquierda) 
            {
                PiezaL.Add(new Cuadro(new Point(co.X - 40, co.Y)));
                PiezaL.Add(new Cuadro(new Point(co.X - 20, co.Y)));
                PiezaL.Add(new Cuadro(new Point(co.X, co.Y)));
                PiezaL.Add(new Cuadro(new Point(co.X, co.Y-20)));
            }
            if (op == OrientacionPieza.Abajo) 
            {
                PiezaL.Add(new Cuadro(new Point(co.X, co.Y + 20)));
                PiezaL.Add(new Cuadro(new Point(co.X, co.Y)));
                PiezaL.Add(new Cuadro(new Point(co.X, co.Y-20)));
                PiezaL.Add(new Cuadro(new Point(co.X - 20, co.Y - 20)));
            }
            if (op == OrientacionPieza.Derecha) 
            {
                PiezaL.Add(new Cuadro(new Point(co.X + 40, co.Y)));
                PiezaL.Add(new Cuadro(new Point(co.X + 20, co.Y)));
                PiezaL.Add(new Cuadro(new Point(co.X, co.Y)));
                PiezaL.Add(new Cuadro(new Point(co.X, co.Y + 20)));
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
        public bool MoverAbajo(ref List<Cuadro> PiezaL, Tablero tab, OrientacionPieza op)
        {
            bool verificar = false;
            if (op == OrientacionPieza.Arriba)
            {
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
            }
            if (op == OrientacionPieza.Izquierda) 
            {
                foreach (Cuadro c in PiezaL)
                {
                    if (c.Estado == false)
                    {
                        foreach (Cuadro ta in tab.cuadritos)
                        {
                            if (ta.Estado == true)
                            {
                                if ((ta.coordenadas.X == PiezaL[0].coordenadas.X && ta.coordenadas.Y - 20 == PiezaL[0].coordenadas.Y && ta.coordenadas.Y - 40 == PiezaL[3].coordenadas.Y)
                                    || (ta.coordenadas.X == PiezaL[1].coordenadas.X && ta.coordenadas.Y - 20 == PiezaL[1].coordenadas.Y && ta.coordenadas.Y - 40 == PiezaL[3].coordenadas.Y)
                                    || (ta.coordenadas.X == PiezaL[2].coordenadas.X && ta.coordenadas.Y - 20 == PiezaL[2].coordenadas.Y && ta.coordenadas.Y - 40 == PiezaL[3].coordenadas.Y))
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
                        if (PiezaL[0].coordenadas.Y == 380 && PiezaL[3].coordenadas.Y == 360)
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
            }
            if (op == OrientacionPieza.Abajo) 
            {
                foreach (Cuadro c in PiezaL)
                {
                    if (c.Estado == false)
                    {
                        foreach (Cuadro ta in tab.cuadritos)
                        {
                            if (ta.Estado == true)
                            {
                                if ((ta.coordenadas.X == PiezaL[0].coordenadas.X && ta.coordenadas.Y - 20 == PiezaL[0].coordenadas.Y && ta.coordenadas.Y - 60 == PiezaL[3].coordenadas.Y)
                                    || (ta.coordenadas.X == PiezaL[3].coordenadas.X && ta.coordenadas.Y - 20 == PiezaL[3].coordenadas.Y))
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
                        if (PiezaL[0].coordenadas.Y == 380 && PiezaL[3].coordenadas.Y == 340)
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
            }
            if (op == OrientacionPieza.Derecha) 
            {
                foreach (Cuadro c in PiezaL)
                {
                    if (c.Estado == false)
                    {
                        foreach (Cuadro ta in tab.cuadritos)
                        {
                            if (ta.Estado == true)
                            {
                                if ((ta.coordenadas.X == PiezaL[0].coordenadas.X && ta.coordenadas.Y - 20 == PiezaL[0].coordenadas.Y && ta.coordenadas.Y == PiezaL[3].coordenadas.Y)
                                    || (ta.coordenadas.X == PiezaL[1].coordenadas.X && ta.coordenadas.Y - 20 == PiezaL[1].coordenadas.Y && ta.coordenadas.Y == PiezaL[3].coordenadas.Y)
                                    || (ta.coordenadas.X == PiezaL[3].coordenadas.X && ta.coordenadas.Y - 20 == PiezaL[3].coordenadas.Y))
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
                        if (PiezaL[0].coordenadas.Y == 360 && PiezaL[3].coordenadas.Y == 380)
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
            }
            return verificar;

        }
        public void MoverDerecha(ref List<Cuadro> PiezaL, Tablero tab, OrientacionPieza op)
        {
            bool mover = true;
            if (op == OrientacionPieza.Arriba)
            {
                foreach (Cuadro c in PiezaL)
                {
                    if (c.Estado == false)
                    {
                        foreach (Cuadro t in tab.cuadritos)
                        {
                            if (t.Estado == true)
                            {
                                if ((t.coordenadas.X == PiezaL[3].coordenadas.X + 20 && t.coordenadas.Y == PiezaL[3].coordenadas.Y)
                                    || (t.coordenadas.X == PiezaL[1].coordenadas.X + 20 && t.coordenadas.Y == PiezaL[1].coordenadas.Y)
                                    || (t.coordenadas.X == PiezaL[0].coordenadas.X + 20 && t.coordenadas.Y == PiezaL[0].coordenadas.Y))
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
            }
            if (op == OrientacionPieza.Izquierda) 
            {
                foreach (Cuadro c in PiezaL)
                {
                    if (c.Estado == false)
                    {
                        foreach (Cuadro t in tab.cuadritos)
                        {
                            if (t.Estado == true)
                            {
                                if ((t.coordenadas.X == PiezaL[3].coordenadas.X + 20 && t.coordenadas.Y == PiezaL[3].coordenadas.Y)
                                    || (t.coordenadas.X == PiezaL[2].coordenadas.X + 20 && t.coordenadas.Y == PiezaL[2].coordenadas.Y))
                                {
                                    //c.coordenadas.X -= 20;
                                    mover = false;
                                    break;
                                }
                            }
                        }
                        if ((PiezaL[3].coordenadas.X == 180))
                        {
                            mover = false;
                        }
                    }
                }
            }
            if (op == OrientacionPieza.Abajo) 
            {
                foreach (Cuadro c in PiezaL)
                {
                    if (c.Estado == false)
                    {
                        foreach (Cuadro t in tab.cuadritos)
                        {
                            if (t.Estado == true)
                            {
                                if ((t.coordenadas.X == PiezaL[1].coordenadas.X + 20 && t.coordenadas.Y == PiezaL[1].coordenadas.Y)
                                    || (t.coordenadas.X == PiezaL[2].coordenadas.X + 20 && t.coordenadas.Y == PiezaL[2].coordenadas.Y)
                                    || (t.coordenadas.X == PiezaL[0].coordenadas.X + 20 && t.coordenadas.Y == PiezaL[0].coordenadas.Y))
                                {
                                    //c.coordenadas.X -= 20;
                                    mover = false;
                                    break;
                                }
                            }
                        }
                        if ((PiezaL[2].coordenadas.X == 180))
                        {
                            mover = false;
                        }
                    }
                }
            }
            if (op == OrientacionPieza.Derecha) 
            {
                foreach (Cuadro c in PiezaL)
                {
                    if (c.Estado == false)
                    {
                        foreach (Cuadro t in tab.cuadritos)
                        {
                            if (t.Estado == true)
                            {
                                if ((t.coordenadas.X == PiezaL[3].coordenadas.X + 20 && t.coordenadas.Y == PiezaL[3].coordenadas.Y)
                                    || (t.coordenadas.X == PiezaL[0].coordenadas.X + 20 && t.coordenadas.Y == PiezaL[0].coordenadas.Y))
                                {
                                    //c.coordenadas.X -= 20;
                                    mover = false;
                                    break;
                                }
                            }
                        }
                        if ((PiezaL[0].coordenadas.X == 180))
                        {
                            mover = false;
                        }
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
        public void MoverIzquierda(ref List<Cuadro> PiezaL, Tablero tab, OrientacionPieza op)
        {
            bool mover = true;
            if (op == OrientacionPieza.Arriba)
            {

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
            }
            if (op == OrientacionPieza.Izquierda) 
            {
                foreach (Cuadro c in PiezaL)
                {
                    if (c.Estado == false)
                    {
                        foreach (Cuadro t in tab.cuadritos)
                        {
                            if (t.Estado == true)
                            {
                                if ((t.coordenadas.X == PiezaL[3].coordenadas.X - 20 && t.coordenadas.Y == PiezaL[3].coordenadas.Y)
                                    || (t.coordenadas.X == PiezaL[0].coordenadas.X - 20 && t.coordenadas.Y == PiezaL[0].coordenadas.Y))
                                {
                                    //c.coordenadas.X -= 20;
                                    mover = false;
                                    break;
                                }
                            }
                        }
                        if ((PiezaL[0
                            
                            ].coordenadas.X == 0))
                        {
                            mover = false;
                        }
                    }
                }
            }
            if (op == OrientacionPieza.Abajo) 
            {
                foreach (Cuadro c in PiezaL)
                {
                    if (c.Estado == false)
                    {
                        foreach (Cuadro t in tab.cuadritos)
                        {
                            if (t.Estado == true)
                            {
                                if ((t.coordenadas.X == PiezaL[3].coordenadas.X - 20 && t.coordenadas.Y == PiezaL[3].coordenadas.Y)
                                    || (t.coordenadas.X == PiezaL[0].coordenadas.X - 20 && t.coordenadas.Y == PiezaL[0].coordenadas.Y)
                                    || (t.coordenadas.X == PiezaL[1].coordenadas.X - 20 && t.coordenadas.Y == PiezaL[1].coordenadas.Y))
                                {
                                    //c.coordenadas.X -= 20;
                                    mover = false;
                                    break;
                                }
                            }
                        }
                        if ((PiezaL[3].coordenadas.X == 0))
                        {
                            mover = false;
                        }
                    }
                }
            }
            if (op == OrientacionPieza.Derecha) 
            {
                foreach (Cuadro c in PiezaL)
                {
                    if (c.Estado == false)
                    {
                        foreach (Cuadro t in tab.cuadritos)
                        {
                            if (t.Estado == true)
                            {
                                if ((t.coordenadas.X == PiezaL[2].coordenadas.X - 20 && t.coordenadas.Y == PiezaL[2].coordenadas.Y)
                                    || (t.coordenadas.X == PiezaL[3].coordenadas.X - 20 && t.coordenadas.Y == PiezaL[3].coordenadas.Y))
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
            switch (op)
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
            return Formar(Pieza[2].coordenadas, op);
        }
    }
}

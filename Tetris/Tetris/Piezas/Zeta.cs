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
    [Serializable]
    public class Zeta:IPieza
    {
        public Zeta()
        {

        }
        public List<Cuadro> Formar(Point co, OrientacionPieza op)
        {
            List<Cuadro> PiezaZ = new List<Cuadro>();
            bool agrega = false;
            if (op == OrientacionPieza.Arriba || op == OrientacionPieza.Abajo)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if ((i == 0 & j == 2) || (i == 1 & j == 0))
                        {
                            agrega = false;
                        }
                        else
                        {
                            agrega = true;
                        }
                        if (agrega == true)
                        {
                            PiezaZ.Add(new Cuadro(co));
                        }
                        co.X += 20;
                    }
                    co.X -= 60;
                    co.Y += 20;
                }
            }
            else if (op == OrientacionPieza.Derecha || op == OrientacionPieza.Izquierda)
            {
                PiezaZ.Add(new Cuadro(new Point(co.X - 20, co.Y + 20)));
                PiezaZ.Add(new Cuadro(new Point(co.X - 20, co.Y)));
                PiezaZ.Add(new Cuadro(new Point(co.X, co.Y)));
                PiezaZ.Add(new Cuadro(new Point(co.X, co.Y-20)));
            }
            return PiezaZ;
        }

        public void Dibujar(ref List<Cuadro> PiezaZ, PictureBox pb)
        {
            Graphics g = pb.CreateGraphics();
            Rectangle rect;
            Size tam = new Size(20, 20);

            foreach (Cuadro c in PiezaZ)
            {
                rect = new Rectangle(c.coordenadas, tam);
                g.FillRectangle(c.Brocha5, rect);
                ControlPaint.DrawBorder(g, rect, Color.Black, ButtonBorderStyle.Inset);
            }
        }
        public bool MoverAbajo(ref List<Cuadro> PiezaZ, Tablero tab,OrientacionPieza op)
        {
            bool verificar = false;
            if (op == OrientacionPieza.Arriba || op == OrientacionPieza.Abajo)
            {

                foreach (Cuadro c in PiezaZ)
                {
                    if (c.Estado == false)
                    {
                        foreach (Cuadro ta in tab.cuadritos)
                        {
                            if (ta.Estado == true)
                            {
                                if ((ta.coordenadas.X == PiezaZ[3].coordenadas.X && ta.coordenadas.Y - 20 == PiezaZ[3].coordenadas.Y)
                                    || (ta.coordenadas.X == PiezaZ[2].coordenadas.X && ta.coordenadas.Y - 20 == PiezaZ[2].coordenadas.Y && ta.coordenadas.Y - 20 == PiezaZ[3].coordenadas.Y)
                                    || (ta.coordenadas.X == PiezaZ[0].coordenadas.X && ta.coordenadas.Y - 20 == PiezaZ[0].coordenadas.Y && ta.coordenadas.Y == PiezaZ[3].coordenadas.Y))
                                {
                                    foreach (Cuadro c2 in PiezaZ)
                                    {
                                        foreach (Cuadro t in tab.cuadritos)
                                        {
                                            if (c2.coordenadas.X == t.coordenadas.X && c2.coordenadas.Y == t.coordenadas.Y)
                                            {
                                                t.Estado = true;
                                                t.Brocha4 = c2.Brocha5;
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
                        if (PiezaZ[PiezaZ.Count - 1].coordenadas.Y == 380)
                        {
                            foreach (Cuadro c2 in PiezaZ)
                            {
                                foreach (Cuadro t in tab.cuadritos)
                                {
                                    if (c2.coordenadas.X == t.coordenadas.X && c2.coordenadas.Y == t.coordenadas.Y)
                                    {
                                        t.Estado = true;
                                        t.Brocha4 = c2.Brocha5;
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
            if (op == OrientacionPieza.Derecha || op == OrientacionPieza.Izquierda) 
            {
                foreach (Cuadro c in PiezaZ)
                {
                    if (c.Estado == false)
                    {
                        foreach (Cuadro ta in tab.cuadritos)
                        {
                            if (ta.Estado == true)
                            {
                                if ((ta.coordenadas.X == PiezaZ[2].coordenadas.X && ta.coordenadas.Y - 20 == PiezaZ[2].coordenadas.Y && PiezaZ[3].coordenadas.Y == ta.coordenadas.Y - 40)
                                    || (ta.coordenadas.X == PiezaZ[0].coordenadas.X && ta.coordenadas.Y - 20 == PiezaZ[0].coordenadas.Y && PiezaZ[3].coordenadas.Y == ta.coordenadas.Y - 60))
                                {
                                    foreach (Cuadro c2 in PiezaZ)
                                    {
                                        foreach (Cuadro t in tab.cuadritos)
                                        {
                                            if (c2.coordenadas.X == t.coordenadas.X && c2.coordenadas.Y == t.coordenadas.Y)
                                            {
                                                t.Estado = true;
                                                t.Brocha4 = c2.Brocha5;
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
                        if (PiezaZ[0].coordenadas.Y == 380 && PiezaZ[3].coordenadas.Y == 340)
                        {
                            foreach (Cuadro c2 in PiezaZ)
                            {
                                foreach (Cuadro t in tab.cuadritos)
                                {
                                    if (c2.coordenadas.X == t.coordenadas.X && c2.coordenadas.Y == t.coordenadas.Y)
                                    {
                                        t.Estado = true;
                                        t.Brocha4 = c2.Brocha5;
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
        public void MoverDerecha(ref List<Cuadro> PiezaZ, Tablero tab, OrientacionPieza op)
        {
            bool mover = true;
            if (op == OrientacionPieza.Arriba || op == OrientacionPieza.Abajo)
            {

                foreach (Cuadro c in PiezaZ)
                {
                    if (c.Estado == false)
                    {
                        foreach (Cuadro t in tab.cuadritos)
                        {
                            if (t.Estado == true)
                            {
                                if ((t.coordenadas.X == PiezaZ[3].coordenadas.X + 20 && t.coordenadas.Y == PiezaZ[3].coordenadas.Y)
                                    || (t.coordenadas.X == PiezaZ[1].coordenadas.X + 20 && t.coordenadas.Y == PiezaZ[1].coordenadas.Y))
                                {
                                    //c.coordenadas.X -= 20;
                                    mover = false;
                                    break;
                                }
                            }
                        }
                        if ((PiezaZ[PiezaZ.Count - 1].coordenadas.X == 180))
                        {
                            mover = false;
                        }
                    }
                }
            }
            if (op == OrientacionPieza.Derecha || op == OrientacionPieza.Izquierda) 
            {
                foreach (Cuadro c in PiezaZ)
                {
                    if (c.Estado == false)
                    {
                        foreach (Cuadro t in tab.cuadritos)
                        {
                            if (t.Estado == true)
                            {
                                if ((t.coordenadas.X == PiezaZ[3].coordenadas.X + 20 && t.coordenadas.Y == PiezaZ[3].coordenadas.Y)
                                    || (t.coordenadas.X == PiezaZ[2].coordenadas.X + 20 && t.coordenadas.Y == PiezaZ[2].coordenadas.Y)
                                    || (t.coordenadas.X == PiezaZ[0].coordenadas.X + 20 && t.coordenadas.Y == PiezaZ[0].coordenadas.Y))
                                {
                                    //c.coordenadas.X -= 20;
                                    mover = false;
                                    break;
                                }
                            }
                        }
                        if ((PiezaZ[3].coordenadas.X == 180))
                        {
                            mover = false;
                        }
                    }
                }
            }
            foreach (Cuadro c in PiezaZ)
            {
                if (mover)
                {
                    c.coordenadas.X += 20;
                }
            }

        }
        public void MoverIzquierda(ref List<Cuadro> PiezaZ, Tablero tab, OrientacionPieza op)
        {
            bool mover = true;
            if (op == OrientacionPieza.Arriba || op == OrientacionPieza.Abajo)
            {

                foreach (Cuadro c in PiezaZ)
                {
                    if (c.Estado == false)
                    {
                        foreach (Cuadro t in tab.cuadritos)
                        {
                            if (t.Estado == true)
                            {
                                if ((t.coordenadas.X == PiezaZ[2].coordenadas.X - 20 && t.coordenadas.Y == PiezaZ[2].coordenadas.Y)
                                    || (t.coordenadas.X == PiezaZ[0].coordenadas.X - 20 && t.coordenadas.Y == PiezaZ[0].coordenadas.Y))
                                {
                                    //c.coordenadas.X -= 20;
                                    mover = false;
                                    break;
                                }
                            }
                        }
                        if ((PiezaZ[0].coordenadas.X == 0))
                        {
                            mover = false;
                        }
                    }
                }
            }
            if (op == OrientacionPieza.Derecha || op == OrientacionPieza.Izquierda) 
            {
                foreach (Cuadro c in PiezaZ)
                {
                    if (c.Estado == false)
                    {
                        foreach (Cuadro t in tab.cuadritos)
                        {
                            if (t.Estado == true)
                            {
                                if ((t.coordenadas.X == PiezaZ[3].coordenadas.X - 20 && t.coordenadas.Y == PiezaZ[3].coordenadas.Y)
                                    || (t.coordenadas.X == PiezaZ[0].coordenadas.X - 20 && t.coordenadas.Y == PiezaZ[0].coordenadas.Y)
                                    || (t.coordenadas.X == PiezaZ[1].coordenadas.X - 20 && t.coordenadas.Y == PiezaZ[1].coordenadas.Y))
                                {
                                    //c.coordenadas.X -= 20;
                                    mover = false;
                                    break;
                                }
                            }
                        }
                        if ((PiezaZ[0].coordenadas.X == 0))
                        {
                            mover = false;
                        }
                    }
                }
            }
            foreach (Cuadro c in PiezaZ)
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
        public override string ToString()
        {
            return "Zeta";
        }
    }
}

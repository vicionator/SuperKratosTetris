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
    public class Te :IPieza
    {
        
        public Te()
        {

        }
        public List<Cuadro> Formar(Point co, OrientacionPieza op)
        {
            List<Cuadro> PiezaT = new List<Cuadro>();
            bool agrega = false;
            if (op == OrientacionPieza.Arriba)
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
            else if (op == OrientacionPieza.Izquierda)
            {
                PiezaT.Add(new Cuadro(new Point(co.X, co.Y + 20)));
                PiezaT.Add(new Cuadro(new Point(co.X, co.Y)));
                PiezaT.Add(new Cuadro(new Point(co.X, co.Y-20)));
                PiezaT.Add(new Cuadro(new Point(co.X+20, co.Y)));
            }
            else if (op == OrientacionPieza.Abajo)
            {
                PiezaT.Add(new Cuadro(new Point(co.X + 20, co.Y)));
                PiezaT.Add(new Cuadro(new Point(co.X, co.Y)));
                PiezaT.Add(new Cuadro(new Point(co.X-20, co.Y)));
                PiezaT.Add(new Cuadro(new Point(co.X, co.Y-20)));
            }
            else if (op == OrientacionPieza.Derecha)
            {
                PiezaT.Add(new Cuadro(new Point(co.X, co.Y - 20)));
                PiezaT.Add(new Cuadro(new Point(co.X, co.Y)));
                PiezaT.Add(new Cuadro(new Point(co.X, co.Y + 20)));
                PiezaT.Add(new Cuadro(new Point(co.X - 20, co.Y)));
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
        public bool MoverAbajo(ref List<Cuadro> PiezaT, Tablero tab, OrientacionPieza op)
        {
            bool verificar = false;
            if (op == OrientacionPieza.Arriba)
            {

                foreach (Cuadro c in PiezaT)
                {
                    if (c.Estado == false)
                    {
                        foreach (Cuadro ta in tab.cuadritos)
                        {
                            if (ta.Estado == true)
                            {
                                if ((ta.coordenadas.X == PiezaT[3].coordenadas.X && ta.coordenadas.Y - 20 == PiezaT[3].coordenadas.Y)
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
            }
            if (op == OrientacionPieza.Izquierda) 
            {
                foreach (Cuadro c in PiezaT)
                {
                    if (c.Estado == false)
                    {
                        foreach (Cuadro ta in tab.cuadritos)
                        {
                            if (ta.Estado == true)
                            {
                                if ((ta.coordenadas.X == PiezaT[3].coordenadas.X && ta.coordenadas.Y - 20 == PiezaT[3].coordenadas.Y)
                                    || (ta.coordenadas.X == PiezaT[0].coordenadas.X && ta.coordenadas.Y - 20 == PiezaT[0].coordenadas.Y && PiezaT[3].coordenadas.Y == ta.coordenadas.Y - 40))
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
                        if (PiezaT[0].coordenadas.Y == 380 && PiezaT[3].coordenadas.Y == 360)
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

            }
            if (op == OrientacionPieza.Abajo) 
            {
                foreach (Cuadro c in PiezaT)
                {
                    if (c.Estado == false)
                    {
                        foreach (Cuadro ta in tab.cuadritos)
                        {
                            if (ta.Estado == true)
                            {
                                if ((ta.coordenadas.X == PiezaT[1].coordenadas.X && ta.coordenadas.Y - 20 == PiezaT[1].coordenadas.Y && ta.coordenadas.Y - 40 == PiezaT[3].coordenadas.Y)
                                    || (ta.coordenadas.X == PiezaT[0].coordenadas.X && ta.coordenadas.Y - 20 == PiezaT[0].coordenadas.Y && ta.coordenadas.Y - 40 == PiezaT[3].coordenadas.Y)
                                    || (ta.coordenadas.X == PiezaT[2].coordenadas.X && ta.coordenadas.Y - 20 == PiezaT[2].coordenadas.Y && ta.coordenadas.Y - 40 == PiezaT[3].coordenadas.Y))
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
                        if (PiezaT[1].coordenadas.Y == 380 && PiezaT[3].coordenadas.Y == 360)
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

            }
            if (op == OrientacionPieza.Derecha) 
            {
                foreach (Cuadro c in PiezaT)
                {
                    if (c.Estado == false)
                    {
                        foreach (Cuadro ta in tab.cuadritos)
                        {
                            if (ta.Estado == true)
                            {
                                if ((ta.coordenadas.X == PiezaT[3].coordenadas.X && ta.coordenadas.Y - 20 == PiezaT[3].coordenadas.Y)
                                    || (ta.coordenadas.X == PiezaT[2].coordenadas.X && ta.coordenadas.Y - 20 == PiezaT[2].coordenadas.Y && ta.coordenadas.Y - 40 == PiezaT[3].coordenadas.Y))
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
                        if (PiezaT[2].coordenadas.Y == 380 && PiezaT[3].coordenadas.Y == 360)
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

            }
            return verificar;

        }
        public void MoverDerecha(ref List<Cuadro> PiezaT, Tablero tab, OrientacionPieza op)
        {
            bool mover = true;
            if (op == OrientacionPieza.Arriba)
            {

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
            }
            if (op == OrientacionPieza.Izquierda) 
            {
                foreach (Cuadro c in PiezaT)
                {
                    if (c.Estado == false)
                    {
                        foreach (Cuadro t in tab.cuadritos)
                        {
                            if (t.Estado == true)
                            {
                                if ((t.coordenadas.X == PiezaT[3].coordenadas.X + 20 && t.coordenadas.Y == PiezaT[3].coordenadas.Y)
                                    || (t.coordenadas.X == PiezaT[2].coordenadas.X + 20 && t.coordenadas.Y == PiezaT[2].coordenadas.Y)
                                    || (t.coordenadas.X == PiezaT[0].coordenadas.X + 20 && t.coordenadas.Y == PiezaT[0].coordenadas.Y))
                                {
                                    //c.coordenadas.X -= 20;
                                    mover = false;
                                    break;
                                }
                            }
                        }
                        if ((PiezaT[3].coordenadas.X == 180))
                        {
                            mover = false;
                        }
                    }
                }
            }
            if (op == OrientacionPieza.Abajo) 
            {
                foreach (Cuadro c in PiezaT)
                {
                    if (c.Estado == false)
                    {
                        foreach (Cuadro t in tab.cuadritos)
                        {
                            if (t.Estado == true)
                            {
                                if ((t.coordenadas.X == PiezaT[3].coordenadas.X + 20 && t.coordenadas.Y == PiezaT[3].coordenadas.Y)
                                    || (t.coordenadas.X == PiezaT[0].coordenadas.X + 20 && t.coordenadas.Y == PiezaT[0].coordenadas.Y))
                                {
                                    //c.coordenadas.X -= 20;
                                    mover = false;
                                    break;
                                }
                            }
                        }
                        if ((PiezaT[0].coordenadas.X == 180))
                        {
                            mover = false;
                        }
                    }
                }
            }
            if (op == OrientacionPieza.Derecha) 
            {
                foreach (Cuadro c in PiezaT)
                {
                    if (c.Estado == false)
                    {
                        foreach (Cuadro t in tab.cuadritos)
                        {
                            if (t.Estado == true)
                            {
                                if ((t.coordenadas.X == PiezaT[1].coordenadas.X + 20 && t.coordenadas.Y == PiezaT[1].coordenadas.Y)
                                    || (t.coordenadas.X == PiezaT[2].coordenadas.X + 20 && t.coordenadas.Y == PiezaT[2].coordenadas.Y)
                                    || (t.coordenadas.X == PiezaT[0].coordenadas.X + 20 && t.coordenadas.Y == PiezaT[0].coordenadas.Y))
                                {
                                    //c.coordenadas.X -= 20;
                                    mover = false;
                                    break;
                                }
                            }
                        }
                        if ((PiezaT[1].coordenadas.X == 180))
                        {
                            mover = false;
                        }
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
        public void MoverIzquierda(ref List<Cuadro> PiezaT, Tablero tab, OrientacionPieza op)
        {
            bool mover = true;
            if (op == OrientacionPieza.Arriba)
            {

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
            }
            if (op == OrientacionPieza.Izquierda) 
            {
                foreach (Cuadro c in PiezaT)
                {
                    if (c.Estado == false)
                    {
                        foreach (Cuadro t in tab.cuadritos)
                        {
                            if (t.Estado == true)
                            {
                                if ((t.coordenadas.X == PiezaT[2].coordenadas.X - 20 && t.coordenadas.Y == PiezaT[2].coordenadas.Y)
                                    || (t.coordenadas.X == PiezaT[1].coordenadas.X - 20 && t.coordenadas.Y == PiezaT[1].coordenadas.Y)
                                    || (t.coordenadas.X == PiezaT[0].coordenadas.X - 20 && t.coordenadas.Y == PiezaT[0].coordenadas.Y))
                                {
                                    //c.coordenadas.X -= 20;
                                    mover = false;
                                    break;
                                }
                            }
                        }
                        if ((PiezaT[1].coordenadas.X == 0))
                        {
                            mover = false;
                        }
                    }
                }
            }
            if (op == OrientacionPieza.Abajo) 
            {
                foreach (Cuadro c in PiezaT)
                {
                    if (c.Estado == false)
                    {
                        foreach (Cuadro t in tab.cuadritos)
                        {
                            if (t.Estado == true)
                            {
                                if ((t.coordenadas.X == PiezaT[3].coordenadas.X - 20 && t.coordenadas.Y == PiezaT[3].coordenadas.Y)
                                    || (t.coordenadas.X == PiezaT[2].coordenadas.X - 20 && t.coordenadas.Y == PiezaT[2].coordenadas.Y))
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
            }
            if (op == OrientacionPieza.Derecha) 
            {
                foreach (Cuadro c in PiezaT)
                {
                    if (c.Estado == false)
                    {
                        foreach (Cuadro t in tab.cuadritos)
                        {
                            if (t.Estado == true)
                            {
                                if ((t.coordenadas.X == PiezaT[2].coordenadas.X - 20 && t.coordenadas.Y == PiezaT[2].coordenadas.Y)
                                    || (t.coordenadas.X == PiezaT[1].coordenadas.X - 20 && t.coordenadas.Y == PiezaT[1].coordenadas.Y)
                                    || (t.coordenadas.X == PiezaT[0].coordenadas.X - 20 && t.coordenadas.Y == PiezaT[0].coordenadas.Y))
                                {
                                    //c.coordenadas.X -= 20;
                                    mover = false;
                                    break;
                                }
                            }
                        }
                        if ((PiezaT[1].coordenadas.X == 0))
                        {
                            mover = false;
                        }
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
            return Formar(Pieza[1].coordenadas, op);
        }
        public override string ToString()
        {
            return "Te";
        }
    }
}

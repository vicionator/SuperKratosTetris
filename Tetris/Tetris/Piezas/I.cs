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
        List<Cuadro> PiezaI = new List<Cuadro>();

        public I()
        {

        }
        public List<Cuadro> Formar(Point co, OrientacionPieza op)
        {
            List<Cuadro> PiezaI = new List<Cuadro>();
            for (int i = 0; i < 4; i++)
            {
                PiezaI.Add(new Cuadro(co));
                co.X += 20;
            }
            return PiezaI;
        }
        public void Dibujar(ref List<Cuadro> PiezaI,PictureBox pb)
        {
            Graphics g = pb.CreateGraphics();
            Rectangle rect;
            Size tam = new Size(20, 20);
            
            foreach (Cuadro c in PiezaI)
            {
                rect = new Rectangle(c.coordenadas, tam);
                g.FillRectangle(c.Brocha3, rect);
                ControlPaint.DrawBorder(g, rect, Color.Black, ButtonBorderStyle.Inset);
            }
        }
        public bool MoverAbajo(ref List<Cuadro> PiezaI, Tablero tab)
        {
            bool verificar = false;
            foreach (Cuadro c in PiezaI)
            {
                if (c.Estado == false)
                {
                    foreach (Cuadro ta in tab.cuadritos)
                    {
                        if (ta.Estado == true)
                        {
                            if ((ta.coordenadas.X == PiezaI[0].coordenadas.X && ta.coordenadas.Y - 20 == PiezaI[0].coordenadas.Y && ta.coordenadas.Y - 20 == PiezaI[1].coordenadas.Y && ta.coordenadas.Y - 20 == PiezaI[2].coordenadas.Y && ta.coordenadas.Y - 20 == PiezaI[3].coordenadas.Y)
                                || (ta.coordenadas.X == PiezaI[1].coordenadas.X && ta.coordenadas.Y - 20 == PiezaI[1].coordenadas.Y && ta.coordenadas.Y - 20 == PiezaI[0].coordenadas.Y && ta.coordenadas.Y - 20 == PiezaI[2].coordenadas.Y && ta.coordenadas.Y - 20 == PiezaI[3].coordenadas.Y)
                                || (ta.coordenadas.X == PiezaI[2].coordenadas.X && ta.coordenadas.Y - 20 == PiezaI[2].coordenadas.Y && ta.coordenadas.Y - 20 == PiezaI[1].coordenadas.Y && ta.coordenadas.Y - 20 == PiezaI[0].coordenadas.Y && ta.coordenadas.Y - 20 == PiezaI[3].coordenadas.Y)
                                || (ta.coordenadas.X == PiezaI[3].coordenadas.X && ta.coordenadas.Y - 20 == PiezaI[3].coordenadas.Y && ta.coordenadas.Y - 20 == PiezaI[1].coordenadas.Y && ta.coordenadas.Y - 20 == PiezaI[2].coordenadas.Y && ta.coordenadas.Y - 20 == PiezaI[0].coordenadas.Y))
                            {
                                foreach (Cuadro c2 in PiezaI)
                                {
                                    foreach (Cuadro t in tab.cuadritos)
                                    {
                                        if (c2.coordenadas.X == t.coordenadas.X && c2.coordenadas.Y == t.coordenadas.Y)
                                        {
                                            t.Estado = true;
                                            t.Brocha4 = c2.Brocha3;
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
                    if (PiezaI[PiezaI.Count - 1].coordenadas.Y == 380)
                    {
                        foreach (Cuadro c2 in PiezaI)
                        {
                            foreach (Cuadro t in tab.cuadritos)
                            {
                                if (c2.coordenadas.X == t.coordenadas.X && c2.coordenadas.Y == t.coordenadas.Y)
                                {
                                    t.Estado = true;
                                    t.Brocha4 = c2.Brocha3;
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
        public void MoverDerecha(ref List<Cuadro> PiezaI, Tablero tab)
        {
            bool mover = true;
            foreach (Cuadro c in PiezaI)
            {
                if (c.Estado == false)
                {
                    foreach (Cuadro t in tab.cuadritos)
                    {
                        if (t.Estado == true)
                        {
                            if ((t.coordenadas.X == PiezaI[3].coordenadas.X + 20 && t.coordenadas.Y == PiezaI[3].coordenadas.Y))
                            {
                                //c.coordenadas.X -= 20;
                                mover = false;
                                break;
                            }
                        }
                    }
                    if ((PiezaI[PiezaI.Count - 1].coordenadas.X == 180))
                    {
                        mover = false;
                    }
                }
            }
            foreach (Cuadro c in PiezaI)
            {
                if (mover)
                {
                    c.coordenadas.X += 20;
                }
            }

        }
        public void MoverIzquierda(ref List<Cuadro> PiezaI, Tablero tab)
        {
            bool mover = true;
            foreach (Cuadro c in PiezaI)
            {
                if (c.Estado == false)
                {
                    foreach (Cuadro t in tab.cuadritos)
                    {
                        if (t.Estado == true)
                        {
                            if ((t.coordenadas.X == PiezaI[0].coordenadas.X - 20 && t.coordenadas.Y == PiezaI[0].coordenadas.Y))
                            {
                                //c.coordenadas.X -= 20;
                                mover = false;
                                break;
                            }
                        }
                    }
                    if ((PiezaI[0].coordenadas.X == 0))
                    {
                        mover = false;
                    }
                }
            }
            foreach (Cuadro c in PiezaI)
            {
                if (mover)
                {
                    c.coordenadas.X -= 20;
                }
            }

        }
        public List<Cuadro> Rotar(Tablero tab, ref OrientacionPieza op, List<Cuadro> Pieza)
        {
            return Pieza;
        }
    }
}

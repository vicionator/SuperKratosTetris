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
    public class Cubo:IPieza
    {
        public Cubo()
        {
        }
        public List<Cuadro> Formar(Point co, OrientacionPieza op)
        {
            List<Cuadro> PiezaO = new List<Cuadro>();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    PiezaO.Add(new Cuadro(co));
                    co.X += 20;
                }
                co.X -= 40;
                co.Y += 20;
            }
            return PiezaO;
        }
        public void Dibujar(ref List<Cuadro> PiezaO,PictureBox pb) 
        {
            Graphics g = pb.CreateGraphics();
            Rectangle rect;
            Size tam = new Size(20, 20);

            foreach (Cuadro c in PiezaO)
            {
                rect = new Rectangle(c.coordenadas, tam);
                g.FillRectangle(c.Brocha, rect);
                ControlPaint.DrawBorder(g, rect, Color.Black, ButtonBorderStyle.Inset);
            }
        }
        public bool MoverAbajo(ref List<Cuadro> PiezaO,Tablero tab)
        {
            bool verificar=false;
            foreach (Cuadro c in PiezaO)
                {
                    if (c.Estado == false)
                    {
                        foreach (Cuadro ta in tab.cuadritos)
                        {
                            if (ta.Estado == true) 
                            {
                                if ((ta.coordenadas.X == PiezaO[PiezaO.Count - 1].coordenadas.X && ta.coordenadas.Y - 20 == PiezaO[PiezaO.Count - 1].coordenadas.Y) 
                                    ||(ta.coordenadas.X == PiezaO[PiezaO.Count - 2].coordenadas.X && ta.coordenadas.Y - 20 == PiezaO[PiezaO.Count - 2].coordenadas.Y 
                                    && ta.coordenadas.Y - 20 == PiezaO[PiezaO.Count - 1].coordenadas.Y)) 
                                {
                                    foreach (Cuadro c2 in PiezaO)
                                    {
                                        foreach (Cuadro t in tab.cuadritos)
                                        {
                                            if (c2.coordenadas.X == t.coordenadas.X && c2.coordenadas.Y == t.coordenadas.Y)
                                            {
                                                t.Estado = true;
                                                t.Brocha4 = c2.Brocha;
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
                        if (PiezaO[PiezaO.Count - 1].coordenadas.Y == 380)
                        {
                            foreach (Cuadro c2 in PiezaO)
                            {
                                foreach (Cuadro t in tab.cuadritos)
                                {
                                    if (c2.coordenadas.X == t.coordenadas.X && c2.coordenadas.Y == t.coordenadas.Y) 
                                    {
                                        t.Estado = true;
                                        t.Brocha4 = c2.Brocha;
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
        public void MoverDerecha(ref List<Cuadro> PiezaO,Tablero tab)
        {
            bool mover = true;
            foreach (Cuadro c in PiezaO)
            {
                if (c.Estado == false)
                {
                    foreach (Cuadro t in tab.cuadritos)
                    {
                        if (t.Estado == true)
                        {
                            if ((t.coordenadas.X == PiezaO[3].coordenadas.X + 20 && t.coordenadas.Y == PiezaO[3].coordenadas.Y) 
                                || (t.coordenadas.X == PiezaO[1].coordenadas.X + 20 && t.coordenadas.Y == PiezaO[1].coordenadas.Y))
                            {
                                //c.coordenadas.X -= 20;
                                mover = false;
                                break;
                            }
                        }
                    }
                    if ((PiezaO[PiezaO.Count - 1].coordenadas.X == 180))
                    {
                        mover = false;
                    }
                }
            }
            foreach (Cuadro c in PiezaO)
            {
                if (mover)
                {
                    c.coordenadas.X += 20;
                }
            }

        }
        public void MoverIzquierda(ref List<Cuadro> PiezaO,Tablero tab)
        {
            bool mover = true;
            foreach (Cuadro c in PiezaO)
            {
                if (c.Estado == false)
                {
                    foreach (Cuadro t in tab.cuadritos)
                    {
                        if (t.Estado == true)
                        {
                            if ((t.coordenadas.X == PiezaO[2].coordenadas.X - 20 && t.coordenadas.Y == PiezaO[2].coordenadas.Y)
                                || (t.coordenadas.X == PiezaO[0].coordenadas.X - 20 && t.coordenadas.Y == PiezaO[0].coordenadas.Y))
                            {
                                //c.coordenadas.X -= 20;
                                mover = false;
                                break;
                            }
                        }
                    }
                    if ((PiezaO[2].coordenadas.X == 0))
                    {
                        mover = false;
                    }
                }
            }
            foreach (Cuadro c in PiezaO)
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

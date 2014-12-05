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
        List<Cuadro> PiezaJ = new List<Cuadro>();
        bool agrega = false;

        public Jota(Point co)
        {
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
        }


        public void Dibujar(PictureBox pb)
        {
            Graphics g = pb.CreateGraphics();
            Rectangle rect;
            Size tam = new Size(20, 20);

            foreach (Cuadro c in PiezaJ)
            {
                c.Estado = true;
                rect = new Rectangle(c.coordenadas, tam);
                g.FillRectangle(c.Brocha2, rect);
                ControlPaint.DrawBorder(g, rect, Color.Black, ButtonBorderStyle.Inset);
            }
        }
        public bool MoverAbajo(Tablero tab)
        {
            bool verificar = false;
            foreach (Cuadro c in this.PiezaJ)
            {
                if (c.Estado == false)
                {
                    foreach (Cuadro ta in tab.cuadritos)
                    {
                        if (ta.Estado == true)
                        {
                            if ((ta.coordenadas.X == this.PiezaJ[this.PiezaJ.Count - 1].coordenadas.X && ta.coordenadas.Y - 20 == this.PiezaJ[this.PiezaJ.Count - 1].coordenadas.Y)
                                || (ta.coordenadas.X == this.PiezaJ[this.PiezaJ.Count - 2].coordenadas.X && ta.coordenadas.Y - 20 == this.PiezaJ[this.PiezaJ.Count - 2].coordenadas.Y
                                && ta.coordenadas.Y - 20 == this.PiezaJ[this.PiezaJ.Count - 1].coordenadas.Y))
                            {
                                foreach (Cuadro c2 in this.PiezaJ)
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
                    if (this.PiezaJ[this.PiezaJ.Count - 1].coordenadas.Y == 380)
                    {
                        foreach (Cuadro c2 in this.PiezaJ)
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
        public void MoverDerecha(Tablero tab)
        {
            bool mover = true;
            foreach (Cuadro c in this.PiezaJ)
            {
                if (c.Estado == false)
                {
                    foreach (Cuadro t in tab.cuadritos)
                    {
                        if (t.Estado == true)
                        {
                            if ((t.coordenadas.X == this.PiezaJ[3].coordenadas.X + 20 && t.coordenadas.Y == this.PiezaJ[3].coordenadas.Y)
                                || (t.coordenadas.X == this.PiezaJ[1].coordenadas.X + 20 && t.coordenadas.Y == this.PiezaJ[1].coordenadas.Y))
                            {
                                //c.coordenadas.X -= 20;
                                mover = false;
                                break;
                            }
                        }
                    }
                    if ((this.PiezaJ[this.PiezaJ.Count - 1].coordenadas.X == 180))
                    {
                        mover = false;
                    }
                }
            }
            foreach (Cuadro c in this.PiezaJ)
            {
                if (mover)
                {
                    c.coordenadas.X += 20;
                }
            }

        }
        public void MoverIzquierda(Tablero tab)
        {
            bool mover = true;
            foreach (Cuadro c in this.PiezaJ)
            {
                if (c.Estado == false)
                {
                    foreach (Cuadro t in tab.cuadritos)
                    {
                        if (t.Estado == true)
                        {
                            if ((t.coordenadas.X == this.PiezaJ[2].coordenadas.X - 20 && t.coordenadas.Y == this.PiezaJ[2].coordenadas.Y)
                                || (t.coordenadas.X == this.PiezaJ[0].coordenadas.X - 20 && t.coordenadas.Y == this.PiezaJ[0].coordenadas.Y))
                            {
                                //c.coordenadas.X -= 20;
                                mover = false;
                                break;
                            }
                        }
                    }
                    if ((this.PiezaJ[2].coordenadas.X == 0))
                    {
                        mover = false;
                    }
                }
            }
            foreach (Cuadro c in this.PiezaJ)
            {
                if (mover)
                {
                    c.coordenadas.X -= 20;
                }
            }

        }

        public void Rotar(Tablero tab)
        {
            throw new NotImplementedException();
        }
    }
}

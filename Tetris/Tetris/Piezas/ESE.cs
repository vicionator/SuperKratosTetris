﻿using System;
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
        List<Cuadro> PiezaS = new List<Cuadro>();
        bool agrega = false;

        public ESE(Point co)
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

        public void Dibujar(PictureBox pb)
        {
            Graphics g = pb.CreateGraphics();
            Rectangle rect;
            Size tam = new Size(20, 20);

            foreach (Cuadro c in PiezaS)
            {
                c.Estado = true;
                rect = new Rectangle(c.coordenadas, tam);
                g.FillRectangle(c.Brocha4, rect);
                ControlPaint.DrawBorder(g, rect, Color.Black, ButtonBorderStyle.Inset);
            }
        }
        public bool MoverAbajo(Tablero tab)
        {
            bool verificar = false;
            foreach (Cuadro c in this.PiezaS)
            {
                if (c.Estado == false)
                {
                    foreach (Cuadro ta in tab.cuadritos)
                    {
                        if (ta.Estado == true)
                        {
                            if ((ta.coordenadas.X == this.PiezaS[this.PiezaS.Count - 1].coordenadas.X && ta.coordenadas.Y - 20 == this.PiezaS[this.PiezaS.Count - 1].coordenadas.Y)
                                || (ta.coordenadas.X == this.PiezaS[this.PiezaS.Count - 2].coordenadas.X && ta.coordenadas.Y - 20 == this.PiezaS[this.PiezaS.Count - 2].coordenadas.Y
                                && ta.coordenadas.Y - 20 == this.PiezaS[this.PiezaS.Count - 1].coordenadas.Y))
                            {
                                foreach (Cuadro c2 in this.PiezaS)
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
                    if (this.PiezaS[this.PiezaS.Count - 1].coordenadas.Y == 380)
                    {
                        foreach (Cuadro c2 in this.PiezaS)
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
            foreach (Cuadro c in this.PiezaS)
            {
                if (c.Estado == false)
                {
                    foreach (Cuadro t in tab.cuadritos)
                    {
                        if (t.Estado == true)
                        {
                            if ((t.coordenadas.X == this.PiezaS[3].coordenadas.X + 20 && t.coordenadas.Y == this.PiezaS[3].coordenadas.Y)
                                || (t.coordenadas.X == this.PiezaS[1].coordenadas.X + 20 && t.coordenadas.Y == this.PiezaS[1].coordenadas.Y))
                            {
                                //c.coordenadas.X -= 20;
                                mover = false;
                                break;
                            }
                        }
                    }
                    if ((this.PiezaS[this.PiezaS.Count - 1].coordenadas.X == 180))
                    {
                        mover = false;
                    }
                }
            }
            foreach (Cuadro c in this.PiezaS)
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
            foreach (Cuadro c in this.PiezaS)
            {
                if (c.Estado == false)
                {
                    foreach (Cuadro t in tab.cuadritos)
                    {
                        if (t.Estado == true)
                        {
                            if ((t.coordenadas.X == this.PiezaS[2].coordenadas.X - 20 && t.coordenadas.Y == this.PiezaS[2].coordenadas.Y)
                                || (t.coordenadas.X == this.PiezaS[0].coordenadas.X - 20 && t.coordenadas.Y == this.PiezaS[0].coordenadas.Y))
                            {
                                //c.coordenadas.X -= 20;
                                mover = false;
                                break;
                            }
                        }
                    }
                    if ((this.PiezaS[2].coordenadas.X == 0))
                    {
                        mover = false;
                    }
                }
            }
            foreach (Cuadro c in this.PiezaS)
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

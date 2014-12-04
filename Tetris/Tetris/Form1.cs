using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        int[,] board = new int[10, 20];
        Point[,] Coordenadas = new Point[10, 20];
        Point inicial = new Point(0, 0);

        Tablero tab = new Tablero();
        Cubo cu = new Cubo(new Point(40, 40));
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tab.CreacionTab();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();

            //foreach (Cuadro c in cu.PiezaO)
            //{
            //    c.coordenadas.Y += 20;
            //}
            //cu.Dibujar(pictureBox1);


            //ELE el = new ELE(new Point(40, 80));
            //el.Dibujar(pictureBox1);

            //Jota jo = new Jota(new Point(80, 40));
            //jo.Dibujar(pictureBox1);

            //I pi = new I(new Point(80, 100));
            //pi.Dibujar(pictureBox1);

            //ESE es = new ESE(new Point(40, 140));
            //es.Dibujar(pictureBox1);

            //Zeta ze = new Zeta(new Point(40, 180));
            //ze.Dibujar(pictureBox1);

            //Te te = new Te(new Point(40, 220));
            //te.Dibujar(pictureBox1);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            pictureBox1.Refresh();

            if (keyData == Keys.Down)
            {
                foreach (Cuadro c in cu.PiezaO)
                {
                    if (c.Estado == false)
                    {
                        foreach (Cuadro ta in tab.cuadritos)
                        {
                            if (ta.Estado == true) 
                            {
                                if ((ta.coordenadas.X == cu.PiezaO[cu.PiezaO.Count - 1].coordenadas.X && ta.coordenadas.Y - 20 == cu.PiezaO[cu.PiezaO.Count - 1].coordenadas.Y) || (ta.coordenadas.X == cu.PiezaO[cu.PiezaO.Count - 2].coordenadas.X && ta.coordenadas.Y - 20 == cu.PiezaO[cu.PiezaO.Count - 2].coordenadas.Y && ta.coordenadas.Y - 20 == cu.PiezaO[cu.PiezaO.Count - 1].coordenadas.Y)) 
                                {
                                    foreach (Cuadro c2 in cu.PiezaO)
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
                                    cu = new Cubo(new Point(40, 40));
                                    break;
                                }
                            }
                        }
                        c.coordenadas.Y += 20;
                        if (cu.PiezaO[cu.PiezaO.Count - 1].coordenadas.Y == 380)
                        {
                            foreach (Cuadro c2 in cu.PiezaO)
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
                            cu = new Cubo(new Point(40, 40));
                            break;
                        }
                    }
                }
                cu.Dibujar(pictureBox1);
                tab.Dibuja(pictureBox1);
            }
            if (keyData == Keys.Right) 
            {
                foreach (Cuadro c in cu.PiezaO)
                {
                    if (c.Estado == false) 
                    {
                        foreach (Cuadro t in tab.cuadritos)
                        {
                            if (t.Estado == true) 
                            {
                                if ((t.coordenadas.X == cu.PiezaO[cu.PiezaO.Count - 1].coordenadas.X + 20 && t.coordenadas.Y == cu.PiezaO[cu.PiezaO.Count - 1].coordenadas.Y) || (t.coordenadas.X == cu.PiezaO[cu.PiezaO.Count-3].coordenadas.X+20 && t.coordenadas.Y == cu.PiezaO[cu.PiezaO.Count-3].coordenadas.Y) ) 
                                {
                                    c.coordenadas.X -= 20;
                                }
                            }
                        }
                        if ((cu.PiezaO[cu.PiezaO.Count - 1].coordenadas.X == 180))
                        {
                        }
                        else
                        {
                            c.coordenadas.X += 20;
                        }
                    }
                }
                cu.Dibujar(pictureBox1);
                tab.Dibuja(pictureBox1);
            }
            if (keyData == Keys.Left) 
            {
                foreach (Cuadro c in cu.PiezaO)
                {
                    if (c.Estado == false)
                    {
                        if (cu.PiezaO[cu.PiezaO.Count-1].coordenadas.X == 20)
                        {
                        }
                        else
                        {
                            c.coordenadas.X -= 20;
                        }
                    }
                }
                cu.Dibujar(pictureBox1);
                tab.Dibuja(pictureBox1);
            }
            if (keyData == Keys.Up) 
            {
                cu.Dibujar(pictureBox1);
                tab.Dibuja(pictureBox1);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
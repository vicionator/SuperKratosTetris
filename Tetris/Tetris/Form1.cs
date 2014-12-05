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
            if (keyData == Keys.Down)
            {
                
                if (cu.MoverAbajo(tab))
                {
                    cu = new Cubo(new Point(40, 40));     
                }
                Refrescar();
            }
            if (keyData == Keys.Right) 
            {
                cu.MoverDerecha(tab);
                Refrescar();
            }
            if (keyData == Keys.Left) 
            {
                cu.MoverIzquierda(tab);
                Refrescar();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        public void Refrescar()
        {
            pictureBox1.Refresh();
            cu.Dibujar(pictureBox1);
            tab.Dibuja(pictureBox1);
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris.Piezas;

namespace Tetris
{
    public partial class Form1 : Form
    {
        int[,] board = new int[10, 20];
        Point[,] Coordenadas = new Point[10, 20];
        Point inicial = new Point(0, 0);
        Tablero tab = new Tablero();
        Pieza pi = new Pieza(new Cubo(), new Point(40,40));       
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
                
                if (pi.MoverAbajo(tab))
                {
                    pi = new Pieza(NuevaPieza(), new Point(40, 40));  
                }
                Refrescar();
            }
            if (keyData == Keys.Right) 
            {
                pi.MoverDerecha(tab);
                Refrescar();
            }
            if (keyData == Keys.Left) 
            {
                pi.MoverIzquierda(tab);
                Refrescar();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        public void Refrescar()
        {
            pictureBox1.Refresh();
            pi.Dibujar(pictureBox1);
            tab.Dibuja(pictureBox1);
        }
        public IPieza NuevaPieza()
        {
            IPieza pieza=new Cubo();
            Random r = new Random();
            int x = r.Next(1, 8);
            switch(x)
            {
                case 1:
                    pieza= new Cubo();
                    break;
                case 2:
                    pieza = new I();
                    break;
                case 3:
                    pieza = new Jota();
                    break;
                case 4:
                    pieza = new ELE();
                    break;
                case 5:
                    pieza = new ESE();
                    break;
                case 6:
                    pieza = new Te();
                    break;
                case 7:
                    pieza = new Zeta();
                    break;
            }
            return pieza;
        }

    }
}
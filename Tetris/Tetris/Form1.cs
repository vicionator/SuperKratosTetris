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
        int X = 0;
        int Y = 0;

        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tablero tab = new Tablero();
            tab.CreacionTab(pictureBox1);

            Cubo cu = new Cubo(new Point(40, 40));
            cu.Dibujar(pictureBox1);

            ELE el = new ELE(new Point(40, 80));
            el.Dibujar(pictureBox1);

            Jota jo = new Jota(new Point(80, 40));
            jo.Dibujar(pictureBox1);

            I pi = new I(new Point(80, 100));
            pi.Dibujar(pictureBox1);

            ESE es = new ESE(new Point(40, 140));
            es.Dibujar(pictureBox1);

            Zeta ze = new Zeta(new Point(40, 180));
            ze.Dibujar(pictureBox1);

            Te te = new Te(new Point(40, 220));
            te.Dibujar(pictureBox1);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            pictureBox1.Refresh();
            Graphics g = pictureBox1.CreateGraphics();
            SolidBrush Brocha = new SolidBrush(Color.Red);

            Rectangle rect;// = new Rectangle(0, 380, 20, 20);
            g.FillRectangle(Brocha, rect = new Rectangle(X, Y, 20, 20));
            if (e.KeyData == Keys.Up) 
            {
                if (Y == 0)
                {
                }
                else
                {
                    Y--;
                }
            }
            if (e.KeyData == Keys.Down)
            {
                if (Y == 19)
                {
                }
                else
                {
                    Y++;
                }
            }
            if (e.KeyData == Keys.Left)
            {
                if (X == 0)
                {
                }
                else
                {
                    X--;
                }
            }
            if (e.KeyData == Keys.Right)
            {
                if (X == 9)
                {
                }
                else
                {
                    X++;
                }
            }
        }
    }
}
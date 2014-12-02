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
        int boardWidth = 10;
        int boardHeight = 20;
        int X = 0;
        int Y = 0;

        Tetromino Pieza = new Tetromino();
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    board[x, y] = 0;
                    Coordenadas[x, y] = inicial;
                    inicial.X += 20;
                }
                inicial.X = 0;
                inicial.Y += 20;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point p1 = new Point(20, 0);
            Point p2 = new Point(20, 400);
            Point p3 = new Point(0, 20);
            Point p4 = new Point(200, 20);
            Graphics g = pictureBox1.CreateGraphics();
            Pen Pluma = new Pen(Color.Black);
            SolidBrush Brocha = new SolidBrush(Color.Red);

            Rectangle rect;// = new Rectangle(0, 380, 20, 20);
            Size tam = new Size(20,20);
           
            for (int i = 0; i < 10; i++)
            {
                g.DrawLine(Pluma, p1.X, p1.Y, p2.X, p2.Y);
                p1.X += 20;
                p2.X += 20;
            }
            for (int j = 0; j < 20; j++)
            {
                g.DrawLine(Pluma, p3.X, p3.Y, p4.X, p4.Y);
                p3.Y += 20;
                p4.Y += 20;
            }
            //for (int i = 0; i < 20; i++)
            //{
            //    for (int j = 0; j < 10; j++)
            //    {
            //        g.FillRectangle(Brocha, rect = new Rectangle(Coordenadas[j, i], tam));
            //    }
            //}
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            pictureBox1.Refresh();
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
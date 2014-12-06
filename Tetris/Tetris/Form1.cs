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
        Tablero tab = new Tablero();
        Pieza pi = new Pieza(new Cubo(), new Point(100,0),OrientacionPieza.Arriba);
        MenuPrincipal M;
        public Form1(MenuPrincipal m)
        {
            M = m;
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Down)
            {
                
                if (pi.MoverAbajo(tab))
                {
                    pi = new Pieza(NuevaPieza(), new Point(100, 0),/*NuevaOrientacion()*/OrientacionPieza.Arriba);
                    tab.VerificarLineas();
                    if(tab.Perder())
                    {
                        MessageBox.Show("Haz Perdido!!\nPuntos: " + lbPuntos.Text);
                        tab = new Tablero();
                    }
                    lbPuntos.Text = tab.ObtenerPuntos().ToString();
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
            if (keyData == Keys.Up) 
            {
                pi.Rotar(tab);
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
        public OrientacionPieza NuevaOrientacion()
        {
            OrientacionPieza op = OrientacionPieza.Arriba;
            Random r = new Random();
            int x = r.Next(1, 5);
            switch (x)
            {
                case 1:
                    op = OrientacionPieza.Arriba;
                    break;
                case 2:
                    op = OrientacionPieza.Abajo;
                    break;
                case 3:
                    op = OrientacionPieza.Derecha;
                    break;
                case 4:
                    op = OrientacionPieza.Izquierda;
                    break;
            }
            return op;
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            /*if ((MessageBox.Show("¿Desea volver al Menu principal?", "Volver",
    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                MenuPrincipal m = new MenuPrincipal();
                m.Show();
                this.Close();
            }*/
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("¿Desea volver al Menu principal?", "Volver",
MessageBoxButtons.YesNo, MessageBoxIcon.Question,
MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                MenuPrincipal m = new MenuPrincipal();
                m.Show();
                this.Close();
            }
        }
    }
}
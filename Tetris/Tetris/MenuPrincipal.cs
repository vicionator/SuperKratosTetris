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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnUnJugador_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1(this);
            f1.Show();
            this.Hide();
        }

        private void btnDosJugadores_Click(object sender, EventArgs e)
        {

        }

        private void btnCreditos_Click(object sender, EventArgs e)
        {

        }

        private void MenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

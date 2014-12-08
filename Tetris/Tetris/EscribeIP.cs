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
    public partial class EscribeIP : Form
    {
        public EscribeIP()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txbIP.Text == "")
            {
            }
            else
            {
                DosJugadoresTablero DJT = new DosJugadoresTablero(false, txbIP.Text);
                DJT.Show();
                this.Hide();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            MenuDosJugadores m2 = new MenuDosJugadores();
            m2.Show();
            this.Hide();
        }

        private void EscribeIP_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuDosJugadores m2 = new MenuDosJugadores();
            m2.Show();
            this.Hide();
        }
    }
}

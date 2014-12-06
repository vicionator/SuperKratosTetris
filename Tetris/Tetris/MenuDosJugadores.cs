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
    public partial class MenuDosJugadores : Form
    {
        public MenuDosJugadores()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            MenuPrincipal m = new MenuPrincipal();
            m.Show();
            this.Hide();
        }

        private void btnEsperarPartida_Click(object sender, EventArgs e)
        {
            DosJugadoresTablero DJT = new DosJugadoresTablero(true);
            DJT.Show();
            this.Hide();
        }

        private void MenuDosJugadores_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuPrincipal m = new MenuPrincipal();
            m.Show();
            this.Hide();
        }

        private void btnConectarIP_Click(object sender, EventArgs e)
        {
            EscribeIP es = new EscribeIP();
            es.Show();
            this.Hide();

        }
    }
}

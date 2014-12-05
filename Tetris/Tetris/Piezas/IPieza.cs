using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris.Piezas
{
    public interface IPieza
    {
        void Dibujar(PictureBox pb);
        void MoverDerecha(Tablero tab);
        void MoverIzquierda(Tablero tab);
        bool MoverAbajo(Tablero tab);
        void Rotar(Tablero tab);
    }
}

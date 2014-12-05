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
        List<Cuadro> Formar(Point co,OrientacionPieza op);
        void Dibujar(ref List<Cuadro> PiezaO,PictureBox pb);
        void MoverDerecha(ref List<Cuadro> PiezaO,Tablero tab);
        void MoverIzquierda(ref List<Cuadro> PiezaO,Tablero tab);
        bool MoverAbajo(ref List<Cuadro> PiezaO,Tablero tab);
        void Rotar(ref List<Cuadro> PiezaO,Tablero tab);
    }
}

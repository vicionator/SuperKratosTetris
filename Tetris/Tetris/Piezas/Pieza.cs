using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace Tetris.Piezas
{
    [DataContract]
    public class Pieza
    {
        [DataMember]
        public List<Cuadro> PiezaO;
        [DataMember]
        public IPieza pieza { get; set; }
        [DataMember]
        public OrientacionPieza OP;
        public Pieza(IPieza _pieza,Point co, OrientacionPieza op)
        {
            pieza = _pieza;
            PiezaO = pieza.Formar(co,op);
        }
        public void Dibujar(PictureBox pb)
        {
            pieza.Dibujar(ref PiezaO, pb);
        }
        public bool MoverAbajo(Tablero tab)
        {
           return pieza.MoverAbajo(ref PiezaO, tab,OP);
        }
        public void MoverDerecha(Tablero tab)
        {
            pieza.MoverDerecha(ref PiezaO,tab,OP);
        }
        public void MoverIzquierda(Tablero tab)
        {
            pieza.MoverIzquierda(ref PiezaO, tab,OP);
        }
        public void Rotar(Tablero tab)
        {
            PiezaO = pieza.Rotar(tab, ref OP, PiezaO);
        }
        public List<Cuadro> Piezas()
        {
            return PiezaO;
        }
    }
}

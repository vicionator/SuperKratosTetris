using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization;

namespace Tetris
{
    [Serializable]
    public class Cuadro
    {
        [DataMember]
        public Point coordenadas;
        [DataMember]
        public bool Estado;
        [NonSerialized]
        public SolidBrush Brocha;
        [NonSerialized]
        public SolidBrush Brocha1;
        [NonSerialized]
        public SolidBrush Brocha2;
        [NonSerialized]
        public SolidBrush Brocha3;
        [NonSerialized]
        public SolidBrush Brocha4;
        [NonSerialized]
        public SolidBrush Brocha5;
        [NonSerialized]
        public SolidBrush Brocha6;
        
        public Cuadro(Point coord)
        {
            coordenadas = coord;
            Estado = false;
            Brocha = new SolidBrush(Color.Red);
            Brocha1 = new SolidBrush(Color.Orange);
            Brocha2 = new SolidBrush(Color.Yellow);
            Brocha3 = new SolidBrush(Color.Green);
            Brocha4 = new SolidBrush(Color.Blue);
            Brocha5 = new SolidBrush(Color.Indigo);
            Brocha6 = new SolidBrush(Color.Violet);
        }
    }
}

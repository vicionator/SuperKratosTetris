using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization;

namespace Tetris
{
    [DataContract]
    public class Cuadro
    {
        [DataMember]
        public Point coordenadas;
        [DataMember]
        public bool Estado;
        public SolidBrush Brocha;
        public SolidBrush Brocha1;
        public SolidBrush Brocha2;
        public SolidBrush Brocha3;
        public SolidBrush Brocha4;
        public SolidBrush Brocha5;
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

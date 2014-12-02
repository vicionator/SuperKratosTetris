using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    public class Tetromino
    {
        public Point Coordenadas;
        List<int[,]> Pieza = new List<int[,]>();
        public Color[] TetronimoColors = {
                                    Color.Transparent,  /* 0 */
                                    Color.Orange,       /* 1 */
                                    Color.Blue,         /* 2 */
                                    Color.Red,          /* 3 */
                                    Color.LightSkyBlue, /* 4 */
                                    Color.Yellow,       /* 5 */
                                    Color.Magenta,      /* 6 */
                                    Color.LimeGreen     /* 7 */
                                  };


        public Tetromino() 
        {
            // I
            Pieza.Add(new int[4, 4] { 
            {0, 0, 0, 0},
            {1, 1, 1, 1},
            {0, 0, 0, 0},
            {0, 0, 0, 0}
            });

            // L
            Pieza.Add(new int[3, 3]{
                {0,0,1},
                {1,1,1},
                {0,0,0}
            });

            // O
            Pieza.Add(new int[2, 2] { 
            {1, 1},
            {1, 1}
            });

            // S
            Pieza.Add(new int[3, 3] { 
            {0, 1, 1},
            {1, 1, 0},
            {0, 0, 0}
            });


            // T
            Pieza.Add(new int[3, 3] { 
            {0, 1, 0},
            {1, 1, 1},
            {0, 0, 0}
            });

            // Z
            Pieza.Add(new int[3, 3] { 
            {1, 1, 0},
            {0, 1, 1},
            {0, 0, 0}
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace Tetris
{
    [Serializable]
    public class Tablero
    {
        [DataMember]
        public List<Cuadro> cuadritos = new List<Cuadro>();
        Point inicial = new Point(0, 0);
        Rectangle rect;
        int puntos = 0;
        public Tablero()
        {
            CreacionTab();
        }             
        public void CreacionTab()
        {
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    cuadritos.Add(new Cuadro(inicial));
                    
                    inicial.X += 20;
                }
                inicial.X = 0;
                inicial.Y += 20;
            }
        }
        public void Dibuja(PictureBox p) 
        {
            Graphics g = p.CreateGraphics();
            Size tam = new Size(20, 20);

            foreach (Cuadro c in cuadritos)
            {
                if (c.Estado == true)
                {
                    rect = new Rectangle(c.coordenadas, tam);
                    g.FillRectangle(c.Brocha4, rect);
                    ControlPaint.DrawBorder(g, rect, Color.Black, ButtonBorderStyle.Inset);
                }
            }
        }
        public void VerificarLineas()
        {
            bool[] Lineas=new bool[20];
            for (int i = 0; i < Lineas.Length; i++)
            {
                Lineas[i] = false;
            }
            int ContadorColumnas = 0;
            int CordY = 0;
            for (int i = 0; i < 20; i++)
            {
                //List<Cuadro> temp= cuadritos.Select(x=>x).Where(x=>x.coordenadas.Y==cont);
                foreach (Cuadro c in cuadritos.Select(x => x).Where(x => x.coordenadas.Y == CordY))
                {
                    if (c.Estado)
                        ContadorColumnas++;
                }
                if(ContadorColumnas==10)
                {
                    Lineas[i] = true;
                    ContadorColumnas = 0;
                }
                else
                {
                    ContadorColumnas = 0;
                }
                CordY += 20;
            }
            bool limpiarLineas = false;
            foreach (bool b in Lineas)
            {
                if (b)
                    limpiarLineas = true;
            }
            if (limpiarLineas)
                LimpiarLineas(Lineas);
        }
        public void LimpiarLineas(bool[] Lineas)
        {
            for (int i = 0; i < Lineas.Length; i++)
			{
                if(Lineas[i])
                {
                    foreach (Cuadro c in cuadritos.Select(x => x).Where(x => x.coordenadas.Y == (20*i)))
                    {
                        c.Estado = false;
                    }
                    bool[,] Cuadros = VerificarCuadrosOcupados();
                    int contador = 0;
                    for (int j = i; j > 0; j--)
                    {
                        foreach (Cuadro c in cuadritos.Select(x => x).Where(x => x.coordenadas.Y == (20*j)))
                        {
                            if (Cuadros[j-1, contador])
                                c.Estado = true;
                            else
                                c.Estado = false;
                            contador++;
                        }
                        contador = 0;
                    }
                    puntos++;
                }
            }
            bool[,] Cuadros2 = VerificarCuadrosOcupados();
            VerificarLineas();
        }
        public bool[,] VerificarCuadrosOcupados()
        {
            bool[,] Cuadros = new bool[20, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Cuadros[j, i] = false;
                }
            }
            int contador = 0;
            for (int i = 0; i < 20; i++)
            {
                foreach (Cuadro c in cuadritos.Select(x => x).Where(x => x.coordenadas.Y == (i*20)))
                {
                    if (c.Estado)
                        Cuadros[i, contador] = true;
                    contador++;
                }
                contador = 0;
            }
            return Cuadros;
        }
        public int ObtenerPuntos()
        {
            return puntos;
        }
        public bool Perder()
        {
            bool resultado = false;
            bool[,] Matrix = VerificarCuadrosOcupados();
            for (int i = 0; i < 10; i++)
            {
                if (Matrix[0, i])
                    resultado = true;
            }
            return resultado;
        }
    }
}

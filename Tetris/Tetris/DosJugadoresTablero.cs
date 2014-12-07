﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris.Piezas;
using System.Runtime.Serialization.Json;
using System.Drawing;

namespace Tetris
{
    public partial class DosJugadoresTablero : Form
    {
        bool Servidor = false;
        public DosJugadoresTablero(bool s)
        {
            Servidor = s;
            InitializeComponent();
        }

        Tablero tab = new Tablero();
        Tablero tab2= new Tablero();
        Pieza pi = new Pieza(new Cubo(), new Point(100, 0), OrientacionPieza.Arriba);
        bool iniciado = true;
        public SolidBrush Brocha = new SolidBrush(Color.Red);
        public SolidBrush Brocha1 = new SolidBrush(Color.Orange);
        public SolidBrush Brocha2 = new SolidBrush(Color.Yellow);
        public SolidBrush Brocha3 = new SolidBrush(Color.Green);
        public SolidBrush Brocha4 = new SolidBrush(Color.Blue);
        public SolidBrush Brocha5 = new SolidBrush(Color.Indigo);
        public SolidBrush Brocha6 = new SolidBrush(Color.Violet);
        private void DosJugadoresTablero_Load(object sender, EventArgs e)
        {

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Down)
            {

                if (pi.MoverAbajo(tab))
                {
                    pi = new Pieza(NuevaPieza(), new Point(100, 0),/*NuevaOrientacion()*/OrientacionPieza.Arriba);
                    tab.VerificarLineas();
                    if (tab.Perder())
                    {
                        MessageBox.Show("Haz Perdido!!\nPuntos: " + lbPuntos.Text);
                        tab = new Tablero();
                    }
                    lbPuntos.Text = tab.ObtenerPuntos().ToString();
                }
                Refrescar();
                EnviarRecibir();
            }
            if (keyData == Keys.Right)
            {
                pi.MoverDerecha(tab);
                Refrescar();
                EnviarRecibir();
            }
            if (keyData == Keys.Left)
            {
                pi.MoverIzquierda(tab);
                Refrescar();
                EnviarRecibir();
            }
            if (keyData == Keys.Up)
            {
                pi.Rotar(tab);
                Refrescar();
                EnviarRecibir();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        public void Refrescar()
        {
            PBJugador1.Refresh();
            pi.Dibujar(PBJugador1);
            tab.Dibuja(PBJugador1);
        }
        public void RefrescarS(Pieza Pie)
        {
            PBJugador2.Refresh();
            Pie.Dibujar(PBJugador2);
            tab2.Dibuja(PBJugador2);
        }
        public IPieza NuevaPieza()
        {
            IPieza pieza = new Cubo();
            Random r = new Random();
            int x = r.Next(1, 8);
            switch (x)
            {
                case 1:
                    pieza = new Cubo();
                    break;
                case 2:
                    pieza = new I();
                    break;
                case 3:
                    pieza = new Jota();
                    break;
                case 4:
                    pieza = new ELE();
                    break;
                case 5:
                    pieza = new ESE();
                    break;
                case 6:
                    pieza = new Te();
                    break;
                case 7:
                    pieza = new Zeta();
                    break;
            }
            return pieza;
        }
        public OrientacionPieza NuevaOrientacion()
        {
            OrientacionPieza op = OrientacionPieza.Arriba;
            Random r = new Random();
            int x = r.Next(1, 5);
            switch (x)
            {
                case 1:
                    op = OrientacionPieza.Arriba;
                    break;
                case 2:
                    op = OrientacionPieza.Abajo;
                    break;
                case 3:
                    op = OrientacionPieza.Derecha;
                    break;
                case 4:
                    op = OrientacionPieza.Izquierda;
                    break;
            }
            return op;
        }
        public void EnviarRecibir()
        {
            if (Servidor)
            {
                try
                {
                    IPAddress ipAd = IPAddress.Any;
                    TcpListener myList = new TcpListener(ipAd, 8001);
                    myList.Start();


                    //Pieza
                    Socket s = myList.AcceptSocket();
                    byte[] b = new byte[1000000];
                    int k = s.Receive(b);

                    MemoryStream memStream = new MemoryStream();
                    BinaryFormatter binForm = new BinaryFormatter();
                    memStream.Write(b, 0, b.Length);
                    memStream.Seek(0, SeekOrigin.Begin);
                    Pieza p = (Pieza)binForm.Deserialize(memStream);

                    if (p.pieza.ToString() == "Cubo") 
                    {
                        foreach (Cuadro c in p.PiezaO)
                        {
                            c.Brocha = Brocha;
                            c.Brocha1 = Brocha;
                            c.Brocha2 = Brocha;
                            c.Brocha3 = Brocha;
                            c.Brocha4 = Brocha;
                            c.Brocha5 = Brocha;
                            c.Brocha6 = Brocha;
                        }
                    }
                    if (p.pieza.ToString() == "I")
                    {
                        foreach (Cuadro c in p.PiezaO)
                        {
                            c.Brocha = Brocha3;
                            c.Brocha1 = Brocha3;
                            c.Brocha2 = Brocha3;
                            c.Brocha3 = Brocha3;
                            c.Brocha4 = Brocha3;
                            c.Brocha5 = Brocha3;
                            c.Brocha6 = Brocha3;
                        }
                    }
                    if (p.pieza.ToString() == "Jota")
                    {
                        foreach (Cuadro c in p.PiezaO)
                        {
                            c.Brocha = Brocha2;
                            c.Brocha1 = Brocha2;
                            c.Brocha2 = Brocha2;
                            c.Brocha3 = Brocha2;
                            c.Brocha4 = Brocha2;
                            c.Brocha5 = Brocha2;
                            c.Brocha6 = Brocha2;
                        }
                    }
                    if (p.pieza.ToString() == "Te")
                    {
                        foreach (Cuadro c in p.PiezaO)
                        {
                            c.Brocha = Brocha6;
                            c.Brocha1 = Brocha6;
                            c.Brocha2 = Brocha6;
                            c.Brocha3 = Brocha6;
                            c.Brocha4 = Brocha6;
                            c.Brocha5 = Brocha6;
                            c.Brocha6 = Brocha6;
                        }
                    }
                    if (p.pieza.ToString() == "ESE")
                    {
                        foreach (Cuadro c in p.PiezaO)
                        {
                            c.Brocha = Brocha4;
                            c.Brocha1 = Brocha4;
                            c.Brocha2 = Brocha4;
                            c.Brocha3 = Brocha4;
                            c.Brocha4 = Brocha4;
                            c.Brocha5 = Brocha4;
                            c.Brocha6 = Brocha4;
                        }
                    }
                    if (p.pieza.ToString() == "ELE")
                    {
                        foreach (Cuadro c in p.PiezaO)
                        {
                            c.Brocha = Brocha1;
                            c.Brocha1 = Brocha1;
                            c.Brocha2 = Brocha1;
                            c.Brocha3 = Brocha1;
                            c.Brocha4 = Brocha1;
                            c.Brocha5 = Brocha1;
                            c.Brocha6 = Brocha1;
                        }
                    }
                    if (p.pieza.ToString() == "Zeta")
                    {
                        foreach (Cuadro c in p.PiezaO)
                        {
                            c.Brocha = Brocha5;
                            c.Brocha1 = Brocha5;
                            c.Brocha2 = Brocha5;
                            c.Brocha3 = Brocha5;
                            c.Brocha4 = Brocha5;
                            c.Brocha5 = Brocha5;
                            c.Brocha6 = Brocha5;
                        }
                    }
                    
                    RefrescarS(p);
                    myList.Stop();

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else
            {
                try
                {
                    TcpClient tcpclnt = new TcpClient();
                    tcpclnt.Connect("192.168.1.78", 8001);


                    byte[] bytes;
                    IFormatter formatter = new BinaryFormatter();
                    using (MemoryStream stream = new MemoryStream())
                    {
                        formatter.Serialize(stream, pi);
                        bytes = stream.ToArray();
                    }
                    NetworkStream cosa = tcpclnt.GetStream();
                    cosa.Write(bytes, 0, bytes.Length);

                    
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
           
        }
        private void DosJugadoresTablero_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {

        }


    }
}

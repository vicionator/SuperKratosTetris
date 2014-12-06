using System;
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
        Pieza pi = new Pieza(new Cubo(), new Point(100, 0), OrientacionPieza.Arriba);
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
        public void RefrescarS(PictureBox pb, Pieza Pie,Tablero Tab)
        {
            pb.Refresh();
            Pie.Dibujar(pb);
            Tab.Dibuja(pb);
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

                    //Recibir(Pieza, Tablero)
                    /* Socket s = myList.AcceptSocket();
                     byte[] b = new byte[1000000];
                     int k = s.Receive(b);
                     /*for (int i = 0; i < k; i++)
                         Console.Write(Convert.ToChar(b[i]));*/

                    //Pieza
                    Socket s = myList.AcceptSocket();
                    byte[] b = new byte[1000000];
                    int k = s.Receive(b);
                    List<Cuadro> cuadros = new List<Cuadro>();
                    int x=-1;
                    int y=-1;
                    string aux = "";
                    for (int i = 0; i < k; i++)
                    {
                        if (Convert.ToChar(b[i]) != ',')
                        aux += Convert.ToChar(b[i]);
                        if (Convert.ToChar(b[i])==','&&x==-1)
                        {
                            x = int.Parse(aux);
                            aux = "";
                        }
                        else if(Convert.ToChar(b[i])==','&&x!=-1)
                        {
                            y = int.Parse(aux);
                            aux = "";
                        }
                        else if(x!=-1&&y!=-1)
                        {
                            cuadros.Add(new Cuadro(new Point(x, y)));
                            x = -1;
                            y = -1;
                            aux = "";
                        }
                    }

                    Socket s1 = myList.AcceptSocket();
                    byte[] b1 = new byte[1000000];
                    int k1 = s1.Receive(b1);
                    string pieza = "";
                    for (int i = 0; i < k1; i++)
                    {
                        pieza+=Convert.ToChar(b1[i]);
                    }

                    Socket s2 = myList.AcceptSocket();
                    byte[] b2 = new byte[1000000];
                    int k2 = s2.Receive(b2);
                    string OP = "";
                    for (int i = 0; i < k2; i++)
                    {
                        OP += Convert.ToChar(b2[i]);
                    }
                    IPieza ip = new Cubo();
                    switch(pieza)
                    {
                        case "Cubo":
                            ip = new Cubo();
                            break;
                    }
                    OrientacionPieza op = OrientacionPieza.Arriba;
                    switch (pieza)
                    {
                        case "Arriba":
                            op = OrientacionPieza.Arriba;
                            break;
                    }
                    Pieza p = new Pieza(ip, cuadros[0].coordenadas, op);

                   //Tablero
                   //TcpClient client2 = myList.AcceptTcpClient();
                   //NetworkStream strm2 = client.GetStream();
                   //IFormatter formatter2 = new BinaryFormatter();
                   //Tablero t = (Tablero)formatter.Deserialize(strm2); // you have to cast the deserialized object

                   //Enviar(Pieza, Tablero)
                   /*ASCIIEncoding asen = new ASCIIEncoding();
                   string m = "Servidor: " + Console.ReadLine() + "\n";
                   s.Send(asen.GetBytes(m));
                   s.Close();
                   myList.Stop();*/

                    /*//Pieza
                    IFormatter formatterP = new BinaryFormatter(); // the formatter that will serialize my object on my stream 
                    NetworkStream strmP = client.GetStream(); // the stream 
                    formatterP.Serialize(strm, pi); // the serialization process 

                    //Tablero
                    IFormatter formatterT = new BinaryFormatter(); // the formatter that will serialize my object on my stream 
                    NetworkStream strmT = client.GetStream(); // the stream 
                    formatterT.Serialize(strm, tab); // the serialization process */
                    RefrescarS(PBJugador2, p, tab);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error en conexion Servidor");
                }
            }
            else
            {
                try
                {
                    TcpClient tcpclnt = new TcpClient();
                    tcpclnt.Connect("10.10.188.6", 8001);
                    //tcpclnt.Connect("10.10.181.43", 8001);
                    //tcpclnt.Connect("192.168.1.78", 8001);
                    //Enviar(Pieza, Tablero)

                    /*String str = "Cliente: " + Console.ReadLine() + "\n";
                    Stream stm = tcpclnt.GetStream();
                    ASCIIEncoding asen = new ASCIIEncoding();
                    byte[] ba = asen.GetBytes(str);
                    //Console.WriteLine("Enviando.....");
                    stm.Write(ba, 0, ba.Length);*/
                    ASCIIEncoding asen = new ASCIIEncoding();
                    //Pieza
                    NetworkStream streamC = tcpclnt.GetStream();
                    List<string> cord = new List<string>();
                    foreach (Cuadro c in pi.PiezaO)
                    {
                        cord.Add(c.coordenadas.X.ToString());
                        cord.Add(c.coordenadas.Y.ToString());
                    }
                    byte[] ba1 = asen.GetBytes(string.Join(",",cord));
                    streamC.Write(ba1, 0, ba1.Length);

                    String str = pi.pieza.ToString();
                    NetworkStream streamIP = tcpclnt.GetStream();
                    byte[] ba2 = asen.GetBytes(str);
                    streamIP.Write(ba2, 0, ba2.Length);

                    NetworkStream streamO = tcpclnt.GetStream();
                    byte[] ba3 = asen.GetBytes(pi.OP.ToString());
                    streamO.Write(ba3, 0, ba3.Length);

                    //Pieza
                    // IFormatter formatter = new BinaryFormatter(); // the formatter that will serialize my object on my stream 
                    // NetworkStream strm = tcpclnt.GetStream(); // the stream 
                    // formatter.Serialize(strm, pi); // the serialization process 

                    //Tablero
                    //IFormatter formatterT = new BinaryFormatter(); // the formatter that will serialize my object on my stream 
                    //NetworkStream strmT = tcpclnt.GetStream(); // the stream 
                    //formatterT.Serialize(strm, tab); // the serialization process 

                    //Tablero
                    /*MemoryStream stream2 = new MemoryStream();
                    DataContractJsonSerializer sert = new DataContractJsonSerializer(typeof(Tablero));
                    sert.WriteObject(stream1, tab);
                    stream2.Position = 0;
                    Tablero t1 = (Tablero)sert.ReadObject(stream2);*/

                    //Recibir(Pieza, Tablero)
                    /*byte[] bb = new byte[100];
                    int k = stm.Read(bb, 0, 100);
                    for (int i = 0; i < k; i++)
                        Console.Write(Convert.ToChar(bb[i]));
                    tcpclnt.Close();*/

                    /* //Pieza
                     TcpClient client = tcpclnt.AcceptTcpClient();
                     NetworkStream strm = tcpclnt.GetStream();
                     IFormatter formatter = new BinaryFormatter();
                     Pieza p = (Pieza)formatter.Deserialize(strm); // you have to cast the deserialized object

                     //Tablero
                     TcpClient client2 = tcpclnt.AcceptTcpClient();
                     NetworkStream strm2 = tcpclnt.GetStream();
                     IFormatter formatter2 = new BinaryFormatter();
                     Tablero t = (Tablero)formatter.Deserialize(strm2); // you have to cast the deserialized object*/
                }
                catch(Exception e)
                {
                    MessageBox.Show("Error en conexion Cliente");
                }
            }
           
        }


    }
}

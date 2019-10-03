using QGF.Network.Groups;
using QGF.Network.Users;
using QGF.Traitement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QGF.Network
{
    public class SocketMain
    {
 
        public static string username;
        public static IPAddress ip = IPAddress.Parse("78.114.52.238");
        public static int port = 5000;
        public static TcpClient client = new TcpClient();

        public static Thread thread = new Thread(o => ReceiveData((TcpClient)o));
        public static NetworkStream ns;
        public static int loadingstate = 0;
        public static bool connected = false;
        public static string todo = "keep";
        public static int onlineplayers;
        public static int onlinegroups;
        public static string f4todo = "keep";
        public static string f7todo = "keep";
        public static string f3todo = "keep";
        public  void Connect()
            
        {
            if (connected == false)
            {
                try
                {
                    client.Connect(ip, port);
                    connected = true;
                    while (loadingstate != 100)
                    {
                        loadingstate = loadingstate + 1;
                        Thread.Sleep(25);
                    }
                   
                }
                catch(Exception e)
                {
                    MessageBox.Show("Le serveur est actuellement indisponible: " + e.ToString());
                    Application.Exit();
                }
                try
                {
                    ns = client.GetStream();
                    thread.Start(client);
                    
                }
                catch
                {

                }

            }
                string s;
                while (!string.IsNullOrEmpty((s = Console.ReadLine())))
                {
                    byte[] buffer = Encoding.ASCII.GetBytes(s);
                    ns.Write(buffer, 0, buffer.Length);
                }
            
        }
        public static string data;
        public static bool isenabled = true;
        static void ReceiveData(TcpClient client)
        {
            NetworkStream ns = client.GetStream();
            byte[] receivedBytes = new byte[1024];
            int byte_count;
            while (ns.CanRead == true)
            {
                while (ns.DataAvailable)
                {
                    //MessageBox.Show("New data");
                    while ((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
                    {

                        string data = Encoding.ASCII.GetString(receivedBytes, 0, byte_count);

                        if (data.Contains("disable"))
                        {
                            if(isenabled == true)
                            {
                                isenabled = false;
                            }
                            else
                            {
                                isenabled = true;
                            }
                        }

                        if (data.Contains("notif"))
                        {
                            string[] splitter = data.Split('|');
                            MessageBox.Show(splitter[1]);
                        }
                        //else if (data.Contains("SendMessageSuccess"))
                        //{
                        //    string[] splitter = data.Split('|');

                        //    Form7 frm = new Form7();
                        //    frm.addOutMessage(splitter[1], Me.username);
                        //}


                        else if (data.Contains("NewMessage"))
                        {
                            //MessageBox.Show("nouveau message");
                            string[] splitter = data.Split('|');
                            string content = splitter[1];
                            string auteur = splitter[2];
                            ChatMessage c = new ChatMessage(content, auteur);
                            ChatMessage.mlist.Add(c);

                        }
                        else if (data.Contains("quit") || data.Contains("quitall"))
                        {
                            Application.Exit();
                        }
                        else if (data.Contains("OP"))
                        {
                            try
                            {
                                string[] splitter = data.Split('|');
                                onlineplayers = int.Parse(splitter[1]);
                                onlinegroups = int.Parse(splitter[2]);
                            }
                            catch
                            {

                            }
                        }
                        else if (data.Contains("disconnectsuccess"))
                        {
                            f3todo = "destroy";
                            todo = "destroy";
                            f4todo = "destroy";
                            f7todo = "destroy";

                        }
                        else if (data.Contains("regsuccess"))
                        {
                          
                        
                                SendToConnect();
                            f3todo = "destroy";
                            
                           
                        }
                        else if (data.Contains("regfailed"))
                        {
                            MessageBox.Show("Identifiants / Email déjà pris");
                        }

                        else if (data.Contains("authsuccess"))
                        {
                            string[] splitter = data.Split('|');
                            Me.rank = splitter[1];
                            new Thread(() =>
                            {
                                Form4 frm = new Form4();
                                frm.ShowDialog();
                            }).Start();
                            byte[] b = Encoding.ASCII.GetBytes("GetGroups");
                            SocketMain.SendData(b, SocketMain.ns);
                            todo = "destroy";

                        }
                        else if (data.Contains("PlayerKicked"))
                        {

                            foreach (User u in User.users)
                            {
                                string[] splitter = data.Split('|');
                                if (u.usernem == splitter[1])
                                {
                                    User.users.Remove(u);
                                    break;
                                }
                            }

                        }
                    else if (data.Contains("RoomDisbanded"))
                        {
                            User.users.Clear();
                            f4todo = "keep";
                            new Thread(() =>
                            {
                                Form4 frm = new Form4();
                                frm.ShowDialog();
                            }).Start();
                            byte[] b = Encoding.ASCII.GetBytes("GetGroups");
                            SocketMain.SendData(b, SocketMain.ns);
                            f7todo = "destroy";

                        }
                        else if (data.Contains("RoomKicked"))
                        {
                            string[] splitter = data.Split('|');
                            string admin = splitter[1];
                            f4todo = "keep";
                            new Thread(() =>
                            {
                                Form4 frm = new Form4();
                                frm.ShowDialog();
                            }).Start();


                            byte[] b = Encoding.ASCII.GetBytes("GetGroups");
                            SocketMain.SendData(b, SocketMain.ns);
                            f7todo = "destroy";
                            MessageBox.Show("Vous vous êtes fait exclure par " + admin);
                        }
                        else if (data.Contains("authbanned"))
                        {

                            MessageBox.Show("Ce compte à été banni de façon permanente de la plateforme QGF");
                        }
                        else if (data.Contains("authfailed"))
                        {

                            MessageBox.Show("Impossible de se connecter avec ces identifiants");
                        }
                        else if (data.Contains("RoomFull"))
                        {
                            MessageBox.Show("Salon Plein");
                        }
                        else if (data.Contains("JoinSuccess"))
                        {
                    
                            string[] splitter = data.Split('|');
                            //JoinSuccess|user1/premium;user2/free;user3/free;|roomtitle|roomdesc|author
                            if (splitter[5] == Me.username)
                            {
                                if (splitter[1] != "") {
                                    string[] users = splitter[1].Split(';');
                                    foreach (string u in users)
                                    {
                                        string[] ranks = u.Split('/');
                                        try
                                        {
                                            User user = new User(ranks[0], ranks[1]);
                                            User.users.Add(user);
                                        }
                                        catch
                                        {
                                            
                                        }
                                    }
                                }
                               
                                Me.currentroomname = splitter[2];
                                Me.currentroomdesc = splitter[3];
                                Me.currentroomadmin = splitter[4];
                                Me.currentroom = int.Parse(splitter[6]);
                            }
                            new Thread(() =>
                            {

                                Form7 frm = new Form7();
                                frm.ShowDialog();
                            }).Start();

                            f4todo = "destroy";

                        }
                        else if (data.Contains("PlayerDisconnect"))
                        {
                            string[] splitter = data.Split('|');
                            string username = splitter[1];
                            foreach(User u in User.users)
                            {
                                if(u.usernem == username)
                                {
                                    if (u.usernem == Me.currentroomadmin)
                                    {

                                    }
                                        User.users.Remove(u);
                                    
                                }
                            }
                        }
                        else if (data.Contains("PlayerJoined"))
                        {
                            bool got = false;
                            try
                            {

                                string[] splitter = data.Split('|');
                                data.Trim();
                                int i = int.Parse(splitter[3]);
                                if (i == Me.currentroom && splitter[1] != Me.username)
                                {
                                    // MessageBox.Show("oui" + Me.username);
                                    string username = splitter[1];
                                    string rank = splitter[2];
                                    User u = new User(username, rank);
                                    foreach (User us in User.users)
                                    {
                                        if (us.usernem.Contains(username))
                                        {
                                            got = true;
                                        }

                                    }
                                    if (got == false)
                                    {
                                        User.users.Add(u);
                                    }
                                }

                            


                            }
                            
                            
                            catch
                            {

                            }
                        }
                        else if (data.Contains("Groups"))
                        {
                            Group.g.Clear();
                       
                            try {
                                string[] splitter = data.Split(';'); // sépare les groupes
                                if (splitter[0] != "Groups|")
                                {
                                    splitter[0].Replace("Groups|", "");

                                    foreach (string s in splitter)
                                    {


                                        if (s.Contains("Groups|"))
                                        {

                                         
                                            string[] split = s.Split('|');
                                            string author = split[1];
                                            int actualplayer = int.Parse(split[2]);
                                            int maxplayers = int.Parse(split[3]);
                                            string _public = split[4];

                                            string gameID = split[8];
                                            string roomname = split[5];
                                            string roomdesc = split[6];
                                            int roomid = int.Parse(split[7]);
                                            string game = Game.GetNameByID(gameID);
                                        
                                            try
                                            {
                                                string rank = split[9];
                                                Group g = new Group(roomname, roomdesc, author, actualplayer, maxplayers, game, _public, roomid, rank);                                                                           
                                               Group.g.Add(g);
                                                    
                                          
                                            }
                                            catch
                                            {
                                                Group g = new Group(roomname, roomdesc, author, actualplayer, maxplayers, game, _public, roomid, "free");


                                                        Group.g.Add(g);
                                                    
                                                
                                            }


                                        }
                                        if (!s.Contains("Groups|") && s != "")
                                        {
                                            try
                                            {
                                                string[] split = s.Split('|');
                                                string author = split[0];
                                                int actualplayer = int.Parse(split[1]);
                                                int maxplayers = int.Parse(split[2]);
                                                string ispublic = split[3];
                                                string roomname = split[4];
                                                string roomdesc = split[5];
                                                int roomid = int.Parse(split[6]);
                                                string gameID = split[7];
                                                string rank = split[8];
                                                string game = Game.GetNameByID(gameID);
                                           
                                                Group g = new Group(roomname, roomdesc, author, actualplayer, maxplayers, game, ispublic, roomid, rank);
                                                Group.g.Add(g);
                                            }
                                            catch
                                            {
                                                try
                                                {
                                                    string[] split = s.Split('|');
                                                    string author = split[1];
                                                    int actualplayer = int.Parse(split[2]);
                                                    int maxplayers = int.Parse(split[3]);
                                                    string _public = split[4];
                                             
                                                    string gameID = split[8];
                                                    string roomname = split[5];
                                                    string roomdesc = split[6];
                                                    int roomid = int.Parse(split[7]);
                                                    string game = Game.GetNameByID(gameID);
                                                  
                                                    try
                                                    {
                                                        string rank = split[9];
                                                        Group g = new Group(roomname, roomdesc, author, actualplayer, maxplayers, game, _public, roomid, rank);

                                                        Group.g.Add(g);
                                                    }
                                                    catch
                                                    {
                                                        Group g = new Group(roomname, roomdesc, author, actualplayer, maxplayers, game, _public, roomid, "free");

                                                        Group.g.Add(g);
                                                    }
                                                }
                                                catch
                                                {
                                                   
                                                }
                                            }
                                        }
                                    }

                                }
                            }
                            catch(Exception e)
                            {
                                MessageBox.Show(e.ToString());
                            }
                            }
                        
                        else
                        {
                            MessageBox.Show("Message inconnu: " + data);
                        }
                    }
                    Application.Exit();
                }
              
            }

        }
        public static void HideForm(Form frm)
        {
            frm.Hide();
        }
        static void OpenForm(Form frms)
        {
            
        }
     

        static void SendToConnect()
        {
            Form1 frm = new Form1();
         
            frm.ShowDialog();
            f3todo = "destroy";
        }
     
        public static void SendData(byte[] b, NetworkStream nss)
        {
                nss.Write(b, 0, b.Length);          
        }

    public static void EndSession()
        {
         
            string msg = "DisconnectRequest|" + Me.username;
           SendData(Encoding.ASCII.GetBytes(msg), ns);
            //thread.Join();
        }
    }
}

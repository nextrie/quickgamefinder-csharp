using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QGF.Network.Groups
{
   public class Group
    {
       
        public string roomname;
        public string roomdescription;
        public string author;
        public int playercounter;
        public int desiredplayers;
        public string gameID;
        public string _public;
        public int roomIDs;
        public string ranks;
        public Group(string nameroom, string descroom, string roomauthor, int players, int maxplayers, string game, string isPublic, int roomID, string rank)
        {
            roomdescription = descroom;
            roomname = nameroom;
            author = roomauthor;
            playercounter = players;
            desiredplayers = maxplayers;
            _public = isPublic;
            gameID = game;
            ranks = rank;
            roomIDs = roomID;
        }
        public static List<Group> g = new List<Group>();
    }
}

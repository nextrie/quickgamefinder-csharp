using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QGF.Traitement
{
    public class ChatMessage
    {
        public static  List<ChatMessage> mlist = new List<ChatMessage>();
        public static string c;
        public static string a;
        public string pcontent;
        public string pauteur;
        public ChatMessage(string content, string auteur)
        {
            c = content;
            a = auteur;
            pcontent = content;
            pauteur = auteur;
        }
    }
}

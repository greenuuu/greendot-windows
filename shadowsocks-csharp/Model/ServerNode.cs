using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowSocks.Model
{
    public class ServerNode
    {
        private int id;
        private string name;
        private string icon;
        private string remark;
        private int linkcount;
        private bool selected;
        private string host;
        private string port;
        private string method;
        private string password;

        public int Linkcount { get => linkcount; set => linkcount = value; }
        public string Remark { get => remark; set => remark = value; }
        public string Icon { get => icon; set => icon = value; }
        public string Name { get => name; set => name = value; }
        public bool Selected { get => selected; set => selected = value; }
        public string Host { get => host; set => host = value; }
        public string Port { get => port; set => port = value; }
        public string Method { get => method; set => method = value; }
        public string Password { get => password; set => password = value; }
        public int Id { get => id; set => id = value; }
    }
}

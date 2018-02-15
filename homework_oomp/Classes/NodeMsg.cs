using System;
using System.Collections.Generic;
using System.Text;

namespace homework_oomp
{
    public class NodeMsg : IMessage
    {
        private string _header;
        private string _nodeaddress;

        public NodeMsg(string header, string address)
        {
            _header = header;
            _nodeaddress = address;
        }
        public string Payload()
        {
            return _nodeaddress;
        }
        public string Header()
        {
            return _header;
        }
    }
}

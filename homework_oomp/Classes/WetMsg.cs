using System;
using System.Collections.Generic;
using System.Text;

namespace homework_oomp
{
    public class WetMsg : IMessage
    {
        private string _header;
        private string _message;

        public WetMsg(string header, string message)
        {
            _header = header;
            _message = message;
        }
        public string Payload()
        {
            return _message;
        }
        public string Header()
        {
            return _header;
        }
    }
}

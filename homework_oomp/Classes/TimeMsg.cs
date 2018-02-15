using System;
using System.Collections.Generic;
using System.Text;

namespace homework_oomp
{
    public class TimeMsg: IMessage
    {
        private string _header;
        private string _stamp;

        public TimeMsg(string header, string timestamp)
        {
            _header = header;
            _stamp = timestamp;
        }
        public string Payload()
        {
            return _stamp;
        }
        public string Header()
        {
            return _header;
        }
    }
    
}

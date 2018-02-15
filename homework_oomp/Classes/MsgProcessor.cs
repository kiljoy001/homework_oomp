using System;
using System.Collections.Generic;
using System.Text;

namespace homework_oomp
{
    public class MsgProcessor
    {
        private List<IMessage> MsgHolder;

        public MsgProcessor()
        {
            MsgHolder = new List<IMessage>();
        }

        public void Add(IMessage message)
        {
            MsgHolder.Add(message);
        }

        public void Clear()
        {
            MsgHolder.Clear();
        }

        public List<IMessage> Digest { get { return MsgHolder; } }
    }
}

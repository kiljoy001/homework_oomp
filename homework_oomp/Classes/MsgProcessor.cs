using System;
using System.Collections.Generic;
using System.Text;

namespace homework_oomp
{
    public class MsgProcessor
    {
        private Queue<IMessage> MsgHolder;
        
        public MsgProcessor()
        {
            MsgHolder = new Queue<IMessage>();
        }

        public void Add(IMessage message)
        {
            MsgHolder.Enqueue(message);
        }

        public IMessage GetMessage()
        {
           return MsgHolder.Dequeue();
        }
        public void Clear()
        {
            MsgHolder.Clear();
        }

        public Queue<IMessage> Digest { get { return MsgHolder; } }
    }
}

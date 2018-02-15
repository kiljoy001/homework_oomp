using Autofac;
using homework_oomp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scrypt;

namespace MsgTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Processor()
        {
            //Arrange
            var Node = new ContainerBuilder();
            var Wet = new ContainerBuilder();
            var Time = new ContainerBuilder();
            Node.RegisterType<NodeMsg>().As<IMessage>();
            Wet.RegisterType<WetMsg>().As<IMessage>();
            Time.RegisterType<TimeMsg>().As<IMessage>();
            ScryptEncoder hashstring = new ScryptEncoder();
            string fakeHeader = hashstring.Encode("somerandomstring");
            MsgProcessor processor = new MsgProcessor();
           
           
            //Act
            

        }
    }
}

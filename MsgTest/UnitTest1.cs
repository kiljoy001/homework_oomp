using Moq;
using homework_oomp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace MsgTest
{
    [TestClass]
    public class UnitTest1
    {
        private const string payload = "{\"Id\":\"123\",\"DateOfRegistration\":\"2012-10-21T00:00:00+05:30\",\"Status\":0}";
        Mock<IMessage> mockNode = new Mock<IMessage>();
        Mock<IMessage> mockWet = new Mock<IMessage>();
        Mock<IMessage> mockTime = new Mock<IMessage>();
        MsgProcessor processor = new MsgProcessor();
        string fakeHeader ="some randome string";

        [TestMethod]
        public void Test_Processor_Add_Message()
        {
            //Arrange
            
            Arrange();
            //Act
            processor.Add((IMessage)mockNode.Object);
            processor.Add((IMessage)mockWet.Object);
            processor.Add((IMessage)mockTime.Object);
             
            
            //Assert
            Assert.AreEqual(processor.Digest.Count, 3);
            foreach(IMessage item in processor.Digest)
            {
                Assert.IsInstanceOfType(item, typeof(IMessage));
            }
        }

        [TestMethod]
        public void Test_Processor_Clear_Messages()
        {
            //Arrange
            Arrange();
            
            //Act
            processor.Add((IMessage)mockNode.Object);
            processor.Add((IMessage)mockWet.Object);
            processor.Add((IMessage)mockTime.Object);
            processor.Clear();

            //Assert
            Assert.AreEqual(processor.Digest.Count, 0);
        }

        [TestMethod]
        public void Test_Msg_Methods()
        {
            //Arrange
            Arrange();
            

            //Act
            processor.Add((IMessage)mockNode.Object);
            processor.Add((IMessage)mockWet.Object);
            processor.Add((IMessage)mockTime.Object);

            //Assert
            foreach (IMessage item in processor.Digest)
            {
                string header = item.Header();
                string data = item.Payload();
                Assert.AreEqual("some randome string", header);
                Assert.AreEqual("{\"Id\":\"123\",\"DateOfRegistration\":\"2012-10-21T00:00:00+05:30\",\"Status\":0}", data);
            }
        }

        private void Arrange()
        {
            mockNode.Setup(n => n.Header()).Returns(fakeHeader);
            mockNode.Setup(n => n.Payload()).Returns(payload);
            mockWet.Setup(n => n.Header()).Returns(fakeHeader);
            mockWet.Setup(n => n.Payload()).Returns(payload);
            mockTime.Setup(n => n.Header()).Returns(fakeHeader);
            mockTime.Setup(n => n.Payload()).Returns(payload);   
        }
    }
}

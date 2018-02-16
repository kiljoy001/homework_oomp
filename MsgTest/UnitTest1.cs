using Moq;
using homework_oomp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scrypt;
using System.Collections.Generic;

namespace MsgTest
{
    [TestClass]
    public class UnitTest1
    {
        private const string payload = "{\"Id\":\"123\",\"DateOfRegistration\":\"2012-10-21T00:00:00+05:30\",\"Status\":0}";
        [TestMethod]
        public void Test_Processor_Add_Message()
        {
            //Arrange
            var mockNode = new Mock<IMessage>();
            var mockWet = new Mock<IMessage>();
            var mockTime = new Mock<IMessage>();
            ScryptEncoder hashstring = new ScryptEncoder();
            string fakeHeader = hashstring.Encode("somerandomstring");
            mockNode.Setup(n => n.Header()).Returns(fakeHeader);
            mockNode.Setup(n => n.Payload()).Returns(payload);
            mockWet.Setup(n => n.Header()).Returns(fakeHeader);
            mockWet.Setup(n => n.Payload()).Returns(payload);
            mockTime.Setup(n => n.Header()).Returns(fakeHeader);
            mockTime.Setup(n => n.Payload()).Returns(payload);
            MsgProcessor processor = new MsgProcessor();

            //Act
            processor.Add(mockNode.Object);
            processor.Add(mockWet.Object);
            processor.Add(mockTime.Object);
             
            
            //Assert
            Assert.AreEqual(processor.Digest.Count, 3);
            foreach(IMessage item in processor.Digest)
            {
                Assert.IsInstanceOfType(item, typeof(IMessage));
            }
        }
    }
}

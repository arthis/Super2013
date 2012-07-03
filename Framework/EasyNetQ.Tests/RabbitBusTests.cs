using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;
using NUnit.Framework;
using Newtonsoft.Json;

namespace EasyNetQ.Tests
{
    [TestFixture]
    public class SerializationTests
    {
        public class MyMessage : IMessage
        {
            public Guid Id
            {
                get ; set; 
            }
            public Guid CommitId
            {
                get;
                set; 
            }
            public DateTime Date { get; set; }

            public string ToDescription()
            {
                throw new NotImplementedException();
            }
        }

        [Test]
        public void RabbitBus_Serialize_envelope()
        {
            Guid id = Guid.NewGuid();
            Guid commitId = Guid.NewGuid();
            DateTime now = DateTime.Now;
            var serializer =  new JsonSerializer();
            var msg = new MyMessage() {Id = id, CommitId = commitId, Date = now};
            var envelope = new Envelope<MyMessage>(commitId, msg);
            
            var bytes = serializer.MessageToBytes(envelope);

            Assert.IsNotNull(bytes);

            var message = JsonConvert.DeserializeObject<IEnvelope<MyMessage>>(Encoding.UTF8.GetString(bytes));

            Assert.IsNotNull(message);
            Assert.IsInstanceOf<Envelope<MyMessage>>(message);
            Assert.AreEqual(commitId, message.MessageId);
            Assert.AreEqual(id, message.PayLoad.Id);
            Assert.AreEqual(commitId, message.PayLoad.CommitId);
            Assert.AreEqual(now, message.PayLoad.Date);
            

        }
    }
}

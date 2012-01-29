using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mail;

namespace MailTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class MailBoxTests
    {
        [Serializable]
        public class InterventoTest
        {
            public Guid Id { get; set; }
            public DateTime? Inizio { get; set; }
            public DateTime? Fine { get; set; }
        }

        public MailBoxTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void MailBox_SendMessage()
        {
            //SendMessage(string from, string to, string oggetto, string filename, byte[] allegato)
            Guid g = Guid.NewGuid();
            string from = "super.testti@cert.trenitalia.it";
            string to = "super.testti@cert.trenitalia.it";
            string oggetto = "test " + g.ToString();
            string filename = "test.xml";
            DateTime inizio = DateTime.Now.AddDays(1);
            DateTime fine = inizio.AddHours(1);

            InterventoTest allegatoOggetto = new InterventoTest()
            {
                Id = g,
                Inizio = inizio,
                Fine = fine
            };

            byte[] allegato = Encoding.UTF8.GetBytes(Denormalizers.Tools.Serialization.Serialize(allegatoOggetto));


            MailBox box = new MailBox();
            
            box.SendMessage(from, to, oggetto, filename, allegato);


        }
    }
}

using Git;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for TransferStreamTest and is intended
    ///to contain all TransferStreamTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TransferStreamTest
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for TransferStream Constructor
        ///</summary>
        [TestMethod()]
        public void TransferStreamConstructorTest()
        {
            Stream writeableStream = null; // TODO: Initialize to an appropriate value
            TransferStream target = new TransferStream(writeableStream);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Close
        ///</summary>
        [TestMethod()]
        public void CloseTest()
        {
            Stream writeableStream = null; // TODO: Initialize to an appropriate value
            TransferStream target = new TransferStream(writeableStream); // TODO: Initialize to an appropriate value
            target.Close();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Flush
        ///</summary>
        [TestMethod()]
        public void FlushTest()
        {
            Stream writeableStream = null; // TODO: Initialize to an appropriate value
            TransferStream target = new TransferStream(writeableStream); // TODO: Initialize to an appropriate value
            target.Flush();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Read
        ///</summary>
        [TestMethod()]
        public void ReadTest()
        {
            Stream writeableStream = null; // TODO: Initialize to an appropriate value
            TransferStream target = new TransferStream(writeableStream); // TODO: Initialize to an appropriate value
            byte[] buffer = null; // TODO: Initialize to an appropriate value
            int offset = 0; // TODO: Initialize to an appropriate value
            int count = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Read(buffer, offset, count);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Seek
        ///</summary>
        [TestMethod()]
        public void SeekTest()
        {
            Stream writeableStream = null; // TODO: Initialize to an appropriate value
            TransferStream target = new TransferStream(writeableStream); // TODO: Initialize to an appropriate value
            long offset = 0; // TODO: Initialize to an appropriate value
            SeekOrigin origin = new SeekOrigin(); // TODO: Initialize to an appropriate value
            long expected = 0; // TODO: Initialize to an appropriate value
            long actual;
            actual = target.Seek(offset, origin);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SetLength
        ///</summary>
        [TestMethod()]
        public void SetLengthTest()
        {
            Stream writeableStream = null; // TODO: Initialize to an appropriate value
            TransferStream target = new TransferStream(writeableStream); // TODO: Initialize to an appropriate value
            long value = 0; // TODO: Initialize to an appropriate value
            target.SetLength(value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Write
        ///</summary>
        [TestMethod()]
        public void WriteTest()
        {
            Stream writeableStream = null; // TODO: Initialize to an appropriate value
            TransferStream target = new TransferStream(writeableStream); // TODO: Initialize to an appropriate value
            byte[] buffer = null; // TODO: Initialize to an appropriate value
            int offset = 0; // TODO: Initialize to an appropriate value
            int count = 0; // TODO: Initialize to an appropriate value
            target.Write(buffer, offset, count);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CanRead
        ///</summary>
        [TestMethod()]
        public void CanReadTest()
        {
            Stream writeableStream = null; // TODO: Initialize to an appropriate value
            TransferStream target = new TransferStream(writeableStream); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.CanRead;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CanSeek
        ///</summary>
        [TestMethod()]
        public void CanSeekTest()
        {
            Stream writeableStream = null; // TODO: Initialize to an appropriate value
            TransferStream target = new TransferStream(writeableStream); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.CanSeek;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CanWrite
        ///</summary>
        [TestMethod()]
        public void CanWriteTest()
        {
            Stream writeableStream = null; // TODO: Initialize to an appropriate value
            TransferStream target = new TransferStream(writeableStream); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.CanWrite;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Length
        ///</summary>
        [TestMethod()]
        public void LengthTest()
        {
            Stream writeableStream = null; // TODO: Initialize to an appropriate value
            TransferStream target = new TransferStream(writeableStream); // TODO: Initialize to an appropriate value
            long actual;
            actual = target.Length;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Position
        ///</summary>
        [TestMethod()]
        public void PositionTest()
        {
            Stream writeableStream = null; // TODO: Initialize to an appropriate value
            TransferStream target = new TransferStream(writeableStream); // TODO: Initialize to an appropriate value
            long expected = 0; // TODO: Initialize to an appropriate value
            long actual;
            target.Position = expected;
            actual = target.Position;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}

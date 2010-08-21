using Git;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for IObjectTest and is intended
    ///to contain all IObjectTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IObjectTest
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


        internal virtual IObject CreateIObject()
        {
            // TODO: Instantiate an appropriate concrete class.
            IObject target = null;
            return target;
        }

        /// <summary>
        ///A test for Deflate
        ///</summary>
        [TestMethod()]
        public void DeflateTest()
        {
            IObject target = CreateIObject(); // TODO: Initialize to an appropriate value
            string outputPath = string.Empty; // TODO: Initialize to an appropriate value
            target.Deflate(outputPath);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Digest
        ///</summary>
        [TestMethod()]
        public void DigestTest()
        {
            IObject target = CreateIObject(); // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = target.Digest;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Size
        ///</summary>
        [TestMethod()]
        public void SizeTest()
        {
            IObject target = CreateIObject(); // TODO: Initialize to an appropriate value
            ulong actual;
            actual = target.Size;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Type
        ///</summary>
        [TestMethod()]
        public void TypeTest()
        {
            //IObject target = CreateIObject(); // TODO: Initialize to an appropriate value
            //ObjectType expected = new ObjectType(); // TODO: Initialize to an appropriate value
            //ObjectType actual;
            //target.Type = expected;
            //actual = target.Type;
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}

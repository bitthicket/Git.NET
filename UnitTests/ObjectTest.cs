using System;
using System.IO;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using Git;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for ObjectTest and is intended
    ///to contain all ObjectTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ObjectTest
    {
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private const string m_RepositoryPath =
            @"D:\Users\Ben\Development\Bit Thicket\Projects\Git.NET\UnitTests\Repositories\TestGitRepo\.git";

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
        ///A test for CreateObject
        ///</summary>
        [TestMethod()]
        public void CreateObjectTest()
        {
            //string repoPath = string.Empty; // TODO: Initialize to an appropriate value
            //byte[] digest = null; // TODO: Initialize to an appropriate value
            //IObject expected = null; // TODO: Initialize to an appropriate value
            //IObject actual;
            //actual = Object.CreateObject(repoPath, digest);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CreateObject
        ///</summary>
        [TestMethod()]
        public void CreateObjectTest1()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Path.Combine(m_RepositoryPath, "objects"));
            foreach (var file in dirInfo.EnumerateFiles("*", SearchOption.AllDirectories))
            {
                Git.IObject obj = Git.Object.CreateObject(file.FullName);
                Assert.AreNotEqual(null, obj);
            }
        }

        /// <summary>
        ///A test for Deflate
        ///</summary>
        [TestMethod()]
        public void DeflateTest()
        {
            // this should be a 270k pdf called "order_quest.pdf"
            byte[] digest = Git.Object.DigestFromString("9090123a6aa941a83a2c5834f3f796001a042d93");  
            Git.IObject target = Git.Object.CreateObject(m_RepositoryPath, digest);
            string outputPath = Path.GetTempFileName();
            logger.Debug("deflating to {0}", outputPath);
            target.Deflate(outputPath);

            using (Stream input = File.OpenRead(outputPath))
            {
                Assert.AreEqual((ulong)input.Length, target.Size);
            }

            //File.Delete(outputPath);
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        public void DisposeTest()
        {
            //Object target = CreateObject(); // TODO: Initialize to an appropriate value
            //target.Dispose();
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Digest
        ///</summary>
        [TestMethod()]
        public void DigestTest()
        {
            //Object target = CreateObject(); // TODO: Initialize to an appropriate value
            //byte[] actual;
            //actual = target.Digest;
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Size
        ///</summary>
        [TestMethod()]
        public void SizeTest()
        {
            //Object target = CreateObject(); // TODO: Initialize to an appropriate value
            //ulong actual;
            //actual = target.Size;
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Type
        ///</summary>
        [TestMethod()]
        public void TypeTest()
        {
            //Object target = CreateObject(); // TODO: Initialize to an appropriate value
            //ObjectType expected = new ObjectType(); // TODO: Initialize to an appropriate value
            //ObjectType actual;
            //target.Type = expected;
            //actual = target.Type;
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}

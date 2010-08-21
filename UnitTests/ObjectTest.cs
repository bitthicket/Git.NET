using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NLog;

namespace UnitTests
{
    [TestClass]
    public class ObjectTest
    {
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private const string m_RepositoryPath = 
            @"D:\Users\Ben\Development\Bit Thicket\Projects\Git.NET\UnitTests\Repositories\TestGitRepo\.git";

        [TestMethod]
        public void CreateObjectTest()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Path.Combine(m_RepositoryPath, "objects"));
            foreach (var file in dirInfo.EnumerateFiles("*", SearchOption.AllDirectories))
            {
                Git.IObject obj = Git.Object.CreateObject(file.FullName);
                Assert.AreNotEqual(null, obj);
            }
        }
    }
}

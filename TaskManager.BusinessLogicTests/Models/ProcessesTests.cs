using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace TaskManager.BusinessLogic.Models.Tests
{
    [TestClass()]
    public class ProcessesTests
    {
        [TestMethod()]
        public void ProcessesTest()
        {
            string expected = "testhost";
            var proccess = new ProcessModel(Process.GetCurrentProcess());

            Assert.AreEqual(expected, proccess.Process.ProcessName);
        }
    }
}
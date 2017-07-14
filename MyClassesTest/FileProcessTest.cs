using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        [TestMethod]
        public void FileNameDoesExist()
        {
            FileProcess fp = new FileProcess();
            bool fileDoesExist = fp.FileExists(@"C:\Windows\Regedit.exe");

            Assert.IsTrue(fileDoesExist);
        }

        [TestMethod]
        public void FileNameDoesNotExist()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void FileNameNullOrEmpty_ThrowException()
        {
            Assert.Inconclusive();
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System.Configuration;
using System.IO;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE_NAME = "@C:\badFileName.bad";
        private string _GoodFileName;

        public void SetGoodFileName()
        {
            _GoodFileName = ConfigurationSettings.AppSettings["GoodFileName"];
            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPath]",
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }
        [TestMethod]
        public void FileNameDoesExist()
        {
            SetGoodFileName();
            File.AppendAllText(_GoodFileName, "Some text");
            FileProcess fp = new FileProcess();
            bool fileDoesExist = fp.FileExists(@"C:\Windows\Regedit.exe");
            File.Delete(_GoodFileName);

            Assert.IsTrue(fileDoesExist);
        }

        [TestMethod]
        public void FileNameDoesNotExist()
        {
            FileProcess fp = new FileProcess();
            bool fileDoesExist = fp.FileExists(BAD_FILE_NAME);

            Assert.IsFalse(fileDoesExist);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameNullOrEmpty_ThrowException()
        {
            FileProcess fp = new FileProcess();
            fp.FileExists("");
        }

        [TestMethod]
        public void FileNameNullOrEmpty_ThrowException_Using_Try_Catch()
        {
            FileProcess fp = new FileProcess();

            try { 
            fp.FileExists("");
            } catch (ArgumentNullException e)
            {
                return;
            }

            Assert.Fail("Test did not return ArgumentNullException");
        }
    }
}

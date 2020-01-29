using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace DesignPatterns
{
   public interface IFileHandler
    {
        void WriteData(Byte[] bytes, string pathToWriteTo);
        Byte[] ReadData();

    }

    class TextFileHandler : IFileHandler
    {
        public string Path;
        public TextFileHandler(string path)
        {
            this.Path = path;
        }
        public byte[] ReadData()
        {
            return File.ReadAllBytes(Path);
        }

        public void WriteData(Byte[] bytes,string pathToWriteTo)
        {
            File.WriteAllBytes(pathToWriteTo, bytes);
        }
    }

    class FileHandlerDecorator : IFileHandler
    {
        protected IFileHandler FileHandler;
        public FileHandlerDecorator(IFileHandler fileHandler)
        {
            this.FileHandler = fileHandler;
        }
        public virtual byte[] ReadData()
        {
            return FileHandler.ReadData();
        }

        public virtual void WriteData(Byte[] bytes, string pathToWriteTo)
        {
            FileHandler.WriteData(bytes, pathToWriteTo);
        }
    }
    class CompressFileDecorator: FileHandlerDecorator
    {
        public CompressFileDecorator(IFileHandler fileHandler):base(fileHandler)
        {
            FileHandler = fileHandler;
        }
        public override byte[] ReadData()
        {
            var bytes = FileHandler.ReadData();
            MemoryStream input = new MemoryStream(bytes);
            MemoryStream output = new MemoryStream();
            using (DeflateStream dstream = new DeflateStream(input, CompressionMode.Decompress))
            {
                dstream.CopyTo(output);
            }
            return output.ToArray();
        }

        public override void WriteData(byte[] bytes, string pathToWriteTo)
        {
            MemoryStream output = new MemoryStream();
            using (DeflateStream dstream = new DeflateStream(output, CompressionLevel.Optimal))
            {
                dstream.Write(bytes, 0, bytes.Length);
            }
            FileHandler.WriteData(output.ToArray(), pathToWriteTo);
        }
    }
    class EncryptFileDecorator : FileHandlerDecorator
    {
        public EncryptFileDecorator(IFileHandler fileHandler): base(fileHandler)
        {
            FileHandler = fileHandler;
        }
        public override byte[] ReadData()
        {
            var bytes = FileHandler.ReadData();
            var encryptedBytes = ProtectedData.Unprotect(bytes, null, DataProtectionScope.CurrentUser);
            return encryptedBytes;
        }

        public override void WriteData(Byte[] bytes, string pathToWriteTo)
        {
            var encryptedBytes = ProtectedData.Protect(bytes, null, DataProtectionScope.CurrentUser);
            FileHandler.WriteData(encryptedBytes, pathToWriteTo);
        }
    }
   
}


using BinaryFormatter;
using MortgageAppLibrary.Models.SavedFile;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortgageAppLibrary.FileActions
{
    public class FileServices
    {
        private BinaryConverter converter;

        public FileServices()
        {
            converter=new BinaryConverter();
        }
        public byte[] SaveDataFileToBinary(SavedFile savedFile)
        {
            byte[] savedBytes=converter.Serialize(savedFile);
            return savedBytes;
        }

        public SavedFile OpenDataFileFromBinary(byte[] fileBytes) 
        {
            SavedFile savedFile=converter.Deserialize<SavedFile>(fileBytes); 
            return savedFile;
        }
    }
}


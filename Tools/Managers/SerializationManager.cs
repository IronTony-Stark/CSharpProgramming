using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Managers
{
    internal static class SerializationManager
    {
        internal static void Serialize<T>(T obj, string filePath)
        {
            try
            {
                FileInfo file = new FileInfo(filePath);
                if (file.CreateFolderAndCheckFileExistence())
                    file.Delete();
                
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    formatter.Serialize(stream, obj);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to serialize data to file {filePath}", ex);
            }
        }

        internal static T Deserialize<T>(string filePath) where T: class
        {
            try
            {
                if (!FileFolderHelper.CreateFolderAndCheckFileExistence(filePath))
                    throw new FileNotFoundException("File doesn't exist.");
                
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(filePath, FileMode.Open))
                {
                    return (T) formatter.Deserialize(stream);
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException($"Failed to Deserialize Data From File {filePath}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to Deserialize Data From File {filePath}", ex);
            }
        }
    }
}

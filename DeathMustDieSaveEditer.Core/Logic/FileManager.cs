using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.Json;

namespace DeathMustDieSaveEditor.Core.Logic
{
    public class FileManager
    {
        private const string SaveRelevantPath = @"Realm Archive\Death Must Die\Saves";
        private const string SaveName = "Slot_0.sav";
        private const string BackUpFolderName = "SaveBackups";

        public FileManager()
        {
        }

        /// <summary>
        /// Returns string.Empty if save not found
        /// </summary>
        /// <returns></returns>
        public string GetSavePathIfExists()
        {
            string pathVariant1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), SaveRelevantPath, SaveName);
            string pathVariant2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), SaveRelevantPath, SaveName);
            string pathVariant3 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)+"Low", SaveRelevantPath, SaveName);

            if (File.Exists(pathVariant1))
            {
                return pathVariant1;
            }
            else if (File.Exists(pathVariant2))
            {
                return pathVariant2;
            }
            else if (File.Exists(pathVariant3))
            {
                return pathVariant3;
            }

            return string.Empty;
        }

        private void BackUpSave(string savePath)
        {
            string fileName = Path.GetFileName(savePath);
            string directory = savePath.Replace(fileName, "");
            string backUpDir = Path.Combine(directory, BackUpFolderName);
            if (!Directory.Exists(backUpDir))
                Directory.CreateDirectory(backUpDir);

            string backUpName = DateTime.Now.ToString("ddMMyy_HHmmss") + ".sav";
            string newFileLoc = Path.Combine(backUpDir, backUpName);
            File.Copy(savePath, newFileLoc, true);
        }

        /// <summary>
        /// This will override any stored data
        /// </summary>
        /// <param name="savePath"></param>
        /// <param name="data"></param>
        public void SaveData(string savePath, string data)
        {
            var zippedData = ZipString(data);
            this.WriteFile(savePath, zippedData);
        }

        public string LoadData(string saveFilePath)
        {
            this.BackUpSave(saveFilePath);

            string json = this.UnzipString(this.ReadByteFileToEnd(saveFilePath));
            return json;
        }

        private string ReaFileToEnd(string filePath)
        {
            using StreamReader stream = File.OpenText(filePath);
            return stream.ReadToEnd();
        }

        private byte[] ReadByteFileToEnd(string filePath)
        {
            byte[] fileData;
            using (FileStream fileStream = File.OpenRead(filePath))
            {
                fileData = new byte[fileStream.Length];
                fileStream.Read(fileData, 0, (int)fileStream.Length);
            }
            return fileData;
        }

        private string UnzipString(byte[] content)
        {
            using MemoryStream inputStream = new MemoryStream(content);
            using DeflateStream gzip = new DeflateStream(inputStream, CompressionMode.Decompress);
            using StreamReader reader = new StreamReader(gzip, Encoding.UTF8);
            return reader.ReadToEnd();
        }

        private byte[] ZipString(string content)
        {
            using MemoryStream output = new MemoryStream();
            using (DeflateStream gzip = new DeflateStream(output, CompressionMode.Compress))
            {
                using StreamWriter writer = new StreamWriter(gzip, Encoding.UTF8);
                writer.Write(content);
            }
            return output.ToArray();
        }

        private void WriteFile(string filePath, byte[] fileData)
        {
            using (FileStream fileStream = File.OpenWrite(filePath))
            {
                fileStream.Write(fileData, 0, fileData.Length);
            }
        }
    }
}

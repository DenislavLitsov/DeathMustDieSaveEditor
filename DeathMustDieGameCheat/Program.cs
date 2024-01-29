using DeathMustDieSaveEditor.Core.Logic;
using DeathMustDieSaveEditor.Core.Models.SaveStructure;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Nodes;


namespace DeathMustDieGameCheat
{
    internal class Program
    {
        const string fileLoc = "C:\\Users\\denis\\AppData\\LocalLow\\Realm Archive\\Death Must Die\\Saves\\Slot_0.sav";
        static void Main(string[] args)
        {
            DataManager dataManager = new DataManager();
            dataManager.TryLoadSaveAlone();

            Console.WriteLine(dataManager.GetGold());
            dataManager.SetGold(99999);
            Console.WriteLine(dataManager.GetGold());

            dataManager.SaveChanges();

            //dataManager.
            //LoadSave();
            //SaveSave();
            //var file = ReadFileAsync("E:\\Games\\Steam\\steamapps\\common\\Death Must Die\\Death Must Die_Data\\resources.assets");
            //string s = Convert.ToBase64String(file);
            //Console.WriteLine(s);
        }


        static void SaveSave()
        {
            var data = ReadTextFileAsync("save.txt");

            var zipper = ZipStringAsync(data);
            WriteFileAsync("newSave.txt", zipper);
        }

        static void LoadSave()
        {
            //var data = LoadJson("save.txt", true);
            
            var dataNotParsed = File.ReadAllText("save.txt");
            var asd = Newtonsoft.Json.JsonConvert.DeserializeObject(dataNotParsed);
            var parsed = Newtonsoft.Json.JsonConvert.DeserializeObject<SaveData>(dataNotParsed);
            
            var progression = parsed.serializedSaveData.GetProgression();
            var InventoryData = progression.GetEquippedItems("Knight");
            Console.WriteLine(InventoryData);


        }

        static string LoadJson(string filePath, bool binaryEncoded)
        {
            string json = ((!binaryEncoded) ? (ReadTextFileAsync(filePath)) : (UnzipStringAsync(ReadFileAsync(filePath))));
            return json;
        }

        public static string ReadTextFileAsync(string filePath)
        {
            using StreamReader stream = File.OpenText(filePath);
            return stream.ReadToEnd();
        }

        public static string UnzipStringAsync(byte[] content)
        {
            using MemoryStream inputStream = new MemoryStream(content);
            using DeflateStream gzip = new DeflateStream(inputStream, CompressionMode.Decompress);
            using StreamReader reader = new StreamReader(gzip, Encoding.UTF8);
            return reader.ReadToEnd();
        }

        public static byte[] ReadFileAsync(string filePath)
        {
            using FileStream fileStream = File.OpenRead(filePath);
            byte[] fileData = new byte[fileStream.Length];
            fileStream.Read(fileData, 0, (int)fileStream.Length);
            return fileData;
        }


        public static byte[] ZipStringAsync(string content)
        {
            using MemoryStream output = new MemoryStream();
            using (DeflateStream gzip = new DeflateStream(output, CompressionMode.Compress))
            {
                using StreamWriter writer = new StreamWriter(gzip, Encoding.UTF8);
                writer.WriteAsync(content);
            }
            return output.ToArray();
        }


        public static void WriteFileAsync(string filePath, byte[] fileData)
        {
            using FileStream fileStream = File.OpenWrite(filePath);
            fileStream.WriteAsync(fileData, 0, fileData.Length);
        }
    }
}
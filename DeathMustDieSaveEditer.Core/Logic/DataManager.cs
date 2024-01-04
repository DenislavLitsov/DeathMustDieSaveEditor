using DeathMustDieSaveEditor.Core.Models.SaveStructure;

namespace DeathMustDieSaveEditor.Core.Logic
{
    public class DataManager
    {
        private SaveData SaveData;

        private string SavePath;

        public DataManager()
        {
        }

        public bool TryLoadSaveAlone()
        {
            FileManager fileManager = new FileManager();
            string savePath = fileManager.GetSavePathIfExists();

            if (savePath == null || savePath == string.Empty)
                return false;

            this.SavePath = savePath;
            string json = fileManager.LoadData(savePath);
            this.ParseJsonToSaveStructure(json);

            return true;
        }

        public void LoadSave(string savePath)
        {
            this.SavePath = savePath;
            FileManager fileManager = new FileManager();
            string json = fileManager.LoadData(savePath);
            this.ParseJsonToSaveStructure(json);
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void SetGold(int newValue)
        {
            var progression = this.SaveData.serializedSaveData.GetProgression();
            progression.Gold = newValue;
            this.SaveData.serializedSaveData.SaveProgression(progression);
        }

        public IEnumerable<string> GetUnlockedHeroes()
        {
            var progression = this.SaveData.serializedSaveData.GetProgression();
            var heroNames = progression.InventoryData
                .Select(x=>x.CharacterCode)
                .ToList();

            return heroNames;
        }

        private void ParseJsonToSaveStructure(string jsonData)
        {
            var parsedData = Newtonsoft.Json.JsonConvert.DeserializeObject<SaveData>(jsonData);
            this.SaveData = parsedData;
        }
    }
}
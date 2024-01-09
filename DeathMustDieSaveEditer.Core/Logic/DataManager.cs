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

        /// <summary>
        /// Return File Path
        /// </summary>
        /// <returns></returns>
        public string TryLoadSaveAlone()
        {
            FileManager fileManager = new FileManager();
            string savePath = fileManager.GetSavePathIfExists();

            if (savePath == null || savePath == string.Empty)
                return string.Empty;

            this.SavePath = savePath;
            string json = fileManager.LoadData(savePath);
            this.ParseJsonToSaveStructure(json);

            return savePath;
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
            var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(this.SaveData);

            FileManager fileManager = new FileManager();
            fileManager.SaveData(this.SavePath, jsonData);
        }

        public int GetGold()
        {
            var progression = this.SaveData.serializedSaveData.GetProgression();
            return progression.Gold;
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
                .Select(x => x.CharacterCode)
                .ToList();

            return heroNames;
        }

        public IEnumerable<Item> GetItems(string heroClass)
        {
            var progression = this.SaveData.serializedSaveData.GetProgression();
            var items = progression.GetEquippedItems(heroClass);
            return items;
        }

        public bool IsHeroUnlocked(string heroName)
        {
            var heroes = this.GetUnlockedHeroes();
            return heroes.Any(x => x.ToUpper() == heroName.ToUpper());
        }

        public void UnlockHero()
        {
            throw new NotImplementedException();
        }

        private void ParseJsonToSaveStructure(string jsonData)
        {
            var parsedData = Newtonsoft.Json.JsonConvert.DeserializeObject<SaveData>(jsonData);
            this.SaveData = parsedData;
        }
    }
}
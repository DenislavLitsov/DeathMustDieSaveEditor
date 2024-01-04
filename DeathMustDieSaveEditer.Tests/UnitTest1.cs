using DeathMustDieSaveEditor.Core.Logic;
using DeathMustDieSaveEditor.Tests;

namespace DeathMustDieSaveEditor.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SetGoldTest()
        {
            DataManager dataManager = new DataManager();
            dataManager.TryLoadSaveAlone();

            int initGoldValue = dataManager.GetGold();
            int editedGoldValue = initGoldValue + 1;
            dataManager.SetGold(editedGoldValue);

            int sameDatamanagerNewGoldRead = dataManager.GetGold();
            Assert.That(sameDatamanagerNewGoldRead, Is.EqualTo(editedGoldValue));

            dataManager.SaveChanges();

            DataManager dataManager2 = new DataManager();
            dataManager2.TryLoadSaveAlone();

            int newReadGoldValue = dataManager2.GetGold();
            Assert.That(newReadGoldValue, Is.EqualTo(editedGoldValue));
        }
    }
}

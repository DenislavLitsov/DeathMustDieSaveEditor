using DeathMustDieSaveEditor.Core.Models;

namespace DeathMustDieSaveEditor.WPF.Helpers
{
    public class MainWindowHelper
    {
        public ItemType GetClickedType(int x, int y)
        {
            if (x >= 36 && y >= 155 &&
                x <= 134 && y <= 250)
            {
                return ItemType.Weapon;
            }
            else if (x >= 178 && y >= 6 &&
                x <= 273 && y <= 100)
            {
                return ItemType.Head;
            }
            else if (x >= 177 && y >= 132 &&
                x <= 278 && y <= 226)
            {
                return ItemType.Torso;
            }
            else if (x >= 104 && y >= 364 &&
                x <= 200 && y <= 458)
            {
                return ItemType.Hands;
            }
            else if (x >= 181 && y >= 239 &&
                x <= 273 && y <= 335)
            {
                return ItemType.Waist;
            }
            else if (x >= 254 && y >= 363 &&
                x <= 352 && y <= 461)
            {
                return ItemType.Feet;
            }
            else if (x >= 289 && y >= 256 &&
                x <= 386 && y <= 348)
            {
                return ItemType.Ring;
            }
            else if (x >= 65 && y >= 51 &&
                x <= 163 && y <= 148)
            {
                return ItemType.Amulet;
            }
            else if (x >= 290 && y >= 48 &&
                x <= 386 && y <= 147)
            {
                return ItemType.Relic;
            }
            else if (x >= 70 && y >= 261 &&
                x <= 155 && y <= 341)
            {
                return ItemType.Jewel;
            }
            else
            {
                return ItemType.NONE;
            }
        }
    }
}
using DeathMustDieSaveEditor.Core.Models.SaveStructure;
using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using System.Windows;
using System.Windows.Controls;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Interop;
using Button = System.Windows.Controls.Button;
using Label = System.Windows.Controls.Label;
using TextBox = System.Windows.Controls.TextBox;

namespace DeathMustDieSaveEditor.WPF.Helpers
{
    internal class MainWindowItemAttributeHelper
    {
        private readonly Grid grid;

        private int AttributeCount = 0;
        private int PixelHeightDifference = 25;

        List<string> AffixCodes = new List<string> { "a         ",
"e",
"h",
"hr",
"hol",
"hpg",
"ls       ",
"hok      ",
"ad%      ",
"sd%      ",
"d%       ",
"adeu%    ",
"sdeu%    ",
"deu%     ",
"adebl%   ",
"sdebl%   ",
"debl%    ",
"adeal%   ",
"sdeal%   ",
"deal%    ",
"acc%     ",
"scc%     ",
"cc%     ",
"dsum%    ",
"as%      ",
"ss%      ",
"s%       ",
"av%      ",
"sv%      ",
"v%       ",
"ang%     ",
"acnt     ",
"scnt     ",
"cnt      ",
"apnc     ",
"arng%    ",
"aare%    ",
"sare%    ",
"are%     ",
"u%       ",
"-thr%_e  ",
"ms       ",
"ms%      ",
"msp      ",
"dcld%    ",
"dchg     ",
"drng     ",
"akb      ",
"lck      ",
"pul      ",
"pxp      ",
"xp%      ",
"rev      ",
"brer     ",
"bban     ",
"bski     ",
"msa%     ",
"mse%     ",
"msm%     ",
"msl%     ",
"msru%    ",
"mslvl%   ",
"msnew%   ",
"msrarm   ",
"mic%     ",
"mir%     ",
"mie%     ",
"mim%     ",
"mii%     ",
"g%       ",
"pdr%     ",
"sp1      ",
"sp3      ",
"sp6      ",
"sp7      ",
"sp8      ",
"sp9      ",
"sp10     ",
"sp11     ",
"auoh1    ",
"auoh2    ",
"auoh3    ",
"auoh4    ",
"auoh5    ",
"auoh6    ",
"auoh7    ",
"auoh8    ",
"auoh9    ",
"soh3     ",
"soh4     ",
"soh7     ",
"sosh1    ",
"sod1     ",
"sod2     ",
"sod3     ",
"sod4     ",
"ssum1    ",
"ssum2    ",
"ssum3    ",
"ssum4    ",
"unstr    ",
"unstam   ",
"unwinter ",
"unequil  ",
"unsheph  ",
"unspirkni",
"unjackrab",
"ungodrage",
"undiabol ",
"unwitch  ",
"unsncane "
 };
        List<string> AffixNames = new List<string>()
        {
"            Armor                                  ",
"Evasion                                            ",
"Health                                             ",
"Health Regen                                       ",
"Heal on Level                                      ",
"Heals Multiplier                                   ",
"Lifesteal on Hit (% chance)                        ",
"Lifeheal on Kill (% chance)                        ",
"Attack Damage %                                    ",
"Spell Damage %                                     ",
"Damage %                                           ",
"Attack Damage % vs undamaged enemies               ",
"Spell Damage % vs undamaged enemies                ",
"Damage % vs undamaged enemies                      ",
"Attack Damage % vs enemies below % life            ",
"Spell Damage % vs enemies below % life             ",
"Damage % vs enemies below % life                   ",
"Attack Damage % vs enemies above % life            ",
"Spell Damage % vs enemies above % life             ",
"Damage % vs enemies above % life                   ",
"Attack Critical Chance %                           ",
"Spell Critical Chance %                            ",
"Critical Chance %                                  ",
"Summon Damage %                                    ",
"Attack Speed %                                     ",
"Faster Cooldowns %                                 ",
"Attack Speed & Faster Cooldowns %                  ",
"Attack Projectile Velocity %                       ",
"Spell Projectile Velocity %                        ",
"Projectile Velocity %                              ",
"Projectile Angle %                                 ",
"Attack Projectile Count                            ",
"Spell Skills Projectile Count                      ",
"Attack & Spell Skills Projectile Count             ",
"Attack Pounce                                      ",
"Attack Range %                                     ",
"Attack Area %                                      ",
"Spell Area %                                       ",
"Attack & Spell Area %                              ",
"Spell Duration %                                   ",
"Enemy Stun Threshold %                             ",
"Movement Speed                                     ",
"Movement Speed %                                   ",
"Movement Speed Penalty                             ",
"Dash Cooldown %                                    ",
"Dash Charges                                       ",
"Dash Range                                         ",
"Knockback (to attack)                              ",
"Luck                                               ",
"Pull Area                                          ",
"Passive Experience Gain                            ",
"Experience Gain %                                  ",
"Revival                                            ",
"Reroll                                             ",
"Banish                                             ",
"Skip                                               ",
"Adept Skills %                                     ",
"Expert Skills %                                    ",
"Master Skills %                                    ",
"Legend Skills %                                    ",
"Rarity Upgrade Offer %                             ",
"Level Upgrade Offer %                              ",
"New Offer %                                        ",
"Rarity Upgrade can upgrade Boons to Mythic.        ",
"Common Items Drop %                                ",
"Rare Items Drop %                                  ",
"Epic Items Drop %                                  ",
"Mythic Items Drop %                                ",
"Immortal Items Drop %                              ",
"Gold Multiplier %                                  ",
"Pick Ups Drop Multiplier %                         ",
"% To Heal on nth Kill                              ",
"On Hit Refresh Enemy Statuses                      ",
"Global DPS to Enemies                              ",
"-Global Damage % to Enemies                        ",
"-Enemy Attack and Cast Speed to Enemies            ",
"-Global Projectile Velocity % to Enemies           ",
"-Movement Speed % to Enemies                       ",
"Skill Passive (Crescents)                          ",
"Apply Status on nth Attack (Weakened)              ",
"Apply Status on nth Attack (Marked)                ",
"Apply Status on nth Attack (Burning)               ",
"Apply Status on nth Attack (Ruptured)              ",
"Apply Status on nth Attack (Chilled)               ",
"Apply Status on nth Attack (Frozen)                ",
"Apply Status on nth Attack (Feared)                ",
"Apply Status on nth Attack (Doomed)                ",
"Apply Status on nth Attack (Stunned)               ",
"Skill on nth Hit (ExtraAttack)                     ",
"Skill on nth Hit (BlackLightningBolt)              ",
"Skill on nth Hit (BreathOfFrost)                   ",
"Skill on nth Level Up (Meteor)                     ",
"Skill on nth Dash (FrostNova)                      ",
"Skill on nth Dash (PoisonNova)                     ",
"Skill on nth Dash (Sickles)                        ",
"Recharge Dash on Dash (Recharge Dash)              ",
"Skill Summon (BookWarrior)                         ",
"Skill Summon (DragonMort)                          ",
"Skill Summon (GreenParrot)                         ",
"Skill Summon (Skeleton)                            ",
"Strength                                           ",
"Stamina                                            ",
"Winter's Embrace                                   ",
"Equilibrium                                        ",
"Shepherd                                           ",
"Spirit Knife                                       ",
"Jackrabbit                                         ",
"Godrage                                            ",
"Diabolic II                                        ",
"Witchsword                                         ",
"Snowswatch Candy Cane                              "
        };

        private Item CurrItem = null;

        public MainWindowItemAttributeHelper(Grid grid)
        {
            this.grid = grid;

            List<string> newAffixes = new List<string>();
            foreach (var item in this.AffixCodes)
            {
                newAffixes.Add(item.Trim());
            }

            this.AffixCodes = newAffixes;

            List<string> newAffixeNames = new List<string>();
            foreach (var item in this.AffixNames)
            {
                newAffixeNames.Add(item.Trim());
            }

            this.AffixNames = newAffixeNames;
        }

        public void InitializeItem(Item item)
        {
            if (this.CurrItem != null)
                this.DeleteAllAttributeLines();

            this.CurrItem = item;
            foreach (Affix affix in this.CurrItem.Affixes)
            {
                this.CreateNewAttributeLine(affix.Code, affix.Levels.ToString());
            }
        }

        private void CreateNewAttributeLine(string affixCode, string textBoxValue)
        {
            Label dynamicLabel = new Label();
            dynamicLabel.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            dynamicLabel.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            dynamicLabel.Margin = new System.Windows.Thickness(10, 157 + PixelHeightDifference * AttributeCount, 0, 0);
            dynamicLabel.Content = this.GetAffixName(affixCode);
            dynamicLabel.ToolTip = this.GetAffixName(affixCode);
            dynamicLabel.Name = $"AttributeLabel{AttributeCount}";
            dynamicLabel.Width = 240;
            dynamicLabel.Height = 30;

            TextBox txtb = new TextBox();
            txtb.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            txtb.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            txtb.Margin = new System.Windows.Thickness(92, 161 + PixelHeightDifference * AttributeCount, 0, 0);
            txtb.Name = $"AttributeValueTextBox{AttributeCount}";
            txtb.Height = 18;
            txtb.Width = 120;
            txtb.Text = textBoxValue;

            Button btn = new Button();

            btn.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            btn.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            btn.Margin = new System.Windows.Thickness(241, 161 + PixelHeightDifference * AttributeCount, 0, 0);
            btn.Name = $"AttributeDeleteButton{AttributeCount}";
            btn.Height = 20;
            btn.Width = 39;
            btn.Content = "Delete";
            btn.Click += new RoutedEventHandler(ButtonAttributeDelete_Click);

            this.grid.Children.Add(dynamicLabel);
            this.grid.Children.Add(txtb);
            this.grid.Children.Add(btn);
            this.AttributeCount++;
        }

        private void DeleteAllAttributeLines()
        {
            this.grid.Children.RemoveRange(1, AttributeCount * 3);
            AttributeCount = 0;
        }

        private void DeleteAttributeLine(int lineNumber)
        {
            string LabelName = $"AttributeLabel{lineNumber}";
            string TextBoxName = $"AttributeValueTextBox{lineNumber}";
            string ButtonName = $"AttributeDeleteButton{lineNumber}";

            TextBox myTextBlock = null;
            Label myTextLabel = null;
            System.Windows.Controls.Button myButton = null;

            foreach (var child in this.grid.Children)
            {
                if (child is TextBox)
                {
                    var parsedChild = (TextBox)child;
                    if (parsedChild.Name == TextBoxName)
                    {
                        myTextBlock = parsedChild;
                    }
                }
                else if (child is Label)
                {
                    var parsedChild = (Label)child;
                    if (parsedChild.Name == LabelName)
                    {
                        myTextLabel = parsedChild;
                    }
                }
                else if (child is System.Windows.Controls.Button)
                {
                    var parsedChild = (System.Windows.Controls.Button)child;
                    if (parsedChild.Name == ButtonName)
                    {
                        myButton = parsedChild;
                    }
                }
            }

            this.grid.Children.Remove(myTextBlock);
            this.grid.Children.Remove(myTextLabel);
            this.grid.Children.Remove(myButton);
        }

        private void AffixWasChanged(int lineNumber, string newValue)
        {

        }

        private void ButtonAttributeDelete_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
            string Name = button.Name;
            int LetterCount = "AttributeDeleteButton".Length;
            string Number = Name.Substring(LetterCount, Name.Length - LetterCount);
            this.DeleteAttributeLine(int.Parse(Number));
        }

        private string GetCode(string name)
        {
            var index = this.AffixNames.IndexOf(name);
            var result = this.AffixCodes[index];
            return result;
        }

        private string GetAffixName(string code)
        {
            var index = this.AffixCodes.IndexOf(code);
            var result = this.AffixNames[index];
            return result;
        }
    }
}

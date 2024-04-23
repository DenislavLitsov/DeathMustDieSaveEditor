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
using ComboBox = System.Windows.Controls.ComboBox;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace DeathMustDieSaveEditor.WPF.Helpers
{
    internal class MainWindowItemAttributeHelper
    {
        private readonly Grid grid;

        private int AttributeCount = 0;
        private int PixelHeightDifference = 25;

        private List<string> AffixCodes = new List<string> { "a							  ",
"e							  ",
"h							  ",
"hr							  ",
"hol						  ",
"hpg						  ",
"ls							  ",
"hok						  ",
"hod						  ",
"d%							  ",
"ad%						  ",
"dd%						  ",
"sd%						  ",
"cd%						  ",
"pd%						  ",
"sud%						  ",
"std%						  ",
"deu%						  ",
"debl%						  ",
"deal%						  ",
"dbar						  ",
"cc%						  ",
"acc%						  ",
"dcc%						  ",
"scc%						  ",
"ccc%						  ",
"pcc%						  ",
"as%						  ",
"ss%						  ",
"sus%						  ",
"s%							  ",
"v%							  ",
"ang%						  ",
"acnt						  ",
"dcnt						  ",
"scnt						  ",
"ccnt						  ",
"pcnt						  ",
"sucnt						  ",
"apnc						  ",
"rng%						  ",
"arng%						  ",
"are%						  ",
"aare%						  ",
"dare%						  ",
"sare%						  ",
"care%						  ",
"pare%						  ",
"suare%						  ",
"u%							  ",
"du%						  ",
"su%						  ",
"cu%						  ",
"pu%						  ",
"suu%						  ",
"thr%_e						  ",
"sums%						  ",
"ms							  ",
"ms%						  ",
"msp						  ",
"dcld%						  ",
"dchg						  ",
"drng						  ",
"akb						  ",
"lck						  ",
"pul						  ",
"pxp						  ",
"xp%						  ",
"rev						  ",
"brer						  ",
"bban						  ",
"bski						  ",
"msa%						  ",
"mse%						  ",
"msm%						  ",
"msl%						  ",
"msru%						  ",
"mslvl%						  ",
"msnew%						  ",
"msrarm						  ",
"mic%						  ",
"mir%						  ",
"mie%						  ",
"mim%						  ",
"mii%						  ",
"miuniq%					  ",
"sslot						  ",
"cslot						  ",
"pslot						  ",
"suslot						  ",
"a%							  ",
"e%							  ",
"h%							  ",
"hr%						  ",
"pul%						  ",
"g%							  ",
"pdr%						  ",
"a-							  ",
"e-							  ",
"h-							  ",
"hr-						  ",
"hol-						  ",
"hpg-						  ",
"ls-						  ",
"hok-						  ",
"hod-						  ",
"d%-						  ",
"ad%-						  ",
"dd%-						  ",
"sd%-						  ",
"cd%-						  ",
"pd%-						  ",
"sud%-						  ",
"std%-						  ",
"deu%-						  ",
"debl%-						  ",
"deal%-						  ",
"dbar-						  ",
"cc%-						  ",
"acc%-						  ",
"dcc%-						  ",
"scc%-						  ",
"ccc%-						  ",
"pcc%-						  ",
"as%-						  ",
"ss%-						  ",
"sus%-						  ",
"s%-						  ",
"v%-						  ",
"ang%-						  ",
"acnt-						  ",
"dcnt-						  ",
"scnt-						  ",
"ccnt-						  ",
"pcnt-						  ",
"sucnt-						  ",
"apnc-						  ",
"rng%-						  ",
"arng%-						  ",
"are%-						  ",
"aare%-						  ",
"dare%-						  ",
"sare%-						  ",
"care%-						  ",
"pare%-						  ",
"suare%-					  ",
"u%-						  ",
"du%-						  ",
"su%-						  ",
"cu%-						  ",
"pu%-						  ",
"suu%-						  ",
"-thr%_e-					  ",
"sums%-						  ",
"ms-						  ",
"ms%-						  ",
"msp-						  ",
"dcld%-						  ",
"dchg-						  ",
"drng-						  ",
"akb-						  ",
"lck-						  ",
"pul-						  ",
"pxp-						  ",
"xp%-						  ",
"rev-						  ",
"brer-						  ",
"bban-						  ",
"bski-						  ",
"msa%-						  ",
"mse%-						  ",
"msm%-						  ",
"msl%-						  ",
"msru%-						  ",
"mslvl%-					  ",
"msnew%-					  ",
"msrarm-					  ",
"mic%-						  ",
"mir%-						  ",
"mie%-						  ",
"mim%-						  ",
"mii%-						  ",
"miuniq%-					  ",
"sslot-						  ",
"cslot-						  ",
"pslot-						  ",
"suslot-					  ",
"a%-						  ",
"e%-						  ",
"h%-						  ",
"hr%-						  ",
"pul%-						  ",
"g%-						  ",
"pdr%-						  ",
"auoh1						  ",
"auoh2						  ",
"auoh3						  ",
"auoh4						  ",
"auoh5						  ",
"auoh6						  ",
"auoh7						  ",
"auoh8						  ",
"auoh9						  ",
"auoh10						  ",
"auoh11						  ",
"auoh13						  ",
"soh1						  ",
"soh3						  ",
"soh4						  ",
"soh6						  ",
"soh7						  ",
"soh8						  ",
"soh9						  ",
"soh10						  ",
"soh11						  ",
"sod1						  ",
"sod2						  ",
"sod3						  ",
"sod4						  ",
"sod8						  ",
"sod10						  ",
"soga1						  ",
"sogh1						  ",
"sogh2						  ",
"sogh4						  ",
"solvl2						  ",
"sop1						  ",
"sop2						  ",
"sosh1						  ",
"sosh2						  ",
"soc2						  ",
"soc5						  ",
"ssum1						  ",
"ssum2						  ",
"ssum3						  ",
"ssum4						  ",
"ssum5						  ",
"ssum6						  ",
"ssum7						  ",
"ssum8						  ",
"ssum9						  ",
"ssum10						  ",
"sp1						  ",
"sp2						  ",
"sp3						  ",
"sp4						  ",
"sp5						  ",
"sp6						  ",
"sp7						  ",
"sp8						  ",
"sp9						  ",
"sp10						  ",
"sp11						  ",
"sp12						  ",
"sp13						  ",
"sp14						  ",
"sp15						  ",
"sp16						  ",
"sp17						  ",
"unstr						  ",
"unstam						  ",
"unwinter					  ",
"unequil					  ",
"unsheph					  ",
"unspirkni					  ",
"unjackrab					  ",
"ungodrage					  ",
"undiabol					  ",
"unwitch					  ",
"unsncane					  ",
"Bro						  ",
"Amuletus					  ",
"SacredBlood				  ",
"TheSucker					  ",
"DemonSoul					  ",
"Qareen						  ",
"CrescentAmulet				  ",
"SandAls					  ",
"BouncingBoots				  ",
"WalkenBoots				  ",
"BigFoot					  ",
"CatPaws					  ",
"Stealy						  ",
"DogPaws					  ",
"TheGeminator				  ",
"SandGhouls					  ",
"ColorfulGloves				  ",
"MediumHands				  ",
"TheGauntlet				  ",
"EyepatchDisguise			  ",
"SultanHat					  ",
"Gibberish					  ",
"FallOfTheKing				  ",
"TheQueenOfWorms			  ",
"TheZealot					  ",
"Bighead					  ",
"Pinky						  ",
"FateStone					  ",
"Possibility				  ",
"CatTail					  ",
"ZackGold					  ",
"TheEyeOfTheDune			  ",
"Butterfly					  ",
"AncientVirus				  ",
"ArabianNight				  ",
"SoftTowel					  ",
"GenericPen					  ",
"AncientHieroglyph1			  ",
"AncientHieroglyph2			  ",
"AncientHieroglyph3			  ",
"Hookah						  ",
"InfiniteFood				  ",
"Perfume					  ",
"Stopwatch					  ",
"SalamanderBiscuit			  ",
"ElectricCarrot				  ",
"MagicSand					  ",
"CrystalBall				  ",
"ColorlessRainbow			  ",
"DesertRose					  ",
"FlyingCarpet				  ",
"StrategicallyFriedRice		  ",
"TheSlab					  ",
"TheBlackLamp				  ",
"TheTomes					  ",
"Worm						  ",
"TheApprentice				  ",
"SorcerorsRing				  ",
"FarmersRing				  ",
"MirageRing					  ",
"GenieRing					  ",
"RingOfMusic				  ",
"TheCaterpillar				  ",
"TheEvilWardrobe			  ",
"CamelsBack					  ",
"TheNomadOfTheDune			  ",
"TheTrailedWanderer			  ",
"TheLoneWolf				  ",
"TheScarab					  ",
"TheWhaleOfTheDesertSeas	  ",
"Zaratan					  ",
"BlueBelt					  ",
"TheCode					  ",
"Waste						  ",
"TheBelt					  ",
"TheBlackFrame				  ",
"TheWoodenSword				  ",
"TheProtector				  ",
"RocSword					  ",
"Crusader					  ",
"FishKnife					  ",
"Tooltip					  ",
"WingsOfColor				  ",
"TheForgiver				  ",
"TheFeedBacker				  ",
"TheCarver					  ",
"Axident					  ",
"Karkadann					  ",
"ShyWhoLuud					  ",
"TheAnqa					  ",
"TheEagler					  ",
"Sandsword					  ",
"TheNameOfTheDesert			  ",
"TheScorpionQueen			  ",
"Spherenick					  ",
"PinkSnapper				  ",
"ScepterOfDomination		  ",
"TheScepterOfRasis			  ",
"TheEightColorStaff			  ",
"FireStarter				  ",
"Sharpshooter				  ",
"TheGoldenBow				  ",
"DuellingWinds				  ",
"adeu%						  ",
"sdeu%						  ",
"adebl%						  ",
"sdebl%						  ",
"adeal%						  ",
"sdeal%						  ",
"dsum%						  ",
"av%						  ",
"sv%						  ",
"cnt						  ",
"-thr%_e					  "
 };
        private List<string> AffixNames = new List<string>()
        {
"Armor																					",
"Evasion																				",
"Health																					",
"Health Regen																			",
"Heal on Level																			",
"Heals Multiplier %																		",
"Lifesteal on Hit (% chance)															",
"Lifeheal on Attack-Kill (% chance)														",
"Lifeheal on Enemy Dies (% chance)														",
"Damage %																				",
"Attack Damage %																		",
"Dash Damage %																			",
"Strike Damage %																		",
"Cast Damage %																			",
"Power Damage %																			",
"Summon Damage %																		",
"Status Damage %																		",
"Damage % vs undamaged enemies															",
"Damage % vs enemies below % life														",
"Damage % vs enemies above % life														",
"Damage % vs barriers																	",
"Critical Chance %																		",
"Attack Critical Chance %																",
"Dash Critical Chance %																	",
"Strike Critical Chance %																",
"Cast Critical Chance %																	",
"Power Critical Chance %																",
"Attack Speed %																			",
"Cooldown Reduction %																	",
"Summon Attack Speed %																	",
"Attack Speed & Faster Cooldowns %														",
"Projectile Velocity %																	",
"Projectile Angle %																		",
"Attack Projectile Count																",
"Dash Projectile Count																	",
"Strike Projectile Count																",
"Cast Projectile Count																	",
"Power Projectile Count																	",
"Summon Count																			",
"Attack Pounce																			",
"Range %																				",
"Attack Range %																			",
"Area %																					",
"Attack Area %																			",
"Dash Area %																			",
"Strike Area %																			",
"Cast Area %																			",
"Power Area %																			",
"Summon Attack Area %																	",
"Duration %																				",
"Dash Duration %																		",
"Strike Duration %																		",
"Cast Duration %																		",
"Power Duration %																		",
"Summon Duration %																		",
"Shorter Enemy Barriers %																",
"Summon Movement Speed %																",
"Movement Speed																			",
"Movement Speed %																		",
"Movement Speed Penalty																	",
"Dash Recharge Speed %																	",
"Dash Charges																			",
"Dash Distance																			",
"Knockback (to attack)																	",
"Luck %																					",
"Pull Area																				",
"Passive Experience Gain																",
"Experience Gain %																		",
"Revival																				",
"Reroll																					",
"Banish																					",
"Skip																					",
"Adept Skills %																			",
"Expert Skills %																		",
"Master Skills %																		",
"Legend Skills %																		",
"Rarity Upgrade Offer %																	",
"Level Upgrade Offer %																	",
"New Offer %																			",
"Rarity Upgrade can upgrade Boons to Mythic.											",
"Common Items Drop %																	",
"Rare Items Drop %																		",
"Epic Items Drop %																		",
"Mythic Items Drop %																	",
"Immortal Items Drop %																	",
"Unique Items Drop %																	",
"Strike Slot																			",
"Cast Slot																				",
"Power Slot																				",
"Summon Slot																			",
"Armor %																				",
"Evasion %																				",
"Health %																				",
"Health Regen %																			",
"Pull Area %																			",
"Gold Multiplier %																		",
"Pick Ups Drop Multiplier %																",
"Armor-																					",
"Evasion-																				",
"Health-																				",
"Health Regen-																			",
"Heal on Level-																			",
"Heals Multiplier %-																	",
"Lifesteal on Hit (% chance)-															",
"Lifeheal on Attack-Kill (% chance)-													",
"Lifeheal on Enemy Dies (% chance)-														",
"Damage %-																				",
"Attack Damage %-																		",
"Dash Damage %-																			",
"Strike Damage %-																		",
"Cast Damage %-																			",
"Power Damage %-																		",
"Summon Damage %-																		",
"Status Damage %-																		",
"Damage % vs undamaged enemies-															",
"Damage % vs enemies below % life-														",
"Damage % vs enemies above % life-														",
"Damage % vs barriers-																	",
"Critical Chance %-																		",
"Attack Critical Chance %-																",
"Dash Critical Chance %-																",
"Strike Critical Chance %-																",
"Cast Critical Chance %-																",
"Power Critical Chance %-																",
"Attack Speed %-																		",
"Cooldown Reduction %-																	",
"Summon Attack Speed %-																	",
"Attack Speed & Faster Cooldowns %-														",
"Projectile Velocity %-																	",
"Projectile Angle %-																	",
"Attack Projectile Count-																",
"Dash Projectile Count-																	",
"Strike Projectile Count-																",
"Cast Projectile Count-																	",
"Power Projectile Count-																",
"Summon Count-																			",
"Attack Pounce-																			",
"Range %-																				",
"Attack Range %-																		",
"Area %-																				",
"Attack Area %-																			",
"Dash Area %-																			",
"Strike Area %-																			",
"Cast Area %-																			",
"Power Area %-																			",
"Summon Attack Area %-																	",
"Duration %-																			",
"Dash Duration %-																		",
"Strike Duration %-																		",
"Cast Duration %-																		",
"Power Duration %-																		",
"Summon Duration %-																		",
"Shorter Enemy Barriers %-																",
"Summon Movement Speed %-																",
"Movement Speed-																		",
"Movement Speed %-																		",
"Movement Speed Penalty-																",
"Dash Recharge Speed %-																	",
"Dash Charges-																			",
"Dash Distance-																			",
"Knockback (to attack)-																	",
"Luck %-																				",
"Pull Area-																				",
"Passive Experience Gain-																",
"Experience Gain %-																		",
"Revival-																				",
"Reroll-																				",
"Banish-																				",
"Skip-																					",
"Adept Skills %-																		",
"Expert Skills %-																		",
"Master Skills %-																		",
"Legend Skills %-																		",
"Rarity Upgrade Offer %-																",
"Level Upgrade Offer %-																	",
"New Offer %-																			",
"Rarity Upgrade can upgrade Boons to Mythic.-											",
"Common Items Drop %-																	",
"Rare Items Drop %-																		",
"Epic Items Drop %-																		",
"Mythic Items Drop %-																	",
"Immortal Items Drop %-																	",
"Unique Items Drop %-																	",
"Strike Slot-																			",
"Cast Slot-																				",
"Power Slot-																			",
"Summon Slot-																			",
"Armor %-																				",
"Evasion %-																				",
"Health %-																				",
"Health Regen %-																		",
"Pull Area %-																			",
"Gold Multiplier %-																		",
"Pick Ups Drop Multiplier %-															",
"Apply Weakened on nth Attack															",
"Apply Marked on nth Attack																",
"Apply Burning on nth Attack															",
"Apply Ruptured on nth Attack															",
"Apply Chilled on nth Attack															",
"Apply Frozen on nth Attack																",
"Apply Fear on nth Attack																",
"Apply Cursed on nth Attack																",
"Apply Stunned on nth Attack															",
"Apply Smited on nth Attack																",
"Apply Immobilized on nth Attack														",
"Apply Poisoned on nth Attack															",
"Firebolt on nth Hit																	",
"Extra Attack on nth Hit																",
"Black LightningBolt on nth Hit															",
"Fire Trails on nth Hit																	",
"Breath of Frost on nth Hit																",
"Breath of Poison on nth Hit															",
"Lightning Zaps on nth Hit																",
"Lightning Bolt on nth Hit																",
"Black Chain Lightning on nth Hit (0-666, 6 on every 60 sec)							",
"Frost Nova on nth Dash																	",
"Poison Nova on nth Dash																",
"Half-Moons on nth Dash																	",
"Recharge Dash on Dash																	",
"Lightning Orb on Dash																	",
"Evasion on Dash																		",
"Black Single Chain Lightning on nth IsAttacked											",
"Lightning Bolt on nth GetHit															",
"Deal Damage Back on nth GetHit															",
"Fire Nova on nth GetHit																",
"Lightnings Bolts Armageddon on LvlUp													",
"Fear on EnemyPostureBreak																",
"Gain Gold on EliteKill																	",
"Meteors on nth DoodadUse																",
"Magnet on nth DoodadUse																",
"Firebolt on CD																			",
"Crescents on CD																		",
"Book Warrior Summon																	",
"Dragon Mort Summon																		",
"Green Parrot Summon																	",
"Skeleton Summon																		",
"Red Parrot Summon																		",
"Blue Parrot Summon																		",
"Yellow Parrot Summon																	",
"Pink Parrot Summon																		",
"Black Parrot Summon																	",
"White Parrot Summon																	",
"% To Heal % on nth BossKill															",
"Burning Malady																			",
"Refresh Enemy Statuses on nth Hit														",
"Damage % vs Statused Enemies															",
"Damage % vs Immobilized Enemies														",
"Global DPS to Enemies																	",
"Enemy Damage % Reduced																	",
"Enemy Attack Speeds % Reduced															",
"Enemy Projectile Velocity % Reduced													",
"Enemy Movement Speed % Reduced															",
"Enemy Actions Speed % Reduced															",
"Enemy Areas % Reduced																	",
"Enemy Aim % Reduced																	",
"Damage % vs Minions																	",
"Damage % vs Elites																		",
"Damage % vs Bosses																		",
"Attack Speed % when below % life														",
"Strength																				",
"Stamina																				",
"Winter's Embrace																		",
"Equilibrium																			",
"Shepherd																				",
"Spirit Knife																			",
"Jackrabbit																				",
"Godrage																				",
"Diabolic II																			",
"Witchsword																				",
"Snowswatch Candy Cane																	",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"																						",
"Attack Damage % vs undamaged enemies													",
"Strike Damage % vs undamaged enemies													",
"Attack Damage % vs enemies below % life												",
"Strike Damage % vs enemies below % life												",
"Attack Damage % vs enemies above % life												",
"Strike Damage % vs enemies above % life												",
"Summon Damage %																		",
"Attack Projectile Velocity %															",
"Projectile Velocity %																	",
"Projectile Count																		",
"Shorter Enemy Barriers %																"
        };

        private Item CurrItem = null;
        private string AffixNameBeforeChange;

        public event EventHandler ItemChanged;

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
            for (int i = 0; i < AffixNames.Count; i++)
            {
                string affixName = this.AffixNames[i];
                if (string.IsNullOrEmpty(affixName.Trim()) == false)
                {
                    newAffixeNames.Add(affixName.Trim());
                }
                else
                {
                    newAffixeNames.Add(this.AffixCodes[i]);
                }
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

        public void AddNewAffix()
        {
            if (this.CurrItem == null)
                return;

            var code = this.AffixCodes.First(x=>this.CurrItem.Affixes.Any(s=>s.Code == x) == false);
            this.CreateNewAttributeLine(code, "1");
            this.CurrItem.Affixes.Add(new Affix()
            {
                Code = code,
                Levels = 1
            });

            this.ItemChanged(this, null);
        }
        
        public void DeleteAllAttributeLines()
        {
            this.grid.Children.RemoveRange(2, AttributeCount * 3);
            AttributeCount = 0;
        }

        private void CreateNewAttributeLine(string affixCode, string textBoxValue)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            comboBox.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            comboBox.Margin = new System.Windows.Thickness(10, 157 + PixelHeightDifference * AttributeCount, 0, 0);
            //comboBox.Content = this.GetAffixName(affixCode);
            comboBox.ToolTip = this.GetAffixName(affixCode);
            comboBox.Name = $"AttributeLabel{AttributeCount}";
            comboBox.Width = 240;
            comboBox.Height = 22;
            for (int i = 0; i < AffixNames.Count; i++)
            {
                comboBox.Items.Add(AffixNames[i]);
            }
            comboBox.SelectedIndex = comboBox.Items.IndexOf(this.GetAffixName(affixCode));
            comboBox.DropDownOpened += new EventHandler(this.OnDropDownOpen);
            comboBox.SelectionChanged += new SelectionChangedEventHandler(this.OnDropDownSelectionChange);

            TextBox txtb = new TextBox();
            txtb.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            txtb.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            txtb.Margin = new System.Windows.Thickness(257, 159 + PixelHeightDifference * AttributeCount, 0, 0);
            txtb.Name = $"AttributeValueTextBox{AttributeCount}";
            txtb.Height = 18;
            txtb.Width = 120;
            txtb.Text = textBoxValue;
            txtb.TextChanged += ValueTextChanged;
            txtb.PreviewTextInput += this.NumberValidationTextBox;

            Button btn = new Button();

            btn.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            btn.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            btn.Margin = new System.Windows.Thickness(385, 158 + PixelHeightDifference * AttributeCount, 0, 0);
            btn.Name = $"AttributeDeleteButton{AttributeCount}";
            btn.Height = 20;
            btn.Width = 39;
            btn.Content = "Delete";
            btn.Click += new RoutedEventHandler(ButtonAttributeDelete_Click);

            this.grid.Children.Add(comboBox);
            this.grid.Children.Add(txtb);
            this.grid.Children.Add(btn);
            this.AttributeCount++;
        }

        private void DeleteAttributeLine(int lineNumber)
        {
            string LabelName = $"AttributeLabel{lineNumber}";
            string TextBoxName = $"AttributeValueTextBox{lineNumber}";

            TextBox myTextBlock = null;
            ComboBox myComboBox = null;

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
                else if (child is ComboBox)
                {
                    var parsedChild = (ComboBox)child;
                    if (parsedChild.Name == LabelName)
                    {
                        myComboBox = parsedChild;
                    }
                }
            }

            this.RemoveAffix(this.GetAffixCode(myComboBox.SelectedItem.ToString()), myTextBlock.Text);
        }

        private string GetAffixCode(string name)
        {
            var index = this.AffixNames.IndexOf(name);
            if (index == -1)
            {
                // This case is when the affix code has no name and the name is the code
                return name;
            }

            var result = this.AffixCodes[index];
            return result;
        }

        private string GetAffixName(string code)
        {
            var index = this.AffixCodes.IndexOf(code);
            var result = this.AffixNames[index];
            return result;
        }

        private void ValueTextChanged(object sender, TextChangedEventArgs e)
        {
            var parsedSender = (TextBox)sender;
            int letterCount = "AttributeValueTextBox".Length;
            var selectedIndex = parsedSender.Name.Substring(letterCount, parsedSender.Name.Length - letterCount);
            var attributeLabelName = $"AttributeLabel{selectedIndex}";

            foreach (var child in this.grid.Children)
            {
                if (child is ComboBox && ((ComboBox)child).Name == attributeLabelName)
                {
                    var affixName = ((ComboBox)child).SelectedValue.ToString();
                    var affixCode = this.GetAffixCode(affixName);

                    if (string.IsNullOrEmpty(parsedSender.Text))
                    {
                        parsedSender.Text = "1";
                    }

                    int value = int.Parse(parsedSender.Text);
                    if (value > 9999)
                    {
                        value = 9999;
                        parsedSender.Text = "9999";
                    }
                    else if (value < 0)
                    {
                        value = 1;
                        parsedSender.Text = "1";
                    }

                    this.CurrItem.Affixes.First(x => x.Code == affixCode).Levels = value;
                    this.ItemChanged(sender, e);
                }
            }
        }

        private void RemoveAffix(string affixCode, string affixValue)
        {
            var affixToRemove = this.CurrItem.Affixes.First(x => x.Code == affixCode && x.Levels.ToString() == affixValue);
            this.CurrItem.Affixes.Remove(affixToRemove);
            this.ItemChanged(this, null);
        }

        private void ButtonAttributeDelete_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
            string Name = button.Name;
            int LetterCount = "AttributeDeleteButton".Length;
            string Number = Name.Substring(LetterCount, Name.Length - LetterCount);

            this.DeleteAttributeLine(int.Parse(Number));
            this.DeleteAllAttributeLines();
            this.InitializeItem(this.CurrItem);
        }

        private void OnDropDownOpen(object sender, EventArgs e)
        {
            var combobox = (ComboBox)sender;
            this.AffixNameBeforeChange = combobox.SelectedValue.ToString();
        }

        private void OnDropDownSelectionChange(object sender, SelectionChangedEventArgs e)
        {
            var combobox = (ComboBox)sender;
            var newAffixName = combobox.SelectedValue.ToString();
            var newAffixCode = this.GetAffixCode(newAffixName);
            if (this.CurrItem.Affixes.Any(x=>x.Code == newAffixCode))
            {
                combobox.SelectedValue = this.AffixNameBeforeChange;
                return;
            }

            var oldAffixCode = this.GetAffixCode(this.AffixNameBeforeChange);
            this.CurrItem.Affixes.First(x => x.Code == oldAffixCode).Code = newAffixCode;

            this.ItemChanged(sender, e);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
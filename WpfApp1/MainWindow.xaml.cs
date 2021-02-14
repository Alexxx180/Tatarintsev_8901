﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace WpfApp1
{

    /// <summary>
    /// [EN] Interaction logic for game triggers.
    /// [RU] Интерактивная логика для внутренних механизмов.
    /// </summary>
    public class Descriptions
    {
        public class Foes : Descriptions
        {
            public Foes()
            {
                SetAllEnemyDscr();
            }
            private void SetAllEnemyDscr()
            {
                Spider = "Паук";
                Mummy = "Мумия";
                Zombie = "Зомби";
                Bones = "Страж";
                Vulture = "Стервятник";
                Ghoul = "Гуль";
                GrimReaper = "Жнец";
                Scarab = "Скарабей";
                GetByIndexes = new string[,] { { Spider, Mummy, Zombie, Bones }, { Vulture, Ghoul, GrimReaper, Scarab } };
            }
            public String Spider { get; set; }
            public String Mummy { get; set; }
            public String Zombie { get; set; }
            public String Bones { get; set; }
            public String Vulture { get; set; }
            public String Ghoul { get; set; }
            public String GrimReaper { get; set; }
            public String Scarab { get; set; }
            public String[,] GetByIndexes { get; set; }
        }
    }
    public class Paths
    {
        public void SetPaths()
        {
            PersonStatePath = new Static.Person();
            IconStatePath = new Static.Icon();
            FoesStatePath = new Static.Foes();
            BossesStatePath = new Static.Bosses();
            FoesAnimatePath = new Dynamic.Foes();
            BossesAnimatePath = new Dynamic.Bosses();
            PersonAnimatePath = new Dynamic.Person();
            IconAnimatePath = new Dynamic.Icon();
            MiscAnimatePath = new Dynamic.Misc();
            GameMusic = new OST.Music();
            GameSounds = new OST.Sounds();
            GameNoises = new OST.Noises();
            CutScene = new CutScenes();
            Backgrounds = new Static.Map();
            MapModels = new Static.Map.Models();
            Ray = new Static.Map.Models.Guy();
            Msg = new Static.Map.Messages();
            BtnCustomize = new Static.BtnImgs.Usual();
            BtnBefore = new Static.BtnImgs.Before();
            BtnAfter = new Static.BtnImgs.After();
            MenuImgs = new Static.Menu();
            Fighting = new Static.Battle();
            AniModel = new Paths.Dynamic.Models();
        }
        public class CutScenes : Paths
        {
            public CutScenes() { SetAllPaths(); }
            public void SetAllPaths()
            {
                Ambushed = @"Ambushed.mp4";
                BattleStations = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\BattleStarts\BattleStations2.mp4";
                PreChapter1 = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\ChaptersIntroduction\Chapter1.mp4";
                PreChapter2 = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\ChaptersIntroduction\Chapter2.mp4";
                PreChapter3 = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\ChaptersIntroduction\Chapter3.mp4";
                Victory = @"Win.mp4";
                WasteTime = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\BattleEnds\Win2.mp4";
                Fin_Chapter1 = @"Final1.mp4";
                Fin_Chapter2 = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\ChaptersEnding\Final2.mp4";
                Titres = @"Titres3.mp4";
            }
            public String Prologue { get; set; }
            public String Ambushed { get; set; }
            public String BattleStations { get; set; }
            public String PreChapter1 { get; set; }
            public String PreChapter2 { get; set; }
            public String PreChapter3 { get; set; }
            public String Victory { get; set; }
            public String WasteTime { get; set; }
            public String Fin_Chapter1 { get; set; }
            public String Fin_Chapter2 { get; set; }
            public String Titres { get; set; }
        }
        public class OST:Paths
        {
            public class Music : OST
            {
                public Music()
                {
                    SetAllPaths();
                }
                public void SetAllPaths()
                {
                    MainTheme = @"Begin2.mp3";
                    Prologue = @"Intro1.mp3";
                    AncientPyramid = @"Main_theme.mp3";
                    WaterTemple = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\OST\Music\WaterTemple_theme.mp3";
                    LavaTemple = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\OST\Music\FireTemple_theme.mp3";
                    FoesChase = @"Battle_theme2.mp3";
                    LookWhoAwake = @"Pharaoh.mp3";
                    SeriousIsMe = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SecretBossFight1.mp3";
                    AncientKey = @"Final1.mp3";
                    SayGoodbye = @"Titres.mp3";
                }
                public String MainTheme { get; set; }
                public String Prologue { get; set; }
                public String AncientPyramid { get; set; }
                public String WaterTemple { get; set; }
                public String LavaTemple { get; set; }
                public String FoesChase { get; set; }
                public String LookWhoAwake { get; set; }
                public String SeriousIsMe { get; set; }
                public String AncientKey { get; set; }
                public String SayGoodbye { get; set; }
            }
            public class Sounds : OST
            {
                public Sounds()
                {
                    SetAllPaths();
                }
                public void SetAllPaths()
                {
                    DoorOpened = @"DoorOpened1.mp3";
                    ChestOpened = @"ChestOpened1.mp3";
                    ControlSave = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SaveSound.mp3";
                    NowTheWinnerIs = @"YouWon.mp3";
                    SpiderDied = @"SpiderDied.mp3";
                    MummyDied = @"MummyDied.mp3";
                    ZombieDied = @"ZombieDied.mp3";
                    BonesDied = @"BonesDied.mp3";
                    PhaGetLost = @"DefeatPharaoh.mp3";
                }
                public String DoorOpened { get; set; }
                public String ChestOpened { get; set; }
                public String ControlSave { get; set; }
                public String NowTheWinnerIs { get; set; }
                public String SpiderDied { get; set; }
                public String MummyDied { get; set; }
                public String ZombieDied { get; set; }
                public String BonesDied { get; set; }
                public String PhaGetLost { get; set; }
            }
            public class Noises : OST
            {
                public Noises()
                {
                    SetAllPaths();
                }
                public void SetAllPaths()
                {
                    Danger = @"Ambushed.mp3";
                    Horror = @"Horror.mp3";
                    EgoRage = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\OST\Noises\PharaohRoar(Boss2)_1.mp3";
                    StrongStand = @"Defence.mp3";
                    FleeAway = @"Escape.mp3";
                    HandAttack = @"Punch.mp3";
                    Cure = @"Cure.mp3";
                    Heal = @"Heal.mp3";
                    Torch = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Torch.mp3";
                    Whip = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Whip.mp3";
                    Super = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Super.mp3";
                    BagOpen = @"ItemsOpen.mp3";
                    BagClose = @"ItemsClose.mp3";
                    UseItems = @"ItemsUsed.mp3";
                    LevelUp = "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp.mp3";
                }
                public String Danger { get; set; }
                public String Horror { get; set; }
                public String EgoRage { get; set; }
                public String StrongStand { get; set; }
                public String FleeAway { get; set; }
                public String HandAttack { get; set; }
                public String Cure { get; set; }
                public String Heal { get; set; }
                public String Torch { get; set; }
                public String Whip { get; set; }
                public String Super { get; set; }
                public String BagOpen { get; set; }
                public String BagClose { get; set; }
                public String UseItems { get; set; }
                public String LevelUp { get; set; }
            }
        }
        public class Static : Paths
        {
            public class Map
            {
                public Map()
                {
                    SetAllMapPaths();
                }
                public void SetAllMapPaths()
                {
                    Main = @"New_game_show.jpg";
                    Location1 = @"Loc1_2.jpg";
                    Location2 = @"Loc2_1.png";
                    Location3 = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Locations\Loc3.jpg";
                    Normal = @"AbsoluteBlack.jpg";
                    Register = "Wanted.png";
                    UnRegister = "Wanted2.png";
                }
                public class Models : Map
                {
                    public class Guy : Map
                    {
                        public Guy() { SetAllGuyPaths(); }
                        public void SetAllGuyPaths()
                        {
                            StaticUp = @"person2.png";
                            StaticRight = @"person3.png";
                            StaticLeft = @"person4.png";
                            StaticDown = @"person1.png";
                            GoUp1 = "WalkU1.png";
                            GoUp2 = "WalkU2.png";
                            GoLeft = "WalkL1.png";
                            GoRight = "WalkR1.png";
                            GoDown1 = "WalkD1.png";
                            GoDown2 = "WalkD2.png";
                        }
                        public String StaticUp { get; set; }
                        public String StaticRight { get; set; }
                        public String StaticLeft { get; set; }
                        public String StaticDown { get; set; }
                        public String GoUp1 { get; set; }
                        public String GoUp2 { get; set; }
                        public String GoLeft { get; set; }
                        public String GoRight { get; set; }
                        public String GoDown1 { get; set; }
                        public String GoDown2 { get; set; }
                    }
                    public Models() { SetAllModPaths(); }
                    public void SetAllModPaths()
                    {
                        LeverOff = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Locations\Objects\LeverOff.png";
                        LeverOn = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Locations\Objects\LeverOn.png";
                        ChestClosed1 = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\ChestClosed(ver1).png";
                        ChestClosed2 = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\ChestVersions\ChestClosed(ver2).png";
                        ChestClosed3 = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Locations\Objects\ChestClosed(ver3).png";
                        ChestOpened1 = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\ChestOpened(ver1).png";
                        ChestOpened2 = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\ChestVersions\ChestOpened(ver2).png";
                        ChestOpened3 = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Locations\Objects\ChestOpened(ver3).png";
                        Artifact1 = @"AncientArtifact.png";
                        Artifact2 = @"AncientArtifact2.png";
                        Artifact3 = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Locations\Objects\AncientArtifact3.png";
                        SeriousPants = @"GetItemsCustomPants4.png";
                        BandageBoots = @"GetItemsCustomBoots1.png";
                        StrongBoots = @"GetItemsCustomBoots2.png";
                    }
                    public String LeverOff { get; set; }
                    public String LeverOn { get; set; }
                    public String ChestClosed1 { get; set; }
                    public String ChestClosed2 { get; set; }
                    public String ChestClosed3 { get; set; }
                    public String ChestOpened1 { get; set; }
                    public String ChestOpened2 { get; set; }
                    public String ChestOpened3 { get; set; }
                    public String Artifact1 { get; set; }
                    public String Artifact2 { get; set; }
                    public String Artifact3 { get; set; }
                    public String SeriousPants { get; set; }
                    public String BandageBoots { get; set; }
                    public String StrongBoots { get; set; }
                }
                public class Messages : Map
                {
                    public Messages() { SetAllMsgPaths(); }
                    public void SetAllMsgPaths()
                    {
                        Knucleduster = @"GetItemsCustomWeapon1.png";
                        AncientKnife = @"GetItemsCustomWeapon2.png";
                        LegendSword = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Messages\GetItemsCustomWeapon3.png";
                        SeriousMinigun = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Messages\GetItemsCustomWeapon4.png";
                        LeatherArmor = @"GetItemsArmor1.png";
                        AncientArmor = @"GetItemsArmor2.png";
                        LegendArmor = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Messages\GetItemsArmor3.png";
                        FeatherWears = @"GetItemsCustomPants1.png";
                        AncientPants = @"GetItemsCustomPants2.png";
                        LegendPants = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Messages\GetItemsCustomPants3.png";
                        SeriousPants = @"GetItemsCustomPants4.png";
                        BandageBoots = @"GetItemsCustomBoots1.png";
                        StrongBoots = @"GetItemsCustomBoots2.png";
                        LegendBoots = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Messages\GetItemsCustomBoots3.png";
                        Tb1_Msg1 = @"TableMessage1.png";
                        Tb1_Msg2 = @"TableMessage4.png";
                        Tb1_Msg3 = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Messages\TableMessage7.png";
                        Tb2_Msg1 = @"TableMessage2.png";
                        Tb2_Msg2 = @"TableMessage5.png";
                        Tb2_Msg3 = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Messages\TableMessage8.png";
                        Tb3_Msg1 = @"TableMessage3.png";
                        Tb3_Msg2 = @"TableMessage6.png";
                        Tb3_Msg3 = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Messages\TableMessage9.png";
                        Completed ="/TaskCompleted.png";
                    }
                    public String Knucleduster { get; set; }
                    public String AncientKnife { get; set; }
                    public String LegendSword { get; set; }
                    public String SeriousMinigun { get; set; }
                    public String LeatherArmor { get; set; }
                    public String AncientArmor { get; set; }
                    public String LegendArmor { get; set; }
                    public String FeatherWears { get; set; }
                    public String AncientPants { get; set; }
                    public String SeriousPants { get; set; }
                    public String LegendPants { get; set; }
                    public String BandageBoots { get; set; }
                    public String StrongBoots { get; set; }
                    public String LegendBoots { get; set; }
                    public String Tb1_Msg1 { get; set; }
                    public String Tb1_Msg2 { get; set; }
                    public String Tb1_Msg3 { get; set; }
                    public String Tb2_Msg1 { get; set; }
                    public String Tb2_Msg2 { get; set; }
                    public String Tb2_Msg3 { get; set; }
                    public String Tb3_Msg1 { get; set; }
                    public String Tb3_Msg2 { get; set; }
                    public String Tb3_Msg3 { get; set; }
                    public String Completed { get; set; }
                }
                public String Main { get; set; }
                public String Location1 { get; set; }
                public String Location2 { get; set; }
                public String Location3 { get; set; }
                public String Normal { get; set; }
                public String Register { get; set; }
                public String UnRegister { get; set; }
            }
            public class Battle : Static
            {
                public Battle() { SetAllBPaths(); }
                public void SetAllBPaths()
                {
                    Battle1 = @"Battle3.jpg";
                    Battle2 = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\BattleImages\b2.jpg";
                }
                public String Battle1 { get; set; }
                public String Battle2 { get; set; }
            }
            public class Menu : Static
            {
                public Menu() { SetAllBPaths(); }
                public void SetAllBPaths()
                {
                    UsualTask = @"ActiveTask.png";
                    Completed = @"CompletedTask.png";
                }
                public String UsualTask { get; set; }
                public String ExperTask { get; set; }
                public String Completed { get; set; }
            }

            public class BtnImgs : Static
            {
                public class Usual : BtnImgs
                {
                    public Usual() { SetAllPaths(); }
                    public void SetAllPaths()
                    {
                        ArrowNext = @"ToNext.png";
                        ArrowPrev = @"ToPrev.png";
                        Knucleduster= @"KnucledusterItem.png";
                        AncientKnife = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EquipBtnImg\AncientKnife.png";
                        LegendSword = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EquipBtnImg\LegendSword.png";
                        SeriousMinigun = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EquipBtnImg\SeriousMinigun.png";
                        LeatherArmor = @"BlackSkinItems.png";
                        AncientArmor = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EquipBtnImg\AncientArmorButton.png";
                        LegendArmor = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EquipBtnImg\LegendArmor.png";
                        SeriousTshirt = @"CoolT-shirt.png";
                        FeatherWears = @"EagleWearsItems.png";
                        AncientPants = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EquipBtnImg\WarPants.png";
                        LegendPants = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EquipBtnImg\LegendPants.png";
                        SeriousPants = @"SeriousPants.png";
                        BandageBoots = @"BandageBootsItems.png";
                        StrongBoots = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EquipBtnImg\ManBoots.png";
                        LegendBoots = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EquipBtnImg\LegendBoots.png";
                        SeriousBoots = @"SeriousBoots.png";
                    }
                    public String ArrowNext { get; set; }
                    public String ArrowPrev { get; set; }
                    public String Knucleduster { get; set; }
                    public String AncientKnife { get; set; }
                    public String LegendSword { get; set; }
                    public String SeriousMinigun { get; set; }
                    public String LeatherArmor { get; set; }
                    public String AncientArmor { get; set; }
                    public String LegendArmor { get; set; }
                    public String SeriousTshirt { get; set; }
                    public String FeatherWears { get; set; }
                    public String AncientPants { get; set; }
                    public String LegendPants { get; set; }
                    public String SeriousPants { get; set; }
                    public String BandageBoots { get; set; }
                    public String StrongBoots { get; set; }
                    public String LegendBoots { get; set; }
                    public String SeriousBoots { get; set; }
                }
                public class Before : BtnImgs
                {
                    public Before() { SetAllPaths(); }
                    public void SetAllPaths()
                    {
                        Fight = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\FightBeforeImg.png";
                        Defence = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\DefenceBeforeImg.png";
                        Escape = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\EscapeBeforeImg.png";
                        Bag = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\ItemsBeforeImg.png";
                        Skills = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\SkillsBeforeImg.png";
                        Select = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\TrgtSelectBeforeImg.png";
                    }
                    public String Fight { get; set; }
                    public String Defence { get; set; }
                    public String Escape { get; set; }
                    public String Bag { get; set; }
                    public String Skills { get; set; }
                    public String Select { get; set; }
                }
                public class After : BtnImgs
                {
                    public After() { SetAllPaths(); }
                    public void SetAllPaths()
                    {
                        Fight = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\FightAfterImg.png";
                        Defence = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\DefenceAfterImg.png";
                        Escape = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\EscapeAfterImg.png";
                        Bag = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\ItemsAfterImg.png";
                        Skills = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\SkillsAfterImg.png";
                        Select = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\TrgtSelectAfterImg.png";
                    }
                    public String Fight { get; set; }
                    public String Defence { get; set; }
                    public String Escape { get; set; }
                    public String Bag { get; set; }
                    public String Skills { get; set; }
                    public String Select { get; set; }
                }
            }
            public class Foes : Static
            {
                public Foes() { SetAllEnemyPaths(); }

                private void SetAllEnemyPaths()
                {
                    Spider = "Spider.png";
                    Mummy = "Foe1.Mummy.png";
                    Zombie = "Foe1.Zombie.png";
                    Bones = "Foe1.Bones.png";
                    Vulture = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Vulture.png";
                    Ghoul = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Ghoul.png";
                    GrimReaper = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\GrimReaper.png";
                    Scarab = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Scarab.png";
                    KillerMole = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\KillerMole.png";
                    Imp = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Imp.png";
                    Worm = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Worm.png";
                    Master = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Master.png";

                    SpiderIcon = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EnemyImgs\Spider1.png";
                    MummyIcon = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EnemyImgs\Mummy1.png";
                    ZombieIcon = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EnemyImgs\Zombie1.png";
                    BonesIcon = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EnemyImgs\Bones1.png";
                    VultureIcon = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EnemyImgs\Vulture1.png";
                    GhoulIcon = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EnemyImgs\Ghoul1.png";
                    GrimReaperIcon = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EnemyImgs\GrimReaper1.png";
                    ScarabIcon = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EnemyImgs\Scarab.png";
                    KillerMoleIcon = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\KillerMole.png";
                    ImpIcon = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Imp.png";
                    WormIcon = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Worm.png";
                    MasterIcon = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Master.png";
                }
                public String Spider { get; set; }
                public String Mummy { get; set; }
                public String Zombie { get; set; }
                public String Bones { get; set; }
                public String Vulture { get; set; }
                public String Ghoul { get; set; }
                public String GrimReaper { get; set; }
                public String Scarab { get; set; }
                public String KillerMole { get; set; }
                public String Imp { get; set; }
                public String Worm { get; set; }
                public String Master { get; set; }
                public String SpiderIcon { get; set; }
                public String MummyIcon { get; set; }
                public String ZombieIcon { get; set; }
                public String BonesIcon { get; set; }
                public String VultureIcon { get; set; }
                public String GhoulIcon { get; set; }
                public String GrimReaperIcon { get; set; }
                public String ScarabIcon { get; set; }
                public String KillerMoleIcon { get; set; }
                public String ImpIcon { get; set; }
                public String WormIcon { get; set; }
                public String MasterIcon { get; set; }
            }
            public class Bosses : Static
            {
                public Bosses()
                {
                    SetAllEnemyPaths();
                }

                private void SetAllEnemyPaths()
                {
                    Pharaoh = "Foe1.Mummy.png";
                    UghZan = "Spider.png";
                    Warrior = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Bosses\Warrior.png";

                    PharaohIcon = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EnemyImgs\Pharaoh.png";
                    UghZanIcon = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EnemyImgs\UghZan1.png";
                    WarriorIcon = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EnemyImgs\Warrior1.png";
                }
                public String Pharaoh { get; set; }
                public String UghZan { get; set; }
                public String Warrior { get; set; }
                public String PharaohIcon { get; set; }
                public String UghZanIcon { get; set; }
                public String WarriorIcon { get; set; }
            }
            public class Person : Static
            {
                public Person() { SetAllPaths(); }
                private void SetAllPaths()
                {
                    Usual = "/pers5.png";
                    Serious = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSam.png";
                    Defensive = @"Defence.png";
                }
                public String Usual { get; set; }
                public String Serious { get; set; }
                public String Defensive { get; set; }
            }
            public class Icon : Static
            {
                public Icon() { SetAllPaths(); }
                private void SetAllPaths()
                {
                    Usual = "/person6.png";
                    Poison = "IconPoisoned.png";
                    Serious = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSam.png";
                    Defensive = @"IconDefence1.png";
                }
                public String Usual { get; set; }
                public String Poison { get; set; }
                public String Serious { get; set; }
                public String Defensive { get; set; }
            }
        }
        public class Dynamic : Paths
        {
            public class Foes : Dynamic
            {
                public Foes() { SetAllPaths(); }
                private void SetAllPaths()
                {
                    Spider = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks1.png" };
                    Mummy = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\MummyAttacks\\MummyAttacks1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\MummyAttacks\\MummyAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\MummyAttacks\\MummyAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\MummyAttacks\\MummyAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\MummyAttacks\\MummyAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\MummyAttacks\\MummyAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\MummyAttacks\\MummyAttacks1.png" };
                    Zombie = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ZombieAttacks\\ZombieAttacks1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ZombieAttacks\\ZombieAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ZombieAttacks\\ZombieAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ZombieAttacks\\ZombieAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ZombieAttacks\\ZombieAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ZombieAttacks\\ZombieAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ZombieAttacks\\ZombieAttacks1.png" };
                    Bones = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\BonesAttacks\\BonesAttacks1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\BonesAttacks\\BonesAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\BonesAttacks\\BonesAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\BonesAttacks\\BonesAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\BonesAttacks\\BonesAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\BonesAttacks\\BonesAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\BonesAttacks\\BonesAttacks1.png" };
                    Vulture = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\VultureAttacks\VultureAttacks1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\VultureAttacks\VultureAttacks2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\VultureAttacks\VultureAttacks1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\VultureAttacks\VultureAttacks2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\VultureAttacks\VultureAttacks1.png" };
                    Ghoul = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\GhoulAttacks\GhoulAttacks1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\GhoulAttacks\GhoulAttacks2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\GhoulAttacks\GhoulAttacks1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\GhoulAttacks\GhoulAttacks2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\GhoulAttacks\GhoulAttacks1.png" };
                    GrimReaper = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\GrimReaperAttacks\GrimReaperAttacks1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\GrimReaperAttacks\GrimReaperAttacks2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\GrimReaperAttacks\GrimReaperAttacks1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\GrimReaperAttacks\GrimReaperAttacks2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\GrimReaperAttacks\GrimReaperAttacks1.png" };
                    Scarab = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\ScarabAttacks\ScarabAttacks1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\ScarabAttacks\ScarabAttacks2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\ScarabAttacks\ScarabAttacks1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\ScarabAttacks\ScarabAttacks2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\ScarabAttacks\ScarabAttacks1.png" };
                    KillerMole = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\KillerMoleAttacks\KillerMole1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\KillerMoleAttacks\KillerMole2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\KillerMoleAttacks\KillerMole1.png" };
                    Imp = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\ImpAttacks\Imp1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\ImpAttacks\Imp2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\ImpAttacks\Imp1.png" };
                    Worm = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\WormAttacks\Worm1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\WormAttacks\Worm2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\WormAttacks\Worm1.png" };
                    Master = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\MasterAttacks\Master1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\MasterAttacks\Master2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Enemies\Dynamic\MasterAttacks\Master1.png" };
                }
                public String[] Spider { get; set; }
                public String[] Mummy { get; set; }
                public String[] Zombie { get; set; }
                public String[] Bones { get; set; }
                public String[] Vulture { get; set; }
                public String[] Ghoul { get; set; }
                public String[] GrimReaper { get; set; }
                public String[] Scarab { get; set; }
                public String[] KillerMole { get; set; }
                public String[] Imp { get; set; }
                public String[] Worm { get; set; }
                public String[] Master { get; set; }

            }
            public class Bosses : Dynamic
            {
                public Bosses()
                {
                    SetAllBossesPaths();
                }

                private void SetAllBossesPaths()
                {
                    Pharaoh = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PharaohAttacks\\PharaohAttacks.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PharaohAttacks\\PharaohAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PharaohAttacks\\PharaohAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PharaohAttacks\\PharaohAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PharaohAttacks\\PharaohAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PharaohAttacks\\PharaohAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PharaohAttacks\\PharaohAttacks.png" };
                    UghZan = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks8.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks9.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks10.png" };
                    Warrior = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Bosses\Dynamic\WarriorAttacks\WarriorAttacks1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Bosses\Dynamic\WarriorAttacks\WarriorAttacks2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Bosses\Dynamic\WarriorAttacks\WarriorAttacks3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Bosses\Dynamic\WarriorAttacks\WarriorAttacks2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Bosses\Dynamic\WarriorAttacks\WarriorAttacks1.png", };
                }
                public String[] Pharaoh { get; set; }
                public String[] UghZan { get; set; }
                public String[] Warrior { get; set; }
            }
            public class Person : Dynamic
            {
                public Person()
                {
                    SetAllPersonPaths();
                }

                public void SetAllPersonPaths()
                {
                    Cure = new string[] {"D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure10.png"};
                    Cure2 = new string[] {@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Cure2\Cure2_1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Cure2\Cure2_2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Cure2\Cure2_3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Cure2\Cure2_4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Cure2\Cure2_5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Cure2\Cure2_6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Cure2\Cure2_7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Cure2\Cure2_8.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Cure2\Cure2_9.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Cure2\Cure2_10.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Cure2\Cure2_11.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Cure2\Cure2_12.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Cure2\Cure2_13.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Cure2\Cure2_14.png"};
                    Heal = new string[] {"D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal10.png"};
                    BuffUp = new string[] {@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\BuffUp\BuffUp1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\BuffUp\BuffUp2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\BuffUp\BuffUp3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\BuffUp\BuffUp4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\BuffUp\BuffUp5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\BuffUp\BuffUp6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\BuffUp\BuffUp7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\BuffUp\BuffUp8.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\BuffUp\BuffUp9.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\BuffUp\BuffUp10.png"};
                    ToughenUp = new string[] {@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ToughenUp\ToughenUp1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ToughenUp\ToughenUp2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ToughenUp\ToughenUp3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ToughenUp\ToughenUp4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ToughenUp\ToughenUp5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ToughenUp\ToughenUp6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ToughenUp\ToughenUp7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ToughenUp\ToughenUp8.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ToughenUp\ToughenUp9.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ToughenUp\ToughenUp10.png"};
                    Regen = new string[] {@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Regen\Regen1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Regen\Regen2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Regen\Regen3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Regen\Regen4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Regen\Regen5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Regen\Regen6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Regen\Regen7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Regen\Regen8.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Regen\Regen9.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Regen\Regen10.png"};
                    Control = new string[] {@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Control\Control1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Control\Control2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Control\Control3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Control\Control4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Control\Control5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Control\Control6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Control\Control7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Control\Control8.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Control\Control9.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Control\Control10.png"};
                    Torch = new string[] {"D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch10.png"};
                    Whip = new string[] {"D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip10.png"};
                    Thrower = new string[] {@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Thrower\Thrower1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Thrower\Thrower2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Thrower\Thrower3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Thrower\Thrower4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Thrower\Thrower5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Thrower\Thrower6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Thrower\Thrower7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Thrower\Thrower8.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Thrower\Thrower2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Thrower\Thrower1.png"};
                    Super = new string[] {"D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super5.png"};
                    Tornado = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super5.png" };
                    Quake = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Quake\Quake8.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Quake\Quake1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Quake\Quake2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Quake\Quake3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Quake\Quake4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Quake\Quake5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Quake\Quake6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Quake\Quake7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\Quake\Quake8.png" };
                    BagUse = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed1.png" };
                    Escape = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape2.png" };
                    HdAttack = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack10.png" };
                    KnAttack = new string[] { @"D:\Александр\Windows 7\Учёба, ПТК НовГУ\3 курс\Курсовая\GIF\KnifeAttack\KnifeAttck1.png", @"D:\Александр\Windows 7\Учёба, ПТК НовГУ\3 курс\Курсовая\GIF\KnifeAttack\KnifeAttck2.png", @"D:\Александр\Windows 7\Учёба, ПТК НовГУ\3 курс\Курсовая\GIF\KnifeAttack\KnifeAttck3.png", @"D:\Александр\Windows 7\Учёба, ПТК НовГУ\3 курс\Курсовая\GIF\KnifeAttack\KnifeAttck4.png", @"D:\Александр\Windows 7\Учёба, ПТК НовГУ\3 курс\Курсовая\GIF\KnifeAttack\KnifeAttck5.png", @"D:\Александр\Windows 7\Учёба, ПТК НовГУ\3 курс\Курсовая\GIF\KnifeAttack\KnifeAttck6.png", @"D:\Александр\Windows 7\Учёба, ПТК НовГУ\3 курс\Курсовая\GIF\KnifeAttack\KnifeAttck7.png", @"D:\Александр\Windows 7\Учёба, ПТК НовГУ\3 курс\Курсовая\GIF\KnifeAttack\KnifeAttck8.png", @"D:\Александр\Windows 7\Учёба, ПТК НовГУ\3 курс\Курсовая\GIF\KnifeAttack\KnifeAttck9.png", @"D:\Александр\Windows 7\Учёба, ПТК НовГУ\3 курс\Курсовая\GIF\KnifeAttack\KnifeAttck10.png" };
                    SwAttack = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Person\SwordAttack\Sword1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Person\SwordAttack\Sword2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Person\SwordAttack\Sword3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Person\SwordAttack\Sword4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Person\SwordAttack\Sword5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Person\SwordAttack\Sword6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Person\SwordAttack\Sword7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Person\SwordAttack\Sword8.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Person\SwordAttack\Sword9.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Person\SwordAttack\Sword10.png" };
                    MgAttack = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Person\MinigunAttack\MinigunAttack1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Person\MinigunAttack\MinigunAttack2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Person\MinigunAttack\MinigunAttack3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Person\MinigunAttack\MinigunAttack4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Person\MinigunAttack\MinigunAttack5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Person\MinigunAttack\MinigunAttack6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Person\MinigunAttack\MinigunAttack7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Person\MinigunAttack\MinigunAttack8.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Person\MinigunAttack\MinigunAttack9.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Person\MinigunAttack\MinigunAttack10.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Person\MinigunAttack\MinigunAttack11.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Person\MinigunAttack\MinigunAttack12.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Person\MinigunAttack\MinigunAttack13.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Person\MinigunAttack\MinigunAttack14.png" };
                    SeriousMg = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun8.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun9.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun10.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun11.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun12.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun13.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun14.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun15.png" };
                    SSwitch = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSwitch\SeriousSwitch1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSwitch\SeriousSwitch2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSwitch\SeriousSwitch3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSwitch\SeriousSwitch3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSwitch\SeriousSwitch4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSwitch\SeriousSwitch5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSwitch\SeriousSwitch6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSwitch\SeriousSwitch7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSwitch\SeriousSwitch8.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSwitch\SeriousSwitch9.png" };
                    Hurt = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PersonHurts\\PersonHurts1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PersonHurts\\PersonHurts2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PersonHurts\\PersonHurts3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PersonHurts\\PersonHurts4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PersonHurts\\PersonHurts5.png" };
                    //GetByIndexes = BmpArrayNotStatedX(Cure, Cure2, Heal, BuffUp, ToughenUp, Regen, Control, Torch, Whip, Thrower, Super, Tornado, Quake);
                }
                public string[] Cure { get; set; }
                public string[] Cure2 { get; set; }
                public string[] Heal { get; set; }
                public string[] BuffUp { get; set; }
                public string[] ToughenUp { get; set; }
                public string[] Regen { get; set; }
                public string[] Control { get; set; }
                public string[] Torch { get; set; }
                public string[] Whip { get; set; }
                public string[] Thrower { get; set; }
                public string[] Super { get; set; }
                public string[] Tornado { get; set; }
                public string[] Quake { get; set; }
                public string[] BagUse { get; set; }
                public string[] Escape { get; set; }
                public string[] HdAttack { get; set; }
                public string[] KnAttack { get; set; }
                public string[] SwAttack { get; set; }
                public string[] MgAttack { get; set; }
                public string[] SeriousMg { get; set; }
                public string[] SSwitch { get; set; }
                public string[] Hurt { get; set; }
                public string[][] GetByIndexes { get; set; }
                
            }

            public class Icon : Dynamic
            {
                public Icon()
                {
                    SetAllIconPaths();
                }

                public void SetAllIconPaths()
                {
                    Cure = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure10.png" };
                    Cure2 = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\CureIcon2\IconCure2_1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\CureIcon2\IconCure2_2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\CureIcon2\IconCure2_1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\CureIcon2\IconCure2_2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\CureIcon2\IconCure2_3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\CureIcon2\IconCure2_3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\CureIcon2\IconCure2_3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\CureIcon2\IconCure2_4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\CureIcon2\IconCure2_5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\CureIcon2\IconCure2_6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\CureIcon2\IconCure2_7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\CureIcon2\IconCure2_8.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\CureIcon2\IconCure2_9.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\CureIcon2\IconCure2_9.png" };
                    Heal = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon10.png" };
                    BuffUp = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\BuffUpIcon\BuffUpIcon1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\BuffUpIcon\BuffUpIcon2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\BuffUpIcon\BuffUpIcon3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\BuffUpIcon\BuffUpIcon4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\BuffUpIcon\BuffUpIcon5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\BuffUpIcon\BuffUpIcon6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\BuffUpIcon\BuffUpIcon7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\BuffUpIcon\BuffUpIcon8.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\BuffUpIcon\BuffUpIcon9.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\BuffUpIcon\BuffUpIcon10.png" };
                    ToughenUp = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ToughenUpIcon\ToughenUpIcon1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ToughenUpIcon\ToughenUpIcon2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ToughenUpIcon\ToughenUpIcon3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ToughenUpIcon\ToughenUpIcon4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ToughenUpIcon\ToughenUpIcon5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ToughenUpIcon\ToughenUpIcon6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ToughenUpIcon\ToughenUpIcon7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ToughenUpIcon\ToughenUpIcon8.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ToughenUpIcon\ToughenUpIcon9.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ToughenUpIcon\ToughenUpIcon10.png" };
                    Regen = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\RegenIcon\RegenIcon1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\RegenIcon\RegenIcon2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\RegenIcon\RegenIcon3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\RegenIcon\RegenIcon4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\RegenIcon\RegenIcon5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\RegenIcon\RegenIcon6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\RegenIcon\RegenIcon7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\RegenIcon\RegenIcon8.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\RegenIcon\RegenIcon9.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\RegenIcon\RegenIcon10.png" };
                    Control = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ControlIcon\ControlIcon1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ControlIcon\ControlIcon2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ControlIcon\ControlIcon3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ControlIcon\ControlIcon4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ControlIcon\ControlIcon5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ControlIcon\ControlIcon6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ControlIcon\ControlIcon7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ControlIcon\ControlIcon8.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ControlIcon\ControlIcon9.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ControlIcon\ControlIcon10.png" };
                    Torch = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch10.png" };
                    Whip = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon10.png" };
                    Thrower = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ThrowerIcon\ThrowerIcon1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ThrowerIcon\ThrowerIcon2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ThrowerIcon\ThrowerIcon3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ThrowerIcon\ThrowerIcon4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ThrowerIcon\ThrowerIcon5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ThrowerIcon\ThrowerIcon6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ThrowerIcon\ThrowerIcon7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ThrowerIcon\ThrowerIcon8.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ThrowerIcon\ThrowerIcon9.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\ThrowerIcon\ThrowerIcon10.png" };
                    Super = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon4.png" };
                    Tornado = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\TornadoIcon\TornadoIcon1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\TornadoIcon\TornadoIcon2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\TornadoIcon\TornadoIcon3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\TornadoIcon\TornadoIcon4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\TornadoIcon\TornadoIcon5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\TornadoIcon\TornadoIcon6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\TornadoIcon\TornadoIcon7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\TornadoIcon\TornadoIcon8.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\TornadoIcon\TornadoIcon9.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\TornadoIcon\TornadoIcon10.png" };
                    Quake = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\QuakeIcon\QuakeIcon1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\QuakeIcon\QuakeIcon2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\QuakeIcon\QuakeIcon3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\QuakeIcon\QuakeIcon4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\QuakeIcon\QuakeIcon5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\QuakeIcon\QuakeIcon6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\QuakeIcon\QuakeIcon7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\QuakeIcon\QuakeIcon8.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesShow\QuakeIcon\QuakeIcon9.png" };
                    BagUse = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed10.png" };
                    Escape = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape2.png" };
                    HdAttack = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage10.png" };
                    KnAttack = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconKnAtk\IconKnAtk1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconKnAtk\IconKnAtk2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconKnAtk\IconKnAtk3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconKnAtk\IconKnAtk4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconKnAtk\IconKnAtk5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconKnAtk\IconKnAtk6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconKnAtk\IconKnAtk7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconKnAtk\IconKnAtk8.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconKnAtk\IconKnAtk9.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconKnAtk\IconKnAtk10.png" };
                    SwAttack = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Icon\SwordIcon\Sword1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Icon\SwordIcon\Sword2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Icon\SwordIcon\Sword1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Icon\SwordIcon\Sword2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Icon\SwordIcon\Sword3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Icon\SwordIcon\Sword4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Icon\SwordIcon\Sword5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Icon\SwordIcon\Sword6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Icon\SwordIcon\Sword7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Icon\SwordIcon\Sword8.png" };
                    MgAttack = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Icon\MinigunIcon\MinigunIcon1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Icon\MinigunIcon\MinigunIcon1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Icon\MinigunIcon\MinigunIcon1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Icon\MinigunIcon\MinigunIcon2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Icon\MinigunIcon\MinigunIcon1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Icon\MinigunIcon\MinigunIcon2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Icon\MinigunIcon\MinigunIcon1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Icon\MinigunIcon\MinigunIcon2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Icon\MinigunIcon\MinigunIcon1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Icon\MinigunIcon\MinigunIcon2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Icon\MinigunIcon\MinigunIcon1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Icon\MinigunIcon\MinigunIcon2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Icon\MinigunIcon\MinigunIcon1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Icon\MinigunIcon\MinigunIcon2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Animation\Icon\MinigunIcon\MinigunIcon1.png" };
                    SeriousMg = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun1.png" };
                    SSwitch = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconShocked\IconShocked1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconShocked\IconShocked2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconShocked\IconShocked3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconShocked\IconShocked4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconShocked\IconShocked5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconShocked\IconShocked6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconShocked\IconShocked7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconShocked\IconShocked8.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconShocked\IconShocked9.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconShocked\IconShocked10.png" };
                    LevelUp = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon9.png" };
                }
                public string[] Cure { get; set; }
                public string[] Cure2 { get; set; }
                public string[] Heal { get; set; }
                public string[] BuffUp { get; set; }
                public string[] ToughenUp { get; set; }
                public string[] Regen { get; set; }
                public string[] Control { get; set; }
                public string[] Torch { get; set; }
                public string[] Whip { get; set; }
                public string[] Thrower { get; set; }
                public string[] Super { get; set; }
                public string[] Tornado { get; set; }
                public string[] Quake { get; set; }
                public string[] BagUse { get; set; }
                public string[] Escape { get; set; }
                public string[] HdAttack { get; set; }
                public string[] KnAttack { get; set; }
                public string[] SwAttack { get; set; }
                public string[] MgAttack { get; set; }
                public string[] SeriousMg { get; set; }
                public string[] SSwitch { get; set; }
                public string[] LevelUp { get; set; }
                public string[][] GetByIndexes { get; set; }
            }
            public class Misc : Dynamic
            {
                public Misc()
                {
                    SetAllMiscPaths();
                }
                public void SetAllMiscPaths()
                {
                    Target = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Target\\Target1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Target\\Target2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Target\\Target3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Target\\Target2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Target\\Target1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Target\\Target2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Target\\Target3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Target\\Target2.png" };
                }
                public string[] Target { get; set; }
            }
            public class Models : Dynamic
            {
                public Models()
                {
                    SetAllPaths();
                }
                public void SetAllPaths()
                {
                    Ancient = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\LocationModels\AncientModel1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\LocationModels\AncientModel2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\LocationModels\AncientModel3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\LocationModels\AncientModel4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\LocationModels\AncientModel5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\LocationModels\AncientModel6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\LocationModels\AncientModel5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\LocationModels\AncientModel6.png" };
                    Warrior = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\LocationModels\WarriorModel_1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\LocationModels\WarriorModel2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\LocationModels\WarriorModel3.png", };

                }
                public string[] Ancient { get; set; }
                public string[] Warrior { get; set; }
            }
        }
        public Static.Person PersonStatePath { get; set; }
        public Static.Icon IconStatePath { get; set; }
        public Static.Foes FoesStatePath { get; set; }
        public Static.Bosses BossesStatePath { get; set; }
        public Static.Map Backgrounds { get; set; }
        public Static.Map.Models MapModels { get; set; }
        public Static.Map.Models.Guy Ray { get; set; }
        public Static.Map.Messages Msg { get; set; }
        public Static.BtnImgs.Usual BtnCustomize { get; set; }
        public Static.BtnImgs.Before BtnBefore { get; set; }
        public Static.BtnImgs.After BtnAfter { get; set; }
        public Static.Menu MenuImgs { get; set; }
        public Static.Battle Fighting { get; set; }
        public Dynamic.Foes FoesAnimatePath { get; set; }
        public Dynamic.Bosses BossesAnimatePath { get; set; }
        public Dynamic.Person PersonAnimatePath { get; set; }
        public Dynamic.Icon IconAnimatePath { get; set; }
        public Dynamic.Misc MiscAnimatePath { get; set; }
        public Dynamic.Models AniModel { get; set; }
        public OST.Music GameMusic { get; set; }
        public OST.Sounds GameSounds { get; set; }
        public OST.Noises GameNoises { get; set; }
        public CutScenes CutScene { get; set; }
    }
    public class Sql {
        public Sql()
        {
            Con = NewConnection();
            PlayerLogins = new List<string>();
        }
        public SqlConnection NewConnection() { return new SqlConnection("Data Source=SASHA;Initial Catalog=DesertRageGame;Integrated Security=True"); }
        private void NewStoredProcedureBuild(in String ProcedureName)
        {
            Cmd = new SqlCommand(ProcedureName, Con);
            Cmd.CommandType = CommandType.StoredProcedure;
        }
        private void NewExecuteNonQueryBuild()
        {
            Cmd.Connection.Open();
            Cmd.ExecuteNonQuery();
            Cmd.Connection.Close();
        }
        private List<string> NewSqlDataReaderBuild(List<string> Lgs)
        {
            Cmd.Connection.Open();
            DataReader = Cmd.ExecuteReader();
            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    Lgs.Add(DataReader.GetValue(0).ToString());
                }
            }
            Cmd.Connection.Close();
            return Lgs;
        }
        private string NewSqlDataReaderBuild(string Selected, in Byte Column)
        {
            Cmd.Connection.Open();
            DataReader = Cmd.ExecuteReader();
            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    Selected = DataReader.GetValue(Column).ToString();
                }
            }
            Cmd.Connection.Close();
            return Selected;
        }
        private Object[] NewSqlDataReaderBuild(Object[] Values, in Byte StartValue, in Byte EndValue)
        {
            Cmd.Connection.Open();
            DataReader = Cmd.ExecuteReader();
            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    for (Byte i = StartValue; i < EndValue; i++)
                    {
                        Values[i- StartValue] =DataReader.GetValue(i);
                    }
                }
            }
            Cmd.Connection.Close();
            return Values;
        }
        private Byte[] NewSqlDataReaderBuild(Byte[] Values, in Byte StartValue, in Byte EndValue)
        {
            Cmd.Connection.Open();
            DataReader = Cmd.ExecuteReader();
            if (DataReader.HasRows)
                while (DataReader.Read())
                    for (Byte i = StartValue; i < EndValue; i++)
                        Values[i- StartValue] = Convert.ToByte(DataReader.GetValue(i));
            Cmd.Connection.Close();
            return Values;
        }
        private void AddProcedureParameter(in String ParamName, in String NewStringParam) { Cmd.Parameters.Add(ParamName, SqlDbType.VarChar).Value = NewStringParam; }
        private void AddProcedureParameter(in String ParamName, in Boolean NewBooleanParam) { Cmd.Parameters.Add(ParamName, SqlDbType.Bit).Value = NewBooleanParam; }
        private void AddProcedureParameter(in String ParamName, in Byte NewTinyIntParam) { Cmd.Parameters.Add(ParamName, SqlDbType.TinyInt).Value = NewTinyIntParam; }
        private void AddProcedureParameter(in String ParamName, in UInt16 NewSmallIntParam) { Cmd.Parameters.Add(ParamName, SqlDbType.SmallInt).Value = NewSmallIntParam; }
        private void AddProcedureParametersX(in String[] ParamNames, in Object[] NewAnyParams)
        {
            for (Byte i = 0; i < ParamNames.Length; i++)
            {
                if (NewAnyParams[i].GetType().ToString() == "System.String") { AddProcedureParameter(ParamNames[i], (String)NewAnyParams[i]); continue; }
                else if (NewAnyParams[i].GetType().ToString() == "System.Boolean") { AddProcedureParameter(ParamNames[i], (Boolean)NewAnyParams[i]); continue; }
                else if (NewAnyParams[i].GetType().ToString() == "System.UInt16") { AddProcedureParameter(ParamNames[i], (UInt16)NewAnyParams[i]); continue; }
                else if (NewAnyParams[i].GetType().ToString() == "System.Byte") { AddProcedureParameter(ParamNames[i], (Byte)NewAnyParams[i]); continue; }
            }
        }
        private void CheckIfPlayersListIsNotNull() { if (PlayerLogins.Count > 0) PlayerLogins.Clear(); }
        public void DeselectCurrentPlayer(in String NewPlayerLogin)
        {
            NewStoredProcedureBuild("DeselectPlayer");
            NewExecuteNonQueryBuild();
            Cmd.Parameters.Clear();
        }
        public void NewPlayer(in String NewPlayerLogin)
        {
            NewStoredProcedureBuild("AddNewProfile");
            AddProcedureParameter("@LOGIN", NewPlayerLogin);
            NewExecuteNonQueryBuild();
            Cmd.Parameters.Clear();
        }
        public void DeletePlayer(in String ExistingPlayerLogin)
        {
            NewStoredProcedureBuild("DeleteProfile");
            AddProcedureParameter("@LOGIN", ExistingPlayerLogin);
            NewExecuteNonQueryBuild();
            Cmd.Parameters.Clear();
        }
        public void CheckAllRecordedPlayers()
        {
            CheckIfPlayersListIsNotNull();
            NewStoredProcedureBuild("CheckLogin");
            PlayerLogins=NewSqlDataReaderBuild(new List<string>());
            Cmd.Parameters.Clear();
        }
        public string GetCurrentPlayer()
        {
            NewStoredProcedureBuild("CheckSelected");
            CurrentLogin = (PlayerLogins.Count > 0 ? (NewSqlDataReaderBuild("????", 0) == "????" ? PlayerLogins[0] : NewSqlDataReaderBuild("????", 0)) : "????");
            Cmd.Parameters.Clear();
            return CurrentLogin;
        }
        public Object[] CheckPlayerBag(in String PlayerLogin, in Object[] Items)
        {
            NewStoredProcedureBuild("CheckBAG");
            AddProcedureParameter("@LOGIN", PlayerLogin);
            return NewSqlDataReaderBuild(Items, 2, 11);
        }
        public Byte[] CheckPlayerEquip(in String PlayerLogin, in Byte[] Equip)
        {
            NewStoredProcedureBuild("CheckEquip");
            AddProcedureParameter("@LOGIN", PlayerLogin);
            return NewSqlDataReaderBuild(Equip, 2, 10);
        }
        public Object[] GetPlayerRecord(in String PlayerLogin, in Object[] RecordValues)
        {
            NewStoredProcedureBuild("CheckPlayer");
            AddProcedureParameter("@LOGIN", PlayerLogin);
            return NewSqlDataReaderBuild(RecordValues, 1, 8);
        }
        public Object[] GetPlayerStats(in String PlayerLogin, in Object[] Params)
        {
            NewStoredProcedureBuild("CheckParams");
            AddProcedureParameter("@LOGIN", PlayerLogin);
            return NewSqlDataReaderBuild(Params, 1, 7);
        }
        public Byte[] GetPlayerSettings(in String PlayerLogin, in Byte[] Settings)
        {
            NewStoredProcedureBuild("CheckSettings");
            AddProcedureParameter("@LOGIN", PlayerLogin);
            return NewSqlDataReaderBuild(Settings, 2, 7);
        }
        public void SavePlayerBag(in String[] Parameters, in Object[] Items)
        {
            NewStoredProcedureBuild("GetNewItemsBag");
            AddProcedureParametersX(Parameters, Items);
            NewExecuteNonQueryBuild();
        }
        public void SavePlayerEquip(in String[] Parameters, in Object[] Equipment)
        {
            NewStoredProcedureBuild("GetNewEquip");
            AddProcedureParametersX(Parameters, Equipment);
            NewExecuteNonQueryBuild();
        }
        public void SavePlayerStats(in String[] Parameters, in Object[] Stats)
        {
            NewStoredProcedureBuild("GetNewParams");
            AddProcedureParametersX(Parameters, Stats);
            NewExecuteNonQueryBuild();
        }
        public void SavePlayerSettings(in String[] Parameters, in Object[] Settings)
        {
            NewStoredProcedureBuild("GetNewSettings");
            AddProcedureParametersX(Parameters, Settings);
            NewExecuteNonQueryBuild();
        }
        public void NewGameStart(in String PlayerLogin)
        {
            NewStoredProcedureBuild("GetNewSettings");
            AddProcedureParameter("@LOGIN", PlayerLogin);
            NewExecuteNonQueryBuild();
        }
        public Boolean CheckIfPlayerCanContinue()
        {
            NewStoredProcedureBuild("CheckPlayer");
            AddProcedureParameter("@LOGIN", CurrentLogin);
            return NewSqlDataReaderBuild("1", 2) != "1";
        }
        public SqlCommand Cmd { get; set; }
        public SqlDataReader DataReader { get; set; }
        public SqlConnection Con { get; set; }
        public List<string> PlayerLogins { get; set; }
        public string CurrentLogin { get; set; }
    }

    /* SqlInternalException
     Exception: Something get wrong, Read this: System.Data.SqlClient.SqlException (0x80131904): A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: Named Pipes Provider, error: 40 - Could not open a connection to SQL Server)
 ---> System.ComponentModel.Win32Exception (2): Не удается найти указанный файл.
   at System.Data.SqlClient.SqlInternalConnectionTds..ctor(DbConnectionPoolIdentity identity, SqlConnectionString connectionOptions, SqlCredential credential, Object providerInfo, String newPassword, SecureString newSecurePassword, Boolean redirectedUserInstance, SqlConnectionString userConnectionOptions, SessionData reconnectSessionData, Boolean applyTransientFaultHandling, String accessToken)
   at System.Data.SqlClient.SqlConnectionFactory.CreateConnection(DbConnectionOptions options, DbConnectionPoolKey poolKey, Object poolGroupProviderInfo, DbConnectionPool pool, DbConnection owningConnection, DbConnectionOptions userOptions)
   at System.Data.ProviderBase.DbConnectionFactory.CreatePooledConnection(DbConnectionPool pool, DbConnection owningObject, DbConnectionOptions options, DbConnectionPoolKey poolKey, DbConnectionOptions userOptions)
   at System.Data.ProviderBase.DbConnectionPool.CreateObject(DbConnection owningObject, DbConnectionOptions userOptions, DbConnectionInternal oldConnection)
   at System.Data.ProviderBase.DbConnectionPool.UserCreateRequest(DbConnection owningObject, DbConnectionOptions userOptions, DbConnectionInternal oldConnection)
   at System.Data.ProviderBase.DbConnectionPool.TryGetConnection(DbConnection owningObject, UInt32 waitForMultipleObjectsTimeout, Boolean allowCreate, Boolean onlyOneCheckConnection, DbConnectionOptions userOptions, DbConnectionInternal& connection)
   at System.Data.ProviderBase.DbConnectionPool.TryGetConnection(DbConnection owningObject, TaskCompletionSource`1 retry, DbConnectionOptions userOptions, DbConnectionInternal& connection)
   at System.Data.ProviderBase.DbConnectionFactory.TryGetConnection(DbConnection owningConnection, TaskCompletionSource`1 retry, DbConnectionOptions userOptions, DbConnectionInternal oldConnection, DbConnectionInternal& connection)
   at System.Data.ProviderBase.DbConnectionInternal.TryOpenConnectionInternal(DbConnection outerConnection, DbConnectionFactory connectionFactory, TaskCompletionSource`1 retry, DbConnectionOptions userOptions)
   at System.Data.ProviderBase.DbConnectionClosed.TryOpenConnection(DbConnection outerConnection, DbConnectionFactory connectionFactory, TaskCompletionSource`1 retry, DbConnectionOptions userOptions)
   at System.Data.SqlClient.SqlConnection.TryOpen(TaskCompletionSource`1 retry)
   at System.Data.SqlClient.SqlConnection.Open()
   at WpfApp1.Sql.NewSqlDataReaderBuild(List`1 Lgs) in D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\MainWindow.xaml.cs:line 306
   at WpfApp1.Sql.CheckAllRecordedPlayers() in D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\MainWindow.xaml.cs:line 419
   at WpfApp1.MainWindow..ctor() in D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\MainWindow.xaml.cs:line 896
ClientConnectionId:00000000-0000-0000-0000-000000000000
Error Number:2,State:0,Class:20
    */

    //[EN] Foe class, influence on new enemies.
    //[RU] Класс противник, определяет новых противников возникающих в бою.
    public class Foe
    {
        public Foe()
        {
            GetStats();
        }

        //[EN] Stats class, presents each enemy stats in new object.
        //[RU] Класс параметров, определяет параметры каждого вида противников.
        public class Stats : Foe
        {
            public void PreStats(in Byte at, in Byte df, in Byte ag, in Byte sp, in UInt16 mhp)
            {
                EnemyAttack = at;
                EnemyDefence = df;
                EnemySpeed = ag;
                EnemyAgility = sp;
                EnemyMHP = mhp;
            }
            public void PreStats(in Byte FoeIndex)
            {
                UInt16[] MaxHp = {    65,   83,  101,  125,  250,  306,  272,  100,  400,  600,  950,  760,  500, 2000,10000,  350 };
                Byte[] Power   = {  25, 32, 41, 50, 45, 80,100, 75,150,125,160,180, 75,170,255, 50 };
                Byte[] Vital   = {   3,  7,  5, 15, 25, 40, 20, 80,100,120, 70,150, 40,120,255, 50 };
                Byte[] Speed   = {  10, 17, 25, 35, 65, 30, 45, 80,100, 90,130,150, 40, 90,255, 50 };
                Byte[] Abils   = {   0,  2,  5,  7, 30, 20, 60, 80, 75,110, 70,150, 35,140,255, 50 };
                Byte[] Exper   = {   5,  8, 12, 15, 35, 75,100, 60,175,140,200,225,100,200,255,150 };
                Byte[] Mater   = {   5, 10, 35, 75, 60,110, 80,255,105,180,150,255,100,200,255,150 };
                Byte[] Drops =   { 0,1,2,3, 6,4,5,7, 6,5,5,7, 3, 7, 7, 5 };
                EnemyAttack = Power[FoeIndex];
                EnemyDefence = Vital[FoeIndex];
                EnemySpeed = Speed[FoeIndex];
                EnemyAgility = Abils[FoeIndex];
                EnemyMHP = MaxHp[FoeIndex];
                Materials = Mater[FoeIndex];
                Experience = Exper[FoeIndex];
                DropRate = Drops[FoeIndex];
            }
            public UInt16 EnemyMHP { get; set; }
            public Byte EnemyAttack { get; set; }
            public Byte EnemyDefence { get; set; }
            public Byte EnemySpeed { get; set; }
            public Byte EnemyAgility { get; set; }
            public Byte Experience { get; set; }
            public Byte Materials { get; set; }
            public Byte DropRate { get; set; }
        }
        /// <summary>
        /// Крайне важная информация для разработчика на будущее:
        /// Т.к. выходит слишком много "Ничьих" среди врагов и они не могут
        /// нанести урон персонажу + игрок не может противостоять физическими атаками врагов 3 локации
        /// Создаем формулу бонуса к атаке: АТК (с учётом экипировки)+АТК(без)* (СКР/100)
        /// Бонус к защите: ЗЩТ+СПЦ*(СКР/200)
        /// </summary>
        public void GetStats() {
            EnemyName = new string[][] { new string[] { "Паук", "Мумия", "Зомби", "Страж", "Фараон", "Угх-зан I" }, new string[] { "Стервятник", "Гуль", "Жнец", "Скарабей", "????" } };
            EnemyAppears = new string[] { "", "", "" };
            EnemyTurn = new Byte[] { 60, 30, 0 };
            EnemyHP = new UInt16[] { 0, 0, 0 };
            EnemiesStillAlive = 0;
        }
        public void SetEnemies()
        {
            Spider = new Stats();
            Mummy = new Stats();
            Zombie = new Stats();
            Bones = new Stats();
            Vulture = new Stats();
            Ghoul = new Stats();
            GrimReaper = new Stats();
            Scarab = new Stats();
            BOSS1 = new Stats();
            BOSS2 = new Stats();
            SecretBOSS1 = new Stats();
        }
        public UInt16[] EnemyHP { get; set; }
        public string[][] EnemyName { get; set; }
        public string[] EnemyAppears { get; set; }
        public Byte[] EnemyTurn { get; set; }
        public Byte EnemiesStillAlive { get; set; }
        public Stats Spider { get; set; }
        public Stats Mummy { get; set; }
        public Stats Zombie { get; set; }
        public Stats Bones { get; set; }
        public Stats Vulture { get; set; }
        public Stats Ghoul { get; set; }
        public Stats GrimReaper { get; set; }
        public Stats  Scarab { get; set; }
        public Stats  BOSS1 { get; set; }
        public Stats  BOSS2 { get; set; }
        public Stats SecretBOSS1 { get; set; }
    }

    //[EN] Class of hero parameters, like Max Health (HP), Attack and other.
    //[RU] Класс параметров героя, таких как Макс. Здоровье (ОЗ), Атака и прочее.
    public class Characteristics
    {
        public Characteristics() {

            //[EN] PLAYER STATS
            //[RU] СТАТУС ИГРОКА

            //[EN] Current player's level and exp to the next level
            //[RU] Текущий уровень игрока и количество опыта необходимое для достижения следующего.
            CurrentLevel = 1;
            NextLevel = new UInt16[] { 15, 24, 38, 61, 98, 112, 150, 177, 200, 250, 420, 770, 1170, 1595, 2045, 2520, 3020, 3620, 4320, 5080, 6020, 7500, 8750, 10000, 0 };

            //[EN] Active stats (HP,AP)
            //[RU] Активные параметры (ОЗ, ОД).
            MaxHP = 100;
            MaxAP = 40;
            CurrentHP = MaxHP;
            CurrentAP = MaxAP;

            //[EN] Passive stats (ATK, DEF, AG, SP)
            //[RU] Пассивные параметры (АТК, ЗЩТ, СКР, СПЦ).
            Attack = 25;
            Defence = 15;
            Speed = 15;
            Special = 25;
            Learned = 0;

            //[EN] PLAYER LEVEL UP STATS
            //[RU] СТАТУС ИГРОКА ПРИ ПОВЫШЕНИИ УРОВНЯ
            MaxHPNxt = new UInt16[] { 100, 110, 121, 132, 145, 159, 174, 192, 221, 250, 282, 312, 350, 391, 436, 485, 532, 582, 633, 686, 741, 800, 862, 930, 999 };
            MaxAPNxt = new UInt16[] { 40, 44, 48, 53, 58, 64, 70, 77, 85, 100, 121, 147, 200, 267, 342, 395, 478, 540, 570, 600, 785, 840, 890, 940, 999 };
            AttackNxt = new Byte[] { 25, 28, 31, 34, 40, 45, 52, 63, 70, 85, 102, 109, 116, 124, 132, 141, 150, 160, 171, 182, 194, 206, 219, 230, 255 };
            DefenseNxt = new Byte[] { 15, 17, 19, 21, 25, 30, 33, 37, 45, 50, 66, 81, 88, 96, 110, 119, 136, 146, 157, 175, 187, 199, 211, 225, 255 };
            SpeedNxt = new Byte[] { 15, 17, 19, 21, 23, 25, 28, 31, 35, 39, 40, 42, 45, 48, 53, 61, 74, 95, 116, 137, 158, 179, 200, 221, 255 };
            SpecialNxt = new Byte[] { 25, 30, 35, 40, 45, 50, 60, 65, 75, 100, 105, 110, 120, 125, 130, 140, 145, 160, 175, 185, 200, 210, 225, 240, 255 };

            //[EN] PLAYER CURRENT EQUIP
            //[RU] ТЕКУЩАЯ ЭКИПИРОВКА
            PlayerEQ = new Byte[] { 0, 0, 0, 0 };

            //[EN] PLAYER STATUS IN AND OUT OF BATTLE
            //[RU] СТАТУС ИГРОКА В И ВНЕ БОЯ
            DefenseState = 1;
            PlayerStatus = 0;
            MenuTask = 0;
            MiniTask = false;
            Experience = 0;
        }
        public void SetStats(in Byte Level)
        {
            MaxHP = MaxHPNxt[Level];
            MaxAP = MaxAPNxt[Level];
            Attack = AttackNxt[Level];
            Defence = DefenseNxt[Level];
            Speed = SpeedNxt[Level];
            Special = SpecialNxt[Level];
        }
        public void SetStats(in Byte Level, in UInt16 MaxHp, in UInt16 MaxAp, in Byte Power, in Byte Defense, in Byte Agility, in Byte Ability)
        {
            CurrentLevel = Level;
            MaxHP = MaxHp;
            MaxAP = MaxAp;
            Attack = Power;
            Defence = Defense;
            Speed = Agility;
            Special = Ability;
        }
        public void SetCurrentHpAp(in UInt16 Hp, in UInt16 Ap)
        {
            CurrentHP = Hp;
            CurrentAP = Ap;
        }
        public Object[] GetPlayerRecord(in string login)
        {
            return new Object[] { login, CurrentLevel, MenuTask, CurrentHP, CurrentAP, Experience, MiniTask, Learned, true };
        }
        public void SetPlayerRecord(params Object[] Values)
        {
            SetAnyValues(new Object[] { CurrentLevel, MenuTask, CurrentHP, CurrentAP, Experience, MiniTask, Learned }, Values);
        }
        public void SetAnyValues(Object[] Properties, params Object[] Values)
        {
            for (Byte i = 0; i < Values.Length; i++)
            {
                if (Properties[i].GetType() == typeof(String)) Properties[i] = (String)Values[i];
                if (Properties[i].GetType() == typeof(Boolean)) Properties[i] = (Boolean)Values[i];
                if (Properties[i].GetType() == typeof(Byte)) Properties[i] = (Byte)Values[i];
                if (Properties[i].GetType() == typeof(UInt16)) Properties[i] = (UInt16)Values[i];
            }
        }
        public void SetAnyValues(Object[] Properties, in Object Value)
        {
            for (Byte i = 0; i < Properties.Length; i++)
            {
                if (Properties[i].GetType() == typeof(String)) Properties[i] = (String)Value;
                if (Properties[i].GetType() == typeof(Boolean)) Properties[i] = (Boolean)Value;
                if (Properties[i].GetType() == typeof(Byte)) Properties[i] = (Byte)Value;
                if (Properties[i].GetType() == typeof(UInt16)) Properties[i] = (UInt16)Value;
            }
        }
        public void SetAllEquip(in Byte Weapon, in Byte Armor, in Byte Legs, in Byte Boots)
        {
            PlayerEQ[0] = Weapon;
            PlayerEQ[1] = Armor;
            PlayerEQ[2] = Legs;
            PlayerEQ[3] = Boots;
        }
        public UInt16 MaxHP { get; set; }
        public UInt16 MaxAP { get; set; }
        public UInt16 CurrentHP { get; set; }
        public UInt16 CurrentAP { get; set; }
        public Byte Attack { get; set; }
        public Byte Defence { get; set; }
        public Byte Speed { get; set; }
        public Byte Special { get; set; }
        public Byte Learned { get; set; }
        public Byte CurrentLevel { get; set; }
        public Byte PlayerStatus { get; set; }
        public Byte DefenseState { get; set; }
        public UInt16[] NextLevel { get; set; }
        public UInt16[] MaxHPNxt { get; set; }
        public UInt16[] MaxAPNxt { get; set; }
        public Byte[] AttackNxt { get; set; }
        public Byte[] DefenseNxt { get; set; }
        public Byte[] SpeedNxt { get; set; }
        public Byte[] SpecialNxt { get; set; }
        public Byte[] PlayerEQ { get; set; }
        public Byte MenuTask { get; set; }
        public Boolean MiniTask { get; set; }
        public UInt16 Experience { get; set; }
    }

    //[EN] Bag class, depends on items getting and used in/out battle
    //[RU] Класс мешка с вещами, зависит от вещей, получаемых и используемых в/вне боя
    public class Bag : Characteristics
    {
        public Bag()
        {
            Equip();
            Items();
        }

        //[EN] Initialize empty slots of equipment
        //[RU] Метод для обозначения слотов экипировки
        public void Equip()
        {
            Hands = false;
            Weapon = new Boolean[] { false, false, false, false };
            Jacket = false;
            Armor = new Boolean[] { false, false, false, false };
            Legs = false;
            Pants = new Boolean[] { false, false, false, false };
            Boots = false;
            ArmBoots = new Boolean[] { false, false, false, false };
        }
        public void EquipPropertyChange(in Byte propertyNo, in Boolean onChange)
        {
            switch (propertyNo)
            {
                case 0: Hands = onChange; break;
                case 1: Jacket = onChange; break;
                case 2: Legs = onChange; break;
                case 3: Boots = onChange; break;
                default: break;
            }
        }

        //[EN] Initialize items count method
        //[RU] Метод для обозначения хранения каждого вида предметов
        public void Items()
        {
            BandageITM = 0;
            AntidoteITM = 0;
            EtherITM = 0;
            FusedITM = 0;
            HerbsITM = 0;
            SleepBagITM = 0;
            Ether2ITM = 0;
            ElixirITM = 0;
            Materials = 0;
        }
        public void ItemsSet(in Byte Bandages, in Byte Antidote, in Byte Ether, in Byte Fused, in Byte Herbs, in Byte SleepBags, in Byte Ethers2, in Byte Elixir, in UInt16 Materia) {
            BandageITM = Bandages;
            AntidoteITM = Antidote;
            EtherITM = Ether;
            FusedITM = Fused;
            HerbsITM = Herbs;
            SleepBagITM = SleepBags;
            Ether2ITM = Ethers2;
            ElixirITM = Elixir;
            Materials = Materia;
        }
        public void ItemsSet(in Byte Bandages, in Byte Antidote, in Byte Ether, in Byte Fused, in Byte Herbs, in Byte SleepBags, in Byte Ethers2, in Byte Elixir)
        {
            BandageITM = Bandages;
            AntidoteITM = Antidote;
            EtherITM = Ether;
            FusedITM = Fused;
            HerbsITM = Herbs;
            SleepBagITM = SleepBags;
            Ether2ITM = Ethers2;
            ElixirITM = Elixir;
        }
        public void EquipWearSet(in Boolean hands, in Boolean jacket, in Boolean legs, in Boolean boots)
        {
            Hands = hands;
            Jacket = jacket;
            Legs = legs;
            Boots = boots;
        }
        public void EquipKindsSet(in Boolean[] weapon, in Boolean[] armor, in Boolean[] pants, in Boolean[] armboots)
        {
            Weapon = weapon;
            Armor = armor;
            Pants = pants;
            ArmBoots = armboots;
        }
        public void EquipAllSet(in Boolean hands, in Boolean jacket, in Boolean legs, in Boolean boots, in Boolean[] weapon, in Boolean[] armor, in Boolean[] pants, in Boolean[] armboots)
        {
            EquipWearSet(hands, jacket, legs, boots);
            EquipKindsSet(weapon, armor, pants, armboots);
        }
        public Byte BandageITM { get; set; }
        public Byte AntidoteITM { get; set; }
        public Byte EtherITM { get; set; }
        public Byte FusedITM { get; set; }
        public Byte HerbsITM { get; set; }
        public Byte Ether2ITM { get; set; }
        public Byte SleepBagITM { get; set; }
        public Byte ElixirITM { get; set; }
        public Boolean Hands { get; set; }
        public Boolean[] Weapon { get; set; }
        public Boolean Jacket { get; set; }
        public Boolean[] Armor { get; set; }
        public Boolean Legs { get; set; }
        public Boolean[] Pants { get; set; }
        public Boolean Boots { get; set; }
        public Boolean[] ArmBoots { get; set; }
        public UInt16 Materials { get; set; }
    }

    //[EN] Menu class, contents info 
    //[RU] Класс игрового меню, содержит справочную информацию
    public class Menu
    {
        public Menu()
        {
            InitOnNewGame();
        }

        private void InitOnNewGame()
        {
            InfoChange1 = 0;
            HelpInfo1 = new string[,]{ {"Введение","Древние - кто они?","Приключение","Управление","Сражение","Цель боя","Очки здоровья, ОЗ","Урон","Оборона","Побег","Статус","Показатели","Скорость (СКР)","Больше чем бой","Настройки","Проходы","Сундуки","Сила земли","Сцены" },
            {"Неизвестный...","Предыстория","Розыск","Меню/Выход","Противники","Ходы","Очки действий, ОД","Бой","Умения","Результаты","Уровень","Атака (АТК)","Спец. (СПЦ)","Реестр противников","Разработал","Стены","Опасности","Погостить пришёл","Благодарности" },
            {"Древние святыни","Артефакты","Главы","Взаимодействие","Боссы","Действия","АВШ","Выбор","Предметы","Прирост","Опыт","Защита (ЗЩТ)","Время игры","Задачи","До новых встреч","Замки","Цветные камушки","Секреты","Финансы" } };

            HelpInfo2 = new string[,] { {"Добро пожаловать, искатели\nприключений! Приветствуем\nвас в кратком своде правил.","Древние - люди, что когда-то\nобладали технологиями, кото-\nрые нам и не снились.","Вам доступно создание\nнового или загрузка старого\nприключения если оно было","Клавиатура обязательна\nПередвижение - WASD,\nВзаимодействие - E","Во время передвижения, на\nвас могут напасть. Не бой-\nтесь сражаться за правое!","Во время сражения нужно\nубрать всех противников и\nбоссов с поля, не погибнув.","Определяют какое количе-\nство урона персонаж может\nвзять, прежде чем умереть.","Числом определяет силу, с\nкоторой бьёт герой или враг,\nприближает к гибели.","Повышает защиту героя в\nдва раза до следующего\nхода.","Существует альтернативный\nспособ выйти из сражения -\nизбежать этим действием.","Выводит состояние героя,\nпри отравлении персонаж\nбудет терять ОЗ.","Влияют на выживаемость\nгероя, каждый отвечает за\nчто-то своё.","Влияет на скорость заполне-\nния АВШ и возможность\nсбежать из боя.","Умения доступны вне боя, а\nещё каждое из них можно\n\"пожамкать\" ^_^.","Не так-то просто справляться\nс шумом? Слишком яркое\nизображение? Не вопрос!","Место, по которому может\nходить герой, обычная\nплита.","Там хранится всевозможное\nоружие и броня древних.\nПочему бы и не одолжить?","Источники, бьющие прямо\nиз огненных песков лечат\nвсе недомогания.","Как никогда лучше показы-\nвают происходящее в\nсамом эпицентре событий." },
            {"Вы играете за одарённого\nархеолога Рэя, его целью\nявляется поиск артефактов.","После глупых войн и жажды\nвласти, люди истратили нас-\n","Здесь находятся все\nискатели! Можно разделять\nпрогресс с друзьями","Клавиатура обязательна\nОткрыть меню - Left CTRL\nВыйти из игры - ESC","Монстры и прочие чудища,\nвышедшие из под контроля\nжаждут вашей гибели","Действия героя и врагов\nраспределены: они могут\nвыполнять их спустя время","От ОД зависит доступ к осо-\nбым действиям - умениям,\nвызывающие эффекты","Опция позволяющая физи-\nчески атаковать врага\nгерою, зависит от АТК.","Каждое умение тратит ОД и\nможет оказывать эффект\nкак на врага, так и на героя.","Победив, вы получаете\nопыт, материалы и ве-\nщи в конце сражения.","Показывает потенциал\nперсонажа, от него за-\nвисят все показатели.","Урон, наносимый героем\nпри обычной атаке. Может\nбыть увеличена оружием.","Специальное влияет на силу\nэффектов от использования\nумений персонажа.","После открытия умения \"Из-\nучение\", вы сможете смот-\nреть показатели врагов","Прошу любить и жаловать:\nТатаринцев Александр,\nвыступал в роли FullStack.","Препятствия, через которые\nнельзя передвигаться. Из\nних составлены лабиринты.","Какое приключение не обо-\nйдётся без опасностей?\nВсё как положено.","-Алло, это кто?\n-Сэм.\n-Шутник, Сэм, это я.","Посвящается (Вы лучшие):\nМасленников Денис,\nМасленникова Татьяна" },
            {"Основными местами для\nпоиска сокровищ стали\nсооружения древних.","Артефакты содержат посла-\nния, лежащие в основе\nключа к мудрости веков","Приключение рассказывает\nисторию, основные события\nкоторой показаны в главах","Все нажатия на кнопки\nосуществляются с помощью\nлевой кнопки мыши (ЛКМ)","Древние стражи и могучие\nвластители, пробудившиеся\nото сна ждут боя.","Совокупность опций возни-\nкающих около персонажа.\nНужны для победы в бою.","Активная временная шкала\nпосле заполнения, даёт ход\nгерою, отображая действия.","Для выбора зоны пораже-\nния. Отмена - вернуться к\nпредыдущим опциям","Использование предметов,\nполученных после боя или\nсозданных материалами.","При повышении уровня, по-\nказатели героя вырастут,\nоблегчая новые задачи.","При сборе достаточного\nколичества - повышает\nуровень.","Снижает урон, получаемый\nот врагов. Может быть\nувеличена доспехами.","Всему своё время и приклю-\nчение - не исключение, бе-\nрегите глаза, друзья!","Для понимания основной\nцели - она разбита на\nзадачи.","Надеюсь данное руководст-\nво было вам полезно, даль-\nше для общего развития =)","Закрытые проходы, веду-\nщие через путь к выходу\nк артефактам. ","Артефакты - ключи, ведущие\nк сокровищам, эта основная\nцель приключения.","Каждое сооружение хранит\nсвои секреты. Сможете ли\nвы отыскать их все?","А в плане денег - у нас нет\nденег. Поможете ли доброй\nкопеечкой? 89212049320" } };
        }
        public Byte InfoChange1 { get; set; }
        public string[,] HelpInfo1 { get; set; }
        public string[,] HelpInfo2 { get; set; }
    }

    //[EN] Misc class, contents engine values
    //[RU] Класс прочее, содержит параметры двигателя игры
    public class Misc
    {
        public Misc()
        {
            InitOnNewGame();
        }

        //[EN] Adaptation subclass
        //[RU] Подкласс адаптации
        public class Adopt : Misc
        {
            public Adopt()
            {
                AdoptInit();
            }
            private void AdoptInit()
            {
                WidthAdBack = 1;
                HeightAdBack = 1;
                ImgLeftStep = 62;
                ImgTopStep = 30;
                ImgXbounds = 18;
                ImgYbounds = 34;
            }
            public void SetBounds(in Boolean LeftRightOrUpDown, in Byte RowOrColumn) { if (LeftRightOrUpDown) ImgYbounds = RowOrColumn; else ImgXbounds = RowOrColumn; }
            public double WidthAdBack { get; set; }
            public double HeightAdBack { get; set; }
            public double ImgLeftStep { get; set; }
            public double ImgTopStep { get; set; }
            public int ImgXbounds { get; set; }
            public int ImgYbounds { get; set; }
        }
        private void InitOnNewGame()
        {
            EquipmentClass = 0;
            TableEN = true;
            LockIndex = 3;
            StepsToBattle = 20;
            SelectedTarget = 0;
            FoeType1Alive = 0;
            FoeType2Alive = 0;
            FoeType3Alive = 0;
            FoeType4Alive = 0;
            EnemyRate = 2;
            Rnd1 = 0;
            Rnd2 = 0;
            SpecialBattle = 0;
            ItemsDropRate = new Byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
        }
        public void EnemiesGetDown(in Byte propertyNo)
        {
            switch (propertyNo)
            {
                case 0: FoeType1Alive--; break;
                case 1: FoeType2Alive--; break;
                case 2: FoeType3Alive--; break;
                case 3: FoeType4Alive--; break;
                default: break;
            }
        }
        public void EnemiesGetLost(in Byte propertyNo)
        {
            switch (propertyNo)
            {
                case 0: FoeType1Alive = 0; break;
                case 1: FoeType2Alive = 0; break;
                case 2: FoeType3Alive = 0; break;
                case 3: FoeType4Alive = 0; break;
                default: break;
            }
        }
        public Byte SelectedTarget { get; set; }
        public Byte StepsToBattle { get; set; }
        public Byte EnemyRate { get; set; }
        public Int32 Rnd1 { get; set; }
        public Int32 Rnd2 { get; set; }
        public Byte EquipmentClass { get; set; }
        public Byte FoeType1Alive { get; set; }
        public Byte FoeType2Alive { get; set; }
        public Byte FoeType3Alive { get; set; }
        public Byte FoeType4Alive { get; set; }
        public bool TableEN { get; set; }
        public Byte LockIndex { get; set; }
        public Byte SpecialBattle { get; set; }
        public Byte[] ItemsDropRate { get; set; }
    }

    /// <summary>
    /// [EN] Interaction logic for MainWindow.xaml
    /// [RU] Интерактивная логика для ГлавногоЭкрана.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //[EN] Initialize MainWindow (Main Constructor)
        //[RU] Инициализация ГлавногоЭкрана (Главный Конструктор).
        public MainWindow()
        {
            InitializeComponent();
            Foe1.SetEnemies();
            Path.SetPaths();
            SetEnemies();
            WidelyUsedAnyTimer(out TimeRecord, WorldRecord, new TimeSpan(0, 0, 0, 0, 1));
            HeyPlaySomething(Path.GameMusic.MainTheme);
            CheckScreenProperties();

            try { Autorization(); } catch (Exception ex) { throw new Exception("Something get wrong, Read this: " + ex); }
        }
        public void Autorization() { DataBaseMSsql.CheckAllRecordedPlayers(); CurrentPlayer.Content = DataBaseMSsql.GetCurrentPlayer(); Continue.IsEnabled = DataBaseMSsql.CheckIfPlayerCanContinue(); }
        /*System.Windows.Markup.XamlParseException: "Вызов конструктора для типа "WpfApp1.MainWindow", удовлетворяющего указанным ограничениям привязки, привел к выдаче исключения."*/

        Sql DataBaseMSsql = new Sql();

        public static UInt16[] TimeWorldRecord = new UInt16[] { 0, 0, 0, 0 };
        private void WorldRecord(object sender, EventArgs e)
        {
            if ((TimeWorldRecord[0] <= 23) && (TimeWorldRecord[1] <= 60) && (TimeWorldRecord[2] <= 60) && (TimeWorldRecord[3] <= 100)) {
                TimeWorldRecord[3]++;
                if (TimeWorldRecord[3] >= 100)
                {
                    TimeWorldRecord[2]++;
                    TimeWorldRecord[3] = 0;
                }
                if (TimeWorldRecord[2] >= 60)
                {
                    TimeWorldRecord[1]++;
                    TimeWorldRecord[2] = 0;
                }
                if (TimeWorldRecord[1] >= 60)
                {
                    TimeWorldRecord[0]++;
                    TimeWorldRecord[1] = 0;
                }
                if (TimeWorldRecord[0] >= 2)
                {
                    TimeRecordText.Foreground = Brushes.Yellow;
                    if ((TimeWorldRecord[1] >= 10) && (TimeWorldRecord[2] >= 10) && (TimeWorldRecord[3] >= 10))
                        TimeRecordText.Content = "Эй, это уже не шутки! Время: " + TimeWorldRecord[0] + ":" + TimeWorldRecord[1] + ":" + TimeWorldRecord[2] + "." + TimeWorldRecord[3];
                    else if ((TimeWorldRecord[1] >= 10) && (TimeWorldRecord[2] >= 10))
                        TimeRecordText.Content = "Эй, это уже не шутки! Время: " + TimeWorldRecord[0] + ":" + TimeWorldRecord[1] + ":" + TimeWorldRecord[2] + ".0" + TimeWorldRecord[3];
                    else if (TimeWorldRecord[1] >= 10)
                        TimeRecordText.Content = "Эй, это уже не шутки! Время: " + TimeWorldRecord[0] + ":" + TimeWorldRecord[1] + ":0" + TimeWorldRecord[2] + ".0" + TimeWorldRecord[3];
                    else if ((TimeWorldRecord[2] >= 10) && (TimeWorldRecord[3] >= 10))
                        TimeRecordText.Content = "Эй, это уже не шутки! Время: " + TimeWorldRecord[0] + ":0" + TimeWorldRecord[1] + ":" + TimeWorldRecord[2] + "." + TimeWorldRecord[3];
                    else if (TimeWorldRecord[2] >= 10)
                        TimeRecordText.Content = "Эй, это уже не шутки! Время: " + TimeWorldRecord[0] + ":0" + TimeWorldRecord[1] + ":" + TimeWorldRecord[2] + ".0" + TimeWorldRecord[3];
                    else if ((TimeWorldRecord[3] >= 10))
                        TimeRecordText.Content = "Эй, это уже не шутки! Время: " + TimeWorldRecord[0] + ":0" + TimeWorldRecord[1] + ":0" + TimeWorldRecord[2] + "." + TimeWorldRecord[3];
                    else
                        TimeRecordText.Content = "Эй, это уже не шутки! Время: " + TimeWorldRecord[0] + ":0" + TimeWorldRecord[1] + ":0" + TimeWorldRecord[2] + ".0" + TimeWorldRecord[3];
                }
                else if (TimeWorldRecord[1] >= 30)
                {
                    TimeRecordText.Foreground = Brushes.Green;
                    if ((TimeWorldRecord[1] >= 10) && (TimeWorldRecord[2] >= 10) && (TimeWorldRecord[3] >= 10))
                        TimeRecordText.Content = "Пора передохнуть... Время: " + TimeWorldRecord[0] + ":" + TimeWorldRecord[1] + ":" + TimeWorldRecord[2] + "." + TimeWorldRecord[3];
                    else if ((TimeWorldRecord[1] >= 10) && (TimeWorldRecord[2] >= 10))
                        TimeRecordText.Content = "Пора передохнуть... Время: " + TimeWorldRecord[0] + ":" + TimeWorldRecord[1] + ":" + TimeWorldRecord[2] + ".0" + TimeWorldRecord[3];
                    else if (TimeWorldRecord[1] >= 10)
                        TimeRecordText.Content = "Пора передохнуть... Время: " + TimeWorldRecord[0] + ":" + TimeWorldRecord[1] + ":0" + TimeWorldRecord[2] + ".0" + TimeWorldRecord[3];
                    else if ((TimeWorldRecord[2] >= 10) && (TimeWorldRecord[3] >= 10))
                        TimeRecordText.Content = "Пора передохнуть... Время: " + TimeWorldRecord[0] + ":0" + TimeWorldRecord[1] + ":" + TimeWorldRecord[2] + "." + TimeWorldRecord[3];
                    else if (TimeWorldRecord[2] >= 10)
                        TimeRecordText.Content = "Пора передохнуть... Время: " + TimeWorldRecord[0] + ":0" + TimeWorldRecord[1] + ":" + TimeWorldRecord[2] + ".0" + TimeWorldRecord[3];
                    else if (TimeWorldRecord[3] >= 10)
                        TimeRecordText.Content = "Пора передохнуть... Время: " + TimeWorldRecord[0] + ":0" + TimeWorldRecord[1] + ":0" + TimeWorldRecord[2] + "." + TimeWorldRecord[3];
                    else
                        TimeRecordText.Content = "Пора передохнуть... Время: " + TimeWorldRecord[0] + ":0" + TimeWorldRecord[1] + ":0" + TimeWorldRecord[2] + ".0" + TimeWorldRecord[3];
                }
                else
                {
                    if ((TimeWorldRecord[1] >= 10) && (TimeWorldRecord[2] >= 10) && (TimeWorldRecord[3] >= 10))
                        TimeRecordText.Content = "Время: " + TimeWorldRecord[0] + ":" + TimeWorldRecord[1] + ":" + TimeWorldRecord[2] + "." + TimeWorldRecord[3];
                    else if ((TimeWorldRecord[1] >= 10) && (TimeWorldRecord[2] >= 10))
                        TimeRecordText.Content = "Время: " + TimeWorldRecord[0] + ":" + TimeWorldRecord[1] + ":" + TimeWorldRecord[2] + ".0" + TimeWorldRecord[3];
                    else if (TimeWorldRecord[1] >= 10)
                        TimeRecordText.Content = "Время: " + TimeWorldRecord[0] + ":" + TimeWorldRecord[1] + ":0" + TimeWorldRecord[2] + ".0" + TimeWorldRecord[3];
                    else if ((TimeWorldRecord[2] >= 10) && (TimeWorldRecord[3] >= 10))
                        TimeRecordText.Content = "Время: " + TimeWorldRecord[0] + ":0" + TimeWorldRecord[1] + ":" + TimeWorldRecord[2] + "." + TimeWorldRecord[3];
                    else if (TimeWorldRecord[2] >= 10)
                        TimeRecordText.Content = "Время: " + TimeWorldRecord[0] + ":0" + TimeWorldRecord[1] + ":" + TimeWorldRecord[2] + ".0" + TimeWorldRecord[3];
                    else if (TimeWorldRecord[3] >= 10)
                        TimeRecordText.Content = "Время: " + TimeWorldRecord[0] + ":0" + TimeWorldRecord[1] + ":0" + TimeWorldRecord[2] + "." + TimeWorldRecord[3];
                    else
                        TimeRecordText.Content = "Время: " + TimeWorldRecord[0] + ":0" + TimeWorldRecord[1] + ":0" + TimeWorldRecord[2] + ".0" + TimeWorldRecord[3];
                }
            }
            else
            {
                TimeRecordText.Foreground = Brushes.Red;
                TimeRecordText.Content = "Срочно выключай машину! Время: 23:59:59.99";
                TimeRecord.Stop();
            }
        }
        //[EN] Initialize public objects
        //[RU] Инициализация объектов публичного доступа
        Descriptions.Foes FoesNames = new Descriptions.Foes();
        Paths Path = new Paths();
        
        Bag BAG = new Bag();
        Characteristics Super1 = new Characteristics { MaxHP = 100, MaxAP = 40, Attack = 25, Defence = 15, Speed = 15, Special = 25 };
        Foe Foe1 = new Foe();
        Misc Sets = new Misc();
        Misc.Adopt Adoptation = new Misc.Adopt();
        Menu GameMenu = new Menu();
        private void ChbShow(CheckBox Chb) { Chb.Visibility = Visibility.Visible; Chb.IsEnabled = true; }
        private void ChbHide(CheckBox Chb) { Chb.Visibility = Visibility.Hidden; Chb.IsEnabled = false; }
        private void SetEnemies()
        {
            Foe1.Spider.PreStats(0);
            Foe1.Mummy.PreStats(1);
            Foe1.Zombie.PreStats(2);
            Foe1.Bones.PreStats(3);
            Foe1.Vulture.PreStats(4);
            Foe1.Ghoul.PreStats(5);
            Foe1.GrimReaper.PreStats(6);
            Foe1.Scarab.PreStats(7);
            Foe1.BOSS1.PreStats(12);
            Foe1.BOSS2.PreStats(13);
            Foe1.SecretBOSS1.PreStats(15);
        }
        private void ImgShrink(Image Img, in Double W, in Double H) { Img.Width = W; Img.Height = H; }
        private void BtnShrink(Button Btn, in Double W, in Double H) { Btn.Width = W; Btn.Height = H; }
        private void BarShrink(ProgressBar Bar, in Double W, in Double H) { Bar.Width = W; Bar.Height = H; }
        private void MedShrink(MediaElement Med, in Double W, in Double H) { Med.Width = W; Med.Height = H; }
        private void LabShrink(Label Lab, in Double fs) { Lab.FontSize = fs; }
        private void LabGrid(Label Lab, in Byte row, in Byte col) { Grid.SetRow(Lab, row); Grid.SetColumn(Lab, col); }
        private void BtnGrid(Button Btn, in Byte row, in Byte col) { Grid.SetRow(Btn, row); Grid.SetColumn(Btn, col); }
        private void BarGrid(ProgressBar Bar, in Byte row, in Byte col) { Grid.SetRow(Bar, row); Grid.SetColumn(Bar, col); }
        private void MedGrid(MediaElement Med, in Byte row, in Byte col) { Grid.SetRow(Med, row); Grid.SetColumn(Med, col); }
        private void ImgGrid(Image Img, in Byte row, in Byte col) { Grid.SetRow(Img, row); Grid.SetColumn(Img, col); }
        private void ButtonCHFT(Button Btn, in Double fs) { Btn.FontSize = fs; }
        private void TxtHide(TextBlock Txt) { Txt.Visibility = Visibility.Hidden; Txt.IsEnabled = false; }
        private void TxtShow(TextBlock Txt) { Txt.Visibility = Visibility.Visible; Txt.IsEnabled = true; }
        private void TxtHideX(TextBlock[] TextArray) { foreach (TextBlock Txt in TextArray) TxtHide(Txt); }
        private void TxtShowX(TextBlock[] TextArray) { foreach (TextBlock Txt in TextArray) TxtShow(Txt); }
        private void SldHide(Slider sld) { sld.Visibility = Visibility.Hidden; sld.IsEnabled = false; }
        private void SldShow(Slider sld) { sld.Visibility = Visibility.Visible; sld.IsEnabled = true; }
        private void AnyHide(Object Element)
        {
            switch (Element.GetType().ToString())
            {
                case "System.Windows.Controls.Label": LabHide((Label)Element); break;
                case "System.Windows.Controls.Button": ButtonHide((Button)Element); break;
                case "System.Windows.Controls.Image": ImgHide((Image)Element); break;
                case "System.Windows.Controls.TextBlock": TxtHide((TextBlock)Element); break;
                case "System.Windows.Controls.Slider": SldHide((Slider)Element); break;
                case "System.Windows.Controls.CheckBox": ChbHide((CheckBox)Element); break;
                case "System.Windows.Controls.MediaElement": MediaHide((MediaElement)Element); break;
                case "System.Windows.Controls.ProgressBar": BarHide((ProgressBar)Element); break;
                case "System.Windows.Controls.TextBox": TBoxHide((TextBox)Element); break;
            }
        }
        private void AnyShow(Object Element)
        {
            switch (Element.GetType().ToString())
            {
                case "System.Windows.Controls.Label": LabShow((Label)Element); break;
                case "System.Windows.Controls.Button": ButtonShow((Button)Element); break;
                case "System.Windows.Controls.Image": ImgShow((Image)Element); break;
                case "System.Windows.Controls.TextBlock": TxtShow((TextBlock)Element); break;
                case "System.Windows.Controls.Slider": SldShow((Slider)Element); break;
                case "System.Windows.Controls.CheckBox": ChbShow((CheckBox)Element); break;
                case "System.Windows.Controls.MediaElement": MediaShow((MediaElement)Element); break;
                case "System.Windows.Controls.ProgressBar": BarShow((ProgressBar)Element); break;
                case "System.Windows.Controls.TextBox": TBoxShow((TextBox)Element); break;
            }
        }
        private void AnyGrid(Object Element, in Byte row, in Byte column)
        {
            switch (Element.GetType().ToString())
            {
                case "System.Windows.Controls.Label": LabGrid((Label)Element, row, column); break;
                case "System.Windows.Controls.Button": BtnGrid((Button)Element, row, column); break;
                case "System.Windows.Controls.Image": ImgGrid((Image)Element, row, column); break;
                /*case "System.Windows.Controls.TextBlock": TxtGrid((TextBlock)Element, rows, columns); break;
                case "System.Windows.Controls.Slider": SldGrid((Slider)Element, rows, columns); break;
                case "System.Windows.Controls.CheckBox": ChbGrid((CheckBox)Element, rows, columns); break;*/
                case "System.Windows.Controls.MediaElement": MedGrid((MediaElement)Element, row, column); break;
                case "System.Windows.Controls.ProgressBar": BarGrid((ProgressBar)Element, row, column); break;
            }
        }
        private void AnyHideX(params Object[] Elements) { foreach (Object Element in Elements) AnyHide(Element); }
        private void AnyShowX(params Object[] Elements) { foreach (Object Element in Elements) AnyShow(Element); }
        private void AnyGridX(Object[] Elements, in Byte[] rows, in Byte[] columns) { for (Byte i = 0; i < Elements.Length; i++) AnyGrid(Elements[i], rows[i], columns[i]); }
        private void Adaptate()
        {
            ///In Game with player start
            //[EN] Adaptate mechanics, sreen elements formula: CurrentScreenSize/Recomended(1920X1080)
            //[RU] Механика адаптации, формула расположения элементов: ТекущееРазрешениеЭкрана/Рекомендуемое(1920Х1080)
            Button[] BtnWFM = { Button1, Skip1, Equip1, Equip2, Equip3, Equip4, Remove1, Remove2, Remove3, Remove4, CancelEq, Button2, Button3, Button4, Abilities, Items, Back2, Back1, Fight, Cancel1, Cancel2, Cure, Torch, Heal, Whip, Super, ACT1, ACT2, textOk2, TextOk1, InfoIndexMinus, InfoIndexPlus };
            Button[] BtnM = { Cure1, Heal1, Bandage, Ether1, Antidote, Fused, Equipments, Status, Abils, Items0, Tasks, Info, Equip, Bandage1, Antidote1, Ether, Fused1 };
            //TimeImg
            Label[] LabMS = { Lab1, Lab2, FightSkills, MiscSkills, HealCost, AbilsCost, CostText, BandageText, EtherText, AntidoteText, FusedText, CountText, Task1, Task2, Task3, Task4, InfoHeaderText1, InfoHeaderText2, InfoHeaderText3, InfoIndex, Describe1, Describe2, BattleText1, BattleText2, HPtext, APtext, LevelText, ExpText, ItemText, BattleText3, BattleText4, BattleText5, BattleText6, HPenemy, BandageText, EtherText, AntidoteText, FusedText, CountText, ATK, FightSkills, MiscSkills, HealCost, AbilsCost, CostText, Name0, Level0, StatusP, HPtext1, APtext1, Exp1, ATK1, DEF1, AG1, SP1, Params, ParamsATK, ParamsDEF, ParamsAG, ParamsSP, HP1, AP1, EquipH, EquipB, EquipL, EquipD, EquipText, HP, AP };
            Image[] ImgMS = { Icon0, ATKImg, DEFImg, AGImg, SPImg, EquipHImg, EquipBImg, EquipLImg, EquipDImg, Task1Img, Task2Img, Task3Img, Task4Img, Img4, Img5, ItemsCountImg, Img6, Img7, Img8, ChestImg4, ChestImg3, ChestImg2, ChestImg1, LockImg3, LockImg2, LockImg1, KeyImg3, KeyImg2, KeyImg1, Threasure1, Table1, Table2, Table3, TableMessage1, ChestMessage1 };
            ProgressBar[] StBarMS = { HPbar1, APbar1, ExpBar1 };
            ProgressBar[] BarMS = { HPbar, APbar, NextExpBar, Time1, HPenemyBar };
            MediaElement[] MedMS = { PharaohBattle, Trgt };
            //Params, ParamsATK, ParamsDEF, ParamsAG, ParamsSP, ATK1, DEF1, AG1, SP1, EquipText, EquipH, EquipB, EquipL, EquipD, Exp1,
            foreach (Button btn in BtnWFM) { BtnShrink(btn, (btn.Width * Adoptation.WidthAdBack), (btn.Height * Adoptation.HeightAdBack)); ButtonCHFT(btn, btn.FontSize * Adoptation.WidthAdBack); }
            foreach (Button btn in BtnM) { BtnShrink(btn, (btn.Width * Adoptation.WidthAdBack), (btn.Height * Adoptation.HeightAdBack)); }
            foreach (Label lab in LabMS) { LabShrink(lab, lab.FontSize * Adoptation.WidthAdBack); }
            foreach (Image img in ImgMS) { ImgShrink(img, img.Width * Adoptation.WidthAdBack, img.Height * Adoptation.HeightAdBack); }
            foreach (ProgressBar bar in StBarMS) { BarShrink(bar, bar.Width * 2 * Adoptation.WidthAdBack, bar.Height * Adoptation.HeightAdBack); }
            foreach (ProgressBar bar in BarMS) { BarShrink(bar, bar.Width * Adoptation.WidthAdBack, bar.Height * Adoptation.HeightAdBack); }
            foreach (MediaElement med in MedMS) { MedShrink(med, med.Width * Adoptation.WidthAdBack, med.Height * Adoptation.HeightAdBack); }
            ///[EN] When fire start, break this, this may make more fun) Or if you want to release where player and Location stands|[RU] Ничего такого, просто способ быстро понять в чём дело, если элементы уехали в сторону
            //Lab1.Content = Img1.Margin.Top;
            //ImgShrink(Img2, 9999, 9999);
        }

        //D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\

        private void FullImgMedAutoShrink(in int W, in int H)
        {
            ImgShrink(Menu1, W, H);
            MedShrink(Med1, W, H);
            MedShrink(Med2, W, H);
            MedShrink(Win, W, H);
            MedShrink(GameOver, W, H);
            MedShrink(TheEnd, W, H);
            ImgShrink(Img1, W, H);
        }
        private void CheckScreenProperties()
        {
            int[,] ScreenSize = { { 800, 1024, 1152, 1280, 1280, 1280, 1280, 1280, 1360, 1366, 1440, 1600, 1600, 1680, 3840 }, { 600, 768, 864, 720, 768, 800, 960, 1024, 768, 768, 900, 900, 1024, 1050, 2160 } };
            double[,] WHB = { { 0.416667, 0.533333, 0.6, 0.666667, 0.666667, 0.666667, 0.666667, 0.666667, 0.708333, 0.711458, 0.75, 0.833333, 0.833333, 0.875, 2 }, { 0.555556, 0.711111, 0.8, 0.666667, 0.711111, 0.740741, 0.888889, 0.948148, 0.711111, 0.711111, 0.833333, 0.833333, 0.948148, 0.972222, 2 } };
            double[,] I2S = { { 12.92, 16.53, 18.6, 20.67, 20.67, 20.67, 20.67, 20.67, 21.96, 22.06, 23.25, 25.83, 25.83, 27.125, 62 }, { 16.67, 21.33, 24, 20.1, 21.33, 22.22, 26.67, 28.44, 21.33, 21.33, 25, 25, 28.44, 29.16, 60 } };
            String Screen = SystemParameters.VirtualScreenWidth + "X" + SystemParameters.VirtualScreenHeight;
            if (Screen != "1920X1080") {
                for (int j = 0; j < ScreenSize.GetLength(1); j++)
                {
                    if (Screen == (ScreenSize[0, j] + "X" + ScreenSize[1, j]))
                    {
                        Adoptation.HeightAdBack = WHB[1, j];
                        Adoptation.WidthAdBack = WHB[0, j];
                        ImgShrink(Img2, I2S[0, j], I2S[1, j]);
                        FullImgMedAutoShrink(ScreenSize[0, j], ScreenSize[1, j]);
                        Adoptation.ImgLeftStep = I2S[0, j] * 2;
                        Adoptation.ImgTopStep = I2S[1, j];
                        Adaptate();
                        break;
                    }
                    if (j == ScreenSize.GetLength(1))
                    {
                        MessageBoxResult MR = System.Windows.MessageBox.Show("Приложение не поддерживает данный\nтип разрешения на этом устройстве\n" + "\nДоступные разрешения:\n800x600;         1024X768;\n1152x864;       1280X720;\n1280x768;       1280X800;\n1280x960;       1280X1024;\n1360x768;       1366X768;\n1440x900;       1600X900;\n1600x1024;     1680X1050;\n1920x1080;     3840X2160;\n" + "\nТекущее разрешение экрана: " + Screen, "Ошибка адаптации разрешения", MessageBoxButton.OK, MessageBoxImage.Error);
                        if (MR == MessageBoxResult.OK) Form1.Close();
                    }
                }
            }
            else { Adoptation.ImgLeftStep = 62; Adoptation.ImgTopStep = 30; }
        }

        //[EN] Initialize all variables
        //[RU] Инициализация всех переменных.

        //[EN] Initialize timers
        //[RU] Инициализация таймеров.
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer timer2 = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer timer3 = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer timer4 = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer timer5 = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer timer6 = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer timer7 = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer timer8 = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer timer9 = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer timer10 = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer timer11 = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer timer12 = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer timer13 = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer TimeRecord = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer BossAppear1 = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer HPRegenerate = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer APRegenerate = new System.Windows.Threading.DispatcherTimer();

        //[EN] Initialize way to escape and experience
        //[RU] Инициализация состояния побега и количества опыта, получаемого после боя.
        public static Int32 speed = 0;
        public static Int32 Exp = 0;
        public static Byte[,] MapScheme;

        //[EN] Initialize random mechanic
        //[RU] Инициализация механики ведения случайных величин.
        public static Random Random1 = new Random();
        public static Int32 rnd = Random1.Next(5, 20);
        public static int poison = 0;

        private void New_game()
        {
            //[EN] Return to normal stats
            //[RU] Возврат к исходным значениям.
            AnyHideX(AddProfile, DeleteProfile, Player1, Player2, Player3, Player4, Player5, Player6, CurrentPlayer, AutorizeImg, Continue, AddPlayer);

            DataBaseMSsql.NewGameStart(DataBaseMSsql.CurrentLogin);

            SetEnemies();
            Exp = 0;
            Foe1.EnemyAppears[0] = "";
            Foe1.EnemyAppears[1] = "";
            Foe1.EnemyAppears[2] = "";
            Foe1.EnemiesStillAlive = 0;

            Sets.FoeType1Alive = 0;
            Sets.FoeType2Alive = 0;
            Sets.FoeType3Alive = 0;
            Sets.FoeType4Alive = 0;

            PharaohAppears.Opacity = 0.1;
            Sets.SpecialBattle = 0;

            MapBuild(0);
            ImgGridX(new Image[] { ChestImg1, ChestImg2, ChestImg3, ChestImg4, Table1, Table2, Table3, Threasure1, SaveProgress, PharaohAppears }, new Byte[] { 27, 24, 7, 9, 33, 25, 10, 4, 17, 8 }, new Byte[] { 19, 11, 21, 20, 18, 13, 38, 36, 29, 36 });
            Super1.SetStats(25, 999, 999, 255, 255, 255, 255);
            Super1.SetAnyValues(new object[] { Super1.CurrentHP, Super1.CurrentAP }, 999);
            PlayerSetLocation(34, 18);
            MaxAndWidthHPcalculate();
            MaxAndWidthAPcalculate();
            BAG.EquipWearSet(false, false, false, false);
            BAG.ItemsSet(10, 10, 10, 10, 0, 0, 0, 0, 0);
            Super1.MenuTask = 0;
            FastImgChange(new Image[] { ChestImg1, ChestImg2, ChestImg3, ChestImg4 }, BmpersToX(Bmper(Path.MapModels.ChestClosed1), Bmper(Path.MapModels.ChestClosed1), Bmper(Path.MapModels.ChestClosed1), Bmper(Path.MapModels.ChestClosed1)));
        }
        private void HeyPlaySomething(Uri uris) { Sound1.Stop(); Sound1.Source = uris; Sound1.Play(); }
        private void HeyPlaySomething(in string Path) { Sound1.Stop(); Sound1.Source = Ura(Path); Sound1.Play(); }
        private void Dj(Uri uris) { Sound2.Stop(); Sound2.Source = uris; Sound2.Play(); }
        private void Dj(in string Path) { Sound2.Stop(); Sound2.Source = Ura(Path); Sound2.Play(); }
        private void SEF(Uri sound) { Sound3.Stop(); Sound3.Source = sound; Sound3.Play(); }
        private void SEF(in string Path) { Sound3.Stop(); Sound3.Source = Ura(Path); Sound3.Play(); }
        //[EN] Working with Images
        //[RU] Работа с изображениями
        private void ImgHide(Image Img) { Img.Visibility = Visibility.Hidden; Img.IsEnabled = false; }
        private void ImgShow(Image Img) { Img.Visibility = Visibility.Visible; Img.IsEnabled = true; } 
        //[EN] Working with Media
        //[RU] Работа с элементами Медиа (звук, анимация, прочее).
        private void MediaHide(MediaElement Med) { Med.Stop(); Med.Visibility = Visibility.Hidden; Med.IsEnabled = false; }
        private void MediaShow(MediaElement Med) { Med.Visibility = Visibility.Visible; Med.IsEnabled = true; Med.Play(); }
        //[EN] Working with Buttons
        //[RU] Работа с кнопками.
        private void ButtonHide(Button Btn)
        { Btn.Visibility = Visibility.Hidden; Btn.IsEnabled = false; }
        private void BtnHideX(Button[] ButtonArray) { foreach (Button Btn in ButtonArray) ButtonHide(Btn); }
        private void ButtonShow(Button Btn) { Btn.Visibility = Visibility.Visible; Btn.IsEnabled = true; }
        //[EN] Working with Labels
        //[RU] Работа с метками (надписями).
        private void LabHide(Label Lab) { Lab.Visibility = Visibility.Hidden; Lab.IsEnabled = false; }
        private void LabShow(Label Lab) { Lab.Visibility = Visibility.Visible; Lab.IsEnabled = true; }
        //[EN] Working with bars
        //[RU] Работа со шкалами.
        private void BarShow(ProgressBar Bar) { Bar.Visibility = Visibility.Visible; Bar.IsEnabled = true; }
        private void BarHide(ProgressBar Bar) { Bar.Visibility = Visibility.Hidden; Bar.IsEnabled = false; }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            New_game();
            MediaShow(Med1);
            AnyHideX(Lab1, Button1);
            ButtonShow(Skip1);
            HeyPlaySomething(Path.GameMusic.Prologue);
        }
        public Uri Ura(in string Path) { return new Uri(Path, UriKind.RelativeOrAbsolute); }
        public BitmapImage Bmper(string UriToBmp) { return new BitmapImage(new Uri(UriToBmp, UriKind.RelativeOrAbsolute)); }
        public BitmapImage[] BmpersToX(params BitmapImage[] bitmapImages) { return bitmapImages; }
        private void AnyShowX(in Boolean[] Conditions, Object[] Objects) { for (Byte i = 0; i < Conditions.Length; i++) if (Conditions[i]) AnyShow(Objects[i]); }
        private void MapBuild(in Byte Loc)
        {
            switch (Loc)
            {
                case 0:
                    MapScheme = new Byte[,]
                    {{ 1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1 },
                    {  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  0,  1,  0,  1,  0,  0,  1,  0,  1,  0,  0,  0,  1,  1,  1,  1,  1,  1,  0,  1,  1,  1,  0,  0,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  1,  1,  0,  0,  0,  1 },
                    {  1,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  1,  1,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  1,  1,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  1,  1,  0,  1,  1,  1,  1,  0,  1,  0,  0,  1,  0,  1,  0,  1,  1,  1,  1,  1,  1,  1,  1,  0,  0,  1,  0,  1,  0,  1,  0,  0,  0,  0,  1,161,  1,  0,  0,  0,  1,  0,  0,  1,  1,  0,  1,  0,  0,  1,  1,  0,  0,  1,  1,  1,  0,  0,  1 },
                    {  1,  0,  0,  0,  1,  0,  0,  0,  0,  1,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  1,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  0,  1,  0,  0,  1,  0,  1,  1,  0,  0,  0,  0,  0,  1,  1,  0,  1 },
                    {  1,  1,  0,  1,  1,  0,  1,  1,  1,  1,  0,  1,  1,  0,  1,  1,  1,  1,  0,  1,  1,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,  1,  1,  1,  0,  0,  1,  0,  1,  1,  0,  1,  0,  0,  1,  1,  1,  1,  0,  1,  0,  1 },
                    {  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,203,  1,  0,  0,  1,  1,  0,  1,  0,  0,  0,  1,  1,  1,  1,133,  1,  1,  1,  0,  0,  0,  0,  1,  0,  0,  1,  0,  1,  0,  1,  1,  0,  0,  1,  0,  1,  0,  1 },
                    {  1,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  1,  0,  1,  0,  0,  0,  1,  1,  1,  0,  1,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  0,  1,  0,  1,  0,  1,  0,  0,  0,  1,  0,  1,  0,  1 },
                    {  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  1,  1,  1,  1,204,  0,  0,  0,  0,  1,  1,  0,  0,  0,  1,  0,  0,  0,  0,  1,  1,  1,  1,  0,  0,  0,  0,  0,  1,  0,  0,  1,  0,  1,  0,  1,191,  1,  0,  1,  0,  1,  0,  1 },
                    {  1,  0,  1,  0,  1,  1,  1,  1,  1,  1,  1,  0,  1,  0,  1,  0,  1,  0,  0,  0,  1,  1,  0,  0,  1,  0,  0,  1,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,173,  1,  1,  1,  1,  1,  1,  0,  1,  1,  0,  1,  0,  0,  1,  1,  0,  1,  0,  1,  0,  1 },
                    {  1,  0,  1,  0,  1,  0,  0,  0,  0,  0,  1,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  1,  0,  0,  1,  0,  0,  0,  1,  0,  0,  1,  1,  1,  0,  0,  0,  1,  1,  1,  0,  0,  0,  0,  0,  1,  0,  1,  1,  0,  0,  0,  0,  0,  1,  1,  0,  1 },
                    {  1,  0,  1,  0,  1,  0,  1,  1,  1,  0,  1,  0,  1,  1,  1,  1,  1,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  0,  1,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  0,  1,  1,  1,  1,  1,  1,  1,  0,  0,  1 },
                    {  1,  0,  1,  0,  1,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  1,  1,  1,  1,  0,  0,  1,  1,  1,  1,  1,  1,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  1,  0,  1,  0,  1,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  1,  0,  0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  0,  0,  1 },
                    {  1,  0,  1,  0,  1,  0,  1,  0,  1,  0,  1,  0,  0,  0,  1,  1,  1,  1,  1,  0,  0,  1,  0,  1,  1,  1,  1,  1,  0,  1,  1,  1,  1,  0,  0,  1,  1,  1,  1,  1,  1,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  1,  0,  1,  0,  1,  0,  1,  1,  1,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  1,  0,  0,  0,  1,  1,  0,  1,  0,  0,  1,150,  1,  0,  1,  0,  1,  1,  1,  1,  1,  0,  0,  1,  1,  1,  1,  1,  0,  1,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  1,  1,131,  1,  0,  0,  0,  0,  0,  1,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  1,  1,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  1,  1,  1,  1,  1,  1,132,  1,  1,  0,  1,  1,  1,  0,  0,  1,  0,  0,  1,  1,  1,  0,  1,  1,  1,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  0,  0,  0,  0,  1,  1,  1,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,  1,  1,  0,  0,  1 },
                    {  1,  0,  1,  0,  0,  0,  0,  1,  1,  1,  1,102,  0,  0,  0,  0,  1,  0,  1,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  0,  1,  0,  1,  0,  0,  0,  0,  1,  0,  1,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  1 },
                    {  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  1,  1,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  1 },
                    {  1,  0,  1,  0,  1,  1,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  1,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  0,  1,  0,  0,  1,  0,  0,  1,  1,  1,  1,  0,  0,  0,  0,  0,  1,  0,  0,  1 },
                    {  1,  0,  1,  0,  1,  0,  0,  0,  0,  0,  1,202,  0,  0,  1,  1,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  1 },
                    {  1,  1,  1,  0,  1,  1,  1,  1,  0,  0,  1,  1,  0,  0,  1,172,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  1,  0,  1,  1,  1,  1,  1,  1,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  1 },
                    {  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,  0,  1,  1,  1,  1,  1,  1,  0,  0,  1,  0,  0,  1,  0,  0,  0,  1,  1,  1,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  1,  1,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,201,  1,  0,  0,  0,  0,  1,  0,  0,  1,  1,  1,  1,  0,  0,  0,  0,  1,  1,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  1,  1,  1,  0,  1,  0,  0,  1,  0,  0,  1 },
                    {  1,  0,  0,  0,  1,  0,  0,  1,  1,  1,  0,  0,  0,  0,  1,  0,  0,  1,  0,  1,  0,  0,  0,  1,  0,  0,  1,  0,  0,  1,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  1,  1,  0,  1 },
                    {  1,  0,  1,  0,  1,  0,  0,  0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  1,  1,  0,  0,  1,  0,  1,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  1,  0,  0,  0,  0,  1,  0,  1,  0,  0,  1,  1,  1,  1,  1,  1,  1,  0,  1,  0,  0,  1 },
                    {  1,  0,  1,  0,  1,  0,  0,  0,  0,  1,  1,  1,  1,  0,  0,  0,  0,  1,  1,  0,  1,  0,  0,  1,  0,  0,  1,  0,  1,  1,  0,  0,  0,  1,  0,  1,  0,  1,  0,  0,  0,  1,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1 },
                    {  1,  1,  1,  0,  1,  1,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  1,  1,  1,  1,  0,  0,  1,  0,  0,  0,  1,  0,  1,  0,  1,  0,  1,  1,  1,  0,  1,  1,  0,  0,  1,  1,  1,  1,  0,  0,  1,  1,  0,  1,  0,  0,  1 },
                    {  1,  0,  0,  0,  1,  0,  0,  0,  0,  1,  1,  0,  0,  1,  0,  0,  1,  0,  0,  0,  1,  0,  1,  0,  0,  0,  1,  0,  1,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  1,  1,  0,  0,  0,  0,  1,  0,  0,  1,  0,  0,  1,  1,  0,  1 },
                    {  1,  0,101,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,171,  0,  1,  0,  1,  0,  1,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,103,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  1,  0,  0,  1 },
                    {  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1 }};
                    break;
                case 1:
                    MapScheme = new Byte[,]
                    {{ 1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1 },
                    {  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,  0,  1,  1,  1,  1,  1,  0,  0,  1,  1,  1,  0,  0,  0,  1,  1,  1,  0,  0,  0,  1 },
                    {  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  0,  1,  0,  0,  0,  1,  1,  1,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  7,  1,  0,  0,  0,  1 },
                    {  1,  0,  1,  1,  1,  1,  0,  1,  1,  1,  0,  1,  0,  1,  1,  1,  1,  1,  1,  1,  0,  1,  0,  0,  0,  0,  1,  0,  0,  1,  1,  0,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  1,  0,  0,  1,  0,  0,  1,  0,  1,135,  1,  0,  1,  0,  1 },
                    {  1,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,105,  1,232,  1,  0,  1 },
                    {  1,  0,  0,  1,  1,  0,  0,  1,  1,  1,  0,  1,  1,  1,  1,  1,  1,  1,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  1,  0,  0,  1,  1,  1,  0,  1,  1,  1,  1,  1,  0,  1,  0,  0,  1,  1,  1,  1,  0,  1,  0,  1,  1,  1,  0,  1 },
                    {  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  6,  6,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  1,  0,  0,  0,  0,  1,  1,  0,  0,  1,  0,  1,  0,  1,  0,  1 },
                    {  1,  0,106,  0,  1,  0,  6,  1,  0,  1,  0,  6,  6,  6,  0,  0,  0,  0,  1,  1,  1,  1,  0,  0,  1,  0,  0,  1,  1,  1,  1,  1,  0,  0,  1,205,  1,  0,  1,  0,  1,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  1,  0,  1 },
                    {  1,  0,  0,  1,  1,  6,  0,  1,208,  1,  0,  0,  6,  6,  1,  1,  1,  1,  1,  0,  0,  1,  0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  1,  1,  0,  1,  1,  1,  1,  0,  0,  0,  1,  0,  0,  1,  0,  0,  1,  0,  1,  0,  1,  0,  0,  0,  1 },
                    {  1,  0,  1,  0,  0,  0,  0,  1,  0,  1,  1,  1,  1,  1,  1,  0,  1,  0,  0,  0,  0,  0,  1,  1,206,  1,  1,  0,  0,  0,  0,  0,  6,  0,  6,  6,  0,  1,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  1,  1,  1,  1,  0,  1,  0,  1,  0,  1,  0,  1 },
                    {  1,  0,  6,  1,  1,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  6,  0,  6,  0,  0,  1,  0,  0,  0,  6,  6,  0,  6,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  1,  0,  1,  0,  0,  1,  0,  1,  0,  1,  0,  1,  0,  1 },
                    {  1,  6,  6,  0,  0,  0,  0,  1,  0,  1,  0,  0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  6,  0,  1,  0,  6,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  1,  1,  1,  1,  1,  0,  0,  0,  1,  0,  0,  1,  0,  1,  0,  1,  0,  1,  0,  1 },
                    {  1,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,  1,  0,  1,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  1,  0,  1 },
                    {  1,  0,  0,  1,  1,  1,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  6,  6,  0,  0,  0,  1,  1,  0,  0,  0,  1,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  1,  0,  1,  0,  1 },
                    {  1,  1,  1,  0,  0,  0,  1,  0,  0,  1,  0,  0,  1,  1,  0,  0,  0,  1,  1,  0,  0,  0,  1,  0,  1,  0,  1,  0,  0,  1,  0,  0,  6,  0,  0,  6,  0,  1,  0,  1,  1,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  1 },
                    {  1,  0,  0,  0,162,  0,  1,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  6,  6,  0,  0,  1,  0,  1,  0,  1,  0,  0,  1,  1,  0,  1,  0,  0,  0,  0,  0,  1,  0,  1,  1,  1,  0,  1 },
                    {  1,  1,  1,  0,  0,  0,  1,  0,  1,  0,  0,  1,  1,  0,  0,  0,  0,107,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  6,  0,  0,  6,  0,  1,  0,  0,  0,  0,  0,  1,  0,  1,  0,  1,  1,  1,  1,  1,  0,  1,  1,  1,  0,  0,  0,  1 },
                    {  1,  0,  0,  1,136,  1,  0,  0,  1,  0,  0,  0,  1,  1,  0,  0,  0,  0,  1,  0,  0,  1,  1,  0,  0,  1,  1,  0,  0,  0,  0,  1,  1,  1,  1,  0,  1,  1,  0,  1,  1,  1,  1,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,135,  0,  0,  0,  6,  6,  1 },
                    {  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  1,  0,  1,  0,  0,  1,  0,  0,  1,  1,  0,  0,  1,  0,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1 },
                    {  1,  0,  0,  1,  0,  1,  0,  0,  1,  0,  1,  1,  0,  1,  0,  0,  1,  1,  0,  1,  0,  1,  1,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  1,  0,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  6,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  1,  0,  0,  1,  0,  0,  1,  0,207,  1,  0,  1,  0,  0,  1,  0,  0,  1,  0,  0,  1,  1,  0,  1,  1,  0,  0,  1,  0,  0,  1,  1,  1,  1,  1,  0,  0,  0,  1,  1,  0,  1,  1,  0,  0,  0,  6,  0,  6,  0,  1,  0,  0,  1,104,  1,  0,  1 },
                    {  1,  0,176,  1,  0,  0,  1,  0,  1,  0,  0,  0,  0,  1,  0,  0,  1,  0,  0,  1,  0,  1,  1,175,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  1,  1,  0,  0,  0,  1,  1,  0,  0,  0,  6,  0,  1,  0,  0,  0,  1,  1,  1,  6,  1 },
                    {  1,  0,  0,  0,  1,  0,  1,  0,  1,  1,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  1,  0,  0,  0,  1,  0,  1,  1,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  1,  1,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  1,  1,  1,  1,  1,  6,  1,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  1,  0,  0,  1,  0,  0,  0,108,  0,  0,  0,  6,  0,  6,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  1,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1 },
                    {  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  1,  0,  0,  1,138,  1,  0,  6,  0,  6,  0,  0,  0,  0,  1,  0,  0,  1,  1,  0,  1,  6,  1,  0,  1,  0,  1,192,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1 },
                    {  1,  0,  0,  1,  1,  0,  0,  1,  1,  0,  1,  1,  1,  0,  1,  0,  1,  0,  1,  0,  0,  0,  1,  1,  1,  1,  1,  1,213,  1,  1,  1,  1,  0,  0,  0,  1,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,134,  1,  1,  1,  1,  0,  0,  0,  0,  1 },
                    {  1,  0,  1,  0,  0,  1,  0,  1,  0,  0,  0,  0,  1,  0,  1,137,  1,  0,  1,  0,150,  0,  1,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  1,  1,  0,  6,  0,  0,  1 },
                    {  1,  0,  1,  0,  0,  0,  0,  1,  1,  1,  1,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  1,  1,  0,  1,  0,  0,  1,  0,  0,  0,  0,  1,  1,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,174,  6,  6,  0,  1,  1,  0,  6,  0,  0,  1 },
                    {  1,  0,  0,  1,  1,  0,  0,  1,  0,  0,  0,  0,  1,  1,  1,  1,  6,  6,  0,  1,  0,  1,  0,  0,  1,  0,  0,  1,  0,  1,  1,  0,  0,  0,  0,  1,  6,  0,  6,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  6,  0,  0,  0,  0,  0,  0,  6,  0,  0,  1 },
                    {  1,  0,  0,  0,  0,  1,  0,  1,  0,  1,  1,  1,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  6,  0,  6,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  6,  0,  0,  0,  1 },
                    {  1,  0,  1,  0,  0,  1,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  1,  1,  0,  1,  0,  0,  0,  0,  0,  6,  0,  6,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  0,  1,  1,  0,  0,  1,  1,  0,  1,  1,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  6,  0,  6,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  6,  0,  6,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1 },
                    {  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1 } };
                    break;
                case 2:
                    MapScheme = new Byte[,]
                    {{ 1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1 },
                    {  1,  0,  0,  0,  0,  0,  0,  0,  0,178,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  8,  8,  1,  0,  0,  0,  1,  8,  8,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,179,  0,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  8,  8,  1,  0,  0,  0,  1,  8,  8,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  1,  0,  0,  8,  8,  1,  0,  0,  0,  1,  8,  8,  0,  0,  1,  0,  1,  1,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  1,  0,  0,  8,  8,  8,  1,  0,  1,  8,  8,  8,  0,  0,  1,  0,  1,  0,  0,  1,  1,  0,  0,  6,  6,  0,  0,  0,  1,  1,  1,  0,  0,  0,  6,  6,  0,  0,  1 },
                    {  1,  0,  0,  6,  6,  0,  0,  0,  1,  1,  1,  0,  0,  0,  6,  6,  0,  0,  1,  1,  0,  1,  0,  0,  0,  8,  8,  8,  0,  8,  8,  8,  0,  0,  0,  1,  0,  1,  0,  0,  1,  1,  0,  0,  6,  6,  0,  0,  1,  0,  0,  0,  1,  0,  0,  6,  6,  0,  0,  1 },
                    {  1,  0,  0,  6,  6,  0,  0,  1,  0,  0,  0,  1,  0,  0,  6,  6,  0,  0,  1,  1,  0,  1,  1,  0,  0,  0,  8,  8,  0,  8,  8,  0,  0,  0,  1,  1,  0,  0,  0,  0,  1,  1,  6,  6,224,222,  6,  6,  1,  0,151,  0,  1,  6,  6,224,222,  6,  6,  1 },
                    {  1,  6,  6,223,225,  6,  6,  1,  0,152,  0,  1,  6,  6,223,225,  6,  6,  1,  1,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  1,  0,  1,  1,  6,  6,222,222,  6,  6,  1,  0,  0,  0,  1,  6,  6,222,222,  6,  6,  1 },
                    {  1,  6,  6,223,223,  6,  6,  1,  0,  0,  0,  1,  6,  6,223,223,  6,  6,  1,  1,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  1,  0,  1,  1,  0,  0,  6,  6,  0,  0,  0,  1,  0,  1,  0,  0,  0,  6,  6,  0,  0,  1 },
                    {  1,  0,  0,  6,  6,  0,  0,  0,  1,  0,  1,  0,  0,  0,  6,  6,  0,  0,  1,  1,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  1,  1,  0,  1,  1,  0,  0,  6,  6,  0,  0,  0,  0,  0,  0,  0,  0,  0,  6,  6,  0,  0,  1 },
                    {  1,  0,  0,  6,  6,  0,  0,  0,  0,  0,  0,  0,  0,  0,  6,  6,  0,  0,139,139,  0,  0,  0,  0,  0,  1,  1,  1,  0,  1,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1 },
                    {  1,  0,  0,  0,  0,  0,  0,222,222,224,221,223,  0,  0,  0,  0,  0,  0,  1,  1,  0,223,  8,223,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,225,  0,  0,  0,  0,  0,140,140,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  0,  0,  0,  0,  0,221,222,222,223,223,  0,  0,  0,  0,  0,  0,  1,  1,  0,  8,225,  8,  0,  0,  0,  0,  0,  0,  0,  0,  0,225,  8,225,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,223,225,  0,  0,  0,  1,  0,221,  0,  0,  0,  1 },
                    {  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,225,  8,225,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,225,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,222,224,223,  0,  0,  0,  1,  0,  0,  1,  0,226,  1 },
                    {  1,  1,  1,  1,  1,  0,  0,  1,  1,  1,  1,  8,  8,  8,  8,  8,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,223,224,222,  0,  0,  0,  0,  1,  0,  0,  1,  0,  0,  1 },
                    {  1,  0,  0,  0,  1,  1,  1,  1,  0,  0,  1,  8,  8,  8,  8,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  0,138,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  0,225,223,  0,  0,  1,  1,  1,  1,  1,  1,  1,  0,  0,  1 },
                    {  1,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  1,  1,  1,  0,  0,  0,  0,  6,  6,  0,  0,  0,  0,  1,  1,138,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  1,  0,209,  0,  1,  0,  1,  9,  1,233,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  6,  6,  0,  1,177,  0,  0,  1,  0,  6,  0,  6,  0,  8,  8,  8,  0,  6,  0,  6,  0,  1,  1,  0,  0,  1,  1,  1,  0,  0,  0,  1,  1,  1,  0,  0,  1 },
                    {  1,  0,  1,  0,  0,  0,  1,  0,  1,  9,  0,  1,  1,  1,  0,223,  0,  0,  0,  0,  0,  6,  6,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  6,  0,  6,  8,221,  8,  6,  0,  6,  0,  0,  0,  1,  1,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  0,  1,  1,  1,  0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  6,  6,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  6,  0,  6,  0,  8,  8,  8,  0,  6,  0,  6,  0,  0,  1,  1,  1,  0,  0,  0,  1,  1,  1,  1,  0,  0,  0,  0,  1 },
                    {  1,  0,  8,  0,  0,  0,  8,  8,  1,  9,  1,  1,  0,  0,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  7,  1,  0,  6,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  1,  1,  1,  1,  1,  8,  1,  0,  1,  0,  0,221,  0,  1,  1,  1,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  0,  0,  0,  1,135,  1,  6,110,  6,  0,  0,  0,  0,  0,  0,  1,  1,  1 },
                    {  1,  0,  6,  0,  0,224,  1,  8,  1,  9,  1,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  1,  0,210,  0,  0,  1,  0,  8,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  1,  0,  6,  0,  0,  0,  1,  1,  1,  1,  0,  0,  1 },
                    {  1,  1,  1,  0,  1,  1,  1,  8,  1,  0,  1,  0,  0,  1,  1,  1,  0,  0,  0,  1,  0,  1,  0,  0,  0,  0,  1,  6,  0,  0,  0,  0,  6,  0,  0,  6,  0,  6,  8,  0,  9,  1,  1,222,  0,  0,  0,  1,  1,  1,  1,  1,  0,  1,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  6,  0,  1,  8,  8,  8,  1,  9,  1,  0,  0,  1,  0,  0,  1,  0,  0,  1,  0,  1,  1,  1,  1,  0,  1,  0,  8,  0,  0,  1,  1,  1,  1,  1,  1,  8,  8,  0,  0,  0,  1,  1,  1,  1,  0,  1,  0,  0,  0,  0,  0,  1,  1,  1,  0,  0,  0,  1 },
                    {  1,  0,  1,  1,  1,  8,  1,  1,  1,  0,  1,  0,  0,  1,  0,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  6,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,104,  0,  0,  0,  0,  1,  0,  1,136,  1,  1,  1,  1,  1,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  6,  0,  1,  8,  1,  0,  0,  6,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  1,  1,  1,  1,  1,  1,  1,  0,  8,  0,  1,  1,  1,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  1,  0,  0,  0,  0,  0,  1,  0,  8,212,  8,  0,  1 },
                    {  1,  1,  1,  0,  1,  8,  1,  6,  6,  0,  1,  0,  0,  1,  1,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  6,  0,  0,  1,  0,  0,  0,  0,  1,  0,  1,  1,  1,  0,  1,  0,  1,  0,  1,105,  1,  0,  1,  0,  0,  0,  1,  0,  0,  8,  0,  0,  1 },
                    {  1,  0,  0,  0,  1,  8,  1,  6,  6,  0,  1,  0,  0,  0,  0,  1,  0,  1,  1,  1,  0,  1,  1,  1,  0,  0,  1,  0,  8,  0,  1,  0,  1,  1,  1,  0,  0,134,211,  1,  0,  1,  0,  0,  0,  1,  0,  1,  0,  1,  1,  0,  0,  1,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  0,  6,  1,  6,  1,  6,  0,  6,  1,  0,  0,  0,  0,  1,  1,  1,222,  1,  1,  1,  0,  1,  0,  0,  1,  0,  0,  6,  1,  0,  1,  0,  0,  0,  8,  1,  1,  1,  0,  1,  1,  1,  0,  1,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  1,  0,  6,  0,  1,  0,  6,  6,  1,  0,  0,  9,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  1,  0,  1,  0,  0,  0,  1,  0,  1,  1,  1,  1 },
                    {  1,  0,  1,  6,  0,  6,  1,  0,  6,  6,  1,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  1,  0,223,  1,  8,  1,  0,  0,  0,  1,  0,  0,  0,  0,  1 },
                    {  1,  0,  1,  1,  1,  1,  1,  6,  0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  1,  1,  0,  0,  0,  6,  0,  1,  1,  1,  0,  0,  1 },
                    {  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  1,  0,  0,  0,  0,  0,  6,  0,  0,  0,  0,  1,106,  0,  1 },
                    {  1,109,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,108,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,223,  1 },
                    {  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1 } };
                    break;
                default: break;
            }
        }
        private void Med1_MediaFailed(object sender, ExceptionRoutedEventArgs e) { MessageBox(); }
        private void MessageBox() { throw new NotImplementedException(); }

        //[EN] Activate/Deactivate all .. | [RU] Активировать/Деактивировать все...
        //[EN] Chests+Tables/
        //[RU] Сундуки+Таблички/
        private void ChestsAndTablesAllTurnOn1() { ImgShowX(new Image[] { ChestImg1, ChestImg2, ChestImg3, ChestImg4, Table1, Table2, Table3 }); }
        private void ChestsAndTablesAllTurnOff1() { ImgHideX(new Image[] { ChestImg1, ChestImg2, ChestImg3, ChestImg4, Table1, Table2, Table3 }); }
        //[EN] keys/
        //[RU] ключи/
        private void Map1ModelsAllTurnOn1() { ImgShowX(new Image[] { KeyImg1, KeyImg2, KeyImg3, LockImg1, LockImg2, LockImg3 }); }
        private void Map1ModelsAllTurnOff1() { ImgHideX(new Image[] { LockImg1, LockImg2, LockImg3, KeyImg1, KeyImg2, KeyImg3 }); }

        //[EN] After game intro has been ended
        //[RU] После завершения пролога.
        private void Med1_MediaEnded(object sender, RoutedEventArgs e) { Img1.Source = Bmper(Path.Backgrounds.Normal); AnyShowX(Img1, ChapterIntroduction); AnyHideX(Med1, Skip1); HeyPlaySomething(Path.GameMusic.MainTheme); }
        private void CheckIfInteracted() { Image[] images = { ChestMessage1, TaskCompletedImg, PainImg }; foreach (Image image in images) if (image.IsEnabled) ImgHide(image); }
        //[EN] Complete tasks
        //[RU] Завершение задач.
        private void CollectKey(Image Key, Image Lock)
        {
            ImgHideX(new Image[] { Key, Lock });
            ImgShow(TaskCompletedImg);
            SEF(Path.GameSounds.DoorOpened);
            Sets.LockIndex--;
            Sets.EnemyRate++;
            Super1.MenuTask++;
        }
        private void PullTheLever(Image Lever, Image[] Imgs)
        {
            AnyShowX(Imgs);
            Lever.Source = Bmper(Path.MapModels.LeverOn);
            SEF(Path.GameSounds.DoorOpened);
        }
        private void HPenemyBARwidth(in double maxHp)
        {
            if (maxHp > 3500) { HPenemyBar.Width = HPenemyBar.Maximum / 16; HPenemyBar.Foreground= new SolidColorBrush(Color.FromRgb(0, 243, 255)); HPenemyBar.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 243, 255)); }
            else if (maxHp > 500) { HPenemyBar.Width = HPenemyBar.Maximum / 4; HPenemyBar.Foreground = new SolidColorBrush(Color.FromRgb(14, 222, 175)); HPenemyBar.BorderBrush = new SolidColorBrush(Color.FromRgb(14, 222, 175)); }
            else { HPenemyBar.Width = HPenemyBar.Maximum; HPenemyBar.Foreground = new SolidColorBrush(Color.FromRgb(50, 172, 40)); HPenemyBar.BorderBrush = new SolidColorBrush(Color.FromRgb(50, 172, 40)); }
        }
        //[EN] Target select mech
        //[RU] Механика выбора цели.
        private void InfoAboutEnemies()
        {
            Byte[,] grRowColumn = new Byte[,] { { 23, 15, 21 }, { 2, 13, 24 } };
            int[][] newHP = { new int[] { Foe1.Spider.EnemyMHP, Foe1.Mummy.EnemyMHP, Foe1.Zombie.EnemyMHP, Foe1.Bones.EnemyMHP, Foe1.BOSS1.EnemyMHP, Foe1.SecretBOSS1.EnemyMHP }, new int[] { Foe1.Vulture.EnemyMHP, Foe1.Ghoul.EnemyMHP, Foe1.GrimReaper.EnemyMHP, Foe1.Scarab.EnemyMHP, Foe1.BOSS2.EnemyMHP  } };
            Uri[][] EnemySource = new Uri[][] { new Uri[] { Ura(Path.FoesStatePath.SpiderIcon), Ura(Path.FoesStatePath.MummyIcon), Ura(Path.FoesStatePath.ZombieIcon), Ura(Path.FoesStatePath.BonesIcon), Ura(Path.BossesStatePath.PharaohIcon), Ura(Path.BossesStatePath.UghZanIcon) }, new Uri[] { Ura(Path.FoesStatePath.VultureIcon), Ura(Path.FoesStatePath.GhoulIcon), Ura(Path.FoesStatePath.GrimReaperIcon), Ura(Path.FoesStatePath.ScarabIcon), Ura(Path.BossesStatePath.WarriorIcon) } };
            for (int en = 0; en < Foe1.EnemyName[CurrentLocation].Length; en++)
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == Foe1.EnemyName[CurrentLocation][en])
                {
                    BattleText1.Content = Foe1.EnemyName[CurrentLocation][en];
                    HPenemyBar.Maximum = newHP[CurrentLocation][en];
                    HPenemyBARwidth(HPenemyBar.Maximum);
                    EnemyImg.Source = new BitmapImage(EnemySource[CurrentLocation][en]);
                    Grid.SetColumn(BattleText1, 17);
                    break;
                }
            ImgGrid(TrgtImg, ((Foe1.EnemyAppears[0] == "Фараон") || (Foe1.EnemyAppears[0] == "Угх-зан I") || (Foe1.EnemyAppears[0] == "????")) ? (byte)(grRowColumn[0, Sets.SelectedTarget] - 5) : grRowColumn[0, Sets.SelectedTarget], grRowColumn[1, Sets.SelectedTarget]);
            HPenemyBar.Value = Foe1.EnemyHP[Sets.SelectedTarget];
            HPenemy.Content = HPenemyBar.Value + "/" + HPenemyBar.Maximum;
            RefreshAllHP();
            LabShowX(new Label[] { HPenemy, BattleText1 });
        }
        private void SelectWithKeyBoard(bool Left)
        {
            if (Left)
            {
                if (Sets.SelectedTarget > 0)
                {
                    if (Foe1.EnemyHP[1] == 0) Sets.SelectedTarget = Convert.ToByte(Foe1.EnemyHP[0] != 0 ? Sets.SelectedTarget - 2 : Sets.SelectedTarget);
                    else if (Foe1.EnemyHP[0] == 0) Sets.SelectedTarget = Convert.ToByte(Sets.SelectedTarget > 1 ? Sets.SelectedTarget - 1 : Sets.SelectedTarget);
                    else Sets.SelectedTarget--;
                    InfoAboutEnemies();
                }
            }
            else
                if (Sets.SelectedTarget < Sets.Rnd1 - 1)
                {
                    if (Foe1.EnemyHP[1] == 0) Sets.SelectedTarget = Convert.ToByte(Foe1.EnemyHP[2] != 0 ? Sets.SelectedTarget + 2 : Sets.SelectedTarget);
                    else if (Foe1.EnemyHP[0] == 0) Sets.SelectedTarget = Convert.ToByte(Sets.SelectedTarget < 2 ? Sets.SelectedTarget + 1 : Sets.SelectedTarget);
                    else Sets.SelectedTarget++;
                    InfoAboutEnemies();
                }
        }
        private void BallRoll(object sender, EventArgs e)
        {
            Byte[] MapModel = CheckModelCoord(7);
            if ((MapModel[0] == Adoptation.ImgYbounds) && (MapModel[1] == Adoptation.ImgXbounds)) { ImgShow(PainImg); if (Super1.CurrentHP - 50 >= 0) Super1.CurrentHP -= 50; else { WonOrDied(); MediaShow(GameOver); } }
            ChangeMapToVoid(7);
            if (MapScheme[MapModel[0] + 1, MapModel[1]] != 1)
            {
                MapModel[0]++;
                ReplaceModel(MapModel[0], MapModel[1], 7);
                ImgGrid(Boulder1, MapModel[0], MapModel[1]);
                Boulder1.RenderTransform = new RotateTransform(45 * MapModel[0], 16, 15);
            }
            else { ImgHide(Boulder1); timer.Stop(); }
        }
        private void LetsBattle() { Sets.StepsToBattle--; Dj(Path.GameNoises.Danger); MediaShow(Med2); }
        private void WhatsGoingOn(in Byte SecretBattlesIndex) { MapScheme[Adoptation.ImgYbounds, Adoptation.ImgXbounds] = 0; Sets.SpecialBattle = SecretBattlesIndex; ImgShrink(TrgtImg, 475, 475); }
        private void GroundCheck(in Byte Interaction)
        {
            switch (Interaction)
            {
                case 0: break;
                case 6: Super1.CurrentHP--; ImgShow(PainImg); break;
                case 8: Super1.CurrentHP-=10; ImgShow(PainImg); break;
                case 9: Super1.CurrentHP-=25; ImgShow(PainImg); break;
                case 104: ChangeMapToVoidOrWallX(new Byte[] { 104, 134 }, 0); ImgHide(JailImg1); Sets.EnemyRate = 5; Super1.MenuTask++; break;
                case 105: ChangeMapToVoidOrWallX(new Byte[] { 105, 135 }, 0); ImgHideX((CurrentLocation == 1) ? new Image[] {  JailImg2, JailImg3 } : new Image[] { JailImg2 }); WidelyUsedAnyTimer(out timer, new EventHandler(BallRoll), new TimeSpan(0, 0, 0, 1)); break;
                case 106: ChangeMapToVoidOrWallX(new Byte[] { 106, 136 }, 0); ImgHide(JailImg5); if (CurrentLocation == 1) Super1.MenuTask++; break;
                case 107: ChangeMapToVoidOrWallX(new Byte[] { 107, 137 }, 0); ImgHide(JailImg6); break;
                case 108: ChangeMapToVoidOrWallX(new Byte[] { 108, 138 }, 0); ImgHide(JailImg7); break;
                case 150: if (DataBaseMSsql.CurrentLogin != "????") { SaveGame(); SEF(Path.GameSounds.ControlSave); } break;
                case 151: Super1.CurrentHP = Super1.MaxHP; Dj(Path.GameNoises.Cure); break;
                case 152: Super1.CurrentAP = Super1.MaxAP; Dj(Path.GameNoises.Cure); break;
                case 191: WhatsGoingOn(200); LetsBattle(); break;
                case 192: ChangeMapToVoid(192); PlayerSetLocation(1,57); break;
                default: break;
            }
        }
        private Byte Bits(Object obj) { return Convert.ToByte(obj); }
        private Int32 Numb(Object obj) { return Convert.ToInt32(obj); }
        private UInt16 Shrt(Object obj) { return Convert.ToUInt16(obj); }
        private Byte ColMgs(in Image img) { return Numb(img.GetValue(Grid.ColumnProperty)) - 5 > 0 ? Bits(Bits(img.GetValue(Grid.ColumnProperty)) - 5) : Bits(0); }
        private Byte RowMgs(in Image img) { return Numb(img.GetValue(Grid.RowProperty)) - 8 > 0 ? Bits(Bits(img.GetValue(Grid.RowProperty)) - 8) : Bits(0); }
        private Byte CheckGuy()
        {
            String[] Direction = { Path.Ray.StaticRight, Path.Ray.GoRight, Path.Ray.StaticDown, Path.Ray.GoDown1, Path.Ray.GoDown2, Path.Ray.StaticLeft, Path.Ray.GoLeft, Path.Ray.StaticUp, Path.Ray.GoUp1, Path.Ray.GoUp2 };
            SByte[,] Dir1 = { { 0, 0, 1, 1, 1, 0, 0, -1, -1, -1 }, { 1, 1, 0, 0, 0, -1, -1, 0, 0, 0 } };
            for (Byte i = 0; i < Direction.Length; i++) if (Img2.Source.ToString().Contains(Direction[i])) return MapScheme[Adoptation.ImgYbounds + Dir1[0, i], Adoptation.ImgXbounds + Dir1[1, i]];
            return 0;
        }
        private void TablesSetInfo()
        {
            if (Sets.TableEN || TableMessage1.IsEnabled) ImgHide(TableMessage1);
            Sets.TableEN = !Sets.TableEN && !TableMessage1.IsEnabled;
            Byte Interaction = CheckGuy();
            Byte[] Conditions = { 171, 172, 173, 174, 175, 176, 177, 178, 179 };
            BitmapImage[] images = BmpersToX(Bmper(Path.Msg.Tb1_Msg1), Bmper(Path.Msg.Tb2_Msg1), Bmper(Path.Msg.Tb3_Msg1), Bmper(Path.Msg.Tb1_Msg2), Bmper(Path.Msg.Tb2_Msg2), Bmper(Path.Msg.Tb3_Msg2), Bmper(Path.Msg.Tb1_Msg3), Bmper(Path.Msg.Tb2_Msg3), Bmper(Path.Msg.Tb3_Msg3));
            Image[] Mess = { Table1, Table2, Table3, Table1, Table2, Table3, Table1, Table2, Table3 };
            for (Byte i = 0; i < Conditions.Length; i++) if (Interaction == Conditions[i]) SetTablesMessage(images[i], RowMgs(Mess[i]), ColMgs(Mess[i]));
        }
        private void SetTablesMessage(BitmapImage image, Byte X, Byte Y)
        {
            TableMessage1.Source = image;
            if (!Sets.TableEN) Sets.TableEN = true;
            ImgGrid(TableMessage1, X, Y);
            ImgShow(TableMessage1);
        }
        private void MaxAndWidthHPcalculate()
        {
            if (Super1.MaxHP >= 666)
            {
                HPbar.Maximum = 333;
                HPbar.Width = HPbar.Maximum;
                HPbarOver333.Maximum = 333;
                HPbarOver333.Width = HPbarOver333.Maximum;
                HPbarOver666.Maximum = Super1.MaxHP - 666;
                HPbarOver666.Width = HPbarOver666.Maximum;
            }
            else if (Super1.MaxHP >= 333)
            {
                HPbar.Maximum = 333;
                HPbar.Width = HPbar.Maximum;
                HPbarOver333.Maximum = Super1.MaxHP - 333;
                HPbarOver333.Width = HPbarOver333.Maximum;
            }
            else
            {
                HPbar.Maximum = Super1.MaxHP;
                HPbar.Width = HPbar.Maximum;
            }
        }
        private void MaxAndWidthAPcalculate()
        {
            if (Super1.MaxAP > 666)
            {
                APbar.Maximum = 333;
                APbar.Width = APbar.Maximum;
                APbarOver333.Maximum = 333;
                APbarOver333.Width = APbarOver333.Maximum;
                APbarOver666.Maximum = Super1.MaxAP - 666;
                APbarOver666.Width = APbarOver666.Maximum;
            }
            else if (Super1.MaxAP > 333)
            {
                APbar.Maximum = 333;
                APbar.Width = APbar.Maximum;
                APbarOver333.Maximum = Super1.MaxAP - 333;
                APbarOver333.Width = APbarOver333.Maximum;
            }
            else
            {
                APbar.Maximum = Super1.MaxAP;
                APbar.Width = APbar.Maximum;
            }
        }

        private void CurrentHPcalculate()
        {
            if (Super1.CurrentHP > 666)
            {
                if (!HPbarOver666.IsEnabled) BarShow(HPbarOver666);
                HPbar.Value = HPbar.Maximum;
                HPbarOver333.Value = HPbarOver333.Maximum;
                HPbarOver666.Value = Super1.CurrentHP - 666;
            }
            else if (Super1.CurrentHP > 333)
            {
                if (HPbarOver666.IsEnabled) BarHide(HPbarOver666);
                if (!HPbarOver333.IsEnabled) BarShow(HPbarOver333);
                HPbarOver666.Value = 0;
                HPbarOver333.Value = Super1.CurrentHP - 333;
                HPbar.Value = HPbar.Maximum;
            }
            else
            {
                if (HPbarOver666.IsEnabled) BarHide(HPbarOver666);
                if (HPbarOver333.IsEnabled) BarHide(HPbarOver333);
                HPbarOver666.Value = 0;
                HPbarOver333.Value = 0;
                HPbar.Value = Super1.CurrentHP;
            }
            RefreshAllHP();
        }

        private void CurrentAPcalculate()
        {
            if (Super1.CurrentAP > 666)
            {
                if (!APbarOver666.IsEnabled) BarShow(APbarOver666);
                APbar.Value = APbar.Maximum;
                APbarOver333.Value = APbarOver333.Maximum;
                APbarOver666.Value = Super1.CurrentAP - 666;
            }
            else if (Super1.CurrentAP > 333)
            {
                if (APbarOver666.IsEnabled) BarHide(APbarOver666);
                if (!APbarOver333.IsEnabled) BarShow(APbarOver333);
                APbar.Value = APbar.Maximum;
                APbarOver666.Value = 0;
                APbarOver333.Value = Super1.CurrentAP - 333;
                APbar.Value = APbar.Maximum;
            }
            else
            {
                if (APbarOver666.IsEnabled) BarHide(APbarOver666);
                if (APbarOver333.IsEnabled) BarHide(APbarOver333);
                APbarOver666.Value = 0;
                APbarOver333.Value = 0;
                APbar.Value = Super1.CurrentAP;
            }
            RefreshAllAP();
        }
        private void CurrentHpApCalculate() { CurrentHPcalculate(); CurrentAPcalculate(); }
        private void GetPoisoned()
        {
            if (Super1.PlayerStatus == 1) Super1.CurrentHP--;
            if (Super1.CurrentHP <= 0)
            {
                Super1.PlayerStatus = 0;
                ImgHideX(new Image[] { Img2, Menu1 });
                MegaHide();
                Sound1.Stop();
                Sound2.Stop();
                Sound3.Stop();
                MediaShow(GameOver);
                timer.Stop();
                timer2.Stop();
            }
        }
        private void Movement(in Boolean LeftRightOrUpDown, in BitmapImage bmp, in Byte rowcolumn)
        {
            Img2.Source = bmp;
            Adoptation.SetBounds(LeftRightOrUpDown, rowcolumn);
            PlayerSetLocation(Convert.ToByte(Adoptation.ImgYbounds), Convert.ToByte(Adoptation.ImgXbounds));
            GroundCheck(MapScheme[Adoptation.ImgYbounds, Adoptation.ImgXbounds]);
            TablesSetInfo();
            //if (Sets.StepsToBattle >= rnd) { ImgHideX(new Image[] { Img2, PainImg }); Sound1.Stop(); Dj(Path.GameNoises.Danger); MediaShow(Med2); }
            //Sets.StepsToBattle++;
            GetPoisoned();
        }
        private void SomeRudeAppears(in Byte BattleIndex, in EventHandler Event, in string Noise)
        {
            ImgShrink(TrgtImg, 475, 475);
            Sets.SpecialBattle = BattleIndex;
            Img2.IsEnabled = false;
            Sound1.Stop();
            WidelyUsedAnyTimer(out BossAppear1, Event, new TimeSpan(0, 0, 0, 0, 20));
            Dj(Noise);
        }
        private void GetSecretReward() { Exp += 250; Mat += 250; Super1.MiniTask = true; ShowAfterBattleMenu(); }
        private Boolean IsWallNext(Byte map)
        {
            switch (map)
            {
                case 0: case 6: case 7: case 8: case 9: case 104: case 105: case 106: case 107: case 111: case 112: case 113: case 114: case 115: case 116: case 117: case 118: case 119: case 120: case 150: case 151:
                case 152: case 191: case 192: return true;
                default: return false;
            }
        }
        //[EN] Movement (W,A,S,D), actions on map (E), open menu (LCtrl), target select in fight (W,A,S,D)
        //[RU] Передвижение (W,A,S,D), действия при нахождении на локации (E), открыть меню (LCtrl), выбор цели (W,A,S,D)
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            CheckIfInteracted();
            if (Img2.IsEnabled)
            {
                Sets.Rnd1 = 0;
                Sets.SelectedTarget = 0;
                if (e.Key == Key.W) Movement(true, Img2.Source.ToString().Contains(Path.Ray.GoUp1) ? Bmper(Path.Ray.GoUp2) : Bmper(Path.Ray.GoUp1), IsWallNext(MapScheme[Adoptation.ImgYbounds - 1, Adoptation.ImgXbounds]) ? Bits(Adoptation.ImgYbounds - 1) : Bits(Adoptation.ImgYbounds));
                if (e.Key == Key.A) Movement(false, Img2.Source.ToString().Contains(Path.Ray.StaticLeft) ? Bmper(Path.Ray.GoLeft) : Bmper(Path.Ray.StaticLeft), IsWallNext(MapScheme[Adoptation.ImgYbounds, Adoptation.ImgXbounds - 1]) ? Bits(Adoptation.ImgXbounds - 1) : Bits(Adoptation.ImgXbounds));
                if (e.Key == Key.S) Movement(true, Img2.Source.ToString().Contains(Path.Ray.GoDown1) ? Bmper(Path.Ray.GoDown2) : Bmper(Path.Ray.GoDown1), IsWallNext(MapScheme[Adoptation.ImgYbounds + 1, Adoptation.ImgXbounds]) ? Bits(Adoptation.ImgYbounds + 1) : Bits(Adoptation.ImgYbounds));
                if (e.Key == Key.D) Movement(false, Img2.Source.ToString().Contains(Path.Ray.StaticRight) ? Bmper(Path.Ray.GoRight) : Bmper(Path.Ray.StaticRight), IsWallNext(MapScheme[Adoptation.ImgYbounds, Adoptation.ImgXbounds + 1]) ? Bits(Adoptation.ImgXbounds + 1) : Bits(Adoptation.ImgXbounds));
                if (e.Key == Key.E)
                {
                    string[] ChestOp = { Path.MapModels.ChestOpened1, Path.MapModels.ChestOpened2, Path.MapModels.ChestOpened3 };
                    string[,] EquipmentAll = new string[,] { { Path.Msg.Knucleduster, Path.Msg.LeatherArmor, Path.Msg.FeatherWears, Path.Msg.BandageBoots }, { Path.Msg.AncientKnife, Path.Msg.AncientArmor, Path.Msg.AncientPants, Path.Msg.StrongBoots }, { Path.Msg.LegendSword, Path.Msg.LegendArmor, Path.Msg.LegendPants, Path.Msg.LegendBoots } };
                    Int32[] LocItem = new Int32[] { Img2.Source.ToString().Contains(Path.Ray.StaticDown) ? Adoptation.ImgYbounds + 1 : (Img2.Source.ToString().Contains(Path.Ray.StaticUp) ? Adoptation.ImgYbounds - 1 : Adoptation.ImgYbounds), Img2.Source.ToString().Contains(Path.Ray.StaticRight) ? Adoptation.ImgXbounds + 1 : (Img2.Source.ToString().Contains(Path.Ray.StaticLeft) ? Adoptation.ImgXbounds - 1 : Adoptation.ImgXbounds) };
                    Byte Interaction = MapScheme[LocItem[0], LocItem[1]];
                    switch (Interaction)
                    {
                        case 101: ImgGrid(TaskCompletedImg, 28,  0); CollectKey(KeyImg1, LockImg1); ChangeMapToVoidOrWallX(new Byte[] { 101, 131 }, 0); break;
                        case 102: ImgGrid(TaskCompletedImg, 16, 18); CollectKey(KeyImg2, LockImg2); ChangeMapToVoidOrWallX(new Byte[] { 102, 132 }, 0); break;
                        case 103: ImgGrid(TaskCompletedImg, 28, 39); CollectKey(KeyImg3, LockImg3); ChangeMapToVoidOrWallX(new Byte[] { 103, 133 }, 0); break;
                        case 108: ImgGrid(TaskCompletedImg, 28, 39); PullTheLever(Lever1, new Image[] { Bridge1, Bridge2, Bridge3, Bridge4 }); ChangeMapToWall(108); ChangeMapToVoid(138); Super1.MenuTask++; break;
                        case 109: ImgGrid(TaskCompletedImg, 28, 39); PullTheLever(Lever2, new Image[] { Bridge5, Bridge6 }); ChangeMapToWall(109); ChangeMapToVoid(139); break;
                        case 110: ImgGrid(TaskCompletedImg, 28, 39); PullTheLever(Lever3, new Image[] { Bridge7, Bridge8 }); ChangeMapToWall(110); ChangeMapToVoid(140); break;
                        case 161: SomeRudeAppears(1, PharaohAppear_Time51, Path.GameNoises.Horror); break;
                        case 162: SomeRudeAppears(2, AncientAppear_Time52, Path.GameNoises.EgoRage); break;
                        case 163: break;
                        case 201: ChestOpen(ChestImg1, Bmper(EquipmentAll[CurrentLocation, 1]), Bmper(ChestOp[CurrentLocation]), 1, CurrentLocation); break;
                        case 202: ChestOpen(ChestImg2, Bmper(EquipmentAll[CurrentLocation, 3]), Bmper(ChestOp[CurrentLocation]), 3, CurrentLocation); break;
                        case 203: ChestOpen(ChestImg3, Bmper(EquipmentAll[CurrentLocation, 0]), Bmper(ChestOp[CurrentLocation]), 0, CurrentLocation); break;
                        case 204: ChestOpen(ChestImg4, Bmper(EquipmentAll[CurrentLocation, 2]), Bmper(ChestOp[CurrentLocation]), 2, CurrentLocation); break;
                        case 205: ChestOpen(ChestImg4, Bmper(EquipmentAll[CurrentLocation, 2]), Bmper(ChestOp[CurrentLocation]), 2, CurrentLocation); break;
                        case 206: ChestOpen(ChestImg3, Bmper(EquipmentAll[CurrentLocation, 0]), Bmper(ChestOp[CurrentLocation]), 0, CurrentLocation); break;
                        case 207: ChestOpen(ChestImg2, Bmper(EquipmentAll[CurrentLocation, 3]), Bmper(ChestOp[CurrentLocation]), 3, CurrentLocation); break;
                        case 208: ChestOpen(ChestImg1, Bmper(EquipmentAll[CurrentLocation, 1]), Bmper(ChestOp[CurrentLocation]), 1, CurrentLocation); break;
                        case 209: ChestOpen(ChestImg1, Bmper(EquipmentAll[CurrentLocation, 0]), Bmper(ChestOp[CurrentLocation]), 0, CurrentLocation); break;
                        case 210: ChestOpen(ChestImg2, Bmper(EquipmentAll[CurrentLocation, 1]), Bmper(ChestOp[CurrentLocation]), 1, CurrentLocation); break;
                        case 211: ChestOpen(ChestImg3, Bmper(EquipmentAll[CurrentLocation, 2]), Bmper(ChestOp[CurrentLocation]), 2, CurrentLocation); break;
                        case 212: ChestOpen(ChestImg4, Bmper(EquipmentAll[CurrentLocation, 3]), Bmper(ChestOp[CurrentLocation]), 3, CurrentLocation); break;
                        case 213: ChestOpen(SecretChestImg1, Bmper(Path.Msg.SeriousPants), Bmper(ChestOp[CurrentLocation]), 2, 3); break;
                        case 221: ChangeMapToVoid(Bits(LocItem[0]), Bits(LocItem[1]), SpDmg1, SpDmg2, SpDmg3, SpDmg4, SpDmg5); Super1.CurrentHP -= 50; ImgShow(PainImg); break;
                        case 222: ChangeMapToVoid(Bits(LocItem[0]), Bits(LocItem[1]), SpHrb1, SpHrb2, SpHrb3, SpHrb4, SpHrb5, SpHrb6, SpHrb7, SpHrb8, SpHrb9, SpHrb10, SpHrb11, SpHrb12, SpHrb13, SpHrb14); if (BAG.HerbsITM < 255) BAG.HerbsITM++; break;
                        case 223: ChangeMapToVoid(Bits(LocItem[0]), Bits(LocItem[1]), SpEtr1, SpEtr2, SpEtr3, SpEtr4, SpEtr5, SpEtr6, SpEtr7, SpEtr8, SpEtr9, SpEtr10, SpEtr11, SpEtr12, SpEtr13, SpEtr14, SpEtr15, SpEtr16, SpEtr17, SpEtr18); if (BAG.Ether2ITM < 255) BAG.Ether2ITM++; break;
                        case 224: ChangeMapToVoid(Bits(LocItem[0]), Bits(LocItem[1]), SpElx1, SpElx2, SpElx3, SpElx4, SpElx5, SpElx6); if (BAG.ElixirITM < 255) BAG.ElixirITM++; break;
                        case 225: ChangeMapToVoid(Bits(LocItem[0]), Bits(LocItem[1]), SpSbg1, SpSbg2, SpSbg3, SpSbg4, SpSbg5, SpSbg6, SpSbg7, SpSbg8, SpSbg9, SpSbg10, SpSbg11); if (BAG.SleepBagITM<255) BAG.SleepBagITM++; break;
                        case 226: ChangeMapToVoid(Bits(LocItem[0]), Bits(LocItem[1]), SpSer); BAG.Weapon[3] = true; break;
                        case 232: ChestOpen(SecretChestImg2, Bmper(Path.Msg.Completed), Bmper(ChestOp[CurrentLocation]), 2, 3); GetSecretReward(); break;
                        case 233: GetSecretReward(); break;
                        default: break;
                    }
                }
            }
            else
                if (Fight.IsEnabled || ACT1.IsEnabled || ACT2.IsEnabled || ACT3.IsEnabled) if (e.Key == Key.W || e.Key == Key.A || e.Key == Key.S || e.Key == Key.D) SelectWithKeyBoard(e.Key == Key.W || e.Key == Key.A);
            if (e.Key == Key.LeftCtrl)
                if (Img2.IsEnabled)
                    if (!Menu1.IsEnabled)
                    {
                        if (Sets.TableEN) ImgHide(TableMessage1);
                        Sets.TableEN = !Sets.TableEN;
                        HeroStatus();
                    }
                    else
                    {
                        MegaHide();
                        AnyHideX(Menu1, Status, Abils, Items0, Equip, Tasks, Info, Settings);
                        AnyShowX(Img2, Img1);
                    }
            if (e.Key == Key.Escape) Form1.Close();
        }
        private void ChestOpen(Image Chest, in BitmapImage Message, in BitmapImage ChestOpened, in Byte Class, in Byte Quality)
        {
            ImgShow(ChestMessage1);
            ChestMessage1.Source = Message;
            Chest.Source = ChestOpened;
            switch (Class)
            {
                case 0: BAG.Hands = Super1.PlayerEQ[Class] == 0; BAG.Weapon[Quality] = true; break;
                case 1: BAG.Jacket = Super1.PlayerEQ[Class] == 0; BAG.Armor[Quality] = true; break;
                case 2: BAG.Legs = Super1.PlayerEQ[Class] == 0; BAG.Pants[Quality] = true; break;
                case 3: BAG.Boots = Super1.PlayerEQ[Class] == 0; BAG.ArmBoots[Quality] = true; break;
                default: break;
            }
            SEF(Path.GameSounds.ChestOpened);
            ImgGrid(ChestMessage1, Convert.ToByte(Convert.ToByte(Chest.GetValue(Grid.RowProperty)) - 5), Convert.ToByte(Convert.ToByte(Chest.GetValue(Grid.ColumnProperty)) - 3));
        }
        private void PharaohAppear_Time51(object sender, EventArgs e)
        {
            if (!PharaohAppears.IsEnabled) ImgShow(PharaohAppears);
            if (PharaohAppears.Opacity < 1) PharaohAppears.Opacity += 0.01;
            else
            {
                if ((byte)((Int32)PharaohAppears.GetValue(Grid.RowProperty) - 1) < 6)
                {
                    LetsBattle();
                    BossAppear1.Stop();
                }
                ImgGrid(PharaohAppears, (byte)((Int32)PharaohAppears.GetValue(Grid.RowProperty) - 1), (byte)(Int32)(PharaohAppears.GetValue(Grid.ColumnProperty)));
            }
        }
        public static Byte Appearance = 0;
        private void AncientAppear_Time52(object sender, EventArgs e)
        {
            if (!Ancient.IsEnabled) AnyShow(Ancient);
            if (Ancient.Opacity < 1) Ancient.Opacity += 0.25;
            else
            {
                if (!Warrior.IsEnabled) AnyShow(Warrior);
                if (Appearance < Path.AniModel.Ancient.Length) AncientAppear_Phase1(Appearance);
                if (Appearance < 2) AncientAppear_Phase2(Appearance);
                else if ((Int32)Warrior.GetValue(Grid.ColumnProperty)<5) AncientAppear_Phase3();
                else { ImgGrid(Warrior, (byte)((Int32)Warrior.GetValue(Grid.RowProperty)), (byte)((Int32)Warrior.GetValue(Grid.ColumnProperty) - 1)); BossAppear1.Stop(); LetsBattle(); }
                Appearance++;
            }
        }
        private void AncientAppear_Phase1(in Byte App) { Ancient.Source = Bmper(Path.AniModel.Ancient[App]); }
        private void AncientAppear_Phase2(in Byte App) { Warrior.Source = Bmper(Path.AniModel.Warrior[App]); }
        private void AncientAppear_Phase3() { ImgGrid(Warrior, (byte)((Int32)Warrior.GetValue(Grid.RowProperty)), (byte)((Int32)Warrior.GetValue(Grid.ColumnProperty)+1)); }
        private void StatusCalculate() { StatsMeaning(); MenuHpApExp(); }
        private void FastTextChange(Label[] Labs, in String[] texts) { for (Byte i = 0; i < Labs.Length; i++) Labs[i].Content = texts[i]; }
        private void HeroStatus()
        {
            StatusCalculate();
            AnyShowX(Menu1, Img2, Img1, Icon0, EquipHImg, EquipBImg, EquipLImg, EquipDImg, ATKImg, DEFImg, AGImg, SPImg, HPbar1, APbar1, ExpBar1, Name0, Level0, StatusP, Exp1, HPtext1, APtext1, HP1, AP1, Describe1, Describe2, Params, ParamsATK, ParamsDEF, ParamsAG, ParamsSP, EquipText, ATK1, DEF1, AG1, SP1, EquipH, EquipB, EquipL, EquipD, DescribeHeader, Describe1);
            AnyGridX(new Object[] { HPbar1, APbar1, StatusP, HPtext1, APtext1 }, new Byte[] { 7, 9, 2, 7, 9 }, new Byte[] { 11, 11, 14, 2, 2 });
            LabGridX(new Label[] { HP1, AP1, Exp1 }, new byte[] { Convert.ToByte(HPbar1.GetValue(Grid.RowProperty)), Convert.ToByte(APbar1.GetValue(Grid.RowProperty)), Convert.ToByte(ExpBar1.GetValue(Grid.RowProperty)) }, new byte[] { Convert.ToByte(Convert.ToInt32(HPbar1.GetValue(Grid.ColumnProperty)) + 1 + (Convert.ToInt32(HPbar1.Width) / 32)), Convert.ToByte(Convert.ToInt32(APbar1.GetValue(Grid.ColumnProperty)) + 1 + (Convert.ToInt32(APbar1.Width) / 32)), Convert.ToByte(Convert.ToInt32(ExpBar1.GetValue(Grid.ColumnProperty)) + 1 + (Convert.ToInt32(ExpBar1.Width) / 32)) });
            RightPanelMenuTurnON();
            if (!TimerTurnOn.IsChecked.Value) LabShow(TimeRecordText);
            PlayerSetLocation(Convert.ToByte(Adoptation.ImgYbounds), Convert.ToByte(Adoptation.ImgXbounds));
            Status.IsEnabled = false;
            FastTextChange(new Label[] { Describe1, Describe2 }, new String[] { "ОЗ имеет тенденцию падать до 0. Враги только этого и добиваются.\nПохоже им уже давно пора задать трёпку.", "Статус героя" });
        }
        private void ImgShowX(in Image[] ImagesArray) { foreach (Image img in ImagesArray) ImgShow(img); }
        private void LabShowX(in Label[] LabelArray) { foreach (Label Lab in LabelArray) LabShow(Lab); }
        private void BarShowX(in ProgressBar[] ProgressBarArray) { foreach (ProgressBar Bar in ProgressBarArray) BarShow(Bar); }
        private void BtnShowX(in Button[] ButtonArray) { foreach (Button Btn in ButtonArray) ButtonShow(Btn); }
        private void ImgGridX(in Image[] ImageArray, in Byte[] rows, in Byte[] cols) { for (Byte i = 0; i < ImageArray.Length; i++) ImgGrid(ImageArray[i], rows[i], cols[i]); }
        private void LabGridX(in Label[] LabelArray, in Byte[] rows, in Byte[] cols) { for (Byte i = 0; i < LabelArray.Length; i++) LabGrid(LabelArray[i], rows[i], cols[i]); }
        private void BarGridX(in ProgressBar[] ProgressBarArray, in Byte[] rows, in Byte[] cols) { for (Byte i = 0; i < ProgressBarArray.Length; i++) BarGrid(ProgressBarArray[i], rows[i], cols[i]); }
        private void LabHideX(Label[] LabelArray) { foreach (Label Lab in LabelArray) LabHide(Lab); }
        private void ImgHideX(Image[] ImageArray) { foreach (Image Img in ImageArray) ImgHide(Img); }
        private void MegaHide()
        {
            AnyHideX(InfoText1, InfoText2, InfoText3, MusicLoud, SoundsLoud, NoiseLoud, GameSpeed, Brightness, TimerTurnOn, DescribeHeader,
                MusicText, SoundsText, NoiseText, GameSpeedText, BrightnessText, MusicPercent, SoundsPercent, NoisePercent, BrightnessPercent, GameSpeedX,
                TimeRecordText, HerbsText, Ether2OutText, SleepBagText, ElixirText, Icon0, EquipHImg, EquipBImg, EquipLImg, EquipDImg, ATKImg, DEFImg, AGImg,
                SPImg, Task1Img, Task2Img, Task3Img, Task4Img, MaterialsCraftImg, HPbar1, APbar1, ExpBar1, Name0, StatusP, Exp1, HPtext1, APtext1, HP1, AP1,
                Describe1, Describe2, Params, ParamsATK, ParamsDEF, ParamsAG, ParamsSP, EquipText, ATK1, DEF1, AG1, SP1, EquipH, EquipB, EquipL, EquipD,
                AbilsCost, HealCost, CountText, CostText, FightSkills, MiscSkills, Task1, Task2, Task3, Task4, InfoHeaderText1, InfoHeaderText2, InfoHeaderText3,
                InfoIndex, Level0, AntidoteText, EtherText, BandageText, FusedText, MaterialsCraft, Ether1, Bandage, Antidote, Cure1, Fused, Equip1, Equip2,
                Equip3, Equip4, Remove1, Remove2, Remove3, Remove4, Equipments, CancelEq, InfoIndexPlus, InfoIndexMinus, CraftSwitch, CraftAntidote,
                CraftBandage, CraftFused, CraftEther, Torch1, Whip1, Super0, Heal1, Cure2Out, Torch1, Whip1, Thrower1, Super0, Tornado1, Quake1, Learn1,
                BuffUp1, ToughenUp1, Regen1, Control1, Herbs1, Ether2Out, SleepBag1, Elixir1, CraftBedbag, CraftElixir, CraftHerbs, CraftPerfboots, CraftEther2);
        }

        public static Byte[] EnemyNamesFight = new Byte[] { 0, 0, 0, 0 };
        public static UInt16 Mat = 0;

        private void EnemiesTotal(in Byte num, in string EnemyKind, in Byte CountEnemy)
        {
            switch (EnemyNamesFight[num])
            {
                case 1: BattleText3.Content = EnemyKind + ": " + CountEnemy; LabShow(BattleText3); break;
                case 2: BattleText4.Content = EnemyKind + ": " + CountEnemy; LabShow(BattleText4); break;
                case 3: BattleText5.Content = EnemyKind + ": " + CountEnemy; LabShow(BattleText5); break;
                default: break;
            }
        }
        private void FoesCalculate(in Byte InBattle, in Byte FoeIndex, in Byte Exper, in Byte Mater, in Byte ItemDrop)
        {
            Image[] Enemies = { Img6, Img7, Img8 };
            UInt16[][] EnHP = { new UInt16[] { Foe1.Spider.EnemyMHP, Foe1.Mummy.EnemyMHP, Foe1.Zombie.EnemyMHP, Foe1.Bones.EnemyMHP, Foe1.BOSS1.EnemyMHP, Foe1.SecretBOSS1.EnemyMHP }, new UInt16[] { Foe1.Vulture.EnemyMHP, Foe1.Ghoul.EnemyMHP, Foe1.GrimReaper.EnemyMHP, Foe1.Scarab.EnemyMHP } };
            Uri[,] RegularEnemiesImg = new Uri[,] { { new Uri(@Path.FoesStatePath.Spider, UriKind.RelativeOrAbsolute), new Uri(@Path.FoesStatePath.Mummy, UriKind.RelativeOrAbsolute), new Uri(@Path.FoesStatePath.Zombie, UriKind.RelativeOrAbsolute), new Uri(@Path.FoesStatePath.Bones, UriKind.RelativeOrAbsolute) }, { new Uri(@Path.FoesStatePath.Vulture, UriKind.RelativeOrAbsolute), new Uri(@Path.FoesStatePath.Ghoul, UriKind.RelativeOrAbsolute), new Uri(@Path.FoesStatePath.GrimReaper, UriKind.RelativeOrAbsolute), new Uri(@Path.FoesStatePath.Scarab, UriKind.RelativeOrAbsolute) } };
                for (Byte i = 0; i < Enemies.Length; i++)
                    if (InBattle - 1 == i)
                    {
                        Foe1.EnemyHP[i] = EnHP[CurrentLocation][FoeIndex];
                        Enemies[i].Source = new BitmapImage(RegularEnemiesImg[CurrentLocation, FoeIndex]);
                        Foe1.EnemyAppears[i] = FoesNames.GetByIndexes[CurrentLocation, FoeIndex];
                        break;
                    }
                Exp += Exper;
                Mat += Mater;
                switch (FoeIndex)
                {
                    case 0: Sets.FoeType1Alive += 1; break;
                    case 1: Sets.FoeType2Alive += 1; break;
                    case 2: Sets.FoeType3Alive += 1; break;
                    case 3: Sets.FoeType4Alive += 1; break;
                    default: Sets.FoeType1Alive += 1; break;
                }
                Sets.ItemsDropRate[ItemDrop] += 1;
        }
        private void SmartEnemyLabels(in Byte Index)
        {
            List<Byte> msp = new List<byte>();
            Byte[] Mapawe = { 0, 1, 2, 3 };
            foreach (Byte i in Mapawe) if (i != Index) msp.Add(i);
            if (EnemyNamesFight[Index] == 0) EnemyNamesFight[Index] = Convert.ToByte((EnemyNamesFight[msp[0]] != 1) && (EnemyNamesFight[msp[1]] != 1) && (EnemyNamesFight[msp[2]] != 1)? 1 : (EnemyNamesFight[msp[0]] != 2) && (EnemyNamesFight[msp[1]] != 2) && (EnemyNamesFight[msp[2]] != 2)? 2 : 3);
        }
        private void RegularBattle()
        {
            CalculateBattleStatus();
            Byte[][] Mat = { new Byte[] { Foe1.Spider.Materials, Foe1.Mummy.Materials, Foe1.Zombie.Materials, Foe1.Bones.Materials, Foe1.BOSS1.Materials, Foe1.SecretBOSS1.Materials }, new Byte[] { Foe1.Vulture.Materials, Foe1.Ghoul.Materials, Foe1.GrimReaper.Materials, Foe1.Scarab.Materials } };
            Byte[][] XP = { new Byte[] { Foe1.Spider.Experience, Foe1.Mummy.Experience, Foe1.Zombie.Experience, Foe1.Bones.Experience, Foe1.BOSS1.Experience, Foe1.SecretBOSS1.Experience }, new Byte[] { Foe1.Vulture.Experience, Foe1.Ghoul.Experience, Foe1.GrimReaper.Experience, Foe1.Scarab.Experience } };
            Byte[][] DrRt = { new Byte[] { Foe1.Spider.DropRate, Foe1.Mummy.DropRate, Foe1.Zombie.DropRate, Foe1.Bones.DropRate, Foe1.BOSS1.DropRate, Foe1.SecretBOSS1.DropRate }, new Byte[] { Foe1.Vulture.DropRate, Foe1.Ghoul.DropRate, Foe1.GrimReaper.DropRate, Foe1.Scarab.DropRate } };
            HeyPlaySomething(Path.GameMusic.FoesChase);

            Sets.StepsToBattle = 0;
            rnd = Random1.Next(5, 20);

            if (Sets.SpecialBattle == 0)
            {
                Sets.Rnd1 = Random1.Next(1, 4);
                Foe1.EnemiesStillAlive = (byte)Sets.Rnd1;
                for (Byte ib = 1; ib <= Sets.Rnd1; ib++)
                {
                    Sets.Rnd2 = Random1.Next(1, Sets.EnemyRate);
                    FoesCalculate(ib, Convert.ToByte(Sets.Rnd2 - 1), XP[CurrentLocation][Sets.Rnd2 - 1], Mat[CurrentLocation][Sets.Rnd2 - 1], DrRt[CurrentLocation][Sets.Rnd2 - 1]);
                    SmartEnemyLabels(Convert.ToByte(Sets.Rnd2 - 1));
                }
                EnemiesTotal(0, Foe1.EnemyName[CurrentLocation][0], Sets.FoeType1Alive);
                EnemiesTotal(1, Foe1.EnemyName[CurrentLocation][1], Sets.FoeType2Alive);
                EnemiesTotal(2, Foe1.EnemyName[CurrentLocation][2], Sets.FoeType3Alive);
                EnemiesTotal(3, Foe1.EnemyName[CurrentLocation][3], Sets.FoeType4Alive);
                switch (Sets.Rnd1)
                {
                    case 1: ImgShow(Img6); break;
                    case 2: ImgShowX(new Image[] { Img6, Img7 }); break;
                    case 3: ImgShowX(new Image[] { Img6, Img7, Img8 }); break;
                    default: ImgShow(Img6); break;
                }
            }
            TimeEnemy();
            BattleText2.Content = Sets.FoeType2Alive;
            AnyShow(BattleText2);
        }
        private void CalculateBattleStatus()
        {
            EnemyNamesFight = new Byte[] { 0, 0, 0, 0 };
            if (Img2.Source.ToString().Contains(Path.Ray.GoUp1) || Img2.Source.ToString().Contains(Path.Ray.GoUp2)) Img2.Source = Bmper(Path.Ray.StaticUp);
            else if (Img2.Source.ToString().Contains(Path.Ray.GoLeft)) Img2.Source = Bmper(Path.Ray.StaticLeft);
            else if (Img2.Source.ToString().Contains(Path.Ray.GoDown1) || Img2.Source.ToString().Contains(Path.Ray.GoDown2)) Img2.Source = Bmper(Path.Ray.StaticDown);
            else if (Img2.Source.ToString().Contains(Path.Ray.GoRight)) Img2.Source = Bmper(Path.Ray.StaticRight);
            LevelText.Content = (Super1.CurrentLevel < 25 ? "Ур. " + Super1.CurrentLevel : "Ур." + Super1.CurrentLevel);
            if (Sets.TableEN) ImgHide(TableMessage1);
            MaxAndWidthHPcalculate();
            MaxAndWidthAPcalculate();
            CurrentHpApCalculate();
            speed = 0;
            Lab2.Foreground = Brushes.Yellow;
            AnyShowX(LevelText, Lab2, HP, AP, HPtext, APtext, Img3, Img4, Img5, TimeTurnImg, HPbar, APbar, Time1);
            AnyHideX(Threasure1, Med2, Img1, Img2, PharaohAppears, SaveProgress, JailImg1, JailImg2, JailImg3, JailImg5, JailImg6, JailImg7, Boulder1);
            Map1ModelsAllTurnOff1();
            ChestsAndTablesAllTurnOff1();
            if (Sets.SpecialBattle != 200) FightMenuBack();
            ImgGrid(Img6, 23, 2);
            AbilityBonuses[0] = 0;
            AbilityBonuses[1] = 0;
            Time1.Value = 100;
            Icon0.Source = Super1.PlayerStatus == 0 ? Bmper(Path.IconStatePath.Usual) : Bmper(Path.IconStatePath.Poison);
        }
        private void BossBattle1()
        {
            CalculateBattleStatus();
            Sets.Rnd1 = 1;
            Foe1.EnemiesStillAlive = Convert.ToByte(Sets.Rnd1);
            BattleText3.Content = "Фараон: " + Foe1.EnemiesStillAlive;
            LabShow(BattleText3);
            Foe1.EnemyAppears[0] = "Фараон";
            Foe1.EnemyHP[0] = 500;
            Img6.Source = Bmper(Path.BossesStatePath.Pharaoh);
            ImgGrid(Img6, 18, 2);
            ImgShrink(Img6, 450 * Adoptation.WidthAdBack, 450 * Adoptation.HeightAdBack);
            MedShrink(Trgt, 450 * Adoptation.WidthAdBack, 450 * Adoptation.HeightAdBack);
            ImgShow(Img6);
            Exp += 125;
            Mat += 250;
            HeyPlaySomething(Path.GameMusic.LookWhoAwake);
            TimeEnemy();
        }
        private void BossBattle2()
        {
            CalculateBattleStatus();
            Sets.Rnd1 = 1;
            Foe1.EnemiesStillAlive = Convert.ToByte(Sets.Rnd1);
            BattleText3.Content = "????: " + Foe1.EnemiesStillAlive;
            LabShow(BattleText3);
            Foe1.EnemyAppears[0] = "????";
            Foe1.EnemyHP[0] = 2000;
            Img6.Source = Bmper(Path.BossesStatePath.Warrior);
            ImgGrid(Img6, 18, 2);
            ImgShrink(Img6, 450 * Adoptation.WidthAdBack, 450 * Adoptation.HeightAdBack);
            MedShrink(Trgt, 450 * Adoptation.WidthAdBack, 450 * Adoptation.HeightAdBack);
            ImgShow(Img6);
            Exp += 255;
            Mat += 255;
            HeyPlaySomething(Path.GameMusic.LookWhoAwake);
            TimeEnemy();
        }
        public static UInt16[] RememberHPAP = { 0, 0, 0, 0 };
        public static Byte[] RememberParams = { 0, 0, 0, 0 };
        private void SecretBossBattle1()
        {
            CalculateBattleStatus();
            Sets.Rnd1 = 1;
            Foe1.EnemiesStillAlive = Convert.ToByte(Sets.Rnd1);
            BattleText3.Content = "Угх-зан I: " + Foe1.EnemiesStillAlive;
            LabShow(BattleText3);
            Foe1.EnemyAppears[0] = "Угх-зан I";
            Foe1.EnemyHP[0] = 500;
            Img6.Source = Bmper(Path.BossesStatePath.UghZan);
            ImgGrid(Img6, 18, 2);
            ImgShrink(Img6, 450 * Adoptation.WidthAdBack, 450 * Adoptation.HeightAdBack);
            ImgShow(Img6);
            WidelyUsedAnyTimer(out timer8, SeriousSwitch_Time_Tick45, new TimeSpan(0, 0, 0, 0, Convert.ToByte(50 / GameSpeed.Value)));
            RememberHPAP[0] = Convert.ToUInt16(Super1.CurrentHP);
            RememberHPAP[1] = Convert.ToUInt16(Super1.CurrentAP);
            RememberHPAP[2] = Super1.MaxHP;
            RememberHPAP[3] = Super1.MaxAP;
            RememberParams[0] = Super1.Attack;
            RememberParams[1] = Super1.Defence;
            RememberParams[2] = Super1.Speed;
            RememberParams[3] = Super1.Special;
            APtext.Content = "БР";
            NewMaximumX(200, HPbar, APbar);
            FullRecoverX(HPbar, APbar);
            Super1.CurrentHP = 200;
            Super1.CurrentAP = 200;
            CurrentHpApCalculate();
            Super1.Attack = 100;
            Super1.Defence = 35;
            Exp += 250;
            Mat += 500;
            HeyPlaySomething(Path.GameMusic.SeriousIsMe);
            TimeEnemy();
        }
        private void NewMaximum(ProgressBar Bar, in UInt16 Max) { Bar.Maximum = Max; Bar.Width = Bar.Maximum; }
        private void NewMaximumX(in UInt16[] Maxes, params ProgressBar[] Bars) { for (Byte i=0;i<Bars.Length;i++) NewMaximum(Bars[i], Maxes[i]); }
        private void NewMaximumX(in UInt16 Max, params ProgressBar[] Bars) { foreach (ProgressBar Bar in Bars) NewMaximum(Bar, Max); }
        private void FullRecover(ProgressBar Bar) { Bar.Value=Bar.Maximum; }
        private void FullRecoverX(params ProgressBar[] Bars) { foreach (ProgressBar Bar in Bars) FullRecover(Bar); }
        private void Med2_MediaEnded(object sender, RoutedEventArgs e)
        {
            switch (Sets.SpecialBattle)
            {
                case 0: RegularBattle(); break;
                case 1: BossBattle1(); break;
                case 2: BossBattle2(); break;
                case 200: SecretBossBattle1(); break;
                default: Form1.Close(); break;
            }
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Sets.SelectedTarget = Convert.ToByte(Sets.SelectedTarget > 2 ? 0 : Sets.SelectedTarget);
            SelectedTrgt = Sets.SelectedTarget;
            FightMenuMakesDisappear();
            BtnShowX(new Button[] { Fight, Cancel1 });
            SelectTarget();
        }
        public void SelectTarget()
        {
            Uri[] EnemySource = new Uri[] { Ura(Path.FoesStatePath.SpiderIcon), Ura(Path.FoesStatePath.MummyIcon), Ura(Path.FoesStatePath.ZombieIcon), Ura(Path.FoesStatePath.BonesIcon), Ura(Path.BossesStatePath.PharaohIcon), Ura(Path.BossesStatePath.UghZanIcon) };
            AnyShowX(HPenemy, HPenemyBar, EnemyImg, TrgtImg);
            RefreshAllHP();
            InfoAboutEnemies();
            WidelyUsedAnyTimer(out timer9, Target_Time_Tick16, new TimeSpan(0, 0, 0, 0, Convert.ToUInt16(100 / GameSpeed.Value)));
        }
        private void CheckMapIfModelExistsX(in Byte[] Models, in Image[] images) { for (Byte i = 0; i < Models.Length; i++) if (CheckMapIfModelExists(Models[i])) ImgShow(images[i]); }
        private void AfterAction()
        {
            BattleText3.Foreground = Brushes.White;
            BattleText4.Foreground = Brushes.White;
            BattleText5.Foreground = Brushes.White;
            if (Sets.SpecialBattle == 200) HP.Foreground = Brushes.White;
            LabHideX(new Label[] { BattleText1, BattleText2 });
            if (speed > 0)
            {
                if (HPRegenerate != null) { HPRegenerate.IsEnabled = !HPRegenerate.IsEnabled; HPRegenerate.Stop(); }
                if (APRegenerate != null) { APRegenerate.IsEnabled = !APRegenerate.IsEnabled; APRegenerate.Stop(); }
                Sets.FoeType1Alive = 0;
                Sets.FoeType2Alive = 0;
                Sets.FoeType3Alive = 0;
                Sets.FoeType4Alive = 0;
                Foe1.EnemiesStillAlive = 0;
                Foe1.EnemyHP[0] = 0;
                Foe1.EnemyHP[1] = 0;
                Foe1.EnemyHP[2] = 0;
                Exp = 0;
                Mat = 0;
                AnyHideX(Img3, Img4, Img5, Img6, Img7, Img8, TimeTurnImg, HPbar, HPbarOver333, HPbarOver666, APbar, APbarOver333, APbarOver666, NextExpBar, Time1, HP, AP, Lab2, HPtext, APtext, LevelText, ExpText, BattleText3, BattleText4, BattleText5, BattleText6);
                ImgShowX(new Image[] { Img1, Img2, Threasure1, SaveProgress });
                CheckMapIfModelExistsX(new Byte[] { 104, 105, 105, 106, 107, 108 }, new Image[] { JailImg1, JailImg2, JailImg3, JailImg5, JailImg6, JailImg7 });
                speed = 0;
                timer2.Stop();
                Sound1.Stop();
                ChestsAndTablesAllTurnOn1();
                if (CurrentLocation == 0) Map1EnableModels(); else ImgShowX(new Image[] { SecretChestImg1, SecretChestImg2 });
                if (CheckMapIfModelExists(7)) ImgShow(Boulder1);
                ButtonHide(Abilities);
                Abilities.IsEnabled = Super1.CurrentLevel >= 2;
                string[] music = new string[] { Path.GameMusic.AncientPyramid, Path.GameMusic.WaterTemple };
                HeyPlaySomething(music[CurrentLocation]);
            }
            else
            if (Foe1.EnemiesStillAlive <= 0)
            {
                if (HPRegenerate != null) { HPRegenerate.IsEnabled = !HPRegenerate.IsEnabled; HPRegenerate.Stop(); }
                if (APRegenerate != null) { APRegenerate.IsEnabled = !APRegenerate.IsEnabled; APRegenerate.Stop(); }
                ChestsAndTablesAllTurnOn1();
                if (CheckMapIfModelExists(7)) ImgShow(Boulder1);
                if (CurrentLocation == 1) ImgShowX(new Image[] { SecretChestImg1, SecretChestImg2 });
                Sound1.Stop();
                SEF(Path.GameSounds.NowTheWinnerIs);
                Grid.SetColumn(BattleText1, 22);
                FastTextChange(new Label[] { BattleText1, BattleText2 }, new string[] { "Победа!", "Пора переходить к добыче" });
                AnyShowX(Img4, BattleText1, BattleText2, textOk2);
            }
            else if (Super1.CurrentHP > 0) Time();
            BattleText2.Content = Sets.FoeType1Alive+" " + Sets.FoeType2Alive + " " + Sets.FoeType3Alive + " " + Sets.FoeType4Alive + " " + Foe1.EnemiesStillAlive;
            AnyShow(BattleText2);
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Super1.DefenseState = 2;
            FightMenuMakesDisappear();
            Time1.Value = 0;
            HP.Foreground = Brushes.White;
            if (Sets.SpecialBattle == 200)
            {
                FastImgChange(new Image[] { Img4, Img5 }, BmpersToX(Bmper(Path.PersonStatePath.Serious), Bmper(Path.PersonStatePath.Usual)));
                Super1.SetCurrentHpAp(Convert.ToUInt16(Super1.CurrentHP + 40 < Super1.MaxHP ? Super1.CurrentHP + 40 : Super1.MaxHP), Convert.ToUInt16(Super1.CurrentAP + 20 < Super1.MaxAP ? Super1.CurrentAP + 20 : Super1.MaxAP));
                CurrentHpApCalculate();
            }
            else FastImgChange(new Image[] { Img4, Img5 }, BmpersToX(Bmper(Path.PersonStatePath.Defensive), Bmper(Path.IconStatePath.Defensive)));
            Lab2.Foreground = Brushes.White;
            Dj(Path.GameNoises.StrongStand);
            Time();
        }
        private void Time()
        {
            if ((Time1.Value == 100) && (HPbar.Value != 0))
            {
                Super1.DefenseState = 1;
                FastImgChange(new Image[] { Img4, Img5 }, BmpersToX(Bmper(Sets.SpecialBattle == 200 ? Path.PersonStatePath.Serious : Path.PersonStatePath.Usual), Bmper(Sets.SpecialBattle == 200 ? Path.IconStatePath.Serious : Super1.PlayerStatus == 1 ? Path.IconStatePath.Poison : Path.IconStatePath.Usual)));
                FightMenuBack();
                if (Sets.SpecialBattle == 200) BtnHideX(new Button[] { Button4, Items, Abilities });
                Lab2.Foreground = Brushes.Yellow;
            }
            else WidelyUsedAnyTimer(out timer, Player_Time_Tick, new TimeSpan(0, 0, 0, 0, Convert.ToUInt16(240 / Super1.Speed / GameSpeed.Value)));
        }
        private void TimeEnemy() { Byte aglfoe = 25; if ((Foe1.EnemyHP[0] > 0) || (Foe1.EnemyHP[1] > 0) || (Foe1.EnemyHP[2] > 0)) WidelyUsedAnyTimer(out timer2, EnemyTime_Tick2, new TimeSpan(0, 0, 0, 0, Convert.ToUInt16((50 - aglfoe) / GameSpeed.Value))); }
        private int CheckEnemies(out UInt16 EnemyAttack, Byte pos)
        {
            Foe.Stats[][] FS = new Foe.Stats[][] { new Foe.Stats[] { Foe1.Spider, Foe1.Mummy, Foe1.Zombie, Foe1.Bones, Foe1.BOSS1, Foe1.SecretBOSS1 }, new Foe.Stats[] { Foe1.Vulture, Foe1.Ghoul, Foe1.GrimReaper, Foe1.Scarab, Foe1.BOSS2 } };
            EnemyAttack = 25;
            for (Byte i = 0; i < Foe1.EnemyName.Length; i++) if (Foe1.EnemyAppears[pos - 1] == Foe1.EnemyName[CurrentLocation][i]) { EnemyAttack = Convert.ToUInt16(FS[CurrentLocation][i].EnemyAttack + FS[CurrentLocation][i].EnemyAttack*(FS[CurrentLocation][i].EnemySpeed*0.01)); break; }
            return 25;
        }
        private int GetOut(out Byte Speed)
        {
            Foe.Stats[][] FS = new Foe.Stats[][] { new Foe.Stats[] { Foe1.Spider, Foe1.Mummy, Foe1.Zombie, Foe1.Bones, Foe1.BOSS1, Foe1.SecretBOSS1 }, new Foe.Stats[] { Foe1.Vulture, Foe1.Ghoul, Foe1.GrimReaper, Foe1.Scarab, Foe1.BOSS2 } };
            Speed = 10;
            for (Byte i = 0; i < Foe1.EnemyAppears.Length; i++) for (Byte j = 0; j < Foe1.EnemyName.Length; j++) if (Foe1.EnemyAppears[i] == Foe1.EnemyName[CurrentLocation][j]) Speed = Speed < FS[CurrentLocation][j].EnemySpeed ? FS[CurrentLocation][j].EnemySpeed : Speed;
            return Speed;
        }
        private UInt16 EnemyTough(Byte pos)
        {
            Foe.Stats[][] FS = new Foe.Stats[][] { new Foe.Stats[] { Foe1.Spider, Foe1.Mummy, Foe1.Zombie, Foe1.Bones, Foe1.BOSS1, Foe1.SecretBOSS1 }, new Foe.Stats[] { Foe1.Vulture, Foe1.Ghoul, Foe1.GrimReaper, Foe1.Scarab, Foe1.BOSS2 } };
            for (Byte i = 0; i < Foe1.EnemyName.Length; i++) if (Foe1.EnemyAppears[pos] == Foe1.EnemyName[CurrentLocation][i]) { return Convert.ToUInt16(FS[CurrentLocation][i].EnemyDefence + FS[CurrentLocation][i].EnemyAgility * (FS[CurrentLocation][i].EnemySpeed * 0.01)); }
            return 25;
        }
        private UInt16 EnemyAntiSkill(Byte pos)
        {
            Foe.Stats[][] FS = new Foe.Stats[][] { new Foe.Stats[] { Foe1.Spider, Foe1.Mummy, Foe1.Zombie, Foe1.Bones, Foe1.BOSS1, Foe1.SecretBOSS1 }, new Foe.Stats[] { Foe1.Vulture, Foe1.Ghoul, Foe1.GrimReaper, Foe1.Scarab, Foe1.BOSS2 } };
            for (Byte i = 0; i < Foe1.EnemyName.Length; i++) if (Foe1.EnemyAppears[pos] == Foe1.EnemyName[CurrentLocation][i]) { return Convert.ToUInt16(FS[CurrentLocation][i].EnemyAgility + FS[CurrentLocation][i].EnemySpeed); }
            return 25;
        }
        private string NameEnemies(out string enemy, Byte pos)
        {
            Foe.Stats[][] FS = new Foe.Stats[][] { new Foe.Stats[] { Foe1.Spider, Foe1.Mummy, Foe1.Zombie, Foe1.Bones, Foe1.BOSS1, Foe1.SecretBOSS1 }, new Foe.Stats[] { Foe1.Vulture, Foe1.Ghoul, Foe1.GrimReaper, Foe1.Scarab, Foe1.BOSS2 } };
            enemy = "Паук";
            for (Byte i = 0; i < Foe1.EnemyName.Length; i++) if (Foe1.EnemyAppears[pos] == Foe1.EnemyName[CurrentLocation][i]) { enemy = FS[CurrentLocation][i].EnemyName[CurrentLocation][i]; break; }
            return enemy;
        }
        private string EnemySounds(in Byte pos)
        {
            string[] sounds = { Path.GameSounds.SpiderDied, Path.GameSounds.MummyDied, Path.GameSounds.ZombieDied, Path.GameSounds.BonesDied, Path.GameSounds.PhaGetLost };
            for (Byte i = 0; i < Foe1.EnemyName.Length; i++) if (Foe1.EnemyAppears[pos] == Foe1.EnemyName[CurrentLocation][i]) { return sounds[i]; }
            return Path.GameSounds.SpiderDied;
        }
        private void EnemyOnAttack(in string enemy, in UInt16 dmg)
        {
            if (Sets.SpecialBattle != 200) Super1.CurrentHP = Convert.ToUInt16(Super1.CurrentHP - dmg > 0? Super1.CurrentHP - dmg:0);
            else
            {
                if (Super1.CurrentAP - 10 >= 0) Super1.SetCurrentHpAp(Convert.ToUInt16(Super1.CurrentHP - dmg + 10 > 0 ? Super1.CurrentHP - (dmg - 10) : 0), Convert.ToUInt16(Super1.CurrentAP - 10));                
                else Super1.SetCurrentHpAp(Convert.ToUInt16(Super1.CurrentHP - dmg + Super1.CurrentAP > 0 ? Super1.CurrentHP - (dmg - Super1.CurrentAP) : 0), 0);                
                CurrentAPcalculate();
            }
            CurrentHPcalculate();
            BattleText6.Content = "-" + dmg;
            LabShow(BattleText6);
            HP.Foreground = Brushes.Red;
            UInt16 GameSpeed1 = Convert.ToUInt16(50 / GameSpeed.Value);
            if (Sets.SpecialBattle != 200)
            {
                if (timer3 == null) { WidelyUsedAnyTimer(out timer3, DamageTime_Tick3, new TimeSpan(0, 0, 0, 0, GameSpeed1)); timer3.IsEnabled = true; }
                else if (Img4.Source.ToString().Contains(Path.PersonStatePath.Usual) && (!timer3.IsEnabled)) { WidelyUsedAnyTimer(out timer3, DamageTime_Tick3, new TimeSpan(0, 0, 0, 0, GameSpeed1)); timer3.IsEnabled = true; }
                else HP.Foreground = Brushes.White;

                if (timer4 == null) { WidelyUsedAnyTimer(out timer4, HurtTime_Tick4, new TimeSpan(0, 0, 0, 0, GameSpeed1)); timer4.IsEnabled = true; }
                else if (!timer4.IsEnabled) { WidelyUsedAnyTimer(out timer4, HurtTime_Tick4, new TimeSpan(0, 0, 0, 0, GameSpeed1)); timer4.IsEnabled = true; }
                else HP.Foreground = Brushes.White;
            }
        }

        public static Byte PlayerHurt = 0;
        public static Byte PlayerHurtM = 0;
        public static Byte[] EnemyAtck = new Byte[] { 0, 0, 0 };
        //public static string DamageGet = "";
        public void SetAnyValues(Object[] Properties, params Object[] Values)
        {
            for (Byte i = 0; i < Values.Length; i++)
            {
                if (Values[i].GetType() == typeof(String)) Properties[i] = (String)Values[i];
                if (Values[i].GetType() == typeof(Boolean)) Properties[i] = (Boolean)Values[i];
                if (Values[i].GetType() == typeof(Byte)) Properties[i] = (Byte)Values[i];
                if (Values[i].GetType() == typeof(UInt16)) Properties[i] = (UInt16)Values[i];
                if (Values[i].GetType() == typeof(Double)) Properties[i] = (Double)Values[i];
            }
        }
        public void SetAnyValues(Double[] Properties, params Double[] Values) { for (Byte i = 0; i < Values.Length; i++) Properties[i] = (Double)Values[i]; }
        public Byte[] SetAnyValues(Byte[] Properties, params Object[] Values)
        {
            for (Byte i = 0; i < Values.Length; i++) Properties[i] = (Byte)Values[i];
            return Properties;
        }
        public UInt16[] SetAnyValues(UInt16[] Properties, params Object[] Values)
        {
            for (Byte i = 0; i < Values.Length; i++) Properties[i] = (UInt16)Values[i];
            return Properties;
        }
        private void BattleFoeCharges(in Byte FoeNo , ref System.Windows.Threading.DispatcherTimer SomeTimer)
        {
            string enemy = "";
            UInt16 EnemyAttack = 25;
            UInt16 PlayerDef = Convert.ToUInt16(Super1.Defence * Super1.DefenseState + Super1.Special * Super1.Speed * 0.005 + Super1.PlayerEQ[1] + Super1.PlayerEQ[2] + Super1.PlayerEQ[3] + AbilityBonuses[1]);
            if (Foe1.EnemyHP[FoeNo] > 0)
                if (Foe1.EnemyTurn[FoeNo] == 200)
                {
                    EventHandler[] FoeFights = { FoeAttack1_Time_Tick5, FoeAttack2_Time_Tick6, FoeAttack3_Time_Tick7 };
                    Foe1.EnemyTurn[FoeNo] = 0;
                    CheckEnemies(out EnemyAttack, 1);
                    NameEnemies(out enemy, 1);
                    if (EnemyAttack > PlayerDef)
                    {
                        UInt16 dmg = Convert.ToUInt16(EnemyAttack - PlayerDef);
                        WidelyUsedAnyTimer(out SomeTimer, FoeFights[FoeNo], new TimeSpan(0, 0, 0, 0, Convert.ToUInt16(50 / GameSpeed.Value)));
                        EnemyOnAttack(enemy, dmg);
                        Super1.PlayerStatus = Convert.ToByte((Random1.Next(1, 13) == 7) && (Super1.PlayerStatus != 1) && (Foe1.EnemyAppears[FoeNo] == "Паук") ? 1 : 0);
                        Img5.Source = Bmper(Super1.PlayerStatus == 1 ? Path.IconStatePath.Poison : Path.IconStatePath.Usual);
                    }
                }
                else Foe1.EnemyTurn[FoeNo] += 1;
        }
        private void EnemyTime_Tick2(object sender, EventArgs e)
        {
            if (Super1.CurrentHP <= 0)
            {
                Super1.PlayerStatus = 0;
                Sound1.Stop();
                Sound2.Stop();
                Sound3.Stop();
                LabHide(BattleText3);
                MediaShow(GameOver);
                GameOver.Play();
                if (timer != null) timer.Stop();
                timer2.Stop();
            }
            if ((Super1.PlayerStatus == 1) && (Super1.CurrentHP > 0)) if (poison < 30) poison += 1; else { poison = 0; Super1.CurrentHP = Convert.ToUInt16(Super1.CurrentHP - 1); CurrentHPcalculate(); }
            if (((Foe1.EnemyHP[0] > 0) || (Foe1.EnemyHP[1] > 0) || (Foe1.EnemyHP[2] > 0)) && (Super1.CurrentHP > 0))
            {
                BattleFoeCharges(0, ref timer5);
                BattleFoeCharges(1, ref timer6);
                BattleFoeCharges(2, ref timer7);
            }
        }
        private void Player_Time_Tick(object sender, EventArgs e) { if (Time1.Value < 100) Time1.Value += 1; else { timer.Stop(); Time(); } }
        private void Skip1_Click(object sender, RoutedEventArgs e) { ButtonHide(Skip1); Med1.Position = new TimeSpan(0, 0, 0, 7, 500); }
        private void Sound1_MediaEnded(object sender, RoutedEventArgs e)
        {
            Sound1.Stop();
            Sound1.Position = TimeSpan.Zero;
            Sound1.Play();
        }
        private void FightMenuMakesDisappear() { BtnHideX(new Button[] { Button2, Button3, Button4, Abilities, Items }); }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            Byte agl = Super1.Speed;
            Byte fagl = 10;
            FightMenuMakesDisappear();
            GetOut(out fagl);
            Time1.Value = 0;
            Lab2.Foreground = Brushes.White;
            if (agl > fagl)
            {
                timer2.Stop();
                speed = 1;
            }
            else
            {
                BattleText2.Content = "Не удается сбежать!";
                LabShow(BattleText2);
            }
            WidelyUsedAnyTimer(out timer8, Escape_Time_Tick9, new TimeSpan(0, 0, 0, 0, Convert.ToUInt16(25 / GameSpeed.Value)));
            Dj(Path.GameNoises.FleeAway);
        }
        private void FightMenuBack()
        {
            BtnShowX(new Button[] { Button2, Button3 });
            if (Sets.SpecialBattle != 200) {
                BtnShowX(new Button[] { Button4, Abilities, Items });
                Button4.IsEnabled = Sets.SpecialBattle == 0;
                Abilities.IsEnabled = Super1.CurrentLevel >= 2;
            }
        }
        private void Trgt_MediaEnded(object sender, RoutedEventArgs e)
        {
            Trgt.Stop();
            Med1.Position = new TimeSpan(0, 0, 0, 0, 0);
            Trgt.Play();
        }
        public static Byte SelectedTrgt = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer9.Stop();
            SelectedTrgt = Sets.SelectedTarget;
            UInt16 strength = Convert.ToUInt16(Super1.Attack + Super1.PlayerEQ[0] + AbilityBonuses[0]);
            UInt16 EnemyDefence = EnemyTough(SelectedTrgt);
            AnyHideX(BattleText1, HPenemyBar, HPenemy, Fight, Cancel1, TrgtImg, EnemyImg);
            WidelyUsedAnyTimer(out timer10, DamageFoe_Time_Tick17, new TimeSpan(0, 0, 0, 0, Convert.ToUInt16(50 / GameSpeed.Value)));
            LabShow(BattleText1);

            Time1.Value = 0;
            Lab2.Foreground = Brushes.White;

            Foe1.EnemyHP[Sets.SelectedTarget] = Convert.ToUInt16(Foe1.EnemyHP[Sets.SelectedTarget] - (strength - EnemyDefence) < 0 ? 0 : Foe1.EnemyHP[Sets.SelectedTarget] - (strength - EnemyDefence));
            if (Foe1.EnemyHP[Sets.SelectedTarget] == 0)
            {
                string res = Path.GameSounds.SpiderDied;
                try { res = EnemySounds(Sets.SelectedTarget); } catch { res = Path.GameSounds.SpiderDied; }
                SEF(res);
            }
            if (Foe1.EnemyHP[Sets.SelectedTarget] == 0)
            {
                switch (Sets.SelectedTarget)
                {
                    case 0: ImgHide(Img6); break;
                    case 1: ImgHide(Img7); break;
                    case 2: ImgHide(Img8); break;
                }
                SuperCheckFoes(Convert.ToByte(Sets.SelectedTarget));
                Sets.SelectedTarget = Convert.ToByte(Foe1.EnemyHP[0] != 0? 0 : Foe1.EnemyHP[1] != 0? 1 : Foe1.EnemyHP[2] != 0? 2 : 0);

                Byte[,] grRowColumn = new Byte[,] { { 23, 15, 21 }, { 2, 13, 24 } };
                ImgGrid(TrgtImg, grRowColumn[0, Sets.SelectedTarget], grRowColumn[1, Sets.SelectedTarget]);
                Foe1.EnemiesStillAlive = Convert.ToByte(Foe1.EnemiesStillAlive - 1);
                if ((Foe1.EnemyAppears[Sets.SelectedTarget] == "Фараон")|| (Foe1.EnemyAppears[Sets.SelectedTarget] == "Угх-зан I"))
                    if (Foe1.EnemiesStillAlive == 0)
                    {
                        BattleText2.Content = Foe1.EnemyAppears[Sets.SelectedTarget] + " погибает!";
                        LabShow(BattleText2);
                        LabHide(BattleText6);
                        BattleText6.Content = "";
                        Foe1.EnemyAppears[Sets.SelectedTarget] = "";
                    }
            }
            EventHandler WeaponCharacter = (Sets.SpecialBattle == 200 ? SeriousMinigun_Time_Tick39 : (Super1.PlayerEQ[0]==10 ? HandAttack_Time_Tick8: Super1.PlayerEQ[0] == 50 ? (EventHandler)KnifeAttack_Time_Tick8 : HandAttack_Time_Tick8));
            WidelyUsedAnyTimer(out timer8, WeaponCharacter, new TimeSpan(0, 0, 0, 0, Convert.ToUInt16(25 / GameSpeed.Value)));
            Dj(Path.GameNoises.HandAttack);
        }
        public static Byte Actions = 0;
        public static UInt16 FoeDamage = 0;
        private void DamageFoe_Time_Tick17(object sender, EventArgs e)
        {
            UInt16 strength = Convert.ToUInt16(Super1.Attack + Super1.PlayerEQ[0] + AbilityBonuses[0] - EnemyTough(Sets.SelectedTarget));
            Label[] Labs = new Label[] { DamageFoe, DamageFoe2, DamageFoe3 };
            Labs[SelectedTrgt].Content = Convert.ToUInt16(strength);
            FoesKicked();
        }
        private void CureHP_Time_Tick18(object sender, EventArgs e) { CureHealTxt.Content = "+" + Super1.Special * 2; CureOrHeal(); }
        private void HealPsn_Time_Tick19(object sender, EventArgs e) { CureHealTxt.Content = "-Яд"; CureOrHeal(); }
        private void TorchDmg_Time_Tick20(object sender, EventArgs e)
        {
            UInt16 trchsp = Convert.ToUInt16((Foe1.EnemyAppears[SelectedTrgt] == "Паук") || (Foe1.EnemyAppears[SelectedTrgt] == "Мумия") ? Super1.Special * 2.5 : Foe1.EnemyAppears[SelectedTrgt] == "Фараон" ? Super1.Special * 0.5 : Super1.Special * 1.25);
            trchsp += Convert.ToUInt16(Super1.Special * Super1.Speed * 0.01);
            Label[] Labs = new Label[] { DamageFoe, DamageFoe2, DamageFoe3 };
            UInt16 EnemyAura = EnemyAntiSkill(Sets.SelectedTarget);
            Labs[SelectedTrgt].Content = Convert.ToUInt16(trchsp > EnemyAura ? trchsp - EnemyAura : 0);
            FoesKicked();
        }

        private void WhipDmg_Time_Tick21(object sender, EventArgs e)
        {
            UInt16 whipsp = Convert.ToUInt16((Foe1.EnemyAppears[SelectedTrgt] == "Зомби") || (Foe1.EnemyAppears[SelectedTrgt] == "Страж") ? Super1.Special * 3 : Foe1.EnemyAppears[SelectedTrgt] == "Фараон" ? Super1.Special * 0.75 : Super1.Special * 1.5);
            whipsp += Convert.ToUInt16(Super1.Special * Super1.Speed * 0.01);
            Label[] Labs = new Label[] { DamageFoe, DamageFoe2, DamageFoe3 };
            UInt16 EnemyAura = EnemyAntiSkill(Sets.SelectedTarget);
            Labs[SelectedTrgt].Content = Convert.ToUInt16(whipsp > EnemyAura ? whipsp - EnemyAura : 0);
            FoesKicked();
        }

        private void SuperDmg_Time_Tick22(object sender, EventArgs e)
        {
            UInt16 supersp = Convert.ToUInt16(Foe1.EnemyAppears[0] != "Фараон"? Super1.Special * 2 : Super1.Special);
            supersp += Convert.ToUInt16(Super1.Special * Super1.Speed * 0.01);
            UInt16 EnemyAura = EnemyAntiSkill(Sets.SelectedTarget);
            Label[] Labs = new Label[] { DamageFoe, DamageFoe2, DamageFoe3 };
            for (Byte i = 0; i < Labs.Length; i++) if (Foe1.EnemyHP[i] != 0) Labs[i].Content = supersp > EnemyAura? supersp - EnemyAura: 0;
            FoesKicked();
        }
        public static Byte CureCurrent = 0;
        public static Byte RAPCurrent = 0;
        private void CureOrHeal()
        {
            Byte[] RowSet2 = { 22, 21, 20, 19, 18 };
            if (!CureHealTxt.IsEnabled) LabShow(CureHealTxt);
            if (CureCurrent == RowSet2.Length - 1)
            {
                CureCurrent = 0;
                timer11.Stop();
                LabHide(CureHealTxt);
            }
            else
            {
                Grid.SetRow(CureHealTxt, RowSet2[CureCurrent]);
                CureCurrent++;
            }
        }
        
        private void RestoreAP()
        {
            Byte[] RowSet2 = { 24, 23, 22, 21, 20 };
            if (!RecoverAPTxt.IsEnabled) LabShow(RecoverAPTxt);
            if (RAPCurrent == RowSet2.Length - 1) { RAPCurrent = 0; timer11.Stop(); LabHide(RecoverAPTxt); }
            else { Grid.SetRow(RecoverAPTxt, RowSet2[RAPCurrent]); RAPCurrent++; }
        }

        private void FoesKicked()
        {
            Byte[,] RowSet2 = new Byte[,] { { 26, 25, 26, 25, 26 }, { 18, 17, 18, 17, 18 }, { 24, 23, 24, 23, 24 } };
            Byte[,] ColumnSet2 = new Byte[,] { { 4, 3, 2, 1, 0 }, { 15, 14, 13, 12, 11 }, { 26, 25, 24, 23, 22 } };
            Label[] Labs = new Label[] { DamageFoe, DamageFoe2, DamageFoe3 };
            if (SelectedTrgt < 3)
            {
                if (!Labs[SelectedTrgt].IsEnabled) LabShow(Labs[SelectedTrgt]);
                if (FoeDamage == ColumnSet2.GetLength(1) - 1)
                {
                    FoeDamage = 0;
                    timer10.Stop();
                    LabHide(Labs[SelectedTrgt]);
                }
                else
                {
                    LabGrid(Labs[SelectedTrgt], RowSet2[SelectedTrgt, FoeDamage], ColumnSet2[SelectedTrgt, FoeDamage]);
                    FoeDamage++;
                }
            }
            else
            {
                for (Byte i = 0; i < 3; i++) if ((!Labs[i].IsEnabled) && (Foe1.EnemyHP[i] != 0)) LabShow(Labs[i]);
                if (FoeDamage == ColumnSet2.GetLength(1) - 1)
                {
                    FoeDamage = 0;
                    timer10.Stop();
                    LabHideX(Labs);
                }
                else
                {
                    for (Byte i=0;i<3;i++) if (Foe1.EnemyHP[i] != 0) LabGrid(Labs[i], RowSet2[i, FoeDamage], ColumnSet2[i, FoeDamage]);
                    FoeDamage++;
                }
            }
        }
        private void IconActions(Image icon, in string[] ico)
        {
            icon.Source = Bmper(ico[Actions]);
            if (Actions == ico.Length - 1)
            {
                Actions = 0;
                icon.Source = Bmper(Path.IconStatePath.Usual);
                timer2.Stop();
                timer2.IsEnabled = !timer2.IsEnabled;
            }
            else Actions++;
        }
        private void ActionsTickCheck(in string[] pers, in string[] ico)
        {
            FastImgChange(new Image[] { Img4, Img5 }, BmpersToX(Bmper(pers[Actions]), Bmper(ico[Actions])));
            if (Actions == pers.Length - 1)
            {
                Actions = 0;
                FastImgChange(new Image[] { Img4, Img5 }, BmpersToX(Bmper(Sets.SpecialBattle != 200 ? @Path.PersonStatePath.Usual : @Path.PersonStatePath.Serious),
                    Bmper(Sets.SpecialBattle == 200 ? @Path.IconStatePath.Serious : Super1.PlayerStatus == 1 ? @Path.IconStatePath.Poison : @Path.IconStatePath.Usual)));
                AfterAction();
                timer8.Stop();
            }
            else Actions++;
        }
        public static Byte trgt = 0;
        private void UnlimitedActionsTickCheck(in string[] spec)
        {
            TrgtImg.Source = new BitmapImage(new Uri(spec[trgt], UriKind.RelativeOrAbsolute));
            trgt = Convert.ToByte(trgt == spec.Length - 1? 0 : trgt+1);
        }
        private void Cancel1_Click(object sender, RoutedEventArgs e)
        {
            timer9.Stop();
            AnyHideX(Fight, Cancel1, HPenemy, BattleText1, EnemyImg, TrgtImg, HPenemyBar);
            FightMenuBack();
            if (Sets.SpecialBattle == 200) BtnHideX(new Button[] { Button4, Items, Abilities });
        }
        private void Win_MediaEnded(object sender, RoutedEventArgs e) { WinStop(); HideAfterBattleMenu(); }
        private void WinStop()
        {
            WonOrDied();
            string[] music = new string[] { Path.GameMusic.AncientPyramid, Path.GameMusic.WaterTemple, Path.GameMusic.LavaTemple };
            CheckMapIfModelExistsX(new Byte[] { 104, 105, 105, 106, 107, 108 }, new Image[] { JailImg1, JailImg2, JailImg3, JailImg5, JailImg6, JailImg7 });
            if (Sets.TableEN) ImgShow(TableMessage1);
            if (CurrentLocation == 0) Map1EnableModels();
            ImgShowX(new Image[] { Threasure1, Img2, SaveProgress });
            AnyHideX(Win, Img5);
            Win.Position = new TimeSpan(0, 0, 0, 0, 0);
            HeyPlaySomething(music[CurrentLocation]);
        }
        private void Map1EnableModels()
        {
            switch (Sets.LockIndex)
            {
                case 0: break;
                case 1: ImgShowX(new Image[] { KeyImg3, LockImg3 }); break;
                case 2: ImgShowX(new Image[] { KeyImg2, LockImg2, KeyImg3, LockImg3 }); break;
                case 3: Map1ModelsAllTurnOn1(); break;
                default: Map1ModelsAllTurnOn1(); break;
            }
            ChestsAndTablesAllTurnOn1();
        }
        private void Sound2_MediaEnded(object sender, RoutedEventArgs e) { Sound2.Stop(); }
        private void Win_MediaFailed(object sender, ExceptionRoutedEventArgs e) { WonOrDied(); Win.Stop(); ImgShow(Img2); }
        private void HideAfterBattleMenu() { AnyHideX(NewLevelGet, AfterParams, AfterHPtxt, AfterAPtxt, AfterHP, AfterAP, AfterAttack, AfterDefence, AfterAgility, AfterSpecial, AfterATK, AfterDEF, AfterAG, AfterSP, AddHP, AddAP, AddATK, AddDEF, AddAG, AddSP, ExpText, AfterLevel, AfterName, AfterStatus, BeforeParams, BeforeHPtxt, BeforeAPtxt, BeforeHP, BeforeAP, BeforeAttack, BeforeDefence, BeforeAgility, BeforeSpecial, BeforeATK, BeforeDEF, BeforeAG, BeforeSP, AfterBattleGet, MaterialsGet, MaterialsOnHand, MaterialsAdd, ItemsGet, ItemsGetSlot1, AfterAttackImg, AfterDefenceImg, AfterAgilityImg, AfterSpecialImg, AfterBattleMenuImg, AfterIcon, BeforeAttackImg, BeforeDefenceImg, BeforeAgilityImg, BeforeSpecialImg, MaterialsGetImg, AfterHPbar, AfterAPbar, NextExpBar, BeforeHPbar, BeforeAPbar, BeforeHPbarOver333, AfterHPbarOver333, BeforeHPbarOver666, AfterHPbarOver666, BeforeAPbarOver333, AfterAPbarOver333, BeforeAPbarOver666, AfterAPbarOver666, TextOk1); }
        private void TextOk1_Click(object sender, RoutedEventArgs e)
        {
            Win.Source = (CurrentLocation==1? Ura(Path.CutScene.WasteTime) : Ura(Path.CutScene.Victory));
            MaterialsAdd.Content = "";
            if (timer.IsEnabled) timer.Stop();
            BAG.Materials += Convert.ToUInt16(timer.IsEnabled ? Mat : 0);
            Mat = 0;
            if (Sets.SpecialBattle == 0)
            {
                MediaShow(Win);
                AnyHideX(BattleText1, BattleText2, BattleText3, Img1);
            }
            else
            {
                ImgGrid(Img6, 18, 2);
                ImgShrink(Img6, 450 * Adoptation.WidthAdBack, 450 * Adoptation.HeightAdBack);
                LabHideX(new Label[] { BattleText1, BattleText2, BattleText3 });
                switch (Sets.SpecialBattle)
                {
                    case 1: MediaShow(TheEnd); Img1.Source = Bmper(Path.Backgrounds.Normal); break;
                    case 2: MediaShow(TheEnd); Img1.Source = Bmper(Path.Backgrounds.Normal); break;
                    case 200: MediaShow(Win); AnyHide(Img1); break;
                    default: MediaShow(Win); AnyHide(Img1); break;
                }
            }
            HideAfterBattleMenu();
            Sound1.Stop();
            ImgShow(Img1);
        }
        private void WonOrDied() { Sound1.Stop(); AnyHideX(BattleText1, BattleText2, BattleText3, Lab2, HPtext, APtext, LevelText, HP, AP, ATK, TextOk1, Button2, Button3, Button4, Items, Abilities, textOk2, HPbar, APbar, Time1, Img3, Img4, Img5, Img6, Img7, Img8, TimeTurnImg); }
        private void FightStaticButtons_MouseEnter(object sender, MouseEventArgs e)
        {
            Button[] FightMenu = { Cancel1, Cancel2, Back1, Back2 };
            String[] BattleTxt = { "Отменить нападение", "Отменить умение", "Обратно к действиям", "Обратно к действиям" };
            for (Byte i = 0; i < FightMenu.Length; i++)
                if (sender.Equals(FightMenu[i]))
                {
                    BattleText2.Content = BattleTxt[i];
                    LabShow(BattleText2);
                    break;
                }
        }
        private void FightStaticButtons_MouseLeave(object sender, MouseEventArgs e)
        {
            Button[] FightMenu = { Cancel1, Cancel2, Back1, Back2 };
            for (Byte i = 0; i < FightMenu.Length; i++) if (sender.Equals(FightMenu[i])) { LabHide(BattleText2); break; }
        }
        private void FightDynamicButtons_MouseLeave(object sender, MouseEventArgs e)
        {
            Button[] FightMenu = { Button2, Button3, Button4, Items, Abilities, Fight, ACT1, ACT2, ACT3 };
            Image[] images = { FightImg, DefenceImg, EscapeFromBattleImg, ItemsImg, AbilitiesImg, SelectTrgt1Img, SelectTrgt2Img, SelectTrgt3Img, SelectTrgt4Img };
            BitmapImage[] Btim = { Bmper(Path.BtnBefore.Fight), Bmper(Path.BtnBefore.Defence), Bmper(Path.BtnBefore.Escape), Bmper(Path.BtnBefore.Bag), Bmper(Path.BtnBefore.Skills), Bmper(Path.BtnBefore.Select), Bmper(Path.BtnBefore.Select), Bmper(Path.BtnBefore.Select), Bmper(Path.BtnBefore.Select) };
            for (Byte i = 0; i < FightMenu.Length; i++) if (sender.Equals(FightMenu[i])) { images[i].Source = Btim[i]; LabHide(BattleText2); break; }
        }
        private void FightDynamicButtons_MouseEnter(object sender, MouseEventArgs e)
        {
            Button[] FightMenu = { Button2, Button3, Button4, Items, Abilities, Fight, ACT1, ACT2, ACT3 };
            Image[] images = { FightImg, DefenceImg, EscapeFromBattleImg, ItemsImg, AbilitiesImg, SelectTrgt1Img, SelectTrgt2Img, SelectTrgt3Img, SelectTrgt4Img };
            BitmapImage[] Btim = { Bmper(Path.BtnAfter.Fight), Bmper(Path.BtnAfter.Defence), Bmper(Path.BtnAfter.Escape), Bmper(Path.BtnAfter.Bag), Bmper(Path.BtnAfter.Skills), Bmper(Path.BtnAfter.Select), Bmper(Path.BtnAfter.Select), Bmper(Path.BtnAfter.Select), Bmper(Path.BtnAfter.Select) };
            String[] text = { "Атаковать выбранного врага", "Встать в стойку (Защита X2)", "Сбежать из боя", "Посмотреть инвентарь", "Особые умения", "Подтвердить цель", "Поджечь выбранного врага", "Ударить врага хлыстом", "Подстрелить врага" };
            for (Byte i = 0; i < FightMenu.Length; i++)
                if (sender.Equals(FightMenu[i]))
                {
                    images[i].Source = Btim[i];
                    BattleText2.Content = text[i];
                    LabShow(BattleText2);
                    break;
                }
        }
        private void HideFightIconPersActions() { AnyHideX(HPenemyBar, BattleText4, BattleText5, BattleText6, HPenemy, ItemText, ItemsCountImg, Img4, Img5, TrgtImg, Cure, Heal, Torch, Whip, Super, Back1, Button2, Button3, Button4, Items, Abilities, Fight, Cancel1, ACT1, ACT2, Cancel2); }
        private void GameOver_MediaEnded(object sender, RoutedEventArgs e)
        {
            AnyHideX(Button2, Button3, Button4, Threasure1, GameOver);
            AnyShowX(Img1, Button1, Lab1);
            Map1ModelsAllTurnOff1();
            ChestsAndTablesAllTurnOff1();
            HideFightIconPersActions();
            WonOrDied();
            if (timer != null) timer.Stop();
            Sound1.Position = new TimeSpan(0, 0, 0, 0, 0);
            Img1.Source = Bmper(Path.Backgrounds.Main);
            HeyPlaySomething(Path.GameMusic.MainTheme);
        }
        public static Byte[] AbilityBonuses = new Byte[] { 0, 0, 0, 0 };
        private void AbilitiesMakeDisappear1() { BtnHideX(new Button[] { Cure, Cure2, Heal, BuffUp, ToughenUp, Regen, Control, Torch, Whip, Thrower, Super, Tornado, Quake, Learn, Back1, SwitchAbils }); }
        private void Back1_Click(object sender, RoutedEventArgs e)
        {
            AbilitiesMakeDisappear1();
            FightMenuBack();
        }
        private void PersonTextAnimationStart(in EventHandler PersonAction, in EventHandler TextAction, in UInt16 PersonSpeed, in UInt16 TextSpeed)
        {
            WidelyUsedAnyTimer(out timer8, PersonAction, new TimeSpan(0, 0, 0, 0, PersonSpeed));
            WidelyUsedAnyTimer(out timer11, TextAction, new TimeSpan(0, 0, 0, 0, TextSpeed));
        }
        private void DmgTextAnimationStart(in EventHandler PersonAction, in EventHandler TextAction, in UInt16 PersonSpeed, in UInt16 TextSpeed)
        {
            WidelyUsedAnyTimer(out timer8, PersonAction, new TimeSpan(0, 0, 0, 0, PersonSpeed));
            WidelyUsedAnyTimer(out timer10, TextAction, new TimeSpan(0, 0, 0, 0, TextSpeed));
        }
        private void Cure_Click(object sender, RoutedEventArgs e)
        {
            PersonTextAnimationStart(Cure_Time_Tick11, CureHP_Time_Tick18, Convert.ToUInt16(25 / GameSpeed.Value), Convert.ToUInt16(75 / GameSpeed.Value));
            Dj(Path.GameNoises.Cure);
            Super1.SetCurrentHpAp(Convert.ToUInt16(Super1.Special * 2 + Super1.CurrentHP >= Super1.MaxHP ? Super1.MaxHP : Super1.CurrentHP + Super1.Special * 2), Convert.ToUInt16(Super1.CurrentAP - 5));
            CurrentHpApCalculate();
            AbilitiesMakeDisappear1();
            Time1.Value = 0;
        }
        private void Abilities_Click(object sender, RoutedEventArgs e)
        {
            CheckAccessAbilities(new Button[] { Cure, Cure2, Heal, BuffUp, ToughenUp, Regen, Control }, new Byte[] { 2, 21, 4, 16, 14, 20, 25 }, new Byte[] { 5, 10, 3, 12, 8, 15, 0 });
            BtnShowX(new Button[] { SwitchAbils, Back1 });
            if (APRegenerate != null) Control.IsEnabled = !APRegenerate.IsEnabled;
            if (HPRegenerate != null) Regen.IsEnabled = !HPRegenerate.IsEnabled;
            FastEnableDisableBtn(new Boolean[] { AbilityBonuses[0] <= 0, AbilityBonuses[1] <= 0 }, BuffUp, ToughenUp);
            ToNextImg.Source = Bmper(Path.BtnCustomize.ArrowNext);
            FightMenuMakesDisappear();
        }
        private void LevelUpShow()
        {
            AnyShowX(NewLevelGet, AfterParams, AfterHPtxt, AfterAPtxt, AfterHP, AfterAP, AfterAttack, AfterDefence, AfterAgility, AfterSpecial, AfterATK, AfterDEF, AfterAG, AfterSP, AddHP, AddAP, AddATK, AddDEF, AddAG, AddSP, AfterAttackImg, AfterDefenceImg, AfterAgilityImg, AfterSpecialImg);
            if (AfterAPbar.Width < 333) BarShow(AfterAPbar); else BarShowX(AfterAPbarOver333.Width < 333 ? new ProgressBar[] { AfterAPbar, AfterAPbarOver333 } : new ProgressBar[] { AfterAPbar, AfterAPbarOver333, AfterAPbarOver666 });
            if (AfterHPbar.Width < 333) BarShow(AfterHPbar); else BarShowX(AfterHPbarOver333.Width < 333? new ProgressBar[] { AfterHPbar, AfterHPbarOver333 } : new ProgressBar[] { AfterHPbar, AfterHPbarOver333, AfterHPbarOver666 });
        }
        private void AddingStats_Time_Tick41(object sender, EventArgs e)
        {
            if ((CurrentNextHPAP[0] < Super1.MaxHP) || (CurrentNextHPAP[1] < Super1.MaxAP) || (CurrentNextParams[0] < Super1.Attack) || (CurrentNextParams[1] < Super1.Defence) || (CurrentNextParams[2] < Super1.Speed) || (CurrentNextParams[3] < Super1.Special))
            {
                if (CurrentNextHPAP[0] < Super1.MaxHP)
                {
                    CurrentNextHPAP[0]++;
                    if (AfterHPbar.Width < 333) NewMaximum(AfterHPbar, CurrentNextHPAP[0]);
                    else
                    {
                        NewMaximumX(AfterHPbar.Width < 333? new UInt16[] { 333, Convert.ToUInt16(CurrentNextHPAP[0] - 333) } : new UInt16[] { 333, 333, Convert.ToUInt16(CurrentNextHPAP[0] - 333) }, AfterHPbar.Width < 333 ? new ProgressBar[] { AfterHPbar, AfterHPbarOver333 }: new ProgressBar[] { AfterHPbar, AfterHPbarOver333, AfterHPbarOver666 });
                        BarShowX(AfterHPbar.Width < 333 ? new ProgressBar[] { AfterHPbarOver333 }: new ProgressBar[] { AfterHPbarOver333, AfterHPbarOver666 });
                    }
                    FastTextChange(new Label[] { AddHP, AfterHP }, new string[] { "+" + (Super1.MaxHP - CurrentNextHPAP[0]), Super1.CurrentHP + "/" + CurrentNextHPAP[0] });
                }
                else LabHide(AddHP);

                if (CurrentNextHPAP[1] < Super1.MaxAP)
                {
                    CurrentNextHPAP[1]++;
                    if (AfterAPbar.Width < 333) NewMaximum(AfterAPbar, CurrentNextHPAP[1]);
                    else
                    {
                        NewMaximumX(AfterAPbar.Width < 333 ? new UInt16[] { 333, Convert.ToUInt16(CurrentNextHPAP[1] - 333) } : new UInt16[] { 333, 333, Convert.ToUInt16(CurrentNextHPAP[1] - 333) }, AfterAPbar.Width < 333 ? new ProgressBar[] { AfterAPbar, AfterAPbarOver333 } : new ProgressBar[] { AfterAPbar, AfterAPbarOver333, AfterAPbarOver666 });
                        BarShowX(AfterAPbar.Width < 333 ? new ProgressBar[] { AfterAPbarOver333 } : new ProgressBar[] { AfterAPbarOver333, AfterAPbarOver666 });
                    }
                    FastTextChange(new Label[] { AddAP, AfterAP }, new string[] { "+" + (Super1.MaxAP - CurrentNextHPAP[1]), Super1.CurrentAP + "/" + CurrentNextHPAP[1] });
                }
                else LabHide(AddAP);

                CustomAddStat(0, Super1.Attack, AddATK, AfterATK);
                CustomAddStat(1, Super1.Defence, AddDEF, AfterDEF);
                CustomAddStat(2, Super1.Speed, AddAG, AfterAG);
                CustomAddStat(3, Super1.Special, AddSP, AfterSP);
            }
            else
            {
                timer13.Stop();
                MaxAndWidthHPcalculate();
                MaxAndWidthAPcalculate();
                LabHideX(new Label[] { AddHP, AddAP, AddATK, AddDEF, AddAG, AddSP });
                ButtonShow(TextOk1);
            }
        }
        private void CustomAddStat(in Byte StatNo, in Byte Stat, Label AddPlus, Label Added)
        {
            if (CurrentNextParams[StatNo] < Stat) { CurrentNextParams[StatNo]++; FastTextChange(new Label[] { AddPlus, Added }, new string[] { "+" + (Stat - CurrentNextParams[StatNo]), CurrentNextParams[StatNo].ToString() }); }
            else LabHide(AddPlus);
        }
        private void AddingMaterials_Time_Tick42(object sender, EventArgs e)
        {
            if ((Mat > 0) && (BAG.Materials + 1 < 65535))
            {
                BAG.Materials++;
                MaterialsOnHand.Content = BAG.Materials;
                Mat--;
                MaterialsAdd.Content = "+" + Mat;
            } else
            {
                Mat = 0;
                timer.IsEnabled = false;
                LabHide(MaterialsAdd);
                timer.Stop();
            }
        }
        private void Levelling_Time_Tick40(object sender, EventArgs e)
        {
            if ((Exp > 0) && (Super1.CurrentLevel < 25)) {
                if (Super1.Experience + 1 >= NextExpBar.Maximum)
                {
                    if (Super1.CurrentLevel < 25) {
                        Super1.CurrentLevel += 1;
                        Super1.SetStats(Convert.ToByte(Super1.CurrentLevel-1));

                        Super1.Experience = 0;
                        NextExpBar.Maximum = Super1.NextLevel[Super1.CurrentLevel - 1];
                        NextExpBar.Value = 0;
                        FastTextChange(new Label[] { AddHP, AddAP, AddATK, AddDEF, AddAG, AddSP, ExpText, AfterLevel }, new string[] { "+" + (Super1.MaxHP - CurrentNextHPAP[0]), "+" + (Super1.MaxAP - CurrentNextHPAP[1]), "+" + (Super1.Attack - CurrentNextParams[0]), "+" + (Super1.Defence - CurrentNextParams[1]), "+" + (Super1.Speed - CurrentNextParams[2]), "+" + (Super1.Special - CurrentNextParams[3]), "Опыт " + NextExpBar.Value + "/" + NextExpBar.Maximum, "Уровень " + Super1.CurrentLevel });

                        if (!NewLevelGet.IsEnabled) LevelUpShow();
                        NewLevelGet.Content = (LevelUpCount > 1? "Новый уровень! X" + LevelUpCount : "Новый уровень!");
                        LevelUpCount += 1;
                        Dj(Path.GameNoises.LevelUp);
                        if (!timer2.IsEnabled)
                        {
                            WidelyUsedAnyTimer(out timer2, LevelingUPImage_Time_Tick44, new TimeSpan(0, 0, 0, 0, 25));
                            timer2.IsEnabled = true;
                        }
                    } else
                    {
                        Super1.Experience = Convert.ToUInt16(NextExpBar.Maximum);
                        NextExpBar.Value = NextExpBar.Maximum;
                        //                "Максимальный"
                        ExpText.Content = "Профессионал";
                        Exp = 0;
                        timer12.Stop();
                        if (!NewLevelGet.IsEnabled) ButtonShow(TextOk1); else WidelyUsedAnyTimer(out timer13, AddingStats_Time_Tick41, new TimeSpan(0, 0, 0, 0, 25));
                    }
                }
                else
                {
                    Super1.Experience++;
                    NextExpBar.Value= Super1.Experience;
                    ExpText.Content = "Опыт " + NextExpBar.Value + "/" + NextExpBar.Maximum;
                }
                Exp--;
            }
            else if (!NewLevelGet.IsEnabled)
            {
                timer12.Stop();
                ButtonShow(TextOk1);
            }
            else
            {
                timer12.Stop();
                WidelyUsedAnyTimer(out timer13, AddingStats_Time_Tick41, new TimeSpan(0, 0, 0, 0, 25));
            }
        }

        public static Byte LevelUpCount = 1;
        public static Byte[] CurrentNextParams = new Byte[] { 25, 15, 15, 25 };
        public static UInt16[] CurrentNextHPAP = new UInt16[] { 100, 40 };

        private void LevelingUPImage_Time_Tick44(object sender, EventArgs e) { IconActions(AfterIcon, Path.IconAnimatePath.LevelUp); }
        private void textOk2_Click(object sender, RoutedEventArgs e)
        {
            ItemsGetSlot1.Content = "";
            if (Sets.SpecialBattle == 200)
            {
                APtext.Content = "ОД";
                Super1.SetStats(Convert.ToByte(Super1.CurrentLevel-1));
                Super1.SetCurrentHpAp(RememberHPAP[0], RememberHPAP[1]);
                RefreshAllHPAP();
                Sets.SpecialBattle = 0;
                TrgtImg.Width = 325;
                TrgtImg.Height = 325;
                Img6.Width = 325;
                Img6.Height = 325;
                FastImgChange(new Image[] { Img4, Img5 }, BmpersToX(Bmper(Path.IconStatePath.Usual), Bmper(Path.PersonStatePath.Usual)));
                BAG.Armor[3] = true;
                BAG.Jacket = Super1.PlayerEQ[1] == 0;
                ItemsGetSlot1.Content += "Футболка серьёзного \n";
                LabShow(ItemsGetSlot1);
            }
            AnyHideX(HPbar, HPbarOver333, HPbarOver666, APbar, APbarOver333, APbarOver666, BattleText1, BattleText2, BattleText3, BattleText4, BattleText5, BattleText6, textOk2);
            ShowAfterBattleMenu();
            WonOrDied();
        }
        private void ShowAfterBattleMenu()
        {
            LevelUpCount = 1;
            CurrentNextParams = SetAnyValues(CurrentNextParams, Super1.Attack, Super1.Defence, Super1.Speed, Super1.Special);
            CurrentNextHPAP = SetAnyValues(CurrentNextHPAP, Super1.MaxHP, Super1.MaxAP);
            FastTextChange(new Label[] { BeforeATK, BeforeDEF, BeforeAG, BeforeSP, BeforeHP, BeforeAP, AfterATK, AfterDEF, AfterAG, AfterSP, AfterHP, AfterAP }, new string[] { Convert.ToString(CurrentNextParams[0]), Convert.ToString(CurrentNextParams[1]), Convert.ToString(CurrentNextParams[2]), Convert.ToString(CurrentNextParams[3]), Super1.CurrentHP + "/" + CurrentNextHPAP[0], Super1.CurrentAP + "/" + CurrentNextHPAP[1], Convert.ToString(CurrentNextParams[0]), Convert.ToString(CurrentNextParams[1]), Convert.ToString(CurrentNextParams[2]), Convert.ToString(CurrentNextParams[3]), Super1.CurrentHP + "/" + CurrentNextHPAP[0], Super1.CurrentAP + "/" + CurrentNextHPAP[1] });
            if (HPbar.Width < 333)
            {
                NewMaximumX(CurrentNextHPAP[0], BeforeHPbar, AfterHPbar);
                SetAnyValues(new object[] { HPbarOver333.Value, HPbarOver666.Value }, 0, 0);
            }
            else
            {
                NewMaximumX(HPbarOver333.Width < 333 ? new UInt16[] { 333, 333, Convert.ToUInt16(CurrentNextHPAP[0] - 333), Convert.ToUInt16(CurrentNextHPAP[0] - 333) } : new UInt16[] { 333, 333, 333, 333, Convert.ToUInt16(CurrentNextHPAP[0] - 666), Convert.ToUInt16(CurrentNextHPAP[0] - 666) }, HPbarOver333.Width < 333 ? new ProgressBar[] { BeforeHPbar, AfterHPbar, BeforeHPbarOver333, AfterHPbarOver333 } : new ProgressBar[] { BeforeHPbar, AfterHPbar, BeforeHPbarOver333, AfterHPbarOver333, BeforeHPbarOver666, AfterHPbarOver666 });
                BarShowX(HPbarOver333.Width < 333 ? new ProgressBar[] { BeforeHPbarOver333 } : new ProgressBar[] { BeforeHPbarOver333, BeforeHPbarOver666 });
                HPbarOver666.Value = (HPbarOver333.Width < 333 ? 0 : HPbarOver666.Value);
            }
            if (APbar.Width < 333)
            {
                NewMaximumX(CurrentNextHPAP[1], BeforeAPbar, AfterAPbar);
                SetAnyValues(new object[] { APbarOver333.Value, APbarOver666.Value }, 0, 0);
            }
            else
            {
                NewMaximumX(APbarOver333.Width < 333 ? new UInt16[] { 333, 333, Convert.ToUInt16(CurrentNextHPAP[1] - 333), Convert.ToUInt16(CurrentNextHPAP[1] - 333) } : new UInt16[] { 333, 333, 333, 333, Convert.ToUInt16(CurrentNextHPAP[1] - 666), Convert.ToUInt16(CurrentNextHPAP[1] - 666) }, HPbarOver333.Width < 333 ? new ProgressBar[] { BeforeAPbar, AfterAPbar, BeforeAPbarOver333, AfterAPbarOver333 } : new ProgressBar[] { BeforeAPbar, AfterAPbar, BeforeAPbarOver333, AfterAPbarOver333, BeforeAPbarOver666, AfterAPbarOver666 });
                BarShowX(APbarOver333.Width < 333 ? new ProgressBar[] { BeforeAPbarOver333 } : new ProgressBar[] { BeforeAPbarOver333, BeforeAPbarOver666 });
                APbarOver666.Value = (APbarOver333.Width < 333 ? 0 : APbarOver666.Value);
            }
            SetAnyValues(new object[] { BeforeHPbar.Value, AfterHPbar.Value, BeforeHPbarOver333.Value, AfterHPbarOver333.Value, BeforeHPbarOver666.Value, AfterHPbarOver666.Value, BeforeAPbar.Value, AfterAPbar.Value, BeforeAPbarOver333.Value, AfterAPbarOver333.Value, BeforeAPbarOver666.Value, AfterAPbarOver666.Value }, new object[] { HPbar.Value, HPbar.Value, HPbarOver333.Value, HPbarOver333.Value, HPbarOver666.Value, HPbarOver666.Value, APbar.Value, APbar.Value, APbarOver333.Value, APbarOver333.Value, APbarOver666.Value, APbarOver666.Value });
            FastTextChange(new Label[] { MaterialsOnHand, MaterialsAdd, AfterLevel }, new string[] { "" + BAG.Materials, "+" + Mat, "Уровень " + Super1.CurrentLevel });
            AnyShowX(ExpText, AfterLevel, AfterName, AfterStatus, BeforeParams, BeforeHPtxt, BeforeAPtxt, BeforeHP, BeforeAP, BeforeAttack, BeforeDefence, BeforeAgility, BeforeSpecial, BeforeATK, BeforeDEF, BeforeAG, BeforeSP, AfterBattleGet, MaterialsGet, MaterialsOnHand, MaterialsAdd, ItemsGet, ItemsGetSlot1, AfterBattleMenuImg, AfterIcon, BeforeAttackImg, BeforeDefenceImg, BeforeAgilityImg, BeforeSpecialImg, MaterialsGetImg, NextExpBar, BeforeHPbar, BeforeAPbar);
            ItemsGetSlot1.Content = "";
            WidelyUsedAnyTimer(out timer12, Levelling_Time_Tick40, new TimeSpan(0, 0, 0, 0, 0));
            WidelyUsedAnyTimer(out timer, AddingMaterials_Time_Tick42, new TimeSpan(0, 0, 0, 0, 0));
            RefreshAllHPAP();
            timer2.Stop();
            BAG.AntidoteITM = ItemsGetAfterFight(0, BAG.AntidoteITM);
            BAG.BandageITM = ItemsGetAfterFight(1, BAG.BandageITM);
            BAG.EtherITM = ItemsGetAfterFight(2, BAG.EtherITM);
            BAG.FusedITM = ItemsGetAfterFight(3, BAG.FusedITM);
        }
        private Byte ItemsGetAfterFight(in Byte ItemNo, Byte Value)
        {
            Byte item = 0;
            String[] ItemNames = { "Антидот", "Бинт", "Эфир", "Смесь" };
            if (Sets.ItemsDropRate[ItemNo] != 0)
                while (Sets.ItemsDropRate[ItemNo] != 0)
                {
                    item = Convert.ToByte(Random1.Next(0, 8) == 4 ? item + 1 : item);
                    Sets.ItemsDropRate[ItemNo]--;
                }
            if (item > 0)
            {
                ItemsGetSlot1.Content += ItemNames[ItemNo] +": " + item + "\n";
                Value = Convert.ToByte(Value + item < 255 ? Value + item : 255);
            }
            return Value;
        }
        private void Torch_Click(object sender, RoutedEventArgs e)
        {
            Sets.SelectedTarget = Convert.ToByte(Sets.SelectedTarget > 2 ? 0 : Sets.SelectedTarget);
            SelectedTrgt = Sets.SelectedTarget;
            SelectTarget();
            AbilitiesMakeDisappear1();
            BtnShowX(new Button[] { ACT1, Cancel2 });
        }

        private void InBattleHighSkillsMenu()
        {
            //throw new Exception(Path.BtnCustomize.ArrowPrev);
            if (ToNextImg.Source.ToString().Contains(Path.BtnCustomize.ArrowNext))
            {
                BtnHideX(new Button[] { Cure, Cure2, Heal, BuffUp, ToughenUp, Regen, Control });
                CheckAccessAbilities(new Button[] { Torch, Whip, Thrower, Super, Tornado, Quake, Learn }, new Byte[] { 3, 6, 11, 7, 13, 18, 5 }, new Byte[] { 4, 6, 15, 10, 20, 30, 2 });
                ButtonShow(SwitchAbils);
                ToNextImg.Source = Bmper(Path.BtnCustomize.ArrowPrev);
            }
            else if (ToNextImg.Source.ToString().Contains(Path.BtnCustomize.ArrowPrev))
            {
                BtnHideX(new Button[] { Torch, Whip, Thrower, Super, Tornado, Quake, Learn });
                CheckAccessAbilities(new Button[] { Cure, Cure2, Heal, BuffUp, ToughenUp, Regen, Control }, new Byte[] { 2, 21, 4, 16, 14, 20, 25 }, new Byte[] { 5, 10, 3, 12, 8, 15, 0 });
                ButtonShow(SwitchAbils);
                BuffUp.IsEnabled = AbilityBonuses[0] > 0? false : true;
                ToughenUp.IsEnabled = AbilityBonuses[1] > 0 ? false : true;
                if (APRegenerate != null) Control.IsEnabled = !APRegenerate.IsEnabled;
                if (HPRegenerate != null) Regen.IsEnabled = !HPRegenerate.IsEnabled;
                ToNextImg.Source = Bmper(Path.BtnCustomize.ArrowNext);
            }
        }

        private void Cancel2_Click(object sender, RoutedEventArgs e)
        {
            timer9.Stop();
            AnyHideX(HPenemyBar, HPenemy, BattleText1, EnemyImg, TrgtImg, Fight, ACT1, ACT2, ACT3, Cancel2, Cancel1);
            ButtonShow(Back1);
            InBattleHighSkillsMenu();
        }
        private void ACT(in Byte a1)
        {
            string[] EnemyNames = { "Паук", "Мумия", "Зомби", "Страж", "Стервятник", "Гуль", "Жнец", "Скарабей", "Моль-убийца", "Прислужник", "П. червь", "Мастер"  };
            UInt16 strength = Convert.ToUInt16(a1 == 0? ( Foe1.EnemyAppears[Sets.SelectedTarget] == EnemyNames[0] || Foe1.EnemyAppears[Sets.SelectedTarget] == EnemyNames[1] || Foe1.EnemyAppears[Sets.SelectedTarget] == EnemyNames[5] || Foe1.EnemyAppears[Sets.SelectedTarget] == EnemyNames[6] ? Super1.Special * 2.5 : Super1.Special * 1.25) : a1 == 1? ( Foe1.EnemyAppears[Sets.SelectedTarget] == EnemyNames[2] || Foe1.EnemyAppears[Sets.SelectedTarget] == EnemyNames[3] || Foe1.EnemyAppears[Sets.SelectedTarget] == EnemyNames[7] || Foe1.EnemyAppears[Sets.SelectedTarget] == EnemyNames[9] ? Super1.Special * 3 : Super1.Special * 1.5 ) : a1 == 2 ? (Foe1.EnemyAppears[Sets.SelectedTarget] == EnemyNames[4] || Foe1.EnemyAppears[Sets.SelectedTarget] == EnemyNames[8] || Foe1.EnemyAppears[Sets.SelectedTarget] == EnemyNames[9] || Foe1.EnemyAppears[Sets.SelectedTarget] == EnemyNames[11] ? Super1.Special*5 : Super1.Special*2.5) : Super1.Special);
            strength += Convert.ToUInt16(Super1.Special * Super1.Speed * 0.01);
            AnyHideX(HPenemy, BattleText1, HPenemyBar, EnemyImg, Fight, Cancel1, Cancel2);
            Time1.Value = 0;
            Lab2.Foreground = Brushes.White;
            UInt16 EnemyAura = EnemyAntiSkill(Sets.SelectedTarget);
            Foe1.EnemyHP[Sets.SelectedTarget] = Convert.ToUInt16(strength > EnemyAura ? Foe1.EnemyHP[Sets.SelectedTarget] - (strength - EnemyAura) < 0 ? 0 : Foe1.EnemyHP[Sets.SelectedTarget] - (strength-EnemyAura): Foe1.EnemyHP[Sets.SelectedTarget]);
            if (Foe1.EnemyHP[Sets.SelectedTarget] <= 0)
            {
                string res;
                try { res = EnemySounds(Sets.SelectedTarget); } catch { res = Path.GameSounds.SpiderDied; }
                SEF(res);
                SuperCheckFoes(Sets.SelectedTarget);
            }
            if (Foe1.EnemyHP[Sets.SelectedTarget] == 0)
            {
                Image[] Imgs = { Img6, Img7, Img8 };
                ImgHide(Imgs[Sets.SelectedTarget]);
                Sets.SelectedTarget = Convert.ToByte(Foe1.EnemyHP[0] != 0? 0 : Foe1.EnemyHP[1] != 0 ? 1 : Foe1.EnemyHP[2] != 0 ? 2 : Sets.SelectedTarget);                
                Foe1.EnemiesStillAlive--;
                if (Foe1.EnemyAppears[0] == "Фараон") if (Foe1.EnemiesStillAlive == 0) LabHide(BattleText3);
            }
        }
        private void Heal_Click(object sender, RoutedEventArgs e)
        {
            LabShow(BattleText1);
            Img5.Source = Bmper(@Path.IconStatePath.Usual);
            SetAnyValues(new object[] { Super1.PlayerStatus, Time1.Value },0,0);
            Super1.CurrentAP -= 3;
            CurrentAPcalculate();
            AbilitiesMakeDisappear1();
            PersonTextAnimationStart(Heal_Time_Tick12, HealPsn_Time_Tick19, Convert.ToUInt16(25 / GameSpeed.Value), Convert.ToUInt16(75 / GameSpeed.Value));
            Dj(Path.GameNoises.Heal);
        }
        private void Whip_Click(object sender, RoutedEventArgs e)
        {
            Sets.SelectedTarget = Convert.ToByte(Sets.SelectedTarget > 2 ? 0 : Sets.SelectedTarget);
            SelectedTrgt = Sets.SelectedTarget;
            SelectTarget();
            AbilitiesMakeDisappear1();
            BtnShowX(new Button[] { ACT2, Cancel2 });
        }
        private void SuperCheckFoes(in Byte seltrg)
        {
            Label[] Enemies = { BattleText3, BattleText4, BattleText5 };
            Byte[] FoesAlive = { Sets.FoeType1Alive, Sets.FoeType2Alive, Sets.FoeType3Alive, Sets.FoeType4Alive };
            for (Byte i = 0; i < FoesAlive.Length; i++)
                if (Foe1.EnemyAppears[seltrg] == Foe1.EnemyName[CurrentLocation][i])
                {
                    if (FoesAlive[i] - 1 <= 0)
                    {
                        Sets.EnemiesGetLost(i);
                        LabHide(Enemies[EnemyNamesFight[i]-1]);
                        FoesAlive[i] = 0;
                    }
                    else
                    {
                        Sets.EnemiesGetDown(i);
                        FoesAlive[i]--;
                        Enemies[EnemyNamesFight[i]-1].Foreground = Brushes.Red;
                        EnemiesTotal(Convert.ToByte(i), Foe1.EnemyName[CurrentLocation][i], FoesAlive[i]);
                    }
                    break;
                }
            Foe1.EnemyAppears[seltrg] = "";
        }
        private void AbilitySupers(in UInt16 strength)
        {
            AbilitiesMakeDisappear1();
            AnyHideX(TrgtImg, BattleText1, HPenemy, Fight, Cancel1, Cancel2, HPenemyBar);
            LabShow(BattleText1);
            SelectedTrgt = 4;
            Time1.Value = 0;
            Lab2.Foreground = Brushes.White;
            for (Byte i=0;i<3;i++) SupersFastCheck(strength,i);
            Sets.SelectedTarget = Convert.ToByte(Foe1.EnemyHP[0] > 0 ? 0 : Foe1.EnemyHP[1] > 0? 1 : 2);
            Time1.Value = 0;
        }
        private void SupersFastCheck(in UInt16 strength, in Byte CheckIndex)
        {
            Image[] FoeImgs = { Img6, Img7, Img8 };
            UInt16 EnemyAura = EnemyAntiSkill(CheckIndex);
            if ((Foe1.EnemyHP[CheckIndex] - strength + EnemyAura <= 0) && (Foe1.EnemyAppears[CheckIndex] != ""))
            {
                Foe1.EnemyHP[CheckIndex] = 0;
                ImgHide(FoeImgs[CheckIndex]);
                if ((Sets.SpecialBattle != 1) && (Sets.SpecialBattle != 2)) SuperCheckFoes(CheckIndex);
                else { LabHide(BattleText3); Foe1.EnemyAppears[0] = ""; };
                Foe1.EnemiesStillAlive = Convert.ToByte(Foe1.EnemiesStillAlive - 1 <= 0 ? 0 : Foe1.EnemiesStillAlive - 1);
                Foe1.EnemyAppears[CheckIndex] = "";
            }
            else if (Foe1.EnemyAppears[CheckIndex] != "") Foe1.EnemyHP[CheckIndex] = Convert.ToUInt16(strength > EnemyAura ? (Foe1.EnemyHP[CheckIndex] - strength + EnemyAura) : Foe1.EnemyHP[CheckIndex]);
        }
        private void Items_Click(object sender, RoutedEventArgs e)
        {
            FightMenuMakesDisappear();
            AnyShowX(Back2, ItemText, ItemsCountImg);
            CheckAccessItems(new Byte[] { BAG.AntidoteITM, BAG.FusedITM, BAG.BandageITM, BAG.EtherITM, BAG.HerbsITM, BAG.Ether2ITM, BAG.ElixirITM }, new Button[] { Antidote1, Fused1, Bandage1, Ether, Herbs, Ether2, Elixir });
            Dj(Path.GameNoises.BagOpen);
        }
        private void MenuItemsHide1() { BtnHideX(new Button[] { Antidote1, Fused1, Bandage1, Ether, Herbs, Ether2, Elixir, Back2 }); }
        private void Back2_Click(object sender, RoutedEventArgs e)
        {
            MenuItemsHide1();
            FightMenuBack();
            AnyHideX(ItemText, ItemsCountImg);
            Dj(Path.GameNoises.BagClose);
        }
        private void ShowEquipAndStats() { AnyShowX(EquipHImg, EquipBImg, EquipLImg, EquipDImg, ATKImg, DEFImg, AGImg, SPImg, ATK1, DEF1, AG1, SP1, EquipH, EquipB, EquipL, EquipD, Params, ParamsATK, ParamsDEF, ParamsAG, ParamsSP, EquipText); }
        private void MenuHpApExp()
        {
            HPbar1.Width = (HPbar.Width + HPbarOver333.Width + HPbarOver666.Width) * 0.65;
            HPbar1.Maximum = Super1.MaxHP;
            HPbar1.Value = Super1.CurrentHP;
            APbar1.Width = (APbar.Width + APbarOver333.Width + APbarOver666.Width) * 0.65;
            APbar1.Maximum = Super1.MaxAP;
            APbar1.Value = Super1.CurrentAP;
            NextExpBar.Value = Super1.Experience;
            ExpBar1.Width = NextExpBar.Width * 0.5;
            ExpBar1.Maximum = NextExpBar.Maximum;
            ExpBar1.Value = NextExpBar.Value;
            Exp1.Content = ExpText.Content;
            RefreshAllHPAP();
            BarColoring(HPbar1, 0);
            BarColoring(APbar1, 1);
            Icon0.Source = Bmper(Super1.PlayerStatus == 0 ? Path.IconStatePath.Usual : Path.IconStatePath.Poison);
            StatusP.Content = Super1.PlayerStatus == 0 ? "Статус: здоров ♫" : "Статус: отравлен §";
        }
        private void BarColoring(ProgressBar Bar, in Byte color)
        {
            string[,] colors = new string[,] { { "#FF3AAC28", "#FF0EDEAF", "#FF00F3FF" }, { "#FF1D25BB", "#FF5E1DBB", "#FFBB1D4F" } };
            if (Bar.Value < 333)
            {
                Bar.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom(colors[color, 0]));
                Bar.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom(colors[color, 0]));
            } else if (Bar.Value < 666)
            {
                Bar.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom(colors[color, 1]));
                Bar.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom(colors[color, 1]));
            } else
            {
                Bar.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom(colors[color, 2]));
                Bar.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom(colors[color, 2]));
            }
        }
        private void Status_Click(object sender, RoutedEventArgs e)
        {
            if (!Items0.IsEnabled) Dj(Path.GameNoises.BagClose);
            MegaHide();
            RightPanelMenuTurnON();
            HeroStatus();
        }
        private void RightPanelMenuTurnON() { BtnShowX(new Button[] { Status, Abils, Items0, Equip, Tasks, Info, Settings }); }
        private void CheckAccessAbilities(Button[] abils, in Byte[] lvl, in Byte[] apcost) { for (Byte i = 0; i < abils.Length; i++) if (Super1.CurrentLevel >= lvl[i]) { ButtonShow(abils[i]); abils[i].IsEnabled = Super1.CurrentAP >= apcost[i]; } }
        private void HeroAbilities()
        {
            MenuHpApExp();
            RightPanelMenuTurnON();
            AnyShowX(Menu1, Icon0, HPbar1, APbar1, Name0, StatusP, HPtext1, APtext1, HP1, AP1, Describe1, Describe2, CostText, MiscSkills, FightSkills);
            BarGridX(new ProgressBar[] { HPbar1, APbar1 }, new Byte[] { 4, 26 }, new Byte[] { 16, 11 });
            LabGridX(new Label[] { StatusP, HPtext1, APtext1, HP1, AP1, Exp1 }, new Byte[] { 2, 4, 26, Convert.ToByte(HPbar1.GetValue(Grid.RowProperty)), Convert.ToByte(APbar1.GetValue(Grid.RowProperty)), Convert.ToByte(ExpBar1.GetValue(Grid.RowProperty)) }, new Byte[] { 14, 7, 2, Convert.ToByte(Convert.ToInt32(HPbar1.GetValue(Grid.ColumnProperty)) + 1 + (Convert.ToInt32(HPbar1.Width) / 32)), Convert.ToByte(Convert.ToInt32(APbar1.GetValue(Grid.ColumnProperty)) + 1 + (Convert.ToInt32(APbar1.Width) / 32)), Convert.ToByte(Convert.ToInt32(ExpBar1.GetValue(Grid.ColumnProperty)) + 1 + (Convert.ToInt32(ExpBar1.Width) / 32)) });
            CheckAccessAbilities(new Button[] { Cure1, Heal1, Cure2Out, Torch1, Whip1, Thrower1, Super0, Tornado1, Quake1, Learn1, BuffUp1, ToughenUp1, Regen1, Control1 }, new Byte[] { 2, 4, 21, 3, 6, 11, 7, 13, 18, 5, 16, 14, 20, 25 }, new Byte[] { 5, 3, 10, 4, 6, 15, 10, 20, 30, 2, 12, 8, 15, 0 });
        }
        private void Abils_Click(object sender, RoutedEventArgs e)
        {
            if (!Items0.IsEnabled) Dj(Path.GameNoises.BagClose);
            MegaHide();
            HeroAbilities();
            Abils.IsEnabled = false;
            //                  "                                                                       "                                                                       ""                                                                       "
            FastTextChange(new Label[] { Describe1, Describe2 }, new string[] { "Каждое умение становится доступным при достижении определённого\nуровня. Используя их правильно, можно свернуть горы!", "Умения героя" });
            AnyShowX(Describe2, DescribeHeader, Describe1);
        }
        private void CheckAccessItems(in Byte[] bag, Button[] btn, Label[] lab) { for (Byte i = 0; i < lab.Length; i++) if (bag[i] >= 1) { ButtonShow(btn[i]); LabShow(lab[i]); } }
        private void CheckAccessItems(in Byte[] bag, Button[] btn)
        {
            for (Byte i = 0; i < btn.Length; i++)            
                if (bag[i] >= 1) ButtonShow(btn[i]);
                else ButtonHide(btn[i]);
        }
        private void HeroItems()
        {
            MenuHpApExp();            
            RightPanelMenuTurnON();
            BarGridX(new ProgressBar[] { HPbar1, APbar1 }, new Byte[] { 2, 4 }, new Byte[] { 16, 16 });
            LabGridX(new Label[] { StatusP, HPtext1, APtext1, HP1, AP1, Exp1 }, new Byte[] { 7, 2, 4, Convert.ToByte(HPbar1.GetValue(Grid.RowProperty)), Convert.ToByte(APbar1.GetValue(Grid.RowProperty)), Convert.ToByte(ExpBar1.GetValue(Grid.RowProperty)) }, new Byte[] { 2, 7, 7, Convert.ToByte(Convert.ToInt32(HPbar1.GetValue(Grid.ColumnProperty)) + 1 + (Convert.ToInt32(HPbar1.Width) / 32)), Convert.ToByte(Convert.ToInt32(APbar1.GetValue(Grid.ColumnProperty)) + 1 + (Convert.ToInt32(APbar1.Width) / 32)), Convert.ToByte(Convert.ToInt32(ExpBar1.GetValue(Grid.ColumnProperty)) + 1 + (Convert.ToInt32(ExpBar1.Width) / 32)) });
            CheckAccessItems(new Byte[] { BAG.AntidoteITM, BAG.BandageITM, BAG.EtherITM, BAG.FusedITM, BAG.HerbsITM, BAG.Ether2ITM, BAG.SleepBagITM, BAG.ElixirITM }, new Button[] { Antidote, Bandage, Ether1, Fused, Herbs1, Ether2Out, SleepBag1, Elixir1 }, new Label[] { AntidoteText, BandageText, EtherText, FusedText, HerbsText, Ether2OutText, SleepBagText, ElixirText });
            FastEnableDisableBtn(new Boolean[] { MapScheme[Adoptation.ImgYbounds, Adoptation.ImgXbounds] != 150, false }, new Button[] { SleepBag1, Items0 });
            CraftSwitch.Content = "Создание";
            MaterialsCraft.Content = BAG.Materials;
            FastTextChange(new Label[] { Describe1, Describe2 }, new string[] { "Инвентарь", "Предметы бывают очень полезными как в бою, так и вне боя. Лучше\nвсего перевязывать раны - иначе этот напалм не выдержать." });
            AnyShowX(DescribeHeader, Describe2, Describe1, StatusP, HPtext1, APtext1, HP1, AP1, Describe1, Describe2, MaterialsCraft, HPbar1, APbar1, CraftSwitch, Menu1, Icon0, MaterialsCraftImg);
        }
        private void Items0_Click(object sender, RoutedEventArgs e)
        {
            MegaHide();
            HeroItems();
            Dj(Path.GameNoises.BagOpen);
        }
        private void Bandage_MouseLeave(object sender, MouseEventArgs e) { LabHide(CountText); }
        private void Ether1_MouseLeave(object sender, MouseEventArgs e) { LabHide(CountText); }
        private void Antidote_MouseLeave(object sender, MouseEventArgs e) { LabHide(CountText); }
        private void RefreshAllAP() { FastTextChange(new Label[] { AP, AP1 }, new string[] { Super1.CurrentAP + "/" + Super1.MaxAP, Super1.CurrentAP + "/" + Super1.MaxAP }); }
        private void RefreshAllHP() { FastTextChange(new Label[] { HP, HP1 }, new string[] { Super1.CurrentHP + "/" + Super1.MaxHP, Super1.CurrentHP + "/" + Super1.MaxHP }); }
        private void RefreshAllHPAP() { RefreshAllHP(); RefreshAllAP(); }
        private void Fused_MouseLeave(object sender, MouseEventArgs e) { LabHide(CountText); }
        private void HeroEquip()
        {
            StatusCalculate();
            RightPanelMenuTurnON();
            BarGridX(new ProgressBar[] { HPbar1, APbar1 }, new Byte[] { 2, 4 }, new Byte[] { 16, 16 });
            LabGridX(new Label[] { StatusP, HPtext1, APtext1, HP1, AP1, Exp1 }, new Byte[] { 2, 2, 4, Convert.ToByte(HPbar1.GetValue(Grid.RowProperty)), Convert.ToByte(APbar1.GetValue(Grid.RowProperty)), Convert.ToByte(ExpBar1.GetValue(Grid.RowProperty)) }, new Byte[] { 14, 7, 7, Convert.ToByte(Convert.ToInt32(HPbar1.GetValue(Grid.ColumnProperty)) + 1 + (Convert.ToInt32(HPbar1.Width) / 32)), Convert.ToByte(Convert.ToInt32(APbar1.GetValue(Grid.ColumnProperty)) + 1 + (Convert.ToInt32(APbar1.Width) / 32)), Convert.ToByte(Convert.ToInt32(ExpBar1.GetValue(Grid.ColumnProperty)) + 1 + (Convert.ToInt32(ExpBar1.Width) / 32)) });
            AnyShowX(Menu1, Img2, Img1, Icon0, EquipHImg, EquipBImg, EquipLImg, EquipDImg, ATKImg, DEFImg, AGImg, SPImg, HPbar1, APbar1, HPtext1, APtext1, HP1, AP1, Describe1, Describe2, Params, ParamsATK, ParamsDEF, ParamsAG, ParamsSP, EquipText, ATK1, DEF1, AG1, SP1, EquipH, EquipB, EquipL, EquipD, DescribeHeader, Describe1, Equip1, Equip2, Equip3, Equip4, Remove1, Remove2, Remove3, Remove4);
            FastEnableDisableBtn(false, new Button[] { Equip, Remove1, Remove2, Remove3, Remove4, Equip1, Equip2, Equip3, Equip4 });
            FastTextChange(new Label[] { Describe1, Describe2 }, new string[] { "Снаряжение героя", "Отличное оснащение даёт преимущество в бою." });
        }
        private void FastEnableDisableBtn(Boolean enabled, params Button[] buttons) { foreach (Button btn in buttons) btn.IsEnabled = enabled; }
        private void FastEnableDisableBtn(Boolean[] enabled, params Button[] buttons) { for (Byte i=0;i<enabled.Length;i++) buttons[i].IsEnabled = enabled[i]; }
        private void Equip_Click(object sender, RoutedEventArgs e)
        {
            if (!Items0.IsEnabled) Dj(Path.GameNoises.BagClose);
            MegaHide();
            HeroEquip();
            ShowEquipAndStats();
            EquipWatch();
        }
        private void EquipWatch()
        {
            AnyShowX(Equip1, Equip2, Equip3, Equip4, Remove1, Remove2, Remove3, Remove4);
            FastEnableDisableBtn(new Boolean[] { BAG.Hands && (Super1.PlayerEQ[0] == 0), BAG.Jacket && (Super1.PlayerEQ[1] == 0), BAG.Legs && (Super1.PlayerEQ[2] == 0), BAG.Boots && (Super1.PlayerEQ[3] == 0), !BAG.Hands && (Super1.PlayerEQ[0] != 0),!BAG.Jacket && (Super1.PlayerEQ[1] != 0),!BAG.Legs && (Super1.PlayerEQ[2] != 0),!BAG.Boots && (Super1.PlayerEQ[3] != 0) }, Equip1, Equip2, Equip3, Equip4, Remove1, Remove2, Remove3, Remove4);
        }
        private void StatsMeaning() { FastTextChange(new Label[] { Level0, ATK1, DEF1, AG1, SP1 }, new string[] { "Уровень: " + Super1.CurrentLevel, Convert.ToString(Super1.Attack + Super1.PlayerEQ[0]), Convert.ToString(Super1.Defence + Super1.PlayerEQ[1] + Super1.PlayerEQ[2] + Super1.PlayerEQ[3]), Convert.ToString(Super1.Speed), Convert.ToString(Super1.Special) }); }
        private void OnRemove_Click(object sender, RoutedEventArgs e)
        {
            Button[] buttons = { Remove1, Remove2, Remove3, Remove4 };
            Label[] labels = { EquipH, EquipB, EquipL, EquipD };
            string[] descr = { "Правая рука","Тело","Ноги","Ступни" };
            for (Byte i=0;i < buttons.Length; i++)
                if (sender.Equals(buttons[i]))
                {
                    Super1.PlayerEQ[i] = 0;
                    buttons[i].IsEnabled = false;
                    labels[i].Content = descr[i];
                    BAG.EquipPropertyChange(i, true);
                    break;
                }
            StatsMeaning();
            EquipWatch();
        }
        private void OnEquip_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage[][] bitmapImages = {
                BmpersToX(Bmper(Path.BtnCustomize.Knucleduster), Bmper(Path.BtnCustomize.AncientKnife), Bmper(Path.BtnCustomize.LegendSword), Bmper(Path.BtnCustomize.SeriousMinigun)),
                BmpersToX(Bmper(Path.BtnCustomize.LeatherArmor), Bmper(Path.BtnCustomize.AncientArmor), Bmper(Path.BtnCustomize.LegendArmor), Bmper(Path.BtnCustomize.SeriousTshirt)),
                BmpersToX(Bmper(Path.BtnCustomize.FeatherWears), Bmper(Path.BtnCustomize.AncientPants), Bmper(Path.BtnCustomize.LegendPants), Bmper(Path.BtnCustomize.SeriousPants)),
                BmpersToX(Bmper(Path.BtnCustomize.BandageBoots), Bmper(Path.BtnCustomize.StrongBoots), Bmper(Path.BtnCustomize.LegendBoots), Bmper(Path.BtnCustomize.SeriousBoots))
            };
            Byte i = 0;
            Button[] EqButtons = { Equip1, Equip2, Equip3, Equip4 };
            Boolean[][] SomeEquipHave = { BAG.Weapon, BAG.Armor, BAG.Pants, BAG.ArmBoots };
            for (;i < EqButtons.Length; i++) if (sender.Equals(EqButtons[i])) break;
            Sets.EquipmentClass = i;
            if (SomeEquipHave[i][0]) ButtonShow(Equipments);
            if (SomeEquipHave[i][1]) ButtonShow(Equipments2);
            if (SomeEquipHave[i][2]) ButtonShow(Equipments3);
            if (SomeEquipHave[i][3]) ButtonShow(Equipments4);
            FastImgChange(new Image[] { EquipmentsImg, Equipments2Img, Equipments3Img, Equipments4Img }, bitmapImages[i]);
            ButtonShow(CancelEq);
        }
        private void CancelEq_Click(object sender, RoutedEventArgs e) { BtnHideX(new Button[] { Equipments, Equipments2, Equipments3, Equipments4, CancelEq }); }
        private void HeroTasks()
        {
            if (!Items0.IsEnabled) Dj(Path.GameNoises.BagClose);
            MegaHide();
            RightPanelMenuTurnON();
            Tasks.IsEnabled = false;
            string[] TasksText = { "Найдите способ открыть дверь", "Соберите другой ключ", "Соберите последний ключ", "Проверьте загадочный артефакт", "Найдите другой способ открыть врата","Откройте путь до артефакта", "Проверьте загадочный артефакт", "Найдите переправу через пропасть","Выдвините мост к артефакту","Заберите последний ключ древних тайн" };
            string[] uriSources = new string[] { Path.MenuImgs.UsualTask, Path.MenuImgs.Completed };
            switch (Super1.MenuTask)
            {
                case 0:
                    AnyShowX(Task1, Task1Img);
                    Task1.Content = TasksText[0];
                    Task1Img.Source = Bmper(uriSources[0]);
                    break;
                case 1:
                    AnyShowX(Task1, Task2, Task1Img, Task2Img);  
                    FastTextChange(new Label[] { Task1, Task2 }, new string[] { TasksText[0], TasksText[1] });
                    FastImgChange(new Image[] { Task1Img, Task2Img }, BmpersToX(Bmper(uriSources[1]), Bmper(uriSources[0])));
                    break;
                case 2:
                    AnyShowX(Task1, Task2, Task3, Task1Img, Task2Img, Task3Img);
                    FastTextChange(new Label[] { Task1, Task2, Task3 }, new string[] { TasksText[0], TasksText[1], TasksText[2] });
                    FastImgChange(new Image[] { Task1Img, Task2Img, Task3Img }, BmpersToX(Bmper(uriSources[1]), Bmper(uriSources[1]), Bmper(uriSources[0])));
                    break;
                case 3:
                    AnyShowX(Task1, Task2, Task3, Task4, Task1Img, Task2Img, Task3Img, Task4Img);
                    FastTextChange(new Label[] { Task1, Task2, Task3, Task4 }, new string[] { TasksText[0], TasksText[1], TasksText[2], TasksText[3] });
                    FastImgChange(new Image[] { Task1Img, Task2Img, Task3Img, Task4Img }, BmpersToX(Bmper(uriSources[1]), Bmper(uriSources[1]), Bmper(uriSources[1]), Bmper(uriSources[0])));
                    break;
                case 4:
                    AnyShowX(Task1, Task1Img);
                    FastTextChange(new Label[] { Task1 }, new string[] { TasksText[4] });
                    Task1Img.Source = Bmper(uriSources[0]);
                    break;
                case 5:
                    AnyShowX(Task1, Task2, Task1Img, Task2Img);
                    FastTextChange(new Label[] { Task1, Task2 }, new string[] { TasksText[4], TasksText[5] });
                    FastImgChange(new Image[] { Task1Img, Task2Img }, BmpersToX(Bmper(uriSources[1]), Bmper(uriSources[0])));
                    break;
                case 6:
                    AnyShowX(Task1, Task2, Task3, Task1Img, Task2Img, Task3Img);
                    FastTextChange(new Label[] { Task1, Task2, Task3 }, new string[] { TasksText[4], TasksText[5], TasksText[6] });
                    FastImgChange(new Image[] { Task1Img, Task2Img, Task3Img }, BmpersToX(Bmper(uriSources[1]), Bmper(uriSources[1]), Bmper(uriSources[0])));
                    break;
                default: AnyShowX(Task1, Task1Img); break;
            }
            FastTextChange(new Label[] { Describe1, Describe2 }, new string[] { "Выполняя задачи нужно оставаться предельно осторожным. Никто не\nзнает, что поджидает в святилищах древних.", "Текущие цели" });            
            AnyShowX(Describe1, Describe2, DescribeHeader);
        }
        private void Tasks_Click(object sender, RoutedEventArgs e) { HeroTasks(); }
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            if (!Items0.IsEnabled) Dj(Path.GameNoises.BagClose);
            MegaHide();
            RightPanelMenuTurnON();
            Info.IsEnabled = false;
            GameMenu.InfoChange1 = 0;
            FastInfoChange(new TextBlock[] { InfoText1, InfoText2, InfoText3 }, new Label[] { InfoHeaderText1, InfoHeaderText2, InfoHeaderText3 }, new string[] { GameMenu.HelpInfo2[0, GameMenu.InfoChange1], GameMenu.HelpInfo2[1, GameMenu.InfoChange1], GameMenu.HelpInfo2[2, GameMenu.InfoChange1] }, new string[] { GameMenu.HelpInfo1[0, GameMenu.InfoChange1], GameMenu.HelpInfo1[1, GameMenu.InfoChange1], GameMenu.HelpInfo1[2, GameMenu.InfoChange1] });
            FastTextChange(new Label[] { InfoIndex, Describe1, Describe2 }, new string[] { GameMenu.InfoChange1 + 1 + "/19", "Герой! Контролируй прогресс\nу точек контроля со знаком \"S\"", "Руководство игрока" });
            AnyShowX(DescribeHeader, Describe1, Describe2, InfoHeaderText1, InfoHeaderText2, InfoHeaderText3, InfoIndex, InfoIndexPlus, InfoText1, InfoText2, InfoText3);
        }
        private void FastInfoChange(TextBlock[] Texts, Label[] Headers, in string[] text, in string[] content) { for (Byte i = 0; i < Headers.Length; i++) { Headers[i].Content = content[i]; Texts[i].Text = text[i]; } }
        private void FastImgChange(Image[] ImageArray, BitmapImage[] bitmapImage) { for (Byte i = 0; i < ImageArray.Length; i++) ImageArray[i].Source = bitmapImage[i]; }
        private void InfoIndexPlus_Click(object sender, RoutedEventArgs e)
        {
            GameMenu.InfoChange1 += 1;
            FastInfoChange(new TextBlock[] { InfoText1, InfoText2, InfoText3 }, new Label[] { InfoHeaderText1, InfoHeaderText2, InfoHeaderText3 }, new string[] { GameMenu.HelpInfo2[0, GameMenu.InfoChange1], GameMenu.HelpInfo2[1, GameMenu.InfoChange1], GameMenu.HelpInfo2[2, GameMenu.InfoChange1] }, new string[] { GameMenu.HelpInfo1[0, GameMenu.InfoChange1], GameMenu.HelpInfo1[1, GameMenu.InfoChange1], GameMenu.HelpInfo1[2, GameMenu.InfoChange1] });
            InfoIndex.Content = (GameMenu.InfoChange1 + 1) + "/19";
            ButtonShow(InfoIndexMinus);
            if (GameMenu.InfoChange1 >= 18) ButtonHide(InfoIndexPlus);
        }
        private void InfoIndexMinus_Click(object sender, RoutedEventArgs e)
        {
            GameMenu.InfoChange1 -= 1;
            FastInfoChange(new TextBlock[] { InfoText1, InfoText2, InfoText3 }, new Label[] { InfoHeaderText1, InfoHeaderText2, InfoHeaderText3 }, new string[] { GameMenu.HelpInfo2[0, GameMenu.InfoChange1], GameMenu.HelpInfo2[1, GameMenu.InfoChange1], GameMenu.HelpInfo2[2, GameMenu.InfoChange1] }, new string[] { GameMenu.HelpInfo1[0, GameMenu.InfoChange1], GameMenu.HelpInfo1[1, GameMenu.InfoChange1], GameMenu.HelpInfo1[2, GameMenu.InfoChange1] });
            InfoIndex.Content = GameMenu.InfoChange1 + 1 + "/19";
            ButtonShow(InfoIndexPlus);
            if (GameMenu.InfoChange1 <= 0) ButtonHide(InfoIndexMinus);
        }
        private void PharaohBattle_MediaEnded(object sender, RoutedEventArgs e)
        {
            ImgHide(Img2);
            Sound1.Stop();
            MediaHide(PharaohBattle);
            Dj(Path.GameNoises.Danger);
            MediaShow(Med2);
        }
        private void TheEnd_MediaEnded(object sender, RoutedEventArgs e)
        {
            HideFightIconPersActions();
            WonOrDied();
            switch (Super1.MenuTask)
            {
                case 3: MediaShowAdvanced(TheEnd, Ura(Path.CutScene.Fin_Chapter1), new TimeSpan(0, 0, 0, 0, 0)); HeyPlaySomething(Path.GameMusic.AncientKey); Super1.MenuTask++; Img1.Source = Bmper(Path.Backgrounds.Normal); break;
                case 4: MediaShowAdvanced(ChapterIntroduction, Ura(Path.CutScene.PreChapter2), new TimeSpan(0, 0, 0, 0, 0)); break;
                case 6: MediaShowAdvanced(TheEnd, Ura(Path.CutScene.Fin_Chapter2), new TimeSpan(0, 0, 0, 0, 0)); HeyPlaySomething(Path.GameMusic.AncientKey); Super1.MenuTask++; Img1.Source = Bmper(Path.Backgrounds.Normal);  break;
                case 7: MediaShowAdvanced(ChapterIntroduction, Ura(Path.CutScene.PreChapter3), new TimeSpan(0, 0, 0, 0, 0));  break;
                case 10: MediaShowAdvanced(TheEnd, Ura(Path.CutScene.Titres), new TimeSpan(0, 0, 0, 0, 0)); HeyPlaySomething(Path.GameMusic.SayGoodbye); break;
                default: Form1.Close(); break;
            }
        }
        private void Sound3_MediaEnded(object sender, RoutedEventArgs e) { Sound3.Stop(); Sound3.Position = new TimeSpan(0, 0, 0, 0, 0); }
        private void Win_MediaOpened(object sender, RoutedEventArgs e) { WonOrDied(); }
        private void Trgt_MediaFailed(object sender, ExceptionRoutedEventArgs e) { Trgt.Stop(); Trgt.Play(); }
        private void Med1_MediaOpened(object sender, RoutedEventArgs e) { AnyHideX(Button1, Img1, Lab1, Skip1); }
        private void PharaohBattle_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            AnyHideX(PharaohBattle, Img2);
            Sound1.Stop();
            Dj(Path.GameNoises.Danger);
            MediaShow(Med2);
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e) { if (Img2.IsEnabled) Img2.Source = Bmper(e.Key == Key.W ? Path.Ray.StaticUp : e.Key == Key.A ? Path.Ray.StaticLeft : e.Key == Key.D ? Path.Ray.StaticRight : Path.Ray.StaticDown); }
        private void SwitchAbils_Click(object sender, RoutedEventArgs e){ InBattleHighSkillsMenu(); }
        private void RemoveButtons_MouseEnter(object sender, MouseEventArgs e)
        {
            Byte[] EquipQuality = { Super1.PlayerEQ[0], Super1.PlayerEQ[1], Super1.PlayerEQ[2], Super1.PlayerEQ[3] };
            Label[] EquipLabels = { AddATK1, AddDEF1, AddDEF1, AddDEF1 };
            Button[] Buttons = { Remove1, Remove2, Remove3, Remove4 };
            for (Byte i = 0; i < EquipQuality.Length; i++)
                if (sender.Equals(Buttons[i]))
                {
                    EquipLabels[i].Foreground = new SolidColorBrush(Color.FromRgb(199, 15, 15));
                    EquipLabels[i].Content = "-" + EquipQuality[i];
                    LabShow(EquipLabels[i]);
                    break;
                }
        }
        private void RemoveButtons_MouseLeave(object sender, MouseEventArgs e) { LabHide(sender.Equals(Remove1) ? AddATK1 : AddDEF1); }
        private void CheckAccessMaterials(in UInt16[] bag, Button[] btn) { for (Byte i = 0; i < btn.Length; i++) if (BAG.Materials >= bag[i]) ButtonShow(btn[i]); else ButtonHide(btn[i]); }
        private void TooManyItems(in Byte[] bag, Button[] btn) { for (Byte i = 0; i < btn.Length; i++) btn[i].IsEnabled = bag[i] < 255; }
        private void FastBtnsDisable(in Boolean Logic, params Button[] buttons) { foreach (Button btn in buttons) btn.IsEnabled = false; }
        private void CraftSwitch_Click(object sender, RoutedEventArgs e)
        {
            if (CraftSwitch.Content.ToString() == "Создание") {
                FastBtnsDisable(false, Bandage, Ether1, Antidote, Fused, Herbs1, Ether2Out, SleepBag1, Elixir1);
                LabHideX(new Label[] { AntidoteText, BandageText, EtherText, FusedText, HerbsText, Ether2OutText, SleepBagText, ElixirText });
                CheckAccessMaterials(new UInt16[] { 10, 20, 70, 150, 500, 1500, 100, 10000 }, new Button[] { CraftAntidote, CraftBandage, CraftEther, CraftFused, CraftHerbs, CraftEther2, CraftBedbag, CraftElixir });
                if (!BAG.ArmBoots[3]) CheckAccessMaterials(new UInt16[] { 30000 }, new Button[] { CraftPerfboots });
                TooManyItems(new Byte[] { BAG.AntidoteITM, BAG.BandageITM, BAG.EtherITM, BAG.FusedITM, BAG.HerbsITM, BAG.Ether2ITM, BAG.SleepBagITM, BAG.ElixirITM }, new Button[] { CraftAntidote, CraftBandage, CraftEther, CraftFused, CraftHerbs, CraftEther2, CraftBedbag, CraftElixir });
                CraftSwitch.Content = "Инвентарь";
            } else
            {
                MegaHide();
                HeroItems();
            }
        }
        private void AbilsMenu_Click(object sender, RoutedEventArgs e)
        {
            Button[] abils = new Button[] { Cure1, Cure2Out, Heal1, Torch1, Whip1, Super0 };
            string[] uris = new string[] { Path.GameNoises.Cure, Path.GameNoises.Cure, Path.GameNoises.Heal, Path.GameNoises.Torch, Path.GameNoises.Whip, Path.GameNoises.Super };
            for (Byte i=0;i< abils.Length; i++) if (sender.Equals(abils[i])) Dj(uris[i]);
            if (sender.Equals(Cure1)) Super1.SetCurrentHpAp(Convert.ToUInt16(Super1.CurrentHP + Convert.ToUInt16(Super1.Special * 2) >= Super1.MaxHP ? Super1.MaxHP : Super1.CurrentHP + Convert.ToUInt16(Super1.Special * 2)), Convert.ToUInt16(Super1.CurrentAP - 5));
            if (sender.Equals(Cure2Out)) Super1.SetCurrentHpAp(Super1.MaxHP, Convert.ToUInt16(Super1.CurrentAP - 10));
            if (sender.Equals(Heal1)) { Super1.PlayerStatus = 0; Super1.CurrentAP -= 3; }
            RefreshAllHPAP();
            MenuHpApExp();
        }
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Settings.IsEnabled = false;
            MegaHide();
            ChbShow(TimerTurnOn);
            HeroSettings();
        }
        private void MusicLoud_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Sound1.Volume = MusicLoud.Value;
            if (MusicPercent != null) MusicPercent.Content = Convert.ToByte(Sound1.Volume * 100) + "%";
        }
        private void SoundsLoud_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Sound3.Volume = SoundsLoud.Value;
            if (!Button1.IsEnabled) SEF(Path.GameSounds.ChestOpened);
            if (SoundsPercent != null) SoundsPercent.Content = Convert.ToByte(Sound3.Volume * 100) + "%";

        }
        private void NoiseLoud_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Sound2.Volume = NoiseLoud.Value;
            if (!Button1.IsEnabled) Dj(Path.GameNoises.Torch);
            if (NoisePercent != null) NoisePercent.Content = Convert.ToByte(Sound2.Volume * 100) + "%";
        }
        private void GameSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) { if (GameSpeedX != null) GameSpeedX.Content = "x" + Math.Round(GameSpeed.Value, 2); }
        private void Brightness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (BrightnessPercent != null)
            {
                BrightnessImg.Opacity = 1 - Brightness.Value;
                BrightnessPercent.Content = Convert.ToByte(Brightness.Value * 100) + "%";
            }
        }
        private void HeroSettings()
        {
            RightPanelMenuTurnON();
            AnyShowX(MusicText, SoundsText, NoiseText, GameSpeedText, BrightnessText, MusicPercent, SoundsPercent, NoisePercent, BrightnessPercent, GameSpeedX, MusicLoud, SoundsLoud, NoiseLoud, GameSpeed, Brightness, DescribeHeader, Describe1, Menu1);
            FastTextChange(new Label[] { Describe2 }, new string[] { "Настройки", "Настройки помогают определить предпочтения. Помимо стандартного\nизменения громкости и яркости, вы можете регулировать скорость боя" });
        }
        private void TimerTurnOn_Checked(object sender, RoutedEventArgs e) { TimeRecord.Stop(); }
        private void TimerTurnOn_Unchecked(object sender, RoutedEventArgs e) { WidelyUsedAnyTimer(out TimeRecord, WorldRecord, new TimeSpan(0, 0, 0, 0, 1)); }
        private void AnyEquipments_MouseLeave(object sender, MouseEventArgs e) { LabHideX(new Label[] { AddATK1, AddDEF1 }); }
        private void EquipCollectInfo(string describe, Label Stat, string statrise)
        {
            Describe1.Content = describe;
            LabShow(Stat);
            Stat.Content = statrise;
            Stat.Foreground = new SolidColorBrush(Color.FromRgb(255, 210, 6));
        }
        private void OnEquiped(Button EquipButton, Label Equips, in string equipment, in Byte ArmClass, in Byte EqPower)
        {
            EquipButton.IsEnabled = false;
            Equips.Content = equipment;
            Super1.PlayerEQ[ArmClass] = EqPower;
            switch (ArmClass)
            {
                case 0: BAG.Hands = false; break;
                case 1: BAG.Jacket = false; break;
                case 2: BAG.Legs = false; break;
                case 3: BAG.Boots = false; break;
                default: BAG.Hands = false; break;
            }
        }
        private void WidelyUsedAnyTimer(out System.Windows.Threading.DispatcherTimer timer, EventHandler SomeEvent, TimeSpan timeSpan)
        {
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(SomeEvent);
            timer.Interval = timeSpan;
            timer.Start();
        }
        private void MediaShowAdvanced(MediaElement Media, Uri Source, TimeSpan timeSpan)
        {
            Media.Stop();
            Media.Source = Source;
            Media.Position = timeSpan;
            Media.Play();
        }
        private void CurrentPlayer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (AutorizeImg.Source.ToString().Contains(Path.Backgrounds.UnRegister)) AnyHideX(AddProfile, DeleteProfile, Player1, Player2, Player3, Player4, Player5, Player6, AddPlayer); else CheckRecords();
            AutorizeImg.Source = Bmper(AutorizeImg.Source.ToString().Contains(Path.Backgrounds.UnRegister) ? Path.Backgrounds.Register : Path.Backgrounds.UnRegister);
        }
        private void TBoxShow(TextBox tbx) { tbx.Visibility = Visibility.Visible; tbx.IsEnabled = true; }
        private void TBoxHide(TextBox tbx) { tbx.Visibility = Visibility.Hidden; tbx.IsEnabled = false; }
        private void AddProfile_Click(object sender, RoutedEventArgs e)
        {
            AddPlayer.Text = (AddPlayer.Text == "Никем быть нельзя!") || (AddPlayer.Text == "Один уже есть") ? "" : AddPlayer.Text;
            if (AddPlayer.Text != "")
            {
                foreach (string str in DataBaseMSsql.PlayerLogins) if (AddPlayer.Text == str) { AddPlayer.Text = "Один уже есть"; return; }
                try
                {
                    DataBaseMSsql.NewPlayer(AddPlayer.Text);
                    DataBaseMSsql.CheckAllRecordedPlayers();
                    DataBaseMSsql.GetCurrentPlayer();
                    AnyHideX(AddPlayer, AddProfile);
                    AddPlayer.Text = "";
                    CheckRecords();
                }
                catch (Exception ex) { throw new Exception("Something get wrong, Read this: " + ex); }
            }
            else AddPlayer.Text = "Никем быть нельзя!";
        }
        private void AddPlayer_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            AddPlayer.Text = (AddPlayer.Text == "Никем быть нельзя!") || (AddPlayer.Text == "Один уже есть") ? "" : AddPlayer.Text;
            Regex regex = new Regex("[^0-9a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        public static Byte ProfileSelected = 0;
        private void CheckRecords()
        {
            Label[] Profiles = new Label[] { Player1, Player2, Player3, Player4, Player5, Player6 };
            Byte[] RowGrid = new Byte[] { 3, 5, 7, 9, 11, 13 };
            Byte rem = 0;
            if (DataBaseMSsql.PlayerLogins.Count < 6)
            {
                for (Byte i = 0; i <DataBaseMSsql.PlayerLogins.Count; i++)
                {
                    Profiles[i].Content =DataBaseMSsql.PlayerLogins[i];
                    LabShow(Profiles[i]);
                    BtnGrid(AddProfile, RowGrid[i], 0);
                    rem++;
                }
                Grid.SetRow(AddPlayer, RowGrid[rem]);
                Grid.SetRow(AddProfile, RowGrid[rem]);
                rem = 0;
                AnyShowX(AddProfile, AddPlayer);
            }
            else for (Byte i = 0; i <DataBaseMSsql.PlayerLogins.Count; i++) { Profiles[i].Content =DataBaseMSsql.PlayerLogins[i]; LabShow(Profiles[i]); }
        }
        private void OnPlayers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Label[] Players = { Player1, Player2, Player3, Player4, Player5, Player6 };
            Byte[] Btngrid = { 3, 5, 7, 9, 11, 13 };
            for (Byte i=0;i<Players.Length;i++)
                if (sender.Equals(Players[i]))
                {
                    DataBaseMSsql.CurrentLogin = DataBaseMSsql.PlayerLogins[i];
                    CurrentPlayer.Content = DataBaseMSsql.CurrentLogin;
                    BtnGrid(DeleteProfile, Btngrid[i], 0);
                    ButtonShow(DeleteProfile);
                    Continue.IsEnabled = DataBaseMSsql.CheckIfPlayerCanContinue();
                    break;
                }
        }
        private void CancelDelete(object sender, MouseEventArgs e) { ButtonHide(DeleteProfile); }
        private void DeleteProfile_Click(object sender, RoutedEventArgs e)
        {
            DataBaseMSsql.DeletePlayer(DataBaseMSsql.CurrentLogin);
            DataBaseMSsql.CheckAllRecordedPlayers();
            CurrentPlayer.Content = DataBaseMSsql.GetCurrentPlayer();
            AnyHideX(Player1, Player2, Player3, Player4, Player5, Player6, DeleteProfile);
            CheckRecords();
        }
        private void AddPlayer_MouseEnter(object sender, RoutedEventArgs e) { AddPlayer.Text = ((AddPlayer.Text == "Никем быть нельзя!") || (AddPlayer.Text == "Один уже есть")) ? "": AddPlayer.Text; }
        private void SaveGame()
        {
            try
            {
                Byte[] CipherValue = new Byte[] { 1, 2, 4, 8 };
                DataBaseMSsql.SavePlayerBag(new string[] { "@LOGIN", "@BAN", "@ETR", "@ANT", "@FUS", "@HRB", "@ER2", "@SLB", "@ELX", "@MAT" }, new Object[] { DataBaseMSsql.CurrentLogin, BAG.BandageITM, BAG.EtherITM, BAG.AntidoteITM, BAG.FusedITM, BAG.HerbsITM, BAG.Ether2ITM, BAG.SleepBagITM, BAG.ElixirITM, BAG.Materials});
                DataBaseMSsql.SavePlayerEquip(new string[] { "@LOGIN", "@WPN", "@ARR", "@PNT", "@BOO", "@WPS", "@ARS", "@PTS", "@BTS" }, new Object[] { DataBaseMSsql.CurrentLogin, Convert.ToByte(Super1.PlayerEQ[0]), Convert.ToByte(Super1.PlayerEQ[1]), Convert.ToByte(Super1.PlayerEQ[2]), Convert.ToByte(Super1.PlayerEQ[3]), Convert.ToByte(Encoder(CipherValue, BAG.Weapon, Convert.ToByte(BAG.Weapon.Length))), Convert.ToByte(Encoder(CipherValue, BAG.Armor, Convert.ToByte(BAG.Armor.Length))), Convert.ToByte(Encoder(CipherValue, BAG.Pants, Convert.ToByte(BAG.Pants.Length))), Convert.ToByte(Encoder(CipherValue, BAG.ArmBoots, Convert.ToByte(BAG.ArmBoots.Length))) });
                DataBaseMSsql.SavePlayerSettings(new string[] { "@LOGIN", "@MUS", "@SND", "@NS", "@FS", "@BR", "@TMR" }, new Object[] { DataBaseMSsql.CurrentLogin, Convert.ToByte(MusicLoud.Value * 100), Convert.ToByte(SoundsLoud.Value * 100), Convert.ToByte(NoiseLoud.Value * 100), Convert.ToByte(GameSpeed.Value * 100), Convert.ToByte(Brightness.Value * 100), TimerTurnOn.IsChecked.Value });
                DataBaseMSsql.SavePlayerStats(new string[] { "@LOGIN", "@LV", "@LC", "@HP", "@AP", "@XP", "@TK", "@LN", "@TR" }, Super1.GetPlayerRecord(DataBaseMSsql.CurrentLogin));
            }
            catch (Exception ex)
            {
                //Byte[] CipherValue = new Byte[] { 1, 2, 4, 8 };
                //"Login: "+DataBaseMSsql.CurrentLogin+ "MATERIALS: " + Super1.CurrentHP.GetType() + "Arm: " + Super1.PlayerEQ[1] + "Legs: " + Super1.PlayerEQ[2] + "Bts: " + Super1.PlayerEQ[3] + "Wcp: " + Encoder(CipherValue, BAG.Weapon, Convert.ToByte(BAG.Weapon.Length))+ "Acp: "+ Encoder(CipherValue, BAG.Armor, Convert.ToByte(BAG.Armor.Length)) + "Lcp: " + Encoder(CipherValue, BAG.Pants, Convert.ToByte(BAG.Pants.Length)) + "Bcp: " + Encoder(CipherValue, BAG.ArmBoots, Convert.ToByte(BAG.ArmBoots.Length))+
                throw new Exception("Something get wrong, Read this: " + ex);
            }
        }
        private Byte Encoder(in Byte[] CipherValues, in Boolean[] ToEncode, in Byte length) { Byte Cipher = 0; for (Byte i = 0; i < length; i++) if (ToEncode[i]) Cipher += CipherValues[i]; return Cipher; }
        private Boolean[] Decoder(in Byte[] CipherValues, Byte Cipher, in Byte length)
        {
            Lab1.Content = "";
            Boolean[] Decipher = { false, false, false, false };
            for (Byte i = length; i > 0; i--)
                if (Cipher - CipherValues[i - 1] >= 0)
                {
                    Cipher -= CipherValues[i - 1];
                    Decipher[i - 1] = true;
                }
            return Decipher;
        }
        private Boolean GetValueFromDecoder(in Boolean[] Things, in Byte If) { foreach (Boolean bl in Things) if (bl && (If == 0)) return true; return false; }
        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            Object[] Bag=DataBaseMSsql.CheckPlayerBag(DataBaseMSsql.CurrentLogin, new Object[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            BAG.ItemsSet(Convert.ToByte(Bag[0]), Convert.ToByte(Bag[1]), Convert.ToByte(Bag[2]), Convert.ToByte(Bag[3]), Convert.ToByte(Bag[4]), Convert.ToByte(Bag[5]), Convert.ToByte(Bag[6]), Convert.ToByte(Bag[7]), Convert.ToUInt16(Bag[8]));

            Byte[] ByteEquip = DataBaseMSsql.CheckPlayerEquip(DataBaseMSsql.CurrentLogin, new Byte[] { 0, 0, 0, 0, 0, 0, 0, 0 });
            Super1.SetAllEquip(ByteEquip[0], ByteEquip[1], ByteEquip[2], ByteEquip[3]);
            Byte[] Ciphers = { ByteEquip[4], ByteEquip[5], ByteEquip[6], ByteEquip[7] };

            Bag = DataBaseMSsql.GetPlayerRecord(DataBaseMSsql.CurrentLogin, new Object[] { 0, 0, 0, 0, 0, 0, 0 });
            Super1.CurrentLevel = Convert.ToByte(Bag[0]);
            Super1.MenuTask= Convert.ToByte(Bag[1]);
            Super1.SetCurrentHpAp(Convert.ToUInt16(Bag[2]), Convert.ToUInt16(Bag[3]));
            Super1.Experience = Convert.ToUInt16(Bag[4]);
            Super1.MiniTask = Convert.ToBoolean(Bag[5]);
            Super1.Learned = Convert.ToByte(Bag[6]);

            NextExpBar.Value = Super1.Experience;
            NextExpBar.Maximum = Super1.NextLevel[Super1.CurrentLevel - 1];
            ExpBar1.Value = NextExpBar.Value;
            RefreshAllHPAP();

            Bag = DataBaseMSsql.GetPlayerStats(DataBaseMSsql.CurrentLogin, new Object[] { 0, 0, 0, 0, 0, 0 });
            Super1.SetStats(Super1.CurrentLevel, Convert.ToUInt16(Bag[0]), Convert.ToUInt16(Bag[1]), Convert.ToByte(Bag[2]), Convert.ToByte(Bag[3]), Convert.ToByte(Bag[4]), Convert.ToByte(Bag[5]));

            ByteEquip = DataBaseMSsql.GetPlayerSettings(DataBaseMSsql.CurrentLogin, new Byte[] { 0, 0, 0, 0, 0, 0 });
            SettingsSetAll(ByteEquip);

            Byte[] CipherValue = new Byte[] { 1, 2, 4, 8 };
            BAG.Weapon = Decoder(CipherValue, Ciphers[0], Convert.ToByte(BAG.Weapon.Length));
            BAG.Hands = GetValueFromDecoder(BAG.Weapon, Super1.PlayerEQ[0]);

            BAG.Armor = Decoder(CipherValue, Ciphers[1], Convert.ToByte(BAG.Armor.Length));
            BAG.Jacket = GetValueFromDecoder(BAG.Armor, Super1.PlayerEQ[1]);

            BAG.Pants = Decoder(CipherValue, Ciphers[2], Convert.ToByte(BAG.Pants.Length));
            BAG.Legs = GetValueFromDecoder(BAG.Pants, Super1.PlayerEQ[2]);

            BAG.ArmBoots = Decoder(CipherValue, Ciphers[3], Convert.ToByte(BAG.ArmBoots.Length));
            BAG.Boots = GetValueFromDecoder(BAG.ArmBoots, Super1.PlayerEQ[3]);
            ContinueQuest();
        }

        private void MapCheck(in Byte Loc)
        {
            switch (Loc)
            {
                case 0: Location1_AncientPyramid(); break;
                case 1: Location2_WaterTemple(); break;
                case 2: Location3_LavaTemple(); break;
            }
        }
        private void SettingsSetAll(params Byte[] SettingValues)
        {
            Slider[] Sliders = { MusicLoud, SoundsLoud, NoiseLoud, GameSpeed, Brightness };
            for (Byte i = 0; i < Sliders.Length; i++) Sliders[i].Value= Convert.ToDouble(SettingValues[i]) * 0.01;
            TimerTurnOn.IsChecked = Convert.ToBoolean(SettingValues[5]);
        }
        private void PlayerSetLocation(in Byte row, in Byte column)
        {
            Adoptation.ImgYbounds = row;
            Adoptation.ImgXbounds = column;
            AnyGrid(Img2, row, column);
        }
        private void Location1_AncientPyramid()
        {
            ChestsAndTablesAllTurnOn1();
            switch (Super1.MenuTask)
            {
                case 0: Map1ModelsAllTurnOn1(); break;
                case 1: ImgShowX(new Image[] { KeyImg3, LockImg3, KeyImg2, LockImg2 }); ChangeMapToVoidOrWallX(new Byte[] { 101, 131 }, 0); Sets.EnemyRate++; break;
                case 2: ImgShowX(new Image[] { KeyImg3, LockImg3 }); ChangeMapToVoidOrWallX(new Byte[] { 101, 131, 102, 132 }, 0); Sets.EnemyRate += 2; break;
                case 3: ChangeMapToVoidOrWallX(new Byte[] { 101, 131, 102, 132, 103, 133 }, 0); Sets.EnemyRate += 3; break;
            }
            ImgGridX(new Image[] { ChestImg1, ChestImg2, ChestImg3, ChestImg4, Table1, Table2, Table3, Threasure1, SaveProgress }, new Byte[] { 27, 24, 7, 9, 33, 25, 10, 4, 17 }, new Byte[] { 19, 11, 21, 20, 18, 13, 38, 36, 29 });
            PlayerSetLocation(17, 29);
            Sets.LockIndex = Convert.ToByte(3 - Super1.MenuTask);
        }
        private void Location2_WaterTemple()
        {
            Byte[] EnemyRates = { 2, 3, 4, 5, 3, 5, 5 };
            Sets.EnemyRate = EnemyRates[Super1.MenuTask];
            AnyGridX(new Image[] { ChestImg1, ChestImg2, ChestImg3, ChestImg4, Table1, Table2, Table3, Threasure1, SaveProgress }, new Byte[] { 9, 21, 10, 8, 29, 22, 22, 16, 28 }, new Byte[] { 8, 10, 24, 35, 49, 23, 2, 4, 20 });
            ChestsCheck(BAG.Pants[3], 213, SecretChestImg1);
            ChestsCheck(Super1.MiniTask, 232, SecretChestImg2);
            AnyHideX(Super1.MenuTask>5?new Image[] { JailImg1, JailImg5, JailImg6, JailImg7 } : new Image[] { JailImg1 });
            ChangeMapToVoidOrWallX(Super1.MenuTask > 5 ? new byte[] { 134,136,137,138,104,106,107,108 }: new byte[] { 134,104 }, 0);
            AnyShowX(SecretChestImg1, SecretChestImg2);
            PlayerSetLocation(Convert.ToByte(Super1.MenuTask>4?28:34), Convert.ToByte(Super1.MenuTask > 4 ?20: 51));
        }
        private void Location3_LavaTemple()
        {
            Sets.EnemyRate = 5;
            //FastImgChange(new Image[] { Img1 }, BmpersToX(Bmper(Path.Backgrounds.Location3)));
            AnyShowX(ChestImg1, ChestImg2, ChestImg3, ChestImg4, Table1, Table2, Table3, Boulder1, JailImg1, JailImg2, JailImg5, Lever1, Lever2, Lever3);
            AnyGridX(new Image[] { ChestImg1, ChestImg2, ChestImg3, ChestImg4, Table1, Table2, Table3, Threasure1, SaveProgress, Boulder1, JailImg1, JailImg2, JailImg5 }, new Byte[] { 17, 22, 28, 26, 17, 1, 1, 2, 18, 20, 28, 21, 25 }, new Byte[] { 4, 23, 38, 56, 27, 9, 50, 28, 28, 46, 37, 46, 48 });
            AnyHideX(new Image[] { JailImg3, JailImg6, JailImg7, SecretChestImg1, SecretChestImg2 });
            //AnyHideX(Super1.MenuTask > 5 ? new Image[] { JailImg1, JailImg5, JailImg6, JailImg7 } : new Image[] { JailImg1 });
            //ChangeMapToVoidOrWallX(Super1.MenuTask > 5 ? new byte[] { 134, 136, 137, 138, 104, 106, 107, 108 } : new byte[] { 134, 104 }, 0);
            //AnyShowX(SecretChestImg1, SecretChestImg2);
            PlayerSetLocation(Convert.ToByte(18), Convert.ToByte(28));
        }
        private void ContinueQuest()
        {
            CurrentLocation = Convert.ToByte((Super1.MenuTask > 6) ? 2 : (Super1.MenuTask >= 4) && (Super1.MenuTask <= 6)? 1 : 0);
            MapBuild(CurrentLocation);
            MapCheck(CurrentLocation);
            if (CheckMapIfModelExists(7)) ImgShow(Boulder1);
            string[] music = new string[] { Path.GameMusic.AncientPyramid, Path.GameMusic.WaterTemple, Path.GameMusic.LavaTemple };
            Uri[] ambushed = new Uri[] { Ura(Path.CutScene.Ambushed), Ura(Path.CutScene.BattleStations), Ura(Path.CutScene.BattleStations) };
            BitmapImage[] battlegrounds = BmpersToX(Bmper(Path.Fighting.Battle1), Bmper(Path.Fighting.Battle2), Bmper(Path.Fighting.Battle2));
            BitmapImage[] location = BmpersToX(Bmper(Path.Backgrounds.Location1), Bmper(Path.Backgrounds.Location2), Bmper(Path.Backgrounds.Location3));
            BitmapImage[] threasures = BmpersToX(Bmper(Path.MapModels.Artifact1), Bmper(Path.MapModels.Artifact2), Bmper(Path.MapModels.Artifact3));
            ChestsCheck(BAG.Weapon[CurrentLocation], 203, ChestImg3);
            ChestsCheck(BAG.Armor[CurrentLocation], 201, ChestImg1);
            ChestsCheck(BAG.Pants[CurrentLocation], 204, ChestImg4);
            ChestsCheck(BAG.ArmBoots[CurrentLocation], 202, ChestImg2);
            FastImgChange(new Image[] { Img3, Img1, Threasure1 }, BmpersToX(battlegrounds[CurrentLocation], location[CurrentLocation], threasures[CurrentLocation]));
            Med2.Source = ambushed[CurrentLocation];
            HeyPlaySomething(music[CurrentLocation]);
            ChestsAndTablesAllTurnOn1();
            ImgShowX(new Image[] { Img1, Threasure1, Img2, SaveProgress });
            ContinueCheckPoints();
        }
        private void ChestsCheck(in Boolean CheckValue, in Byte OnMap, Image Chest)
        {
            BitmapImage[] chestvercl = BmpersToX(Bmper(Path.MapModels.ChestClosed1), Bmper(Path.MapModels.ChestClosed2), Bmper(Path.MapModels.ChestClosed3));
            BitmapImage[] chestverop = BmpersToX(Bmper(Path.MapModels.ChestOpened1), Bmper(Path.MapModels.ChestOpened2), Bmper(Path.MapModels.ChestOpened3));
            Chest.Source = CheckValue ? chestverop[CurrentLocation] : chestvercl[CurrentLocation];
            if (CheckValue) ChangeMapToWall(OnMap);
        }
        private void ContinueCheckPoints()
        {
            AnyHideX(Lab1, CurrentPlayer, Player1, Player2, Player3, Player4, Player5, Player6, Continue, DeleteProfile, AddProfile, Button1, AutorizeImg);
            TBoxHide(AddPlayer);
            MaxAndWidthHPcalculate();
            MaxAndWidthAPcalculate();
            RefreshAllHPAP();
            if (Super1.CurrentLevel >= 25)
            {
                Super1.Experience = Convert.ToUInt16(NextExpBar.Maximum);
                NextExpBar.Value = NextExpBar.Maximum;
                ExpBar1.Value = ExpBar1.Maximum;
                FastTextChange(new Label[] { ExpText, Exp1 }, new string[] { "Профессионал", "Профессионал" });
            }
            else
            {
                NextExpBar.Value = Super1.Experience;
                ExpBar1.Maximum = Super1.NextLevel[Super1.CurrentLevel - 1];
                ExpBar1.Value = NextExpBar.Value;
                FastTextChange(new Label[] { ExpText, Exp1 }, new string[] { "Опыт " + NextExpBar.Value + "/" + NextExpBar.Maximum, "Опыт " + ExpBar1.Value + "/" + ExpBar1.Maximum });

            }
            WeaponCheckPoint();
            ArmorCheckPoint();
            PantsCheckPoint();
            BootsCheckPoint();
        }
        private void WeaponCheckPoint()
        {
            switch (Super1.PlayerEQ[0])
            {
                case 10: EquipH.Content = "Костяной кастет"; break;
                case 50: EquipH.Content = "Древний кинжал"; break;
                case 200: EquipH.Content = "Легендарный меч"; break;
                case 165: EquipH.Content = "Миниган XM214-A"; break;
                default: break;
            }
        }
        private void ArmorCheckPoint()
        {
            switch (Super1.PlayerEQ[1])
            {
                case 5: EquipB.Content = "Чёрный кожак"; break;
                case 25: EquipB.Content = "Древняя броня"; break;
                case 90:  EquipB.Content = "Броня легенд"; break;
                case 85: EquipB.Content = "Футболка крутого"; break;
                default: break;
            }
        }
        private void PantsCheckPoint()
        {
            switch (Super1.PlayerEQ[2])
            {
                case 4: EquipL.Content = "Штаны стервятника"; break;
                case 15: EquipL.Content = "Поножи воина"; break;
                case 65: EquipL.Content = "Поножи легенды"; break;
                case 55: EquipL.Content = "Штаны серьёзного"; break;
                default: break;
            }
        }
        private void BootsCheckPoint()
        {
            switch (Super1.PlayerEQ[3])
            {
                case 1:  EquipD.Content = "Бинтовая обувь"; break;
                case 10: EquipD.Content = "Сапоги мужества"; break;
                case 45: EquipD.Content = "Легендарная обувь"; break;
                case 25: EquipD.Content = "Армейские ботинки"; break;
                default: break;
            }
        }
        private void ReplaceModel(in Byte y, in Byte x, in Byte Model) { MapScheme[y, x]=Model; }
        private Byte[] CheckModelCoord(in Byte Condition)
        {
            for (Byte i = 0; i < MapScheme.GetLength(0); i++) for (Byte j = 0; j < MapScheme.GetLength(1); j++) if (MapScheme[i, j] == Condition) return new Byte[] { i, j };
            return new Byte[] { 0, 0 };
        }
        private Boolean CheckMapIfModelExists(in Byte Condition)
        {
            for (Byte i = 0; i < MapScheme.GetLength(0); i++) for (Byte j = 0; j < MapScheme.GetLength(1); j++) if (MapScheme[i, j] == Condition) return true;            
            return false;
        }
        private void ChangeMapToVoid(in Byte Condition) { for (Byte i = 0; i < MapScheme.GetLength(0); i++) for (Byte j = 0; j < MapScheme.GetLength(1); j++) if (MapScheme[i, j] == Condition) MapScheme[i, j] = 0; }
        private void ChangeMapToVoid(in Byte Row, in Byte Col,  params Image[] Imgs)
        {
            foreach (Image img in Imgs) if ((Bits(img.GetValue(Grid.RowProperty))==Row)&&(Bits(img.GetValue(Grid.ColumnProperty)) == Col)) { AnyHide(img); MapScheme[Row, Col] = 0; }
        }
        private void ChangeMapToVoidOrWallX(in Byte[] Conditions, in Byte Model) { foreach (Byte Condition in Conditions) if (Model==0) ChangeMapToVoid(Condition); else ChangeMapToWall(Condition); }
        private void ChangeMapToWall(in Byte Condition) { for (Byte i = 0; i < MapScheme.GetLength(0); i++) for (Byte j = 0; j < MapScheme.GetLength(1); j++) if (MapScheme[i, j] == Condition) MapScheme[i, j] = 1; }
        private void AbilsMenu_MouseLeave(object sender, MouseEventArgs e) { LabHide(AbilsCost); }
        private void Cure2_Click(object sender, RoutedEventArgs e)
        {
            Super1.SetCurrentHpAp(Super1.MaxHP, Convert.ToUInt16(Super1.CurrentAP-10));
            PersonTextAnimationStart(Cure2_Time_Tick27, CureHP2_Time_Tick28, Convert.ToUInt16(25 / GameSpeed.Value), Convert.ToUInt16(75 / GameSpeed.Value));
            Dj(Path.GameNoises.Cure);
            CurrentHpApCalculate();
            AbilitiesMakeDisappear1();
            Time1.Value = 0;
        }
        private void BuffUp_Click(object sender, RoutedEventArgs e)
        {
            AbilityBonuses[0] = Super1.Special;
            Super1.CurrentAP -= 12;
            PersonTextAnimationStart(BuffUp_Time_Tick29, BuffUpVal_Time_Tick30, Convert.ToUInt16(25 / GameSpeed.Value), Convert.ToUInt16(75 / GameSpeed.Value));            
            CurrentAPcalculate();
            AbilitiesMakeDisappear1();
            Time1.Value = 0;
        }
        private void BuffUpVal_Time_Tick30(object sender, EventArgs e) { BuffUpTxt.Content = "+"+Super1.Special; BuffUpShow(); }
        private void BuffUpShow()
        {
            Byte[] RowSet2 = { 22, 21, 20, 19, 18 };
            if (!BuffUpTxt.IsEnabled) LabShow(BuffUpTxt);
            if (CureCurrent == RowSet2.Length - 1)
            {
                CureCurrent = 0;
                timer11.Stop();
                LabHide(BuffUpTxt);
            }
            else { Grid.SetRow(BuffUpTxt, RowSet2[CureCurrent]); CureCurrent++; }
        }
        private void ToughenUp_Click(object sender, RoutedEventArgs e)
        {
            AbilityBonuses[1] = Super1.Special;
            Super1.CurrentAP -= 8;
            PersonTextAnimationStart(Toughen_Time_Tick31, BuffUpVal_Time_Tick30, Convert.ToUInt16(25 / GameSpeed.Value), Convert.ToUInt16(75 / GameSpeed.Value));            
            CurrentAPcalculate();
            AbilitiesMakeDisappear1();
            Time1.Value = 0;
        }
        private void Regen_Click(object sender, RoutedEventArgs e)
        {
            Super1.CurrentAP -= 15;
            PersonTextAnimationStart(Regen_Time_Tick32, RegenHP_Time_Tick33, Convert.ToUInt16(25 / GameSpeed.Value), Convert.ToUInt16(6375 / Super1.Special / GameSpeed.Value));
            HPRegenerate.IsEnabled = true;
            CurrentAPcalculate();
            AbilitiesMakeDisappear1();
            Time1.Value = 0;
        }
        private void Control_Click(object sender, RoutedEventArgs e)
        {
            PersonTextAnimationStart(Control_Time_Tick35, ControlAP_Time_Tick34, Convert.ToUInt16(25 / GameSpeed.Value), Convert.ToUInt16(6375 / Super1.Special / GameSpeed.Value));
            AbilitiesMakeDisappear1();
            APRegenerate.IsEnabled = true;
            Time1.Value = 0;
        }
        private void Thrower_Click(object sender, RoutedEventArgs e)
        {
            Sets.SelectedTarget = Convert.ToByte(Sets.SelectedTarget > 2 ? 0 : Sets.SelectedTarget);
            SelectedTrgt = Sets.SelectedTarget;
            SelectTarget();
            AbilitiesMakeDisappear1();
            BtnShowX(new Button[] { ACT3, Cancel2 });
        }
        private void ActionOnOne_Click(object sender, RoutedEventArgs e)
        {
            EventHandler[,] ActTime = { { Torch_Time_Tick13, Whip_Time_Tick14, Thrower_Time_Tick37 }, { TorchDmg_Time_Tick20, WhipDmg_Time_Tick21, Thrower_Time_Tick36 } };
            string[] ActSounds = { Path.GameNoises.Torch, Path.GameNoises.Whip, Path.GameNoises.Whip };
            Byte[] Cost = { 4, 6, 15 };
            Button[] Actions = { ACT1, ACT2, ACT3 };
            SelectedTrgt = Sets.SelectedTarget;
            Time1.Value = 0;
            for (Byte i = 0; i < Actions.Length; i++)
                if (sender.Equals(Actions[i]))
                {
                    Super1.CurrentAP -= Cost[i];
                    ACT(i);
                    Dj(ActSounds[i]);
                    AnyHideX(TrgtImg, Actions[i], Cancel2);
                    DmgTextAnimationStart(ActTime[0, i], ActTime[1, i], Convert.ToUInt16(25 / GameSpeed.Value), Convert.ToUInt16(50 / GameSpeed.Value));
                    break;
                }            
            CurrentAPcalculate();
            timer9.Stop();
        }
        private void ActionOnAll_Click(object sender, RoutedEventArgs e)
        {
            EventHandler[,] ActTime = { { Super_Time_Tick15, Tornado_Time_Tick38, Quake_Time_Tick43 }, { SuperDmg_Time_Tick22, TornadoDmg_Time_Tick39, QuakeDmg_Time_Tick44 } };
            string[] ActSounds = { Path.GameNoises.Super, Path.GameNoises.Super, Path.GameNoises.Super };
            Byte[] Cost = { 10, 20, 30 };
            UInt16[] AbilityPowers = { Convert.ToUInt16(Super1.Special * 2), Convert.ToUInt16(Super1.Special * 3), Convert.ToUInt16(Super1.Special * 4) };
            Button[] Actions = { Super, Tornado, Quake };
            SelectedTrgt = Sets.SelectedTarget;
            Time1.Value = 0;
            for (Byte i = 0; i < Actions.Length; i++)
                if (sender.Equals(Actions[i]))
                {
                    Super1.CurrentAP -= Cost[i];
                    AbilitySupers(AbilityPowers[i]);
                    Dj(ActSounds[i]);
                    AnyHideX(TrgtImg, Actions[i], Cancel2);
                    DmgTextAnimationStart(ActTime[0, i], ActTime[1, i], Convert.ToUInt16(25 / GameSpeed.Value), Convert.ToUInt16(50 / GameSpeed.Value));
                    break;
                }            
            CurrentAPcalculate();
        }
        private void AbilitiesInFight_MouseLeave(object sender, MouseEventArgs e) { LabHide(BattleText2); }
        private void AbilitiesInFight_MouseEnter(object sender, MouseEventArgs e)
        {
            Button[] buttons = { Cure, Cure2, Heal, BuffUp, ToughenUp, Regen, Control, Torch, Whip, Thrower, Super, Tornado, Quake, Learn };
            String[] ondescr = { "Восстановление ОЗ, [-2 ОД]", "ОЗ 100% мгновенно, [-10 ОД]", "Лечение статуса, [-3 ОД]", "Повышает атаку, [-12 ОД]", "Повышает защиту, [-8 ОД]", "Постепенно ОЗ+, [-15 ОД]", "Постепенно ОД+, [0 ОД]",
                                 "Поджигает врагов, [-4 ОД]", "Дробит кости, [-6 ОД]", "Подстрелить врага, [-15 ОД]", "Кровавая бойня, [-10 ОД]", "Порезы ветром, [-20 ОД]", "Обвал грудой камней, [-30 ОД]", "Изучить противника, [-2 ОД]" };
            for (Byte i=0;i<buttons.Length;i++) if (sender.Equals(buttons[i])) BattleText2.Content = ondescr[i];
            LabShow(BattleText2);
        }
        private void AbilitiesOutFight_MouseEnter(object sender, MouseEventArgs e)
        {
            Button[] buttons = { Cure1, Cure2Out, Heal1, BuffUp1, ToughenUp1, Regen1, Control1, Torch1, Whip1, Thrower1, Super0, Tornado1, Quake1, Learn1 };
            String[] ondescr = { "-2", "-10", "-3", "-12", "-8", "-15", "0", "-4", "-6", "-15", "-10", "-20", "-30", "-2" };
            for (Byte i = 0; i < buttons.Length; i++) if (sender.Equals(buttons[i])) AbilsCost.Content = ondescr[i];
            LabShow(AbilsCost);
        }
        private void ItemsOutMenu_MouseEnter(object sender, MouseEventArgs e)
        {
            Button[] buttons = { Bandage, Ether1, Antidote, Fused, Herbs1, Ether2Out, SleepBag1, Elixir1 };
            Button[] buttons2 = { CraftBandage, CraftEther, CraftAntidote, CraftFused, CraftHerbs, CraftEther2, CraftBedbag, CraftElixir };
            Byte[] counts = { BAG.BandageITM, BAG.EtherITM, BAG.AntidoteITM, BAG.FusedITM, BAG.HerbsITM, BAG.Ether2ITM, BAG.SleepBagITM, BAG.ElixirITM };
            for (Byte i = 0; i < buttons.Length; i++) if (sender.Equals(buttons[i]) || sender.Equals(buttons2[i])) CountText.Content = "Всего: " + counts[i];
            LabShow(CountText);
        }
        private void ItemsOutMenu_Click(object sender, RoutedEventArgs e)
        {
            Button[] Items = { Bandage, Ether1, Fused, Herbs1, Ether2Out, Elixir1, SleepBag1 };
            Label[] Describes = { BandageText, EtherText, FusedText, HerbsText, Ether2OutText, ElixirText, SleepBagText };
            Byte[] Counts = { BAG.BandageITM, BAG.EtherITM, BAG.FusedITM, BAG.HerbsITM, BAG.Ether2ITM, BAG.ElixirITM, BAG.SleepBagITM };
            UInt16[] HpFill = { Convert.ToUInt16((Super1.CurrentHP + 50) > Super1.MaxHP ? Super1.MaxHP : (Super1.CurrentHP + 50)), Super1.CurrentHP, Convert.ToUInt16((Super1.CurrentHP + 80) > Super1.MaxHP ? Super1.MaxHP : (Super1.CurrentHP + 80)), Convert.ToUInt16((Super1.CurrentHP + 350) > Super1.MaxHP ? Super1.MaxHP : (Super1.CurrentHP + 350)), Super1.CurrentHP, Super1.MaxHP, Super1.MaxHP };
            UInt16[] ApFill = { Super1.CurrentAP, Convert.ToUInt16((Super1.CurrentAP + 50) > Super1.MaxAP ? Super1.MaxAP : (Super1.CurrentAP + 50)), Convert.ToUInt16((Super1.CurrentAP + 80) > Super1.MaxAP ? Super1.MaxAP : (Super1.CurrentAP + 80)), Super1.CurrentAP, Convert.ToUInt16((Super1.CurrentAP + 300) > Super1.MaxAP ? Super1.MaxAP : (Super1.CurrentAP + 300)), Super1.MaxAP, Super1.MaxAP };
            if (sender.Equals(Antidote))
            {
                BAG.AntidoteITM--;
                Super1.PlayerStatus = 0;
                if (BAG.AntidoteITM <= 0) ButtonHide(Antidote);
            }
            else
                for (Byte i = 0; i < Items.Length; i++)
                    if (sender.Equals(Items[i]))
                    {
                        Counts[i]--;
                        Super1.CurrentHP = HpFill[i];
                        Super1.CurrentAP = ApFill[i];
                        RefreshAllHPAP();
                        MenuHpApExp();
                        Time1.Value = 0;
                        CheckAccessItems(Counts, Items);
                        if (Counts[i] <= 0) AnyHide(Describes[i]);
                        CountText.Content = "Всего" + Counts[i];
                        break;
                    }
            BAG.ItemsSet(Counts[0], BAG.AntidoteITM, Counts[1], Counts[2], Counts[3], Counts[6], Counts[4], Counts[5]);
            Dj(Path.GameNoises.UseItems);
        }
        private void CraftItems_Click(object sender, RoutedEventArgs e)
        {
            Button[] cbuttons = new Button[] { CraftAntidote, CraftBandage, CraftEther, CraftFused, CraftHerbs, CraftEther2, CraftBedbag, CraftElixir };
            Byte[] ItemsCount = { BAG.AntidoteITM, BAG.BandageITM, BAG.EtherITM, BAG.FusedITM, BAG.HerbsITM, BAG.Ether2ITM, BAG.SleepBagITM, BAG.ElixirITM };
            UInt16[] MatCosts = new UInt16[] { 10, 20, 70, 150, 500, 1500, 100, 10000 };
            for (Byte i=0;i<cbuttons.Length;i++)
                if (sender.Equals(cbuttons[i]))
                {
                    BAG.Materials -= MatCosts[i];
                    ItemsCount[i]++;
                    CountText.Content = "Всего: " + ItemsCount[i];
                    MaterialsCraft.Content = BAG.Materials;
                }
            BAG.ItemsSet(ItemsCount[1], ItemsCount[0], ItemsCount[2], ItemsCount[3], ItemsCount[4], ItemsCount[6], ItemsCount[5], ItemsCount[7]);
            CheckAccessMaterials(MatCosts, cbuttons);
            TooManyItems(ItemsCount, cbuttons);
        }
        private void CraftPerfboots_Click(object sender, RoutedEventArgs e)
        {
            BAG.Materials -= 30000;
            BAG.ArmBoots[3] = true;
            MaterialsCraft.Content = BAG.Materials;
            ButtonHide(CraftPerfboots);
            BAG.Boots = Super1.PlayerEQ[3] == 0;
        }
        private void CraftPerfboots_MouseEnter(object sender, MouseEventArgs e) { CountText.Content = "Что это?"; LabShow(CountText); }
        private void ItemsInFight_Click(object sender, RoutedEventArgs e)
        {
            Button[] Items = { Bandage1, Ether, Fused1, Herbs, Ether2, Elixir};
            Byte[] Counts = { BAG.BandageITM, BAG.EtherITM, BAG.FusedITM, BAG.HerbsITM, BAG.Ether2ITM, BAG.ElixirITM };
            UInt16[] HpFill = { Convert.ToUInt16((Super1.CurrentHP + 50) > Super1.MaxHP ? Super1.MaxHP : (Super1.CurrentHP + 50)), Super1.CurrentHP, Convert.ToUInt16((Super1.CurrentHP + 80) > Super1.MaxHP ? Super1.MaxHP : (Super1.CurrentHP + 80)), Convert.ToUInt16((Super1.CurrentHP + 350) > Super1.MaxHP ? Super1.MaxHP : (Super1.CurrentHP + 350)), Super1.CurrentHP, Super1.MaxHP };
            UInt16[] ApFill = {  Super1.CurrentAP, Convert.ToUInt16((Super1.CurrentAP + 50) > Super1.MaxAP ? Super1.MaxAP : (Super1.CurrentAP + 50)), Convert.ToUInt16((Super1.CurrentAP + 80) > Super1.MaxAP ? Super1.MaxAP : (Super1.CurrentAP + 80)), Super1.CurrentAP, Convert.ToUInt16((Super1.CurrentAP + 300) > Super1.MaxAP ? Super1.MaxAP : (Super1.CurrentAP + 300)), Super1.MaxAP };
            EventHandler[] Animate = { Bandage_Time_Tick23, Ether_Time_Tick24, Fused_Time_Tick25, HerbsHP_Time_Tick46, Ether2AP_Time_Tick47, ElixirHPAP_Time_Tick48 };
            AnyHideX(ItemText, ItemsCountImg);
            MenuItemsHide1();
            if (sender.Equals(Antidote))
            {
                BAG.AntidoteITM--;
                Super1.PlayerStatus = 0;
                PersonTextAnimationStart(Items_Time_Tick10, Antidote_Time_Tick26, Convert.ToUInt16(25 / GameSpeed.Value), Convert.ToUInt16(75 / GameSpeed.Value));
            }
            else
                for (Byte i=0;i<Items.Length;i++)
                    if (sender.Equals(Items[i]))
                    {
                        Counts[i]--;
                        Super1.SetCurrentHpAp(HpFill[i], ApFill[i]);
                        CurrentHpApCalculate();
                        Time1.Value = 0;
                        PersonTextAnimationStart(Items_Time_Tick10, Animate[i], Convert.ToUInt16(25 / GameSpeed.Value), Convert.ToUInt16(75 / GameSpeed.Value));
                        break;
                    }
            BAG.ItemsSet(Counts[0],BAG.AntidoteITM, Counts[1], Counts[2], Counts[3], BAG.SleepBagITM, Counts[4], Counts[5]);
            Dj(Path.GameNoises.UseItems);
        }
        private void ItemsUseInBattle_MouseEnter(object sender, RoutedEventArgs e)
        {
            Button[] cbuttons = new Button[] { Antidote1, Bandage1, Ether,  Fused1, Herbs, Ether2, Elixir };
            Byte[] ItemsCount = { BAG.AntidoteITM, BAG.BandageITM, BAG.EtherITM, BAG.FusedITM, BAG.HerbsITM, BAG.Ether2ITM, BAG.ElixirITM };
            String[] descrypt = { "Избавляет от яда", "+50 ОЗ", "+50 ОД", "+80 ОЗ и ОД", "+350 ОЗ", "+300 ОД", "100% ОЗ и ОД" };
            for (Byte i = 0; i < cbuttons.Length; i++)
            {
                if (sender.Equals(cbuttons[i]))
                {
                    ItemText.Content = "Всего: " + ItemsCount[i];
                    BattleText2.Content = descrypt[i];
                    LabShowX(new Label[] { BattleText2, ItemText });
                }
            }
        }
        private void ItemsUseInBattle_MouseLeave(object sender, MouseEventArgs e) { ItemText.Content = ""; LabHideX(new Label[] { ItemText, BattleText2 }); }
        public static Byte CurrentLocation=0;
        private void ChangeOnChapter(in Byte Loc)
        {
            BitmapImage[][] MapAndBattle = { BmpersToX(Bmper(Path.Backgrounds.Location1), Bmper(Path.Fighting.Battle1)), BmpersToX(Bmper(Path.Backgrounds.Location2), Bmper(Path.Fighting.Battle2)), BmpersToX(Bmper(Path.Backgrounds.Location3), Bmper(Path.Fighting.Battle2)) };
            CurrentLocation = Loc;
            FastImgChange(new Image[] { Img1, Img3 }, MapAndBattle[CurrentLocation]);
            MediaHide(ChapterIntroduction);
        }
        private void ChapterIntroduction_MediaEnded(object sender, RoutedEventArgs e)
        {
            switch (Super1.MenuTask)
            {
                case 0: ChangeOnChapter(0); Location1_AncientPyramid(); ImgShowX(new Image[] { TableMessage1, Threasure1 }); break;
                case 3:
                case 4: ChangeOnChapter(1); Location2_WaterTemple(); SaveGame(); break;
                case 6:
                case 7: ChangeOnChapter(2); ContinueQuest(); SaveGame(); break;
                case 10: MediaShowAdvanced(TheEnd, Ura(Path.CutScene.Titres), new TimeSpan(0, 0, 0, 0, 0)); HeyPlaySomething(Path.GameMusic.SayGoodbye); break;
                default: Form1.Close(); break;
            }
            ImgShowX(new Image[] { Img1, Img2, SaveProgress });
        }
        //                           "Закалённый острый кинжал, пробивающий камни насквозь. Крайне\nсмертоносная игрушка."
        private void AnyEquipments_MouseEnter(object sender, MouseEventArgs e)
        {
            LabShow(Describe1);
            Button[] EquipmentsBt = new Button[] { Equipments, Equipments2, Equipments3, Equipments4 };
            String[,] Descryption = new String[,] { { "Прочный костяной кастет. Одно из лучших средств показать свою мощь!", "Черная кожаная куртка. Никто не ценит ничего так сильно, как\nнадёжный кожак в жуткую погоду.", "Штаны из перьев стервятника. Вполне сгодится и на огородное пугало...", "Бинтовая обувь. Спасает от ужасной жары здешних песков как никогда." }, { "Закалённый острый кинжал, пробивающий камни насквозь. Крайне\nсмертоносная игрушка.", "Отлично сохранившиеся доспехи древних воинов. Кажется, что\nради хороших вещей древние даже золота не жалели.", "Поножи из могучих раздробленных пластин, защищают даже от\nукуса комара.", "Сапоги прирождённых солдат, покрыты слоём железа и укрепл-\nены пластинами." }, { "Меч грёз, рассекающий воздух.", "Нагрудник, отполированный настолько, что в нём видно отражение\n приближающихся врагов.", "Поножи, способные полностью закрыть талию от любого вреда.", "Невесомые сапоги, из невероятно прочного материала." }, { "Размер не имеет  значения, главное как его используют", "Футболка для настоящих ценителей", "Штаны серьёзных намерений", "Прочные сапоги из натуральной дублёной кожи" } };
            String[,] ParamsUp = new String[,] { { "+10", "+5", "+4", "+1" }, { "+50", "+25", "+15", "+10" }, { "+200", "+90", "+65", "+45" }, { "+165", "+85", "+55", "+25" } };
            for (Byte i=0;i<EquipmentsBt.Length;i++)
            {
                if (sender.Equals(EquipmentsBt[i]))
                {
                    switch (Sets.EquipmentClass)
                    {
                        case 0: EquipCollectInfo(Descryption[i, 0], AddATK1, ParamsUp[i, 0]); break;
                        case 1: EquipCollectInfo(Descryption[i, 1], AddDEF1, ParamsUp[i, 1]); break;
                        case 2: EquipCollectInfo(Descryption[i, 2], AddDEF1, ParamsUp[i, 2]); break;
                        case 3: EquipCollectInfo(Descryption[i, 3], AddDEF1, ParamsUp[i, 3]); break;
                        default: EquipCollectInfo(Descryption[i, 0], AddATK1, ParamsUp[i, 0]); break;
                    }
                    break;
                }
            }
        }
        private void AnyEquipments_Click(object sender, RoutedEventArgs e)
        {
            LabShow(Describe1);
            Button[] EquipmentsBt = new Button[] { Equipments, Equipments2, Equipments3, Equipments4 };
            String[,] Descryption = new String[,] { { "Древний кастет", "Чёрный кожак", "Штаны стервятника", "Бинтовая обувь" }, { "Древний кинжал", "Древняя броня", "Поножи воина", "Сапоги мужества" }, { "Меч легенды", "Броня легенды", "Поножи легенды", "Сапоги легенды" }, { "Миниган XM214-A", "Футболка крутого", "Штаны серьёзного", "Военные ботинки" } };
            Byte[,] ParamsUp = new Byte[,] { { 10, 5, 4, 1 }, { 50, 25, 15, 10 }, { 200, 90, 65, 45 }, { 165, 85, 55, 25 } };
            for (Byte i = 0; i < EquipmentsBt.Length; i++)
            {
                if (sender.Equals(EquipmentsBt[i]))
                {
                    switch (Sets.EquipmentClass)
                    {
                        case 0: OnEquiped(Equip1, EquipH, Descryption[i, 0], 0, ParamsUp[i, 0]); break;
                        case 1: OnEquiped(Equip2, EquipB, Descryption[i, 1], 1, ParamsUp[i, 1]); break;
                        case 2: OnEquiped(Equip3, EquipL, Descryption[i, 2], 2, ParamsUp[i, 2]); break;
                        case 3: OnEquiped(Equip4, EquipD, Descryption[i, 3], 3, ParamsUp[i, 3]); break;
                        default: OnEquiped(Equip1, EquipH, Descryption[i, 0], 0, ParamsUp[i, 0]); break;
                    }
                    break;
                }
            }
            StatsMeaning();
            BtnHideX(new Button[] { Equipments, Equipments2, Equipments3, Equipments4, CancelEq });
            EquipWatch();
        }
        private void DamageTime_Tick3(object sender, EventArgs e)
        {
            Img4.Source = Bmper(Path.PersonAnimatePath.Hurt[PlayerHurt]);
            if (PlayerHurt == Path.PersonAnimatePath.Hurt.Length - 1)
            {
                HP.Foreground = Brushes.White;
                PlayerHurt = 0;
                Img4.Source = Bmper(Path.PersonStatePath.Usual);
                timer3.Stop();
                timer3.IsEnabled = false;
            }
            else PlayerHurt++;
        }

        private void HurtTime_Tick4(object sender, EventArgs e)
        {
            Byte[] RowSet1 = { 17, 18, 19, 18, 19 };
            Byte[] ColumnSet1 = { 50, 51, 52, 53, 54 };
            if (PlayerHurtM == ColumnSet1.Length - 1)
            {
                PlayerHurtM = 0;
                timer4.Stop();
                timer4.IsEnabled = false;
                LabHide(BattleText6);
            }
            else
            {
                LabGrid(BattleText6, RowSet1[PlayerHurtM], ColumnSet1[PlayerHurtM]);
                PlayerHurtM++;
            }
        }
        private string FoesStaticCheck(in string EnemyName)
        {
            return EnemyName switch
            {
                "Мумия" => Path.FoesStatePath.Mummy,
                "Зомби" => Path.FoesStatePath.Zombie,
                "Страж" => Path.FoesStatePath.Bones,
                "Стервятник" => Path.FoesStatePath.Vulture,
                "Гуль" => Path.FoesStatePath.Ghoul,
                "Жнец" => Path.FoesStatePath.GrimReaper,
                "Скарабей" => Path.FoesStatePath.Scarab,
                "Фараон" => Path.BossesStatePath.Pharaoh,
                "Угх-зан I" => Path.BossesStatePath.UghZan,
                _ => Path.FoesStatePath.Spider,
            };
        }
        private string[] FoesDynamicCheck(in string EnemyName)
        {
            return EnemyName switch
            {
                "Мумия" => Path.FoesAnimatePath.Mummy,
                "Зомби" => Path.FoesAnimatePath.Zombie,
                "Страж" => Path.FoesAnimatePath.Bones,
                "Стервятник" => Path.FoesAnimatePath.Vulture,
                "Гуль" => Path.FoesAnimatePath.Ghoul,
                "Жнец" => Path.FoesAnimatePath.GrimReaper,
                "Скарабей" => Path.FoesAnimatePath.Scarab,
                "Фараон" => Path.BossesAnimatePath.Pharaoh,
                "Угх-зан I" => Path.BossesAnimatePath.UghZan,
                _ => Path.FoesAnimatePath.Spider,
            };
        }
        private bool FoeAttacks_Time_Ticks(in Byte t1)
        {
            Image[] EnemiesImg = { Img6, Img7, Img8 };
            string[] EnemyAnimate = FoesDynamicCheck(Foe1.EnemyAppears[t1]);
            string Enemy = FoesStaticCheck(Foe1.EnemyAppears[t1]);
            EnemiesImg[t1].Source = Bmper(EnemyAnimate[EnemyAtck[t1]]);
            if (EnemyAtck[t1] >= EnemyAnimate.Length - 1)
            {
                if (Sets.SpecialBattle == 200)
                    LabHide(BattleText6);
                HP.Foreground = Brushes.White;
                EnemyAtck[t1] = 0;
                EnemiesImg[t1].Source = Bmper(Enemy);
                return true;
            }
            else
            {
                EnemiesImg[t1].Source = Bmper(EnemyAnimate[EnemyAtck[t1]]);
                EnemyAtck[t1]++;
                return false;
            }
        }
        private void FoeAttack1_Time_Tick5(object sender, EventArgs e) { if (FoeAttacks_Time_Ticks(0)) timer5.Stop(); }
        private void FoeAttack2_Time_Tick6(object sender, EventArgs e) { if (FoeAttacks_Time_Ticks(1)) timer6.Stop(); }
        private void FoeAttack3_Time_Tick7(object sender, EventArgs e) { if (FoeAttacks_Time_Ticks(2)) timer7.Stop(); }
        private void HandAttack_Time_Tick8(object sender, EventArgs e) { ActionsTickCheck(Path.PersonAnimatePath.HdAttack, Path.IconAnimatePath.HdAttack); }
        private void KnifeAttack_Time_Tick8(object sender, EventArgs e) { ActionsTickCheck(Path.PersonAnimatePath.KnAttack, Path.IconAnimatePath.KnAttack); }
        private void Escape_Time_Tick9(object sender, EventArgs e) { ActionsTickCheck(Path.PersonAnimatePath.Escape, Path.IconAnimatePath.Escape); }
        private void Items_Time_Tick10(object sender, EventArgs e) { ActionsTickCheck(Path.PersonAnimatePath.BagUse, Path.IconAnimatePath.BagUse); }
        private void Cure_Time_Tick11(object sender, EventArgs e) { ActionsTickCheck(Path.PersonAnimatePath.Cure, Path.IconAnimatePath.Cure); }
        //Где найти вдохновение
        //https://www.youtube.com/results?search_query=dq+2+battle+theme
        private void Heal_Time_Tick12(object sender, EventArgs e) { ActionsTickCheck(Path.PersonAnimatePath.Heal, Path.IconAnimatePath.Heal); }
        private void Torch_Time_Tick13(object sender, EventArgs e) { ActionsTickCheck(Path.PersonAnimatePath.Torch, Path.IconAnimatePath.Torch); }
        private void Whip_Time_Tick14(object sender, EventArgs e) { ActionsTickCheck(Path.PersonAnimatePath.Whip, Path.IconAnimatePath.Whip); }
        private void Super_Time_Tick15(object sender, EventArgs e) { ActionsTickCheck(Path.PersonAnimatePath.Super, Path.IconAnimatePath.Super); }
        private void Target_Time_Tick16(object sender, EventArgs e) { UnlimitedActionsTickCheck(Path.MiscAnimatePath.Target); }
        private void Bandage_Time_Tick23(object sender, EventArgs e) { CureHealTxt.Content = "+50"; CureOrHeal(); }
        private void Ether_Time_Tick24(object sender, EventArgs e) { RecoverAPTxt.Content = "+50"; RestoreAP(); }
        private void Fused_Time_Tick25(object sender, EventArgs e) { FastTextChange(new Label[] { CureHealTxt, RecoverAPTxt }, new String[] { "+80", "+80" }); CureOrHeal(); RestoreAP(); }
        private void Antidote_Time_Tick26(object sender, EventArgs e) { CureHealTxt.Content = "-Яд"; CureOrHeal(); }
        private void Cure2_Time_Tick27(object sender, EventArgs e) { ActionsTickCheck(Path.PersonAnimatePath.Cure2, Path.IconAnimatePath.Cure2); }
        private void CureHP2_Time_Tick28(object sender, EventArgs e) { CureHealTxt.Content = "100%"; CureOrHeal(); }
        private void BuffUp_Time_Tick29(object sender, EventArgs e) { ActionsTickCheck(Path.PersonAnimatePath.BuffUp, Path.IconAnimatePath.BuffUp); }
        private void Regen_Time_Tick32(object sender, EventArgs e) { ActionsTickCheck(Path.PersonAnimatePath.Regen, Path.IconAnimatePath.Regen); }
        private void Toughen_Time_Tick31(object sender, EventArgs e) { ActionsTickCheck(Path.PersonAnimatePath.ToughenUp, Path.IconAnimatePath.ToughenUp); }
        private void RegenHP_Time_Tick33(object sender, EventArgs e) { if (Super1.CurrentHP < Super1.MaxHP) { Super1.CurrentHP++; CurrentHPcalculate(); } }
        private void ControlAP_Time_Tick34(object sender, EventArgs e) { if (Super1.CurrentAP < Super1.MaxAP) { Super1.CurrentAP++; CurrentAPcalculate(); } }
        private void Control_Time_Tick35(object sender, EventArgs e) { ActionsTickCheck(Path.PersonAnimatePath.Control, Path.IconAnimatePath.Control); }
        private void Thrower_Time_Tick36(object sender, EventArgs e)
        {
            Label[] Labs = new Label[] { DamageFoe, DamageFoe2, DamageFoe3 };
            string[] EnemyNames = { "Паук", "Мумия", "Зомби", "Страж", "Стервятник", "Гуль", "Жнец", "Скарабей", "Моль-убийца", "Прислужник", "П. червь", "Мастер" };
            UInt16 strength = Convert.ToUInt16((Foe1.EnemyAppears[SelectedTrgt] == EnemyNames[4] || Foe1.EnemyAppears[SelectedTrgt] == EnemyNames[8] || Foe1.EnemyAppears[SelectedTrgt] == EnemyNames[9] || Foe1.EnemyAppears[SelectedTrgt] == EnemyNames[11] ? Super1.Special * 5 : Super1.Special * 2.5) + Super1.Special * Super1.Speed * 0.01);
            UInt16 EnemyAura = EnemyAntiSkill(Sets.SelectedTarget);
            Labs[SelectedTrgt].Content = Convert.ToUInt16(strength > EnemyAura ? strength - EnemyAura : 0);
            FoesKicked();
        }
        private void Thrower_Time_Tick37(object sender, EventArgs e) { ActionsTickCheck(Path.PersonAnimatePath.Thrower, Path.IconAnimatePath.Thrower); }
        private void Tornado_Time_Tick38(object sender, EventArgs e) { ActionsTickCheck(Path.PersonAnimatePath.Tornado, Path.IconAnimatePath.Tornado); }
        private void TornadoDmg_Time_Tick39(object sender, EventArgs e)
        {
            UInt16 strength = Convert.ToUInt16(Super1.Special * 3 + Super1.Special * Super1.Speed * 0.01);
            UInt16 EnemyAura = EnemyAntiSkill(Sets.SelectedTarget);
            AllDmgTimeTextChangeConstruction(Convert.ToUInt16(strength > EnemyAura ? strength - EnemyAura : 0));
            FoesKicked();
        }
        private void SeriousMinigun_Time_Tick39(object sender, EventArgs e) { ActionsTickCheck(Path.PersonAnimatePath.SeriousMg, Path.IconAnimatePath.SeriousMg); }
        private void Quake_Time_Tick43(object sender, EventArgs e) { ActionsTickCheck(Path.PersonAnimatePath.Quake, Path.IconAnimatePath.Quake); }
        private void QuakeDmg_Time_Tick44(object sender, EventArgs e)
        {
            UInt16 strength = Convert.ToUInt16(Super1.Special * 4 + Super1.Special * Super1.Speed * 0.01);
            UInt16 EnemyAura = EnemyAntiSkill(Sets.SelectedTarget);
            AllDmgTimeTextChangeConstruction(Convert.ToUInt16(strength > EnemyAura ? strength - EnemyAura : 0));
            FoesKicked();
        }
        private void SeriousSwitch_Time_Tick45(object sender, EventArgs e) { ActionsTickCheck(Path.PersonAnimatePath.SSwitch, Path.IconAnimatePath.SSwitch); }
        private void HerbsHP_Time_Tick46(object sender, EventArgs e) { CureHealTxt.Content = "+350"; CureOrHeal(); }
        private void Ether2AP_Time_Tick47(object sender, EventArgs e) { RecoverAPTxt.Content = "+300"; RestoreAP(); }
        private void ElixirHPAP_Time_Tick48(object sender, EventArgs e) { FastTextChange(new Label[] { CureHealTxt, RecoverAPTxt }, new String[] { "100%", "100%" }); CureOrHeal(); RestoreAP(); }
        private void AllDmgTimeTextChangeConstruction(in UInt16 ActionPower)
        {
            Label[] Labs = new Label[] { DamageFoe, DamageFoe2, DamageFoe3 };
            for (Byte i = 0; i < 3; i++) Labs[i].Content = Foe1.EnemyHP[i] > 0 ? ActionPower : Labs[i].Content;
        }
    }
}
using System;
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

namespace WpfApp1
{

    /// <summary>
    /// [EN] Interaction logic for game triggers.
    /// [RU] Интерактивная логика для внутренних механизмов.
    /// </summary>
    
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
            public UInt16 EnemyMHP { get; set; }
            public Byte EnemyAttack { get; set; }
            public Byte EnemyDefence { get; set; }
            public Byte EnemySpeed { get; set; }
            public Byte EnemyAgility { get; set; }
        }
        public void GetStats() {
            EnemyName = new string[] { "Паук", "Мумия", "Зомби", "Страж","Фараон" };
            EnemyAppears = new string[] { "", "", "" };
            EnemyTurn = new Byte[] { 60, 30, 0 };
            EnemyHP = new UInt16[] { 0, 0, 0 };
            EnemiesStillAlive = 0;
        }
        public UInt16[] EnemyHP { get; set; }
        public string[] EnemyName { get; set; }
        public string[] EnemyAppears { get; set; }
        public Byte[] EnemyTurn { get; set; }
        public Byte EnemiesStillAlive { get; set; }
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
            NextLevel = new UInt16[] { 15, 24, 38, 61, 98, 112, 150, 177, 200, 250 };

            //[EN] Active stats (HP,AP)
            //[RU] Активные параметры (ОЗ, ОД).
            MaxHP = 100;
            MaxAP = 40;

            //[EN] Passive stats (ATK, DEF, AG, SP)
            //[RU] Пассивные параметры (АТК, ЗЩТ, СК., СП.).
            Attack = 25;
            Defence = 15;
            Speed = 15;
            Special = 25;
            
            //[EN] PLAYER LEVEL UP STATS
            //[RU] СТАТУС ИГРОКА ПРИ ПОВЫШЕНИИ УРОВНЯ
            MaxHPNxt = new UInt16[] { 100, 110, 121, 132, 145, 159, 174, 192, 221, 250 };
            MaxAPNxt = new UInt16[] { 40, 44, 48, 53, 58, 64, 70, 77, 85, 100 };
            AttackNxt = new Byte[] { 25, 28, 31, 34, 40, 45, 52, 63, 70, 85 };
            DefenseNxt = new Byte[] { 15, 17, 19, 21, 25, 30, 33, 37, 45, 50 };
            SpeedNxt = new Byte[] { 15, 17, 19, 21, 23, 25, 28, 31, 35, 39 };
            SpecialNxt = new Byte[] { 25, 30, 35, 40, 45, 50, 60, 65, 75, 100 };

            //[EN] PLAYER CURRENT EQUIP
            //[RU] ТЕКУЩАЯ ЭКИПИРОВКА
            PlayerEQ = new Byte[] { 0, 0, 0, 0 };

            //[EN] PLAYER STATUS IN AND OUT OF BATTLE
            //[RU] СТАТУС ИГРОКА В И ВНЕ БОЯ
            DefenseState = 1;
            PlayerStatus = 0;
        }

        public UInt16 MaxHP { get; set; }
        public UInt16 MaxAP { get; set; }
        public Byte Attack { get; set; }
        public Byte Defence { get; set; }
        public Byte Speed { get; set; }
        public Byte Special { get; set; }
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
            Jacket = false;
            Legs = false;
            Boots = false;
        }

        //[EN] Initialize items count method
        //[RU] Метод для обозначения хранения каждого вида предметов
        public void Items()
        {
            BandageITM = 0;
            AntidoteITM = 0;
            EtherITM = 0;
            FusedITM = 0;
        }
        public Byte BandageITM { get; set; }
        public Byte AntidoteITM { get; set; }
        public Byte EtherITM { get; set; }
        public Byte FusedITM { get; set; }
        public Boolean Hands { get; set; }
        public Boolean Jacket { get; set; }
        public Boolean Legs { get; set; }
        public Boolean Boots { get; set; }
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
            HelpInfo1 = new string[,]{ {"Управление","Сражение","Атака","Умения","Уровень" },
            {"Смена цели","Шкала хода","Защита","Предметы","Опыт" },
            {"","Действия","Побег","","" } };
            
            HelpInfo2 = new string[,] { {"Используйте WASD, чтобы передвигаться\nДля взаимодействия с объектом используйте E.","Во время передвижения по основной локации на вас\nмогут напасть противники","Самый лучший путь победы - наступление.","Достигнув 2 уровня вам откроются новые возможности.","Отображает уровень героя. Чем он выше, тем сильнее\nперсонаж" },
            {"WASD - менять цель. Выбирайте с умом!","Во время сражения заполняется активная временная шкала (АВШ).\nПосле её заполнения вам будут доступны разные действия","Оборонительная стойка спасает от ряда\nвнезапных атак","Иногда, после боя найдутся вещи, которые можно\nиспользовать.","Служит для повышения уровня. Набирайте его в боях!" },
            {"","После заполнения АВШ появится 5 опций: Атака,\nЗащита, Побег, Умения, Предметы","Порой лучший план - стратегическое отступление","","" } };
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
                ImgXbounds = -1362;
                ImgYbounds = 1020;
            }

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
            MenuTask = 0;
            TableEN = true;
            LockIndex = 3;
            StepsToBattle = 20;
            SelectedTarget = 0;
            SpiderAlive = 0;
            MummyAlive = 0;
            ZombieAlive = 0;
            BonesAlive = 0;
            EnemyRate = 2;
            Rnd1 = 0;
            Rnd2 = 0;
            BossPharaoh = false;
            ItemsDropRate = new Byte[] { 0, 0, 0, 0 };
        }
        public Byte SelectedTarget { get; set; }
        public Byte StepsToBattle { get; set; }
        public Byte EnemyRate { get; set; }
        public Int32 Rnd1 { get; set; }
        public Int32 Rnd2 { get; set; }
        public Byte EquipmentClass { get; set; }
        public Byte MenuTask { get; set; }
        public Byte SpiderAlive { get; set; }
        public Byte MummyAlive { get; set; }
        public Byte ZombieAlive { get; set; }
        public Byte BonesAlive { get; set; }
        public bool TableEN { get; set; }
        public Byte LockIndex { get; set; }
        public bool BossPharaoh { get; set; }
        public Byte[] ItemsDropRate { get; set; }
    }
    
    /* [EN] Initialize locations for future
     * [RU] Инициализация локаций на будущее
    public static int[] Xcoordinate = { -1517 };
    public static int[] Ycoordinate = { 60 };*/

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
            Foe1.GetStats();
            SetEnemies();
            InitializeComponent();
            Form1.ResizeMode = ResizeMode.NoResize;
            Form1.WindowStyle = WindowStyle.None;
            Form1.WindowState = WindowState.Maximized;
            //[EN] Working with directories (for commercial and private purposes)
            //[RU] Работа с директориями (для коммерческих и личных целей).
            //Environment.CurrentDirectory();
            //Sound1.Play();
            HeyPlaySomething(new Uri(@"Begin2.mp3", UriKind.RelativeOrAbsolute));
            //Sound1.Volume = 0.0;
            //Sound2.Volume = 0.0;
            //Sound3.Volume = 0.0;
            ImgMove(Img2, -1362, 1020);
            ImgMove(TableMessage1, 402, 749);
            CheckScreenProperties();
        }

        //[EN] Initialize public objects
        //[RU] Инициализация объектов публичного доступа
        Bag BAG = new Bag();
        Characteristics Super1 = new Characteristics
        {
            MaxHP = 100,
            MaxAP = 40,
            Attack = 25,
            Defence = 15,
            Speed = 15,
            Special = 25
        };
        Foe Foe1 = new Foe();
        Misc Sets = new Misc();
        Misc.Adopt Adoptation = new Misc.Adopt();
        Menu GameMenu = new Menu();
        Foe.Stats Spider = new Foe.Stats();
        Foe.Stats Mummy = new Foe.Stats();
        Foe.Stats Zombie = new Foe.Stats();
        Foe.Stats Bones = new Foe.Stats();
        Foe.Stats BOSS1 = new Foe.Stats();

        private void SetEnemies()
        {
            Spider.GetStats();
            Spider.PreStats(25, 0, 10, 1, 65);
            Mummy.GetStats();
            Mummy.PreStats(32, 0, 17, 1, 83);
            Zombie.GetStats();
            Zombie.PreStats(41, 0, 25, 1, 101);
            Bones.GetStats();
            Bones.PreStats(50, 0, 35, 1, 125);
            BOSS1.GetStats();
            BOSS1.PreStats(75, 0, 40, 1, 500);
        }


        private void SEF(Uri sound)
        {
            Sound3.Stop();
            Sound3.Source = sound;
            Sound3.Play();
        }

        private void ImgShrink(Image Img, in Double W, in Double H)
        {
            Img.Width = W;
            Img.Height = H;
        }
        private void BtnShrink(Button Btn, in Double W, in Double H)
        {
            Btn.Width = W;
            Btn.Height = H;
        }
        private void BarShrink(ProgressBar Bar, in Double W, in Double H)
        {
            Bar.Width = W;
            Bar.Height = H;
        }
        private void MedShrink(MediaElement Med, in Double W, in Double H)
        {
            Med.Width = W;
            Med.Height = H;
        }
        private void LabShrink(Label Lab, in Double fs)
        {
            Lab.FontSize = fs;
        }
        private void LabMove(Label Lab, in Double l, in Double t)
        {
            Lab.Margin = new Thickness(l, t, 0, 0);
        }
        private void ButtonMove(Button Btn, in Double l, in Double t)
        {
            Btn.Margin = new Thickness(l, t, 0, 0);
        }
        private void BarMove(ProgressBar Bar, in Double l, in Double t)
        {
            Bar.Margin = new Thickness(l, t, 0, 0);
        }
        private void MedMove(MediaElement Med, in Double l, in Double t)
        {
            Med.Margin = new Thickness(l, t, 0, 0);
        }
        private void ImgMove(Image Img, in Double l, in Double t)
        {
            Img.Margin = new Thickness(l, t, 0, 0);
        }
        private void ButtonCHFT(Button Btn, in Double fs)
        {
            Btn.FontSize = fs;
        }

        private void Adaptate()
        {
            ///In Game with player start
            //[EN] Adaptate mechanics, sreen elements formula: CurrentScreenSize/Recomended(1920X1080)
            //[RU] Механика адаптации, формула расположения элементов: ТекущееРазрешениеЭкрана/Рекомендуемое(1920Х1080)
            Button[] BtnWFM = { Button1, Skip1, Equip1, Equip2, Equip3, Equip4, Remove1, Remove2, Remove3, Remove4, CancelEq, Button2, Button3, Button4, Abilities, Items, Back2, Back1, Fight, Cancel1, Cancel2, Cure, Torch, Heal, Whip, Super, ACT1, ACT2, textOk2, TextOk1, InfoIndexMinus, InfoIndexPlus };
            Button[] BtnM = { Cure1, Heal1, Bandage, Ether1, Antidote, Fused, Equipments, Status, Abils, Items0, Tasks, Info, Equip, Bandage1, Antidote1, Ether, Fused1 };
            Label[] LabMS = { Lab1, Lab2, CureDescribe, HealDescribe, HealCost, CureCost, CostText, BandageText, EtherText, AntidoteText, FusedText, CountText, Task1, Task2, Task3, Task4, InfoHeaderText1, InfoHeaderText2, InfoHeaderText3, InfoText1, InfoText2, InfoText3, InfoIndex, Describe1, Describe2, BattleText1, BattleText2, HPtext, APtext, LevelText, HeroName, ExpText, TimeText, ItemText, BattleText3, BattleText4, BattleText5, BattleText6, HPenemy, BandageText, EtherText, AntidoteText, FusedText, CountText, ATK, SP, CureDescribe, HealDescribe, HealCost, CureCost, CostText, Name0, Level0, StatusP, HPtext1, APtext1, Exp1, ATK1, DEF1, AG1, SP1, Params, ParamsATK, ParamsDEF, ParamsAG, ParamsSP, HP1, AP1, EquipH, EquipB, EquipL, EquipD, EquipText, HP,AP };
            Image[] ImgMS = { Icon0, ATKImg, DEFImg, AGImg, SPImg,EquipHImg, EquipBImg, EquipLImg, EquipDImg, Task1Img, Task2Img, Task3Img, Task4Img, Img4, Img5, ItemsCountImg, Img6, Img7, Img8, EnemyCursor, ChestImg4, ChestImg3, ChestImg2, ChestImg1, LockImg3, LockImg2, LockImg1, KeyImg3, KeyImg2, KeyImg1, Threasure1, Table1, Table2,Table3, TableMessage1, ChestMessage1 };
            ProgressBar[] StBarMS = { HPbar1, APbar1, ExpBar1 };
            ProgressBar[] BarMS = { HPbar, APbar, NextExpBar, Time1, HPenemyBar };
            MediaElement[] MedMS = { PharaohBattle, Med3, Med4, Trgt};
            //Params, ParamsATK, ParamsDEF, ParamsAG, ParamsSP, ATK1, DEF1, AG1, SP1, EquipText, EquipH, EquipB, EquipL, EquipD, Exp1,
            foreach (Button btn in BtnWFM)
            {
                ButtonMove(btn, btn.Margin.Left * Adoptation.WidthAdBack, btn.Margin.Top * Adoptation.HeightAdBack);
                BtnShrink(btn, (btn.Width * Adoptation.WidthAdBack), (btn.Height * Adoptation.HeightAdBack));
                ButtonCHFT(btn, btn.FontSize * Adoptation.WidthAdBack);
            }
            foreach (Button btn in BtnM)
            {
                ButtonMove(btn, btn.Margin.Left * Adoptation.WidthAdBack, btn.Margin.Top * Adoptation.HeightAdBack);
                BtnShrink(btn, (btn.Width * Adoptation.WidthAdBack), (btn.Height * Adoptation.HeightAdBack));
            }
            //System.Windows.MessageBox.Show(Convert.ToString(Params.Margin.Left));
            foreach (Label lab in LabMS)
            {
                LabMove(lab, lab.Margin.Left * Adoptation.WidthAdBack, lab.Margin.Top * Adoptation.HeightAdBack);
                LabShrink(lab, lab.FontSize * Adoptation.WidthAdBack);
            }
            //System.Windows.MessageBox.Show(Convert.ToString(Params.Margin.Left));
            foreach (Image img in ImgMS)
            {
                ImgMove(img, img.Margin.Left * Adoptation.WidthAdBack, img.Margin.Top * Adoptation.HeightAdBack);
                ImgShrink(img, img.Width * Adoptation.WidthAdBack, img.Height * Adoptation.HeightAdBack);
            }
            foreach (ProgressBar bar in StBarMS)
            {
                BarMove(bar, bar.Margin.Left * Adoptation.WidthAdBack, bar.Margin.Top * Adoptation.HeightAdBack);
                BarShrink(bar, bar.Width * 2 * Adoptation.WidthAdBack, bar.Height * Adoptation.HeightAdBack);
            }
            foreach (ProgressBar bar in BarMS)
            {
                BarMove(bar, bar.Margin.Left * Adoptation.WidthAdBack, bar.Margin.Top * Adoptation.HeightAdBack);
                BarShrink(bar, bar.Width * Adoptation.WidthAdBack, bar.Height * Adoptation.HeightAdBack);
            }
            foreach (MediaElement med in MedMS)
            {
                MedMove(med, med.Margin.Left * Adoptation.WidthAdBack, med.Margin.Top * Adoptation.HeightAdBack);
                MedShrink(med, med.Width * Adoptation.WidthAdBack, med.Height * Adoptation.HeightAdBack);
            }
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
            ImgShrink(Img3, W, H);
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
                        ImgMove(Img2, -(I2S[0, j] * 25), 1020 * Adoptation.HeightAdBack);
                        Adoptation.ImgLeftStep = I2S[0, j] * 2;
                        Adoptation.ImgTopStep = I2S[1, j];
                        Adaptate();
                        break;
                    }
                    if (j == ScreenSize.GetLength(1))
                    {
                        MessageBoxResult MR = System.Windows.MessageBox.Show("Приложение не поддерживает данный\nтип разрешения на этом устройстве\n" + "\nДоступные разрешения:\n800x600;         1024X768;\n1152x864;       1280X720;\n1280x768;       1280X800;\n1280x960;       1280X1024;\n1360x768;       1366X768;\n1440x900;       1600X900;\n1600x1024;     1680X1050;\n1920x1080;     3840X2160;\n" + "\nТекущее разрешение экрана: " + Screen, "Ошибка адаптации разрешения", MessageBoxButton.OK, MessageBoxImage.Error);
                        if (MR == MessageBoxResult.OK)
                        {
                            Form1.Close();
                        }
                    }
                }
            }
            else
            {
                ImgMove(Img2, -1075, 1020);
                Adoptation.ImgLeftStep = 62;
                Adoptation.ImgTopStep = 30;
            }
        }

        //[EN] Initialize all variables
        //[RU] Инициализация всех переменных.

        //[EN] Initialize timers
        //[RU] Инициализация таймеров.
        System.Windows.Threading.DispatcherTimer timer = null;
        System.Windows.Threading.DispatcherTimer timer2 = null;

        //[EN] Initialize way to escape and experience
        //[RU] Инициализация состояния побега и количества опыта, получаемого после боя.
        public static Int32 speed = 0;
        public static Int32 Exp = 0;

        //[EN] Initialize random mechanic
        //[RU] Инициализация механики ведения случайных величин.
        public static Random Random1 = new Random();
        public static Int32 rnd = Random1.Next(5, 20);
        public static int poison = 0;

        private void New_game()
        {
            //[EN] Return to normal stats
            //[RU] Возврат к исходным значениям.
            SetEnemies();
            Exp = 0;
            Foe1.EnemyAppears[0] = "";
            Foe1.EnemyAppears[1] = "";
            Foe1.EnemyAppears[2] = "";
            Foe1.EnemiesStillAlive = 0;
            Sets.SpiderAlive = 0;
            Sets.MummyAlive = 0;
            Sets.ZombieAlive = 0;
            Sets.BonesAlive = 0;
            Sets.BossPharaoh = false;
            Adoptation.ImgXbounds = -1362;
            Adoptation.ImgYbounds = 1020;
            Super1.CurrentLevel = 1;
            HPbar.Maximum = Super1.MaxHPNxt[Super1.CurrentLevel - 1];
            HPbar.Value = HPbar.Maximum;
            APbar.Maximum = Super1.MaxAPNxt[Super1.CurrentLevel - 1];
            APbar.Value = APbar.Maximum;
            ImgMove(Img2, -775 * Adoptation.WidthAdBack, 1020 * Adoptation.HeightAdBack);
            //ImgMove(Img2, -172*Adoptation.WidthAdBack, 1020* Adoptation.HeightAdBack);
            Super1.MaxHP = 100;
            Super1.MaxAP = 40;
            Super1.CurrentLevel = 1;
            Super1.Attack = 25;
            Super1.Defence = 15;
            Super1.Speed = 15;
            Super1.Special = 25;
            BAG.Hands = false;
            BAG.Jacket = false;
            BAG.Legs = false;
            BAG.Boots = false;
            BAG.AntidoteITM = 0;
            BAG.BandageITM = 0;
            BAG.EtherITM = 0;
            BAG.FusedITM = 0;
            Sets.MenuTask = 0;
            var uriSourceCH = new Uri(@"ChestClosed(ver1).png", UriKind.RelativeOrAbsolute);
            ChestImg1.Source = new BitmapImage(uriSourceCH);
            ChestImg2.Source = new BitmapImage(uriSourceCH);
            ChestImg3.Source = new BitmapImage(uriSourceCH);
            ChestImg4.Source = new BitmapImage(uriSourceCH);
        }
        private void HeyPlaySomething(Uri uris)
        {
            Sound1.Stop();
            Sound1.Source = uris;
            Sound1.Play();
        }
        private void Dj(Uri uris)
        {
            Sound2.Stop();
            Sound2.Source = uris;
            Sound2.Play();
        }
        private void Intro()
        {
            Med1.IsEnabled = true;
            Med1.Visibility = Visibility.Visible;
            Med1.Play();
        }

        //[EN] Working with Images
        //[RU] Работа с изображениями
        private void ImgHide(Image Img)
        {
            Img.Visibility = Visibility.Hidden;
            Img.IsEnabled = false;
        }
        private void ImgShow(Image Img)
        {
            Img.Visibility = Visibility.Visible;
            Img.IsEnabled = true;
        }

        //[EN] Working with Media
        //[RU] Работа с элементами Медиа (звук, анимация, прочее).
        private void MediaHide(MediaElement Med)
        {
            Med.Stop();
            Med.Visibility = Visibility.Hidden;
            Med.IsEnabled = false;
        }
        private void MediaShow(MediaElement Med)
        {
            Med.Visibility = Visibility.Visible;
            Med.IsEnabled = true;
            Med.Play();
        }
        //[EN] Working with Buttons
        //[RU] Работа с кнопками.
        private void ButtonHide(Button Btn)
        {
            Btn.Visibility = Visibility.Hidden;
            Btn.IsEnabled = false;
        }
        private void ButtonShow(Button Btn)
        {
            Btn.Visibility = Visibility.Visible;
            Btn.IsEnabled = true;
        }
        //[EN] Working with Labels
        //[RU] Работа с метками (надписями).
        private void LabHide(Label Lab)
        {
            Lab.Visibility = Visibility.Hidden;
            Lab.IsEnabled = false;
        }
        private void LabShow(Label Lab)
        {
            Lab.Visibility = Visibility.Visible;
            Lab.IsEnabled = true;
        }
        //[EN] Working with bars
        //[RU] Работа со шкалами.
        private void BarShow(ProgressBar Bar)
        {
            Bar.Visibility = Visibility.Visible;
            Bar.IsEnabled = true;
        }

        private void BarHide(ProgressBar Bar)
        {
            Bar.Visibility = Visibility.Hidden;
            Bar.IsEnabled = false;
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            New_game();
            Intro();
            LabHide(Lab1);
            ButtonHide(Button1);
            ButtonShow(Skip1);
            /*Sound1.Stop();
            Sound1.Resources.Add(Properties.Resources.Intro1);
            Sound1.Source = Sound1.Resources.Source;s
            Sound1.Play();*/
            //string uri = "..\\Intro1.mp3";
            HeyPlaySomething(new Uri(@"Intro1.mp3", UriKind.RelativeOrAbsolute));
        }

        private void Med1_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox();
        }

        private void MessageBox()
        {
            throw new NotImplementedException();
        }

        //[EN] Activate/Deactivate all .. | [RU] Активировать/Деактивировать все...
        //[EN] chests/
        //[RU] сундуки/
        private void ChestsAllTurnOn1()
        {
            ImgShow(ChestImg1);
            ImgShow(ChestImg2);
            ImgShow(ChestImg3);
            ImgShow(ChestImg4);
        }
        private void ChestsAllTurnOff1()
        {
            ImgHide(ChestImg1);
            ImgHide(ChestImg2);
            ImgHide(ChestImg3);
            ImgHide(ChestImg4);
        }
        //[EN] keys/
        //[RU] ключи/
        private void KeysAllTurnOn1()
        {
            ImgShow(KeyImg1);
            ImgShow(KeyImg2);
            ImgShow(KeyImg3);
        }
        private void KeysAllTurnOff1()
        {
            ImgHide(KeyImg1);
            ImgHide(KeyImg2);
            ImgHide(KeyImg3);
        }
        //[EN] Locks/
        //[RU] замки/
        private void LocksAllTurnOn1()
        {
            ImgShow(LockImg1);
            ImgShow(LockImg2);
            ImgShow(LockImg3);
        }
        private void LocksAllTurnOff1()
        {
            ImgHide(LockImg1);
            ImgHide(LockImg2);
            ImgHide(LockImg3);
        }
        //[EN] Tables/
        //[RU] таблички/
        private void TablesAllTurnOn1()
        {
            ImgShow(Table1);
            ImgShow(Table2);
            ImgShow(Table3);
        }
        private void TablesAllTurnOff1()
        {
            ImgHide(Table1);
            ImgHide(Table2);
            ImgHide(Table3);
        }

        //[EN] After game intro has been ended
        //[RU] После завершения пролога.
        private void Med1_MediaEnded(object sender, RoutedEventArgs e)
        {
            MediaHide(Med1);
            ImgShow(Img1);
            TablesAllTurnOn1();
            Img1.Source = new BitmapImage(new Uri(@"Loc1_1.jpg", UriKind.RelativeOrAbsolute));
            ImgShow(Img2);
            ImgShow(TableMessage1);
            ButtonHide(Skip1);
            ChestsAllTurnOn1();
            KeysAllTurnOn1();
            LocksAllTurnOn1();
            ImgShow(Threasure1);
            HeyPlaySomething(new Uri(@"Main_theme.mp3", UriKind.RelativeOrAbsolute));
        }
        private void CheckIfInteracted()
        {
            if (ChestMessage1.IsEnabled)
            {
                ImgHide(ChestMessage1);
            }
            if (TaskCompletedImg.IsEnabled)
            {
                ImgHide(TaskCompletedImg);
            }
        }
        //[EN] Complete tasks
        //[RU] Завершение задач.
        private void CollectKey(Image Key, Image Lock)
        {
            ImgHide(Key);
            ImgHide(Lock);
            ImgShow(TaskCompletedImg);
            Sets.LockIndex--;
            Sets.EnemyRate++;
            Sets.MenuTask++;
        }
        //[EN] Target select mech
        //[RU] Механика выбора цели.
        private void InfoAboutEnemies()
        {
            int[] x = { 34, 360, 712 };
            int[] y = { 644, 492, 675 };
            int[] newHP = { Spider.EnemyMHP, Mummy.EnemyMHP , Zombie.EnemyMHP, Bones.EnemyMHP, BOSS1.EnemyMHP };
            LabShow(BattleText1);
            for (int en=0; en < newHP.Length; en++)
            {
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == Foe1.EnemyName[en])
                {
                    BattleText1.Content = Foe1.EnemyName[en];
                    HPenemyBar.Maximum = newHP[en];
                    HPenemyBar.Width = HPenemyBar.Maximum;
                }
            }
            MedMove(Trgt,x[Sets.SelectedTarget] * Adoptation.WidthAdBack, y[Sets.SelectedTarget] * Adoptation.HeightAdBack);
            HPenemyBar.Value = Foe1.EnemyHP[Sets.SelectedTarget];
            LabMove(HPenemy, HPenemyBar.Margin.Left + HPenemyBar.Width - 1 / Adoptation.WidthAdBack, 125 * Adoptation.HeightAdBack);
            HPenemy.Content = HPenemyBar.Value + "/" + HPenemyBar.Maximum;
            LabShow(HPenemy);
        }
        private void SelectWithKeyBoard(bool Left)
        {
            if (Left)
            {
                if (Sets.SelectedTarget > 0)
                {
                    if (Foe1.EnemyHP[1] == 0)
                    {
                        if (!(Foe1.EnemyHP[0] == 0))
                            Sets.SelectedTarget -= 2;
                    }
                    else
                    if (Foe1.EnemyHP[0] == 0)
                    {
                        if (Sets.SelectedTarget > 1)
                            Sets.SelectedTarget--;
                    }
                    else
                    {
                        Sets.SelectedTarget--;
                    }
                    InfoAboutEnemies();
                }
            }
            else
            {
                if (Sets.SelectedTarget < Sets.Rnd1 - 1)
                {
                    if (Foe1.EnemyHP[1] == 0)
                    {
                        if (!(Foe1.EnemyHP[2] == 0))
                            Sets.SelectedTarget += 2;
                    }
                    else
                    if (Foe1.EnemyHP[0] == 0)
                    {
                        if (Sets.SelectedTarget < 2)
                            Sets.SelectedTarget++;
                    }
                    else
                    {
                        Sets.SelectedTarget++;
                    }
                    InfoAboutEnemies();
                }
            }
        }
        private void TablesSetInfo()
        {
            if ((Sets.TableEN)||(TableMessage1.IsEnabled))
            {
                Sets.TableEN = false;
                ImgHide(TableMessage1);
            }
            if ((Adoptation.ImgYbounds == 1020) && (Adoptation.ImgXbounds == -1362))
            {
                if (!Sets.TableEN)
                    Sets.TableEN = true;
                TableMessage1.Source = new BitmapImage(new Uri(@"TableMessage1.png", UriKind.RelativeOrAbsolute));
                ImgShow(TableMessage1);
                ImgMove(TableMessage1, 402 * Adoptation.WidthAdBack, 749 * Adoptation.HeightAdBack);
            }
            if ((Adoptation.ImgYbounds == 780) && (Adoptation.ImgXbounds == -1455))
            {
                if (!Sets.TableEN)
                    Sets.TableEN = true;
                TableMessage1.Source = new BitmapImage(new Uri(@"TableMessage2.png", UriKind.RelativeOrAbsolute));
                ImgShow(TableMessage1);
                ImgMove(TableMessage1, 310 * Adoptation.WidthAdBack, 510 * Adoptation.HeightAdBack);
            }
            if ((Adoptation.ImgYbounds == 330) && (Adoptation.ImgXbounds == -742))
            {
                if (!Sets.TableEN)
                    Sets.TableEN = true;
                TableMessage1.Source = new BitmapImage(new Uri(@"TableMessage3.png", UriKind.RelativeOrAbsolute));
                ImgShow(TableMessage1);
                ImgMove(TableMessage1, 1022 * Adoptation.WidthAdBack, 58 * Adoptation.HeightAdBack);
            }
        }
        private void GetPoisoned()
        {
            if (Super1.PlayerStatus == 1)
            {
                HPbar.Value -= 1;
                HP.Margin = new Thickness(HPbar.Margin.Left + HPbar.Width - 1 / Adoptation.WidthAdBack, 38 * Adoptation.HeightAdBack, 0, 0);
                HP.Content = HPbar.Value + "/" + HPbar.Maximum;
            }
            if (HPbar.Value <= 0)
            {
                Super1.PlayerStatus = 0;
                ImgHide(Img2);
                ImgHide(Menu1);
                MegaHide();
                Sound1.Stop();
                Sound2.Stop();
                Sound3.Stop();
                MediaShow(GameOver);
                timer.Stop();
                timer2.Stop();
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
                if (e.Key == Key.W)
                {
                    if (Img2.Source.ToString().Contains("WalkU1.png"))
                    {
                        Img2.Source = new BitmapImage(new Uri(@"WalkU2.png", UriKind.RelativeOrAbsolute));
                    }
                    else
                        Img2.Source = new BitmapImage(new Uri(@"WalkU1.png", UriKind.RelativeOrAbsolute));
                    //Img2.Source = new BitmapImage(new Uri(@"person2.png", UriKind.RelativeOrAbsolute));
                    if (Adoptation.ImgYbounds > 30)
                    {
                        if (((Adoptation.ImgYbounds > 60) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1486)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1424)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1362)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1672)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -277)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -246)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -215)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -556)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1889)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1858)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1734)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1548)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1486)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1424)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1362)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1300)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -339)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -246)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -215)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -1114)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -990)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1889)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1734)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1672)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1641)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1548)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1424)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1300)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -959)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -649)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -277)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -246)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -1362)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -897)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -773)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -742)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -711)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1796)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1734)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1672)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1641)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1300)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -959)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -463)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -1362)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -1114)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -990)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -835)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -773)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -742)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -339)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1734)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1672)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1641)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1486)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1300)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1021)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -556)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -277)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -215)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -897)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -835)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -711)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -649)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -401)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -153)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -1672)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -1548)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -1486)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -1424)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -1114)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -990)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -339)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -277)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -246)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -215)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -184)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -959)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -897)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -773)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -742)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -711)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -649)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -1486)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -1424)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -1362)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -1114)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -1021)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -990)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -959)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -835)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -773)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -742)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -711)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -339)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -556)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1672)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1641)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1548)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -897)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -463)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -401)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -277)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -246)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -215)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -1858)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -1796)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -1734)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -1486)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -1362)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -990)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -835)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -773)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -649)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -556)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -463)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -1672)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -1548)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -1889)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -1858)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -1641)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -1300)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -1114)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -990)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -897)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -742)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -649)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -463)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -1734)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -711)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -339)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -277)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -246)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -215)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -1672)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -1641)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -1362)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -959)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -773)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -556)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -1114)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -1734)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -1300)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -835)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -773)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -742)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -649)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -463)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -401)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -1889)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -1858)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -1734)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -1114)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -742)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -711)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -649)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -556)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -184)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -1548)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -1486)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -1424)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -1362)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -897)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -835)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -463)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -401)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -1858)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -1300)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -990)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -959)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -401)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -339)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -1672)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -1486)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -835)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -711)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -649)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -556)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -463)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -742)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -401)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -339)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -277)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -246)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -122)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -91)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -1548)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -1362)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -1889)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -1858)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -1734)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -897)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -773)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -711)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -649)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -463)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -401)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -246)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -122)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -1641)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -1424)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 1020) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 1020) || (Adoptation.ImgXbounds != -1114)) && ((Adoptation.ImgYbounds != 1020) || (Adoptation.ImgXbounds != -835)) && ((Adoptation.ImgYbounds != 1020) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 1020) || (Adoptation.ImgXbounds != -556)) && ((Img2.Margin.Top != 1020) || (Img2.Margin.Left != -618)) && ((Adoptation.ImgYbounds != 1020) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 1020) || (Adoptation.ImgXbounds != -277)) && ((Adoptation.ImgYbounds != 1020) || (Adoptation.ImgXbounds != -184)) && ((Adoptation.ImgYbounds != 1020) || (Adoptation.ImgXbounds != -91)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1858)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1796)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -742)) && ((Adoptation.ImgYbounds != 1020) || (Adoptation.ImgXbounds != -1362)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -1455)))
                            if ((Sets.LockIndex < 3) || (((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -1796)) && ((Adoptation.ImgYbounds != 1020) || (Adoptation.ImgXbounds != -1858))))
                                if ((Sets.LockIndex < 2) || (((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -1486)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -1021))))
                                    if ((Sets.LockIndex < 1) || (((Adoptation.ImgYbounds != 1020) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -804))))
                                    {
                                        Img2.Margin = new Thickness(Img2.Margin.Left, Img2.Margin.Top - Adoptation.ImgTopStep, 0, 0);
                                        Adoptation.ImgYbounds -= 30;
                                    }
                    }
                    TablesSetInfo();
                    if (Sets.StepsToBattle >= rnd)
                    {
                        ImgHide(Img2);
                        Sound1.Stop();
                        Dj(new Uri(@"Ambushed.mp3", UriKind.RelativeOrAbsolute));
                        MediaShow(Med2);
                    }
                    Sets.StepsToBattle++;
                    GetPoisoned();
                }
                if (e.Key == Key.A)
                {
                    if (Img2.Source.ToString().Contains("person4.png"))
                    {
                        Img2.Source = new BitmapImage(new Uri(@"WalkL1.png", UriKind.RelativeOrAbsolute));
                    }
                    else
                        Img2.Source = new BitmapImage(new Uri(@"person4.png", UriKind.RelativeOrAbsolute));
                    if (Adoptation.ImgXbounds > -1889)
                    {
                        if (((Adoptation.ImgYbounds > 30) || (Adoptation.ImgXbounds != -1486)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -1300)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -1021)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -959)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -184)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -184)) && ((Adoptation.ImgYbounds != 30) || (Adoptation.ImgXbounds != -959)) && ((Adoptation.ImgYbounds != 30) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 30) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -1641)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -1734)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -1796)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1486)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1021)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -959)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -277)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -1672)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -1021)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -959)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -153)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1486)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1021)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -339)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -122)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -1858)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -1362)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -897)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -122)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1021)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -277)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -122)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -122)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1300)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -959)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -711)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -246)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -122)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -990)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -897)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -246)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -122)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -959)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -339)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -122)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -1641)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -1021)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -959)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -773)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -153)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -1114)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -835)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -1641)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -1114)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -1021)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -184)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -1641)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -897)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -1114)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -339)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -277)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1114)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1021)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -959)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -897)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -711)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -401)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -277)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -1796)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -1734)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -1424)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -711)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -1021)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -711)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -556)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -401)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -1641)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -1548)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -649)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -556)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -401)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -153)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -742)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -463)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -153)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -1548)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -463)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -153)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -1548)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -339)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -153)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -339)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -153)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -1672)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -1548)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -773)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -556)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -463)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -153)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -773)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -1548)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -1362)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -1114)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -742)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -649)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -463)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -246)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -153)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -60)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -1362)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -1300)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -990)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -246)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -153)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -60)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -1362)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -990)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -711)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -556)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -215)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -153)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -60)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -990)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -742)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -556)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -463)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -153)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -990)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -742)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -339)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -215)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -153)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -60)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -1486)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -990)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -649)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -339)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -246)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -153)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -60)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -990)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -649)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -401)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -246)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -153)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -60)) && ((Adoptation.ImgYbounds != 1020) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 1020) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 1020) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 1020) || (Adoptation.ImgXbounds != -990)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -1548)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -773)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -1331))) //&& ((Adoptation.ImgYbounds != 1020) || (Adoptation.ImgXbounds != -587))
                            if ((Sets.LockIndex < 3) || ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -1827)))
                                if ((Sets.LockIndex < 2) || ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -1455)))
                                    if ((Sets.LockIndex < 1) || ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -587)))
                                    {
                                        Adoptation.ImgXbounds -= 31;
                                        Img2.Margin = new Thickness(Img2.Margin.Left - Adoptation.ImgLeftStep, Img2.Margin.Top, 0, 0);
                                    }

                    }
                    TablesSetInfo();
                    if (Sets.StepsToBattle >= rnd)
                    {
                        ImgHide(Img2);
                        Sound1.Stop();
                        Dj(new Uri(@"Ambushed.mp3", UriKind.RelativeOrAbsolute));
                        MediaShow(Med2);
                    }
                    Sets.StepsToBattle++;
                    GetPoisoned();
                }
                if (e.Key == Key.S)
                {
                    if (Img2.Source.ToString().Contains("WalkD1.png"))
                    {
                        Img2.Source = new BitmapImage(new Uri(@"WalkD2.png", UriKind.RelativeOrAbsolute));
                    }
                    else
                        Img2.Source = new BitmapImage(new Uri(@"WalkD1.png", UriKind.RelativeOrAbsolute));
                    //Img2.Source = new BitmapImage(new Uri(@"person1.png", UriKind.RelativeOrAbsolute));
                    if (Adoptation.ImgYbounds < 1020)
                    {
                        if (((Adoptation.ImgYbounds > 30) || (Adoptation.ImgXbounds != -1486)) && ((Adoptation.ImgYbounds > 30) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds > 30) || (Adoptation.ImgXbounds != -1424)) && ((Adoptation.ImgYbounds > 30) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds > 30) || (Adoptation.ImgXbounds != -1362)) && ((Adoptation.ImgYbounds > 30) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 30) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 30) || (Adoptation.ImgXbounds != -1672)) && ((Adoptation.ImgYbounds != 30) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 30) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 30) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 30) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 30) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 30) || (Adoptation.ImgXbounds != -277)) && ((Adoptation.ImgYbounds != 30) || (Adoptation.ImgXbounds != -246)) && ((Adoptation.ImgYbounds != 30) || (Adoptation.ImgXbounds != -215)) && ((Adoptation.ImgYbounds != 30) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -1796)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -1641)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -1114)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -556)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1889)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1858)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1734)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1548)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1486)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1424)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1362)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1300)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -339)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -246)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -215)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -184)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -959)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -401)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -153)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1889)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1734)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1672)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1548)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1486)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1424)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1300)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -711)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -277)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -246)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -215)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -1362)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -1114)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -897)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -835)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -773)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -742)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -339)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1858)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1734)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1672)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1641)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1548)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1424)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1300)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -959)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -1362)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -990)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -773)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -742)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -277)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1300)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1021)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -711)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -649)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1796)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1734)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1672)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1641)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -1114)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -990)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -897)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -835)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1734)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1672)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1486)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1362)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -339)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -277)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -246)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -215)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -959)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -897)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -773)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -742)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -711)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -649)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -1672)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -835)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -556)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -401)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -339)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -277)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -246)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -215)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -1486)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -1424)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -1114)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -1021)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -990)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -959)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -773)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -742)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -711)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -649)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -1641)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -1548)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -897)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -1486)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -1362)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -990)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -835)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -773)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -742)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -556)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -463)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1858)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1672)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1641)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1548)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -339)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -1889)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -1734)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -1424)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -1300)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -1114)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -990)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -959)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -897)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -835)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -649)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -463)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -1672)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -711)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -277)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -246)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -215)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -184)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -1858)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -1641)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -1362)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -897)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -773)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -556)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -1114)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -649)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -1796)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -1734)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -1300)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -773)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -742)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -711)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -556)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -463)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -401)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -1486)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -1889)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -1734)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -1114)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -742)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -649)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -1548)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -1362)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -1300)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -959)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -835)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -463)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -1858)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -1021)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -990)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -773)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -401)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -339)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -277)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -184)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -91)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -1672)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -1641)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -1486)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -1114)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -897)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -835)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -742)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -711)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -649)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -556)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -463)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -1858)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -1548)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -1300)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -401)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -339)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -246)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -122)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -1362)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -835)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -649)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -1889)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -1734)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -711)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -556)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -463)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -401)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -277)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -246)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -122)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -91)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -1424)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -1362)))
                            if ((Sets.LockIndex < 3) || ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -1858)))
                                if ((Sets.LockIndex < 2) || ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -1486)))
                                    if ((Sets.LockIndex < 1) || ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -618)))
                                    {
                                        Adoptation.ImgYbounds += 30;
                                        Img2.Margin = new Thickness(Img2.Margin.Left, Img2.Margin.Top + Adoptation.ImgTopStep, 0, 0);
                                    }
                    }
                    TablesSetInfo();
                    if (Sets.StepsToBattle >= rnd)
                    {
                        ImgHide(Img2);
                        Sound1.Stop();
                        Dj(new Uri(@"Ambushed.mp3", UriKind.RelativeOrAbsolute));
                        MediaShow(Med2);
                    }
                    Sets.StepsToBattle++;
                    GetPoisoned();
                }
                if (e.Key == Key.D)
                {
                    if (Img2.Source.ToString().Contains("person3.png"))
                    {
                        Img2.Source = new BitmapImage(new Uri(@"WalkR1.png", UriKind.RelativeOrAbsolute));
                    }
                    else
                        Img2.Source = new BitmapImage(new Uri(@"person3.png", UriKind.RelativeOrAbsolute));
                    //Img2.Source = new BitmapImage(new Uri(@"person3.png", UriKind.RelativeOrAbsolute));
                    if (Adoptation.ImgXbounds < -61)
                    {
                        if (((Adoptation.ImgYbounds > 30) || (Adoptation.ImgXbounds != -1548)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -1300)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -1021)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -1641)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -1796)) && ((Adoptation.ImgYbounds != 60) || (Adoptation.ImgXbounds != -1858)) && ((Adoptation.ImgYbounds != 30) || (Adoptation.ImgXbounds != -1021)) && ((Adoptation.ImgYbounds != 30) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 30) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1672)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1548)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -1021)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 90) || (Adoptation.ImgXbounds != -339)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -1672)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -1021)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -401)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -277)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1672)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1548)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -1021)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -711)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 150) || (Adoptation.ImgXbounds != -215)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -1858)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -1362)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -990)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -742)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 180) || (Adoptation.ImgXbounds != -339)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -959)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -246)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -1889)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -990)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 240) || (Adoptation.ImgXbounds != -246)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1889)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -1021)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 270) || (Adoptation.ImgXbounds != -246)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -1889)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -1114)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -959)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -742)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -339)) && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -246)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1889)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1641)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1300)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -1021)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -742)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 330) || (Adoptation.ImgXbounds != -215)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -1889)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -1641)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -1021)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -835)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -556)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 360) || (Adoptation.ImgXbounds != -401)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -1889)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -1641)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -990)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -556)) && ((Adoptation.ImgYbounds != 390) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -1889)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -1641)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -1300)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 420) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -1889)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -1641)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -1300)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 450) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -1889)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -1300)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -401)) && ((Adoptation.ImgYbounds != 480) || (Adoptation.ImgXbounds != -339)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1548)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -1021)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -959)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -897)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 510) || (Adoptation.ImgXbounds != -339)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -1889)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -1796)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -1703)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -1486)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -773)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -556)) && ((Adoptation.ImgYbounds != 540) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -1796)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -1672)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -1021)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -773)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -556)) && ((Adoptation.ImgYbounds != 570) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -1765)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -990)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -742)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -463)) && ((Adoptation.ImgYbounds != 600) || (Adoptation.ImgXbounds != -370)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -1889)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -1734)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -1393)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -1300)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -990)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -649)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -215)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -1889)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -1641)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 660) || (Adoptation.ImgXbounds != -215)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -1889)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -1114)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 690) || (Adoptation.ImgXbounds != -215)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -1889)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -1641)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -742)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -401)) && ((Adoptation.ImgYbounds != 720) || (Adoptation.ImgXbounds != -215)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -1641)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -835)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -773)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 750) || (Adoptation.ImgXbounds != -215)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -1114)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -990)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -649)) && ((Adoptation.ImgYbounds != 780) || (Adoptation.ImgXbounds != -556)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -1889)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -1610)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -1424)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -1176)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -835)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -711)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -432)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -215)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -122)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -1734)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -1517)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -1424)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -1362)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -215)) && ((Adoptation.ImgYbounds != 840) || (Adoptation.ImgXbounds != -122)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -1889)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -1672)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -1579)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -1424)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -556)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -463)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -215)) && ((Adoptation.ImgYbounds != 870) || (Adoptation.ImgXbounds != -153)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -1889)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -1672)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -1424)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -1238)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -680)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -525)) && ((Adoptation.ImgYbounds != 900) || (Adoptation.ImgXbounds != -215)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -1672)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -928)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -804)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -742)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -618)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -494)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -215)) && ((Adoptation.ImgYbounds != 930) || (Adoptation.ImgXbounds != -153)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -1672)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -1548)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -1455)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -1083)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -711)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -401)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -215)) && ((Adoptation.ImgYbounds != 960) || (Adoptation.ImgXbounds != -122)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -1269)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -1145)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -866)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -711)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -587)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -463)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -308)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -215)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -122)) && ((Adoptation.ImgYbounds != 1020) || (Adoptation.ImgXbounds != -1827)) && ((Adoptation.ImgYbounds != 1020) || (Adoptation.ImgXbounds != -1331)) && ((Adoptation.ImgYbounds != 1020) || (Adoptation.ImgXbounds != -1207)) && ((Adoptation.ImgYbounds != 1020) || (Adoptation.ImgXbounds != -1052)) && ((Adoptation.ImgYbounds != 210) || (Adoptation.ImgXbounds != -1300)) && ((Adoptation.ImgYbounds != 810) || (Adoptation.ImgXbounds != -1362)) && ((Adoptation.ImgYbounds != 120) || (Adoptation.ImgXbounds != -835))  && ((Adoptation.ImgYbounds != 300) || (Adoptation.ImgXbounds != -773)) && ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -1393)))//&& ((Adoptation.ImgYbounds != 1020) || (Adoptation.ImgXbounds != -649))
                            if ((Sets.LockIndex < 3) || ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -1889)))
                                if ((Sets.LockIndex < 2) || ((Adoptation.ImgYbounds != 630) || (Adoptation.ImgXbounds != -1517)))
                                    if ((Sets.LockIndex < 1) || ((Adoptation.ImgYbounds != 990) || (Adoptation.ImgXbounds != -649)))
                                    {
                                        Adoptation.ImgXbounds += 31;
                                        Img2.Margin = new Thickness(Img2.Margin.Left + Adoptation.ImgLeftStep, Img2.Margin.Top, 0, 0);
                                    }
                    }
                    TablesSetInfo();
                    if (Sets.StepsToBattle >= rnd)
                    {
                        ImgHide(Img2);
                        Sound1.Stop();
                        Dj(new Uri(@"Ambushed.mp3", UriKind.RelativeOrAbsolute));
                        MediaShow(Med2);
                    }
                    Sets.StepsToBattle++;
                    GetPoisoned();
                }
                if (e.Key == Key.E)
                {
                    Uri DoorSound1 = new Uri(@"DoorOpened1.mp3", UriKind.RelativeOrAbsolute);
                    Uri ChestSound1 = new Uri(@"ChestOpened1.mp3", UriKind.RelativeOrAbsolute);
                    Uri BossSound1 = new Uri(@"Horror.mp3", UriKind.RelativeOrAbsolute);
                    var uriSourceCH = new Uri(@"ChestOpened(ver1).png", UriKind.RelativeOrAbsolute);
                    Uri Armor1 = new Uri(@"GetItemsArmor1.png", UriKind.RelativeOrAbsolute);
                    Uri Weapon1 = new Uri(@"GetItemsCustomWeapon1.png", UriKind.RelativeOrAbsolute);
                    Uri Pants1 = new Uri(@"GetItemsCustomPants1.png", UriKind.RelativeOrAbsolute);
                    Uri Boots1 = new Uri(@"GetItemsCustomBoots1.png", UriKind.RelativeOrAbsolute);
                    if ((Adoptation.ImgYbounds == 150) && (Adoptation.ImgXbounds == -804) && (Img2.Source.ToString().Contains("person2.png")))
                    {
                        HeyPlaySomething(BossSound1);
                        Sets.BossPharaoh = true;
                        Img2.IsEnabled = false;
                        MediaShow(PharaohBattle);
                    }
                    if (((Adoptation.ImgYbounds == 810) && (Adoptation.ImgXbounds == -1362)) && (Img2.Source.ToString().Contains("person3.png")) && (ChestImg4.Source.ToString().Contains("ChestClosed(ver1).png")))
                    {
                        ChestMessage1.Margin = new Thickness(460*Adoptation.WidthAdBack, 660 * Adoptation.HeightAdBack, 0, 0);
                        ImgShow(ChestMessage1);
                        ChestMessage1.Source = new BitmapImage(Armor1);
                        ChestImg4.Source = new BitmapImage(uriSourceCH);
                        BAG.Jacket = true;
                        SEF(ChestSound1);
                    }
                    if (((Adoptation.ImgYbounds == 210) && (Adoptation.ImgXbounds == -1300)) && (Img2.Source.ToString().Contains("person3.png")) && (ChestImg2.Source.ToString().Contains("ChestClosed(ver1).png")))
                    {
                        ChestMessage1.Margin = new Thickness(557 * Adoptation.WidthAdBack, 60 * Adoptation.HeightAdBack, 0, 0);
                        ImgShow(ChestMessage1);
                        ChestMessage1.Source = new BitmapImage(Weapon1);
                        ChestImg2.Source = new BitmapImage(uriSourceCH);
                        BAG.Hands = true;
                        SEF(ChestSound1);
                    }
                    if (((Adoptation.ImgYbounds == 270) && (Adoptation.ImgXbounds == -1269)) && (Img2.Source.ToString().Contains("person4.png")) && (ChestImg3.Source.ToString().Contains("ChestClosed(ver1).png")))
                    {
                        ChestMessage1.Margin = new Thickness(526 * Adoptation.WidthAdBack, 119 * Adoptation.HeightAdBack, 0, 0);
                        ImgShow(ChestMessage1);
                        ChestMessage1.Source = new BitmapImage(Pants1);
                        ChestImg3.Source = new BitmapImage(uriSourceCH);
                        BAG.Legs = true;
                        SEF(ChestSound1);
                    }
                    if (((Adoptation.ImgYbounds == 720) && (Adoptation.ImgXbounds == -1548)) && (Img2.Source.ToString().Contains("person4.png")) && (ChestImg1.Source.ToString().Contains("ChestClosed(ver1).png")))
                    {
                        ChestMessage1.Margin = new Thickness(248 * Adoptation.WidthAdBack, 571 * Adoptation.HeightAdBack, 0, 0);
                        ImgShow(ChestMessage1);
                        ChestMessage1.Source = new BitmapImage(Boots1);
                        ChestImg1.Source = new BitmapImage(uriSourceCH);
                        BAG.Boots = true;
                        SEF(ChestSound1);
                    }

                    //W
                    if (((Adoptation.ImgYbounds == 1020) && (Adoptation.ImgXbounds == -618)) && (Img2.Source.ToString().Contains("person2.png")))
                    {
                        ImgMove(TaskCompletedImg, 1207 * Adoptation.WidthAdBack, 840 * Adoptation.HeightAdBack);
                        CollectKey(KeyImg3, LockImg3);
                        SEF(DoorSound1);
                    }
                    if (((Adoptation.ImgYbounds == 1020) && (Adoptation.ImgXbounds == -1858)) && (Img2.Source.ToString().Contains("person2.png")))
                    {
                        ImgMove(TaskCompletedImg, 0 * Adoptation.WidthAdBack, 840 * Adoptation.HeightAdBack);
                        CollectKey(KeyImg1, LockImg1);
                        SEF(DoorSound1);
                    }
                    if (((Adoptation.ImgYbounds == 660) && (Adoptation.ImgXbounds == -1486)) && (Img2.Source.ToString().Contains("person2.png")))
                    {
                        ImgMove(TaskCompletedImg, 340 * Adoptation.WidthAdBack, 539 * Adoptation.HeightAdBack);
                        CollectKey(KeyImg2, LockImg2);
                        SEF(DoorSound1);
                    }
                    //S
                    if (((Adoptation.ImgYbounds == 960) && (Adoptation.ImgXbounds == -618)) && (Img2.Source.ToString().Contains("person1.png")))
                    {
                        ImgMove(TaskCompletedImg, 1207 * Adoptation.WidthAdBack, 840 * Adoptation.HeightAdBack);
                        CollectKey(KeyImg3, LockImg3);
                        SEF(DoorSound1);
                    }
                    if (((Adoptation.ImgYbounds == 960) && (Adoptation.ImgXbounds == -1858)) && (Img2.Source.ToString().Contains("person1.png")))
                    {
                        ImgMove(TaskCompletedImg, 0 * Adoptation.WidthAdBack, 840 * Adoptation.HeightAdBack);
                        CollectKey(KeyImg1, LockImg1);
                        SEF(DoorSound1);
                    }
                    if (((Adoptation.ImgYbounds == 600) && (Adoptation.ImgXbounds == -1486)) && (Img2.Source.ToString().Contains("person1.png")))
                    {
                        ImgMove(TaskCompletedImg, 340 * Adoptation.WidthAdBack, 539 * Adoptation.HeightAdBack);
                        CollectKey(KeyImg2, LockImg2);
                        SEF(DoorSound1);
                    }
                    //A
                    if (((Adoptation.ImgYbounds == 990) && (Adoptation.ImgXbounds == -587)) && (Img2.Source.ToString().Contains("person4.png")))
                    {
                        ImgMove(TaskCompletedImg, 1207 * Adoptation.WidthAdBack, 840 * Adoptation.HeightAdBack);
                        CollectKey(KeyImg3, LockImg3);
                        SEF(DoorSound1);
                    }
                    if (((Adoptation.ImgYbounds == 990) && (Adoptation.ImgXbounds == -1827)) && (Img2.Source.ToString().Contains("person4.png")))
                    {
                        ImgMove(TaskCompletedImg, 0 * Adoptation.WidthAdBack, 840 * Adoptation.HeightAdBack);
                        CollectKey(KeyImg1, LockImg1);
                        SEF(DoorSound1);
                    }
                    if (((Adoptation.ImgYbounds == 630) && (Adoptation.ImgXbounds == -1455)) && (Img2.Source.ToString().Contains("person4.png")))
                    {
                        ImgMove(TaskCompletedImg, 340 * Adoptation.WidthAdBack, 539 * Adoptation.HeightAdBack);
                        CollectKey(KeyImg2, LockImg2);
                        SEF(DoorSound1);
                    }
                    //D
                    if (((Adoptation.ImgYbounds == 990) && (Adoptation.ImgXbounds == -649)) && (Img2.Source.ToString().Contains("person3.png")))
                    {
                        ImgMove(TaskCompletedImg, 1207 * Adoptation.WidthAdBack, 840 * Adoptation.HeightAdBack);
                        CollectKey(KeyImg3, LockImg3);
                        SEF(DoorSound1);
                    }
                    if (((Adoptation.ImgYbounds == 990) && (Adoptation.ImgXbounds == -1889)) && (Img2.Source.ToString().Contains("person3.png")))
                    {
                        ImgMove(TaskCompletedImg, 0 * Adoptation.WidthAdBack, 840 * Adoptation.HeightAdBack);
                        CollectKey(KeyImg1, LockImg1);
                        SEF(DoorSound1);
                    }
                    if (((Adoptation.ImgYbounds == 630) && (Adoptation.ImgXbounds == -1517)) && (Img2.Source.ToString().Contains("person3.png")))
                    {
                        ImgMove(TaskCompletedImg, 340 * Adoptation.WidthAdBack, 539 * Adoptation.HeightAdBack);
                        CollectKey(KeyImg2, LockImg2);
                        SEF(DoorSound1);
                    }
                }
            }
            else
            {
                if ((Fight.IsEnabled) || (ACT1.IsEnabled) || (ACT2.IsEnabled))
                {
                    //int[] x = { 34, 360, 712 };
                    //int[] y = { 644, 492, 675 };
                    if (e.Key == Key.W)
                    {
                        SelectWithKeyBoard(true);
                    }
                    if (e.Key == Key.A)
                    {
                        SelectWithKeyBoard(true);
                    }
                    if (e.Key == Key.S)
                    {
                        SelectWithKeyBoard(false);
                    }
                    if (e.Key == Key.D)
                    {
                        SelectWithKeyBoard(false);
                    }
                }
            }
            if (e.Key == Key.LeftCtrl)
            {
                if ((!Med1.IsEnabled) && (!Button1.IsEnabled))
                    if (!Menu1.IsEnabled)
                    {
                        if (Sets.TableEN)
                        {
                            Sets.TableEN = false;
                            ImgHide(TableMessage1);
                        }
                        if ((Adoptation.ImgYbounds == 1020) && (Adoptation.ImgXbounds == -1362))
                        {
                            if (!Sets.TableEN)
                                Sets.TableEN = true;
                            TableMessage1.Source = new BitmapImage(new Uri(@"TableMessage1.png", UriKind.RelativeOrAbsolute));
                            ImgShow(TableMessage1);
                            ImgMove(TableMessage1, 402 * Adoptation.WidthAdBack, 749 * Adoptation.HeightAdBack);
                        }
                        if ((Adoptation.ImgYbounds == 780) && (Adoptation.ImgXbounds == -1455))
                        {
                            if (!Sets.TableEN)
                                Sets.TableEN = true;
                            TableMessage1.Source = new BitmapImage(new Uri(@"TableMessage2.png", UriKind.RelativeOrAbsolute));
                            ImgShow(TableMessage1);
                            ImgMove(TableMessage1, 310 * Adoptation.WidthAdBack, 510 * Adoptation.HeightAdBack);
                        }
                        if ((Adoptation.ImgYbounds == 330) && (Adoptation.ImgXbounds == -742))
                        {
                            if (!Sets.TableEN)
                                Sets.TableEN = true;
                            TableMessage1.Source = new BitmapImage(new Uri(@"TableMessage3.png", UriKind.RelativeOrAbsolute));
                            ImgShow(TableMessage1);
                            ImgMove(TableMessage1, 1022 * Adoptation.WidthAdBack, 58 * Adoptation.HeightAdBack);
                        }
                        ATK1.Content = Super1.Attack + Super1.PlayerEQ[0];
                        DEF1.Content = Super1.Defence + Super1.PlayerEQ[1] + Super1.PlayerEQ[2] + Super1.PlayerEQ[3];
                        AG1.Content = Super1.Speed;
                        SP1.Content = Super1.Special;
                        Image[] IMGSlctrl = { Menu1, Img2, Img1, Icon0, EquipHImg, EquipBImg, EquipLImg, EquipDImg, ATKImg, DEFImg, AGImg,SPImg };
                        Label[] LABSlctrl = { Name0, Level0, StatusP, Exp1, HPtext1, APtext1, HP1, AP1, Describe1, Describe2, Params, ParamsATK, ParamsDEF, ParamsAG, ParamsSP, EquipText, ATK1, DEF1, AG1, SP1, EquipH, EquipB, EquipL, EquipD };
                        ProgressBar[] BARSlctrl= { HPbar1, APbar1, ExpBar1 };
                        Button[] BTNSlctrl = { Abils, Items0, Equip, Tasks, Info };
                        foreach (Image img in IMGSlctrl)
                        {
                            ImgShow(img);
                        }
                        Status.IsEnabled = false;
                        Status.Visibility = Visibility.Visible;
                        foreach (Button btn in BTNSlctrl)
                        {
                            ButtonShow(btn);
                        }
                        foreach (ProgressBar brs in BARSlctrl)
                        {
                            BarShow(brs);
                        }
                        HPbar1.Width = HPbar.Width * 2;
                        HPbar1.Maximum = HPbar.Maximum;
                        HPbar1.Value = HPbar.Value;
                        APbar1.Width = APbar.Width * 2;
                        APbar1.Maximum = APbar.Maximum;
                        APbar1.Value = APbar.Value;
                        foreach (Label lab in LABSlctrl)
                        {
                            LabShow(lab);
                        }
                        Level0.Content = "Уровень: " + Super1.CurrentLevel;
                        if (Super1.PlayerStatus == 1)
                            StatusP.Content = "Статус: отравлен";
                        else
                            StatusP.Content = "Статус: здоров";
                        ExpBar1.Width = NextExpBar.Width * 1.5;
                        ExpBar1.Maximum = NextExpBar.Maximum;
                        ExpBar1.Value = NextExpBar.Value;
                        Exp1.Content = ExpText.Content;
                        if (Convert.ToString(Exp1.Content)!="Максимальный")
                            Exp1.Margin = new Thickness(881 * Adoptation.WidthAdBack + 30*Adoptation.WidthAdBack, Exp1.Margin.Top, 0, 0);
                        else
                            Exp1.Margin = new Thickness(881 * Adoptation.WidthAdBack + 60 * Adoptation.WidthAdBack, Exp1.Margin.Top, 0, 0);
                        //System.Windows.MessageBox.Show(Exp1.Margin.Left.ToString());
                        Describe2.Content = "";
                        SP1.Content = Super1.Special;
                        Double[] HeightAdopt = { 121,121,121 };
                        Double[] WidthAdopt = { 278,470,706 };
                        Label[] labm = { Name0, Level0, StatusP };
                        for (int it = 0; it < labm.Length; it++)
                        {
                            LabMove(labm[it], WidthAdopt[it] * Adoptation.WidthAdBack, HeightAdopt[it] * Adoptation.HeightAdBack);
                        }
                        BarMove(HPbar1, 418 * Adoptation.WidthAdBack, 275 * Adoptation.HeightAdBack);
                        BarMove(APbar1, 418 * Adoptation.WidthAdBack, 352 * Adoptation.HeightAdBack);
                        LabMove(HPtext1, HPbar1.Margin.Left - 300 * Adoptation.WidthAdBack, HPbar1.Margin.Top - 7 * Adoptation.HeightAdBack);
                        LabMove(APtext1, APbar1.Margin.Left - 300 * Adoptation.WidthAdBack, APbar1.Margin.Top - 7 * Adoptation.HeightAdBack);
                        LabMove(HP1, HPbar1.Margin.Left + HPbar1.Width + 30 * Adoptation.WidthAdBack, HPbar1.Margin.Top - 7);
                        LabMove(AP1, APbar1.Margin.Left + APbar1.Width + 30 * Adoptation.HeightAdBack, APbar1.Margin.Top - 7);
                        HP1.Content = HPbar1.Value + "/" + HPbar1.Maximum;
                        AP1.Content = APbar1.Value + "/" + APbar1.Maximum;
                        if (Super1.PlayerStatus == 0)
                        {
                            Icon0.Source = new BitmapImage(new Uri(@"person6.png", UriKind.RelativeOrAbsolute));
                        }
                        else
                        {
                            Icon0.Source = new BitmapImage(new Uri(@"IconPoisoned.png", UriKind.RelativeOrAbsolute));
                        }
                        Describe1.Content = "Подсказка: следите за тем, чтобы ОЗ не упало до 0, иначе герой погибнет.\nТакже уделяйте внимание АВШ - после её заполнения действовать придётся\nпредельно быстро, иначе ваши оппоненты и пепла от вас не оставят.";
                        LabShow(Describe1);
                    }
                    else
                    {
                        ImgHide(Menu1);
                        ImgShow(Img2);
                        ImgShow(Img1);
                        ButtonHide(Status);
                        ButtonHide(Abils);
                        ButtonHide(Items0);
                        ButtonHide(Equip);
                        ButtonHide(Tasks);
                        ButtonHide(Info);
                        MegaHide();
                    }
            }
            if (e.Key == Key.Escape)
                Form1.Close();
        }

        private void MegaHide()
        {
            Image[] MegaHIDEImg = { Icon0, EquipHImg, EquipBImg, EquipLImg, EquipDImg, ATKImg, DEFImg, AGImg, SPImg, Task1Img, Task2Img, Task3Img, Task4Img };
            ProgressBar[] MegaHIDEBar = { HPbar1 , APbar1, ExpBar1 };
            Label[] MegaHIDELab = { Name0, StatusP, Exp1, HPtext1, APtext1, HP1, AP1, Describe1, Describe2, Params, ParamsATK, ParamsDEF, ParamsAG, ParamsSP, EquipText, ATK1, DEF1, AG1, SP1, EquipH, EquipB, EquipL, EquipD, CureCost, HealCost, CostText, CureDescribe, HealDescribe, Task1, Task2, Task3, Task4, InfoHeaderText1, InfoHeaderText2, InfoHeaderText3, InfoText1, InfoText2, InfoText3, InfoIndex, Level0, AntidoteText, EtherText, BandageText,FusedText };
            Button[] MegaHIDEButton={ Ether1, Bandage, Antidote, Cure1, Heal1, Fused, Equip1, Equip2, Equip3, Equip4, Remove1, Remove2, Remove3, Remove4, Equipments, CancelEq, InfoIndexPlus, InfoIndexMinus };
            foreach (Image Img in MegaHIDEImg) {
                ImgHide(Img);
            }
            foreach (ProgressBar Bar in MegaHIDEBar)
            {
                BarHide(Bar);
            }
            foreach (Label Lab in MegaHIDELab)
            {
                LabHide(Lab);
            }
            foreach (Button Btn in MegaHIDEButton)
            {
                ButtonHide(Btn);
            }
        }

        private void Med2_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (Img2.Source.ToString().Contains("WalkU1.png") || Img2.Source.ToString().Contains("WalkU2.png"))
            {
                Img2.Source = new BitmapImage(new Uri(@"person1.png", UriKind.RelativeOrAbsolute));
            }
            else if (Img2.Source.ToString().Contains("WalkL1.png"))
            {
                Img2.Source = new BitmapImage(new Uri(@"person4.png", UriKind.RelativeOrAbsolute));
            }
            else if (Img2.Source.ToString().Contains("WalkD1.png")|| Img2.Source.ToString().Contains("WalkD2.png"))
            {
                Img2.Source = new BitmapImage(new Uri(@"person1.png", UriKind.RelativeOrAbsolute));
            }
            else if (Img2.Source.ToString().Contains("WalkR1.png"))
            {
                Img2.Source = new BitmapImage(new Uri(@"person3.png", UriKind.RelativeOrAbsolute));
            }
            if (Super1.CurrentLevel < 10)
                LevelText.Content = "Ур. " + Super1.CurrentLevel;
            else
                LevelText.Content = "Ур." + Super1.CurrentLevel;
            TablesAllTurnOff1();
            if (Sets.TableEN)
                ImgHide(TableMessage1);
            HPbar.Maximum = Super1.MaxHPNxt[Super1.CurrentLevel - 1];
            APbar.Maximum = Super1.MaxAPNxt[Super1.CurrentLevel - 1];
            LabShow(HP);
            LabShow(AP);
            HP.Margin = new Thickness(HPbar.Margin.Left + HPbar.Width - 1 / Adoptation.WidthAdBack, 38 * Adoptation.HeightAdBack, 0, 0);
            HP.Content = HPbar.Value + "/" + HPbar.Maximum;
            AP.Margin = new Thickness(APbar.Margin.Left + APbar.Width - 1 / Adoptation.WidthAdBack, 87 * Adoptation.HeightAdBack, 0, 0);
            AP.Content = APbar.Value + "/" + APbar.Maximum;
            int[] x = { 34, 360, 712 };
            int[] y = { 644, 492, 675 };
            Lab2.Foreground = Brushes.Yellow;
            MediaHide(Med2);
            speed = 0;
            ImgHide(Threasure1);
            Trgt.Margin = new Thickness(x[0] * Adoptation.WidthAdBack, y[0] * Adoptation.HeightAdBack, 0, 0);
            ImgHide(Img1);
            ImgHide(Img2);
            ImgShow(Img3);
            ImgShow(Img4);
            ImgShow(Img5);
            ChestsAllTurnOff1();
            KeysAllTurnOff1();
            LocksAllTurnOff1();
            LabShow(Lab2);
            ButtonShow(Button2);
            ButtonShow(Button3);
            if (!Sets.BossPharaoh)
                Button4.IsEnabled = true;
            Button4.Visibility = Visibility.Visible;
            if (Super1.CurrentLevel >= 2)
                Abilities.IsEnabled = true;
            Abilities.Visibility = Visibility.Visible;
            ButtonShow(Items);
            LabShow(HPtext);
            LabShow(APtext);
            BarShow(HPbar);
            BarShow(APbar);
            LabShow(TimeText);
            LabShow(HeroName);
            LabShow(LevelText);
            BarShow(NextExpBar);
            LabShow(ExpText);
            BarShow(Time1);
            Time1.Value = 100;
            var uriSource = new Uri(@"Battle_theme2.mp3", UriKind.RelativeOrAbsolute);
            var PharaohSource = new Uri(@"Pharaoh.mp3", UriKind.RelativeOrAbsolute);
            var SpiderSRC = new Uri(@"Spider.png", UriKind.RelativeOrAbsolute);
            var MummySRC = new Uri(@"Mummy.png", UriKind.RelativeOrAbsolute);
            var ZombieSRC = new Uri(@"Zombie.png", UriKind.RelativeOrAbsolute);
            var DefenderSRC = new Uri(@"Bones.png", UriKind.RelativeOrAbsolute);
            var PharaohSRC = new Uri(@"Pharaoh.png", UriKind.RelativeOrAbsolute);
            if (!Sets.BossPharaoh)
                HeyPlaySomething(uriSource);
            else
                HeyPlaySomething(PharaohSource);
            Sets.StepsToBattle = 0;
            rnd = Random1.Next(5, 20);
            if (!Sets.BossPharaoh)
            {
                Sets.Rnd1 = Random1.Next(1, 4);
                Foe1.EnemiesStillAlive = (byte)Sets.Rnd1;
                for (int ib = 1; ib <= Sets.Rnd1; ib++)
                {
                    Sets.Rnd2 = Random1.Next(1, Sets.EnemyRate);
                    if (Sets.Rnd2 == 1)
                    {
                        LabShow(BattleText3);
                        if (ib == 1)
                        {
                            Foe1.EnemyHP[0] = 65;
                            Img6.Source = new BitmapImage(SpiderSRC);
                            Foe1.EnemyAppears[0] = "Паук ";
                        }
                        if (ib == 2)
                        {
                            Foe1.EnemyHP[1] = 65;
                            Img7.Source = new BitmapImage(SpiderSRC);
                            Foe1.EnemyAppears[1] = "Паук ";
                        }
                        if (ib == 3)
                        {
                            Foe1.EnemyHP[2] = 65;
                            Img8.Source = new BitmapImage(SpiderSRC);
                            Foe1.EnemyAppears[2] = "Паук ";
                        }
                        Exp += 5;
                        Sets.SpiderAlive += 1;
                        Sets.ItemsDropRate[0] += 1;
                    }
                    if (Sets.Rnd2 == 2)
                    {
                        LabShow(BattleText4);
                        if (ib == 1)
                        {
                            Foe1.EnemyHP[0] = 83;
                            Img6.Source = new BitmapImage(MummySRC);
                            Foe1.EnemyAppears[0] = "Мумия";
                        }
                        if (ib == 2)
                        {
                            Foe1.EnemyHP[1] = 83;
                            Img7.Source = new BitmapImage(MummySRC);
                            Foe1.EnemyAppears[1] = "Мумия";
                        }
                        if (ib == 3)
                        {
                            Foe1.EnemyHP[2] = 83;
                            Img8.Source = new BitmapImage(MummySRC);
                            Foe1.EnemyAppears[2] = "Мумия";
                        }
                        Exp += 8;
                        Sets.MummyAlive += 1;
                        Sets.ItemsDropRate[1] += 1;
                    }
                    if (Sets.Rnd2 == 3)
                    {
                        LabShow(BattleText5);
                        if (ib == 1)
                        {
                            Foe1.EnemyHP[0] = 101;
                            Img6.Source = new BitmapImage(ZombieSRC);
                            Foe1.EnemyAppears[0] = "Зомби";
                        }
                        if (ib == 2)
                        {
                            Foe1.EnemyHP[1] = 101;
                            Img7.Source = new BitmapImage(ZombieSRC);
                            Foe1.EnemyAppears[1] = "Зомби";
                        }
                        if (ib == 3)
                        {
                            Foe1.EnemyHP[2] = 101;
                            Img8.Source = new BitmapImage(ZombieSRC);
                            Foe1.EnemyAppears[2] = "Зомби";
                        }
                        Exp += 12;
                        Sets.ZombieAlive += 1;
                        Sets.ItemsDropRate[2] += 1;
                    }
                    if (Sets.Rnd2 == 4)
                    {
                        LabShow(BattleText6);
                        if (ib == 1)
                        {
                            Foe1.EnemyHP[0] = 125;
                            Img6.Source = new BitmapImage(DefenderSRC);
                            Foe1.EnemyAppears[0] = "Страж";
                        }
                        if (ib == 2)
                        {
                            Foe1.EnemyHP[1] = 125;
                            Img7.Source = new BitmapImage(DefenderSRC);
                            Foe1.EnemyAppears[1] = "Страж";
                        }
                        if (ib == 3)
                        {
                            Foe1.EnemyHP[2] = 125;
                            Img8.Source = new BitmapImage(DefenderSRC);
                            Foe1.EnemyAppears[2] = "Страж";
                        }
                        Exp += 15;
                        Sets.BonesAlive += 1;
                        Sets.ItemsDropRate[3] += 1;
                    }
                }
                string spdr = "Паук ";
                string mum = "Мумия";
                string zomb = "Зомби";
                string defd = "Страж";
                //"            "
                if (Sets.SpiderAlive != 0)
                    BattleText3.Content = spdr + "              " + Sets.SpiderAlive;
                if (Sets.MummyAlive != 0)
                    BattleText4.Content = mum + "           " + Sets.MummyAlive;
                if (Sets.ZombieAlive != 0)
                    BattleText5.Content = zomb + "            " + Sets.ZombieAlive;
                if (Sets.BonesAlive != 0)
                    BattleText6.Content = defd + "            " + Sets.BonesAlive;
                switch (Sets.Rnd1)
                {
                    case 1:
                        ImgShow(Img6);
                        break;
                    case 2:
                        ImgShow(Img6);
                        ImgShow(Img7);
                        break;
                    case 3:
                        ImgShow(Img6);
                        ImgShow(Img7);
                        ImgShow(Img8);
                        break;
                    default:
                        ImgShow(Img6);
                        break;
                }
            }
            else
            {
                Sets.Rnd1 = 1;
                Foe1.EnemiesStillAlive = (byte)Sets.Rnd1;
                BattleText3.Content = "Фараон           " + Foe1.EnemiesStillAlive;
                LabShow(BattleText3);
                Foe1.EnemyAppears[0] = "Фараон";
                Foe1.EnemyHP[0] = 500;
                Img6.Source = new BitmapImage(PharaohSRC);
                Img6.Margin = new Thickness(Img6.Margin.Left, Img6.Margin.Top - 150 * Adoptation.HeightAdBack, 0, 0);
                Img6.Width = 450 * Adoptation.WidthAdBack;
                Img6.Height = 450 * Adoptation.HeightAdBack;
                MedMove(Trgt, Img6.Margin.Left, Img6.Margin.Top);
                MedShrink(Trgt, 450 * Adoptation.WidthAdBack, 450 * Adoptation.HeightAdBack);
                ImgShow(Img6);
                Exp += 125;
            }
            if (Super1.PlayerStatus == 0)
            {
                Icon0.Source = new BitmapImage(new Uri(@"person6.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                Icon0.Source = new BitmapImage(new Uri(@"IconPoisoned.png", UriKind.RelativeOrAbsolute));
            }
            TimeEnemy();
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            ButtonHide(Button2);
            ButtonHide(Button3);
            ButtonHide(Button4);
            ButtonShow(Fight);
            ButtonHide(Items);
            ButtonShow(Cancel1);
            ButtonHide(Abilities);
            SelectTarget();
        }

        public void SelectTarget()
        {
            LabMove(BattleText1, 473 * Adoptation.WidthAdBack, 5 * Adoptation.HeightAdBack);
            LabShrink(BattleText1, 48 * Adoptation.WidthAdBack);
            LabShow(BattleText1);
            if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Паук ")
            {
                BattleText1.Content = "Паук ";
                HPenemyBar.Maximum = 65;
                HPenemyBar.Width = HPenemyBar.Maximum*Adoptation.WidthAdBack;
            }
            if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Мумия")
            {
                BattleText1.Content = "Мумия";
                HPenemyBar.Maximum = 83;
                HPenemyBar.Width = HPenemyBar.Maximum * Adoptation.WidthAdBack;
            }
            if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Зомби")
            {
                BattleText1.Content = "Зомби";
                HPenemyBar.Maximum = 101;
                HPenemyBar.Width = HPenemyBar.Maximum * Adoptation.WidthAdBack;
            }
            if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Страж")
            {
                BattleText1.Content = "Страж";
                HPenemyBar.Maximum = 125;
                HPenemyBar.Width = HPenemyBar.Maximum * Adoptation.WidthAdBack;
            }
            if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Страж")
            {
                BattleText1.Content = "Страж";
                HPenemyBar.Maximum = 125;
                HPenemyBar.Width = HPenemyBar.Maximum * Adoptation.WidthAdBack;
            }
            if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Фараон")
            {
                BattleText1.Content = "Фараон";
                HPenemyBar.Maximum = 500;
                HPenemyBar.Width = HPenemyBar.Maximum * Adoptation.WidthAdBack;
            }
            LabShow(HPenemy);
            BarShow(HPenemyBar);
            HPenemyBar.Value = Foe1.EnemyHP[Sets.SelectedTarget];
            HPenemy.Margin = new Thickness(HPenemyBar.Margin.Left + HPenemyBar.Width - 1/ Adoptation.WidthAdBack, 125 * Adoptation.HeightAdBack, 0, 0);
            HPenemy.Content = HPenemyBar.Value + "/" + HPenemyBar.Maximum;
            Trgt.IsEnabled = true;
            Trgt.Visibility = Visibility.Visible;
            Trgt.Play();
        }

        private void Med3_MediaEnded(object sender, RoutedEventArgs e)
        {
            Med3Stop();
        }

        private void Med3Stop()
        {
            Med3.Stop();
            Med3.Position = new TimeSpan(0, 0, 0, 0, 0);
            MediaHide(Med3);
            LabHide(BattleText1);
            LabHide(BattleText2);
            if (speed > 0)
            {
                Sets.SpiderAlive = 0;
                Sets.MummyAlive = 0;
                Sets.ZombieAlive = 0;
                Sets.BonesAlive = 0;
                Foe1.EnemyHP[0] = 0;
                Foe1.EnemyHP[1] = 0;
                Foe1.EnemyHP[2] = 0;
                Exp = 0;
                LabHide(HP);
                LabHide(AP);
                ImgShow(Img1);
                ImgShow(Img2);
                ImgHide(Img3);
                ImgHide(Img4);
                ImgHide(Img5);
                ImgHide(Img6);
                ImgHide(Img7);
                ImgHide(Img8);
                BarHide(Time1);
                speed = 0;
                timer2.Stop();
                Sound1.Stop();
                LabHide(Lab2);
                LabHide(HPtext);
                LabHide(APtext);
                ChestsAllTurnOn1();
                TablesAllTurnOn1();
                if (Sets.TableEN)
                    ImgShow(TableMessage1);
                BarHide(HPbar);
                BarHide(APbar);
                LabHide(HeroName);
                LabHide(LevelText);
                BarHide(NextExpBar);
                LabHide(ExpText);
                LabHide(TimeText);
                LabHide(BattleText3);
                LabHide(BattleText4);
                LabHide(BattleText5);
                LabHide(BattleText6);
                ImgShow(Threasure1);
                switch (Sets.LockIndex)
                {
                    case 0:
                        break;
                    case 1:
                        ImgShow(KeyImg3);
                        ImgShow(LockImg3);
                        break;
                    case 2:
                        ImgShow(KeyImg2);
                        ImgShow(LockImg2);
                        ImgShow(KeyImg3);
                        ImgShow(LockImg3);
                        break;
                    case 3:
                        KeysAllTurnOn1();
                        LocksAllTurnOn1();
                        break;
                    default:
                        KeysAllTurnOn1();
                        LocksAllTurnOn1();
                        break;
                }
                MediaHide(Med4);
                if (Super1.CurrentLevel >= 2)
                    Abilities.IsEnabled = false;
                Abilities.Visibility = Visibility.Hidden;
                HeyPlaySomething(new Uri(@"Main_theme.mp3", UriKind.RelativeOrAbsolute));
            }
            else
            if (Foe1.EnemiesStillAlive == 0)
            {
                timer2.Stop();
                Foe1.EnemyHP[0] = 0;
                Foe1.EnemyHP[1] = 0;
                Foe1.EnemyHP[2] = 0;
                speed = 0;
                Foe1.EnemiesStillAlive = 0;
                int item = 0;
                string itemName = "";
                string itemName2 = "";
                string itemName3 = "";
                string itemName4 = "";
                if (Sets.ItemsDropRate[0] != 0)
                {
                    int rndItem = Random1.Next(Sets.ItemsDropRate[0], 8);
                    if (rndItem == 5)
                    {
                        itemName = "Антидот";
                        item++;
                    }
                    Sets.ItemsDropRate[0] = 0;
                }
                if (Sets.ItemsDropRate[1] != 0)
                {
                    int rndItem = Random1.Next(Sets.ItemsDropRate[1], 8);
                    if (rndItem == 5)
                    {
                        itemName2 = "Бинт";
                        item++;
                    }
                    Sets.ItemsDropRate[1] = 0;
                }
                if (Sets.ItemsDropRate[2] != 0)
                {
                    int rndItem = Random1.Next(Sets.ItemsDropRate[2], 8);
                    if (rndItem == 5)
                    {
                        itemName3 = "Эфир";
                        item++;
                    }
                    Sets.ItemsDropRate[2] = 0;
                }
                if (Sets.ItemsDropRate[3] != 0)
                {
                    int rndItem = Random1.Next(Sets.ItemsDropRate[3], 8);
                    if (rndItem == 5)
                    {
                        itemName4 = "Смесь";
                        item++;
                    }
                    Sets.ItemsDropRate[3] = 0;
                }
                BattleText3.Content = "";
                if ((item > 0) && (itemName == "Антидот"))
                {
                    if (BAG.AntidoteITM < 99)
                        BAG.AntidoteITM += 1;
                    item -= 1;
                    BattleText3.Content = "Получено:\n" + itemName;
                }
                if ((item > 0) && (itemName2 == "Бинт"))
                {
                    if (Convert.ToString(BattleText3.Content) == "")
                    {
                        if (BAG.BandageITM < 99)
                            BAG.BandageITM += 1;
                        item -= 1;
                        BattleText3.Content = "Получено:\n" + itemName2;
                    }
                    else
                    {
                        if (BAG.BandageITM < 99)
                            BAG.BandageITM += 1;
                        item -= 1;
                        BattleText3.Content = BattleText3.Content + "\n" + itemName2;
                    }
                }
                if ((item > 0) && (itemName4 == "Смесь"))
                {
                    if (Convert.ToString(BattleText3.Content) == "")
                    {
                        if (BAG.FusedITM < 99)
                            BAG.FusedITM += 1;
                        item -= 1;
                        BattleText3.Content = "Получено:\n" + itemName4;
                    }
                    else
                    {
                        if (BAG.FusedITM < 99)
                            BAG.FusedITM += 1;
                        item -= 1;
                        BattleText3.Content = BattleText3.Content + "\n" + itemName4;
                    }
                }
                if ((item > 0) && (itemName3 == "Эфир"))
                {
                    if (Convert.ToString(BattleText3.Content) == "")
                    {
                        if (BAG.EtherITM < 99)
                            BAG.EtherITM += 1;
                        item -= 1;
                        BattleText3.Content = "Получено:\n" + itemName3;
                    }
                    else
                    {
                        if (BAG.EtherITM < 99)
                            BAG.EtherITM += 1;
                        item -= 1;
                        BattleText3.Content = BattleText3.Content + "\n" + itemName3;
                    }
                }
                if (Convert.ToString(BattleText3.Content) == "")
                {
                    LabHide(BattleText3);
                }
                Sets.ItemsDropRate[0] = 0;
                Sets.ItemsDropRate[1] = 0;
                Sets.ItemsDropRate[2] = 0;
                Sets.ItemsDropRate[3] = 0;
                Sound1.Stop();
                SEF(new Uri(@"YouWon.mp3", UriKind.RelativeOrAbsolute));
                ImgHide(EnemyCursor);
                LabMove(BattleText1, 723 * Adoptation.WidthAdBack, 45 * Adoptation.HeightAdBack);
                LabShrink(BattleText1, 72 * Adoptation.WidthAdBack);
                BattleText1.Content = "Победа!";
                BattleText2.Content = "Получено " + Exp + " очков опыта";
                ImgShow(Img4);
                LabShow(BattleText1);
                LabShow(BattleText2);
                if (Super1.CurrentLevel < 10)
                {
                    if ((NextExpBar.Value + Exp) < NextExpBar.Maximum)
                    {
                        NextExpBar.Value = NextExpBar.Value + Exp;
                        ExpText.Content = "Опыт " + Convert.ToString(NextExpBar.Value) + "/" + Super1.NextLevel[Super1.CurrentLevel - 1];
                        ButtonShow(TextOk1);
                        Exp = 0;
                    }
                    else
                    {
                        ButtonShow(textOk2);
                    }
                }
                else
                {
                    ButtonShow(TextOk1);
                }
            }
            else
            {
                if (HPbar.Value != 0)
                {
                    ImgShow(Img4);
                    Time();
                }
            }
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Super1.DefenseState = 2;
            ButtonHide(Button2);
            ButtonHide(Button3);
            ButtonHide(Button4);
            ButtonHide(Abilities);
            ButtonHide(Items);
            Time1.Value = 0;
            Img5.Source = new BitmapImage(new Uri(@"IconDefence1.png", UriKind.RelativeOrAbsolute));
            Img4.Source = new BitmapImage(new Uri(@"Defence.png", UriKind.RelativeOrAbsolute));
            Lab2.Foreground = Brushes.White;
            Dj(new Uri(@"Defence.mp3", UriKind.RelativeOrAbsolute));
            Time();
        }

        private void Time()
        {
            if ((Time1.Value == 100)&&(HPbar.Value!=0))
            {
                Super1.DefenseState = 1;
                var uriSource = new Uri(@"pers5.png", UriKind.RelativeOrAbsolute);
                var uriSource1 = new Uri(@"person6.png", UriKind.RelativeOrAbsolute);
                if (Super1.PlayerStatus == 0)
                    uriSource1 = new Uri(@"person6.png", UriKind.RelativeOrAbsolute);
                else
                    uriSource1 = new Uri(@"IconPoisoned.png", UriKind.RelativeOrAbsolute);
                Img4.Source = new BitmapImage(uriSource);
                Img5.Source = new BitmapImage(uriSource1);
                ButtonShow(Button2);
                ButtonShow(Button3);
                if (!Sets.BossPharaoh)
                    Button4.IsEnabled = true;
                Button4.Visibility = Visibility.Visible;
                ButtonShow(Items);
                if (Super1.CurrentLevel >= 2)
                    Abilities.IsEnabled = true;
                Abilities.Visibility = Visibility.Visible;
                Lab2.Foreground = Brushes.Yellow;
            }
            else
            {
                timer = new System.Windows.Threading.DispatcherTimer();
                timer.Tick += new EventHandler(timerTick);
                timer.Interval = new TimeSpan(0, 0, 0, 0, 40 - Super1.Speed);
                timer.Start();
            }
        }
        private void TimeEnemy()
        {
            int aglfoe = 25;
            if ((Foe1.EnemyHP[0] != 0) || (Foe1.EnemyHP[1] != 0) || (Foe1.EnemyHP[2] != 0))
            {
                timer2 = new System.Windows.Threading.DispatcherTimer();
                timer2.Tick += new EventHandler(timerTick2);
                timer2.Interval = new TimeSpan(0, 0, 0, 0, 50 - aglfoe);
                timer2.Start();
            }
        }

        private int CheckEnemies(out int EnemyAttack, int pos)
        {
            EnemyAttack = 25;
            //Foe1.EnemyName[4] = "Фараон";
            for (int i = 0; i< Foe1.EnemyName.Length; i++)
            {
                //Foe.Stats[] FS = new Foe.Stats[] { Spider, Mummy, Zombie, Bones, BOSS1 };
                if (Foe1.EnemyAppears[pos-1] == Foe1.EnemyName[i])
                {
                    Foe.Stats[] FS = new Foe.Stats[] { Spider, Mummy, Zombie, Bones, BOSS1 };
                    EnemyAttack = FS[i].EnemyAttack;
                    break;
                }
            }
            return EnemyAttack;
        }
        private int GetOut(out int Speed)
        {
            Speed = 10;
            for (int i = 0; i < Foe1.EnemyAppears.Length; i++)
            {
                for (int j = 0; j < Foe1.EnemyName.Length; j++) {
                    if (Foe1.EnemyAppears[i] == Foe1.EnemyName[j])
                    {
                        Foe.Stats[] FS = new Foe.Stats[] { Spider, Mummy, Zombie, Bones, BOSS1 };
                        if (Speed< FS[j].EnemySpeed)
                            Speed = FS[j].EnemySpeed;
                    }
                }
            }
            return Speed;
        }

        private string NameEnemies(out string enemy, int pos)
        {
            enemy = "Паук";
            for (int i = 0; i < Foe1.EnemyName.Length; i++)
            {
                if (Foe1.EnemyAppears[pos] == Foe1.EnemyName[i])
                {
                    Foe.Stats[] FS = new Foe.Stats[] { Spider, Mummy, Zombie, Bones, BOSS1 };
                    enemy = FS[i].EnemyName[i];
                    break;
                }
            }
            return enemy;
        }

        private string EnemySounds(in int pos)
        {
            string ogg="";
            for (int i = 0; i < Foe1.EnemyName.Length; i++)
            {
                if (Foe1.EnemyAppears[pos] == Foe1.EnemyName[i])
                {
                    string[] sounds =  { "SpiderDied","MummyDied","ZombieDied","BonesDied", "DefeatPharaoh" };
                    ogg = sounds[i];
                    break;
                }
            }
            return ogg;
        }

        private void EnemyOnAttack(in string enemy, in int dmg)
        {
            BattleText1.Content = enemy + " атакует!\nРэй получает " + dmg + " урона!";
            HPbar.Value = HPbar.Value - dmg;
            HP.Margin = new Thickness(HPbar.Margin.Left + HPbar.Width - 1 / Adoptation.WidthAdBack, 38 * Adoptation.HeightAdBack, 0, 0);
            HP.Content = HPbar.Value + "/" + HPbar.Maximum;
            LabMove(BattleText1, 473 * Adoptation.WidthAdBack, 5 * Adoptation.HeightAdBack);
            LabShrink(BattleText1, 48 * Adoptation.WidthAdBack);
            ImgShow(EnemyCursor);
        }

        private void timerTick2(object sender, EventArgs e)
        {
            /*if (Med3.Position.TotalMilliseconds>=99995)
            {
                Med3_MediaEnded(Med3, null);
            }
            if (Med4.Position.TotalMilliseconds >= 99995)
            {
                Med4_MediaEnded(Med4, null);
            }*/
            if (HPbar.Value == 0)
            {
                Super1.PlayerStatus = 0;
                Sound1.Stop();
                Sound2.Stop();
                Sound3.Stop();
                LabHide(BattleText3);
                MediaShow(GameOver);
                GameOver.Play();
                if (timer!=null)
                    timer.Stop();
                timer2.Stop();
                //HPbar.Value = 100;
            }
            if ((Super1.PlayerStatus == 1)&&(HPbar.Value!=0))
            {
                if (poison < 30)
                {
                    poison += 1;
                }
                else
                {
                    poison = 0;
                    HPbar.Value = HPbar.Value - 1;
                    HP.Content = HPbar.Value + "/" + HPbar.Maximum;
                }
            }
            string enemy = "";
            int EnemyAttack = 25;
            int PlayerDef = Super1.Defence*Super1.DefenseState + Super1.PlayerEQ[1] + Super1.PlayerEQ[2] + Super1.PlayerEQ[3];
            var uriSource = new Uri(@"IconPoisoned.png", UriKind.RelativeOrAbsolute);
            if (((Foe1.EnemyHP[0] != 0) || (Foe1.EnemyHP[1] != 0) || (Foe1.EnemyHP[2] != 0))&& (HPbar.Value != 0))
            {
                if (Foe1.EnemyHP[0] != 0)
                    if (Foe1.EnemyTurn[0] == 200)
                    {
                        Foe1.EnemyTurn[0] = 0;
                        EnemyAttack = CheckEnemies(out EnemyAttack, 1);
                        enemy = NameEnemies(out enemy, 1);
                        if (EnemyAttack > PlayerDef)
                        {
                            int dmg = EnemyAttack - PlayerDef;
                            EnemyOnAttack(enemy, dmg);
                            EnemyCursor.Margin = new Thickness(Img6.Margin.Left + Img6.Width / 4, Img6.Margin.Top - 120 * Adoptation.HeightAdBack, 0, 0);
                            if ((Random1.Next(1, 13) == 7) && (Super1.PlayerStatus != 1) && (Foe1.EnemyAppears[0] == "Паук "))
                            {
                                Img5.Source = new BitmapImage(uriSource);
                                LabShow(BattleText2);
                                BattleText2.Content = "Рэй отравлен!";
                                Super1.PlayerStatus = 1;
                            }
                            LabShow(BattleText1);
                        }
                    }
                    else
                        Foe1.EnemyTurn[0] += 1;
                if (Foe1.EnemyHP[1] != 0)
                    if (Foe1.EnemyTurn[1] == 200)
                    {
                        Foe1.EnemyTurn[0] = 0;
                        EnemyAttack = CheckEnemies(out EnemyAttack, 1);
                        enemy=NameEnemies(out enemy, 1);
                        Foe1.EnemyTurn[1] = 0;
                        if (EnemyAttack > PlayerDef)
                        {
                            int dmg = EnemyAttack - PlayerDef;
                            EnemyOnAttack(enemy, dmg);
                            EnemyCursor.Margin = new Thickness(Img7.Margin.Left + Img7.Width / 4, Img7.Margin.Top - 120 * Adoptation.HeightAdBack, 0, 0);
                            if ((Random1.Next(1, 13) == 7) && (Super1.PlayerStatus != 1) && (Foe1.EnemyAppears[1] == "Паук "))
                            {
                                Img5.Source = new BitmapImage(uriSource);
                                LabShow(BattleText2);
                                BattleText2.Content = "Рэй отравлен!";
                                Super1.PlayerStatus = 1;
                            }
                            LabShow(BattleText1);
                        }
                    }
                    else
                        Foe1.EnemyTurn[1] += 1;
                if (Foe1.EnemyHP[2] != 0)
                    if (Foe1.EnemyTurn[2] == 200)
                    {
                        EnemyAttack = CheckEnemies(out EnemyAttack, 1);
                        enemy = NameEnemies(out enemy, 1);
                        Foe1.EnemyTurn[2] = 0;
                        if (EnemyAttack > PlayerDef)
                        {
                            int dmg = EnemyAttack - PlayerDef;
                            EnemyOnAttack(enemy, dmg);
                            EnemyCursor.Margin = new Thickness(Img8.Margin.Left + Img8.Width / 4, Img8.Margin.Top - 120 * Adoptation.HeightAdBack, 0, 0);
                            if ((Random1.Next(1, 13) == 7) && (Super1.PlayerStatus != 1) && (Foe1.EnemyAppears[2] == "Паук "))
                            {
                                Img5.Source = new BitmapImage(uriSource);
                                LabShow(BattleText2);
                                BattleText2.Content = "Рэй отравлен!";
                                Super1.PlayerStatus = 1;
                            }
                            LabShow(BattleText1);
                        }
                    }
                    else
                        Foe1.EnemyTurn[2] += 1;
                if ((Foe1.EnemyTurn[0] == 15) || (Foe1.EnemyTurn[1] == 15) || (Foe1.EnemyTurn[2] == 15))
                {
                    if (Convert.ToString(BattleText2.Content) == "Рэй отравлен!")
                    {
                        LabHide(BattleText2);
                    }
                    LabHide(BattleText1);
                    ImgHide(EnemyCursor);
                }
            }
        }

        private void timerTick(object sender, EventArgs e)
        {
            if (Time1.Value < 100)
                Time1.Value += 1;
            else
            {
                timer.Stop();
                Time();
            }

        }

        private void Skip1_Click(object sender, RoutedEventArgs e)
        {
            ButtonHide(Skip1);
            Med1.Position = new TimeSpan(0, 0, 0, 7, 500);
        }

        private void Sound1_MediaEnded(object sender, RoutedEventArgs e)
        {
            Sound1.Stop();
            Sound1.Position = TimeSpan.Zero;
            Sound1.Play();
        }
        private void FightMenuMakesDisappear()
        {
            ButtonHide(Button2);
            ButtonHide(Button3);
            ButtonHide(Button4);
            ButtonHide(Abilities);
            ButtonHide(Items);
        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            int agl = Super1.Speed;
            int fagl = 10;
            FightMenuMakesDisappear();
            
            
            fagl = GetOut(out fagl);
            Time1.Value = 0;
            Lab2.Foreground = Brushes.White;
            if (agl > fagl)
            {
                ImgHide(EnemyCursor);
                timer2.Stop();
                speed = 1;
            }
            else
            {
                BattleText2.Content ="Не удается сбежать!";
                LabShow(BattleText2);
            }
            Med4.Source = new Uri(@"IconEscape1.avi", UriKind.RelativeOrAbsolute);
            Med3.Source = new Uri(@"Escape2.avi", UriKind.RelativeOrAbsolute);
            MediaShow(Med4);
            MediaShow(Med3);
            Dj(new Uri(@"Escape.mp3", UriKind.RelativeOrAbsolute));
        }

        private void Med4_MediaEnded(object sender, RoutedEventArgs e)
        {
            Med4Stop();
        }
        
        private void Med4Stop()
        {
            Med4.Position = new TimeSpan(0, 0, 0, 0, 0);
            MediaHide(Med4);
            if (!Img2.IsEnabled)
            {
                if (Super1.PlayerStatus == 0)
                {
                    Img5.Source = new BitmapImage(new Uri(@"person6.png", UriKind.RelativeOrAbsolute));
                }
                if (HPbar.Value!=0)
                    ImgShow(Img5);
            }
            else
            {
                
            }
        }
        private void FightMenuBack()
        {
            ButtonShow(Button2);
            ButtonShow(Button3);
            if (!Sets.BossPharaoh)
                ButtonShow(Button4);
            else
            {
                Button4.Visibility = Visibility.Visible;
            }
            if (Super1.CurrentLevel >= 2)
                ButtonShow(Abilities);
            else
            {
                Abilities.Visibility = Visibility.Visible;
            }
            ButtonShow(Items);
        }
        private void Trgt_MediaEnded(object sender, RoutedEventArgs e)
        {
            Trgt.Stop();
            Med1.Position = new TimeSpan(0, 0, 0, 0, 0);
            Trgt.Play();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UInt16[] x = { 34, 360, 712 };
            UInt16[] y = { 644, 492, 675 };
            UInt16 strength = Convert.ToUInt16(Super1.Attack + Super1.PlayerEQ[0]);
            Byte PharaohAura = 0;
            MediaHide(Trgt);
            LabHide(BattleText1);
            BattleText1.Margin = new Thickness(473 * Adoptation.WidthAdBack, 45 * Adoptation.HeightAdBack, 0, 0);
            BattleText1.FontSize = 48*Adoptation.WidthAdBack;
            if (Sets.BossPharaoh)
            {
                PharaohAura = 25;
            }
            BattleText1.Content = Foe1.EnemyAppears[Sets.SelectedTarget] + " получает " + (strength - PharaohAura) + " урона!";
            LabShow(BattleText1);
            BarHide(HPenemyBar);
            LabHide(HPenemy);
            ButtonHide(Fight);
            ButtonHide(Cancel1);
            
            Time1.Value = 0;
            Lab2.Foreground = Brushes.White;
            
            if (Foe1.EnemyHP[Sets.SelectedTarget] - (strength - PharaohAura) < 0)
            {
                Foe1.EnemyHP[Sets.SelectedTarget] = 0;
            }
            else
            {
                Foe1.EnemyHP[Sets.SelectedTarget] = Convert.ToUInt16(Foe1.EnemyHP[Sets.SelectedTarget] - (strength - PharaohAura));
            }
            if (Foe1.EnemyHP[Sets.SelectedTarget] == 0)
            {
                ImgHide(EnemyCursor);
                BattleText2.Content = Foe1.EnemyAppears[Sets.SelectedTarget] + " погибает!";
                LabShow(BattleText2);
                string res = "";
                res = EnemySounds(Sets.SelectedTarget);
                SEF(new Uri(@"" + res + ".mp3", UriKind.RelativeOrAbsolute));
            }
            string spdr = "Паук ";
            string mum = "Мумия";
            string zomb = "Зомби";
            string defd = "Страж";
            if (Foe1.EnemyHP[Sets.SelectedTarget] == 0)
            {
                switch (Sets.SelectedTarget)
                {
                    case 0:
                        ImgHide(Img6);
                        break;
                    case 1:
                        ImgHide(Img7);
                        break;
                    case 2:
                        ImgHide(Img8);
                        break;
                }
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Паук ")
                {
                    Sets.SpiderAlive--;
                    BattleText3.Content = spdr + "              " + Sets.SpiderAlive;
                    if (Sets.SpiderAlive == 0)
                    {
                        BattleText2.Content = Foe1.EnemyAppears[Sets.SelectedTarget] + " погибает!";
                        LabShow(BattleText2);
                        LabHide(BattleText3);
                        BattleText3.Content = "";
                        Foe1.EnemyAppears[Sets.SelectedTarget] = "";
                    }
                }
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Мумия")
                {
                    Sets.MummyAlive--;
                    BattleText4.Content = mum + "           " + Sets.MummyAlive;
                    if (Sets.MummyAlive == 0)
                    {
                        BattleText2.Content = Foe1.EnemyAppears[Sets.SelectedTarget] + " погибает!";
                        LabShow(BattleText2);
                        LabHide(BattleText4);
                        BattleText4.Content = "";
                        Foe1.EnemyAppears[Sets.SelectedTarget] = "";
                    }
                }
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Зомби")
                {
                    Sets.ZombieAlive--;
                    BattleText5.Content = zomb + "            " + Sets.ZombieAlive;
                    if (Sets.ZombieAlive == 0)
                    {
                        BattleText2.Content = Foe1.EnemyAppears[Sets.SelectedTarget] + " погибает!";
                        LabShow(BattleText2);
                        LabHide(BattleText5);
                        BattleText5.Content = "";
                        Foe1.EnemyAppears[Sets.SelectedTarget] = "";
                    }
                }
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Страж")
                {
                    Sets.BonesAlive--;
                    BattleText6.Content = defd + "            " + Sets.BonesAlive;
                    if (Sets.BonesAlive == 0)
                    {
                        BattleText2.Content = Foe1.EnemyAppears[Sets.SelectedTarget] + " погибает!";
                        LabShow(BattleText2);
                        LabHide(BattleText6);
                        BattleText6.Content = "";
                        Foe1.EnemyAppears[Sets.SelectedTarget] = "";
                    }
                }
                if (Foe1.EnemyHP[0] != 0)
                    Sets.SelectedTarget = 0;
                else
                    if (Foe1.EnemyHP[1] != 0)
                    Sets.SelectedTarget = 1;
                else
                    if (Foe1.EnemyHP[2] != 0)
                    Sets.SelectedTarget = 2;
                Trgt.Margin = new Thickness(x[Sets.SelectedTarget]*Adoptation.WidthAdBack, y[Sets.SelectedTarget] * Adoptation.HeightAdBack, 0, 0);
                Foe1.EnemiesStillAlive = Convert.ToByte(Foe1.EnemiesStillAlive - 1);
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Фараон")
                {
                    if (Foe1.EnemiesStillAlive == 0)
                    {
                        BattleText2.Content = Foe1.EnemyAppears[Sets.SelectedTarget] + " погибает!";
                        LabShow(BattleText2);
                        LabHide(BattleText6);
                        BattleText6.Content = "";
                        Foe1.EnemyAppears[Sets.SelectedTarget] = "";
                    }

                }
            }
            Med3.Source = new Uri(@"HandAttack3.avi", UriKind.RelativeOrAbsolute);
            MediaShow(Med3);
            Dj(new Uri(@"Punch.mp3", UriKind.RelativeOrAbsolute));
            Med4.Source = new Uri(@"IconRage1.avi", UriKind.RelativeOrAbsolute);
            MediaShow(Med4);
        }

        private void Cancel1_Click(object sender, RoutedEventArgs e)
        {
            Sets.SelectedTarget = 0;
            ButtonHide(Fight);
            ButtonHide(Cancel1);
            FightMenuBack();
            LabHide(HPenemy);
            BarHide(HPenemyBar);
            LabHide(BattleText1);
            MediaHide(Trgt);
        }

        private void Win_MediaEnded(object sender, RoutedEventArgs e)
        {
            WinStop();
        }

        private void WinStop()
        {
            WonOrDied();
            switch (Sets.LockIndex)
            {
                case 0:
                    break;
                case 1:
                    ImgShow(KeyImg3);
                    ImgShow(LockImg3);
                    break;
                case 2:
                    ImgShow(KeyImg2);
                    ImgShow(LockImg2);
                    ImgShow(KeyImg3);
                    ImgShow(LockImg3);
                    break;
                case 3:
                    KeysAllTurnOn1();
                    LocksAllTurnOn1();
                    break;
                default:
                    KeysAllTurnOn1();
                    LocksAllTurnOn1();
                    break;
            }
            ImgShow(Threasure1);
            ImgShow(Img2);
            ChestsAllTurnOn1();
            TablesAllTurnOn1();
            if (Sets.TableEN)
                ImgShow(TableMessage1);
            MediaHide(Win);
            MediaHide(Med4);
            ImgHide(Img5);
            Win.Position = new TimeSpan(0, 0, 0, 0, 0);
            HeyPlaySomething(new Uri(@"Main_theme.mp3", UriKind.RelativeOrAbsolute));
        }
        private void Sound2_MediaEnded(object sender, RoutedEventArgs e)
        {
            Sound2.Stop();
        }

        private void Win_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            WonOrDied();
            Win.Stop();
            ImgShow(Img2);
        }

        private void TextOk1_Click(object sender, RoutedEventArgs e)
        {
            if (!Sets.BossPharaoh)
            {
                Win.Source = new Uri(@"Win.mp4", UriKind.RelativeOrAbsolute);
                MediaShow(Win);
                LabHide(BattleText1);
                LabHide(BattleText2);
                LabHide(BattleText3);
                ImgHide(Img1);
            }
            else
            {
                LabHide(BattleText1);
                LabHide(BattleText2);
                LabHide(BattleText3);
                MediaShow(TheEnd);
                Img1.Source=new BitmapImage(new Uri(@"AbsoluteBlack.jpg", UriKind.RelativeOrAbsolute));
            }
            Sound1.Stop();
            ImgShow(Img1);
        }
        private void WonOrDied()
        {
            Sound1.Stop();
            LabHide(BattleText1);
            LabHide(BattleText2);
            LabHide(BattleText3);
            LabHide(Lab2);
            ButtonHide(TextOk1);
            ButtonHide(Button2);
            ButtonHide(Button3);
            ButtonHide(Button4);
            ButtonHide(Items);
            ButtonHide(Abilities);
            ButtonHide(textOk2);
            BarHide(Time1);
            BarHide(HPbar);
            BarHide(APbar);
            BarHide(NextExpBar);
            ImgHide(Img3);
            ImgHide(Img4);
            ImgHide(Img5);
            ImgHide(Img6);
            ImgHide(Img7);
            ImgHide(Img8);
            LabHide(HPtext);
            LabHide(APtext);
            LabHide(HeroName);
            LabHide(LevelText);
            LabHide(ExpText);
            LabHide(TimeText);
            LabHide(HP);
            LabHide(AP);
            LabHide(ATK);
            LabHide(SP);
            ImgHide(EnemyCursor);
        }
        public void TextCh1()
        {
            LabShow(BattleText2);
        }

        public void DisableBattleText()
        {
            LabHide(BattleText2);
        }

        private void Button4_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Сбежать из боя";
            TextCh1();
        }

        private void Button4_MouseLeave(object sender, MouseEventArgs e)
        {
            DisableBattleText();
        }

        private void Button3_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Встать в стойку (Защита Х2)";
            TextCh1();
        }

        private void Button3_MouseLeave(object sender, MouseEventArgs e)
        {
            DisableBattleText();
        }

        private void Button2_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Атаковать выбранного врага";
            TextCh1();
        }

        private void Button2_MouseLeave(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Подтвердить выбор";
            DisableBattleText();
        }

        private void Cancel1_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Отменить нападение";
            TextCh1();
        }

        private void Cancel1_MouseLeave(object sender, MouseEventArgs e)
        {
            DisableBattleText();
        }

        private void Fight_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Подтвердить выбор";
            TextCh1();
        }

        private void Fight_MouseLeave(object sender, MouseEventArgs e)
        {
            if (Foe1.EnemyHP[Sets.SelectedTarget] != 0)
                DisableBattleText();
        }

        private void HideFightIconPersActions()
        {
            BarHide(HPenemyBar);
            LabHide(BattleText4);
            LabHide(BattleText5);
            LabHide(BattleText6);
            LabHide(HPenemy);
            LabHide(ItemText);
            ImgHide(ItemsCountImg);
            ImgHide(Img4);
            ImgHide(Img5);
            ButtonHide(Cure);
            ButtonHide(Heal);
            ButtonHide(Torch);
            ButtonHide(Whip);
            ButtonHide(Super);
            ButtonHide(Back1);
            ButtonHide(Button2);
            ButtonHide(Button3);
            ButtonHide(Button4);
            ButtonHide(Items);
            ButtonHide(Abilities);
            ButtonHide(Fight);
            ButtonHide(Cancel1);
            ButtonHide(ACT1);
            ButtonHide(ACT2);
            ButtonHide(Cancel2);
            MediaHide(Trgt);
        }

        private void GameOver_MediaEnded(object sender, RoutedEventArgs e)
        {
            MediaHide(Med3);
            MediaHide(Med4);
            MediaHide(GameOver);
            GameOver.Stop();
            if (timer != null)
                timer.Stop();
            WonOrDied();
            ChestsAllTurnOff1();
            KeysAllTurnOff1();
            LocksAllTurnOff1();
            TablesAllTurnOff1();
            ImgHide(Threasure1);
            Img1.Source = new BitmapImage(new Uri(@"New_game_show.jpg", UriKind.RelativeOrAbsolute));
            HideFightIconPersActions();
            ImgShow(Img1);
            ButtonShow(Button1);
            LabShow(Lab1);
            Sound1.Position = new TimeSpan(0,0,0,0,0);
            HeyPlaySomething(new Uri(@"Begin2.mp3", UriKind.RelativeOrAbsolute));
            ButtonHide(Button2);
            ButtonHide(Button3);
            ButtonHide(Button4);
        }

        private void AbilitiesMakeDisappear1()
        {
            ButtonHide(Cure);
            ButtonHide(Torch);
            ButtonHide(Heal);
            ButtonHide(Back1);
            ButtonHide(Whip);
            ButtonHide(Super);
        }
        private void Back1_Click(object sender, RoutedEventArgs e)
        {
            AbilitiesMakeDisappear1();
            FightMenuBack();
        }

        private void Back1_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Вернуться к действиям";
            TextCh1();
        }

        private void Back1_MouseLeave(object sender, MouseEventArgs e)
        {
            DisableBattleText();
        }

        private void Cure_Click(object sender, RoutedEventArgs e)
        {
            
            
            Med3.Source = new Uri(@"CurePerson2.avi", UriKind.RelativeOrAbsolute);
            Med4.Source = new Uri(@"CureIcon2.avi", UriKind.RelativeOrAbsolute);
            MediaShow(Med3);
            MediaShow(Med4);
            Dj(new Uri(@"Cure.mp3", UriKind.RelativeOrAbsolute));
            if (((Super1.Special * 2) + HPbar.Value) >= HPbar.Maximum)
            {
                HPbar.Value = HPbar.Maximum;
                HP.Content = HPbar.Value + "/" + HPbar.Maximum;
            }
            else
            {
                HPbar.Value = HPbar.Value + Super1.Special * 2;
                HP.Content = HPbar.Value + "/" + HPbar.Maximum;
            }
            APbar.Value -= 2;
            AP.Content = APbar.Value + "/" + APbar.Maximum;
            AbilitiesMakeDisappear1();
            Time1.Value = 0;
        }

        private void Cure_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Восстановит ОЗ, Стоит: 2 ОД";
            TextCh1();
        }

        private void Cure_MouseLeave(object sender, MouseEventArgs e)
        {
            DisableBattleText();
        }

        private void Abilities_Click(object sender, RoutedEventArgs e)
        {
            Cure.Visibility = Visibility.Visible;
            if (APbar.Value >= 1)
                Cure.IsEnabled = true;
            if (Super1.CurrentLevel >= 3)
            {
                Torch.Visibility = Visibility.Visible;
                if (APbar.Value >= 4)
                    Torch.IsEnabled = true;
            }
            if (Super1.CurrentLevel >= 4)
            {
                Heal.Visibility = Visibility.Visible;
                if (APbar.Value >= 1)
                    Heal.IsEnabled = true;
            }
            if (Super1.CurrentLevel >= 6)
            {
                Whip.Visibility = Visibility.Visible;
                if (APbar.Value >= 6)
                    Whip.IsEnabled = true;
            }
            if (Super1.CurrentLevel >= 7)
            {
                Super.Visibility = Visibility.Visible;
                if (APbar.Value >= 10)
                    Super.IsEnabled = true;
            }
            ButtonShow(Back1);
            FightMenuMakesDisappear();
        }

        private void Abilities_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Особые умения";
            TextCh1();
        }

        private void Abilities_MouseLeave(object sender, MouseEventArgs e)
        {
            DisableBattleText();
        }

        private void textOk2_Click(object sender, RoutedEventArgs e)
        {
            int ex = 0;
            Super1.CurrentLevel += 1;
            if (Exp > NextExpBar.Maximum)
                ex = Convert.ToInt32(Exp - NextExpBar.Maximum);
            else
                ex = Convert.ToInt32(NextExpBar.Value + Exp - NextExpBar.Maximum);
            NextExpBar.Maximum = Super1.NextLevel[Super1.CurrentLevel - 1];
            NextExpBar.Value = ex;
            if (Super1.CurrentLevel < 10)
                LevelText.Content = "Ур. " + Super1.CurrentLevel;
            else
                LevelText.Content = "Ур." + Super1.CurrentLevel;
            HPbar.Maximum = Super1.MaxHPNxt[Super1.CurrentLevel - 1];
            APbar.Maximum = Super1.MaxAPNxt[Super1.CurrentLevel - 1];
            if (HPbar.Maximum > 200)
                HPbar.Width = 200 * Adoptation.WidthAdBack;
            else
                HPbar.Width = HPbar.Maximum * Adoptation.WidthAdBack;
            if (APbar.Maximum > 200)
                APbar.Width = 200 * Adoptation.WidthAdBack;
            else
                APbar.Width = APbar.Maximum * Adoptation.WidthAdBack;
            HPbar.Value = HPbar.Maximum;
            APbar.Value = APbar.Maximum;
            HP.Margin = new Thickness(HPbar.Margin.Left + HPbar.Width- 1 / Adoptation.WidthAdBack, 38 * Adoptation.HeightAdBack, 0, 0);
            HP.Content = HPbar.Value + "/" + HPbar.Maximum;
            AP.Margin = new Thickness(APbar.Margin.Left + APbar.Width- 1 / Adoptation.WidthAdBack, 87 * Adoptation.HeightAdBack, 0, 0);
            AP.Content = APbar.Value + "/" + APbar.Maximum;
            if (Super1.CurrentLevel < 10)
                ExpText.Content = "Опыт " + Convert.ToString(ex) + "/" + Super1.NextLevel[Super1.CurrentLevel - 1];
            else
            {
                ExpText.Content = "Максимальный";
                NextExpBar.Value = NextExpBar.Maximum;
            }
            ImgHide(Img5);
            Med4.Source = new Uri(@"LevelUP.mp4", UriKind.RelativeOrAbsolute);
            MediaShow(Med4);
            ButtonHide(textOk2);
            BattleText2.Content = "Рэй получает уровень " + Super1.CurrentLevel + "!";
            BattleText1.Margin = new Thickness(473*Adoptation.WidthAdBack, 15 * Adoptation.HeightAdBack, 0, 0);
            BattleText1.FontSize = 60 * Adoptation.WidthAdBack;
            BattleText1.Content = "Новый\nуровень!";
            switch (Super1.CurrentLevel)
            {
                case 2:
                    BattleText3.Content = "Изучено:\nЛечение";
                    LabShow(BattleText3);
                    break;
                case 3:
                    BattleText3.Content = "Изучено:\nФакел";
                    LabShow(BattleText3);
                    break;
                case 4:
                    BattleText3.Content = "Изучено:\nИсцеление";
                    LabShow(BattleText3);
                    break;
                case 6:
                    BattleText3.Content = "Изучено:\nКнут";
                    LabShow(BattleText3);
                    break;
                case 7:
                    BattleText3.Content = "Изучено:\nСупер";
                    LabShow(BattleText3);
                    break;
                default:
                    break;
            }
            Super1.MaxHP = Super1.MaxHPNxt[Super1.CurrentLevel - 1];
            Super1.MaxAP = Super1.MaxAPNxt[Super1.CurrentLevel - 1];
            Super1.Attack = Super1.AttackNxt[Super1.CurrentLevel - 1];
            Super1.Defence = Super1.DefenseNxt[Super1.CurrentLevel - 1];
            Super1.Speed = Super1.SpeedNxt[Super1.CurrentLevel - 1];
            Super1.Special = Super1.SpecialNxt[Super1.CurrentLevel - 1];
            ATK.Content = "ОЗ +" + (Super1.MaxHP - Super1.MaxHPNxt[Super1.CurrentLevel - 2]) + "\n" + "АТК +" + (Super1.Attack - Super1.AttackNxt[Super1.CurrentLevel - 2]) + "\n" + "ЗЩТ +" + (Super1.Defence - Super1.DefenseNxt[Super1.CurrentLevel - 2]);
            ATK.Margin = new Thickness(873*Adoptation.WidthAdBack, 20 * Adoptation.HeightAdBack, 0, 0);
            LabShow(ATK);
            SP.Content = "ОД +" + (Super1.MaxAP - Super1.MaxAPNxt[Super1.CurrentLevel - 2]) + "\n" + "СК. +" + (Super1.Speed - Super1.SpeedNxt[Super1.CurrentLevel - 2]) + "\n" + "СП. +" + (Super1.Special - Super1.SpecialNxt[Super1.CurrentLevel - 2]);
            SP.Margin = new Thickness(1073 * Adoptation.WidthAdBack, 20 * Adoptation.HeightAdBack, 0, 0);
            LabShow(SP);
            ButtonShow(TextOk1);
            SEF(new Uri(@"LevelUp.mp3", UriKind.RelativeOrAbsolute));
            Exp = 0;
        }

        private void Torch_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Подожжёт врагов, Стоит: 4 ОД";
            TextCh1();
        }

        private void Torch_MouseLeave(object sender, MouseEventArgs e)
        {
            DisableBattleText();
        }

        private void ACT1_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Поджечь выбранного врага";
            TextCh1();
        }

        private void ACT1_MouseLeave(object sender, MouseEventArgs e)
        {
            DisableBattleText();
        }

        private void Cancel2_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Обратно к умениям";
            TextCh1();
        }

        private void Cancel2_MouseLeave(object sender, MouseEventArgs e)
        {
            DisableBattleText();
        }

        private void Torch_Click(object sender, RoutedEventArgs e)
        {
            SelectTarget();
            AbilitiesMakeDisappear1();
            ButtonShow(ACT1);
            ButtonShow(Cancel2);
        }

        private void Cancel2_Click(object sender, RoutedEventArgs e)
        {
            MediaHide(Trgt);
            BarHide(HPenemyBar);
            LabHide(HPenemy);
            ButtonHide(Fight);
            ButtonHide(ACT1);
            ButtonHide(ACT2);
            ButtonHide(Cancel2);
            ButtonShow(Cure);
            ButtonShow(Back1);
            ButtonShow(Torch);
            if (Super1.CurrentLevel >= 4)
            {
                if (APbar.Value >= 4)
                    Heal.IsEnabled = true;
                Heal.Visibility = Visibility.Visible;
            }
            if (Super1.CurrentLevel >= 6)
            {
                if (APbar.Value >= 6)
                    Heal.IsEnabled = true;
                Whip.IsEnabled = true;
                Whip.Visibility = Visibility.Visible;
            }
            if (Super1.CurrentLevel >= 7)
            {
                if (APbar.Value >= 10)
                    Heal.IsEnabled = true;
                Super.IsEnabled = true;
                Super.Visibility = Visibility.Visible;
            }
        }

        private void ACT(in Byte a1)
        {
            UInt16[] x = { 34, 360, 712 };
            UInt16[] y = { 644, 492, 675 };
            string spdr = "Паук ";
            string mum = "Мумия";
            string zomb = "Зомби";
            string defd = "Страж";
            UInt16 strength = Super1.Special;
            if ((a1 == 0) && ((Foe1.EnemyAppears[Sets.SelectedTarget] == "Паук ") || (Foe1.EnemyAppears[Sets.SelectedTarget] == "Мумия")))
            {
                strength = Convert.ToUInt16(strength * 2.5);
            }
            else
            {
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Фараон")
                    strength = Convert.ToUInt16(strength * 0.5);
                else
                    strength = Convert.ToUInt16(strength * 1.25);
            }
            if ((a1 == 1) && ((Foe1.EnemyAppears[Sets.SelectedTarget] == "Зомби") || (Foe1.EnemyAppears[Sets.SelectedTarget] == "Страж")))
            {
                strength = Convert.ToUInt16(strength * 3);
            }
            else
            {
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Фараон")
                    strength = Convert.ToUInt16(strength * 0.75);
                else
                    strength = Convert.ToUInt16(strength * 1.5);
            }
            MediaHide(Trgt);
            LabHide(BattleText1);
            BattleText1.Margin = new Thickness(473 * Adoptation.WidthAdBack, 45 * Adoptation.HeightAdBack, 0, 0);
            BattleText1.FontSize = 48 * Adoptation.WidthAdBack;
            BattleText1.Content = Foe1.EnemyAppears[Sets.SelectedTarget] + " получает " + strength + " урона!";
            LabShow(BattleText1);
            LabHide(HPenemy);
            BarHide(HPenemyBar);
            ButtonHide(Fight);
            ButtonHide(Cancel1);
            ButtonHide(Cancel2);
            Time1.Value = 0;
            Lab2.Foreground = Brushes.White;
            if (Foe1.EnemyHP[Sets.SelectedTarget] - strength < 0)
            {
                Foe1.EnemyHP[Sets.SelectedTarget] = 0;
            }
            else
            {
                Foe1.EnemyHP[Sets.SelectedTarget] = Convert.ToUInt16(Foe1.EnemyHP[Sets.SelectedTarget] - strength);
            }
            if (Foe1.EnemyHP[Sets.SelectedTarget] == 0)
            {
                string res= "SpiderDied";
                res=EnemySounds(Sets.SelectedTarget);
                SEF(new Uri(@"" + res + ".mp3", UriKind.RelativeOrAbsolute));
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Паук ")
                {
                    Sets.SpiderAlive--;
                    BattleText3.Content = spdr + "              " + Sets.SpiderAlive;
                    if (Sets.SpiderAlive == 0)
                    {
                        LabShow(BattleText3);
                        BattleText3.Content = "";
                        Foe1.EnemyAppears[Sets.SelectedTarget] = "";
                    }
                }
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Мумия")
                {
                    Sets.MummyAlive--;
                    BattleText4.Content = mum + "           " + Sets.MummyAlive;
                    if (Sets.MummyAlive == 0)
                    {
                        BattleText4.Content = "";
                        LabShow(BattleText4);
                        Foe1.EnemyAppears[Sets.SelectedTarget] = "";
                    }
                }
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Зомби")
                {
                    Sets.ZombieAlive--;
                    BattleText5.Content = zomb + "            " + Sets.ZombieAlive;
                    if (Sets.ZombieAlive == 0)
                    {
                        LabShow(BattleText5);
                        BattleText5.Content = "";
                        Foe1.EnemyAppears[Sets.SelectedTarget] = "";
                    }
                }
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Страж")
                {
                    Sets.BonesAlive--;
                    BattleText6.Content = defd + "            " + Sets.BonesAlive;
                    if (Sets.BonesAlive == 0)
                    {
                        LabShow(BattleText6);
                        BattleText6.Content = "";
                        Foe1.EnemyAppears[Sets.SelectedTarget] = "";
                    }
                }
                ImgHide(EnemyCursor);
                BattleText2.Content = Foe1.EnemyAppears[Sets.SelectedTarget] + " погибает!";
                LabShow(BattleText2);
            }
            if (Foe1.EnemyHP[Sets.SelectedTarget] == 0)
            {
                switch (Sets.SelectedTarget)
                {
                    case 0:
                        ImgHide(Img6);
                        break;
                    case 1:
                        ImgHide(Img7);
                        break;
                    case 2:
                        ImgHide(Img8);
                        break;
                }
                if (Foe1.EnemyHP[0] != 0)
                    Sets.SelectedTarget = 0;
                else
                    if (Foe1.EnemyHP[1] != 0)
                    Sets.SelectedTarget = 1;
                else
                    if (Foe1.EnemyHP[2] != 0)
                    Sets.SelectedTarget = 2;
                Trgt.Margin = new Thickness(x[Sets.SelectedTarget] * Adoptation.WidthAdBack, y[Sets.SelectedTarget] * Adoptation.HeightAdBack, 0, 0);
                Foe1.EnemiesStillAlive = Convert.ToByte(Foe1.EnemiesStillAlive - 1);
                if (Foe1.EnemyAppears[0] == "Фараон")
                {
                    if (Foe1.EnemiesStillAlive == 0)
                    {
                        BattleText2.Content = Foe1.EnemyAppears[Sets.SelectedTarget] + " погибает!";
                        LabShow(BattleText2);
                        BattleText3.Content = "";
                        LabHide(BattleText3);
                    }
                }
            }
        }
        private void ACT1_Click(object sender, RoutedEventArgs e)
        {
            APbar.Value = APbar.Value - 4;
            AP.Content = APbar.Value + "/" + APbar.Maximum;
            ButtonHide(ACT1);
            ButtonHide(Cancel2);
            
            
            Med3.Source = new Uri(@"TorchPerson2.avi", UriKind.RelativeOrAbsolute);
            Med4.Source = new Uri(@"TorchIcon.avi", UriKind.RelativeOrAbsolute);
            MediaShow(Med3);
            MediaShow(Med4);
            Dj(new Uri(@"Torch.mp3", UriKind.RelativeOrAbsolute));
            Time1.Value = 0;
            ACT(0);
        }

        private void Heal_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Лечит статус, Стоит: 1 ОД";
            TextCh1();
        }

        private void Heal_MouseLeave(object sender, MouseEventArgs e)
        {
            DisableBattleText();
        }

        private void Heal_Click(object sender, RoutedEventArgs e)
        {
            BattleText1.Margin = new Thickness(473 * Adoptation.WidthAdBack, 45 * Adoptation.HeightAdBack, 0, 0);
            BattleText1.Content = "Рэй излечивается от яда!";
            LabShow(BattleText1);
            Img5.Source = new BitmapImage(new Uri(@"Person6.png", UriKind.RelativeOrAbsolute));
            Super1.PlayerStatus = 0;
            APbar.Value -= 1;
            AP.Content = APbar.Value + "/" + APbar.Maximum;
            AbilitiesMakeDisappear1();
            Time1.Value = 0;
            
            
            Med3.Source = new Uri(@"CurePoisonPerson2.avi", UriKind.RelativeOrAbsolute);
            Med4.Source = new Uri(@"CurePoisonIcon.avi", UriKind.RelativeOrAbsolute);
            MediaShow(Med3);
            MediaShow(Med4);
            Dj(new Uri(@"Heal.mp3", UriKind.RelativeOrAbsolute));
        }

        private void Whip_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Дробит кости, Стоит: 6 ОД";
            TextCh1();
        }

        private void Whip_MouseLeave(object sender, MouseEventArgs e)
        {
            DisableBattleText();
        }

        private void Whip_Click(object sender, RoutedEventArgs e)
        {
            SelectTarget();
            AbilitiesMakeDisappear1();
            ButtonShow(ACT2);
            ButtonShow(Cancel2);
        }

        private void ACT2_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Ударить врага хлыстом";
            TextCh1();
        }

        private void ACT2_MouseLeave(object sender, MouseEventArgs e)
        {
            DisableBattleText();
        }

        private void ACT2_Click(object sender, RoutedEventArgs e)
        {
            APbar.Value = APbar.Value - 6;
            AP.Content = APbar.Value + "/" + APbar.Maximum;
            ButtonHide(ACT2);
            ButtonHide(Cancel2);
            
            
            Med3.Source = new Uri(@"PersonWhip2.avi", UriKind.RelativeOrAbsolute);
            Med4.Source = new Uri(@"IconWhip.avi", UriKind.RelativeOrAbsolute);
            MediaShow(Med3);
            MediaShow(Med4);
            Dj(new Uri(@"Whip.mp3", UriKind.RelativeOrAbsolute));
            Time1.Value = 0;
            ACT(1);
        }

        private void Super_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Кровавая бойня, Стоит: 10 ОД";
            TextCh1();
        }

        private void Super_MouseLeave(object sender, MouseEventArgs e)
        {
            DisableBattleText();
        }

        private void Super_Click(object sender, RoutedEventArgs e)
        {
            APbar.Value = APbar.Value - 10;
            AP.Content = APbar.Value + "/" + APbar.Maximum;
            Int16[] x = { 34, 360, 712 };
            Int16[] y = { 644, 492, 675 };
            UInt16 strength = Super1.Special;
            if (Foe1.EnemyAppears[Sets.SelectedTarget] != "Фараон")
                strength = Convert.ToUInt16(strength * 2);
            Dj(new Uri(@"Super.mp3", UriKind.RelativeOrAbsolute));
            AbilitiesMakeDisappear1();
            MediaHide(Trgt);
            LabHide(BattleText1);
            BattleText1.Margin = new Thickness(473*Adoptation.WidthAdBack, 45 * Adoptation.HeightAdBack, 0, 0);
            BattleText1.FontSize = 48 * Adoptation.WidthAdBack;
            BattleText1.Content = "Все враги получают " + strength + " урона!";
            LabShow(BattleText1);
            BarHide(HPenemyBar);
            LabHide(HPenemy);
            ButtonHide(Fight);
            ButtonHide(Cancel1);
            ButtonHide(Cancel2);
            
            
            Time1.Value = 0;
            Lab2.Foreground = Brushes.White;
            if (Foe1.EnemyAppears[Sets.SelectedTarget] != "Фараон")
            {
                if (Foe1.EnemyHP[0] - strength <= 0)
                    Foe1.EnemyHP[0] = 0;
                else
                    Foe1.EnemyHP[0] = Convert.ToUInt16(Foe1.EnemyHP[0] - strength);
                if (Foe1.EnemyHP[1] - strength <= 0)
                    Foe1.EnemyHP[1] = 0;
                else
                    Foe1.EnemyHP[1] = Convert.ToUInt16(Foe1.EnemyHP[1] - strength);
                if (Foe1.EnemyHP[2] - strength <= 0)
                    Foe1.EnemyHP[2] = 0;
                else
                    Foe1.EnemyHP[2] = Convert.ToUInt16(Foe1.EnemyHP[2] - strength);
                BattleText2.Content = "Все враги погибают!";
                BattleText2.IsEnabled = true;
                BattleText2.Visibility = Visibility.Visible;
                Foe1.EnemiesStillAlive = 0;
                if (Foe1.EnemyHP[0] != 0)
                    Sets.SelectedTarget = 0;
                else
                    if (Foe1.EnemyHP[1] != 0)
                    Sets.SelectedTarget = 1;
                else
                        if (Foe1.EnemyHP[2] != 0)
                    Sets.SelectedTarget = 2;
                Trgt.Margin = new Thickness(x[Sets.SelectedTarget] * Adoptation.WidthAdBack, y[Sets.SelectedTarget] * Adoptation.HeightAdBack, 0, 0);
                BattleText3.Content = "";
                BattleText4.Content = "";
                BattleText5.Content = "";
                BattleText6.Content = "";
                LabHide(BattleText6);
                LabHide(BattleText5);
                LabHide(BattleText4);
                LabHide(BattleText3);
                Foe1.EnemyName[0] = "";
                Foe1.EnemyName[1] = "";
                Foe1.EnemyName[2] = "";
                if (Sets.BonesAlive != 0)
                {
                    Sets.BonesAlive = 0;
                }
                if (Sets.SpiderAlive != 0)
                {
                    Sets.SpiderAlive = 0;
                }
                if (Sets.ZombieAlive != 0)
                {
                    Sets.ZombieAlive = 0;
                }
                if (Sets.MummyAlive != 0)
                {
                    Sets.MummyAlive = 0;
                }
                Time1.Value = 0;
                
                
                Med3.Source = new Uri(@"PersonSuper2.avi", UriKind.RelativeOrAbsolute);
                Med4.Source = new Uri(@"IconSuper2.avi", UriKind.RelativeOrAbsolute);
                MediaShow(Med3);
                MediaShow(Med4);
                ImgHide(EnemyCursor);
                ImgHide(Img6);
                ImgHide(Img7);
                ImgHide(Img8);
            }
            else
            {
                if (Foe1.EnemyHP[0] - strength <= 0)
                    Foe1.EnemyHP[0] = 0;
                else
                    Foe1.EnemyHP[0] = Convert.ToUInt16(Foe1.EnemyHP[0] - strength);
                if (Foe1.EnemyHP[0] == 0)
                {
                    ImgHide(EnemyCursor);
                    ImgHide(Img6);
                    Time1.Value = 0;
                    Foe1.EnemiesStillAlive = 0;
                }
                SEF(new Uri(@"DefeatPharaoh.mp3", UriKind.RelativeOrAbsolute));
                
                
                Med3.Source = new Uri(@"PersonSuper2.avi", UriKind.RelativeOrAbsolute);
                Med4.Source = new Uri(@"IconSuper2.avi", UriKind.RelativeOrAbsolute);
                MediaShow(Med3);
                MediaShow(Med4);
            }
        }

        private void Items_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Посмотреть инвентарь";
            TextCh1();
        }

        private void Items_MouseLeave(object sender, MouseEventArgs e)
        {
            DisableBattleText();
        }

        private void Items_Click(object sender, RoutedEventArgs e)
        {
            FightMenuMakesDisappear();
            ButtonShow(Back2);
            LabShow(ItemText);
            ImgShow(ItemsCountImg);
            if (BAG.AntidoteITM>= 1)
            {
                ButtonShow(Antidote1);
            }
            if (BAG.FusedITM >= 1)
            {
                ButtonShow(Fused1);
            }
            if (BAG.BandageITM >= 1)
            {
                ButtonShow(Bandage1);
            }
            if (BAG.EtherITM >= 1)
            {
                ButtonShow(Ether);
            }
            Dj(new Uri(@"ItemsOpen.mp3", UriKind.RelativeOrAbsolute));
        }

        private void Back2_DragEnter(object sender, DragEventArgs e)
        {
            BattleText2.Content = "Обратно к действиям";
            TextCh1();
        }

        private void Back2_DragLeave(object sender, DragEventArgs e)
        {
            DisableBattleText();
        }

        private void MenuItemsHide1()
        {
            ButtonHide(Antidote1);
            ButtonHide(Fused1);
            ButtonHide(Bandage1);
            ButtonHide(Ether);
            ButtonHide(Back2);
        }
        private void Back2_Click(object sender, RoutedEventArgs e)
        {
            MenuItemsHide1();
            FightMenuBack();
            LabHide(ItemText);
            ImgHide(ItemsCountImg);
            Dj(new Uri(@"ItemsClose.mp3", UriKind.RelativeOrAbsolute));
        }

        private void Antidote1_Click(object sender, RoutedEventArgs e)
        {
            LabHide(ItemText);
            ImgHide(ItemsCountImg);
            MenuItemsHide1();
            Super1.PlayerStatus = 0;
            BAG.AntidoteITM -= 1;
            Time1.Value = 0;
            
            
            Med3.Source = new Uri(@"ItemUsed2.avi", UriKind.RelativeOrAbsolute);
            Med4.Source = new Uri(@"IconItemUsed.avi", UriKind.RelativeOrAbsolute);
            MediaShow(Med3);
            MediaShow(Med4);
            Dj(new Uri(@"ItemsUsed.mp3", UriKind.RelativeOrAbsolute));
        }

        private void Antidote1_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Избавляет от яда";
            ItemText.Content = "В наличии: " + BAG.AntidoteITM;
            TextCh1();
        }

        private void Antidote1_MouseLeave(object sender, MouseEventArgs e)
        {
            ItemText.Content = "";
            DisableBattleText();
        }

        private void Fused1_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Восстановит 80 ОЗ и 40 ОД";
            ItemText.Content = "В наличии: " + BAG.FusedITM;
            TextCh1();
        }

        private void Fused1_MouseLeave(object sender, MouseEventArgs e)
        {
            ItemText.Content = "";
            DisableBattleText();
        }

        private void Fused1_Click(object sender, RoutedEventArgs e)
        {
            LabHide(ItemText);
            ImgHide(ItemsCountImg);
            MenuItemsHide1();
            if ((HPbar.Value + 80) > HPbar.Maximum)
                HPbar.Value = HPbar.Maximum;
            else
                HPbar.Value += 80;
            if ((APbar.Value + 80) > APbar.Maximum)
                APbar.Value = APbar.Maximum;
            else
                APbar.Value += 80;
            HP.Content = HPbar.Value + "/" + HPbar.Maximum;
            AP.Content = APbar.Value + "/" + APbar.Maximum;
            BAG.FusedITM -= 1;
            Time1.Value = 0;
            
            
            Med3.Source = new Uri(@"ItemUsed2.avi", UriKind.RelativeOrAbsolute);
            Med4.Source = new Uri(@"IconItemUsed.avi", UriKind.RelativeOrAbsolute);
            MediaShow(Med3);
            MediaShow(Med4);
            Dj(new Uri(@"ItemsUsed.mp3", UriKind.RelativeOrAbsolute));
        }

        private void Bandage1_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Восстановит 50 ОЗ";
            ItemText.Content = "В наличии: " + BAG.BandageITM;
            TextCh1();
        }

        private void Bandage1_MouseLeave(object sender, MouseEventArgs e)
        {
            ItemText.Content = "";
            DisableBattleText();
        }

        private void Bandage1_Click(object sender, RoutedEventArgs e)
        {
            LabHide(ItemText);
            ImgHide(ItemsCountImg);
            MenuItemsHide1();
            if ((HPbar.Value + 50) > HPbar.Maximum)
                HPbar.Value = HPbar.Maximum;
            else
                HPbar.Value += 50;
            HP.Content = HPbar.Value + "/" + HPbar.Maximum;
            BAG.BandageITM -= 1;
            Time1.Value = 0;
            
            
            Med3.Source = new Uri(@"ItemUsed2.avi", UriKind.RelativeOrAbsolute);
            Med4.Source = new Uri(@"IconItemUsed.avi", UriKind.RelativeOrAbsolute);
            MediaShow(Med3);
            MediaShow(Med4);
            Dj(new Uri(@"ItemsUsed.mp3", UriKind.RelativeOrAbsolute));
        }

        private void Ether_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Восстановит 50 ОД";
            ItemText.Content = "В наличии: " + BAG.EtherITM;
            TextCh1();
        }

        private void Ether_MouseLeave(object sender, MouseEventArgs e)
        {
            ItemText.Content = "";
            DisableBattleText();
        }

        private void Ether_Click(object sender, RoutedEventArgs e)
        {
            LabHide(ItemText);
            ImgHide(ItemsCountImg);
            MenuItemsHide1();
            if ((APbar.Value + 50) > APbar.Maximum)
                APbar.Value = APbar.Maximum;
            else
                APbar.Value += 50;
            AP.Content = APbar.Value + "/" + APbar.Maximum;
            BAG.EtherITM -= 1;
            Time1.Value = 0;
            Med3.Source = new Uri(@"ItemUsed2.avi", UriKind.RelativeOrAbsolute);
            Med4.Source = new Uri(@"IconItemUsed.avi", UriKind.RelativeOrAbsolute);
            MediaShow(Med3);
            MediaShow(Med4);
            Dj(new Uri(@"ItemsUsed.mp3", UriKind.RelativeOrAbsolute));
        }
        private void ShowEquipAndStats()
        {
            ImgShow(EquipHImg);
            ImgShow(EquipBImg);
            ImgShow(EquipLImg);
            ImgShow(EquipDImg);
            ImgShow(ATKImg);
            ImgShow(DEFImg);
            ImgShow(AGImg);
            ImgShow(SPImg);
            LabShow(ATK1);
            LabShow(DEF1);
            LabShow(AG1);
            LabShow(SP1);
            LabShow(EquipH);
            LabShow(EquipB);
            LabShow(EquipL);
            LabShow(EquipD);
            LabShow(Params);
            LabShow(ParamsATK);
            LabShow(ParamsDEF);
            LabShow(ParamsAG);
            LabShow(ParamsSP);
            LabShow(EquipText);
        }
        private void PlayerProfile()
        {
            ImgShow(Icon0);
            LabShow(Level0);
            LabShow(Name0);
            LabShow(StatusP);
        }
        private void MenuHpAp()
        {
            BarShow(HPbar1);
            BarShow(APbar1);
            LabShow(HPtext1);
            LabShow(APtext1);
            LabShow(HP1);
            LabShow(AP1);
            HPbar1.Width = HPbar.Width * 2;
            HPbar1.Maximum = HPbar.Maximum;
            HPbar1.Value = HPbar.Value;
            APbar1.Width = APbar.Width * 2;
            APbar1.Maximum = APbar.Maximum;
            APbar1.Value = APbar.Value;
        }
        private void Status_MouseEnter(object sender, MouseEventArgs e)
        {
            Describe2.Content = "Посмотреть статус";
        }

        private void Status_MouseLeave(object sender, MouseEventArgs e)
        {
            Describe2.Content = "";
        }

        private void Status_Click(object sender, RoutedEventArgs e)
        {
            if (!Items0.IsEnabled)
            {
                Dj(new Uri(@"ItemsClose.mp3", UriKind.RelativeOrAbsolute));
            }
            MegaHide();
            AllturnON();
            Name0.Margin = new Thickness(278*Adoptation.WidthAdBack, 121 * Adoptation.HeightAdBack, 0, 0);
            Level0.Margin = new Thickness(470 * Adoptation.WidthAdBack, 121 * Adoptation.HeightAdBack, 0, 0);
            StatusP.Margin = new Thickness(706 * Adoptation.WidthAdBack, 121 * Adoptation.HeightAdBack, 0, 0);
            StatsMeaning();
            Status.IsEnabled = false;
            PlayerProfile();
            Level0.Content = "Уровень: " + Super1.CurrentLevel;
            MenuHpAp();
            if (Super1.PlayerStatus == 1)
                StatusP.Content = "Статус: отравлен";
            else
                StatusP.Content = "Статус: здоров";
            BarShow(ExpBar1);
            ExpBar1.Maximum = NextExpBar.Maximum;
            ExpBar1.Value = NextExpBar.Value;
            LabShow(Exp1);
            Exp1.Content = ExpText.Content;
            if (Convert.ToString(Exp1.Content) != "Максимальный")
                Exp1.Margin = new Thickness(ExpBar1.Margin.Right + 30 * Adoptation.WidthAdBack, Exp1.Margin.Top, 0, 0);
            else
                Exp1.Margin = new Thickness(ExpBar1.Margin.Right + 60 * Adoptation.WidthAdBack, Exp1.Margin.Top, 0, 0);
            LabShow(Describe1);
            LabShow(Describe2);

            HPbar1.Margin = new Thickness(418 * Adoptation.WidthAdBack, 275 * Adoptation.HeightAdBack, 0, 0);
            APbar1.Margin = new Thickness(418 * Adoptation.WidthAdBack, 352 * Adoptation.HeightAdBack, 0, 0);
            HPtext1.Margin = new Thickness(HPbar1.Margin.Left - 300 * Adoptation.WidthAdBack, HPbar1.Margin.Top - 7 * Adoptation.HeightAdBack, 0, 0);
            APtext1.Margin = new Thickness(APbar1.Margin.Left - 300 * Adoptation.WidthAdBack, APbar1.Margin.Top - 7 * Adoptation.HeightAdBack, 0, 0);
            HP1.Margin = new Thickness(HPbar1.Margin.Left + HPbar1.Width + 30 * Adoptation.WidthAdBack, HPbar1.Margin.Top - 7 * Adoptation.HeightAdBack, 0, 0);
            HP1.Content = HPbar1.Value + "/" + HPbar1.Maximum;
            AP1.Margin = new Thickness(APbar1.Margin.Left + APbar1.Width + 30 * Adoptation.WidthAdBack, APbar1.Margin.Top - 7 * Adoptation.HeightAdBack, 0, 0);
            AP1.Content = APbar1.Value + "/" + APbar1.Maximum;
            ShowEquipAndStats();
            if (Super1.PlayerStatus == 0)
            {
                Icon0.Source = new BitmapImage(new Uri(@"person6.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                Icon0.Source = new BitmapImage(new Uri(@"IconPoisoned.png", UriKind.RelativeOrAbsolute));
            }
            Describe1.Content = "Подсказка: следите за тем, чтобы ОЗ не упало до 0, иначе герой погибнет.\nТакже уделяйте внимание АВШ - после её заполнения действовать придётся\nпредельно быстро, иначе ваши оппоненты и пепла от вас не оставят.";
            LabShow(Describe1);
            if (Exp1.Content.ToString().Contains("Максимальный"))
                Exp1.Margin = new Thickness(881 * Adoptation.WidthAdBack + 30*Adoptation.WidthAdBack, Exp1.Margin.Top, 0, 0);
            else
                Exp1.Margin = new Thickness(881 * Adoptation.WidthAdBack + 60 * Adoptation.WidthAdBack, Exp1.Margin.Top, 0, 0);
        }

        private void Abils_MouseEnter(object sender, MouseEventArgs e)
        {
            Describe2.Content = "Перейти к умениям";
        }

        private void Abils_MouseLeave(object sender, MouseEventArgs e)
        {
            Describe2.Content = "";
        }
        private void AllturnON()
        {
            ButtonShow(Status);
            ButtonShow(Abils);
            ButtonShow(Items0);
            ButtonShow(Equip);
            ButtonShow(Info);
            ButtonShow(Tasks);
        }
        private void Abils_Click(object sender, RoutedEventArgs e)
        {
            if (!Items0.IsEnabled)
            {
                Dj(new Uri(@"ItemsClose.mp3", UriKind.RelativeOrAbsolute));
            }
            MegaHide();
            AllturnON();
            Abils.IsEnabled = false;
            PlayerProfile();
            Name0.Margin = new Thickness(278*Adoptation.WidthAdBack, 121 * Adoptation.HeightAdBack, 0, 0);
            Level0.Margin = new Thickness(470 * Adoptation.WidthAdBack, 121 * Adoptation.HeightAdBack, 0, 0);
            StatusP.Margin = new Thickness(706 * Adoptation.WidthAdBack, 121 * Adoptation.HeightAdBack, 0, 0);
            MenuHpAp();
            HPbar1.Margin = new Thickness(578 * Adoptation.WidthAdBack, 200*Adoptation.HeightAdBack, 0, 0);
            APbar1.Margin = new Thickness(378 * Adoptation.WidthAdBack, 800* Adoptation.HeightAdBack, 0, 0);
            HPtext1.Margin = new Thickness(HPbar1.Margin.Left - 300* Adoptation.WidthAdBack, HPbar1.Margin.Top - 7* Adoptation.HeightAdBack, 0, 0);
            APtext1.Margin = new Thickness(APbar1.Margin.Left - 300 * Adoptation.WidthAdBack, APbar1.Margin.Top - 7* Adoptation.HeightAdBack, 0, 0);
            HP1.Margin = new Thickness(HPbar1.Margin.Left + HPbar1.Width + 30 * Adoptation.WidthAdBack, HPbar1.Margin.Top - 7* Adoptation.HeightAdBack, 0, 0);
            HP1.Content = HPbar1.Value + "/" + HPbar1.Maximum;
            AP1.Margin = new Thickness(APbar1.Margin.Left + APbar1.Width + 30 * Adoptation.WidthAdBack, APbar1.Margin.Top - 7* Adoptation.HeightAdBack, 0, 0);
            AP1.Content = APbar1.Value + "/" + APbar1.Maximum;
            if (Super1.CurrentLevel >= 2)
            {
                LabShow(CureCost);
                if (APbar1.Value >= 2)
                    Cure1.IsEnabled = true;
                Cure1.Visibility = Visibility.Visible;
                LabShow(CureDescribe);
                LabShow(CostText);
                if (Super1.CurrentLevel >= 4)
                {
                    if (APbar1.Value >= 1)
                        Heal1.IsEnabled = true;
                    Heal1.Visibility = Visibility.Visible;
                    LabShow(HealCost);
                    LabShow(HealDescribe);
                }
            }
            LabShow(Describe2);
            Describe1.Content = "Подсказка: умения - одно из самых главных условий выживания. Правильное\nсочетание умений между собой даёт невероятные результаты! Однако помните,\n что все умения используют ОД. Их необходимо своевременно пополнять.";
            LabShow(Describe1);
        }

        private void Cure1_Click(object sender, RoutedEventArgs e)
        {
            Dj(new Uri(@"Cure.mp3", UriKind.RelativeOrAbsolute));
            if (((Super1.Special * 2) + HPbar.Value) >= HPbar.Maximum)
            {
                HPbar.Value = HPbar.Maximum;
                HP.Content = HPbar.Value + "/" + HPbar.Maximum;
                HPbar1.Value = HPbar.Value;
                HP1.Content = HPbar1.Value + "/" + HPbar1.Maximum;
            }
            else
            {
                HPbar.Value = HPbar.Value + Super1.Special * 2;
                HP.Content = HPbar.Value + "/" + HPbar.Maximum;
                HPbar1.Value = HPbar.Value;
                HP1.Content = HPbar1.Value + "/" + HPbar1.Maximum;
            }
            APbar.Value -= 2;
            AP.Content = APbar.Value + "/" + APbar.Maximum;
            APbar1.Value = APbar.Value;
            AP1.Content = APbar1.Value + "/" + APbar1.Maximum;
            if (APbar1.Value < 2)
                Cure1.IsEnabled = false;
        }

        private void Heal1_Click(object sender, RoutedEventArgs e)
        {
            Dj(new Uri(@"Heal.mp3", UriKind.RelativeOrAbsolute));
            Super1.PlayerStatus = 0;
            StatusP.Content = "Статус: здоров";
            Icon0.Source = new BitmapImage(new Uri(@"Person6.png", UriKind.RelativeOrAbsolute));
            APbar.Value -= 1;
            AP.Content = APbar.Value + "/" + APbar.Maximum;
            APbar1.Value = APbar.Value;
            AP1.Content = APbar1.Value + "/" + APbar1.Maximum;
            if (APbar1.Value < 1)
                Heal1.IsEnabled = false;
            if (Super1.PlayerStatus == 0)
            {
                Icon0.Source = new BitmapImage(new Uri(@"person6.png", UriKind.RelativeOrAbsolute));
                Img5.Source = new BitmapImage(new Uri(@"person6.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                Icon0.Source = new BitmapImage(new Uri(@"IconPoisoned.png", UriKind.RelativeOrAbsolute));
            }
        }

        private void Items0_MouseEnter(object sender, MouseEventArgs e)
        {
            Describe2.Content = "Перейти к вещам";
        }

        private void Items0_MouseLeave(object sender, MouseEventArgs e)
        {
            Describe2.Content = "";
        }

        private void Items0_Click(object sender, RoutedEventArgs e)
        {
            MegaHide();
            AllturnON();
            Describe1.Content = "";
            Dj(new Uri(@"ItemsOpen.mp3", UriKind.RelativeOrAbsolute));
            Items0.IsEnabled = false;
            PlayerProfile();
            Name0.Margin = new Thickness(118*Adoptation.WidthAdBack, 261 * Adoptation.HeightAdBack, 0, 0);
            Level0.Margin = new Thickness(310 * Adoptation.WidthAdBack, 261 * Adoptation.HeightAdBack, 0, 0);
            StatusP.Margin = new Thickness(546 * Adoptation.WidthAdBack, 261 * Adoptation.HeightAdBack, 0, 0);
            MenuHpAp();
            HPbar1.Margin = new Thickness(578 * Adoptation.WidthAdBack, 125 * Adoptation.HeightAdBack, 0, 0);
            APbar1.Margin = new Thickness(578 * Adoptation.WidthAdBack, 195 * Adoptation.HeightAdBack, 0, 0);
            HPtext1.Margin = new Thickness(HPbar1.Margin.Left - 300 * Adoptation.WidthAdBack, HPbar1.Margin.Top - 7 * Adoptation.HeightAdBack, 0, 0);
            APtext1.Margin = new Thickness(APbar1.Margin.Left - 300 * Adoptation.WidthAdBack, APbar1.Margin.Top - 7 * Adoptation.HeightAdBack, 0, 0);
            HP1.Margin = new Thickness(HPbar1.Margin.Left + HPbar1.Width + 30 * Adoptation.WidthAdBack, HPbar1.Margin.Top - 7 * Adoptation.HeightAdBack, 0, 0);
            HP1.Content = HPbar1.Value + "/" + HPbar1.Maximum;
            AP1.Margin = new Thickness(APbar1.Margin.Left + APbar1.Width + 30 * Adoptation.WidthAdBack, APbar1.Margin.Top - 7 * Adoptation.HeightAdBack, 0, 0);
            AP1.Content = APbar1.Value + "/" + APbar1.Maximum;
            if (BAG.BandageITM >= 1)
            {
                ButtonShow(Bandage);
                LabShow(BandageText);
            }
            if (BAG.EtherITM >= 1)
            {
                ButtonShow(Ether1);
                LabShow(EtherText);
            }
            if (BAG.AntidoteITM >= 1)
            {
                LabShow(AntidoteText);
                if (Super1.PlayerStatus == 1)
                    Antidote.IsEnabled = true;
                Antidote.Visibility = Visibility.Visible;
            }
            if (BAG.FusedITM >= 1)
            {
                ButtonShow(Fused);
                LabShow(FusedText);
            }
            LabShow(CountText);
            LabShow(Describe2);
            if (Super1.PlayerStatus == 0)
            {
                Icon0.Source = new BitmapImage(new Uri(@"person6.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                Icon0.Source = new BitmapImage(new Uri(@"IconPoisoned.png", UriKind.RelativeOrAbsolute));
            }
            LabShow(Describe1);
        }

        private void Bandage_MouseEnter(object sender, MouseEventArgs e)
        {
            Describe1.Content = "Бинт, полученный из мумии. Отлично подходит для перевязывания ран";
            CountText.Content = "В наличии: " + BAG.BandageITM;
        }

        private void Bandage_MouseLeave(object sender, MouseEventArgs e)
        {
            Describe1.Content = "";
            CountText.Content = "";
        }

        private void Bandage_Click(object sender, RoutedEventArgs e)
        {
            Dj(new Uri(@"ItemsUsed.mp3", UriKind.RelativeOrAbsolute));
            BAG.BandageITM -= 1;
            if (50 + HPbar.Value >= HPbar.Maximum)
            {
                HPbar.Value = HPbar.Maximum;
                HP.Content = HPbar.Value + "/" + HPbar.Maximum;
                HPbar1.Value = HPbar.Value;
                HP1.Content = HPbar1.Value + "/" + HPbar1.Maximum;
            }
            else
            {
                HPbar.Value = HPbar.Value + 50;
                HP.Content = HPbar.Value + "/" + HPbar.Maximum;
                HPbar1.Value = HPbar.Value;
                HP1.Content = HPbar1.Value + "/" + HPbar1.Maximum;
            }
            if (BAG.BandageITM < 1)
            {
                LabHide(BandageText);
                ButtonHide(Bandage);
                CountText.Content = "";
            }
            else
                CountText.Content = "В наличии: " + BAG.BandageITM;
        }

        private void Ether1_MouseEnter(object sender, MouseEventArgs e)
        {
            Describe1.Content = "Особая жидкость древних, чудесным образом восполняющая силы";
            CountText.Content = "В наличии: " + BAG.EtherITM;
        }

        private void Ether1_MouseLeave(object sender, MouseEventArgs e)
        {
            Describe1.Content = "";
            CountText.Content = "";
        }

        private void Ether1_Click(object sender, RoutedEventArgs e)
        {
            Dj(new Uri(@"ItemsUsed.mp3", UriKind.RelativeOrAbsolute));
            BAG.EtherITM -= 1;
            if (80 + HPbar.Value >= HPbar.Maximum)
            {
                HPbar.Value = HPbar.Maximum;
                HP.Content = HPbar.Value + "/" + HPbar.Maximum;
                HPbar1.Value = HPbar.Value;
                HP1.Content = HPbar1.Value + "/" + HPbar1.Maximum;
            }
            else
            {
                HPbar.Value = HPbar.Value + 80;
                HP.Content = HPbar.Value + "/" + HPbar.Maximum;
                HPbar1.Value = HPbar.Value;
                HP1.Content = HPbar1.Value + "/" + HPbar1.Maximum;
            }
            if (50 + APbar.Value >= APbar.Maximum)
            {
                APbar.Value = APbar.Maximum;
                AP.Content = APbar.Value + "/" + APbar.Maximum;
                APbar1.Value = APbar.Value;
                AP1.Content = APbar1.Value + "/" + APbar1.Maximum;
            }
            else
            {
                APbar.Value = APbar.Value + 50;
                AP.Content = APbar.Value + "/" + APbar.Maximum;
                APbar1.Value = APbar.Value;
                AP1.Content = APbar1.Value + "/" + APbar1.Maximum;
            }
            if (BAG.EtherITM < 1)
            {
                LabHide(EtherText);
                ButtonHide(Ether1);
                CountText.Content = "";
            }
            else
                CountText.Content = "В наличии: " + BAG.EtherITM;
        }

        private void Antidote_MouseEnter(object sender, MouseEventArgs e)
        {
            Describe1.Content = "Склизкая, мутная жижа, добытая из глаз паука - единственное средство от его ужасного яда";
            CountText.Content = "В наличии: " + BAG.AntidoteITM;
        }

        private void Antidote_MouseLeave(object sender, MouseEventArgs e)
        {
            Describe1.Content = "";
            CountText.Content = "";
        }

        private void Antidote_Click(object sender, RoutedEventArgs e)
        {
            Dj(new Uri(@"ItemsUsed.mp3", UriKind.RelativeOrAbsolute));
            BAG.AntidoteITM -= 1;
            Super1.PlayerStatus = 0;
            StatusP.Content = "Статус: здоров";
            Antidote.IsEnabled = false;
            if (BAG.AntidoteITM < 1)
            {
                LabHide(AntidoteText);
                Antidote.Visibility = Visibility.Hidden;
                CountText.Content = "";
            }
            else
                CountText.Content = "В наличии: " + BAG.AntidoteITM;
            if (Super1.PlayerStatus == 0)
            {
                Icon0.Source = new BitmapImage(new Uri(@"person6.png", UriKind.RelativeOrAbsolute));
                Img5.Source = new BitmapImage(new Uri(@"person6.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                Icon0.Source = new BitmapImage(new Uri(@"IconPoisoned.png", UriKind.RelativeOrAbsolute));
            }
        }

        private void Fused_Click(object sender, RoutedEventArgs e)
        {
            Dj(new Uri(@"ItemsUsed.mp3", UriKind.RelativeOrAbsolute));
            BAG.FusedITM -= 1;
            if (40 + APbar.Value >= APbar.Maximum)
            {
                APbar.Value = APbar.Maximum;
                AP.Content = APbar.Value + "/" + APbar.Maximum;
                APbar1.Value = APbar.Value;
                AP1.Content = APbar1.Value + "/" + APbar1.Maximum;
            }
            else
            {
                APbar.Value = APbar.Value + 40;
                AP.Content = APbar.Value + "/" + APbar.Maximum;
                APbar1.Value = APbar.Value;
                AP1.Content = APbar1.Value + "/" + APbar1.Maximum;
            }
            if (BAG.FusedITM < 1)
            {
                LabHide(FusedText);
                ButtonHide(Fused);
            }
            else
                CountText.Content = "В наличии: " + BAG.FusedITM;
        }

        private void Fused_MouseEnter(object sender, MouseEventArgs e)
        {
            Describe1.Content = "Смесь из костной муки одного из стражей, кальций всегда важен!";
            CountText.Content = "В наличии: " + BAG.FusedITM;
        }

        private void Fused_MouseLeave(object sender, MouseEventArgs e)
        {
            Describe1.Content = "";
            CountText.Content = "";
        }

        private void Equip_MouseEnter(object sender, MouseEventArgs e)
        {
            Describe2.Content = "Перейти к\nснаряжению";
        }

        private void Equip_MouseLeave(object sender, MouseEventArgs e)
        {
            Describe2.Content = "";
        }

        private void Equip_Click(object sender, RoutedEventArgs e)
        {
            if (!Items0.IsEnabled)
            {
                var uriSource4 = new Uri(@"ItemsClose.mp3", UriKind.RelativeOrAbsolute);
                Sound2.Source = uriSource4;
                Sound2.Play();
            }
            MegaHide();
            AllturnON();
            Describe1.Content = "";
            Equip.IsEnabled = false;
            PlayerProfile();
            MenuHpAp();
            HPbar1.Margin = new Thickness(578*Adoptation.WidthAdBack, 125 * Adoptation.HeightAdBack, 0, 0);
            APbar1.Margin = new Thickness(578 * Adoptation.WidthAdBack, 195 * Adoptation.HeightAdBack, 0, 0);
            HPtext1.Margin = new Thickness(HPbar1.Margin.Left - 300 * Adoptation.WidthAdBack, HPbar1.Margin.Top - 7 * Adoptation.HeightAdBack, 0, 0);
            APtext1.Margin = new Thickness(APbar1.Margin.Left - 300 * Adoptation.WidthAdBack, APbar1.Margin.Top - 7 * Adoptation.HeightAdBack, 0, 0);
            HP1.Margin = new Thickness(HPbar1.Margin.Left + HPbar1.Width + 30 * Adoptation.WidthAdBack, HPbar1.Margin.Top - 7 * Adoptation.HeightAdBack, 0, 0);
            HP1.Content = HPbar1.Value + "/" + HPbar1.Maximum;
            AP1.Margin = new Thickness(APbar1.Margin.Left + APbar1.Width + 30 * Adoptation.WidthAdBack, APbar1.Margin.Top - 7 * Adoptation.HeightAdBack, 0, 0);
            AP1.Content = APbar1.Value + "/" + APbar1.Maximum;
            ShowEquipAndStats();
            StatsMeaning();
            LabHide(Name0);
            LabHide(Level0);
            LabHide(StatusP);
            if (Super1.PlayerStatus == 0)
            {
                Icon0.Source = new BitmapImage(new Uri(@"person6.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                Icon0.Source = new BitmapImage(new Uri(@"IconPoisoned.png", UriKind.RelativeOrAbsolute));
            }
            EquipWatch();
            LabHide(Describe1);
        }
        private void EquipWatch()
        {
            if ((BAG.Hands) && (Super1.PlayerEQ[0] == 0))
                Equip1.IsEnabled = true;
            Equip1.Visibility = Visibility.Visible;
            if ((BAG.Jacket) && (Super1.PlayerEQ[1] == 0))
                Equip2.IsEnabled = true;
            Equip2.Visibility = Visibility.Visible;
            if ((BAG.Legs) && (Super1.PlayerEQ[2] == 0))
                Equip3.IsEnabled = true;
            Equip3.Visibility = Visibility.Visible;
            if ((BAG.Boots) && (Super1.PlayerEQ[3] == 0))
                Equip4.IsEnabled = true;
            Equip4.Visibility = Visibility.Visible;
            if ((!BAG.Hands) && (Super1.PlayerEQ[0] != 0))
                Remove1.IsEnabled = true;
            Remove1.Visibility = Visibility.Visible;
            if ((!BAG.Jacket) && (Super1.PlayerEQ[1] != 0))
                Remove2.IsEnabled = true;
            Remove2.Visibility = Visibility.Visible;
            if ((!BAG.Legs) && (Super1.PlayerEQ[2] != 0))
                Remove3.IsEnabled = true;
            Remove3.Visibility = Visibility.Visible;
            if ((!BAG.Boots) && (Super1.PlayerEQ[3] != 0))
                Remove4.IsEnabled = true;
            Remove4.Visibility = Visibility.Visible;
        }
        private void StatsMeaning()
        {
            ATK1.Content = Super1.Attack + Super1.PlayerEQ[0];
            DEF1.Content = Super1.Defence + Super1.PlayerEQ[1] + Super1.PlayerEQ[2] + Super1.PlayerEQ[3];
            AG1.Content = Super1.Speed;
            SP1.Content = Super1.Special;
        }
        private void Remove1_Click(object sender, RoutedEventArgs e)
        {
            Super1.PlayerEQ[0] = 0;
            BAG.Hands = true;
            Remove1.IsEnabled = false;
            StatsMeaning();
            EquipH.Content = "Правая рука";
            EquipWatch();
        }

        private void Remove2_Click(object sender, RoutedEventArgs e)
        {
            Super1.PlayerEQ[1] = 0;
            BAG.Jacket = true;
            Remove2.IsEnabled = false;
            StatsMeaning();
            EquipB.Content = "Тело";
            EquipWatch();
        }

        private void Remove3_Click(object sender, RoutedEventArgs e)
        {
            Super1.PlayerEQ[2] = 0;
            BAG.Legs = true;
            Remove3.IsEnabled = false;
            StatsMeaning();
            EquipL.Content = "Ноги";
            EquipWatch();
        }

        private void Remove4_Click(object sender, RoutedEventArgs e)
        {
            Super1.PlayerEQ[3] = 0;
            BAG.Boots = true;
            Remove4.IsEnabled = false;
            StatsMeaning();
            EquipD.Content = "Ступни";
            EquipWatch();
        }

        private void Equip1_Click(object sender, RoutedEventArgs e)
        {
            Sets.EquipmentClass = 0;
            ButtonShow(Equipments);
            EquipmentsImg.Source = new BitmapImage(new Uri(@"KnucledusterItem.png", UriKind.RelativeOrAbsolute));
            ButtonShow(CancelEq);
        }

        private void Equipments_Click(object sender, RoutedEventArgs e)
        {
            if (Sets.EquipmentClass == 0)
            {
                Equip1.IsEnabled = false;
                EquipH.Content = "Др. кастет";
                Super1.PlayerEQ[0] = 10;
                BAG.Hands = false;
            }
            if (Sets.EquipmentClass == 1)
            {
                Equip2.IsEnabled = false;
                EquipB.Content = "Ч. кожак";
                Super1.PlayerEQ[1] = 5;
                BAG.Jacket = false;
            }
            if (Sets.EquipmentClass == 2)
            {
                Equip3.IsEnabled = false;
                EquipL.Content = "Штаны С.";
                Super1.PlayerEQ[2] = 4;
                BAG.Legs = false;
            }
            if (Sets.EquipmentClass == 3)
            {
                Equip4.IsEnabled = false;
                EquipD.Content = "Б. обувь";
                Super1.PlayerEQ[3] = 1;
                BAG.Boots = false;
            }
            StatsMeaning();
            ButtonHide(Equipments);
            ButtonHide(CancelEq);
            EquipWatch();
        }

        private void Equip2_Click(object sender, RoutedEventArgs e)
        {
            Sets.EquipmentClass = 1;
            ButtonShow(Equipments);
            EquipmentsImg.Source = new BitmapImage(new Uri(@"BlackSkinItems.png", UriKind.RelativeOrAbsolute));
            ButtonShow(CancelEq);
        }

        private void Equip3_Click(object sender, RoutedEventArgs e)
        {
            Sets.EquipmentClass = 2;
            ButtonShow(Equipments);
            EquipmentsImg.Source = new BitmapImage(new Uri(@"EagleWearsItems.png", UriKind.RelativeOrAbsolute));
            ButtonShow(CancelEq);
        }

        private void Equip4_Click(object sender, RoutedEventArgs e)
        {
            Sets.EquipmentClass = 3;
            ButtonShow(Equipments);
            EquipmentsImg.Source = new BitmapImage(new Uri(@"BandageBootsItems.png", UriKind.RelativeOrAbsolute));
            ButtonShow(CancelEq);
        }

        private void CancelEq_Click(object sender, RoutedEventArgs e)
        {
            ButtonHide(Equipments);
            ButtonHide(CancelEq);
        }

        private void Tasks_Click(object sender, RoutedEventArgs e)
        {
            if (!Items0.IsEnabled)
            {
                Dj(new Uri(@"ItemsClose.mp3", UriKind.RelativeOrAbsolute));
            }
            MegaHide();
            AllturnON();
            LabShow(Describe2);
            Tasks.IsEnabled = false;
            var uriSource2 = new Uri(@"ActiveTask.png", UriKind.RelativeOrAbsolute);
            var uriSource3 = new Uri(@"CompletedTask.png", UriKind.RelativeOrAbsolute);
            switch (Sets.MenuTask)
            {
                case 0:
                    LabShow(Task1);
                    ImgShow(Task1Img);
                    Task1Img.Source = new BitmapImage(uriSource2);
                    break;
                case 1:
                    LabShow(Task1);
                    ImgShow(Task1Img);
                    LabShow(Task2);
                    ImgShow(Task2Img);
                    Task1Img.Source = new BitmapImage(uriSource3);
                    Task2Img.Source = new BitmapImage(uriSource2);
                    break;
                case 2:
                    LabShow(Task1);
                    ImgShow(Task1Img);
                    LabShow(Task2);
                    ImgShow(Task2Img);
                    LabShow(Task3);
                    ImgShow(Task3Img);
                    Task1Img.Source = new BitmapImage(uriSource3);
                    Task2Img.Source = new BitmapImage(uriSource3);
                    Task3Img.Source = new BitmapImage(uriSource2);
                    break;
                case 3:
                    LabShow(Task1);
                    ImgShow(Task1Img);
                    LabShow(Task2);
                    ImgShow(Task2Img);
                    LabShow(Task3);
                    ImgShow(Task3Img);
                    LabShow(Task4);
                    ImgShow(Task4Img);
                    Task1Img.Source = new BitmapImage(uriSource3);
                    Task2Img.Source = new BitmapImage(uriSource3);
                    Task3Img.Source = new BitmapImage(uriSource3);
                    Task4Img.Source = new BitmapImage(uriSource2);
                    break;
                default:
                    LabShow(Task1);
                    ImgShow(Task1Img);
                    break;
            }
            Describe1.Content = "Цель: добраться до сокровищ древних и внести вклад в общее развитие\nархеологии.";
            LabShow(Describe1);
        }

        private void Tasks_MouseEnter(object sender, MouseEventArgs e)
        {
            Describe2.Content = "Перейти к задачам";
        }

        private void Tasks_MouseLeave(object sender, MouseEventArgs e)
        {
            Describe2.Content = "";
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            if (!Items0.IsEnabled)
            {
                Dj(new Uri(@"ItemsClose.mp3", UriKind.RelativeOrAbsolute));
            }
            MegaHide();
            AllturnON();
            Info.IsEnabled = false;
            GameMenu.InfoChange1 = 0;
            InfoHeaderText1.Content = GameMenu.HelpInfo1[0, GameMenu.InfoChange1];
            InfoHeaderText2.Content = GameMenu.HelpInfo1[1, GameMenu.InfoChange1];
            InfoHeaderText3.Content = GameMenu.HelpInfo1[2, GameMenu.InfoChange1];
            InfoText1.Content = GameMenu.HelpInfo2[0, GameMenu.InfoChange1];
            InfoText2.Content = GameMenu.HelpInfo2[1, GameMenu.InfoChange1];
            InfoText3.Content = GameMenu.HelpInfo2[2, GameMenu.InfoChange1];
            LabShow(Describe2);
            LabShow(InfoText1);
            LabShow(InfoText2);
            LabShow(InfoText3);
            LabShow(InfoHeaderText1);
            LabShow(InfoHeaderText2);
            LabShow(InfoHeaderText3);
            LabShow(InfoIndex);
            ButtonShow(InfoIndexPlus);
            InfoIndex.Content = (GameMenu.InfoChange1 + 1) + "/5";
            Describe1.Content = "Подсказка: во время сражения с превосходящим по силе оппонентом лучше\nотступать.";
            LabShow(Describe1);
        }

        private void InfoIndexPlus_Click(object sender, RoutedEventArgs e)
        {
            GameMenu.InfoChange1 += 1;
            InfoHeaderText1.Content = GameMenu.HelpInfo1[0, GameMenu.InfoChange1];
            InfoHeaderText2.Content = GameMenu.HelpInfo1[1, GameMenu.InfoChange1];
            InfoHeaderText3.Content = GameMenu.HelpInfo1[2, GameMenu.InfoChange1];
            InfoText1.Content = GameMenu.HelpInfo2[0, GameMenu.InfoChange1];
            InfoText2.Content = GameMenu.HelpInfo2[1, GameMenu.InfoChange1];
            InfoText3.Content = GameMenu.HelpInfo2[2, GameMenu.InfoChange1];
            InfoIndex.Content = (GameMenu.InfoChange1 + 1) + "/5";
            ButtonShow(InfoIndexMinus);
            if (GameMenu.InfoChange1 >= 4)
            {
                ButtonHide(InfoIndexPlus);
            }
        }

        private void InfoIndexMinus_Click(object sender, RoutedEventArgs e)
        {
            GameMenu.InfoChange1 -= 1;
            InfoHeaderText1.Content = GameMenu.HelpInfo1[0, GameMenu.InfoChange1];
            InfoHeaderText2.Content = GameMenu.HelpInfo1[1, GameMenu.InfoChange1];
            InfoHeaderText3.Content = GameMenu.HelpInfo1[2, GameMenu.InfoChange1];
            InfoText1.Content = GameMenu.HelpInfo2[0, GameMenu.InfoChange1];
            InfoText2.Content = GameMenu.HelpInfo2[1, GameMenu.InfoChange1];
            InfoText3.Content = GameMenu.HelpInfo2[2, GameMenu.InfoChange1];
            InfoIndex.Content = (GameMenu.InfoChange1 + 1) + "/5";
            ButtonShow(InfoIndexPlus);
            if (GameMenu.InfoChange1 <= 0)
            {
                ButtonHide(InfoIndexMinus);
            }
        }

        private void Info_MouseEnter(object sender, MouseEventArgs e)
        {
            Describe2.Content = "Посмотреть справку\n(Что мне делать?)";
        }

        private void Info_MouseLeave(object sender, MouseEventArgs e)
        {
            Describe2.Content = "";
        }

        private void Equipments_MouseEnter(object sender, MouseEventArgs e)
        {
            LabShow(Describe1);
            if (Sets.EquipmentClass == 0)
            {
                Describe1.Content = "Прочный костяной кастет. Одно из лучших средств показать свою мощь!\n(АТК +10)";
            }
            if (Sets.EquipmentClass == 1)
            {
                Describe1.Content = "Черная кожаная куртка. Никто не ценит ничего так сильно, как надёжный кожак\nв жуткую погоду.\n(ЗЩТ +5)";
            }
            if (Sets.EquipmentClass == 2)
            {
                Describe1.Content = "Штаны из перьев стервятника. Вполне сгодится и на огородное пугало...\n(ЗЩТ +4)";
            }
            if (Sets.EquipmentClass == 3)
            {
                Describe1.Content = "Бинтовая обувь. Спасает от ужасной жары здешних песков как никогда.\n(ЗЩТ +1)";
            }
        }

        private void Equipments_MouseLeave(object sender, MouseEventArgs e)
        {
            Describe1.Content = "";
        }

        private void PharaohBattle_MediaEnded(object sender, RoutedEventArgs e)
        {
            Img2.Visibility = Visibility.Hidden;
            Sound1.Stop();
            MediaHide(PharaohBattle);
            Dj(new Uri(@"Ambushed.mp3", UriKind.RelativeOrAbsolute));
            MediaShow(Med2);
        }

        private void TheEnd_MediaEnded(object sender, RoutedEventArgs e)
        {
            var uriSource = new Uri(@"Final1.mp4", UriKind.RelativeOrAbsolute);
            var uriSource1 = new Uri(@"Titres3.mp4", UriKind.RelativeOrAbsolute);
            if (TheEnd.Source == uriSource1)
                Form1.Close();
            else
            {
                if (TheEnd.Source != uriSource)
                {
                    HideFightIconPersActions();
                    WonOrDied();
                    TheEnd.Stop();
                    TheEnd.Source = uriSource;
                    TheEnd.Position = new TimeSpan(0, 0, 0, 0, 0);
                    HeyPlaySomething(new Uri(@"Final1.mp3", UriKind.RelativeOrAbsolute));
                    TheEnd.Play();
                }
                else
                {
                    if (TheEnd.Source != uriSource1)
                    {
                        TheEnd.Stop();
                        TheEnd.Source = uriSource1;
                        TheEnd.Position = new TimeSpan(0, 0, 0, 0, 0);
                        HeyPlaySomething(new Uri(@"Titres.mp3", UriKind.RelativeOrAbsolute));
                        TheEnd.Play();
                    }
                }
            }
        }

        private void Sound3_MediaEnded(object sender, RoutedEventArgs e)
        {
            Sound3.Stop();
            Sound3.Position = new TimeSpan(0, 0, 0, 0, 0);
        }

        private void Med3_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            Med3Stop();
        }

        private void Med4_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            Med4Stop();
        }

        private void Med4_MediaOpened(object sender, RoutedEventArgs e)
        {
            ImgHide(Img5);
        }

        private void Med3_MediaOpened(object sender, RoutedEventArgs e)
        {
            ImgHide(Img4);
        }

        private void Win_MediaOpened(object sender, RoutedEventArgs e)
        {
            WonOrDied();
        }

        private void Trgt_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            Trgt.Stop();
            Trgt.Play();
        }

        private void Med1_MediaOpened(object sender, RoutedEventArgs e)
        {
            ButtonHide(Button1);
            ImgHide(Img1);
            LabHide(Lab1);
            ButtonShow(Skip1);
        }

        private void PharaohBattle_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            Img2.Visibility = Visibility.Hidden;
            Sound1.Stop();
            MediaHide(PharaohBattle);
            Dj(new Uri(@"Ambushed.mp3", UriKind.RelativeOrAbsolute));
            MediaShow(Med2);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (Img2.IsEnabled)
            {
                if (e.Key == Key.W)
                {
                    Img2.Source = new BitmapImage(new Uri(@"person2.png", UriKind.RelativeOrAbsolute));
                }
                if (e.Key == Key.A)
                {
                    Img2.Source = new BitmapImage(new Uri(@"person4.png", UriKind.RelativeOrAbsolute));
                }
                if (e.Key == Key.S)
                {
                    Img2.Source = new BitmapImage(new Uri(@"person1.png", UriKind.RelativeOrAbsolute));
                }
                if (e.Key == Key.D)
                {
                    Img2.Source = new BitmapImage(new Uri(@"person3.png", UriKind.RelativeOrAbsolute));
                }
            }
        }
    }
}

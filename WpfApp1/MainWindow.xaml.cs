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
            Materials = 0;
        }
        public Byte BandageITM { get; set; }
        public Byte AntidoteITM { get; set; }
        public Byte EtherITM { get; set; }
        public Byte FusedITM { get; set; }
        public Boolean Hands { get; set; }
        public Boolean Jacket { get; set; }
        public Boolean Legs { get; set; }
        public Boolean Boots { get; set; }
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
                ImgXbounds = 18;
                ImgYbounds = 34;
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
            //MapBuild();
            //Lab1.Content = MapScheme[Adoptation.ImgYbounds+1, Adoptation.ImgXbounds];
            //[EN] Working with directories (for commercial and private purposes)
            //[RU] Работа с директориями (для коммерческих и личных целей).
            //Environment.CurrentDirectory();
            //Sound1.Play();
            HeyPlaySomething(new Uri(@"Begin2.mp3", UriKind.RelativeOrAbsolute));
            //Sound1.Volume = 0.0;
            //Sound2.Volume = 0.0;
            //Sound3.Volume = 0.0;
            //ImgMove(Img2, -1362, 1020);
            //ImgMove(TableMessage1, 402, 749);
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
            //TimeImg
            Label[] LabMS = { Lab1, Lab2, CureDescribe, HealDescribe, HealCost, CureCost, CostText, BandageText, EtherText, AntidoteText, FusedText, CountText, Task1, Task2, Task3, Task4, InfoHeaderText1, InfoHeaderText2, InfoHeaderText3, InfoText1, InfoText2, InfoText3, InfoIndex, Describe1, Describe2, BattleText1, BattleText2, HPtext, APtext, LevelText, ExpText, ItemText, BattleText3, BattleText4, BattleText5, BattleText6, HPenemy, BandageText, EtherText, AntidoteText, FusedText, CountText, ATK, SP, CureDescribe, HealDescribe, HealCost, CureCost, CostText, Name0, Level0, StatusP, HPtext1, APtext1, Exp1, ATK1, DEF1, AG1, SP1, Params, ParamsATK, ParamsDEF, ParamsAG, ParamsSP, HP1, AP1, EquipH, EquipB, EquipL, EquipD, EquipText, HP, AP };
            Image[] ImgMS = { Icon0, ATKImg, DEFImg, AGImg, SPImg, EquipHImg, EquipBImg, EquipLImg, EquipDImg, Task1Img, Task2Img, Task3Img, Task4Img, Img4, Img5, ItemsCountImg, Img6, Img7, Img8, ChestImg4, ChestImg3, ChestImg2, ChestImg1, LockImg3, LockImg2, LockImg1, KeyImg3, KeyImg2, KeyImg1, Threasure1, Table1, Table2, Table3, TableMessage1, ChestMessage1 };
            ProgressBar[] StBarMS = { HPbar1, APbar1, ExpBar1 };
            ProgressBar[] BarMS = { HPbar, APbar, NextExpBar, Time1, HPenemyBar };
            MediaElement[] MedMS = { PharaohBattle, Med3, Med4, Trgt };
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
            //ImgShrink(Img3, W, H);
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
                        //ImgMove(Img2, -(I2S[0, j] * 25), 1020 * Adoptation.HeightAdBack);
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
                //ImgMove(Img2, -1075, 1020);
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
        System.Windows.Threading.DispatcherTimer timer3 = null;
        System.Windows.Threading.DispatcherTimer timer4 = null;
        System.Windows.Threading.DispatcherTimer timer5 = null;
        System.Windows.Threading.DispatcherTimer timer6 = null;
        System.Windows.Threading.DispatcherTimer timer7 = null;
        System.Windows.Threading.DispatcherTimer timer8 = null;
        System.Windows.Threading.DispatcherTimer timer9 = null;
        System.Windows.Threading.DispatcherTimer timer10 = null;
        System.Windows.Threading.DispatcherTimer timer11 = null;
        System.Windows.Threading.DispatcherTimer timer12 = null;
        System.Windows.Threading.DispatcherTimer timer13 = null;

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
            Adoptation.ImgXbounds = 18;
            Adoptation.ImgYbounds = 34;
            Super1.CurrentLevel = 1;
            HPbar.Maximum = Super1.MaxHPNxt[Super1.CurrentLevel - 1];
            HPbar.Value = HPbar.Maximum;
            APbar.Maximum = Super1.MaxAPNxt[Super1.CurrentLevel - 1];
            APbar.Value = APbar.Maximum;
            //ImgMove(Img2, -775 * Adoptation.WidthAdBack, 1020 * Adoptation.HeightAdBack);
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
            BAG.AntidoteITM = 10;
            BAG.BandageITM = 10;
            BAG.EtherITM = 10;
            BAG.FusedITM = 10;
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
            MapBuild();
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

        private void MapBuild()
        {
            MapScheme = new Byte[,]
            { {  1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
              {  1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1 },
              {  1,0,0,1,0,1,0,0,1,0,1,0,0,0,1,1,1,1,1,1,0,1,1,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,1,1,1,0,0,0,1 },
              {  1,0,0,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0,1,1,1,0,1,0,0,0,0,0,1,0,0,0,0,1,0,1,1,0,0,1,0,0,0,0,1,0,0,0,0,0,0,1 },
              {  1,1,1,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,1,1,1,1,1,1,0,0,1,0,1,0,1,0,0,0,0,1,0,1,0,0,0,1,0,0,1,1,0,1,0,0,1,1,0,0,1,1,1,0,0,1 },
              {  1,0,0,0,1,0,0,0,0,1,1,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0,1,0,1,0,1,1,0,0,0,0,0,0,0,0,1,1,1,0,1,0,0,1,0,1,1,0,0,0,0,0,1,1,0,1 },
              {  1,1,0,1,1,0,1,1,1,1,0,1,1,0,1,1,1,1,0,1,1,1,0,0,1,0,0,0,0,0,0,1,1,0,0,0,0,0,0,1,1,1,0,0,1,0,1,1,0,1,0,0,1,1,1,1,0,1,0,1 },
              {  1,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,1,0,0,1,1,0,1,0,0,0,1,1,1,1,0,1,1,1,0,0,0,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0,1 },
              {  1,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1,0,0,0,1,1,1,0,1,0,0,1,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,1,1,1,0,1,0,1,0,1,0,0,0,1,0,1,0,1 },
              {  1,0,1,0,0,0,0,0,0,0,0,0,1,0,1,0,1,1,1,1,0,0,0,0,0,1,1,0,0,0,1,0,0,0,0,1,1,1,1,0,0,0,0,0,1,0,0,1,0,1,0,1,0,1,0,1,0,1,0,1 },
              {  1,0,1,0,1,1,1,1,1,1,1,0,1,0,1,0,1,0,0,0,1,1,0,0,1,0,0,1,0,1,0,0,1,0,0,0,0,0,0,1,1,1,1,1,1,0,1,1,0,1,0,0,1,1,0,1,0,1,0,1 },
              {  1,0,1,0,1,0,0,0,0,0,1,0,1,0,0,0,1,0,0,0,0,1,0,1,0,0,1,0,0,0,1,0,0,1,1,1,0,0,0,1,1,1,0,0,0,0,0,1,0,1,1,0,0,0,0,0,1,1,0,1 },
              {  1,0,1,0,1,0,1,1,1,0,1,0,1,1,1,1,1,0,1,0,0,0,1,0,0,0,1,0,1,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,1,0,0,1,1,1,1,1,1,1,0,0,1 },
              {  1,0,1,0,1,0,1,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,1,0,0,1,0,0,0,0,0,1,1,1,1,0,0,1,1,1,1,1,1,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,1 },
              {  1,0,1,0,1,0,1,0,1,0,1,0,0,0,0,0,0,0,1,0,0,1,0,0,0,1,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1 },
              {  1,0,1,0,1,0,1,0,1,0,1,0,0,0,1,1,1,1,1,0,0,1,0,1,1,1,1,1,0,1,1,1,1,0,0,1,1,1,1,1,1,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1 },
              {  1,0,1,0,1,0,1,0,1,1,1,1,1,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,1 },
              {  1,0,0,0,0,0,1,0,0,0,0,0,0,1,1,0,0,0,1,0,0,0,1,1,0,1,0,0,1,0,1,0,1,0,1,1,1,1,1,0,1,1,1,1,1,1,0,1,1,0,0,0,1,0,0,0,0,0,0,1 },
              {  1,0,1,1,0,1,0,0,0,0,0,1,1,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,1 },
              {  1,1,1,0,0,1,1,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,1,1,1,1,1,1,0,1,1,0,1,1,1,0,0,1,0,0,1,1,1,0,1,1,1,1,0,0,1,0,0,0,0,0,0,0,1 },
              {  1,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,1,1,0,0,1,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,1 },
              {  1,0,1,0,0,0,0,1,1,1,1,0,0,0,0,0,1,0,1,0,0,1,1,0,0,0,0,0,0,0,0,1,1,1,0,1,0,1,0,0,0,0,1,0,1,1,1,0,0,0,0,0,0,0,0,0,1,0,0,1 },
              {  1,0,1,0,0,0,0,0,0,0,1,1,0,0,0,0,1,0,0,0,0,0,0,1,0,1,1,0,0,0,0,0,0,1,0,1,0,0,0,0,0,1,1,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,1 },
              {  1,0,1,0,1,1,1,0,0,0,0,1,0,0,0,0,1,0,0,0,1,0,1,0,1,0,0,1,0,0,0,0,0,1,1,1,1,1,1,1,0,1,0,0,1,0,0,1,1,1,1,0,0,0,0,0,1,0,0,1 },
              {  1,0,1,0,1,0,0,0,0,0,1,0,0,0,1,1,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,1,0,0,1 },
              {  1,1,1,0,1,1,1,1,0,0,1,1,0,0,1,0,1,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,1,0,0,1,0,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,0,0,1 },
              {  1,0,0,0,1,0,0,0,0,0,0,1,1,1,1,0,1,1,1,1,1,1,0,0,1,0,0,1,0,0,0,1,1,1,0,1,1,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,1 },
              {  1,0,1,1,1,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,1,0,0,1,1,1,1,0,0,0,0,1,1,0,0,1,0,0,0,0,0,1,0,0,1,1,1,0,1,0,0,1,0,0,1 },
              {  1,0,0,0,1,0,0,1,1,1,0,0,0,0,1,0,0,1,0,1,0,0,0,1,0,0,1,0,0,1,0,0,0,1,1,1,1,1,1,1,1,1,1,0,1,0,0,1,0,0,0,0,0,1,0,0,1,1,0,1 },
              {  1,0,1,0,1,0,0,0,0,1,0,0,1,0,0,0,0,1,0,0,1,1,0,0,1,0,1,0,0,1,0,0,0,1,0,0,0,1,1,0,0,0,0,1,0,1,0,0,1,1,1,1,1,1,1,0,1,0,0,1 },
              {  1,0,1,0,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,0,1,0,0,1,0,0,1,0,1,1,0,0,0,1,0,1,0,1,0,0,0,1,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,1 },
              {  1,1,1,0,1,1,1,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0,1,1,1,1,1,0,0,1,0,0,0,1,0,1,0,1,0,1,1,1,0,1,1,0,0,1,1,1,1,0,0,1,1,0,1,0,0,1 },
              {  1,0,0,0,1,0,0,0,0,1,1,0,0,1,0,0,1,0,0,0,1,0,1,0,0,0,1,0,1,1,0,0,0,0,0,1,0,0,0,0,1,0,0,0,1,1,0,0,0,0,1,0,0,1,0,0,1,1,0,1 },
              {  1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,1,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,0,1,0,0,1,0,0,1 },
              {  1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
              {  1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 } };
            /*Image[,] MapNames = new Image[,]
            { { Map_0_0, Map_0_1, Map_0_2, Map_0_3, Map_0_4, Map_0_5, Map_0_6, Map_0_7, Map_0_8, Map_0_9, Map_0_10, Map_0_11, Map_0_12, Map_0_13, Map_0_14, Map_0_15, Map_0_16, Map_0_17, Map_0_18, Map_0_19, Map_0_20, Map_0_21, Map_0_22, Map_0_23, Map_0_24, Map_0_25, Map_0_26, Map_0_27, Map_0_28, Map_0_29, Map_0_30, Map_0_31, Map_0_32, Map_0_33, Map_0_34, Map_0_35, Map_0_36, Map_0_37, Map_0_38, Map_0_39, Map_0_40, Map_0_41, Map_0_42, Map_0_43, Map_0_44, Map_0_45, Map_0_46, Map_0_47, Map_0_48, Map_0_49, Map_0_50, Map_0_51, Map_0_52, Map_0_53, Map_0_54, Map_0_55, Map_0_56, Map_0_57, Map_0_58, Map_0_59 },
              {Map_1_0, Map_1_1, Map_1_2, Map_1_3, Map_1_4, Map_1_5, Map_1_6, Map_1_7, Map_1_8, Map_1_9, Map_1_10, Map_1_11, Map_1_12, Map_1_13, Map_1_14, Map_1_15, Map_1_16, Map_1_17, Map_1_18, Map_1_19, Map_1_20, Map_1_21, Map_1_22, Map_1_23, Map_1_24, Map_1_25, Map_1_26, Map_1_27, Map_1_28, Map_1_29, Map_1_30, Map_1_31, Map_1_32, Map_1_33, Map_1_34, Map_1_35, Map_1_36, Map_1_37, Map_1_38, Map_1_39, Map_1_40, Map_1_41, Map_1_42, Map_1_43, Map_1_44, Map_1_45, Map_1_46, Map_1_47, Map_1_48, Map_1_49, Map_1_50, Map_1_51, Map_1_52, Map_1_53, Map_1_54, Map_1_55, Map_1_56, Map_1_57, Map_1_58, Map_1_59 },
              {Map_2_0, Map_2_1, Map_2_2, Map_2_3, Map_2_4, Map_2_5, Map_2_6, Map_2_7, Map_2_8, Map_2_9, Map_2_10, Map_2_11, Map_2_12, Map_2_13, Map_2_14, Map_2_15, Map_2_16, Map_2_17, Map_2_18, Map_2_19, Map_2_20, Map_2_21, Map_2_22, Map_2_23, Map_2_24, Map_2_25, Map_2_26, Map_2_27, Map_2_28, Map_2_29, Map_2_30, Map_2_31, Map_2_32, Map_2_33, Map_2_34, Map_2_35, Map_2_36, Map_2_37, Map_2_38, Map_2_39, Map_2_40, Map_2_41, Map_2_42, Map_2_43, Map_2_44, Map_2_45, Map_2_46, Map_2_47, Map_2_48, Map_2_49, Map_2_50, Map_2_51, Map_2_52, Map_2_53, Map_2_54, Map_2_55, Map_2_56, Map_2_57, Map_2_58, Map_2_59 },
              {Map_3_0, Map_3_1, Map_3_2, Map_3_3, Map_3_4, Map_3_5, Map_3_6, Map_3_7, Map_3_8, Map_3_9, Map_3_10, Map_3_11, Map_3_12, Map_3_13, Map_3_14, Map_3_15, Map_3_16, Map_3_17, Map_3_18, Map_3_19, Map_3_20, Map_3_21, Map_3_22, Map_3_23, Map_3_24, Map_3_25, Map_3_26, Map_3_27, Map_3_28, Map_3_29, Map_3_30, Map_3_31, Map_3_32, Map_3_33, Map_3_34, Map_3_35, Map_3_36, Map_3_37, Map_3_38, Map_3_39, Map_3_40, Map_3_41, Map_3_42, Map_3_43, Map_3_44, Map_3_45, Map_3_46, Map_3_47, Map_3_48, Map_3_49, Map_3_50, Map_3_51, Map_3_52, Map_3_53, Map_3_54, Map_3_55, Map_3_56, Map_3_57, Map_3_58, Map_3_59 },
              {Map_4_0, Map_4_1, Map_4_2, Map_4_3, Map_4_4, Map_4_5, Map_4_6, Map_4_7, Map_4_8, Map_4_9, Map_4_10, Map_4_11, Map_4_12, Map_4_13, Map_4_14, Map_4_15, Map_4_16, Map_4_17, Map_4_18, Map_4_19, Map_4_20, Map_4_21, Map_4_22, Map_4_23, Map_4_24, Map_4_25, Map_4_26, Map_4_27, Map_4_28, Map_4_29, Map_4_30, Map_4_31, Map_4_32, Map_4_33, Map_4_34, Map_4_35, Map_4_36, Map_4_37, Map_4_38, Map_4_39, Map_4_40, Map_4_41, Map_4_42, Map_4_43, Map_4_44, Map_4_45, Map_4_46, Map_4_47, Map_4_48, Map_4_49, Map_4_50, Map_4_51, Map_4_52, Map_4_53, Map_4_54, Map_4_55, Map_4_56, Map_4_57, Map_4_58, Map_4_59 },
              {Map_5_0, Map_5_1, Map_5_2, Map_5_3, Map_5_4, Map_5_5, Map_5_6, Map_5_7, Map_5_8, Map_5_9, Map_5_10, Map_5_11, Map_5_12, Map_5_13, Map_5_14, Map_5_15, Map_5_16, Map_5_17, Map_5_18, Map_5_19, Map_5_20, Map_5_21, Map_5_22, Map_5_23, Map_5_24, Map_5_25, Map_5_26, Map_5_27, Map_5_28, Map_5_29, Map_5_30, Map_5_31, Map_5_32, Map_5_33, Map_5_34, Map_5_35, Map_5_36, Map_5_37, Map_5_38, Map_5_39, Map_5_40, Map_5_41, Map_5_42, Map_5_43, Map_5_44, Map_5_45, Map_5_46, Map_5_47, Map_5_48, Map_5_49, Map_5_50, Map_5_51, Map_5_52, Map_5_53, Map_5_54, Map_5_55, Map_5_56, Map_5_57, Map_5_58, Map_5_59 },
              {Map_6_0, Map_6_1, Map_6_2, Map_6_3, Map_6_4, Map_6_5, Map_6_6, Map_6_7, Map_6_8, Map_6_9, Map_6_10, Map_6_11, Map_6_12, Map_6_13, Map_6_14, Map_6_15, Map_6_16, Map_6_17, Map_6_18, Map_6_19, Map_6_20, Map_6_21, Map_6_22, Map_6_23, Map_6_24, Map_6_25, Map_6_26, Map_6_27, Map_6_28, Map_6_29, Map_6_30, Map_6_31, Map_6_32, Map_6_33, Map_6_34, Map_6_35, Map_6_36, Map_6_37, Map_6_38, Map_6_39, Map_6_40, Map_6_41, Map_6_42, Map_6_43, Map_6_44, Map_6_45, Map_6_46, Map_6_47, Map_6_48, Map_6_49, Map_6_50, Map_6_51, Map_6_52, Map_6_53, Map_6_54, Map_6_55, Map_6_56, Map_6_57, Map_6_58, Map_6_59 },
              {Map_7_0, Map_7_1, Map_7_2, Map_7_3, Map_7_4, Map_7_5, Map_7_6, Map_7_7, Map_7_8, Map_7_9, Map_7_10, Map_7_11, Map_7_12, Map_7_13, Map_7_14, Map_7_15, Map_7_16, Map_7_17, Map_7_18, Map_7_19, Map_7_20, Map_7_21, Map_7_22, Map_7_23, Map_7_24, Map_7_25, Map_7_26, Map_7_27, Map_7_28, Map_7_29, Map_7_30, Map_7_31, Map_7_32, Map_7_33, Map_7_34, Map_7_35, Map_7_36, Map_7_37, Map_7_38, Map_7_39, Map_7_40, Map_7_41, Map_7_42, Map_7_43, Map_7_44, Map_7_45, Map_7_46, Map_7_47, Map_7_48, Map_7_49, Map_7_50, Map_7_51, Map_7_52, Map_7_53, Map_7_54, Map_7_55, Map_7_56, Map_7_57, Map_7_58, Map_7_59 },
              {Map_8_0, Map_8_1, Map_8_2, Map_8_3, Map_8_4, Map_8_5, Map_8_6, Map_8_7, Map_8_8, Map_8_9, Map_8_10, Map_8_11, Map_8_12, Map_8_13, Map_8_14, Map_8_15, Map_8_16, Map_8_17, Map_8_18, Map_8_19, Map_8_20, Map_8_21, Map_8_22, Map_8_23, Map_8_24, Map_8_25, Map_8_26, Map_8_27, Map_8_28, Map_8_29, Map_8_30, Map_8_31, Map_8_32, Map_8_33, Map_8_34, Map_8_35, Map_8_36, Map_8_37, Map_8_38, Map_8_39, Map_8_40, Map_8_41, Map_8_42, Map_8_43, Map_8_44, Map_8_45, Map_8_46, Map_8_47, Map_8_48, Map_8_49, Map_8_50, Map_8_51, Map_8_52, Map_8_53, Map_8_54, Map_8_55, Map_8_56, Map_8_57, Map_8_58, Map_8_59 },
              {Map_9_0, Map_9_1, Map_9_2, Map_9_3, Map_9_4, Map_9_5, Map_9_6, Map_9_7, Map_9_8, Map_9_9, Map_9_10, Map_9_11, Map_9_12, Map_9_13, Map_9_14, Map_9_15, Map_9_16, Map_9_17, Map_9_18, Map_9_19, Map_9_20, Map_9_21, Map_9_22, Map_9_23, Map_9_24, Map_9_25, Map_9_26, Map_9_27, Map_9_28, Map_9_29, Map_9_30, Map_9_31, Map_9_32, Map_9_33, Map_9_34, Map_9_35, Map_9_36, Map_9_37, Map_9_38, Map_9_39, Map_9_40, Map_9_41, Map_9_42, Map_9_43, Map_9_44, Map_9_45, Map_9_46, Map_9_47, Map_9_48, Map_9_49, Map_9_50, Map_9_51, Map_9_52, Map_9_53, Map_9_54, Map_9_55, Map_9_56, Map_9_57, Map_9_58, Map_9_59 },
              {Map_10_0, Map_10_1, Map_10_2, Map_10_3, Map_10_4, Map_10_5, Map_10_6, Map_10_7, Map_10_8, Map_10_9, Map_10_10, Map_10_11, Map_10_12, Map_10_13, Map_10_14, Map_10_15, Map_10_16, Map_10_17, Map_10_18, Map_10_19, Map_10_20, Map_10_21, Map_10_22, Map_10_23, Map_10_24, Map_10_25, Map_10_26, Map_10_27, Map_10_28, Map_10_29, Map_10_30, Map_10_31, Map_10_32, Map_10_33, Map_10_34, Map_10_35, Map_10_36, Map_10_37, Map_10_38, Map_10_39, Map_10_40, Map_10_41, Map_10_42, Map_10_43, Map_10_44, Map_10_45, Map_10_46, Map_10_47, Map_10_48, Map_10_49, Map_10_50, Map_10_51, Map_10_52, Map_10_53, Map_10_54, Map_10_55, Map_10_56, Map_10_57, Map_10_58, Map_10_59 },
              {Map_11_0, Map_11_1, Map_11_2, Map_11_3, Map_11_4, Map_11_5, Map_11_6, Map_11_7, Map_11_8, Map_11_9, Map_11_10, Map_11_11, Map_11_12, Map_11_13, Map_11_14, Map_11_15, Map_11_16, Map_11_17, Map_11_18, Map_11_19, Map_11_20, Map_11_21, Map_11_22, Map_11_23, Map_11_24, Map_11_25, Map_11_26, Map_11_27, Map_11_28, Map_11_29, Map_11_30, Map_11_31, Map_11_32, Map_11_33, Map_11_34, Map_11_35, Map_11_36, Map_11_37, Map_11_38, Map_11_39, Map_11_40, Map_11_41, Map_11_42, Map_11_43, Map_11_44, Map_11_45, Map_11_46, Map_11_47, Map_11_48, Map_11_49, Map_11_50, Map_11_51, Map_11_52, Map_11_53, Map_11_54, Map_11_55, Map_11_56, Map_11_57, Map_11_58, Map_11_59 },
              {Map_12_0, Map_12_1, Map_12_2, Map_12_3, Map_12_4, Map_12_5, Map_12_6, Map_12_7, Map_12_8, Map_12_9, Map_12_10, Map_12_11, Map_12_12, Map_12_13, Map_12_14, Map_12_15, Map_12_16, Map_12_17, Map_12_18, Map_12_19, Map_12_20, Map_12_21, Map_12_22, Map_12_23, Map_12_24, Map_12_25, Map_12_26, Map_12_27, Map_12_28, Map_12_29, Map_12_30, Map_12_31, Map_12_32, Map_12_33, Map_12_34, Map_12_35, Map_12_36, Map_12_37, Map_12_38, Map_12_39, Map_12_40, Map_12_41, Map_12_42, Map_12_43, Map_12_44, Map_12_45, Map_12_46, Map_12_47, Map_12_48, Map_12_49, Map_12_50, Map_12_51, Map_12_52, Map_12_53, Map_12_54, Map_12_55, Map_12_56, Map_12_57, Map_12_58, Map_12_59 },
              {Map_13_0, Map_13_1, Map_13_2, Map_13_3, Map_13_4, Map_13_5, Map_13_6, Map_13_7, Map_13_8, Map_13_9, Map_13_10, Map_13_11, Map_13_12, Map_13_13, Map_13_14, Map_13_15, Map_13_16, Map_13_17, Map_13_18, Map_13_19, Map_13_20, Map_13_21, Map_13_22, Map_13_23, Map_13_24, Map_13_25, Map_13_26, Map_13_27, Map_13_28, Map_13_29, Map_13_30, Map_13_31, Map_13_32, Map_13_33, Map_13_34, Map_13_35, Map_13_36, Map_13_37, Map_13_38, Map_13_39, Map_13_40, Map_13_41, Map_13_42, Map_13_43, Map_13_44, Map_13_45, Map_13_46, Map_13_47, Map_13_48, Map_13_49, Map_13_50, Map_13_51, Map_13_52, Map_13_53, Map_13_54, Map_13_55, Map_13_56, Map_13_57, Map_13_58, Map_13_59 },
              {Map_14_0, Map_14_1, Map_14_2, Map_14_3, Map_14_4, Map_14_5, Map_14_6, Map_14_7, Map_14_8, Map_14_9, Map_14_10, Map_14_11, Map_14_12, Map_14_13, Map_14_14, Map_14_15, Map_14_16, Map_14_17, Map_14_18, Map_14_19, Map_14_20, Map_14_21, Map_14_22, Map_14_23, Map_14_24, Map_14_25, Map_14_26, Map_14_27, Map_14_28, Map_14_29, Map_14_30, Map_14_31, Map_14_32, Map_14_33, Map_14_34, Map_14_35, Map_14_36, Map_14_37, Map_14_38, Map_14_39, Map_14_40, Map_14_41, Map_14_42, Map_14_43, Map_14_44, Map_14_45, Map_14_46, Map_14_47, Map_14_48, Map_14_49, Map_14_50, Map_14_51, Map_14_52, Map_14_53, Map_14_54, Map_14_55, Map_14_56, Map_14_57, Map_14_58, Map_14_59 },
              {Map_15_0, Map_15_1, Map_15_2, Map_15_3, Map_15_4, Map_15_5, Map_15_6, Map_15_7, Map_15_8, Map_15_9, Map_15_10, Map_15_11, Map_15_12, Map_15_13, Map_15_14, Map_15_15, Map_15_16, Map_15_17, Map_15_18, Map_15_19, Map_15_20, Map_15_21, Map_15_22, Map_15_23, Map_15_24, Map_15_25, Map_15_26, Map_15_27, Map_15_28, Map_15_29, Map_15_30, Map_15_31, Map_15_32, Map_15_33, Map_15_34, Map_15_35, Map_15_36, Map_15_37, Map_15_38, Map_15_39, Map_15_40, Map_15_41, Map_15_42, Map_15_43, Map_15_44, Map_15_45, Map_15_46, Map_15_47, Map_15_48, Map_15_49, Map_15_50, Map_15_51, Map_15_52, Map_15_53, Map_15_54, Map_15_55, Map_15_56, Map_15_57, Map_15_58, Map_15_59 },
              {Map_16_0, Map_16_1, Map_16_2, Map_16_3, Map_16_4, Map_16_5, Map_16_6, Map_16_7, Map_16_8, Map_16_9, Map_16_10, Map_16_11, Map_16_12, Map_16_13, Map_16_14, Map_16_15, Map_16_16, Map_16_17, Map_16_18, Map_16_19, Map_16_20, Map_16_21, Map_16_22, Map_16_23, Map_16_24, Map_16_25, Map_16_26, Map_16_27, Map_16_28, Map_16_29, Map_16_30, Map_16_31, Map_16_32, Map_16_33, Map_16_34, Map_16_35, Map_16_36, Map_16_37, Map_16_38, Map_16_39, Map_16_40, Map_16_41, Map_16_42, Map_16_43, Map_16_44, Map_16_45, Map_16_46, Map_16_47, Map_16_48, Map_16_49, Map_16_50, Map_16_51, Map_16_52, Map_16_53, Map_16_54, Map_16_55, Map_16_56, Map_16_57, Map_16_58, Map_16_59 },
              {Map_17_0, Map_17_1, Map_17_2, Map_17_3, Map_17_4, Map_17_5, Map_17_6, Map_17_7, Map_17_8, Map_17_9, Map_17_10, Map_17_11, Map_17_12, Map_17_13, Map_17_14, Map_17_15, Map_17_16, Map_17_17, Map_17_18, Map_17_19, Map_17_20, Map_17_21, Map_17_22, Map_17_23, Map_17_24, Map_17_25, Map_17_26, Map_17_27, Map_17_28, Map_17_29, Map_17_30, Map_17_31, Map_17_32, Map_17_33, Map_17_34, Map_17_35, Map_17_36, Map_17_37, Map_17_38, Map_17_39, Map_17_40, Map_17_41, Map_17_42, Map_17_43, Map_17_44, Map_17_45, Map_17_46, Map_17_47, Map_17_48, Map_17_49, Map_17_50, Map_17_51, Map_17_52, Map_17_53, Map_17_54, Map_17_55, Map_17_56, Map_17_57, Map_17_58, Map_17_59 },
              {Map_18_0, Map_18_1, Map_18_2, Map_18_3, Map_18_4, Map_18_5, Map_18_6, Map_18_7, Map_18_8, Map_18_9, Map_18_10, Map_18_11, Map_18_12, Map_18_13, Map_18_14, Map_18_15, Map_18_16, Map_18_17, Map_18_18, Map_18_19, Map_18_20, Map_18_21, Map_18_22, Map_18_23, Map_18_24, Map_18_25, Map_18_26, Map_18_27, Map_18_28, Map_18_29, Map_18_30, Map_18_31, Map_18_32, Map_18_33, Map_18_34, Map_18_35, Map_18_36, Map_18_37, Map_18_38, Map_18_39, Map_18_40, Map_18_41, Map_18_42, Map_18_43, Map_18_44, Map_18_45, Map_18_46, Map_18_47, Map_18_48, Map_18_49, Map_18_50, Map_18_51, Map_18_52, Map_18_53, Map_18_54, Map_18_55, Map_18_56, Map_18_57, Map_18_58, Map_18_59 },
              {Map_19_0, Map_19_1, Map_19_2, Map_19_3, Map_19_4, Map_19_5, Map_19_6, Map_19_7, Map_19_8, Map_19_9, Map_19_10, Map_19_11, Map_19_12, Map_19_13, Map_19_14, Map_19_15, Map_19_16, Map_19_17, Map_19_18, Map_19_19, Map_19_20, Map_19_21, Map_19_22, Map_19_23, Map_19_24, Map_19_25, Map_19_26, Map_19_27, Map_19_28, Map_19_29, Map_19_30, Map_19_31, Map_19_32, Map_19_33, Map_19_34, Map_19_35, Map_19_36, Map_19_37, Map_19_38, Map_19_39, Map_19_40, Map_19_41, Map_19_42, Map_19_43, Map_19_44, Map_19_45, Map_19_46, Map_19_47, Map_19_48, Map_19_49, Map_19_50, Map_19_51, Map_19_52, Map_19_53, Map_19_54, Map_19_55, Map_19_56, Map_19_57, Map_19_58, Map_19_59 },
              {Map_20_0, Map_20_1, Map_20_2, Map_20_3, Map_20_4, Map_20_5, Map_20_6, Map_20_7, Map_20_8, Map_20_9, Map_20_10, Map_20_11, Map_20_12, Map_20_13, Map_20_14, Map_20_15, Map_20_16, Map_20_17, Map_20_18, Map_20_19, Map_20_20, Map_20_21, Map_20_22, Map_20_23, Map_20_24, Map_20_25, Map_20_26, Map_20_27, Map_20_28, Map_20_29, Map_20_30, Map_20_31, Map_20_32, Map_20_33, Map_20_34, Map_20_35, Map_20_36, Map_20_37, Map_20_38, Map_20_39, Map_20_40, Map_20_41, Map_20_42, Map_20_43, Map_20_44, Map_20_45, Map_20_46, Map_20_47, Map_20_48, Map_20_49, Map_20_50, Map_20_51, Map_20_52, Map_20_53, Map_20_54, Map_20_55, Map_20_56, Map_20_57, Map_20_58, Map_20_59 },
              {Map_21_0, Map_21_1, Map_21_2, Map_21_3, Map_21_4, Map_21_5, Map_21_6, Map_21_7, Map_21_8, Map_21_9, Map_21_10, Map_21_11, Map_21_12, Map_21_13, Map_21_14, Map_21_15, Map_21_16, Map_21_17, Map_21_18, Map_21_19, Map_21_20, Map_21_21, Map_21_22, Map_21_23, Map_21_24, Map_21_25, Map_21_26, Map_21_27, Map_21_28, Map_21_29, Map_21_30, Map_21_31, Map_21_32, Map_21_33, Map_21_34, Map_21_35, Map_21_36, Map_21_37, Map_21_38, Map_21_39, Map_21_40, Map_21_41, Map_21_42, Map_21_43, Map_21_44, Map_21_45, Map_21_46, Map_21_47, Map_21_48, Map_21_49, Map_21_50, Map_21_51, Map_21_52, Map_21_53, Map_21_54, Map_21_55, Map_21_56, Map_21_57, Map_21_58, Map_21_59 },
              {Map_22_0, Map_22_1, Map_22_2, Map_22_3, Map_22_4, Map_22_5, Map_22_6, Map_22_7, Map_22_8, Map_22_9, Map_22_10, Map_22_11, Map_22_12, Map_22_13, Map_22_14, Map_22_15, Map_22_16, Map_22_17, Map_22_18, Map_22_19, Map_22_20, Map_22_21, Map_22_22, Map_22_23, Map_22_24, Map_22_25, Map_22_26, Map_22_27, Map_22_28, Map_22_29, Map_22_30, Map_22_31, Map_22_32, Map_22_33, Map_22_34, Map_22_35, Map_22_36, Map_22_37, Map_22_38, Map_22_39, Map_22_40, Map_22_41, Map_22_42, Map_22_43, Map_22_44, Map_22_45, Map_22_46, Map_22_47, Map_22_48, Map_22_49, Map_22_50, Map_22_51, Map_22_52, Map_22_53, Map_22_54, Map_22_55, Map_22_56, Map_22_57, Map_22_58, Map_22_59 },
              {Map_23_0, Map_23_1, Map_23_2, Map_23_3, Map_23_4, Map_23_5, Map_23_6, Map_23_7, Map_23_8, Map_23_9, Map_23_10, Map_23_11, Map_23_12, Map_23_13, Map_23_14, Map_23_15, Map_23_16, Map_23_17, Map_23_18, Map_23_19, Map_23_20, Map_23_21, Map_23_22, Map_23_23, Map_23_24, Map_23_25, Map_23_26, Map_23_27, Map_23_28, Map_23_29, Map_23_30, Map_23_31, Map_23_32, Map_23_33, Map_23_34, Map_23_35, Map_23_36, Map_23_37, Map_23_38, Map_23_39, Map_23_40, Map_23_41, Map_23_42, Map_23_43, Map_23_44, Map_23_45, Map_23_46, Map_23_47, Map_23_48, Map_23_49, Map_23_50, Map_23_51, Map_23_52, Map_23_53, Map_23_54, Map_23_55, Map_23_56, Map_23_57, Map_23_58, Map_23_59 },
              {Map_24_0, Map_24_1, Map_24_2, Map_24_3, Map_24_4, Map_24_5, Map_24_6, Map_24_7, Map_24_8, Map_24_9, Map_24_10, Map_24_11, Map_24_12, Map_24_13, Map_24_14, Map_24_15, Map_24_16, Map_24_17, Map_24_18, Map_24_19, Map_24_20, Map_24_21, Map_24_22, Map_24_23, Map_24_24, Map_24_25, Map_24_26, Map_24_27, Map_24_28, Map_24_29, Map_24_30, Map_24_31, Map_24_32, Map_24_33, Map_24_34, Map_24_35, Map_24_36, Map_24_37, Map_24_38, Map_24_39, Map_24_40, Map_24_41, Map_24_42, Map_24_43, Map_24_44, Map_24_45, Map_24_46, Map_24_47, Map_24_48, Map_24_49, Map_24_50, Map_24_51, Map_24_52, Map_24_53, Map_24_54, Map_24_55, Map_24_56, Map_24_57, Map_24_58, Map_24_59 },
              {Map_25_0, Map_25_1, Map_25_2, Map_25_3, Map_25_4, Map_25_5, Map_25_6, Map_25_7, Map_25_8, Map_25_9, Map_25_10, Map_25_11, Map_25_12, Map_25_13, Map_25_14, Map_25_15, Map_25_16, Map_25_17, Map_25_18, Map_25_19, Map_25_20, Map_25_21, Map_25_22, Map_25_23, Map_25_24, Map_25_25, Map_25_26, Map_25_27, Map_25_28, Map_25_29, Map_25_30, Map_25_31, Map_25_32, Map_25_33, Map_25_34, Map_25_35, Map_25_36, Map_25_37, Map_25_38, Map_25_39, Map_25_40, Map_25_41, Map_25_42, Map_25_43, Map_25_44, Map_25_45, Map_25_46, Map_25_47, Map_25_48, Map_25_49, Map_25_50, Map_25_51, Map_25_52, Map_25_53, Map_25_54, Map_25_55, Map_25_56, Map_25_57, Map_25_58, Map_25_59 },
              {Map_26_0, Map_26_1, Map_26_2, Map_26_3, Map_26_4, Map_26_5, Map_26_6, Map_26_7, Map_26_8, Map_26_9, Map_26_10, Map_26_11, Map_26_12, Map_26_13, Map_26_14, Map_26_15, Map_26_16, Map_26_17, Map_26_18, Map_26_19, Map_26_20, Map_26_21, Map_26_22, Map_26_23, Map_26_24, Map_26_25, Map_26_26, Map_26_27, Map_26_28, Map_26_29, Map_26_30, Map_26_31, Map_26_32, Map_26_33, Map_26_34, Map_26_35, Map_26_36, Map_26_37, Map_26_38, Map_26_39, Map_26_40, Map_26_41, Map_26_42, Map_26_43, Map_26_44, Map_26_45, Map_26_46, Map_26_47, Map_26_48, Map_26_49, Map_26_50, Map_26_51, Map_26_52, Map_26_53, Map_26_54, Map_26_55, Map_26_56, Map_26_57, Map_26_58, Map_26_59 },
              {Map_27_0, Map_27_1, Map_27_2, Map_27_3, Map_27_4, Map_27_5, Map_27_6, Map_27_7, Map_27_8, Map_27_9, Map_27_10, Map_27_11, Map_27_12, Map_27_13, Map_27_14, Map_27_15, Map_27_16, Map_27_17, Map_27_18, Map_27_19, Map_27_20, Map_27_21, Map_27_22, Map_27_23, Map_27_24, Map_27_25, Map_27_26, Map_27_27, Map_27_28, Map_27_29, Map_27_30, Map_27_31, Map_27_32, Map_27_33, Map_27_34, Map_27_35, Map_27_36, Map_27_37, Map_27_38, Map_27_39, Map_27_40, Map_27_41, Map_27_42, Map_27_43, Map_27_44, Map_27_45, Map_27_46, Map_27_47, Map_27_48, Map_27_49, Map_27_50, Map_27_51, Map_27_52, Map_27_53, Map_27_54, Map_27_55, Map_27_56, Map_27_57, Map_27_58, Map_27_59 },
              {Map_28_0, Map_28_1, Map_28_2, Map_28_3, Map_28_4, Map_28_5, Map_28_6, Map_28_7, Map_28_8, Map_28_9, Map_28_10, Map_28_11, Map_28_12, Map_28_13, Map_28_14, Map_28_15, Map_28_16, Map_28_17, Map_28_18, Map_28_19, Map_28_20, Map_28_21, Map_28_22, Map_28_23, Map_28_24, Map_28_25, Map_28_26, Map_28_27, Map_28_28, Map_28_29, Map_28_30, Map_28_31, Map_28_32, Map_28_33, Map_28_34, Map_28_35, Map_28_36, Map_28_37, Map_28_38, Map_28_39, Map_28_40, Map_28_41, Map_28_42, Map_28_43, Map_28_44, Map_28_45, Map_28_46, Map_28_47, Map_28_48, Map_28_49, Map_28_50, Map_28_51, Map_28_52, Map_28_53, Map_28_54, Map_28_55, Map_28_56, Map_28_57, Map_28_58, Map_28_59 },
              {Map_29_0, Map_29_1, Map_29_2, Map_29_3, Map_29_4, Map_29_5, Map_29_6, Map_29_7, Map_29_8, Map_29_9, Map_29_10, Map_29_11, Map_29_12, Map_29_13, Map_29_14, Map_29_15, Map_29_16, Map_29_17, Map_29_18, Map_29_19, Map_29_20, Map_29_21, Map_29_22, Map_29_23, Map_29_24, Map_29_25, Map_29_26, Map_29_27, Map_29_28, Map_29_29, Map_29_30, Map_29_31, Map_29_32, Map_29_33, Map_29_34, Map_29_35, Map_29_36, Map_29_37, Map_29_38, Map_29_39, Map_29_40, Map_29_41, Map_29_42, Map_29_43, Map_29_44, Map_29_45, Map_29_46, Map_29_47, Map_29_48, Map_29_49, Map_29_50, Map_29_51, Map_29_52, Map_29_53, Map_29_54, Map_29_55, Map_29_56, Map_29_57, Map_29_58, Map_29_59 },
              {Map_30_0, Map_30_1, Map_30_2, Map_30_3, Map_30_4, Map_30_5, Map_30_6, Map_30_7, Map_30_8, Map_30_9, Map_30_10, Map_30_11, Map_30_12, Map_30_13, Map_30_14, Map_30_15, Map_30_16, Map_30_17, Map_30_18, Map_30_19, Map_30_20, Map_30_21, Map_30_22, Map_30_23, Map_30_24, Map_30_25, Map_30_26, Map_30_27, Map_30_28, Map_30_29, Map_30_30, Map_30_31, Map_30_32, Map_30_33, Map_30_34, Map_30_35, Map_30_36, Map_30_37, Map_30_38, Map_30_39, Map_30_40, Map_30_41, Map_30_42, Map_30_43, Map_30_44, Map_30_45, Map_30_46, Map_30_47, Map_30_48, Map_30_49, Map_30_50, Map_30_51, Map_30_52, Map_30_53, Map_30_54, Map_30_55, Map_30_56, Map_30_57, Map_30_58, Map_30_59 },
              {Map_31_0, Map_31_1, Map_31_2, Map_31_3, Map_31_4, Map_31_5, Map_31_6, Map_31_7, Map_31_8, Map_31_9, Map_31_10, Map_31_11, Map_31_12, Map_31_13, Map_31_14, Map_31_15, Map_31_16, Map_31_17, Map_31_18, Map_31_19, Map_31_20, Map_31_21, Map_31_22, Map_31_23, Map_31_24, Map_31_25, Map_31_26, Map_31_27, Map_31_28, Map_31_29, Map_31_30, Map_31_31, Map_31_32, Map_31_33, Map_31_34, Map_31_35, Map_31_36, Map_31_37, Map_31_38, Map_31_39, Map_31_40, Map_31_41, Map_31_42, Map_31_43, Map_31_44, Map_31_45, Map_31_46, Map_31_47, Map_31_48, Map_31_49, Map_31_50, Map_31_51, Map_31_52, Map_31_53, Map_31_54, Map_31_55, Map_31_56, Map_31_57, Map_31_58, Map_31_59 },
              {Map_32_0, Map_32_1, Map_32_2, Map_32_3, Map_32_4, Map_32_5, Map_32_6, Map_32_7, Map_32_8, Map_32_9, Map_32_10, Map_32_11, Map_32_12, Map_32_13, Map_32_14, Map_32_15, Map_32_16, Map_32_17, Map_32_18, Map_32_19, Map_32_20, Map_32_21, Map_32_22, Map_32_23, Map_32_24, Map_32_25, Map_32_26, Map_32_27, Map_32_28, Map_32_29, Map_32_30, Map_32_31, Map_32_32, Map_32_33, Map_32_34, Map_32_35, Map_32_36, Map_32_37, Map_32_38, Map_32_39, Map_32_40, Map_32_41, Map_32_42, Map_32_43, Map_32_44, Map_32_45, Map_32_46, Map_32_47, Map_32_48, Map_32_49, Map_32_50, Map_32_51, Map_32_52, Map_32_53, Map_32_54, Map_32_55, Map_32_56, Map_32_57, Map_32_58, Map_32_59 },
              {Map_33_0, Map_33_1, Map_33_2, Map_33_3, Map_33_4, Map_33_5, Map_33_6, Map_33_7, Map_33_8, Map_33_9, Map_33_10, Map_33_11, Map_33_12, Map_33_13, Map_33_14, Map_33_15, Map_33_16, Map_33_17, Map_33_18, Map_33_19, Map_33_20, Map_33_21, Map_33_22, Map_33_23, Map_33_24, Map_33_25, Map_33_26, Map_33_27, Map_33_28, Map_33_29, Map_33_30, Map_33_31, Map_33_32, Map_33_33, Map_33_34, Map_33_35, Map_33_36, Map_33_37, Map_33_38, Map_33_39, Map_33_40, Map_33_41, Map_33_42, Map_33_43, Map_33_44, Map_33_45, Map_33_46, Map_33_47, Map_33_48, Map_33_49, Map_33_50, Map_33_51, Map_33_52, Map_33_53, Map_33_54, Map_33_55, Map_33_56, Map_33_57, Map_33_58, Map_33_59 },
              {Map_34_0, Map_34_1, Map_34_2, Map_34_3, Map_34_4, Map_34_5, Map_34_6, Map_34_7, Map_34_8, Map_34_9, Map_34_10, Map_34_11, Map_34_12, Map_34_13, Map_34_14, Map_34_15, Map_34_16, Map_34_17, Map_34_18, Map_34_19, Map_34_20, Map_34_21, Map_34_22, Map_34_23, Map_34_24, Map_34_25, Map_34_26, Map_34_27, Map_34_28, Map_34_29, Map_34_30, Map_34_31, Map_34_32, Map_34_33, Map_34_34, Map_34_35, Map_34_36, Map_34_37, Map_34_38, Map_34_39, Map_34_40, Map_34_41, Map_34_42, Map_34_43, Map_34_44, Map_34_45, Map_34_46, Map_34_47, Map_34_48, Map_34_49, Map_34_50, Map_34_51, Map_34_52, Map_34_53, Map_34_54, Map_34_55, Map_34_56, Map_34_57, Map_34_58, Map_34_59 },
              {Map_35_0, Map_35_1, Map_35_2, Map_35_3, Map_35_4, Map_35_5, Map_35_6, Map_35_7, Map_35_8, Map_35_9, Map_35_10, Map_35_11, Map_35_12, Map_35_13, Map_35_14, Map_35_15, Map_35_16, Map_35_17, Map_35_18, Map_35_19, Map_35_20, Map_35_21, Map_35_22, Map_35_23, Map_35_24, Map_35_25, Map_35_26, Map_35_27, Map_35_28, Map_35_29, Map_35_30, Map_35_31, Map_35_32, Map_35_33, Map_35_34, Map_35_35, Map_35_36, Map_35_37, Map_35_38, Map_35_39, Map_35_40, Map_35_41, Map_35_42, Map_35_43, Map_35_44, Map_35_45, Map_35_46, Map_35_47, Map_35_48, Map_35_49, Map_35_50, Map_35_51, Map_35_52, Map_35_53, Map_35_54, Map_35_55, Map_35_56, Map_35_57, Map_35_58, Map_35_59 } };
                        for (Byte i=0;i< MapScheme.GetLength(0); i++)
                        {
                            for (Byte j = 0; j < MapScheme.GetLength(1); j++)
                            {
                                if (MapScheme[i, j]==0)
                                {
                                    MapNames[i, j].Source = new BitmapImage(new Uri("/Way1.jpg", UriKind.RelativeOrAbsolute));
                                } else if (MapScheme[i, j] == 1)
                                {
                                    MapNames[i, j].Source = new BitmapImage(new Uri("/Wall1.jpg", UriKind.RelativeOrAbsolute));
                                }
                            }
                        }*/
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
            Img1.Source = new BitmapImage(new Uri(@"Loc1_2.jpg", UriKind.RelativeOrAbsolute));
            //ImgShow(Img2);
            ImgShow(TableMessage1);
            ButtonHide(Skip1);
            //ChestsAllTurnOn1();
            //KeysAllTurnOn1();
            //LocksAllTurnOn1();
            ImgShow(Threasure1);
            ImgShow(Img2);
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
            Byte[] grRow = new Byte[] { 23, 15, 21 };
            Byte[] grColumn = new Byte[] { 2, 13, 24 };
            int[] newHP = { Spider.EnemyMHP, Mummy.EnemyMHP, Zombie.EnemyMHP, Bones.EnemyMHP, BOSS1.EnemyMHP };
            LabShow(BattleText1);
            for (int en = 0; en < newHP.Length; en++)
            {
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == Foe1.EnemyName[en])
                {
                    BattleText1.Content = Foe1.EnemyName[en];
                    HPenemyBar.Maximum = newHP[en];
                    HPenemyBar.Width = HPenemyBar.Maximum;
                    Grid.SetColumn(BattleText1, 17);
                    break;
                }
            }
            //MedMove(Trgt,x[Sets.SelectedTarget] * Adoptation.WidthAdBack, y[Sets.SelectedTarget] * Adoptation.HeightAdBack);
            Grid.SetRow(TrgtImg, grRow[Sets.SelectedTarget]);
            Grid.SetColumn(TrgtImg, grColumn[Sets.SelectedTarget]);
            HPenemyBar.Value = Foe1.EnemyHP[Sets.SelectedTarget];
            //LabMove(HPenemy, HPenemyBar.Margin.Left + HPenemyBar.Width - 1 / Adoptation.WidthAdBack, 125 * Adoptation.HeightAdBack);
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
            if ((Sets.TableEN) || (TableMessage1.IsEnabled))
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
                //HP.Margin = new Thickness(HPbar.Margin.Left + HPbar.Width - 1 / Adoptation.WidthAdBack, 38 * Adoptation.HeightAdBack, 0, 0);
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
                    if (MapScheme[Adoptation.ImgYbounds - 1, Adoptation.ImgXbounds] != 1)
                    {
                        Adoptation.ImgYbounds -= 1;
                        Img2.SetValue(Grid.RowProperty, Adoptation.ImgYbounds);
                    }
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
                    if (MapScheme[Adoptation.ImgYbounds, Adoptation.ImgXbounds - 1] != 1)
                    {
                        Adoptation.ImgXbounds -= 1;
                        Img2.SetValue(Grid.ColumnProperty, Adoptation.ImgXbounds);
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
                    if (MapScheme[Adoptation.ImgYbounds + 1, Adoptation.ImgXbounds] != 1)
                    {
                        Adoptation.ImgYbounds += 1;
                        Img2.SetValue(Grid.RowProperty, Adoptation.ImgYbounds);
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
                    if (MapScheme[Adoptation.ImgYbounds, Adoptation.ImgXbounds + 1] != 1)
                    {
                        Adoptation.ImgXbounds += 1;
                        Img2.SetValue(Grid.ColumnProperty, Adoptation.ImgXbounds);
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
                        ChestMessage1.Margin = new Thickness(460 * Adoptation.WidthAdBack, 660 * Adoptation.HeightAdBack, 0, 0);
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
                        Image[] IMGSlctrl = { Menu1, Img2, Img1, Icon0, EquipHImg, EquipBImg, EquipLImg, EquipDImg, ATKImg, DEFImg, AGImg, SPImg };
                        Label[] LABSlctrl = { Name0, Level0, StatusP, Exp1, HPtext1, APtext1, HP1, AP1, Describe1, Describe2, Params, ParamsATK, ParamsDEF, ParamsAG, ParamsSP, EquipText, ATK1, DEF1, AG1, SP1, EquipH, EquipB, EquipL, EquipD };
                        ProgressBar[] BARSlctrl = { HPbar1, APbar1, ExpBar1 };
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
                        if (Convert.ToString(Exp1.Content) != "Максимальный")
                            Exp1.Margin = new Thickness(881 * Adoptation.WidthAdBack + 30 * Adoptation.WidthAdBack, Exp1.Margin.Top, 0, 0);
                        else
                            Exp1.Margin = new Thickness(881 * Adoptation.WidthAdBack + 60 * Adoptation.WidthAdBack, Exp1.Margin.Top, 0, 0);
                        //System.Windows.MessageBox.Show(Exp1.Margin.Left.ToString());
                        Describe2.Content = "";
                        SP1.Content = Super1.Special;
                        Double[] HeightAdopt = { 121, 121, 121 };
                        Double[] WidthAdopt = { 278, 470, 706 };
                        Label[] labm = { Name0, Level0, StatusP };
                        //for (int it = 0; it < labm.Length; it++)
                        //{
                        //    LabMove(labm[it], WidthAdopt[it] * Adoptation.WidthAdBack, HeightAdopt[it] * Adoptation.HeightAdBack);
                        //}
                        BarMove(HPbar1, 418 * Adoptation.WidthAdBack, 275 * Adoptation.HeightAdBack);
                        BarMove(APbar1, 418 * Adoptation.WidthAdBack, 352 * Adoptation.HeightAdBack);
                        //LabMove(HPtext1, HPbar1.Margin.Left - 300 * Adoptation.WidthAdBack, HPbar1.Margin.Top - 7 * Adoptation.HeightAdBack);
                        //LabMove(APtext1, APbar1.Margin.Left - 300 * Adoptation.WidthAdBack, APbar1.Margin.Top - 7 * Adoptation.HeightAdBack);
                        //LabMove(HP1, HPbar1.Margin.Left + HPbar1.Width + 30 * Adoptation.WidthAdBack, HPbar1.Margin.Top - 7);
                        //LabMove(AP1, APbar1.Margin.Left + APbar1.Width + 30 * Adoptation.HeightAdBack, APbar1.Margin.Top - 7);
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
            ProgressBar[] MegaHIDEBar = { HPbar1, APbar1, ExpBar1 };
            Label[] MegaHIDELab = { Name0, StatusP, Exp1, HPtext1, APtext1, HP1, AP1, Describe1, Describe2, Params, ParamsATK, ParamsDEF, ParamsAG, ParamsSP, EquipText, ATK1, DEF1, AG1, SP1, EquipH, EquipB, EquipL, EquipD, CureCost, HealCost, CostText, CureDescribe, HealDescribe, Task1, Task2, Task3, Task4, InfoHeaderText1, InfoHeaderText2, InfoHeaderText3, InfoText1, InfoText2, InfoText3, InfoIndex, Level0, AntidoteText, EtherText, BandageText, FusedText };
            Button[] MegaHIDEButton = { Ether1, Bandage, Antidote, Cure1, Heal1, Fused, Equip1, Equip2, Equip3, Equip4, Remove1, Remove2, Remove3, Remove4, Equipments, CancelEq, InfoIndexPlus, InfoIndexMinus };
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

        public static Byte[] EnemyNamesFight= new Byte[] {0,0,0,0};
        public static UInt16 Mat = 0;
        private void Med2_MediaEnded(object sender, RoutedEventArgs e)
        {
            EnemyNamesFight = new Byte[] { 0, 0, 0, 0 };
            if (Img2.Source.ToString().Contains("WalkU1.png") || Img2.Source.ToString().Contains("WalkU2.png"))
            {
                Img2.Source = new BitmapImage(new Uri(@"person1.png", UriKind.RelativeOrAbsolute));
            }
            else if (Img2.Source.ToString().Contains("WalkL1.png"))
            {
                Img2.Source = new BitmapImage(new Uri(@"person4.png", UriKind.RelativeOrAbsolute));
            }
            else if (Img2.Source.ToString().Contains("WalkD1.png") || Img2.Source.ToString().Contains("WalkD2.png"))
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
            ImgShow(TimeTurnImg);
            LabShow(HP);
            LabShow(AP);
            //HP.Margin = new Thickness(HPbar.Margin.Left + HPbar.Width - 1 / Adoptation.WidthAdBack, 38 * Adoptation.HeightAdBack, 0, 0);
            HP.Content = HPbar.Value + "/" + HPbar.Maximum;
            //AP.Margin = new Thickness(APbar.Margin.Left + APbar.Width - 1 / Adoptation.WidthAdBack, 87 * Adoptation.HeightAdBack, 0, 0);
            AP.Content = APbar.Value + "/" + APbar.Maximum;
            int[] x = { 34, 360, 712 };
            int[] y = { 644, 492, 675 };
            Lab2.Foreground = Brushes.Yellow;
            MediaHide(Med2);
            speed = 0;
            ImgHide(Threasure1);
            //Trgt.Margin = new Thickness(x[0] * Adoptation.WidthAdBack, y[0] * Adoptation.HeightAdBack, 0, 0);
            ImgHide(Img1);
            ImgHide(Img2);
            ImgShow(Img3);
            ImgShow(Img4);
            ImgShow(Img5);
            ChestsAllTurnOff1();
            KeysAllTurnOff1();
            LocksAllTurnOff1();
            LabShow(Lab2);
            FightMenuBack();
            LabShow(HPtext);
            LabShow(APtext);
            BarShow(HPbar);
            BarShow(APbar);
            //TimeImg
            //LabShow(TimeText);
            //LabShow(HeroName);
            LabShow(LevelText);
            //BarShow(NextExpBar);
            //LabShow(ExpText);
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
                            Foe1.EnemyAppears[0] = "Паук";
                        }
                        if (ib == 2)
                        {
                            Foe1.EnemyHP[1] = 65;
                            Img7.Source = new BitmapImage(SpiderSRC);
                            Foe1.EnemyAppears[1] = "Паук";
                        }
                        if (ib == 3)
                        {
                            Foe1.EnemyHP[2] = 65;
                            Img8.Source = new BitmapImage(SpiderSRC);
                            Foe1.EnemyAppears[2] = "Паук";
                        }
                        Exp += 200;
                        Mat += 5;
                        Sets.SpiderAlive += 1;
                        Sets.ItemsDropRate[0] += 1;
                        if (EnemyNamesFight[0] == 0)
                        {
                            if ((EnemyNamesFight[1] != 1) && (EnemyNamesFight[2] != 1) && (EnemyNamesFight[3] != 1))
                            {
                                EnemyNamesFight[0] = 1;
                            }
                            else if ((EnemyNamesFight[1] != 2) && (EnemyNamesFight[2] != 2) && (EnemyNamesFight[3] != 2))
                            {
                                EnemyNamesFight[0] = 2;
                            }
                            else
                            {
                                EnemyNamesFight[0] = 3;
                            }
                        }
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
                        Mat += 10;
                        Exp += 8;
                        Sets.MummyAlive += 1;
                        Sets.ItemsDropRate[1] += 1;
                        if (EnemyNamesFight[1] == 0)
                        {
                            if ((EnemyNamesFight[0] != 1) && (EnemyNamesFight[2] != 1) && (EnemyNamesFight[3] != 1))
                            {
                                EnemyNamesFight[1] = 1;
                            }
                            else if ((EnemyNamesFight[0] != 2) && (EnemyNamesFight[2] != 2) && (EnemyNamesFight[3] != 2))
                            {
                                EnemyNamesFight[1] = 2;
                            }
                            else
                            {
                                EnemyNamesFight[1] = 3;
                            }
                        }
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
                        Mat += 35;
                        Exp += 12;
                        Sets.ZombieAlive += 1;
                        Sets.ItemsDropRate[2] += 1;
                        if (EnemyNamesFight[2] == 0)
                        {
                            if ((EnemyNamesFight[0] != 1) && (EnemyNamesFight[1] != 1) && (EnemyNamesFight[3] != 1))
                            {
                                EnemyNamesFight[2] = 1;
                            }
                            else if ((EnemyNamesFight[0] != 2) && (EnemyNamesFight[1] != 2) && (EnemyNamesFight[3] != 2))
                            {
                                EnemyNamesFight[2] = 2;
                            }
                            else
                            {
                                EnemyNamesFight[2] = 3;
                            }
                        }
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
                        Mat += 75;
                        Exp += 15;
                        Sets.BonesAlive += 1;
                        Sets.ItemsDropRate[3] += 1;
                        if (EnemyNamesFight[3] == 0)
                        {
                            if ((EnemyNamesFight[0] != 1) && (EnemyNamesFight[1] != 1) && (EnemyNamesFight[2] != 1))
                            {
                                EnemyNamesFight[3] = 1;
                            }
                            else if ((EnemyNamesFight[0] != 2) && (EnemyNamesFight[1] != 2) && (EnemyNamesFight[2] != 2))
                            {
                                EnemyNamesFight[3] = 2;
                            }
                            else
                            {
                                EnemyNamesFight[3] = 3;
                            }
                        }
                    }
                }
                string spdr = "Паук";
                string mum = "Мумия";
                string zomb = "Зомби";
                string defd = "Страж";
                //"            "
                if (Sets.SpiderAlive != 0)
                    BattleText3.Content = spdr + ": " + Sets.SpiderAlive;
                if (Sets.MummyAlive != 0)
                    BattleText4.Content = mum + ": " + Sets.MummyAlive;
                if (Sets.ZombieAlive != 0)
                    BattleText5.Content = zomb + ": " + Sets.ZombieAlive;
                if (Sets.BonesAlive != 0)
                    BattleText6.Content = defd + ": " + Sets.BonesAlive;
                //BattleText3.Content = EnemyNamesFight[0];
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
                BattleText3.Content = "Фараон: " + Foe1.EnemiesStillAlive;
                LabShow(BattleText3);
                Foe1.EnemyAppears[0] = "Фараон";
                Foe1.EnemyHP[0] = 500;
                Img6.Source = new BitmapImage(PharaohSRC);
                //Img6.Margin = new Thickness(Img6.Margin.Left, Img6.Margin.Top - 150 * Adoptation.HeightAdBack, 0, 0);
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
            FightMenuMakesDisappear();
            ButtonShow(Fight);
            ButtonShow(Cancel1);
            SelectTarget();
        }

        public void SelectTarget()
        {
            // LabMove(BattleText1, 473 * Adoptation.WidthAdBack, 5 * Adoptation.HeightAdBack);
            // LabShrink(BattleText1, 48 * Adoptation.WidthAdBack);
            LabShow(BattleText1);
            if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Паук")
            {
                BattleText1.Content = "Паук";
                HPenemyBar.Maximum = 65;
                // HPenemyBar.Width = HPenemyBar.Maximum*Adoptation.WidthAdBack;
            }
            if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Мумия")
            {
                BattleText1.Content = "Мумия";
                HPenemyBar.Maximum = 83;
                // HPenemyBar.Width = HPenemyBar.Maximum * Adoptation.WidthAdBack;
            }
            if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Зомби")
            {
                BattleText1.Content = "Зомби";
                HPenemyBar.Maximum = 101;
                //  HPenemyBar.Width = HPenemyBar.Maximum * Adoptation.WidthAdBack;
            }
            if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Страж")
            {
                BattleText1.Content = "Страж";
                HPenemyBar.Maximum = 125;
                //HPenemyBar.Width = HPenemyBar.Maximum * Adoptation.WidthAdBack;
            }
            if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Страж")
            {
                BattleText1.Content = "Страж";
                HPenemyBar.Maximum = 125;
                // HPenemyBar.Width = HPenemyBar.Maximum * Adoptation.WidthAdBack;
            }
            if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Фараон")
            {
                BattleText1.Content = "Фараон";
                HPenemyBar.Maximum = 500;
                // HPenemyBar.Width = HPenemyBar.Maximum * Adoptation.WidthAdBack;
            }
            LabShow(HPenemy);
            BarShow(HPenemyBar);
            ImgShow(EnemyImg);
            HPenemyBar.Value = Foe1.EnemyHP[Sets.SelectedTarget];
            //HPenemy.Margin = new Thickness(HPenemyBar.Margin.Left + HPenemyBar.Width - 1/ Adoptation.WidthAdBack, 125 * Adoptation.HeightAdBack, 0, 0);
            ImgShow(TrgtImg);
            HPenemy.Content = HPenemyBar.Value + "/" + HPenemyBar.Maximum;
            InfoAboutEnemies();
            timer9 = new System.Windows.Threading.DispatcherTimer();
            timer9.Tick += new EventHandler(Target_Time_Tick16);
            timer9.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timer9.Start();
            //Trgt.IsEnabled = true;
            //Trgt.Visibility = Visibility.Visible;
            //Trgt.Play();
        }

        private void Med3_MediaEnded(object sender, RoutedEventArgs e)
        {
            AfterAction();
        }

        private void AfterAction()
        {
            // Med3.Stop();
            // Med3.Position = new TimeSpan(0, 0, 0, 0, 0);
            //  MediaHide(Med3);
            BattleText3.Foreground = Brushes.White;
            BattleText4.Foreground = Brushes.White;
            BattleText5.Foreground = Brushes.White;
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
                ImgHide(TimeTurnImg);
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
                //LabHide(HeroName);
                LabHide(LevelText);
                BarHide(NextExpBar);
                LabHide(ExpText);
                //TimeImg
                //LabHide(TimeText);
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
                //MediaHide(Med4);
                if (Super1.CurrentLevel >= 2)
                    Abilities.IsEnabled = false;
                Abilities.Visibility = Visibility.Hidden;
                HeyPlaySomething(new Uri(@"Main_theme.mp3", UriKind.RelativeOrAbsolute));
            }
            else
            if (Foe1.EnemiesStillAlive <= 0)
            {
                Sound1.Stop();
                SEF(new Uri(@"YouWon.mp3", UriKind.RelativeOrAbsolute));
                // ImgHide(EnemyCursor);
                //LabMove(BattleText1, 723 * Adoptation.WidthAdBack, 45 * Adoptation.HeightAdBack);
                // LabShrink(BattleText1, 72 * Adoptation.WidthAdBack);
                Grid.SetColumn(BattleText1, 22);
                BattleText1.Content = "Победа!";
                //BattleText2.Content = "Получено " + Exp + " очков опыта";
                BattleText2.Content = "Пора переходить к добыче";
                BattleText3.Content = "";
                ImgShow(Img4);
                LabShow(BattleText1);
                LabShow(BattleText2);
                ButtonShow(textOk2);
                /*if (Super1.CurrentLevel < 10)
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
                }*/
            }
            else
            {
                if (HPbar.Value != 0)
                {
                    //ImgShow(Img4);
                    Time();
                }
            }
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Super1.DefenseState = 2;
            FightMenuMakesDisappear();
            Time1.Value = 0;
            Img5.Source = new BitmapImage(new Uri(@"IconDefence1.png", UriKind.RelativeOrAbsolute));
            Img4.Source = new BitmapImage(new Uri(@"Defence.png", UriKind.RelativeOrAbsolute));
            Lab2.Foreground = Brushes.White;
            Dj(new Uri(@"Defence.mp3", UriKind.RelativeOrAbsolute));
            Time();
        }

        private void Time()
        {
            if ((Time1.Value == 100) && (HPbar.Value != 0))
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
                FightMenuBack();
                Lab2.Foreground = Brushes.Yellow;
            }
            else
            {
                timer = new System.Windows.Threading.DispatcherTimer();
                timer.Tick += new EventHandler(Player_Time_Tick);
                timer.Interval = new TimeSpan(0, 0, 0, 0, 240 / Super1.Speed);
                timer.Start();
            }
        }
        private void TimeEnemy()
        {
            int aglfoe = 25;
            if ((Foe1.EnemyHP[0] != 0) || (Foe1.EnemyHP[1] != 0) || (Foe1.EnemyHP[2] != 0))
            {
                timer2 = new System.Windows.Threading.DispatcherTimer();
                timer2.Tick += new EventHandler(EnemyTime_Tick2);
                timer2.Interval = new TimeSpan(0, 0, 0, 0, 50 - aglfoe);
                timer2.Start();
            }
        }

        private int CheckEnemies(out int EnemyAttack, int pos)
        {
            EnemyAttack = 25;
            //Foe1.EnemyName[4] = "Фараон";
            for (int i = 0; i < Foe1.EnemyName.Length; i++)
            {
                //Foe.Stats[] FS = new Foe.Stats[] { Spider, Mummy, Zombie, Bones, BOSS1 };
                if (Foe1.EnemyAppears[pos - 1] == Foe1.EnemyName[i])
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
                        if (Speed < FS[j].EnemySpeed)
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
            string ogg = "";
            for (int i = 0; i < Foe1.EnemyName.Length; i++)
            {
                if (Foe1.EnemyAppears[pos] == Foe1.EnemyName[i])
                {
                    string[] sounds = { "SpiderDied", "MummyDied", "ZombieDied", "BonesDied", "DefeatPharaoh" };
                    ogg = sounds[i];
                    break;
                }
            }
            return ogg;
        }

        private void EnemyOnAttack(in string enemy, in int dmg)
        {
            //BattleText1.Content = enemy + " атакует!\nРэй получает " + dmg + " урона!";
            HPbar.Value = HPbar.Value - dmg;
            //HP.Margin = new Thickness(HPbar.Margin.Left + HPbar.Width - 1 / Adoptation.WidthAdBack, 38 * Adoptation.HeightAdBack, 0, 0);
            HP.Content = HPbar.Value + "/" + HPbar.Maximum;
            BattleText6.Content = "-" + dmg;
            BattleText6.Visibility = Visibility.Visible;
            //DamageGet = dmg.ToString();
            if (Img4.Source.ToString().Contains("pers5.png")) {
                timer3 = new System.Windows.Threading.DispatcherTimer();
                timer3.Tick += new EventHandler(DamageTime_Tick3);
                timer3.Interval = new TimeSpan(0, 0, 0, 0, 50);
                timer3.Start();
            }
            timer4 = new System.Windows.Threading.DispatcherTimer();
            timer4.Tick += new EventHandler(HurtTime_Tick4);
            timer4.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer4.Start();
            //LabMove(BattleText1, 473 * Adoptation.WidthAdBack, 5 * Adoptation.HeightAdBack);
            //LabShrink(BattleText1, 48 * Adoptation.WidthAdBack);
            // ImgShow(EnemyCursor);
        }

        public static Byte PlayerHurt = 0;
        public static Byte PlayerHurtM = 0;
        public static Byte[] EnemyAtck = new Byte[] { 0, 0, 0 };
        //public static string DamageGet = "";
        private void DamageTime_Tick3(object sender, EventArgs e)
        {
            string[] HurtImg = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PersonHurts\\PersonHurts1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PersonHurts\\PersonHurts2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PersonHurts\\PersonHurts3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PersonHurts\\PersonHurts4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PersonHurts\\PersonHurts5.png" };
            Img4.Source = new BitmapImage(new Uri(HurtImg[PlayerHurt], UriKind.RelativeOrAbsolute));
            if (PlayerHurt == HurtImg.Length - 1)
            {
                PlayerHurt = 0;
                Img4.Source = new BitmapImage(new Uri("/pers5.png", UriKind.RelativeOrAbsolute));
                timer3.Stop();
            }
            else
                PlayerHurt++;
        }

        private void HurtTime_Tick4(object sender, EventArgs e)
        {
            Byte[] RowSet1 = { 17, 18, 19, 18, 19 };
            Byte[] ColumnSet1 = { 50, 51, 52, 53, 54 };
            if (PlayerHurtM == ColumnSet1.Length - 1)
            {
                PlayerHurtM = 0;
                timer4.Stop();
                BattleText6.Visibility = Visibility.Hidden;
            }
            else
            {
                //BattleText6.SetValue(Grid.RowProperty, RowSet1[PlayerHurtM]);
                //BattleText6.SetValue(Grid.ColumnProperty, ColumnSet1[PlayerHurtM]);
                Grid.SetRow(BattleText6, RowSet1[PlayerHurtM]);
                Grid.SetColumn(BattleText6, ColumnSet1[PlayerHurtM]);
                PlayerHurtM++;
            }
        }

        private void FoeAttack1_Time_Tick5(object sender, EventArgs e)
        {
            string[] SpdAt = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks1.png" };
            Img6.Source = new BitmapImage(new Uri(SpdAt[EnemyAtck[0]], UriKind.RelativeOrAbsolute));
            if (EnemyAtck[0] == SpdAt.Length - 1)
            {
                EnemyAtck[0] = 0;
                Img6.Source = new BitmapImage(new Uri("/Spider.png", UriKind.RelativeOrAbsolute));
                timer5.Stop();
            }
            else
            {
                Img6.Source = new BitmapImage(new Uri(SpdAt[EnemyAtck[0]], UriKind.RelativeOrAbsolute));
                EnemyAtck[0]++;
            }
        }

        private void FoeAttack2_Time_Tick6(object sender, EventArgs e)
        {
            string[] SpdAt = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks1.png" };
            Img7.Source = new BitmapImage(new Uri(SpdAt[EnemyAtck[1]], UriKind.RelativeOrAbsolute));
            if (EnemyAtck[1] == SpdAt.Length - 1)
            {
                EnemyAtck[1] = 0;
                Img7.Source = new BitmapImage(new Uri("/Spider.png", UriKind.RelativeOrAbsolute));
                timer6.Stop();
            }
            else
            {
                Img7.Source = new BitmapImage(new Uri(SpdAt[EnemyAtck[1]], UriKind.RelativeOrAbsolute));
                EnemyAtck[1]++;
            }
        }

        private void FoeAttack3_Time_Tick7(object sender, EventArgs e)
        {
            string[] SpdAt = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks1.png" };
            Img8.Source = new BitmapImage(new Uri(SpdAt[EnemyAtck[2]], UriKind.RelativeOrAbsolute));
            if (EnemyAtck[2] == SpdAt.Length - 1)
            {
                EnemyAtck[2] = 0;
                Img8.Source = new BitmapImage(new Uri("/Spider.png", UriKind.RelativeOrAbsolute));
                timer7.Stop();
            }
            else
            {
                Img8.Source = new BitmapImage(new Uri(SpdAt[EnemyAtck[2]], UriKind.RelativeOrAbsolute));
                EnemyAtck[2]++;
            }
        }

        private void EnemyTime_Tick2(object sender, EventArgs e)
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
                if (timer != null)
                    timer.Stop();
                timer2.Stop();
                //HPbar.Value = 100;
            }
            if ((Super1.PlayerStatus == 1) && (HPbar.Value != 0))
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
            int PlayerDef = Super1.Defence * Super1.DefenseState + Super1.PlayerEQ[1] + Super1.PlayerEQ[2] + Super1.PlayerEQ[3];
            var uriSource = new Uri(@"IconPoisoned.png", UriKind.RelativeOrAbsolute);
            if (((Foe1.EnemyHP[0] != 0) || (Foe1.EnemyHP[1] != 0) || (Foe1.EnemyHP[2] != 0)) && (HPbar.Value != 0))
            {
                if (Foe1.EnemyHP[0] != 0)
                    if (Foe1.EnemyTurn[0] == 200)
                    {
                        Foe1.EnemyTurn[0] = 0;
                        EnemyAttack = CheckEnemies(out EnemyAttack, 1);
                        enemy = NameEnemies(out enemy, 1);
                        if (EnemyAttack > PlayerDef)
                        {
                            timer5 = new System.Windows.Threading.DispatcherTimer();
                            timer5.Tick += new EventHandler(FoeAttack1_Time_Tick5);
                            timer5.Interval = new TimeSpan(0, 0, 0, 0, 50);
                            timer5.Start();
                            int dmg = EnemyAttack - PlayerDef;
                            EnemyOnAttack(enemy, dmg);
                            // EnemyCursor.Margin = new Thickness(Img6.Margin.Left + Img6.Width / 4, Img6.Margin.Top - 120 * Adoptation.HeightAdBack, 0, 0);
                            if ((Random1.Next(1, 13) == 7) && (Super1.PlayerStatus != 1) && (Foe1.EnemyAppears[0] == "Паук"))
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
                        //Foe1.EnemyTurn[0] = 0;
                        EnemyAttack = CheckEnemies(out EnemyAttack, 1);
                        enemy = NameEnemies(out enemy, 1);
                        Foe1.EnemyTurn[1] = 0;
                        if (EnemyAttack > PlayerDef)
                        {
                            timer6 = new System.Windows.Threading.DispatcherTimer();
                            timer6.Tick += new EventHandler(FoeAttack2_Time_Tick6);
                            timer6.Interval = new TimeSpan(0, 0, 0, 0, 50);
                            timer6.Start();
                            int dmg = EnemyAttack - PlayerDef;
                            EnemyOnAttack(enemy, dmg);
                            // EnemyCursor.Margin = new Thickness(Img7.Margin.Left + Img7.Width / 4, Img7.Margin.Top - 120 * Adoptation.HeightAdBack, 0, 0);
                            if ((Random1.Next(1, 13) == 7) && (Super1.PlayerStatus != 1) && (Foe1.EnemyAppears[1] == "Паук"))
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
                        Foe1.EnemyTurn[2] = 0;
                        EnemyAttack = CheckEnemies(out EnemyAttack, 1);
                        enemy = NameEnemies(out enemy, 1);
                        if (EnemyAttack > PlayerDef)
                        {
                            timer7 = new System.Windows.Threading.DispatcherTimer();
                            timer7.Tick += new EventHandler(FoeAttack3_Time_Tick7);
                            timer7.Interval = new TimeSpan(0, 0, 0, 0, 50);
                            timer7.Start();
                            int dmg = EnemyAttack - PlayerDef;
                            EnemyOnAttack(enemy, dmg);
                            //EnemyCursor.Margin = new Thickness(Img8.Margin.Left + Img8.Width / 4, Img8.Margin.Top - 120 * Adoptation.HeightAdBack, 0, 0);
                            if ((Random1.Next(1, 13) == 7) && (Super1.PlayerStatus != 1) && (Foe1.EnemyAppears[2] == "Паук"))
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
                    //ImgHide(EnemyCursor);
                }
            }
        }

        private void Player_Time_Tick(object sender, EventArgs e)
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
                //ImgHide(EnemyCursor);
                timer2.Stop();
                speed = 1;
            }
            else
            {
                BattleText2.Content = "Не удается сбежать!";
                LabShow(BattleText2);
            }
            timer8 = new System.Windows.Threading.DispatcherTimer();
            timer8.Tick += new EventHandler(Escape_Time_Tick9);
            timer8.Interval = new TimeSpan(0, 0, 0, 0, 25);
            timer8.Start();
            //Med4.Source = new Uri(@"IconEscape1.avi", UriKind.RelativeOrAbsolute);
            //Med3.Source = new Uri(@"Escape2.avi", UriKind.RelativeOrAbsolute);
            //MediaShow(Med4);
            //MediaShow(Med3);
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
                if (HPbar.Value != 0)
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
            //if (Super1.CurrentLevel >= 2)
            ButtonShow(Abilities);
            //else
            // {
            // Abilities.Visibility = Visibility.Visible;
            // }
            ButtonShow(Items);
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
            ImgHide(TrgtImg);
            ImgHide(EnemyImg);
            UInt16 strength = Convert.ToUInt16(Super1.Attack + Super1.PlayerEQ[0]);
            UInt16[] x = { 34, 360, 712 };
            UInt16[] y = { 644, 492, 675 };
            Byte PharaohAura = 0;
            //MediaHide(Trgt);
            LabHide(BattleText1);
            SelectedTrgt = Sets.SelectedTarget;
            timer10 = new System.Windows.Threading.DispatcherTimer();
            timer10.Tick += new EventHandler(DamageFoe_Time_Tick17);
            timer10.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer10.Start();
            //BattleText1.Margin = new Thickness(473 * Adoptation.WidthAdBack, 45 * Adoptation.HeightAdBack, 0, 0);
            //BattleText1.FontSize = 48*Adoptation.WidthAdBack;
            if (Sets.BossPharaoh)
            {
                PharaohAura = 25;
            }
            //BattleText1.Content = Foe1.EnemyAppears[Sets.SelectedTarget] + " получает " + (strength - PharaohAura) + " урона!";
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
                // ImgHide(EnemyCursor);
                BattleText2.Content = Foe1.EnemyAppears[Sets.SelectedTarget] + " погибает!";
                LabShow(BattleText2);
                string res = "";
                res = EnemySounds(Sets.SelectedTarget);
                SEF(new Uri(@"" + res + ".mp3", UriKind.RelativeOrAbsolute));
            }
            string spdr = "Паук";
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
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Паук")
                {
                    Sets.SpiderAlive--;
                    CheckFoeCounts(0, (spdr + ": " + Sets.SpiderAlive));
                    if (Sets.SpiderAlive == 0)
                    {
                        LabShow(BattleText3);
                        CheckFoeCounts(0, "");
                      //  EnemyNamesFight[0]=0;
                        Foe1.EnemyAppears[Sets.SelectedTarget] = "";
                    }
                }
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Мумия")
                {
                    Sets.MummyAlive--;
                    CheckFoeCounts(1, (mum + ": " + Sets.MummyAlive));
                    if (Sets.MummyAlive == 0)
                    {
                        CheckFoeCounts(1, "");
                      //  EnemyNamesFight[1] = 0;
                        LabShow(BattleText4);
                        Foe1.EnemyAppears[Sets.SelectedTarget] = "";
                    }
                }
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Зомби")
                {
                    Sets.ZombieAlive--;
                    CheckFoeCounts(2, (zomb + ": " + Sets.ZombieAlive));
                    if (Sets.ZombieAlive == 0)
                    {
                        LabShow(BattleText5);
                        CheckFoeCounts(2, "");
                      //  EnemyNamesFight[2] = 0;
                        Foe1.EnemyAppears[Sets.SelectedTarget] = "";
                    }
                }
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Страж")
                {
                    Sets.BonesAlive--;
                    CheckFoeCounts(3, (defd + ": " + Sets.BonesAlive));
                    if (Sets.BonesAlive == 0)
                    {
                        LabShow(BattleText6);
                        CheckFoeCounts(3, "");
                      //  EnemyNamesFight[3] = 0;
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
                //Trgt.Margin = new Thickness(x[Sets.SelectedTarget]*Adoptation.WidthAdBack, y[Sets.SelectedTarget] * Adoptation.HeightAdBack, 0, 0);
                Byte[] grRow = new Byte[] { 23, 15, 21 };
                Byte[] grColumn = new Byte[] { 2, 13, 24 };
                Grid.SetRow(TrgtImg, grRow[Sets.SelectedTarget]);
                Grid.SetColumn(TrgtImg, grColumn[Sets.SelectedTarget]);
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
            timer8 = new System.Windows.Threading.DispatcherTimer();
            timer8.Tick += new EventHandler(HandAttack_Time_Tick8);
            timer8.Interval = new TimeSpan(0, 0, 0, 0, 25);
            timer8.Start();
            //Med3.Source = new Uri(@"HandAttack3.avi", UriKind.RelativeOrAbsolute);
            //MediaShow(Med3);
            Dj(new Uri(@"Punch.mp3", UriKind.RelativeOrAbsolute));
            //Med4.Source = new Uri(@"IconRage1.avi", UriKind.RelativeOrAbsolute);
            //MediaShow(Med4);
        }

        public static Byte Actions = 0;
        private void HandAttack_Time_Tick8(object sender, EventArgs e)
        {
            string[] HndAt = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack10.png" };
            string[] IcoRg = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage10.png" };
            ActionsTickCheck(HndAt, IcoRg);
        }

        private void Escape_Time_Tick9(object sender, EventArgs e)
        {
            string[] Flee = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape2.png" };
            string[] IcoEs = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape2.png" };
            ActionsTickCheck(Flee, IcoEs);
        }

        private void Items_Time_Tick10(object sender, EventArgs e)
        {
            string[] ItmUs = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed1.png" };
            string[] IcoUs = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed10.png" };
            ActionsTickCheck(ItmUs, IcoUs);
        }

        private void Cure_Time_Tick11(object sender, EventArgs e)
        {
            string[] Cure = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure10.png" };
            string[] IcoCr = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure10.png" };
            ActionsTickCheck(Cure, IcoCr);
        }

        private void Heal_Time_Tick12(object sender, EventArgs e)
        {
            string[] Heal = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal10.png" };
            string[] IcoHl = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon10.png" };
            ActionsTickCheck(Heal, IcoHl);
        }

        private void Torch_Time_Tick13(object sender, EventArgs e)
        {
            string[] Torch = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch10.png" };
            string[] IcoTh = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch10.png" };
            ActionsTickCheck(Torch, IcoTh);
        }
        private void Whip_Time_Tick14(object sender, EventArgs e)
        {
            string[] Whip = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip10.png" };
            string[] IcoWp = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon10.png" };
            ActionsTickCheck(Whip, IcoWp);
        }

        private void Super_Time_Tick15(object sender, EventArgs e)
        {
            string[] Super = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super5.png" };
            string[] IcoSr = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon4.png" };
            ActionsTickCheck(Super, IcoSr);
        }

        private void Target_Time_Tick16(object sender, EventArgs e)
        {
            string[] Trgt = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Target\\Target1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Target\\Target2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Target\\Target3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Target\\Target2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Target\\Target1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Target\\Target2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Target\\Target3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Target\\Target2.png" };
            UnlimitedActionsTickCheck(Trgt);
        }

        public static UInt16 FoeDamage = 0;

        private void DamageFoe_Time_Tick17(object sender, EventArgs e)
        {
            UInt16 strength = Convert.ToUInt16(Super1.Attack + Super1.PlayerEQ[0]);
            Label[] Labs = new Label[] { DamageFoe, DamageFoe2, DamageFoe3 };
            Labs[SelectedTrgt].Content = Convert.ToUInt16(strength);
            FoesKicked();
        }

        private void CureHP_Time_Tick18(object sender, EventArgs e)
        {
            UInt16 curepower = Convert.ToUInt16(Super1.Special * 2);
            CureHealTxt.Content = "+" + curepower;
            CureOrHeal();
        }
        private void HealPsn_Time_Tick19(object sender, EventArgs e)
        {
            CureHealTxt.Content = "-Яд";
            CureOrHeal();
        }
        private void TorchDmg_Time_Tick20(object sender, EventArgs e)
        {
            UInt16 trchsp = Convert.ToUInt16(Super1.Special);
            if ((Foe1.EnemyAppears[SelectedTrgt] == "Паук") || (Foe1.EnemyAppears[SelectedTrgt] == "Мумия"))
            {
                trchsp = Convert.ToUInt16(trchsp * 2.5);
            }
            else
            {
                if (Foe1.EnemyAppears[SelectedTrgt] == "Фараон")
                    trchsp = Convert.ToUInt16(trchsp * 0.5);
                else
                    trchsp = Convert.ToUInt16(trchsp * 1.25);
            }
            Label[] Labs = new Label[] { DamageFoe, DamageFoe2, DamageFoe3 };
            Labs[SelectedTrgt].Content = Convert.ToUInt16(trchsp);
            FoesKicked();
        }

        private void WhipDmg_Time_Tick21(object sender, EventArgs e)
        {
            UInt16 whipsp = Convert.ToUInt16(Super1.Special);
            if ((Foe1.EnemyAppears[Sets.SelectedTarget] == "Зомби") || (Foe1.EnemyAppears[Sets.SelectedTarget] == "Страж"))
            {
                whipsp = Convert.ToUInt16(whipsp * 3);
            }
            else
            {
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Фараон")
                    whipsp = Convert.ToUInt16(whipsp * 0.75);
                else
                    whipsp = Convert.ToUInt16(whipsp * 1.5);
            }
            Label[] Labs = new Label[] { DamageFoe, DamageFoe2, DamageFoe3 };
            Labs[SelectedTrgt].Content = Convert.ToUInt16(whipsp);
            FoesKicked();
        }

        private void SuperDmg_Time_Tick22(object sender, EventArgs e)
        {
            UInt16 supersp = Convert.ToUInt16(Super1.Special);
            if (Foe1.EnemyAppears[0] != "Фараон")
                supersp *= 2;
            Label[] Labs = new Label[] { DamageFoe, DamageFoe2, DamageFoe3 };
            if (Foe1.EnemyHP[0] != 0)
                Labs[0].Content = Convert.ToUInt16(supersp);
            if (Foe1.EnemyHP[1] != 0)
                Labs[1].Content = Convert.ToUInt16(supersp);
            if (Foe1.EnemyHP[2] != 0)
                Labs[2].Content = Convert.ToUInt16(supersp);
            FoesKicked();
        }
        private void Bandage_Time_Tick23(object sender, EventArgs e)
        {
            CureHealTxt.Content = "+50";
            CureOrHeal();
        }

        private void Ether_Time_Tick24(object sender, EventArgs e)
        {
            RecoverAPTxt.Content = "+50";
            RestoreAP();
        }

        private void Fused_Time_Tick25(object sender, EventArgs e)
        {
            CureHealTxt.Content = "+80";
            RecoverAPTxt.Content = "+80";
            CureOrHeal();
            RestoreAP();
        }

        private void Antidote_Time_Tick26(object sender, EventArgs e)
        {
            CureHealTxt.Content = "-Яд";
            CureOrHeal();
        }

        public static Byte CureCurrent = 0;
        public static Byte RAPCurrent = 0;
        private void CureOrHeal()
        {
            Byte[] RowSet2 = { 22, 21, 20, 19, 18 };
            if (!CureHealTxt.IsEnabled)
                LabShow(CureHealTxt);
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
            if (!RecoverAPTxt.IsEnabled)
                LabShow(RecoverAPTxt);
            if (RAPCurrent == RowSet2.Length - 1)
            {
                RAPCurrent = 0;
                timer11.Stop();
                LabHide(RecoverAPTxt);
            }
            else
            {
                Grid.SetRow(RecoverAPTxt, RowSet2[RAPCurrent]);
                RAPCurrent++;
            }
        }

        private void FoesKicked()
        {
            Byte[,] RowSet2 = new Byte[,] { { 26, 25, 26, 25, 26 }, { 18, 17, 18, 17, 18 }, { 24, 23, 24, 23, 24 } };
            Byte[,] ColumnSet2 = new Byte[,] { { 4, 3, 2, 1, 0 }, { 15, 14, 13, 12, 11 }, { 26, 25, 24, 23, 22 } };
            Label[] Labs = new Label[] { DamageFoe, DamageFoe2, DamageFoe3 };
            if (SelectedTrgt != 4)
            {
                if (!Labs[SelectedTrgt].IsEnabled)
                    LabShow(Labs[SelectedTrgt]);
                if (FoeDamage == ColumnSet2.GetLength(1) - 1)
                {
                    FoeDamage = 0;
                    timer10.Stop();
                    LabHide(Labs[SelectedTrgt]);
                }
                else
                {
                    Grid.SetRow(Labs[SelectedTrgt], RowSet2[SelectedTrgt, FoeDamage]);
                    Grid.SetColumn(Labs[SelectedTrgt], ColumnSet2[SelectedTrgt, FoeDamage]);
                    FoeDamage++;
                }
            }
            else
            {
                if ((!Labs[0].IsEnabled) && (Foe1.EnemyHP[0] != 0))
                    LabShow(Labs[0]);
                if ((!Labs[1].IsEnabled) && (Foe1.EnemyHP[1] != 0))
                    LabShow(Labs[1]);
                if ((!Labs[2].IsEnabled) && (Foe1.EnemyHP[1] != 0))
                    LabShow(Labs[2]);
                if (FoeDamage == ColumnSet2.GetLength(1) - 1)
                {
                    FoeDamage = 0;
                    timer10.Stop();
                    LabHide(Labs[0]);
                    LabHide(Labs[1]);
                    LabHide(Labs[2]);
                }
                else
                {
                    if (Foe1.EnemyHP[0] != 0)
                    {
                        Grid.SetRow(Labs[0], RowSet2[0, FoeDamage]);
                        Grid.SetColumn(Labs[0], ColumnSet2[0, FoeDamage]);
                    }
                    if (Foe1.EnemyHP[1] != 0)
                    {
                        Grid.SetRow(Labs[1], RowSet2[1, FoeDamage]);
                        Grid.SetColumn(Labs[1], ColumnSet2[1, FoeDamage]);
                    }
                    if (Foe1.EnemyHP[2] != 0)
                    {
                        Grid.SetRow(Labs[2], RowSet2[2, FoeDamage]);
                        Grid.SetColumn(Labs[2], ColumnSet2[2, FoeDamage]);
                    }
                    FoeDamage++;
                }
            }
        }
        private void IconActions(Image icon, in string[] ico)
        {
            icon.Source = new BitmapImage(new Uri(ico[Actions], UriKind.RelativeOrAbsolute));
            if (Actions == ico.Length - 1)
            {
                Actions = 0;
                icon.Source = new BitmapImage(new Uri("/person6.png", UriKind.RelativeOrAbsolute));
                //AfterAction();
                timer2.Stop();
            }
            else
            {
                Actions++;
            }
        }
        private void ActionsTickCheck(in string[] pers, in string[] ico)
        {
            Img4.Source = new BitmapImage(new Uri(pers[Actions], UriKind.RelativeOrAbsolute));
            Img5.Source = new BitmapImage(new Uri(ico[Actions], UriKind.RelativeOrAbsolute));
            if (Actions == pers.Length - 1)
            {
                Actions = 0;
                Img4.Source = new BitmapImage(new Uri("/pers5.png", UriKind.RelativeOrAbsolute));
                Img5.Source = new BitmapImage(new Uri("/person6.png", UriKind.RelativeOrAbsolute));
                AfterAction();
                timer8.Stop();
            }
            else
            {
                Actions++;
            }
        }
        public static Byte trgt = 0;
        private void UnlimitedActionsTickCheck(in string[] spec)
        {
            TrgtImg.Source = new BitmapImage(new Uri(spec[trgt], UriKind.RelativeOrAbsolute));
            if (trgt == spec.Length - 1)
            {
                trgt = 0;
            }
            else
            {
                trgt++;
            }
        }

        private void Cancel1_Click(object sender, RoutedEventArgs e)
        {
            timer9.Stop();
            ButtonHide(Fight);
            ButtonHide(Cancel1);
            FightMenuBack();
            LabHide(HPenemy);
            BarHide(HPenemyBar);
            LabHide(BattleText1);
            ImgHide(EnemyImg);
            //MediaHide(Trgt);
            ImgHide(TrgtImg);
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

        private void HideAfterBattleMenu()
        {
            ButtonHide(TextOk1);
            Label[] ANLabs = new Label[] { NewLevelGet, AfterParams, AfterHPtxt, AfterAPtxt, AfterHP, AfterAP, AfterAttack, AfterDefence, AfterAgility, AfterSpecial, AfterATK, AfterDEF, AfterAG, AfterSP, AddHP, AddAP, AddATK, AddDEF, AddAG, AddSP };
            Label[] AFLabs = new Label[] { ExpText, AfterLevel, AfterName, AfterStatus, BeforeParams, BeforeHPtxt, BeforeAPtxt, BeforeHP, BeforeAP, BeforeAttack, BeforeDefence, BeforeAgility, BeforeSpecial, BeforeATK, BeforeDEF, BeforeAG, BeforeSP, AfterBattleGet, MaterialsGet, MaterialsOnHand, MaterialsAdd, ItemsGet, ItemsGetSlot1 };
            Image[] ANImgs = new Image[] { AfterAttackImg, AfterDefenceImg, AfterAgilityImg, AfterSpecialImg };
            Image[] AFImgs = new Image[] { AfterBattleMenuImg, AfterIcon, BeforeAttackImg, BeforeDefenceImg, BeforeAgilityImg, BeforeSpecialImg, MaterialsGetImg };
            ProgressBar[] ANBars = new ProgressBar[] { AfterHPbar, AfterAPbar };
            ProgressBar[] AFBars = new ProgressBar[] { NextExpBar, BeforeHPbar, BeforeAPbar };
            for (Byte i = 0; i < AFLabs.Length; i++)
            {
                LabHide(AFLabs[i]);
            }
            for (Byte i = 0; i < AFImgs.Length; i++)
            {
                ImgHide(AFImgs[i]);
            }
            for (Byte i = 0; i < AFBars.Length; i++)
            {
                BarHide(AFBars[i]);
            }
            for (Byte i = 0; i < ANLabs.Length; i++)
            {
                LabHide(ANLabs[i]);
            }
            for (Byte i = 0; i < ANImgs.Length; i++)
            {
                ImgHide(ANImgs[i]);
            }
            for (Byte i = 0; i < ANBars.Length; i++)
            {
                BarHide(ANBars[i]);
            }
        }

        private void TextOk1_Click(object sender, RoutedEventArgs e)
        {
            HideAfterBattleMenu();
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
                Img1.Source = new BitmapImage(new Uri(@"AbsoluteBlack.jpg", UriKind.RelativeOrAbsolute));
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
            ImgHide(TimeTurnImg);
            LabHide(HPtext);
            LabHide(APtext);
            //LabHide(HeroName);
            LabHide(LevelText);
            LabHide(ExpText);
            //TimeImg
            // LabHide(TimeText);
            LabHide(HP);
            LabHide(AP);
            LabHide(ATK);
            LabHide(SP);
            //ImgHide(EnemyCursor);
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
            Sound1.Position = new TimeSpan(0, 0, 0, 0, 0);
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
            ButtonHide(SwitchAbils);
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
            timer8 = new System.Windows.Threading.DispatcherTimer();
            timer8.Tick += new EventHandler(Cure_Time_Tick11);
            timer8.Interval = new TimeSpan(0, 0, 0, 0, 25);
            timer8.Start();
            timer11 = new System.Windows.Threading.DispatcherTimer();
            timer11.Tick += new EventHandler(CureHP_Time_Tick18);
            timer11.Interval = new TimeSpan(0, 0, 0, 0, 75);
            timer11.Start();
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
            //if (Super1.CurrentLevel >= 3)
            // {
            /* Torch.Visibility = Visibility.Visible;
             if (APbar.Value >= 4)
                 Torch.IsEnabled = true;*/
            // }
            //   if (Super1.CurrentLevel >= 4)
            // {
            Heal.Visibility = Visibility.Visible;
            if (APbar.Value >= 1)
                Heal.IsEnabled = true;
            ButtonShow(SwitchAbils);
            SwitchAbils.Content = "=====>";
            //  }
            //  if (Super1.CurrentLevel >= 6)
            //  {
            /* Whip.Visibility = Visibility.Visible;
             if (APbar.Value >= 6)
                 Whip.IsEnabled = true;*/
            // }
            // if (Super1.CurrentLevel >= 7)
            // {
            /* Super.Visibility = Visibility.Visible;
             if (APbar.Value >= 10)
                 Super.IsEnabled = true;*/
            // }
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

        private void LevelUpShow()
        {
            Label[] ANLabs = new Label[] { NewLevelGet, AfterParams, AfterHPtxt, AfterAPtxt, AfterHP, AfterAP, AfterAttack, AfterDefence, AfterAgility, AfterSpecial, AfterATK, AfterDEF, AfterAG, AfterSP, AddHP, AddAP, AddATK, AddDEF, AddAG, AddSP };
            Image[] ANImgs = new Image[] { AfterAttackImg, AfterDefenceImg, AfterAgilityImg, AfterSpecialImg };
            ProgressBar[] ANBars = new ProgressBar[] { AfterHPbar, AfterAPbar };
            for (Byte i = 0; i < ANLabs.Length; i++)
            {
                LabShow(ANLabs[i]);
            }
            for (Byte i = 0; i < ANImgs.Length; i++)
            {
                ImgShow(ANImgs[i]);
            }
            for (Byte i = 0; i < ANBars.Length; i++)
            {
                BarShow(ANBars[i]);
            }
        }
        private void AddingStats_Time_Tick41(object sender, EventArgs e)
        {
            if ((CurrentNextHPAP[0] < Super1.MaxHP) || (CurrentNextHPAP[1] < Super1.MaxAP) || (CurrentNextParams[0] < Super1.Attack) || (CurrentNextParams[1] < Super1.Defence) || (CurrentNextParams[2] < Super1.Speed) || (CurrentNextParams[3] < Super1.Special))
            {
                if (CurrentNextHPAP[0] < Super1.MaxHP)
                {
                    CurrentNextHPAP[0]++;
                    AddHP.Content = "+" + (Super1.MaxHP - CurrentNextHPAP[0]);
                    AfterHP.Content = HPbar.Value + "/" + CurrentNextHPAP[0];
                    HPbar.Width = CurrentNextHPAP[0];
                    AfterHPbar.Width = CurrentNextHPAP[0];
                    HPbar.Maximum = CurrentNextHPAP[0];
                    AfterHPbar.Maximum = CurrentNextHPAP[0];
                }
                else
                {
                    LabHide(AddHP);
                }

                if (CurrentNextHPAP[1] < Super1.MaxAP)
                {
                    CurrentNextHPAP[1]++;
                    AddAP.Content = "+" + (Super1.MaxAP - CurrentNextHPAP[1]);
                    AfterAP.Content = APbar.Value + "/" + CurrentNextHPAP[1];
                    APbar.Width = CurrentNextHPAP[1];
                    AfterAPbar.Width = CurrentNextHPAP[1];
                    APbar.Maximum = CurrentNextHPAP[1];
                    AfterAPbar.Maximum = CurrentNextHPAP[1];
                }
                else
                {
                    LabHide(AddAP);
                }

                if (CurrentNextParams[0] < Super1.Attack)
                {
                    CurrentNextParams[0]++;
                    AddATK.Content = "+" + (Super1.Attack - CurrentNextParams[0]);
                    AfterATK.Content = CurrentNextParams[0];
                }
                else
                {
                    LabHide(AddATK);
                }

                if (CurrentNextParams[1] < Super1.Defence)
                {
                    CurrentNextParams[1]++;
                    AddDEF.Content = "+" + (Super1.Defence - CurrentNextParams[1]);
                    AfterDEF.Content = CurrentNextParams[1];
                }
                else
                {
                    LabHide(AddDEF);
                }

                if (CurrentNextParams[2] < Super1.Speed)
                {
                    CurrentNextParams[2]++;
                    AddAG.Content = "+" + (Super1.Speed - CurrentNextParams[2]);
                    AfterAG.Content = CurrentNextParams[2];
                }
                else
                {
                    LabHide(AddAG);
                }

                if (CurrentNextParams[3] < Super1.Special)
                {
                    CurrentNextParams[3]++;
                    AddSP.Content = "+" + (Super1.Special - CurrentNextParams[3]);
                    AfterSP.Content = CurrentNextParams[3];
                }
                else
                {
                    LabHide(AddSP);
                }
            }
            else
            {
                timer13.Stop();
                LabHide(AddHP);
                LabHide(AddAP);
                LabHide(AddATK);
                LabHide(AddDEF);
                LabHide(AddAG);
                LabHide(AddSP);
                ButtonShow(TextOk1);
            }
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
                LabHide(MaterialsAdd);
                timer.Stop();
            }
        }
        private void Levelling_Time_Tick40(object sender, EventArgs e)
        {
            if ((Exp > 0) && (Super1.CurrentLevel < 10)) {
                if (NextExpBar.Value + 1 >= NextExpBar.Maximum)
                {
                    if (Super1.CurrentLevel < 10) {
                        Super1.CurrentLevel += 1;
                        Super1.Attack = Super1.AttackNxt[Super1.CurrentLevel - 1];
                        Super1.Defence = Super1.DefenseNxt[Super1.CurrentLevel - 1];
                        Super1.Speed = Super1.SpeedNxt[Super1.CurrentLevel - 1];
                        Super1.Special = Super1.SpecialNxt[Super1.CurrentLevel - 1];
                        Super1.MaxHP = Super1.MaxHPNxt[Super1.CurrentLevel - 1];
                        Super1.MaxAP = Super1.MaxAPNxt[Super1.CurrentLevel - 1];

                        NextExpBar.Maximum = Super1.NextLevel[Super1.CurrentLevel - 1];
                        NextExpBar.Value = 0;
                        ExpText.Content = "Опыт " + NextExpBar.Value + "/" + NextExpBar.Maximum;
                        AfterLevel.Content = "Уровень " + Super1.CurrentLevel;
                        /*CurrentNextParams[0] = Super1.Attack;
                        CurrentNextParams[1] = Super1.Defence;
                        CurrentNextParams[2] = Super1.Speed;
                        CurrentNextParams[3] = Super1.Special;
                        CurrentNextHPAP[0] = Super1.MaxHP;
                        CurrentNextHPAP[1] = Super1.MaxAP;*/
                        AddHP.Content = "+" + (Super1.MaxHP - CurrentNextHPAP[0]);
                        AddAP.Content = "+" + (Super1.MaxAP - CurrentNextHPAP[1]);
                        AddATK.Content = "+" + (Super1.Attack - CurrentNextParams[0]);
                        AddDEF.Content = "+" + (Super1.Defence - CurrentNextParams[1]);
                        AddAG.Content = "+" + (Super1.Speed - CurrentNextParams[2]);
                        AddSP.Content = "+" + (Super1.Special - CurrentNextParams[3]);
                        if (!NewLevelGet.IsEnabled)
                            LevelUpShow();
                        if (LevelUpCount > 1)
                        {
                            NewLevelGet.Content = "Новый уровень! " + "X" + LevelUpCount;
                        }
                        else
                        {
                            NewLevelGet.Content = "Новый уровень!";
                        }
                        LevelUpCount += 1;
                        Dj(new Uri("D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp.mp3", UriKind.RelativeOrAbsolute));
                        timer2 = new System.Windows.Threading.DispatcherTimer();
                        timer2.Tick += new EventHandler(LevelingUPImage_Time_Tick44);
                        timer2.Interval = new TimeSpan(0, 0, 0, 0, 25);
                        timer2.Start();
                    } else
                    {
                        NextExpBar.Value = NextExpBar.Maximum;
                        //                "Максимальный"
                        ExpText.Content = "Профессионал";
                        Exp = 0;
                        if (!NewLevelGet.IsEnabled)
                        {
                            timer12.Stop();
                            ButtonShow(TextOk1);
                        }
                        else
                        {
                            timer12.Stop();
                            timer13 = new System.Windows.Threading.DispatcherTimer();
                            timer13.Tick += new EventHandler(AddingStats_Time_Tick41);
                            timer13.Interval = new TimeSpan(0, 0, 0, 0, 25);
                            timer13.Start();
                        }
                    }
                }
                else
                {
                    NextExpBar.Value++;
                    ExpText.Content = "Опыт " + NextExpBar.Value + "/" + NextExpBar.Maximum;
                    //ex = Convert.ToInt32(Exp - NextExpBar.Maximum);
                }
                Exp--;
            }
            else
            {
                if (!NewLevelGet.IsEnabled)
                {
                    timer12.Stop();
                    ButtonShow(TextOk1);
                }
                else
                {
                    timer12.Stop();
                    timer13 = new System.Windows.Threading.DispatcherTimer();
                    timer13.Tick += new EventHandler(AddingStats_Time_Tick41);
                    timer13.Interval = new TimeSpan(0, 0, 0, 0, 25);
                    timer13.Start();
                }
            }
            //int ex = Exp;

            //ex = Convert.ToInt32(NextExpBar.Value + Exp - NextExpBar.Maximum);

        }

        public static Byte LevelUpCount = 1;
        public static Byte[] CurrentNextParams = new Byte[] { 25, 15, 15, 25 };
        public static UInt16[] CurrentNextHPAP = new UInt16[] { 100, 40 };

        private void LevelingUPImage_Time_Tick44(object sender, EventArgs e) {
            string[] ico = { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon9.png" };
            Image icon = AfterIcon;
            IconActions(icon, ico);
        }
        private void textOk2_Click(object sender, RoutedEventArgs e)
        {
            LevelUpCount = 1;
            CurrentNextParams[0] = Super1.Attack;
            CurrentNextParams[1] = Super1.Defence;
            CurrentNextParams[2] = Super1.Speed;
            CurrentNextParams[3] = Super1.Special;
            CurrentNextHPAP[0] = Super1.MaxHP;
            CurrentNextHPAP[1] = Super1.MaxAP;

            BeforeATK.Content=CurrentNextParams[0];
            BeforeDEF.Content = CurrentNextParams[1];
            BeforeAG.Content = CurrentNextParams[2];
            BeforeSP.Content = CurrentNextParams[3];
            BeforeHP.Content = HPbar.Value+"/"+CurrentNextHPAP[0];
            BeforeAP.Content = APbar.Value + "/" + CurrentNextHPAP[1];

            AfterATK.Content = CurrentNextParams[0];
            AfterDEF.Content = CurrentNextParams[1];
            AfterAG.Content = CurrentNextParams[2];
            AfterSP.Content = CurrentNextParams[3];
            AfterHP.Content = HPbar.Value + "/" + CurrentNextHPAP[0];
            AfterAP.Content = APbar.Value + "/" + CurrentNextHPAP[1];
            HPbar.Width = CurrentNextHPAP[0];
            BeforeHPbar.Width = CurrentNextHPAP[0];
            AfterHPbar.Width = CurrentNextHPAP[0];

            APbar.Width = CurrentNextHPAP[1];
            BeforeAPbar.Width = CurrentNextHPAP[1];
            AfterAPbar.Width = CurrentNextHPAP[1];

            HPbar.Maximum = CurrentNextHPAP[0];
            BeforeHPbar.Maximum = CurrentNextHPAP[0];
            AfterHPbar.Maximum = CurrentNextHPAP[0];

            APbar.Maximum = CurrentNextHPAP[1];
            BeforeAPbar.Maximum = CurrentNextHPAP[1];
            AfterAPbar.Maximum = CurrentNextHPAP[1];

            BeforeHPbar.Value = HPbar.Value;
            AfterHPbar.Value = HPbar.Value;

            BeforeAPbar.Value = APbar.Value;
            AfterAPbar.Value = APbar.Value;
            
            MaterialsOnHand.Content = BAG.Materials;
            MaterialsAdd.Content = "+"+Mat;
            //HPbar.Value = HPbar.Maximum;
            //APbar.Value = APbar.Maximum;
            AfterLevel.Content = "Уровень " +Super1.CurrentLevel;
            LabHide(BattleText1);
            ItemsGetSlot1.Content = "";
            //HP.Margin = new Thickness(HPbar.Margin.Left + HPbar.Width- 1 / Adoptation.WidthAdBack, 38 * Adoptation.HeightAdBack, 0, 0);
            Label[] ANLabs = new Label[] { NewLevelGet, AfterParams, AfterHPtxt, AfterAPtxt, AfterHP, AfterAP, AfterAttack, AfterDefence, AfterAgility, AfterSpecial, AfterATK, AfterDEF, AfterAG, AfterSP, AddHP, AddAP, AddATK, AddDEF, AddAG, AddSP };
            Label[] AFLabs = new Label[] { ExpText, AfterLevel, AfterName, AfterStatus, BeforeParams, BeforeHPtxt, BeforeAPtxt, BeforeHP, BeforeAP, BeforeAttack, BeforeDefence, BeforeAgility, BeforeSpecial, BeforeATK, BeforeDEF, BeforeAG, BeforeSP, AfterBattleGet, MaterialsGet, MaterialsOnHand, MaterialsAdd, ItemsGet, ItemsGetSlot1 };
            Image[] ANImgs = new Image[] { AfterAttackImg, AfterDefenceImg, AfterAgilityImg, AfterSpecialImg };
            Image[] AFImgs = new Image[] { AfterBattleMenuImg, AfterIcon, BeforeAttackImg, BeforeDefenceImg, BeforeAgilityImg, BeforeSpecialImg, MaterialsGetImg };
            ProgressBar[] ANBars = new ProgressBar[] { AfterHPbar, AfterAPbar };
            ProgressBar[] AFBars = new ProgressBar[] { NextExpBar, BeforeHPbar, BeforeAPbar };
            for (Byte i=0; i<AFLabs.Length; i++)
            {
                LabShow(AFLabs[i]);
            }
            for (Byte i = 0; i < AFImgs.Length; i++)
            {
                ImgShow(AFImgs[i]);
            }
            for (Byte i = 0; i < AFBars.Length; i++)
            {
                BarShow(AFBars[i]);
            }
            timer12 = new System.Windows.Threading.DispatcherTimer();
            timer12.Tick += new EventHandler(Levelling_Time_Tick40);
            timer12.Interval = new TimeSpan(0, 0, 0, 0, 25);
            timer12.Start();
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(AddingMaterials_Time_Tick42);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 25);
            timer.Start();
            HP.Content = HPbar.Value + "/" + HPbar.Maximum;
            //AP.Margin = new Thickness(APbar.Margin.Left + APbar.Width- 1 / Adoptation.WidthAdBack, 87 * Adoptation.HeightAdBack, 0, 0);
            AP.Content = APbar.Value + "/" + APbar.Maximum;
            /*if (Super1.CurrentLevel < 10)
                ExpText.Content = "Опыт " + Convert.ToString(ex) + "/" + Super1.NextLevel[Super1.CurrentLevel - 1];
            else
            {
                ExpText.Content = "Максимальный";
                NextExpBar.Value = NextExpBar.Maximum;
            }*/
            //ImgHide(Img5);
            //Med4.Source = new Uri(@"LevelUP.mp4", UriKind.RelativeOrAbsolute);
            //MediaShow(Med4);
            ButtonHide(textOk2);
            //BattleText2.Content = "Рэй получает уровень " + Super1.CurrentLevel + "!";
            //BattleText1.Margin = new Thickness(473*Adoptation.WidthAdBack, 15 * Adoptation.HeightAdBack, 0, 0);
            //BattleText1.FontSize = 60 * Adoptation.WidthAdBack;
            //BattleText1.Content = "Новый\nуровень!";
            /*switch (Super1.CurrentLevel)
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
            Super1.Special = Super1.SpecialNxt[Super1.CurrentLevel - 1];*/
            //ATK.Content = "ОЗ +" + (Super1.MaxHP - Super1.MaxHPNxt[Super1.CurrentLevel - 2]) + "\n" + "АТК +" + (Super1.Attack - Super1.AttackNxt[Super1.CurrentLevel - 2]) + "\n" + "ЗЩТ +" + (Super1.Defence - Super1.DefenseNxt[Super1.CurrentLevel - 2]);
            //ATK.Margin = new Thickness(873*Adoptation.WidthAdBack, 20 * Adoptation.HeightAdBack, 0, 0);
            //LabShow(ATK);
            //SP.Content = "ОД +" + (Super1.MaxAP - Super1.MaxAPNxt[Super1.CurrentLevel - 2]) + "\n" + "СК. +" + (Super1.Speed - Super1.SpeedNxt[Super1.CurrentLevel - 2]) + "\n" + "СП. +" + (Super1.Special - Super1.SpecialNxt[Super1.CurrentLevel - 2]);
            //SP.Margin = new Thickness(1073 * Adoptation.WidthAdBack, 20 * Adoptation.HeightAdBack, 0, 0);
            //LabShow(SP);
            //ButtonShow(TextOk1);
            //SEF(new Uri(@"LevelUp.mp3", UriKind.RelativeOrAbsolute));
            // Exp = 0;
            ItemsGetSlot1.Content = "";
            timer2.Stop();
            Byte item = 0;
            if (Sets.ItemsDropRate[0] != 0)
            {
                while (Sets.ItemsDropRate[0] != 0)
                {
                    Byte rndItem = (Byte)Random1.Next(0, 8);
                    if (rndItem == 4)
                    {
                        item++;
                    }
                    Sets.ItemsDropRate[0]--;
                }
            }
            if (item>0)
            {
                ItemsGetSlot1.Content += "Антидот: "+item+"\n";
                if (BAG.AntidoteITM+item<255)
                    BAG.AntidoteITM += item;
                else
                    BAG.AntidoteITM = 255;
                item = 0;
            }
            if (Sets.ItemsDropRate[1] != 0)
            {
                while (Sets.ItemsDropRate[1] != 0)
                {
                    Byte rndItem = (Byte)Random1.Next(0, 8);
                    if (rndItem == 4)
                    {
                        item++;
                    }
                    Sets.ItemsDropRate[1]--;
                }
            }
            if (item > 0)
            {
                ItemsGetSlot1.Content += "Бинт: " + item + "\n";
                if (BAG.BandageITM+item < 255)
                    BAG.BandageITM += item;
                else
                    BAG.EtherITM = 255;
                item = 0;
            }
            if (Sets.ItemsDropRate[2] != 0)
            {
                while (Sets.ItemsDropRate[2] != 0)
                {
                    Byte rndItem = (Byte)Random1.Next(0, 8);
                    if (rndItem == 4)
                    {
                        item++;
                    }
                    Sets.ItemsDropRate[2]--;
                }
            }
            if (item > 0)
            {
                ItemsGetSlot1.Content += "Эфир: " + item + "\n";
                if (BAG.EtherITM+ item < 255)
                    BAG.EtherITM += item;
                else
                    BAG.EtherITM = 255;
                item = 0;
            }
            if (Sets.ItemsDropRate[3] != 0)
            {
                while (Sets.ItemsDropRate[3] != 0)
                {
                    Byte rndItem = (Byte)Random1.Next(0, 8);
                    if (rndItem == 4)
                    {
                        item++;
                    }
                    Sets.ItemsDropRate[3]--;
                }
            }
            if (item > 0)
            {
                ItemsGetSlot1.Content += "Смесь: " + item + "\n";
                if (BAG.FusedITM + item < 255)
                    BAG.FusedITM += item;
                else
                    BAG.FusedITM = 255;
                item = 0;
            }
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
            //MediaHide(Trgt);
            timer9.Stop();
            BarHide(HPenemyBar);
            LabHide(HPenemy);
            LabHide(BattleText1);
            ImgHide(EnemyImg);
            ButtonHide(Fight);
            ButtonHide(ACT1);
            ButtonHide(ACT2);
            ButtonHide(Cancel2);
            ButtonShow(Back1);
            ImgHide(TrgtImg);
            if (SwitchAbils.Content.ToString() == "=====>")
            {
                ButtonHide(Cure);
                ButtonHide(Heal);
                //if (Super1.CurrentLevel >= 3)
                //  {
                Torch.Visibility = Visibility.Visible;
                if (APbar.Value >= 4)
                    Torch.IsEnabled = true;
                //  }

                // if (Super1.CurrentLevel >= 6)
                // {
                Whip.Visibility = Visibility.Visible;
                if (APbar.Value >= 6)
                    Whip.IsEnabled = true;
                // }

                // if (Super1.CurrentLevel >= 7)
                //{
                Super.Visibility = Visibility.Visible;
                if (APbar.Value >= 10)
                    Super.IsEnabled = true;
                //}
                SwitchAbils.Content = "<=====";
            }
            else if (SwitchAbils.Content.ToString() != "=====>")
            {

                Cure.Visibility = Visibility.Visible;
                if (APbar.Value >= 1)
                    Cure.IsEnabled = true;
                //   if (Super1.CurrentLevel >= 4)
                // {
                Heal.Visibility = Visibility.Visible;
                if (APbar.Value >= 1)
                    Heal.IsEnabled = true;
                ButtonShow(SwitchAbils);
                //  }
                ButtonHide(Torch);
                ButtonHide(Whip);
                ButtonHide(Super);
                SwitchAbils.Content = "=====>";
            }
            /*if (Super1.CurrentLevel >= 4)
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
            }*/
        }
        private void CheckFoeCounts(in Byte selected, in string foestatus)
        {
            if (EnemyNamesFight[selected]==1)
            {
                BattleText3.Content = foestatus;
                BattleText3.Foreground = Brushes.Red;
            } else if (EnemyNamesFight[selected] == 2)
            {
                BattleText4.Content = foestatus;
                BattleText4.Foreground = Brushes.Red;
            } else if (EnemyNamesFight[selected] == 3)
            {
                BattleText5.Content = foestatus;
                BattleText5.Foreground = Brushes.Red;
            } /*else
            {
                BattleText4.Content = selected;
                LabShow(BattleText4);
                BattleText5.Content = EnemyNamesFight[selected];
                LabShow(BattleText5);
            }*/
        }
        private void ACT(in Byte a1)
        {
            UInt16[] x = { 34, 360, 712 };
            UInt16[] y = { 644, 492, 675 };
            string spdr = "Паук";
            string mum = "Мумия";
            string zomb = "Зомби";
            string defd = "Страж";
            UInt16 strength = Super1.Special;
            if ((a1 == 0) && ((Foe1.EnemyAppears[Sets.SelectedTarget] == "Паук") || (Foe1.EnemyAppears[Sets.SelectedTarget] == "Мумия")))
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
            //MediaHide(Trgt);
            LabHide(BattleText1);
            //BattleText1.Margin = new Thickness(473 * Adoptation.WidthAdBack, 45 * Adoptation.HeightAdBack, 0, 0);
            //BattleText1.FontSize = 48 * Adoptation.WidthAdBack;
            //BattleText1.Content = Foe1.EnemyAppears[Sets.SelectedTarget] + " получает " + strength + " урона!";
            LabShow(BattleText1);
            LabHide(HPenemy);
            BarHide(HPenemyBar);
            ImgHide(EnemyImg);
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
                Foe1.EnemyHP[Sets.SelectedTarget] = (ushort)(Foe1.EnemyHP[Sets.SelectedTarget] - strength);
            }
            if (Foe1.EnemyHP[Sets.SelectedTarget] == 0)
            {
                string res= "SpiderDied";
                res=EnemySounds(Sets.SelectedTarget);
                SEF(new Uri(@"" + res + ".mp3", UriKind.RelativeOrAbsolute));
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Паук")
                {
                    Sets.SpiderAlive--;
                    CheckFoeCounts(0, (spdr + ": " + Sets.SpiderAlive));
                    if (Sets.SpiderAlive == 0)
                    {
                        LabShow(BattleText3);
                        CheckFoeCounts(0, "");
                   //     EnemyNamesFight[0] = 0;
                        Foe1.EnemyAppears[Sets.SelectedTarget] = "";
                    }
                }
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Мумия")
                {
                    Sets.MummyAlive--;
                    CheckFoeCounts(1, (mum + ": " + Sets.MummyAlive));
                    if (Sets.MummyAlive == 0)
                    {
                        CheckFoeCounts(1, "");
                      //  EnemyNamesFight[1] = 0;
                        LabShow(BattleText4);
                        Foe1.EnemyAppears[Sets.SelectedTarget] = "";
                    }
                }
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Зомби")
                {
                    Sets.ZombieAlive--;
                    CheckFoeCounts(2, (zomb + ": " + Sets.ZombieAlive));
                    if (Sets.ZombieAlive == 0)
                    {
                        LabShow(BattleText5);
                        CheckFoeCounts(2, "");
                    //    EnemyNamesFight[2] = 0;
                        Foe1.EnemyAppears[Sets.SelectedTarget] = "";
                    }
                }
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Страж")
                {
                    Sets.BonesAlive--;
                    CheckFoeCounts(3, (defd + ": " + Sets.BonesAlive));
                    if (Sets.BonesAlive == 0)
                    {
                        LabShow(BattleText6);
                        CheckFoeCounts(3, "");
                    //    EnemyNamesFight[3] = 0;
                        Foe1.EnemyAppears[Sets.SelectedTarget] = "";
                    }
                }
                // ImgHide(EnemyCursor);
                //BattleText2.Content = Foe1.EnemyAppears[Sets.SelectedTarget] + " погибает!";
                // LabShow(BattleText2);
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
                //Trgt.Margin = new Thickness(x[Sets.SelectedTarget] * Adoptation.WidthAdBack, y[Sets.SelectedTarget] * Adoptation.HeightAdBack, 0, 0);
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
            ImgHide(TrgtImg);
            ButtonHide(ACT1);
            ButtonHide(Cancel2);
            SelectedTrgt = Sets.SelectedTarget;
            timer9.Stop();
            timer8 = new System.Windows.Threading.DispatcherTimer();
            timer8.Tick += new EventHandler(Torch_Time_Tick13);
            timer8.Interval = new TimeSpan(0, 0, 0, 0, 25);
            timer8.Start();
            timer10 = new System.Windows.Threading.DispatcherTimer();
            timer10.Tick += new EventHandler(TorchDmg_Time_Tick20);
            timer10.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer10.Start();
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
            //BattleText1.Margin = new Thickness(473 * Adoptation.WidthAdBack, 45 * Adoptation.HeightAdBack, 0, 0);
            //BattleText1.Content = "Рэй излечивается от яда!";
            LabShow(BattleText1);
            Img5.Source = new BitmapImage(new Uri(@"Person6.png", UriKind.RelativeOrAbsolute));
            Super1.PlayerStatus = 0;
            APbar.Value -= 1;
            AP.Content = APbar.Value + "/" + APbar.Maximum;
            AbilitiesMakeDisappear1();
            Time1.Value = 0;


            timer8 = new System.Windows.Threading.DispatcherTimer();
            timer8.Tick += new EventHandler(Heal_Time_Tick12);
            timer8.Interval = new TimeSpan(0, 0, 0, 0, 25);
            timer8.Start();
            timer11 = new System.Windows.Threading.DispatcherTimer();
            timer11.Tick += new EventHandler(HealPsn_Time_Tick19);
            timer11.Interval = new TimeSpan(0, 0, 0, 0, 75);
            timer11.Start();
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
            ImgHide(TrgtImg);
            SelectedTrgt = Sets.SelectedTarget;
            timer8 = new System.Windows.Threading.DispatcherTimer();
            timer8.Tick += new EventHandler(Whip_Time_Tick14);
            timer8.Interval = new TimeSpan(0, 0, 0, 0, 25);
            timer8.Start();
            timer10 = new System.Windows.Threading.DispatcherTimer();
            timer10.Tick += new EventHandler(WhipDmg_Time_Tick21);
            timer10.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer10.Start();
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
        private void SuperCheckFoes(in Byte seltrg)
        {
            if (Foe1.EnemyAppears[seltrg] == "Паук")
            {
                Sets.SpiderAlive--;
                CheckFoeCounts(0, ("Паук: " + Sets.SpiderAlive));
                if (Sets.SpiderAlive == 0)
                {
                    LabShow(BattleText3);
                    CheckFoeCounts(0, "");
                    Foe1.EnemyAppears[seltrg] = "";
                }
            } else
            {
                BattleText4.Content = seltrg;
                BattleText5.Content = Foe1.EnemyAppears[seltrg];
                LabShow(BattleText4);
                LabShow(BattleText5);
            }
            if (Foe1.EnemyAppears[seltrg] == "Мумия")
            {
                Sets.MummyAlive--;
                CheckFoeCounts(1, ("Мумия: " + Sets.MummyAlive));
                if (Sets.MummyAlive == 0)
                {
                    CheckFoeCounts(1, "");
                    LabShow(BattleText4);
                    Foe1.EnemyAppears[seltrg] = "";
                }
            }
            if (Foe1.EnemyAppears[seltrg] == "Зомби")
            {
                Sets.ZombieAlive--;
                CheckFoeCounts(2, ("Зомби: " + Sets.ZombieAlive));
                if (Sets.ZombieAlive == 0)
                {
                    LabShow(BattleText5);
                    CheckFoeCounts(2, "");
                    Foe1.EnemyAppears[seltrg] = "";
                }
            }
            if (Foe1.EnemyAppears[seltrg] == "Страж")
            {
                Sets.BonesAlive--;
                CheckFoeCounts(3, ("Страж: " + Sets.BonesAlive));
                if (Sets.BonesAlive == 0)
                {
                    LabShow(BattleText6);
                    CheckFoeCounts(3, "");
                    Foe1.EnemyAppears[seltrg] = "";
                }
            }
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
            //MediaHide(Trgt);
            ImgHide(TrgtImg);
            LabHide(BattleText1);

            //BattleText1.Margin = new Thickness(473*Adoptation.WidthAdBack, 45 * Adoptation.HeightAdBack, 0, 0);
            //BattleText1.FontSize = 48 * Adoptation.WidthAdBack;
            //BattleText1.Content = "Все враги получают " + strength + " урона!";
            LabShow(BattleText1);
            BarHide(HPenemyBar);
            LabHide(HPenemy);
            ButtonHide(Fight);
            ButtonHide(Cancel1);
            ButtonHide(Cancel2);
            SelectedTrgt = 4;
            Time1.Value = 0;
            
            Lab2.Foreground = Brushes.White;
            if (Foe1.EnemyAppears[Sets.SelectedTarget] != "Фараон")
            {
                if ((Foe1.EnemyHP[0] - strength <= 0)&& (Foe1.EnemyAppears[0] != ""))
                {
                    Foe1.EnemyHP[0] = 0;
                    ImgHide(Img6);
                    SuperCheckFoes(0);
                    Foe1.EnemiesStillAlive--;
                }
                else if (Foe1.EnemyAppears[0] != "")
                    Foe1.EnemyHP[0] = Convert.ToUInt16(Foe1.EnemyHP[0] - strength);

                if ((Foe1.EnemyHP[1] - strength <= 0)&& (Foe1.EnemyAppears[1]!=""))
                {
                    Foe1.EnemyHP[1] = 0;
                    ImgHide(Img7);
                    SuperCheckFoes(1);
                    Foe1.EnemiesStillAlive--;
                }
                else if (Foe1.EnemyAppears[1] != "")
                    Foe1.EnemyHP[1] = Convert.ToUInt16(Foe1.EnemyHP[1] - strength);

                if ((Foe1.EnemyHP[2] - strength <= 0)&& (Foe1.EnemyAppears[2] != ""))
                {
                    Foe1.EnemyHP[2] = 0;
                    ImgHide(Img8);
                    SuperCheckFoes(2);
                    Foe1.EnemiesStillAlive--;
                }
                else if (Foe1.EnemyAppears[2] != "")
                    Foe1.EnemyHP[2] = Convert.ToUInt16(Foe1.EnemyHP[2] - strength);
                //BattleText2.Content = "Все враги погибают!";
                //BattleText2.IsEnabled = true;
                //BattleText2.Visibility = Visibility.Visible;
                //Foe1.EnemiesStillAlive = 0;
                if (Foe1.EnemyHP[0] != 0)
                    Sets.SelectedTarget = 0;
                else if (Foe1.EnemyHP[1] != 0)
                    Sets.SelectedTarget = 1;
                else if (Foe1.EnemyHP[2] != 0)
                    Sets.SelectedTarget = 2;
                //Trgt.Margin = new Thickness(x[Sets.SelectedTarget] * Adoptation.WidthAdBack, y[Sets.SelectedTarget] * Adoptation.HeightAdBack, 0, 0);
                /*BattleText3.Content = "";
                BattleText4.Content = "";
                BattleText5.Content = "";
                BattleText6.Content = "";
                //LabHide(BattleText6);
                //LabHide(BattleText5);
                //LabHide(BattleText4);
                //LabHide(BattleText3);
                Foe1.EnemyName[0] = "";
                Foe1.EnemyName[1] = "";
                Foe1.EnemyName[2] = "";*/
                /*if (Sets.BonesAlive != 0)
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
                }*/
                Time1.Value = 0;

                timer8 = new System.Windows.Threading.DispatcherTimer();
                timer8.Tick += new EventHandler(Super_Time_Tick15);
                timer8.Interval = new TimeSpan(0, 0, 0, 0, 25);
                timer8.Start();
                timer10 = new System.Windows.Threading.DispatcherTimer();
                timer10.Tick += new EventHandler(SuperDmg_Time_Tick22);
                timer10.Interval = new TimeSpan(0, 0, 0, 0, 50);
                timer10.Start();
                //ImgHide(EnemyCursor);
                //
                //ImgHide(Img7);
                //ImgHide(Img8);
            }
            else
            {
                if (Foe1.EnemyHP[0] - strength <= 0)
                    Foe1.EnemyHP[0] = 0;
                else
                    Foe1.EnemyHP[0] = Convert.ToUInt16(Foe1.EnemyHP[0] - strength);

                if (Foe1.EnemyHP[0] == 0)
                {
                    //ImgHide(EnemyCursor);
                    ImgHide(Img6);
                    Time1.Value = 0;
                    Foe1.EnemiesStillAlive = 0;
                }
                SEF(new Uri(@"DefeatPharaoh.mp3", UriKind.RelativeOrAbsolute));
                timer8 = new System.Windows.Threading.DispatcherTimer();
                timer8.Tick += new EventHandler(Super_Time_Tick15);
                timer8.Interval = new TimeSpan(0, 0, 0, 0, 25);
                timer8.Start();
                timer10 = new System.Windows.Threading.DispatcherTimer();
                timer10.Tick += new EventHandler(SuperDmg_Time_Tick22);
                timer10.Interval = new TimeSpan(0, 0, 0, 0, 25);
                timer10.Start();
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


            timer8 = new System.Windows.Threading.DispatcherTimer();
            timer8.Tick += new EventHandler(Items_Time_Tick10);
            timer8.Interval = new TimeSpan(0, 0, 0, 0, 25);
            timer8.Start();
            timer11 = new System.Windows.Threading.DispatcherTimer();
            timer11.Tick += new EventHandler(Antidote_Time_Tick26);
            timer11.Interval = new TimeSpan(0, 0, 0, 0, 75);
            timer11.Start();
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

            timer8 = new System.Windows.Threading.DispatcherTimer();
            timer8.Tick += new EventHandler(Items_Time_Tick10);
            timer8.Interval = new TimeSpan(0, 0, 0, 0, 25);
            timer8.Start();
            timer11 = new System.Windows.Threading.DispatcherTimer();
            timer11.Tick += new EventHandler(Fused_Time_Tick25);
            timer11.Interval = new TimeSpan(0, 0, 0, 0, 75);
            timer11.Start();
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
            timer8 = new System.Windows.Threading.DispatcherTimer();
            timer8.Tick += new EventHandler(Items_Time_Tick10);
            timer8.Interval = new TimeSpan(0, 0, 0, 0, 25);
            timer8.Start();
            timer11 = new System.Windows.Threading.DispatcherTimer();
            timer11.Tick += new EventHandler(Bandage_Time_Tick23);
            timer11.Interval = new TimeSpan(0, 0, 0, 0, 75);
            timer11.Start();
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
            timer8 = new System.Windows.Threading.DispatcherTimer();
            timer8.Tick += new EventHandler(Items_Time_Tick10);
            timer8.Interval = new TimeSpan(0, 0, 0, 0, 25);
            timer8.Start();
            timer11 = new System.Windows.Threading.DispatcherTimer();
            timer11.Tick += new EventHandler(Ether_Time_Tick24);
            timer11.Interval = new TimeSpan(0, 0, 0, 0, 75);
            timer11.Start();
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
            AfterAction();
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

        private void SwitchAbils_Click(object sender, RoutedEventArgs e)
        {
            if (SwitchAbils.Content.ToString() == "=====>")
            {
                ButtonHide(Cure);
                ButtonHide(Heal);
                //if (Super1.CurrentLevel >= 3)
                //  {
                Torch.Visibility = Visibility.Visible;
                if (APbar.Value >= 4)
                    Torch.IsEnabled = true;
                //  }

                // if (Super1.CurrentLevel >= 6)
                // {
                Whip.Visibility = Visibility.Visible;
                if (APbar.Value >= 6)
                    Whip.IsEnabled = true;
                // }

                // if (Super1.CurrentLevel >= 7)
                //{
                Super.Visibility = Visibility.Visible;
                if (APbar.Value >= 10)
                    Super.IsEnabled = true;
                //}
                SwitchAbils.Content = "<=====";
            }
            else if (SwitchAbils.Content.ToString() != "=====>")
            {

                Cure.Visibility = Visibility.Visible;
                if (APbar.Value >= 1)
                    Cure.IsEnabled = true;
                //   if (Super1.CurrentLevel >= 4)
                // {
                Heal.Visibility = Visibility.Visible;
                if (APbar.Value >= 1)
                    Heal.IsEnabled = true;
                ButtonShow(SwitchAbils);
                //  }
                ButtonHide(Torch);
                ButtonHide(Whip);
                ButtonHide(Super);
                SwitchAbils.Content = "=====>";
            }
        }
    }
}

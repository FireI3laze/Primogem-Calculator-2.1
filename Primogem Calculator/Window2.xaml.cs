using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


namespace Primogem_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            int nWidth = (int)System.Windows.SystemParameters.PrimaryScreenWidth;
            int nHieght = (int)System.Windows.SystemParameters.PrimaryScreenHeight;

            this.LayoutTransform = new ScaleTransform(nWidth / 1920, nHieght / 1080);

        }

        private const int V = 0;
        bool Welkin;
        bool BP;
        bool Events;
        bool ToggleRefund;
        bool AbyssStarsAllowed = false;
        int inputDays;
        int AbyssStars;
        int ExplorationProgress;
        int Counter;



        #region Enter

        public void T1MouseLeave(object sender, RoutedEventArgs e)
        {
            Counter = Counter + 1;
            if (Counter >= 3)
            {
                Start();
            }
        }
        public void T2MouseLeave(object sender, RoutedEventArgs e)
        {
            Counter = Counter + 1;
            if (Counter >= 3)
            {
                Start();
            }
        }
        public void B1MouseEnter(object sender, RoutedEventArgs e)
        {
            Counter = Counter + 1;
            if (Counter >= 3)
            {
                Start();
            }
        }
        public void ButtonEnter(object sender, RoutedEventArgs e)
        {
            Counter = Counter + 1;
            if (Counter >= 3)
            {
                Start();
            }
        }
        #endregion

        #region Start()
        public void Start()
        {
            string input1 = txtBox_anzAbyssStars.Text;
            try
            {
                //AmountOfDays.Content = $"{input1}";
                if (input1 == "")
                {
                    secondError.Foreground = Brushes.Red;
                    secondError.Content = "Assumes 36 Stars*";
                    AbyssStarsAllowed = true;
                }
                else
                {
                    AbyssStars = Int32.Parse(input1);
                    //AmountOfDays.Content = $"{input1}";
                    if (AbyssStars < V)
                    {
                        secondError.Foreground = Brushes.Red;
                        secondError.Content = $"Only use numbers from 0 - 36";
                        AbyssStarsAllowed = false;
                    }
                    else
                    {
                        if (AbyssStars > 36)
                        {
                            AbyssStarsAllowed = false;
                            secondError.Foreground = Brushes.Red;
                            secondError.Content = $"Highest allowed Input is 36";
                        }
                        else
                        {
                            AbyssStarsAllowed = true;
                            SpotPatchPos(inputDays, ExplorationProgress);
                        }
                    }
                }

            }
            catch (FormatException)
            {
                secondError.Foreground = Brushes.Red;
                secondError.Content = $"Only use numbers";
            }

            string input3 = txtBox_anzExploration.Text;
            try
            {
                if (input3 == "")
                {
                    thirdError.Foreground = Brushes.Black;
                    thirdError.Content = "Assumes 0% Exploration*";
                }
                else
                {
                    ExplorationProgress = Int32.Parse(input3);
                    thirdError.Content = "";
                    if (ExplorationProgress < V)
                    {
                        thirdError.Foreground = Brushes.Red;
                        thirdError.Content = $"Only use numbers from 0 - 9999";
                        ExplorationProgress = 0;
                    }
                    else
                    {
                        thirdError.Foreground = Brushes.Black;
                        thirdError.Content = $"% World Exploration progress expected";
                        SpotPatchPos(inputDays, ExplorationProgress);
                    }
                }

            }
            catch (FormatException)
            {
                thirdError.Foreground = Brushes.Red;
                thirdError.Content = $"Only use numbers";
            }

            string input2 = txtBox_anzPrimos.Text;
            try
            {
                inputDays = Int32.Parse(input2);
                firstError.Content = "";
                if (inputDays < V)
                {
                    firstError.Foreground = Brushes.Red;
                    firstError.Content = $"Only use numbers from 0 - 999999.";
                    inputDays = 0;
                }
                else
                {
                    SpotPatchPos(inputDays, ExplorationProgress);
                }
            }
            catch (FormatException)
            {
                firstError.Foreground = Brushes.Red;
                firstError.Content = $"Only use numbers";
                inputDays = 0;
            }          
        }
        #endregion

        #region Check Ticket Box

        public void Welkin_Checked(object sender, RoutedEventArgs e)
        {
            Welkin = true;
        }

        public void Welkin_Unchecked(object sender, RoutedEventArgs e)
        {
            Welkin = false;
        }

        public void BP_Checked(object sender, RoutedEventArgs e)
        {
            BP = true;
        }

        public void BP_Unchecked(object sender, RoutedEventArgs e)
        {
            BP = false;
        }

        public void Events_Checked(object sender, RoutedEventArgs e)
        {
            Events = true;
        }

        public void Events_Unchecked(object sender, RoutedEventArgs e)
        {
            Events = false;
        }

        public void Refund_Checked(object sender, RoutedEventArgs e)
        {
            ToggleRefund = true;
        }

        public void Refund_Unchecked(object sender, RoutedEventArgs e)
        {
            ToggleRefund = false;
        }

        #endregion

        #region Patch Position

        public void SpotPatchPos(int days, int ExplorationProgress)
        {
            int oldPatchPos = 26;
            int newPatchPos;
            int OldDay = 1;
            int OldMonth = 1;
            int OldYear = 2023;

            int CDay = DateTime.Now.Day;        //current day
            int CMonth = DateTime.Now.Month;    //curent month
            int CYear = DateTime.Now.Year;      //current year

            int ExtraDays = 0;
            int DaysBetween;
            int MonthsBetween;
            int YearsBetween = CYear - OldYear;

            while (CYear > OldYear)
            {
                if (CYear % 4 == 0)
                {
                    ExtraDays = ExtraDays + 366;
                    CYear = CYear - 1;
                }
                else
                {
                    ExtraDays = ExtraDays + 365;
                    CYear = CYear - 1;
                }
            }
            while (CMonth > OldMonth)
            {
                switch (CMonth)
                {
                    case 2:     //January
                        ExtraDays = ExtraDays + 31;
                        CMonth = CMonth - 1;

                        break;

                    case 3:     //February
                        if (CYear % 4 == 0)
                        {
                            ExtraDays = ExtraDays + 29;
                            CMonth = CMonth - 1;
                        }
                        else
                        {
                            ExtraDays = ExtraDays + 28;
                            CMonth = CMonth - 1;
                        }

                        break;
                    case 4:     //March
                        ExtraDays = ExtraDays + 31;
                        CMonth = CMonth - 1;

                        break;
                    case 5:     //April
                        ExtraDays = ExtraDays + 30;
                        CMonth = CMonth - 1;

                        break;
                    case 6:     //Mai
                        ExtraDays = ExtraDays + 31;
                        CMonth = CMonth - 1;

                        break;
                    case 7:     //June
                        ExtraDays = ExtraDays + 30;
                        CMonth = CMonth - 1;

                        break;
                    case 8:     //July
                        ExtraDays = ExtraDays + 31;
                        CMonth = CMonth - 1;

                        break;
                    case 9:     //August
                        ExtraDays = ExtraDays + 31;
                        CMonth = CMonth - 1;

                        break;
                    case 10:     //September
                        ExtraDays = ExtraDays + 30;
                        CMonth = CMonth - 1;

                        break;
                    case 11:     //Oktober
                        ExtraDays = ExtraDays + 31;
                        CMonth = CMonth - 1;

                        break;
                    case 12:     //November
                        ExtraDays = ExtraDays + 30;
                        CMonth = CMonth - 1;

                        break;
                    case 1:     //December
                        ExtraDays = ExtraDays + 31;
                        CMonth = CMonth - 1;

                        break;
                }
            }
            DaysBetween = ExtraDays + CDay - OldDay;

            newPatchPos = oldPatchPos + DaysBetween;
            newPatchPos = newPatchPos % 42;
            Calculation(ref days, newPatchPos, ExplorationProgress, Welkin, BP, AbyssStars);
        }



        #endregion

        #region Calculation
        public void Calculation(ref int inputdays, int PatchPos, int ExplorationProgress, bool Welkin, bool BP, int AbyssStars)
        {

            //int Day = DateTime.Now.Day;
            int MDay;
            int CDay = DateTime.Now.Day;        //current day
            int CMonth = DateTime.Now.Month;    //curent month
            int CYear = DateTime.Now.Year;      //current year

            int NewMonth = CMonth;
            int NewYear = CYear;

            int VglToDay = 0;

            int TotalDays = inputdays;
            int TotalMonths = 0;

            int ToDay = inputdays + CDay;       //Ermittelt Tag bis zu dem berechnet werden muss.     31 + 119 = 150     - 31 + 28 + 31 + 30 (= 120) + 31 -> to big
            int ToMonth = CMonth;

            int DailyPrimos;
            int AbyssPrimos;
            int AbyssResets = 0;
            int ShopReset = 0;
            int AnzAnniversary = 0;
            int AnzLanternrite = 0;

            //Price1.Content = $"{CMonth}, {CYear}"; //Output: 1, 2023 | Stand: 01.2023

            while (ToDay >= 29)
            {
                switch (ToMonth)
                {
                    case 1:     //January
                        if (ToDay > 31)
                        {
                            MDay = 31;
                            ToDay = ToDay - MDay;
                            ToMonth = ToMonth + 1;
                            NewMonth = 2;
                            AbyssResets = AbyssResets + 2;
                            ShopReset = ShopReset + 1;
                            TotalMonths = TotalMonths + 1;
                            AnzLanternrite = AnzLanternrite + 1;
                        }

                        break;

                    case 2:     //February
                        if (NewYear % 4 == 0)   //Schaltjahr
                        {

                            if (ToDay > 29)
                            {
                                MDay = 29;
                                ToDay = ToDay - MDay;
                                ToMonth = ToMonth + 1;
                                NewMonth = 3;
                                AbyssResets = AbyssResets + 2;
                                ShopReset = ShopReset + 1;
                                TotalMonths = TotalMonths + 1;
                            }
                        }
                        else                 //normales Jahr
                        {
                            if (ToDay > 28)
                            {
                                MDay = 28;
                                ToDay = ToDay - MDay;
                                ToMonth = ToMonth + 1;
                                NewMonth = 3;
                                AbyssResets = AbyssResets + 2;
                                ShopReset = ShopReset + 1;
                                TotalMonths = TotalMonths + 1;
                            }
                        }

                        break;
                    case 3:     //March
                        if (ToDay > 31)
                        {
                            MDay = 31;
                            ToDay = ToDay - MDay;
                            ToMonth = ToMonth + 1;
                            NewMonth = 4;
                            AbyssResets = AbyssResets + 2;
                            ShopReset = ShopReset + 1;
                            TotalMonths = TotalMonths + 1;
                        }

                        break;
                    case 4:     //April
                        if (ToDay > 30)
                        {
                            MDay = 30;
                            ToDay = ToDay - MDay;
                            ToMonth = ToMonth + 1;
                            NewMonth = 5;
                            AbyssResets = AbyssResets + 2;
                            ShopReset = ShopReset + 1;
                            TotalMonths = TotalMonths + 1;
                        }

                        break;
                    case 5:     //Mai
                        if (ToDay > 31)
                        {
                            MDay = 31;
                            ToDay = ToDay - MDay;
                            ToMonth = ToMonth + 1;
                            NewMonth = 6;
                            AbyssResets = AbyssResets + 2;
                            ShopReset = ShopReset + 1;
                            TotalMonths = TotalMonths + 1;
                        }

                        break;
                    case 6:     //June
                        if (ToDay > 30)
                        {
                            MDay = 30;
                            ToDay = ToDay - MDay;
                            ToMonth = ToMonth + 1;
                            NewMonth = 7;
                            AbyssResets = AbyssResets + 2;
                            ShopReset = ShopReset + 1;
                            TotalMonths = TotalMonths + 1;
                        }
                     
                        break;
                    case 7:     //July
                        if (ToDay > 31)
                        {
                            MDay = 31;
                            ToDay = ToDay - MDay;
                            ToMonth = ToMonth + 1;
                            NewMonth = 8;
                            AbyssResets = AbyssResets + 2;
                            ShopReset = ShopReset + 1;
                            TotalMonths = TotalMonths + 1;
                        }

                        break;
                    case 8:     //August
                        if (ToDay > 31)
                        {
                            MDay = 31;
                            ToDay = ToDay - MDay;
                            ToMonth = ToMonth + 1;
                            NewMonth = 9;
                            AbyssResets = AbyssResets + 2;
                            ShopReset = ShopReset + 1;
                            TotalMonths = TotalMonths + 1;
                            if (ToDay >= 28)
                            {
                                AnzAnniversary = AnzAnniversary + 1;
                            }
                        }

                        break;
                    case 9:     //September
                        if (ToDay > 30)
                        {
                            MDay = 30;
                            ToDay = ToDay - MDay;
                            ToMonth = ToMonth + 1;
                            NewMonth = 10;
                            AbyssResets = AbyssResets + 2;
                            ShopReset = ShopReset + 1;
                            TotalMonths = TotalMonths + 1;
                        }

                        break;
                    case 10:     //Oktober
                        if (ToDay > 31)
                        {
                            MDay = 31;
                            ToDay = ToDay - MDay;
                            ToMonth = ToMonth + 1;
                            NewMonth = 11;
                            AbyssResets = AbyssResets + 2;
                            ShopReset = ShopReset + 1;
                            TotalMonths = TotalMonths + 1;
                        }
                        break;

                    case 11:     //November
                        if (ToDay > 30)
                        {
                            MDay = 30;
                            ToDay = ToDay - MDay;
                            ToMonth = ToMonth + 1;
                            NewMonth = 12;
                            AbyssResets = AbyssResets + 2;
                            ShopReset = ShopReset + 1;
                            TotalMonths = TotalMonths + 1;
                        }
                        break;

                    case 12:     //December
                        if (ToDay > 31)
                        {
                            MDay = 31;
                            ToDay = ToDay - MDay;
                            ToMonth = ToMonth - 11;
                            NewMonth = 1;
                            NewYear = NewYear + 1;
                            AbyssResets = AbyssResets + 2;
                            ShopReset = ShopReset + 1;
                            TotalMonths = TotalMonths + 1;
                        }
                        break;
                }

                if (VglToDay == ToDay)
                {
                    break;
                }
                else
                {
                    VglToDay = ToDay;
                }
            }

            if (ToDay > 16)
            {
                AbyssResets = AbyssResets + 1;
            }

            if (CDay > 16)
            {
                AbyssResets = AbyssResets - 1;
            }

            int AllPrimos;
            int AllWishes;
            int TotalWishes;

            DailyPrimos = DailiesWelkinCalculation(TotalDays, Welkin);
            AbyssPrimos = AbyssCalculation(AbyssStars, AbyssResets);
            var AllEventPrimos = EventCalculation(PatchPos, inputdays, Events, AnzAnniversary, AnzLanternrite);
            int SmallEventPrimos = AllEventPrimos.SmallEventPrimos;
            int BigEventPrimos = AllEventPrimos.BigEventPrimos;
            int AllAnniversaryPrimos = AllEventPrimos.AnniversaryPrimos;
            int AllAnniversaryWishes = AllEventPrimos.AnniversaryWishes;
            int AllLanternriteWishes = AllEventPrimos.LanternriteWishes;
            var AllBPRewards = BattlePassCalculation(PatchPos, inputdays, BP);
            int AllBPWishes = AllBPRewards.BPWishes;
            int AllBPPrimos = AllBPRewards.BPPrimos;
            int ExplorationPrimos = ExplorationRewards(ExplorationProgress);
            int CompensationStuff = CompensationRewards(PatchPos, inputdays);
            

            int ShopWishes = ShopCalculation(TotalMonths);

            AllPrimos = DailyPrimos + AbyssPrimos + SmallEventPrimos + BigEventPrimos + ExplorationPrimos + CompensationStuff + AllAnniversaryPrimos + AllBPPrimos;
            TotalWishes = ShopWishes + AllBPWishes + AllAnniversaryWishes + AllLanternriteWishes + (AllPrimos / 160);

            int Refund = RefundCalculation(TotalWishes);

            AllWishes = ShopWishes + AllBPWishes + AllAnniversaryWishes + AllLanternriteWishes + Refund;
            TotalWishes = TotalWishes + Refund;

            TotalRewards(AllPrimos, AllWishes, TotalWishes, inputdays);
            TotalPrice(PatchPos, inputdays, Welkin, BP);
            DatePrinter(ToDay, NewMonth, NewYear, AbyssResets, AbyssStarsAllowed);
        }

        //Dailies and Welkin
        public int DailiesWelkinCalculation(int Days, bool Welkin)
        {
            int DailyPrimos = 60 * Days;
            int WelkinPrimos;
            int WelkinCrystals;
            int TotalDailyPrimos;
            if (Welkin)
            {
                HWelkinDailies.Content = "Daily Login and Welkin Moon";
                WelkinPrimos = 90 * Days;
                WelkinCrystals = 300 * ((Days / 30) + 1);

                WelkinDailies.Content = $" + {DailyPrimos} Primogems from Dailies \n + {WelkinPrimos} Primogems from Welkin Moon\n + {WelkinCrystals} Crystals from Welkin Moon\n ____________________________________________________________________________________________ \n + {DailyPrimos + WelkinPrimos + WelkinCrystals} Primogems";
                WelkinPrimos = WelkinPrimos + WelkinCrystals;

            }
            else
            {
                HWelkinDailies.Content = "Daily Login";
                WelkinPrimos = 0;
                WelkinDailies.Content = $" + {DailyPrimos} Primogems from Dailies \n ____________________________________________________________________________________________ \n + { DailyPrimos} Primogems";
            }
            TotalDailyPrimos = DailyPrimos + WelkinPrimos;
            return TotalDailyPrimos;
        }

        //Spiral Abyss
        public int AbyssCalculation(int AbyssStars, int AbyssResets)
        {
            if (AbyssStars < 0)
            {
                AbyssStars = 0;
            }
            if (AbyssStars > 36)
            {
                AbyssStars = 0;
            }

            int AbyssPrimos = AbyssStars / 3 * 50;
            int TotalAbyssPrimos = AbyssStars / 3 * 50 * AbyssResets;
            Abyss.Content = $" {AbyssStars} Abyss-Stars clear\n + {AbyssPrimos} Primogems x {AbyssResets} run/s \n ____________________________________________________________________________________________ \n + {TotalAbyssPrimos} Primogems";
            return TotalAbyssPrimos;
        }

        //Events
        (int SmallEventPrimos, int BigEventPrimos, int AnniversaryPrimos, int AnniversaryWishes, int LanternriteWishes) EventCalculation(int PatchPos, int inputdays, bool Events, int AnzAnniversary, int AnzLanternrite)
        {
            int PatchDaysLeft = 42 - PatchPos;                  //Tage, die der aktuelle Patch noch weiter geht
            int OverPatchDays;                                  //Tage die nach dem aktuellen Patch noch über sind
            int CurrentPatchDays;
            int Patches;                                        //Anzahl Patches
            int NewPatchDays;
            int SmallEvents;
            int SmallEventsOver;
            int BigEvents = 0;
            int BigEventsOver;

            if (inputdays + PatchPos > 42)
            {
                OverPatchDays = inputdays - PatchDaysLeft;     //Tage die nach dem aktuellen Patch noch über sind
                CurrentPatchDays = 42;
                Patches = OverPatchDays / 42;
            }
            else
            {
                OverPatchDays = 0;
                CurrentPatchDays = inputdays + PatchPos;     //Tage des aktuellen Patches, falls kein neuer erreicht wird
                Patches = 0;
            }

            if (PatchPos >= 7)
            {
                SmallEventsOver = (PatchPos / 7) - 1;
                BigEventsOver = 1;
                if (PatchPos >= 35)
                {
                        SmallEventsOver = 4;
                }
            }
            else
            {
                SmallEventsOver = 0;
                BigEventsOver = 0;
            }
            if (CurrentPatchDays > 28)
            {
                SmallEvents = 4 - SmallEventsOver;
                if (CurrentPatchDays > 35)
                {
                    BigEvents = 1 - BigEventsOver;
                }
            }
            else
            {
                if (CurrentPatchDays >= 7)
                {
                 SmallEvents = (CurrentPatchDays / 7) - SmallEventsOver;
                 SmallEvents = SmallEvents - 1;
                }
                else
                {
                    SmallEvents = 0;
                }
            }

            NewPatchDays =  OverPatchDays % 42;    //Tage die in den letzten erreichten Patch rein gehen

            int SmallEventPrimos = 0;
            int BigEventPrimos = 0;

            while (Patches > 0)
            {
                SmallEvents = SmallEvents + 4;
                BigEvents = BigEvents + 1;
                Patches = Patches - 1;
            }

            if (NewPatchDays >= 7)
            {
                if (NewPatchDays >= 35)
                {
                    if (NewPatchDays != 42)
                    {
                        SmallEvents = SmallEvents + 4;
                        BigEvents = BigEvents + 1;
                    }
                }
                else
                {
                    SmallEvents = SmallEvents + (NewPatchDays / 7) - 1;
                }
            }
            else
            {
                SmallEvents = SmallEvents + 0;
            }

            SmallEventPrimos = SmallEvents * 420;
            BigEventPrimos = BigEvents * 1680;

            int AnniversaryPrimos = AnzAnniversary * 1600;
            int AnniversaryWishes = AnzAnniversary * 10;
            int LanternriteWishes = AnzLanternrite * 15;
            bool Festivals;

            if (AnniversaryPrimos > 0)
            {
                Festivals = true;
            }
            else
            {
                if (LanternriteWishes > 0)
                {
                    Festivals = true;
                }
                else
                {
                    Festivals = false;
                }
            }

            if (Events)
            {
                if (Festivals)
                {
                    HEvent.Content = "Events and Festivals";
                    Event.Content = $" + {BigEventPrimos} Primogems from {BigEvents} Big Events \n + {SmallEventPrimos} Primogems from {SmallEvents} Small Events\n + {AnniversaryPrimos} Primogems from {AnzAnniversary} Anniversary/s\n + {AnniversaryWishes} Intertwined Fates from {AnzAnniversary} Anniversary/s\n + {LanternriteWishes} Intertwined Fates from {AnzLanternrite} Lanternrite/s\n ____________________________________________________________________________________________ \n + {AnniversaryWishes + LanternriteWishes} Intertwined Fates | + {SmallEventPrimos + BigEventPrimos + AnniversaryPrimos} Primogems";
                }
                else
                {
                    HEvent.Content = "Events";
                    Event.Content = $" + {BigEventPrimos} Primogems from {BigEvents} Big Events \n + {SmallEventPrimos} Primogems from {SmallEvents} Small Events \n ____________________________________________________________________________________________ \n + {SmallEventPrimos + BigEventPrimos} Primogems";
                }
            }
            else
            {
                SmallEventPrimos = 0;
                BigEventPrimos = 0;
                Event.Content = $" + {BigEventPrimos} Primogems from {BigEvents} Big Events \n + {SmallEventPrimos} Primogems from {SmallEvents} Small Events \n ____________________________________________________________________________________________ \n + {SmallEventPrimos + BigEventPrimos} Primogems";
            }
            //Test1.Content = $"{inputdays}, {PatchPos}, {CurrentPatchDays}, {OverPatchDays}, {Patches}, {NewPatchDays}, {SmallEventsOver}, {SmallEvents}, {BigEvents}"; //Test -> Funktioniert!
            return (SmallEventPrimos, BigEventPrimos, AnniversaryPrimos, AnniversaryWishes, LanternriteWishes);
        }

        //BattlePass       
        (int BPWishes, int BPPrimos)BattlePassCalculation(int PatchPos, int inputdays, bool BP)
        {
            int BPWishes = 0;
            int BPPrimos = 0;
            int BPWishesGone;
            int PatchDaysLeft = 42 - PatchPos;                  //Tage, die der aktuelle Patch noch weiter geht
            int OverPatchDays;                                  //Tage die nach dem aktuellen Patch noch über sind
            int CurrentPatchDays;
            int Patches;                                        //Anzahl Patches
            int NewPatchDay;

            if (inputdays + PatchPos > 42)
            {
                OverPatchDays = inputdays - PatchDaysLeft;     //Tage die nach dem aktuellen Patch noch über sind
                CurrentPatchDays = 42;
                Patches = OverPatchDays / 42;
                NewPatchDay = OverPatchDays % 42;
            }
            else
            {
                OverPatchDays = 0;
                CurrentPatchDays = inputdays + PatchPos;     //Tage des aktuellen Patches, falls kein neuer erreicht wird
                Patches = 0;
                NewPatchDay = 0;
            }
            BPWishesGone = PatchPos / 7;
            if (CurrentPatchDays >= 35)
            {
                BPWishes = 4 - BPWishesGone;
                BPPrimos = 680;
            }
            else
            {
                BPWishes = CurrentPatchDays / 7 - BPWishesGone;
            }
            int PatchesLeft = Patches;
            while (PatchesLeft != 0)
            {
                BPWishes = BPWishes + 4;
                BPPrimos = BPPrimos + 680;
                PatchesLeft = PatchesLeft - 1;
            }
            if (NewPatchDay > 0)
            {
                if (NewPatchDay >= 35)
                {
                    BPWishes = BPWishes + 4;
                    BPPrimos = BPPrimos + 680;
                }
                else
                {
                    BPWishes = BPWishes + NewPatchDay / 7;
                }
            }
            if (BP)
            {
                Battlepass.Content = $" {Patches + 1}x Battlepass\n + {BPPrimos} Primogems\n + {BPWishes} Intertwined Fates\n ____________________________________________________________________________________________ \n + {BPWishes + BPPrimos / 160} Intertwined Fates | + {BPPrimos % 160} Primogems";
            }
            else
            {
                BPPrimos = 0;
                BPWishes = 0;
                Battlepass.Content = $" {Patches + 1}x Battlepass\n + {BPPrimos} Primogems\n + {BPWishes} Intertwined Fates\n ____________________________________________________________________________________________ \n + {BPWishes + BPPrimos / 160} Intertwined Fates | + {BPPrimos % 160} Primogems";
            }

            return (BPWishes, BPPrimos);
        }

        //Exploration
        public int ExplorationRewards(int ExplorationProgress)
        {
            int ExplorationPrimos;
            ExplorationPrimos = ExplorationProgress * 8;
            Exploration.Content = $" + {ExplorationPrimos} Primogems from {ExplorationProgress}% Exploration\n ____________________________________________________________________________________________ \n + {ExplorationPrimos} Primogems";
            return ExplorationPrimos;
        }

        //Compensation and Festivals
        public int CompensationRewards(int PatchPos, int inputdays)
        {
            int PatchDaysLeft = 42 - PatchPos;                  //Tage, die der aktuelle Patch noch weiter geht
            int OverPatchDays;                                  //Tage die nach dem aktuellen Patch noch über sind
            int Patches;                                        //Anzahl Patches
            int CompensationPrimos;

            if (inputdays + PatchPos > 42)
            {
                OverPatchDays = inputdays - PatchDaysLeft - 1;     //Tage die nach dem aktuellen Patch noch über sind
                Patches = OverPatchDays / 42 + 1;
                CompensationPrimos = (Patches) * 600;
            }
            else
            {
                Patches = 0;
                CompensationPrimos = 0;
            }
            Compensation.Content = $" + {CompensationPrimos} Primogems from {Patches} Patch Compensations\n ____________________________________________________________________________________________\n + {CompensationPrimos} Primogems";
            return (CompensationPrimos);
        }

        //Shop
        public int ShopCalculation(int Months)
        {
            int ShopWishes = Months * 5;
            Shop.Content = $" + 5 Intertwined Fates x {Months} Shop Resets\n ____________________________________________________________________________________________ \n + {ShopWishes} Intertwined Fates";
            return ShopWishes;
        }

        //Refund
        public int RefundCalculation(int TotalWishes)
        {
            //Starglitter (Assumes refunding 100% of gained Starglitter in more wishes (with worst luck)
            int Starglitter;
            int RefundWishes;
            do
            {
                Starglitter = TotalWishes / 10 * 2;
                while (TotalWishes >= 80)
                {
                    Starglitter = Starglitter + 10;
                    TotalWishes = TotalWishes - 80;
                }
                RefundWishes = Starglitter / 5;
                Starglitter = Starglitter % 5;
            }
            while (Starglitter / 5 != V);

            if (ToggleRefund)
            {
                Refund.Content = $" + {Starglitter + RefundWishes * 5} Starglitter\n ____________________________________________________________________________________________ \n + {RefundWishes} Intertwined Fates | + {Starglitter} Starglitter";
            }
            else
            {
                Starglitter = Starglitter + RefundWishes * 5;
                RefundWishes = 0;
                Refund.Content = $" + {Starglitter + RefundWishes * 5} Starglitter\n ____________________________________________________________________________________________ \n + {RefundWishes} Intertwined Fates | + {Starglitter} Starglitter";
            }
            return RefundWishes;
        }

        //Total
        public void TotalRewards(int AllPrimos, int AllWishes, int TotalWishes, int TotalDays)
        {
            Total.Content = $" + {AllPrimos} Primogems \n + {AllWishes} Intertwined Fates \n ____________________________________________________________________________________________ \n + {TotalWishes} Intertwined Fates & {AllPrimos % 160} Primogems";
        }

        //Price
        public void TotalPrice (int PatchPos, int inputdays, bool Welkin, bool BP)
        {
            int PatchDaysLeft = 42 - PatchPos;                  //Tage, die der aktuelle Patch noch weiter geht
            int OverPatchDay;                                   //Tage die nach dem aktuellen Patch noch über sind
            int CurrentPatchDay;
            int NewPatchDay;
            int Patches;                                        //Anzahl Patches
            int AnzBP = 0;
            int AnzWelkin = 0;

            if (inputdays + PatchPos > 42)
            {
                OverPatchDay = inputdays - PatchDaysLeft;     //Tage die nach dem aktuellen Patch noch über sind
                CurrentPatchDay = 42;
                NewPatchDay = inputdays % 42;
                Patches = OverPatchDay / 42;
            }
            else
            {
                OverPatchDay = 0;
                CurrentPatchDay = inputdays + PatchPos;     //Tage des aktuellen Patches, falls kein neuer erreicht wird
                NewPatchDay = 0;
                Patches = 0;
            }
            if (CurrentPatchDay <= 35)
            {
                AnzBP = 1;
            }
            if (NewPatchDay <= 35)
            {
                AnzBP = 1;
            }
            AnzBP = AnzBP + Patches;
            AnzWelkin = 1 + inputdays / 30;

            if (Welkin)
            {
                if (BP)
                {
                    Price.Content = $" + {AnzWelkin} Welkins x 5$\n + {AnzBP} Battlepass x 10$\n ____________________________________________________________________________________________\n {(AnzWelkin * 5) + (AnzBP * 10)}$";
                }
                else
                {
                    Price.Content = $" + {AnzWelkin} Welkins x 5$\n ____________________________________________________________________________________________\n {AnzWelkin * 5}$";
                }
            }
            else
            {
                if (BP)
                {
                    Price.Content = $" + {AnzBP} Battlepass x 10$\n ____________________________________________________________________________________________\n {AnzBP * 10}$";
                }
                else
                {
                    Price.Content = $" Free to Play\n____________________________________________________________________________________________\n 0$";
                }
            }
        }

        //Date
        public void DatePrinter(int ToDay, int NewMonth, int NewYear, int AbyssResets, bool AbyssStarsAllowed)
        {
            if (AbyssStarsAllowed)
            {
                secondError.Foreground = Brushes.Black;
                secondError.Content = $"Stars | expected Abyss-Resets: {AbyssResets}";
            }
            firstError.Foreground = Brushes.Black;
            firstError.Content = $"Days | calculated for date: {ToDay}.{NewMonth}.{NewYear}";
        }

        #endregion

        private void txtBox_anzAbyssStars_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}

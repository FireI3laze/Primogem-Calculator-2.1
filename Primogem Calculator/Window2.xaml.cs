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
            Start();

        }

        private const int V = 0;
        bool Welkin;
        bool BP;
        bool Events;
        bool ToggleRefund;

        bool AbyssStarsAllowed = false;
        bool ExplorationInputAllowed = false;
        bool DaysInputAllowed = false;

        bool HistoryClear;

        int inputDays;
        int AbyssStars;
        int ExplorationProgress;
        bool Open = true;



        #region Enter

        public void T1MouseLeave(object sender, RoutedEventArgs e)
        {

        }
        public void T2MouseLeave(object sender, RoutedEventArgs e)
        {

        }
        public void B1MouseEnter(object sender, RoutedEventArgs e)
        {

        }
        public void ButtonEnter(object sender, RoutedEventArgs e)
        {
            Start();
        }

        #region BothTabs

        public void BPatches(object sender, RoutedEventArgs e)
        {
            CurrentPatch.Visibility = Visibility.Visible;

            CdaysGone.Visibility = Visibility.Visible;
            CdaysLeft.Visibility = Visibility.Visible;
            CBanner.Visibility = Visibility.Visible;

            NPatch.Visibility = Visibility.Visible;
            FirstHalf.Visibility = Visibility.Visible;
            SecondHalf.Visibility = Visibility.Visible;

            NNPatch.Visibility = Visibility.Visible;
            NFirstHalf.Visibility = Visibility.Visible;
            NSecondHalf.Visibility = Visibility.Visible;

            NNNPatch.Visibility = Visibility.Visible;
            NNFirstHalf.Visibility = Visibility.Visible;
            NNSecondHalf.Visibility = Visibility.Visible;

            RH1.Visibility = Visibility.Hidden;
            RH2.Visibility = Visibility.Visible;

            Last10Inputs.Visibility = Visibility.Hidden;
            History.Visibility = Visibility.Hidden;
            ClearHistory.Visibility = Visibility.Hidden;

            SomeUpcomingPatches.Foreground = Brushes.Black;
            SomeUpcomingPatches.Background = Brushes.LightGray;
            SomeUpcomingPatches.IsEnabled = false;

            HHistory.Foreground = Brushes.LightSkyBlue;
            HHistory.Background = Brushes.AliceBlue;
            HHistory.IsEnabled = true;
        }

        public void BHistory(object sender, RoutedEventArgs e)
        {
            Last10Inputs.Visibility = Visibility.Visible;
            History.Visibility = Visibility.Visible;
            ClearHistory.Visibility = Visibility.Visible;
            
            CurrentPatch.Visibility = Visibility.Hidden;
            
            CdaysGone.Visibility = Visibility.Hidden;
            CdaysLeft.Visibility = Visibility.Hidden;
            CBanner.Visibility = Visibility.Hidden;
            
            NPatch.Visibility = Visibility.Hidden;
            FirstHalf.Visibility = Visibility.Hidden;
            SecondHalf.Visibility = Visibility.Hidden;
            
            NNPatch.Visibility = Visibility.Hidden;
            NFirstHalf.Visibility = Visibility.Hidden;
            NSecondHalf.Visibility = Visibility.Hidden;

            NNNPatch.Visibility = Visibility.Hidden;
            NNFirstHalf.Visibility = Visibility.Hidden;
            NNSecondHalf.Visibility = Visibility.Hidden;

            RH1.Visibility = Visibility.Visible;
            RH2.Visibility = Visibility.Hidden;

            SomeUpcomingPatches.Foreground = Brushes.LightSkyBlue;
            SomeUpcomingPatches.Background = Brushes.AliceBlue;
            SomeUpcomingPatches.IsEnabled = true;

            HHistory.Foreground = Brushes.Black;
            HHistory.Background = Brushes.LightGray;
            HHistory.IsEnabled = false;
        }

        #endregion

        public void ClHistory(object sender, RoutedEventArgs e)
        {
            History.Content = "No Input yet";
            HistoryClear = true;
        }
        #endregion

        #region Start()
        public void Start()
        {
            AbyssStarsAllowed = false;
            ExplorationInputAllowed = false;
            DaysInputAllowed = false;

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
                        ExplorationInputAllowed = true;
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
                    DaysInputAllowed = true;
                }
            }
            catch (FormatException)
            {
                firstError.Foreground = Brushes.Red;
                firstError.Content = $"Only use numbers";
                inputDays = 0;
            }
            if (AbyssStarsAllowed && ExplorationInputAllowed && DaysInputAllowed)
                SpotPatchPos(inputDays, ExplorationProgress);
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
            int PatchesSince;

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
            PatchesSince = newPatchPos / 42;
            newPatchPos = newPatchPos % 42;
            PatchesPrediction(newPatchPos, PatchesSince);
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

            bool OnlyOnce = true; //Bezug: September, in While-Schleife
            bool OnlyOnceLR = true;
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
                                AnzLanternrite = AnzLanternrite + 1;
                                OnlyOnceLR = false;
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
                                AnzLanternrite = AnzLanternrite + 1;
                                OnlyOnceLR = false;
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
                            OnlyOnceLR = true;
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
                            if (CDay <= 28)
                            {
                                AnzAnniversary = AnzAnniversary + 1;
                                OnlyOnce = false;
                            }
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
                            OnlyOnce = true;
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

            if (ToMonth == 9 && ToDay >= 28 && OnlyOnce == true && CDay <= 28) //Anniversary Check [Besonderer Fall, im September]
            {
                AnzAnniversary = AnzAnniversary + 1;
            }

            if (ToMonth == 2 && OnlyOnceLR == true)
                AnzLanternrite = AnzLanternrite + 1;

            if (ToDay >= 16)
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
            InputHistory(inputdays, TotalWishes);
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
                    SmallEventsOver = 3;
                }
            }
            else
            {
                SmallEventsOver = 0;
                BigEventsOver = 0;
            }
            if (CurrentPatchDays > 28)
            {
                SmallEvents = 3 - SmallEventsOver;
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

            NewPatchDays = OverPatchDays % 42;    //Tage die in den letzten erreichten Patch rein gehen

            int SmallEventPrimos;
            int BigEventPrimos;

            while (Patches > 0)
            {
                SmallEvents = SmallEvents + 3;
                BigEvents = BigEvents + 1;
                Patches = Patches - 1;
            }

            if (NewPatchDays >= 7)
            {
                if (NewPatchDays >= 35)
                {
                    if (NewPatchDays != 42)
                    {
                        SmallEvents = SmallEvents + 3;
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
            BigEventPrimos = BigEvents * 1000;

            int AnniversaryPrimos = AnzAnniversary * 1600;
            int AnniversaryWishes = AnzAnniversary * 10;
            int LanternriteWishes = AnzLanternrite * 10;
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
                    NNPatch.Margin = new Thickness(10, 25, 20, 210);
                    NFirstHalf.Margin = new Thickness(10, -190, 20, 50);
                    NSecondHalf.Margin = new Thickness(10, -190, 20, 50);
                    ClearHistory.Margin = new Thickness(10, 25, 20, 210);
                }
                else
                {
                    HEvent.Content = "Events";
                    Event.Content = $" + {BigEventPrimos} Primogems from {BigEvents} Big Events \n + {SmallEventPrimos} Primogems from {SmallEvents} Small Events \n ____________________________________________________________________________________________ \n + {SmallEventPrimos + BigEventPrimos} Primogems";
                    NNPatch.Margin = new Thickness(10, 25, 20, 120);
                    NFirstHalf.Margin = new Thickness(10, -100, 20, 50);
                    NSecondHalf.Margin = new Thickness(10, -100, 20, 50);
                    ClearHistory.Margin = new Thickness(10, 25, 20, 120);
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
        (int BPWishes, int BPPrimos) BattlePassCalculation(int PatchPos, int inputdays, bool BP)
        {
            int BPWishes;
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
            BPWishesGone = PatchPos / 5;
            if (BPWishesGone > 4)
                BPWishesGone = 4;
            if (CurrentPatchDays >= 25)
            {
                BPWishes = 4 - BPWishesGone;
                BPPrimos = 680;
            }
            else
            {
                BPWishes = CurrentPatchDays / 5 - BPWishesGone;
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
                if (NewPatchDay >= 25)
                {
                    BPWishes = BPWishes + 4;
                    BPPrimos = BPPrimos + 680;
                }
                else
                {
                    BPWishes = BPWishes + NewPatchDay / 5;
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
                CompensationPrimos = Patches * 600;
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
        public void TotalPrice(int PatchPos, int inputdays, bool Welkin, bool BP)
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

        //History
        int[] DaysHistory = new int[999999];
        int[] WishesHistory = new int[999999];
        int DCounter = 0;
        int Position = 0;
        public void InputHistory(int inputdays, int TotalWishes)
        {
            History.Content = "No Input yet";
            if (HistoryClear == true)
            {
                DCounter = 0;
                /*for (int i = DCounter; i < 0; i--)
                {
                    DaysHistory[DCounter] = 0;
                }*/
                HistoryClear = false;
            }
            if (DCounter > 9)
            {
                foreach (int Day in DaysHistory)
                {
                    if (Position > 0)
                    {
                        DaysHistory[Position - 1] = Day;
                    }
                    Position = Position + 1;
                }
                DaysHistory[9] = inputdays;
                Position = 0;
            }
            else
                DaysHistory[DCounter] = inputdays;

            WishesHistory[DCounter] = TotalWishes;
            if (DCounter > 9)
            {
                foreach (int Wishes in WishesHistory)
                {
                    if (Position > 0)
                    {
                        WishesHistory[Position - 1] = Wishes;
                    }
                    Position = Position + 1;
                }
                Position = 0;
                DCounter = 9;
                WishesHistory[DCounter] = TotalWishes;
            }

            //Outputs
            switch (DCounter)
            {
                case 0:
                    History.Content = $"Days: {DaysHistory[0]} | Wishes: {WishesHistory[0]}";
                    break;

                case 1:
                    History.Content = $"Days: {DaysHistory[1]} | Wishes: {WishesHistory[1]}\n\nDays: {DaysHistory[0]} | Wishes: {WishesHistory[0]}";
                    break;

                case 2:
                    History.Content = $"Days: {DaysHistory[2]} | Wishes: {WishesHistory[2]}\n\nDays: {DaysHistory[1]} | Wishes: {WishesHistory[1]}\n\nDays: {DaysHistory[0]} | Wishes: {WishesHistory[0]}";
                    break;

                case 3:
                    History.Content = $"Days: {DaysHistory[3]} | Wishes: {WishesHistory[3]}\n\nDays: {DaysHistory[2]} | Wishes: {WishesHistory[2]}\n\nDays: {DaysHistory[1]} | Wishes: {WishesHistory[1]}\n\nDays: {DaysHistory[0]} | Wishes: {WishesHistory[0]}";
                    break;

                case 4:
                    History.Content = $"Days: {DaysHistory[4]} | Wishes: {WishesHistory[4]}\n\nDays: {DaysHistory[3]} | Wishes: {WishesHistory[3]}\n\nDays: {DaysHistory[2]} | Wishes: {WishesHistory[2]}\n\nDays: {DaysHistory[1]} | Wishes: {WishesHistory[1]}\n\nDays: {DaysHistory[0]} | Wishes: {WishesHistory[0]}";
                    break;

                case 5:
                    History.Content = $"Days: {DaysHistory[5]} | Wishes: {WishesHistory[5]}\n\nDays: {DaysHistory[4]} | Wishes: {WishesHistory[4]}\n\nDays: {DaysHistory[3]} | Wishes: {WishesHistory[3]}\n\nDays: {DaysHistory[2]} | Wishes: {WishesHistory[2]}\n\nDays: {DaysHistory[1]} | Wishes: {WishesHistory[1]}\n\nDays: {DaysHistory[0]} | Wishes: {WishesHistory[0]}";
                    break;

                case 6:
                    History.Content = $"Days: {DaysHistory[6]} | Wishes: {WishesHistory[6]}\n\nDays: {DaysHistory[5]} | Wishes: {WishesHistory[5]}\n\nDays: {DaysHistory[4]} | Wishes: {WishesHistory[4]}\n\nDays: {DaysHistory[3]} | Wishes: {WishesHistory[3]}\n\nDays: {DaysHistory[2]} | Wishes: {WishesHistory[2]}\n\nDays: {DaysHistory[1]} | Wishes: {WishesHistory[1]}\n\nDays: {DaysHistory[0]} | Wishes: {WishesHistory[0]}";
                    break;

                case 7:
                    History.Content = $"Days: {DaysHistory[7]} | Wishes: {WishesHistory[7]}\n\nDays: {DaysHistory[6]} | Wishes: {WishesHistory[6]}\n\nDays: {DaysHistory[5]} | Wishes: {WishesHistory[5]}\n\nDays: {DaysHistory[4]} | Wishes: {WishesHistory[4]}\n\nDays: {DaysHistory[3]} | Wishes: {WishesHistory[3]}\n\nDays: {DaysHistory[2]} | Wishes: {WishesHistory[2]}\n\nDays: {DaysHistory[1]} | Wishes: {WishesHistory[1]}\n\nDays: {DaysHistory[0]} | Wishes: {WishesHistory[0]}";
                    break;

                case 8:
                    History.Content = $"Days: {DaysHistory[8]} | Wishes: {WishesHistory[8]}\n\nDays: {DaysHistory[7]} | Wishes: {WishesHistory[7]}\n\nDays: {DaysHistory[6]} | Wishes: {WishesHistory[6]}\n\nDays: {DaysHistory[5]} | Wishes: {WishesHistory[5]}\n\nDays: {DaysHistory[4]} | Wishes: {WishesHistory[4]}\n\nDays: {DaysHistory[3]} | Wishes: {WishesHistory[3]}\n\nDays: {DaysHistory[2]} | Wishes: {WishesHistory[2]}\n\nDays: {DaysHistory[1]} | Wishes: {WishesHistory[1]}\n\nDays: {DaysHistory[0]} | Wishes: {WishesHistory[0]}";
                    break;

                case 9:
                    History.Content = $"Days: {DaysHistory[9]} | Wishes: { WishesHistory[9]}\n\nDays: {DaysHistory[8]} | Wishes: {WishesHistory[8]}\n\nDays: {DaysHistory[7]} | Wishes: {WishesHistory[7]}\n\nDays: {DaysHistory[6]} | Wishes: {WishesHistory[6]}\n\nDays: {DaysHistory[5]} | Wishes: {WishesHistory[5]}\n\nDays: {DaysHistory[4]} | Wishes: {WishesHistory[4]}\n\nDays: {DaysHistory[3]} | Wishes: {WishesHistory[3]}\n\nDays: {DaysHistory[2]} | Wishes: {WishesHistory[2]}\n\nDays: {DaysHistory[1]} | Wishes: {WishesHistory[1]}\n\nDays: {DaysHistory[0]} | Wishes: {WishesHistory[0]}";
                    break;
            }
            DCounter = DCounter + 1;
        }

        //Patches
        public void PatchesPrediction(int PatchPos, int PatchesSince)
        {
            PatchPos = PatchPos - 1;

            int OldBigPatch = 3;
            int OldSmallPatch = 3;
            int TodayPatch;

            int CDaysGone = PatchPos;
            int CDaysLeft = 42 - CDaysGone;

            int NewBigPatch = OldBigPatch;
            int NewSmallPatch = OldSmallPatch;

            TodayPatch = OldSmallPatch + PatchesSince;
            if (TodayPatch > 8)
            {
                NewBigPatch = OldBigPatch + TodayPatch / 9;
                NewSmallPatch = TodayPatch % 9;
            }
            else
            {
                NewSmallPatch = TodayPatch;
            }
            if (PatchPos < 21)
                CBanner.Content = $"           First Half\nDays until next Banner: {20 - CDaysGone}";
            if (PatchPos >= 21 && PatchPos <= 40)
                CBanner.Content = $"           Second Half\n        Ends in {42 - CDaysGone} Days\n\nDays until next Banner: {42 - CDaysGone}";
            if (PatchPos > 40)
            {
                CBanner.Content = $"            No Banner\nDays until next Banner: 1";
            }

            CurrentPatch.Content = $"             Current Patch: {NewBigPatch}.{NewSmallPatch}             ";
            CdaysGone.Content = $"Since: {CDaysGone} Days";
            CdaysLeft.Content = $"Banner Left: {CDaysLeft - 1} Days";


            //Repeat

            int DaysUntilNextPatch;

            if (NewSmallPatch == 8)
            {
                NewSmallPatch = 0;
                NewBigPatch = NewBigPatch + 1;
            }
            else
            {
                NewSmallPatch = NewSmallPatch + 1;
            }
            DaysUntilNextPatch = CDaysLeft;

            NPatch.Content = $"            Upcoming Patch: {NewBigPatch}.{NewSmallPatch}            ";
            FirstHalf.Content = $"First Half starts in {DaysUntilNextPatch} Days\n";
            SecondHalf.Content = $"Second Half starts in {DaysUntilNextPatch + 20} Days";

            //Repeat

            if (NewSmallPatch == 8)
            {
                NewSmallPatch = 0;
                NewBigPatch = NewBigPatch + 1;
            }
            else
            {
                NewSmallPatch = NewSmallPatch + 1;
            }
            DaysUntilNextPatch = DaysUntilNextPatch + 42;

            NNPatch.Content = $"            Upcoming Patch: {NewBigPatch}.{NewSmallPatch}            ";
            NFirstHalf.Content = $"First Half starts in {DaysUntilNextPatch} Days\n";
            NSecondHalf.Content = $"Second Half starts in {DaysUntilNextPatch + 20} Days";

            //Repeat

            if (NewSmallPatch == 8)
            {
                NewSmallPatch = 0;
                NewBigPatch = NewBigPatch + 1;
            }
            else
            {
                NewSmallPatch = NewSmallPatch + 1;
            }
            DaysUntilNextPatch = DaysUntilNextPatch + 42;

            NNNPatch.Content = $"            Upcoming Patch: {NewBigPatch}.{NewSmallPatch}            ";
            NNFirstHalf.Content = $"First Half starts in {DaysUntilNextPatch} Days\n";
            NNSecondHalf.Content = $"Second Half starts in {DaysUntilNextPatch + 20} Days";
        }

        #endregion

        private void txtBox_anzAbyssStars_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}

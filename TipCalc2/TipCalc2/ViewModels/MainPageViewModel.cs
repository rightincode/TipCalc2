using System;
using System.ComponentModel;
//using TipCalc2_core.Interfaces;

namespace TipCalc2.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string totalTxt;
        private string tipTxt;
        private double tipPercent;
        private double grandTotal;

        public double Total { get; set; }

        public double Tip { get; set; }

        //*****remove after refactoring

        //uncomment to make improve testability
        //private readonly ITipCalculator _calculator;

        public MainPageViewModel()
        {            
        }

        //uncomment to make improve testability
        //public MainPageViewModel(ITipCalculator tipCalculator)
        //{
        //    _calculator = tipCalculator;
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        public string TotalTxt
        {
            get
            {
                return totalTxt;
            }

            set
            {
                totalTxt = value;

                try
                {
                    string newValue = value;

                    Total = double.Parse(newValue);
                    //_calculator.Total = double.Parse(newValue);
                }
                catch (Exception)
                {
                    Total = 0;
                    //_calculator.Total = 0;
                }
                finally
                {
                    CalcTip();
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TotalTxt"));
                }
            }
        }

        public string TipTxt
        {
            get { return tipTxt; }
            set
            {
                tipTxt = value;

                try
                {
                    string newValue = value;

                    Tip = double.Parse(newValue);
                    //_calculator.Tip = double.Parse(newValue);
                }
                catch (Exception)
                {
                    Tip = 0;
                    //_calculator.Tip = 0;
                }
                finally
                {
                    CalcTipPercentage();
                }
            }
        }
        
        public string TipPercentTxt
        {
            get { return tipPercent.ToString(); }

            //get { return _calculator.TipPercent.ToString(); }
        }

        public double TipPercent
        {
            get { return tipPercent; }

            //get { return _calculator.TipPercent; }

            set {
                tipPercent = value;
                //_calculator.TipPercent = value;
                CalcTip();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TipPercent"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TipPercentTxt"));
            }
        }

        public string GrandTotalTxt
        {
            get { return grandTotal.ToString(); }

            //get { return _calculator.GrandTotal.ToString(); }
        }

        public void CalcTip()
        {
            if (tipPercent > 0)
            {
                Tip = Total * (tipPercent / 100);
            }
            else
            {
                Tip = 0;
            }
            tipTxt = Tip.ToString();

            //_calculator.CalcTip();
            //tipTxt = _calculator.Tip.ToString();

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TipTxt"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GrandTotalTxt"));
        }

        public void CalcTipPercentage()
        {
            if (Total > 0)
            {
                tipPercent = (Tip / Total) * 100;
            }
            else
            {
                tipPercent = 0;
            }

            grandTotal = Total + Tip;

            //_calculator.CalcTipPercentage();

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TipPercent"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TipPercentTxt"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GrandTotalTxt"));
        }
    }
}

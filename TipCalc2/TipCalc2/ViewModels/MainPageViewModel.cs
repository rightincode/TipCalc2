﻿using System;
using System.ComponentModel;
using TipCalc2_core.Interfaces;

namespace TipCalc2.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string totalTxt;
        private string tipTxt;
        
        private readonly ITipCalculator _calculator;

        public MainPageViewModel(ITipCalculator tipCalculator)
        {
            _calculator = tipCalculator;
        }

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
                    _calculator.Total = double.Parse(newValue);
                }
                catch (Exception)
                {
                    _calculator.Total = 0;
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

                    _calculator.Tip = double.Parse(newValue);
                }
                catch (Exception)
                {
                    _calculator.Tip = 0;
                }
                finally
                {
                    CalcTipPercentage();
                }
            }
        }
        
        public string TipPercentTxt
        {
            get { return Math.Round(_calculator.TipPercent, 2).ToString(); }
        }

        public double TipPercent
        {
            get { return _calculator.TipPercent; }

            set {
                _calculator.TipPercent = value;
                CalcTip();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TipPercent"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TipPercentTxt"));
            }
        }

        public string GrandTotalTxt
        {
            get { return Math.Round(_calculator.GrandTotal, 2).ToString(); }
        }

        public void CalcTip()
        {
            _calculator.CalcTip();
            tipTxt = Math.Round(_calculator.Tip, 2).ToString();

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TipTxt"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GrandTotalTxt"));
        }

        public void CalcTipPercentage()
        {
            _calculator.CalcTipPercentage();

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TipPercent"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TipPercentTxt"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GrandTotalTxt"));
        }
    }
}

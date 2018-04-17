using System;
using TipCalc2.ViewModels;
using TipCalc2_core.Interfaces;
using Xamarin.Forms;

namespace TipCalc2
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel vm;

        public MainPageViewModel VM
        {
            get { return vm; }
        }

        public MainPage(ITipCalculator tipCalculator)
        {
            InitializeComponent();
            vm = new MainPageViewModel(tipCalculator);
            BindingContext = VM;
        }
    }
}

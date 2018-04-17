using System;
using TipCalc2.ViewModels;
using TipCalc2_core.Interfaces;
using Xamarin.Forms;

namespace TipCalc2
{
    public partial class MainPage : ContentPage
    {

        public MainPageViewModel VM { get; }

        public MainPage()
        {
            InitializeComponent();
            VM = new MainPageViewModel();
            BindingContext = VM;
        }

        //uncomment to make improve testability
        //public MainPage(ITipCalculator tipCalculator)
        //{
        //    InitializeComponent();
        //    vm = new MainPageViewModel(tipCalculator);
        //    BindingContext = VM;
        //}
    }
}

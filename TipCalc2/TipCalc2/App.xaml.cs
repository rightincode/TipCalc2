using System;
using Microsoft.Extensions.DependencyInjection;
using TipCalc2_core.Interfaces;
using TipCalc2_core.Models;

using Xamarin.Forms;

namespace TipCalc2
{
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;
        
        public App()
        {
            InitializeComponent();
            StartupConfiguration();

            MainPage = new NavigationPage(new MainPage(_serviceProvider.GetService<ITipCalculator>()));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        
        private void StartupConfiguration()
        {
            var services = new ServiceCollection();
            services.AddTransient<ITipCalculator, TipCalculator>();
            _serviceProvider = services.BuildServiceProvider();
        }
    }
}

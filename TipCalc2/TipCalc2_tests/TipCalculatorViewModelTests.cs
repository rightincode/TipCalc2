using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TipCalc2.ViewModels;

namespace TipCalc2_tests
{
    [TestClass]
    public class TipCalculatorViewModelTests
    {
        [TestMethod]
        public void ViewModelCalculateTipZeroPercent()
        {
            var vm = new MainPageViewModel
            {
                Total = 10,
                TipPercent = 0
            };

            vm.CalcTip();

            Assert.AreEqual(vm.Tip, 0);
        }
    }
}

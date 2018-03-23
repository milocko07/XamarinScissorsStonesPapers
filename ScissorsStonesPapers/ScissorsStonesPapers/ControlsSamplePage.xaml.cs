using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ScissorsStonesPapers
{
    public partial class ControlsSamplePage : ContentPage
    {
        public ControlsSamplePage()
        {
            InitializeComponent();
        }

        private void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            StepperValueLabel.Text = "Stepper value: " + TestStepper.Value.ToString();
        }
    }
}

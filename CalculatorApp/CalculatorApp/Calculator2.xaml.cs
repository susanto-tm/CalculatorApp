using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalculatorApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Calculator2 : ContentPage
	{
        private double _Number = 0;
        public double Number
        {
            get
            {
                return _Number;
            }
            set
            {
                _Number = value;
                displayLbl.Text = _Number.ToString();
            }
        }

        private double _Result;
        public double Result
        {
            get
            {
                return _Result;
            }

            set
            {
                _Result = value;
                displayLbl.Text = _Result.ToString();
            }
        }

        public Calculator2 ()
		{
			InitializeComponent();
		}

        private void CalculatorButtons(object sender, EventArgs e)
        {
            displayLbl.Text += ((Button)sender).Text;
            Double.TryParse(displayLbl.Text, out _Number);
        }


        #region Operation Buttons
        private void PlusButton(object sender, EventArgs e)
        {
            Result += Number;
        }

        private void MinusButton(object sender, EventArgs e)
        {
            Result -= Number;
        }

        private void MultiplyButton(object sender, EventArgs e)
        {
            Result *= Number;
        }

        private void DivideButton(object sender, EventArgs e)
        {
            Result /= Number;
        }

        private void EqualButton(object sender, EventArgs e)
        {
            Result = Number;
        }

        private void ClearButton(object sender, EventArgs e)
        {
            ClearCommand();
        }
        #endregion

        public void ClearCommand() {
            displayLbl.Text = null;
        }
    }
}
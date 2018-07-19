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
	public partial class CalculatorApp : ContentPage
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

        public int currentState;
        public string mathOperator;

        //currentState = 1 is the original state
        //currentState = 3 is after Plus button

		public CalculatorApp ()
		{
			InitializeComponent ();
            currentState = 1;
		}

        private void CalculatorButtons(object sender, EventArgs e)
        {
            if (currentState > 1)
            {
                displayLbl.Text = " ";
            }
            displayLbl.Text += ((Button)sender).Text;
            Double.TryParse(displayLbl.Text, out _Number);
            currentState = 1;
        }

        public void PlusButton(object sender, EventArgs e)
        {
            Button plus = ((Button)sender);
            Result += Number;
            _Number = _Result;
            currentState = 3;
            _Number = 0;
            mathOperator = plus.Text;
        }

        private void MinusButton(object sender, EventArgs e)
        {
            Button minus = ((Button)sender);
            Result -= Number;
            _Number = -_Result;
            currentState = 2;
            _Number = 0;
            mathOperator = minus.Text;
        }

        private void MultiplyButton(object sender, EventArgs e)
        {
            Button multiply = ((Button)sender);
            if (currentState == 1)
            {
                Result = 1;
            }
            Result *= Number;
            _Number = _Result;
            currentState = 2;
            _Number = 0;
            mathOperator = multiply.Text;
        }

        private void DivideButton(object sender, EventArgs e)
        {
            Button divide = ((Button)sender);
            if (currentState == 1)
            {
                Result = Math.Pow(Number, 2);
            }
            Result /= Number;
            _Number = _Result;
            currentState = 2;
            _Number = 0;
            mathOperator = divide.Text;
        }

        public void EqualButton(object sender, EventArgs e)
        {
            if (currentState == 1 && mathOperator == "+")
            {
                Result += Number;
            }
            else if (currentState == 1 && mathOperator == "-")
            {
                Result -= Number;
            }
            else if (currentState == 1 && mathOperator == "×")
            {
                Result *= Number;
            }
            else if (currentState == 1 && mathOperator == "÷")
            {
                Result /= Number;
            }
            currentState = 1;
            _Number = 0;
        }

        private void ClearButton(object sender, EventArgs e)
        {
            ClearCommand();
        }

        public void ClearCommand()
        {
            displayLbl.Text = null;
            _Number = 0;
            _Result = 0;
            currentState = 1;
        }
    }
}
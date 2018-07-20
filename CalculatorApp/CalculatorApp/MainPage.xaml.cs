using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculatorApp
{
    public partial class MainPage : ContentPage
    {
        private double number1, number2;
        private int currentState;
        private string mathOperator;
        CalculateResult calculateResult = new CalculateResult();

        public MainPage()
        {
            InitializeComponent();
            currentState = 1;
        }

        private void CalculatorButtons(object sender, EventArgs e)
        {
            //When a new number is selected its gonna start in a new blank label
            if (currentState > 0)
            {
                displayLbl.Text = " ";
            }
            displayLbl.Text += ((Button)sender).Text;
            //if the currentState is 1 then its gonna parse to number1 if not then parse number2
            if (currentState == 1)
            {
                Double.TryParse(displayLbl.Text, out number1);
            } 
            else
            {
                Double.TryParse(displayLbl.Text, out number2);
            }
            //Resets currentState into 2 if no equal sign is ever pressed
            if (currentState == 3)
            {
                currentState = 2;
            }
        }

        private void OperatorButton(object sender, EventArgs e)
        {
            Button operatorButton = ((Button)sender);
            if (currentState == 1)
            {
                mathOperator = operatorButton.Text;
                currentState = 2;
                //NoEqualCalculate();
            }
            else if (currentState == 2)
            {
                NoEqualCalculate();
                mathOperator = operatorButton.Text;
            }
        }

        public void CalculateNumbers()
        {
            var result = calculateResult.Result(number1, number2, mathOperator);
            displayLbl.Text = result.ToString();
            number1 = result;
        }

        public void NoEqualCalculate()
        {
            CalculateNumbers();
            currentState = 3;
        }

        private void EqualButton(object sender, EventArgs e)
        {
            if (currentState > 0)
            {
                CalculateNumbers();
                currentState = 1;
                
            }
        }

        private void ClearButton(object sender, EventArgs e)
        {
            ClearCommand();
        }

        public void ClearCommand()
        {
            displayLbl.Text = null;
            number1 = 0;
            number2 = 0;
            mathOperator = null;
            currentState = 1;
        }
    }
}
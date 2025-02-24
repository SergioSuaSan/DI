namespace MauiFlyout.Pages
{



    public partial class Calculator
    {
        public Calculator()
        {
            InitializeComponent();
            mathOperator = string.Empty;

        }
        

        string currentEntry = "";
        int currentState = 1;
        string mathOperator;
        double firstNumber, secondNumber;
        string decimalFormat = "N0";



        void OnSelectNumber(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            string pressed = button.Text;

            currentEntry += pressed;

            if ((this.resultText.Text == "0" && pressed == "0")
                || (currentEntry.Length <= 1 && pressed != "0")
                || currentState < 0)
            {
                this.resultText.Text = "";
                if (currentState < 0)
                    currentState *= -1;
            }

            if (pressed == "." && decimalFormat != "N2")
            {
                decimalFormat = "N2";
            }

            this.resultText.Text += pressed;
        }

        void OnSelectOperator(object sender, EventArgs e)
        {
            LockNumberValue(resultText.Text);

            currentState = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            mathOperator = pressed;
        }

        private void LockNumberValue(string text)
        {
            double number;
            if (double.TryParse(text, out number))
            {
                if (currentState == 1)
                {
                    firstNumber = number;
                }
                else
                {
                    secondNumber = number;
                }

                currentEntry = string.Empty;
            }
        }

        void OnClear(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            decimalFormat = "N0";
            this.resultText.Text = "0";
            currentEntry = string.Empty;
        }

        void OnCalculate(object sender, EventArgs e)
        {
            if (currentState == 2)
            {
                if (secondNumber == 0)
                    LockNumberValue(resultText.Text);

                double result = Calculate(firstNumber, secondNumber, mathOperator);

                this.CurrentCalculation.Text = $"{firstNumber} {mathOperator} {secondNumber}";

                this.resultText.Text = result.ToTrimmedString(decimalFormat);
                firstNumber = result;
                secondNumber = 0;
                currentState = -1;
                currentEntry = string.Empty;
            }
        }

        void OnNegative(object sender, EventArgs e)
        {
            if (currentState == 1)
            {
                secondNumber = -1;
                mathOperator = "×";
                currentState = 2;
                OnCalculate(sender, e);
            }
        }

        void OnPercentage(object sender, EventArgs e)
        {
            if (currentState == 1)
            {
                LockNumberValue(resultText.Text);
                decimalFormat = "N2";
                secondNumber = 0.01;
                mathOperator = "×";
                currentState = 2;
                OnCalculate(sender,e);
            }
        }
        public double Calculate(double value1, double value2, string mathOperator)
        {
            double result = 0;

            switch (mathOperator)
            {
                case "÷":
                    result = value1 / value2;
                    break;
                case "×":
                    result = value1 * value2;
                    break;
                case "+":
                    result = value1 + value2;
                    break;
                case "-":
                    result = value1 - value2;
                    break;
            }

            return result;
        }
    }

    public static class DoubleExtensions
    {
        public static string ToTrimmedString(this double target, string decimalFormat)
        {
            string strValue = target.ToString(decimalFormat); //Get the stock string

            //If there is a decimal point present
            if (strValue.Contains("."))
            {
                //Remove all trailing zeros
                strValue = strValue.TrimEnd('0');

                //If all we are left with is a decimal point
                if (strValue.EndsWith(".")) //then remove it
                    strValue = strValue.TrimEnd('.');
            }

            return strValue;
        }
     }





    

}
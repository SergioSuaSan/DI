
using MauiFlyout.Model;

namespace MauiFlyout.Pages
{
    public partial class Page1 : ContentPage
    {


        /// <summary>
        /// Constructor de la página
        /// </summary>
        public Page1()
        {
            Title = "Calculadora";

            InitializeComponent();
      
            OnClear(this, null);

        }

        string currentEntry = "";
        int currentState = 1;
        string mathOperator;
        double firstNumber, secondNumber;
        string decimalFormat = "N0";


        /// <summary>
        /// Método para manejar la selección de un número
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Método para manejar la selección de un operador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnSelectOperator(object sender, EventArgs e)
        {
            LockNumberValue(resultText.Text);

            currentState = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            mathOperator = pressed;
        }

        /// <summary>
        /// Método para bloquear el valor de un número
        /// </summary>
        /// <param name="text"></param>
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

        /// <summary>
        /// Método para limpiar la calculadora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnClear(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            decimalFormat = "N0";
            this.resultText.Text = "0";
            currentEntry = string.Empty;
        }

        /// <summary>
        /// Método para calcular el resultado de una operación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnCalculate(object sender, EventArgs e)
        {
            if (currentState == 2)
            {
                if (secondNumber == 0)
                    LockNumberValue(resultText.Text);

                double result = Calculator.Calculate(firstNumber, secondNumber, mathOperator);

                this.CurrentCalculation.Text = $"{firstNumber} {mathOperator} {secondNumber}";

                this.resultText.Text = result.ToTrimmedString(decimalFormat);
                firstNumber = result;
                secondNumber = 0;
                currentState = -1;
                currentEntry = string.Empty;
            }
        }

        /// <summary>
        /// Método para manejar el cambio de signo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnNegative(object sender, EventArgs e)
        {
            if (currentState == 1)
            {
                secondNumber = -1;
                mathOperator = "×";
                currentState = 2;
                OnCalculate(this, null);
            }
        }

        /// <summary>
        /// Método para manejar el porcentaje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnPercentage(object sender, EventArgs e)
        {
            if (currentState == 1)
            {
                LockNumberValue(resultText.Text);
                decimalFormat = "N2";
                secondNumber = 0.01;
                mathOperator = "×";
                currentState = 2;
                OnCalculate(this, null);
            }
        }
    }

}


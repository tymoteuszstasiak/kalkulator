using System;
using System.Windows.Forms;

namespace kalkulator
{
    public enum Operation
    {
        None,
        Addition,
        Subtraction,
        Division,
        Multiplication
    }

    public partial class Form1 : Form
    {
     private string _firstValue;
     private string _secondValue;
     private Operation _currentOperation = Operation.None;
     private bool _isTheResultOnTheScreen;
        
        public Form1()
        {
            InitializeComponent();
            tbWynik.Text ="0";
        }
        private void OnBtnNumberClick(object sender, EventArgs e)
        {
            var clickedValue = (sender as Button).Text;
            if (tbWynik.Text =="0" && clickedValue !=",")
                tbWynik.Text = string.Empty;
            if (_isTheResultOnTheScreen)
            {
                _isTheResultOnTheScreen = false;
                tbWynik.Text = string.Empty;
                if (clickedValue ==",")
                    clickedValue ="0,";
            }
            tbWynik.Text += clickedValue;
            
            SetResultBtnState(true);
            if (_currentOperation != Operation.None)
           
                _secondValue += clickedValue;
            else
                SetOperationBtnState(true);
        }

        private void OnBtnOperationClick(object sender, EventArgs e)
        {
            _firstValue = tbWynik.Text;

            var operation = (sender as Button).Text;


            _currentOperation = operation switch
            {
                "+" => Operation.Addition,
               "-" => Operation.Subtraction,
                "/" => Operation.Division,
                "*" => Operation.Multiplication,
                _ => Operation.None,
            };
            tbWynik.Text += $" {operation} ";

            if (_isTheResultOnTheScreen)
                _isTheResultOnTheScreen = false;

           
            SetOperationBtnState(false);
           
            SetResultBtnState(false);
        }

      
        private double Calculate(double firstNumber, double secondNumber)
        {
            switch (_currentOperation)
            {
                case Operation.None:
                return firstNumber;
                case Operation.Addition:
                return firstNumber + secondNumber;
                case Operation.Subtraction:
                return firstNumber - secondNumber;
                case Operation.Division:
                    if (secondNumber == 0)
                    {
                        MessageBox.Show("Nie mo¿na dzieliæ przez 0!");
                        return 0;
                    }
                    return firstNumber / secondNumber;
                case Operation.Multiplication:
                    return firstNumber * secondNumber;
            }
            return 0;
        }
        private void OnBtnResultClick(object sender, EventArgs e)
        {
            if (_currentOperation == Operation.None)
                return;
            var firstNumber = double.Parse(_firstValue);
            var secondNumber = double.Parse(_secondValue);

            var result = Calculate(firstNumber, secondNumber);

            tbWynik.Text = result.ToString();
            _secondValue = string.Empty;
            _currentOperation = Operation.None;

            _isTheResultOnTheScreen = true;
            SetOperationBtnState(true);
            SetResultBtnState(true);
        }
       

        private void SetOperationBtnState(bool value)
        {
            bDodawanie.Enabled = value;
           bMnozenie.Enabled = value;
           bDzielenie.Enabled = value;
           bOdejmowanie.Enabled = value;
        }
        private void OnBtnClearClick(object sender, EventArgs e)
        {
            tbWynik.Text = "0";
            _firstValue = string.Empty;
            _secondValue = string.Empty;
            _currentOperation = Operation.None;
        }
        private void SetResultBtnState(bool value)
        {
            bWynik.Enabled = value;


        }


    }



}
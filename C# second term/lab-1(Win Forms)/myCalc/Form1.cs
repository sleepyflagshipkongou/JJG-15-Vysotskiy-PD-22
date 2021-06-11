using System;
using System.Windows.Forms;

namespace myCalc
{
    public partial class Form1 : Form
    {
        private float operandOne = 0,
                      operandTwo = 0;

        private string operation = "";
        private bool operationIsSelected = false;

        public Form1()
        {
            InitializeComponent();
        }

        private String calculate(float operandOne, float operandTwo, String operation)
        {
            switch (operation)
            {
                case "+":
                    return Convert.ToString((operandOne + operandTwo)); 
                case "-":
                    return Convert.ToString((operandOne - operandTwo));
                case "*":
                    return Convert.ToString((operandOne * operandTwo));
                case "/":
                    return Convert.ToString((operandOne / operandTwo));
                case "^":
                    if (operandTwo != 0)
                        return Convert.ToString(Math.Pow(operandOne, operandTwo)); 
                    return Convert.ToString((operandOne * operandOne));
                case "sqrt":
                    return Convert.ToString(Math.Sqrt(operandOne));
                default:
                    return "";
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (operationIsSelected)
            {
                textBox1.Clear();
                operationIsSelected = false;
            }
            textBox1.Text += ((Button)sender).Text;
        }

        private void ButtonOperation_Click(object sender, EventArgs e)
        {
            operationIsSelected = true;
            operation = label1.Text = ((Button)sender).Text;
            operandOne = Convert.ToSingle(textBox1.Text);
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            textBox1.Text += button17.Text;
        }
     
        private void Button18_Click(object sender, EventArgs e)
        {
            operationIsSelected = true;
            operation = button18.Text;
            label1.Text = "s";
            operandOne = Convert.ToSingle(textBox1.Text);
        }

        private void Button19_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            try
            {
                operandTwo = Convert.ToSingle(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Ей, поле для ввода пустое!", "Ну как так то?");
                return;
            }

            textBox1.Text = calculate(operandOne, operandTwo, operation);

            operation = label1.Text = "";
            operandOne = operandTwo = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class MainForm : Form
    {
        private bool textIsLocked;

        public MainForm()
        {
            InitializeComponent();
            this.textIsLocked = false;
        }

        private bool IsNull(string str)
        {
            return string.IsNullOrEmpty(str);
        }

        private void NewOperation(string op = null)
        {
            if (IsNull(textBoxOp.Text))
            {
                if (IsNull(op) | IsNull(textBoxResult.Text))
                {
                    return;
                }

                UpdateOperator(op);

                return;
            } else
            {
                if (!IsNull(op) & IsNull(textBoxResult.Text))
                {
                    textBoxOp.Text = $" {op} ";
                } else if (IsNull(op) & IsNull(textBoxResult.Text))
                {
                    return;
                } else if (!IsNull(op) & !IsNull(textBoxResult.Text))
                {
                    double result = RunOperation(textBoxHistory.Text, textBoxResult.Text, textBoxOp.Text.Trim());
                    UpdateOperator(op, result.ToString());
                } else if (IsNull(op) & !IsNull(textBoxResult.Text))
                {
                    double result = RunOperation(textBoxHistory.Text, textBoxResult.Text, textBoxOp.Text.Trim());
                    ShowResult(result.ToString());
                }

                return;
            }
        }

        private void UpdateOperator(string op, string result = null)
        {
            textBoxOp.Text = $" {op} ";
            textBoxHistory.Text = result ?? textBoxResult.Text;
            textBoxResult.Text = "";
        }

        private void ShowResult(string result)
        {
            textBoxOp.Text = "";
            textBoxHistory.Text = "";
            textBoxResult.Text = result;
            this.textIsLocked = true;
        }

        private double RunOperation(string n1, string n2, string op)
        {
            double nn1 = Convert.ToDouble(n1);
            double nn2 = Convert.ToDouble(n2);

            switch (op)
            {
                case "+": return nn1 + nn2;

                case "-": return nn1 - nn2;

                case "x": return nn1 * nn2;

                case "/": return nn1 / nn2;
                
                default: return 0.00;
            }
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            if (this.textIsLocked)
            {
                textBoxResult.Text = "0";
            } else
            {
                textBoxResult.Text += "0";
            }
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            if (this.textIsLocked)
            {
                textBoxResult.Text = "1";
            }
            else
            {
                textBoxResult.Text += "1";
            }
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            if (this.textIsLocked)
            {
                textBoxResult.Text = "2";
            }
            else
            {
                textBoxResult.Text += "2";
            }
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            if (this.textIsLocked)
            {
                textBoxResult.Text = "3";
            }
            else
            {
                textBoxResult.Text += "3";
            }
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            if (this.textIsLocked)
            {
                textBoxResult.Text = "4";
            }
            else
            {
                textBoxResult.Text += "4";
            }
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            if (this.textIsLocked)
            {
                textBoxResult.Text = "5";
            }
            else
            {
                textBoxResult.Text += "5";
            }
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            if (this.textIsLocked)
            {
                textBoxResult.Text = "6";
            }
            else
            {
                textBoxResult.Text += "6";
            }
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            if (this.textIsLocked)
            {
                textBoxResult.Text = "7";
            }
            else
            {
                textBoxResult.Text += "7";
            }
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            if (this.textIsLocked)
            {
                textBoxResult.Text = "8";
            }
            else
            {
                textBoxResult.Text += "8";
            }
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            if (this.textIsLocked)
            {
                textBoxResult.Text = "9";
            }
            else
            {
                textBoxResult.Text += "9";
            }
        }

        private void btnComma_Click(object sender, EventArgs e)
        {
            if (this.textIsLocked)
            {
                textBoxResult.Text = "0,";
            } else
            {
                int indexOfComma = textBoxResult.Text.IndexOf(',');

                if (indexOfComma ==  -1)
                {
                    textBoxResult.Text += ",";
                }
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            NewOperation();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            NewOperation("+");
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            NewOperation("-");
        }

        private void btnDivider_Click(object sender, EventArgs e)
        {
            NewOperation("/");
        }

        private void btnMultiplier_Click(object sender, EventArgs e)
        {
            NewOperation("x");
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            textBoxHistory.ResetText();
            textBoxResult.ResetText();
            textBoxOp.ResetText();
            this.textIsLocked = false;
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            textBoxResult.ResetText();
            this.textIsLocked = false;
        }

        private void btnErase_Click(object sender, EventArgs e)
        {
            if (!IsNull(textBoxResult.Text) & !this.textIsLocked)
            {
                textBoxResult.Text = textBoxResult.Text.Remove(textBoxResult.Text.Length - 1);
            }
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (!this.textIsLocked)
            {
                double percentValue = Convert.ToDouble(textBoxResult.Text) / 100;
                textBoxResult.Text = percentValue.ToString();
            }
        }

        private void textBoxResult_TextChanged(object sender, EventArgs e)
        {
            TextBox tbr = textBoxResult;

            if (tbr.Text.Length > 1)
            {
                int indexOfComma = tbr.Text.IndexOf(',');

                if (indexOfComma == -1)
                {
                    tbr.Text = tbr.Text.TrimStart('0');
                } else
                {
                    tbr.Text = tbr.Text.Substring(0, indexOfComma) + tbr.Text.Substring(indexOfComma).TrimStart('0');
                }
            }

            if (string.IsNullOrEmpty(tbr.Text))
            {
                tbr.Text = "0";
            }
        }
    }
}

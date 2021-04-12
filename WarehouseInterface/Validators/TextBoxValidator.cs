using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace WarehouseInterface.Validators
{
    public static class TextBoxValidator
    {
        public static void NumberValidationTextBox(TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public static void DecimalValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var textBox = (System.Windows.Controls.TextBox)sender;
            var fullText = textBox.Text;

            if (e.Text == "." && fullText.Count(a => a == '.' || a == ',') < 1)
            {
                e.Handled = false;
                return;
            }
            if (e.Text == "," && fullText.Count(a => a == ',' || a == '.') < 1)
            {
                e.Handled = false;
                return;
            }

            fullText = (fullText + e.Text).Replace('.', ',');
            e.Handled = !Decimal.TryParse(fullText, out var dummy);
        }
    }
}

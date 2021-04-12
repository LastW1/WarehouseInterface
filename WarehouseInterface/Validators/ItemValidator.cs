using System;
using System.Windows.Controls;

namespace WarehouseInterface.Validators
{
    public static class ItemValidator //dopisać test
    {
        public static bool ValidateItem(
            ComboBox categoryComboBox, 
            TextBox nameTextBox, 
            ref TextBox priceTextBox, 
            TextBox countTextBox, 
            TextBox minAllertTextBox, 
            TextBox maxAllertTextBox,
            ref Image imageButtonImage)
        {
            if (categoryComboBox.SelectedValue == null)
            {
                System.Windows.Forms.MessageBox.Show("Nie podano kategorii!");
                return false;
            }

            if (priceTextBox.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Nie podano ceny produktu!");
                return false;
            }

            priceTextBox.Text = priceTextBox.Text.Replace('.', ',');
            if (!Decimal.TryParse(priceTextBox.Text, out var tmp1))
            {
                System.Windows.Forms.MessageBox.Show("Cena porduktu podana w nieprawidłowym formacie!");
                return false;
            }

            if (nameTextBox.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Nie podano nazwy produktu!");
                return false;
            }

            if (countTextBox.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Nie podano ilości produktu!");
                return false;
            }

            if (!Int32.TryParse(countTextBox.Text, out var tmp2))
            {
                System.Windows.Forms.MessageBox.Show("Ilośc porduktu podana w nieprawidłowym formacie!");
                return false;
            }

            if (!minAllertTextBox.Text.Equals("") && !Int32.TryParse(minAllertTextBox.Text, out var tmp3))
            {
                System.Windows.Forms.MessageBox.Show("Wartość minimalnego stanu ma niepoprawny format!");
                return false;
            }

            if (!maxAllertTextBox.Text.Equals("") && !Int32.TryParse(maxAllertTextBox.Text, out var tmp4))
            {
                System.Windows.Forms.MessageBox.Show("Wartość maksymalnego stanu ma niepoprawny format!");
                return false;
            }

            if (!Int32.TryParse(countTextBox.Text, out var tmp5))
            {
                System.Windows.Forms.MessageBox.Show("Ilośc porduktu podana w nieprawidłowym formacie!");
                return false;
            }

            if (imageButtonImage.Source.ToString().Equals("pack://application:,,,/WarehouseInterface;component/Images/addPictureImage.png"))
            {
                imageButtonImage.Source = null;
            }

            return true;
        }
    }
}

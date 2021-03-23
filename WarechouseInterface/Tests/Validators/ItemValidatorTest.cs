using NUnit.Framework;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WarechouseInterface.Validators;

namespace WarechouseInterface.Tests.Validators
{
    [TestFixture, RequiresSTA]
    class ItemValidatorTest
    {
        ComboBox _categoryComboBox;
        TextBox _nameTextBox;
        TextBox _priceTextBox;
        TextBox _countTextBox;
        TextBox _minAllertTextBox;
        TextBox _maxAllertTextBox;
        Image _imageButtonImage;

        [SetUp]
        public void SetUp()
        {
            _categoryComboBox = new ComboBox();
            var comboCollection = new ObservableCollection<int> { 1 };
            _categoryComboBox.ItemsSource = comboCollection;
            _categoryComboBox.SelectedItem = comboCollection.First();
            _nameTextBox = new TextBox();
            _nameTextBox.Text = "Test";
            _priceTextBox = new TextBox();
            _priceTextBox.Text = "1.1";
            _countTextBox = new TextBox();
            _countTextBox.Text = "1";
            _minAllertTextBox = new TextBox();
            _maxAllertTextBox = new TextBox();
            _imageButtonImage = new Image();
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri("pack://application:,,,/WarechouseInterface;component/Images/addPictureImage.png"); ;
            bitmapImage.EndInit();
            _imageButtonImage.Source = bitmapImage;
        }

        [Test]
        public void ValidateItem_WhenCorrectDataGiven_ShouldReturnTrue_Test()
        {
            Assert.IsTrue(ItemValidator.ValidateItem(_categoryComboBox, _nameTextBox, ref _priceTextBox, _countTextBox, _minAllertTextBox, _maxAllertTextBox, ref _imageButtonImage));
            Assert.IsNull(_imageButtonImage.Source);
            Assert.AreEqual(_priceTextBox.Text, "1,1");
        }

        [Test]
        public void ValidateItem_WhenNameNotGiven_ShouldReturnFalse_Test()
        {
            _nameTextBox.Text = "";
            Assert.IsFalse(ItemValidator.ValidateItem(_categoryComboBox, _nameTextBox, ref _priceTextBox, _countTextBox, _minAllertTextBox, _maxAllertTextBox, ref _imageButtonImage));
        }

        [Test]
        public void ValidateItem_WhenCategoryNotGiven_ShouldReturnFalse_Test()
        {
            _categoryComboBox.SelectedItem = null;
            Assert.IsFalse(ItemValidator.ValidateItem(_categoryComboBox, _nameTextBox, ref _priceTextBox, _countTextBox, _minAllertTextBox, _maxAllertTextBox, ref _imageButtonImage));
        }

        [Test]
        public void ValidateItem_WhenCountNotGiven_ShouldReturnFalse_Test()
        {
            _countTextBox.Text = "";
            Assert.IsFalse(ItemValidator.ValidateItem(_categoryComboBox, _nameTextBox, ref _priceTextBox, _countTextBox, _minAllertTextBox, _maxAllertTextBox, ref _imageButtonImage));
        }

        [Test]
        public void ValidateItem_WhenInvalidCountGiven_ShouldReturnFalse_Test()
        {
            _countTextBox.Text = "not int";
            Assert.IsFalse(ItemValidator.ValidateItem(_categoryComboBox, _nameTextBox, ref _priceTextBox, _countTextBox, _minAllertTextBox, _maxAllertTextBox, ref _imageButtonImage));
        }

        [Test]
        public void ValidateItem_WhenPriceNotGiven_ShouldReturnFalse_Test()
        {
            _priceTextBox.Text = "";
            Assert.IsFalse(ItemValidator.ValidateItem(_categoryComboBox, _nameTextBox, ref _priceTextBox, _countTextBox, _minAllertTextBox, _maxAllertTextBox, ref _imageButtonImage));
        }

        [Test]
        public void ValidateItem_WhenInvalidPriceGiven_ShouldReturnFalse_Test()
        {
            _countTextBox.Text = "not decimal";
            Assert.IsFalse(ItemValidator.ValidateItem(_categoryComboBox, _nameTextBox, ref _priceTextBox, _countTextBox, _minAllertTextBox, _maxAllertTextBox, ref _imageButtonImage));
        }

        [Test]
        public void ValidateItem_WhenInvalidMinAllertGiven_ShouldReturnFalse_Test()
        {
            _minAllertTextBox.Text = "not int";
            Assert.IsFalse(ItemValidator.ValidateItem(_categoryComboBox, _nameTextBox, ref _priceTextBox, _countTextBox, _minAllertTextBox, _maxAllertTextBox, ref _imageButtonImage));
        }

        [Test]
        public void ValidateItem_WhenInvalidMaxAllertGiven_ShouldReturnFalse_Test()
        {
            _maxAllertTextBox.Text = "not int";
            Assert.IsFalse(ItemValidator.ValidateItem(_categoryComboBox, _nameTextBox, ref _priceTextBox, _countTextBox, _minAllertTextBox, _maxAllertTextBox, ref _imageButtonImage));
        }
    }
}

using ECommerce.Commands;
using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ECommerce.Domain.ViewModels
{
    internal class UpdateProductUCViewModel : BaseViewModel
    {
        public RelayCommand BackCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }

        private Product productInfo;

        public Product ProductInfo
        {
            get { return productInfo; }
            set { productInfo = value; OnPropertyChanged(); }
        }

        public UpdateProductUCViewModel(Product _productInfo)
        {
            ProductInfo = _productInfo;
            var productRepo = new ProductRepository();

            BackCommand = new RelayCommand((b) =>
            {
                var adminPage = new AdminPageUC();
                var adminPageViewModel = new AdminPageUCViewModel();
                adminPage.DataContext = adminPageViewModel;
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(adminPage);
            });

            UpdateCommand = new RelayCommand((b) =>
            {
                if (string.IsNullOrWhiteSpace(productInfo.Name) || string.IsNullOrWhiteSpace(productInfo.Description))
                {
                    MessageBox.Show("Fill Form Completely!");
                    return;
                }
                productRepo.UpdateData(productInfo);
                MessageBox.Show("Product was updated successfully!");
                BackCommand.Execute(null);
            });
        }

        private static readonly Regex OnlyNumberRegex = new Regex("[0-9]+");
        public void IsAllowedInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private static bool IsTextAllowed(string text)
        {
            return OnlyNumberRegex.IsMatch(text);
        }
    }
}

using ECommerce.Commands;
using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ECommerce.Domain.ViewModels
{
    public class AddProductUCViewModel : BaseViewModel
    {
        public RelayCommand BackCommand { get; set; }
        public RelayCommand AddCommand { get; set; }

        private Product productInfo;

        public Product ProductInfo
        {
            get { return productInfo; }
            set { productInfo = value; OnPropertyChanged(); }
        }

        public AddProductUCViewModel()
        {
            ProductInfo = new Product();
            var productRepo = new ProductRepository();

            BackCommand = new RelayCommand((b) =>
            {
                var adminPage = new AdminPageUC();
                var adminPageViewModel = new AdminPageUCViewModel();
                adminPage.DataContext = adminPageViewModel;
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(adminPage);
            });

            AddCommand = new RelayCommand((b) =>
            {
                if (string.IsNullOrWhiteSpace(productInfo.Name) || string.IsNullOrWhiteSpace(productInfo.Description))
                {
                    MessageBox.Show("Fill Form Completely!");
                    return;
                }
                productRepo.AddData(productInfo);
                MessageBox.Show("Product was added successfully!");
                BackCommand.Execute(null);
            });
        }
    }
}

using ECommerce.Commands;
using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Views;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.ViewModels
{
    public class AdminPageUCViewModel : BaseViewModel
    {
        public RelayCommand BackCommand { get; set; }
        public RelayCommand AddCommand { get; set; }

        public ObservableCollection<Product> AllProducts { get; set; }

        private Product selectedProduct;

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value; OnPropertyChanged(); SelectionChanged(); }
        }

        public void SelectionChanged()
        {
            if (SelectedProduct != null)
            {
                var productInfo = (Product)selectedProduct;
                var updatePage = new UpdateProductUC();
                var updatePageViewModel = new UpdateProductUCViewModel(productInfo);
                updatePage.DataContext = updatePageViewModel;
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(updatePage);
            }
        }

        public AdminPageUCViewModel()
        {
            var productRepo = new ProductRepository();
            AllProducts = productRepo.GetAllData();
            SelectedProduct = null;

            BackCommand = new RelayCommand((b) =>
            {
                var homePage = new HomePageUC();
                var homePageViewModel = new HomePageUCViewModel(productRepo);
                homePage.DataContext = homePageViewModel;
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(homePage);
            });

            AddCommand = new RelayCommand((b) =>
            {
                var addPage = new AddProductUC();
                var addPageViewModel = new AddProductUCViewModel();
                addPage.DataContext = addPageViewModel;
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(addPage);
            });
        }
    }
}

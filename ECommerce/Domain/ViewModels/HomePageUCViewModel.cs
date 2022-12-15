using ECommerce.Commands;
using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Abstractions;
using ECommerce.Domain.Services;
using ECommerce.Domain.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.ViewModels
{
    public class HomePageUCViewModel : BaseViewModel
    {
        public RelayCommand ToLowerCommand { get; set; }
        public RelayCommand SelectProductCommand { get; set; }
        public RelayCommand AdminCommand { get; set; }
        public RelayCommand OrdersCommand { get; set; }

        private readonly IRepository<Product> _productRepo;
        private readonly ProductService _productService;

        private ObservableCollection<Product> allProducts;

        public ObservableCollection<Product> AllProducts
        {
            get { return allProducts; }
            set { allProducts = value; OnPropertyChanged(); }
        }

        private Product selectedProduct;

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value; OnPropertyChanged(); }
        }

        private string filterText;

        public string FilterText
        {
            get { return filterText; }
            set { filterText = value; OnPropertyChanged(); }
        }

        public bool IsLower { get; set; } = false;

        public HomePageUCViewModel(IRepository<Product> productRepo)
        {
            FilterText = "Lower To Higher";
            SelectedProduct = new Product();
            AllProducts = _productRepo.GetAllData();
            _productRepo = productRepo;
            _productService = new ProductService();

            #region AddProduct
            //_productRepo.AddData(new Product()
            //{
            //    Id = 10,
            //    Name = "Iphnone 8+",
            //    Description = "Good Phone",
            //    Price = 1000,
            //    Discount = 2,
            //    Quantity=20
            //});

            //_productRepo.AddData(new Product()
            //{
            //    Id = 11,
            //    Name = "Iphnone 13 PRO MAX",
            //    Description = "New Phone",
            //    Price = 2600,
            //    Discount = 0,
            //    Quantity = 80
            //});

            //_productRepo.AddData(new Product()
            //{
            //    Id = 12,
            //    Name = "Samsung S23",
            //    Description = "Android Phone",
            //    Price = 1290,
            //    Discount=10,
            //    Quantity = 56
            //});

            //_productRepo.AddData(new Product()
            //{
            //    Id = 13,
            //    Name = "Xiaomi",
            //    Description = "Phone",
            //    Price = 800,
            //    Discount = 7,
            //    Quantity = 14
            //});
            #endregion

            ToLowerCommand = new RelayCommand((o) =>
            {
                if (!IsLower)
                {
                    FilterText = "Lower To Higher";
                }
                else
                {
                    FilterText = "Higher To Lower";
                }
                IsLower = !IsLower;
                AllProducts = _productService.GetFromLowerToHigher(IsLower);
            });


            SelectProductCommand = new RelayCommand((o) =>
            {
                var vm = new ProductInfoViewModel();
                vm.ProductInfo = SelectedProduct;
                var view = new ProductWindow();
                view.DataContext = vm;

                view.ShowDialog();
            });

            AdminCommand = new RelayCommand((a) =>
            {
                var adminPage = new AdminPageUC();
                var adminPageViewModel = new AdminPageUCViewModel();
                adminPage.DataContext = adminPageViewModel;
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(adminPage);
            });

            OrdersCommand = new RelayCommand((o) => 
            {

            });
        }
    }
}

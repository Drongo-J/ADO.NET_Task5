using ECommerce.Commands;
using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Models;
using ECommerce.Domain.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.ViewModels
{
    public class OrdersUCViewModel : BaseViewModel
    {
        public RelayCommand BackCommand { get; set; }

        public ObservableCollection<Order> Orders { get; set; }
        public ObservableCollection<OrderModel> AllOrders { get; set; } = new ObservableCollection<OrderModel>();

        public double Total { get; set; }

        public OrdersUCViewModel()
        {   
            var orderRepo = new OrderRepository();
            Orders = orderRepo.GetAllData();
            foreach (var order in Orders)
            {
                var orderModel = new OrderModel(order);
                AllOrders.Add(orderModel);
            }

            Total = 4 * 3;
            BackCommand = new RelayCommand((b) =>
            {
                var homePage = new HomePageUC();
                var homePageViewModel = new HomePageUCViewModel(new ProductRepository());
                homePage.DataContext = homePageViewModel;
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(homePage);
            });
        }
    }
}

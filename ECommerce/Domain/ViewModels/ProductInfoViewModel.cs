﻿using ECommerce.Commands;
using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Abstractions;
using ECommerce.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ECommerce.Domain.ViewModels
{
    public class ProductInfoViewModel:BaseViewModel
    {
        private readonly IRepository<Product> _productRepo;
        private readonly IRepository<Order> _orderRepo;
        private readonly CustomerService _customerService;

        public ProductInfoViewModel()
        {
            _productRepo = new ProductRepository();
            _orderRepo = new OrderRepository();
            _customerService = new CustomerService();

            ProductInfo = new Product();

            OrderCommand = new RelayCommand((o) =>
            {
                var customer = _customerService.GetCustomerByUsername(Username);
                if(customer != null)
                {
                    if (ProductInfo.Quantity >= Amount)
                    {
                        ProductInfo.Quantity -= Amount;

                        var order = new Order();
                        order.Amount= Amount;
                        order.CustomerId = customer.Id;
                        order.ProductId = ProductInfo.Id;
                        order.Date = DateTime.Now;

                        _productRepo.UpdateData(ProductInfo);
                        _orderRepo.AddData(order);

                        MessageBox.Show("Order added successfully");
                    }
                    else
                    {
                        MessageBox.Show($"{Amount}  is greater that we have");
                    }
                }
                else
                {
                    MessageBox.Show($"{username}  customer does not exists");
                }
            });
        }


        public RelayCommand OrderCommand { get; set; }

        private Product productInfo;

        public Product ProductInfo
        {
            get { return productInfo; }
            set { productInfo = value; OnPropertyChanged(); }
        }

        private int amount;

        public int Amount
        {
            get { return amount; }
            set { amount = value; OnPropertyChanged(); }
        }

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged(); }
        }





    }
}

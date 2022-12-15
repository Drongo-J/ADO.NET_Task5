using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Services
{
    public class ProductService
    {
        private readonly IRepository<Product> _productRepo;
        public ProductService()
        {
            _productRepo = new ProductRepository();
        }

        public ObservableCollection<Product> GetFromLowerToHigher(bool isLower)
        {
            IOrderedEnumerable<Product> items = null;
            if (isLower)
            {
                 items = from p in _productRepo.GetAllData()
                            orderby p.Price descending
                            select p;
            }
            else
            {
                items = from p in _productRepo.GetAllData()
                            orderby p.Price ascending
                            select p;
            }


            return new ObservableCollection<Product>(items);
        }
    }
}

using ECommerce.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.SqlServer
{
    public class ProductRepository : IProductRepository
    {
        private ECommerceDataClassesDataContext _dataContext;
        public ProductRepository()
        {
            _dataContext = new ECommerceDataClassesDataContext();
        }
        public void AddData(Product data)
        {
            _dataContext.Products.InsertOnSubmit(data);
            _dataContext.SubmitChanges();
        }

        public void DeleteData(Product data)
        {
            _dataContext.Products.DeleteOnSubmit(data);
            _dataContext.SubmitChanges();
        }

        public ObservableCollection<Product> GetAllData()
        {
            var products = from p in _dataContext.Products
                           select p;
            return new ObservableCollection<Product>(products);
        }

        public Product GetData(int id)
        {
            return _dataContext.Products.SingleOrDefault(p => p.Id == id);
        }

        public void UpdateData(Product data)
        {
            var item = _dataContext.Products.SingleOrDefault(p => p.Id == data.Id);

            item.Name = data.Name;
            item.Price = data.Price;
            item.Description = data.Description;
            item.Quantity = data.Quantity;
            item.Discount = data.Discount;

            _dataContext.SubmitChanges();
        }
    }
}

using ECommerce.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.SqlServer
{
    public class CustomerRepository : ICustomerRepository
    {
        private ECommerceDataClassesDataContext _dataContext;
        public CustomerRepository()
        {
            _dataContext = new ECommerceDataClassesDataContext();
        }
        public void AddData(Customer data)
        {
            _dataContext.Customers.InsertOnSubmit(data);
            _dataContext.SubmitChanges();
        }

        public void DeleteData(Customer data)
        {
            _dataContext.Customers.DeleteOnSubmit(data);
            _dataContext.SubmitChanges();
        }

        public ObservableCollection<Customer> GetAllData()
        {
            var customers = from c in _dataContext.Customers
                            select c;
            return new ObservableCollection<Customer>(customers);
        }

        public Customer GetData(int id)
        {
            return _dataContext.Customers.SingleOrDefault(c => c.Id == id);
        }

        public void UpdateData(Customer data)
        {
            var item = _dataContext.Customers.SingleOrDefault(c => c.Id == data.Id);

            item.Id = data.Id;
            item.Username = data.Username;
            item.Orders = data.Orders;

            _dataContext.SubmitChanges();
        }
    }
}

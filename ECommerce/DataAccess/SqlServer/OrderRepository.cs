using ECommerce.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.SqlServer
{
    public class OrderRepository : IOrderRepository
    {
        private ECommerceDataClassesDataContext _dataContext;
        public OrderRepository()
        {
            _dataContext = new ECommerceDataClassesDataContext();
        }

        public void AddData(Order data)
        {
            _dataContext.Orders.InsertOnSubmit(data);
            _dataContext.SubmitChanges();
        }

        public void DeleteData(Order data)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Order> GetAllData()
        {
            var orders = from o in _dataContext.Orders
                         select o;
            return new ObservableCollection<Order>(orders);
        }

        public Order GetData(int id)
        {
            return _dataContext.Orders.SingleOrDefault(o => o.Id == id);
        }

        public void UpdateData(Order data)
        {
            var item = _dataContext.Orders.SingleOrDefault(o => o.Id == data.Id);

            item.Id = data.Id;
            item.ProductId = data.ProductId;
            item.CustomerId = data.CustomerId;
            item.Date = data.Date;
            item.Amount = data.Amount;

            _dataContext.SubmitChanges();
        }
    }
}

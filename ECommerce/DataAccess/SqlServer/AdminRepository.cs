using ECommerce.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.SqlServer
{
    public class AdminRepository : IAdminRepository
    {
        private ECommerceDataClassesDataContext _dataContext;
        public AdminRepository()
        {
            _dataContext = new ECommerceDataClassesDataContext();
        }

        public void AddData(Admin data)
        {
            _dataContext.Admins.InsertOnSubmit(data);
            _dataContext.SubmitChanges();
        }

        public void DeleteData(Admin data)
        {
            _dataContext.Admins.DeleteOnSubmit(data);
            _dataContext.SubmitChanges();   
        }

        public ObservableCollection<Admin> GetAllData()
        {
            var admins = from a in _dataContext.Admins
                         select a;
            return new ObservableCollection<Admin>(admins);
        }

        public Admin GetData(int id)
        {
            var admin = _dataContext.Admins.SingleOrDefault(a => a.Id == id);
            return admin;
        }

        public void UpdateData(Admin data)
        {
            var item = _dataContext.Admins.SingleOrDefault(a=>a.Id == data.Id);

            item.Id = data.Id;
            item.Username = data.Username;
            item.Password = data.Password;

            _dataContext.SubmitChanges();
        }
    }
}

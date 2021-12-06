using FluentApi.Domain.Abstractions;
using FluentApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FluentApi.DataAccess.EFrameworkServer
{
    public class EFCustomerRepository : ICustomerRepository
    {
        public void AddData(Customer data)
        {
            try
            {
                using (var context = new MyContext())
                {
                    context.Customers.Add(data);
                    context.SaveChanges();
                }
            }   
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    MessageBox.Show($"Entity of type \"{0}\" in state \"{1}\" has the following validation errors:,{ eve.Entry.Entity.GetType().Name}, {eve.Entry.State}");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        MessageBox.Show($"- Property: \"{ 0}\", Error: {1}, { ve.PropertyName}, {ve.ErrorMessage}");
                    }
                }
                throw;
            }
           
        }

        public void DeleteData(Customer data)
        {
            using (var context = new MyContext())
            {

                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public ObservableCollection<Customer> GetAllData()
        {
            var customers = new ObservableCollection<Customer>();
            using (var context=new MyContext())
            {
                customers = new ObservableCollection<Customer>(context.Customers);
            }
            return customers;
        }

        public Customer GetData(int id)
        {
            using (var context =  new MyContext())
            {
                var data = context.Customers.Include("Orders").FirstOrDefault(c => c.Id == id);
                return data;
            }
        }

        public void UpdateData(Customer data)
        {
            using (var context = new MyContext())
            {
                context.Entry(data).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

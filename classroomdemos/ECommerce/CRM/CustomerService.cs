using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM
{
    public  class CustomerService : ICustomerService
    {
        private List<Customer> _customerList;
        public CustomerService()
        {
            this._customerList = new List<Customer>();

        }
        public bool Delete(int id)
        {
            Customer theCustomer=this.Get(id);
            return this._customerList.Remove(theCustomer); 
        }

        public Customer Get(int id)
        {
            foreach (Customer customer in _customerList)
            {
                if(customer.Id == id) 
                    return customer;
            }
           return null;
        }

        public List<Customer> GetAll()
        {
            return _customerList;

        }

        public bool Insert(Customer customer)
        {
           this._customerList.Add(customer);
            return true;
        }

        public bool Update(Customer customer)
        {
            Customer theCustomer = this.Get(customer.Id);
            theCustomer.FirstName = customer.FirstName;
            theCustomer.LastName=customer.LastName;
            theCustomer.Email = customer.Email;
            return true;
            // this._customerList.Remove(theCustomer);
           // this._customerList.Add(customer);
        }
    }
}

using Domain.SearchCriterias;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> Get();
        Customer Get(int id);
        void Add(Customer customer);
        void Update(Customer customer);
        void Remove(int id);
        Customer Get(string login);

        IEnumerable<Customer> Get(CustomerSearchCriteria criteria);
    }
}

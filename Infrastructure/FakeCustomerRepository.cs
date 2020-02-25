using Bogus;
using Domain;
using Domain.SearchCriterias;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure
{
    public class CustomerOptions
    {
        public int Count { get; set; }
    }

    public class FakeCustomerRepository : ICustomerRepository
    {
        private readonly ICollection<Customer> customers;

        public FakeCustomerRepository(Faker<Customer> faker, IOptions<CustomerOptions> options)
        {
            customers = faker.Generate(options.Value.Count);

        }

        public void Add(Customer customer)
        {
            customers.Add(customer);
        }

        public IEnumerable<Customer> Get()
        {
            return customers;
        }

        public Customer Get(int id)
        {
            return customers.SingleOrDefault(c => c.Id == id);
        }

        public Customer Get(string login)
        {
            return customers.SingleOrDefault(c => c.Login == login);
        }

        public IEnumerable<Customer> Get(CustomerSearchCriteria criteria)
        {
            var query = customers.AsQueryable();

            if (!string.IsNullOrEmpty(criteria.City))
            {
                query = query.Where(c => c.FirstName == criteria.City);
            }

            if (!string.IsNullOrEmpty(criteria.Street))
            {
                query = query.Where(c => c.LastName == criteria.Street);
            }


            return query.ToList();


        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }


    public class DbCustomerRepository : ICustomerRepository
    {
        private readonly CustomersContext context;

        public DbCustomerRepository(CustomersContext context)
        {
            this.context = context;
        }

        public void Add(Customer customer)
        {
            
        }

        public IEnumerable<Customer> Get()
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Get(string login)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> Get(CustomerSearchCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}

using Bogus;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class CustomerFaker : Faker<Customer>
    {
        public CustomerFaker()
        {
            UseSeed(1);
            StrictMode(true);
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            RuleFor(p => p.IsRemoved, f => f.Random.Bool(0.3f));
            // Ignore(p => p.Login);
            RuleFor(p => p.Login, f => f.Person.UserName);
        }
    }
}
